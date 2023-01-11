using ControlGallery;
using DBHandler;
using FMSMonitoringUI.Controlls;
using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
using MySqlX.XDevAPI;
using Novasoft.Logger;
using OPCUAClientClassLib;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FMSMonitoringUI
{
    public partial class CtrlFormationCHG : UserControlRoot
    {
        #region [Variable]
        private Logger _Logger;

        private string _EqpID = string.Empty;
        #endregion

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        //private MySqlManager _mysql;

        /// <summary>
        /// First=Charger UnitID, Second=Charger Control
        /// </summary>
        private Dictionary<string, CtrlRack> _ListCharger = new Dictionary<string, CtrlRack>();

        public CtrlFormationCHG()
        {
            InitializeComponent();

            InitFormationBox();

            //_mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);

            InitControls();

            // Timer
            //m_timer.Tick += new EventHandler(OnTimer);
            //m_timer.Stop();
        }

        //private void CtrlFormationBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{

        //}

        #region ProcessStart
        public void ProcessStart(bool start)
        {
            if (start)
            {
                _TheadVisiable = true;

                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    _ProcessThread = new Thread(() => ProcessThreadCallback());
                    _ProcessThread.IsBackground = true; _ProcessThread.Start();
                }));
            }
            else
            {
                if (this._TheadVisiable && this._ProcessThread.IsAlive)
                    this._TheadVisiable = false;

                if (this._TheadVisiable)
                    this._ProcessThread.Abort();
            }            

            // Timer
            //if (onoff) m_timer.Start();
            //else m_timer.Stop();
        }
        #endregion

        private void InitFormationBox()
        {
            //ctrlFormationBoxCHG1_01.Name = "F101";
            //ctrlFormationBoxCHG1_02.Name = "F102";
            //ctrlFormationBoxCHG1_03.Name = "F103";
            //ctrlFormationBoxCHG1_04.Name = "F104";
            //ctrlFormationBoxCHG2_01.Name = "F201";
            //ctrlFormationBoxCHG2_02.Name = "F202";
            //ctrlFormationBoxCHG2_03.Name = "F203";
            //ctrlFormationBoxCHG2_04.Name = "F204";
            //ctrlFormationBoxCHG3_01.Name = "F301";
            //ctrlFormationBoxCHG3_02.Name = "F302";
            //ctrlFormationBoxCHG3_03.Name = "F303";
            //ctrlFormationBoxCHG3_04.Name = "F304";

            //ctrlFormationBoxCHG1_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG1_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG1_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG1_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG2_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG2_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG2_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG2_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG3_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG3_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG3_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            //ctrlFormationBoxCHG3_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;

            this.HandleDestroyed += CtrlFormation_HandleDestroyed;

        }

        private void InitControls()
        {
            _ListCharger.Clear();

            foreach (var ctl in splitContainer1.Panel1.Controls)
            {   
                if (ctl.GetType() == typeof(CtrlRack))
                {
                    CtrlRack charger = ctl as CtrlRack;

                    charger.MouseDoubleClick += Charger_MouseDoubleClick;
                    _ListCharger.Add(charger.UnitID, charger);

                    if (_EqpID == "") _EqpID = charger.EqpID;
                }
            }
        }

        #region SetData
        public void SetData(List<_ctrl_formation_chg> data)
        {
            if (data.Count == 0) return;

            for (int i = 0; i < data.Count; i++)
            {
                CtrlRack chg = _ListCharger[data[i].UNIT_ID];
                chg.SetData(data[i].TRAY_ID, data[i].TRAY_ID_2, data[i].JIG_AVG, data[i].START_TIME, data[i].PLAN_TIME);
            }

            ctrlRackTemp.SetData(data);
        }
        #endregion

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    RESTClient rest = new RESTClient();
                    // Set Query
                    StringBuilder strSQL = new StringBuilder();

                    strSQL.Append(" SELECT A.unit_id, A.eqp_name, A.eqp_name_local, A.tray_id, A.tray_id_2, A.start_time, A.plan_time,");
                    strSQL.Append("        B.*");
                    strSQL.Append(" FROM fms_v.tb_mst_eqp   A, fms_v.tb_dat_temp_unit   B");
                    //필수값
                    strSQL.Append($" WHERE A.eqp_id = '{_EqpID}'");
                    strSQL.Append($"    AND A.unit_id = B.unit_id");
                    strSQL.Append($"    AND B.event_time = (SELECT MAX(event_time) FROM tb_dat_temp_unit)");
                    strSQL.Append($" ORDER BY A.unit_id");

                    string jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                    if (jsonResult != null)
                    {
                        _jsonCtrlFormationCHGResponse result = rest.ConvertCtrlFormationCHG(jsonResult);

                        this.BeginInvoke(new Action(() => SetData(result.DATA)));
                    }

                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### FormationCHG ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        private void Charger_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CtrlRack unit = sender as CtrlRack;

            WinFormationBox form = new WinFormationBox(unit.EqpID, unit.UnitID);
            form.ShowDialog();
        }

        public static CtrlFormationBoxCHG FindByName(Control root, string strName)
        {
            for (int i = 0; i < root.Controls.Count; i++)
            {
                if (root.Controls[i] is ElementHost)
                {
                    if (((ElementHost)root.Controls[i]).Child is CtrlFormationBoxCHG)
                    {
                        CtrlFormationBoxCHG eh = (CtrlFormationBoxCHG)((ElementHost)root.Controls[i]).Child;
                        if (eh.Name == strName)
                            return eh;
                    }
                }
            }

            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //InitControls();

            //for (int i = 1; i <= 3; i++)
            //{
            //    for (int j = 1; j <= 4; j++)
            //    {
            //        string rackid = string.Format($"F{i}0{j}");
            //        CtrlFormationBoxCHG formationCell = FindByName(panelCHG, rackid);

            //        string[] trayID = { $"TrayIDTT{i}00{j}", $"TrayIDBB{i}00{j}" };
            //        string startTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //        string templature = string.Format($"{i+40}℃");
            //        string lotID = string.Format($"LotID{i}00{j}");

            //        formationCell.setBox(trayID, startTime, templature, lotID);
            //    }
            //}

            //string trayID1 = string.Format($"TrayID0001");
            //string startTime1 = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //string templature1 = string.Format($"{40}℃");
            //string pressure1 = string.Format($"{40}kgf");
            //string lotID1 = string.Format($"LotID0001");

            //CtrlFormationBoxHPC hpc = (CtrlFormationBoxHPC)HPC1.Child;
            //hpc.setBox(trayID1, lotID1, templature1, pressure1, startTime1);

            //hpc = (CtrlFormationBoxHPC)HPC2.Child;
            //hpc.setBox(trayID1, lotID1, templature1, pressure1, startTime1);

            //CtrlFormationBoxJIG jig = (CtrlFormationBoxJIG)JIG1.Child;
            //jig.setBox(templature1);

            //jig = (CtrlFormationBoxJIG)JIG2.Child;
            //jig.setBox(templature1);



            //updateTable();

            //DataSet ds = _mysql.SelectChargerInfo();
        }


        private void updateTable()
        {
            try
            {
                int idx = 1;

                for (int bay = 1; bay <= 3; bay++)
                {
                    for (int floor = 1; floor <= 4; floor++)
                    {
                        //string trayid1 = string.Format($"F101BCHG101{{0:D2}}", idx);
                        //string unitid = string.Format($"CHG0110{bay}0{floor}");

                        //_mysql.UpdateChargerInfo("tray_id_2", trayid1, "unit_id", unitid);

                        string value = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                        string unitid = string.Format($"CHG0110{bay}0{floor}");

                        //_mysql.UpdateChargerInfo("start_time", value, "unit_id", unitid);



                        idx++;
                    }
                }
                    

                //_mysql.Open();

                //int idx = 1;
                ////accounts_table의 특정 id의 name column과 phone column 데이터를 수정합니다.
                //for (int line = 1; line <= 4; line++)
                //{
                //    for (int bay = 1; bay <= 17; bay++)
                //    {
                //        for (int deck = 1; deck <= 5; deck++)
                //        {
                //            //string trayid1 = string.Format($"F101EEFB101{{0:D5}}", idx);
                //            //string trayid2 = string.Format($"F101FFFB102{{0:D5}}", idx);
                //            //string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                //            //                                   $"SET tray_id_1 = '{trayid1}', tray_id_2 = '{trayid2}' " +
                //            //                                   $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);


                //            //string starttime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                //            //string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                //            //                                   $"SET start_time = '{starttime}' " +
                //            //                                   $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);

                //            string starttime = "G";
                //            string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                //                                               $"SET status = '{starttime}' " +
                //                                               $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);



                //            MySqlCommand command = new MySqlCommand(updateQuery, _mysql);

                //            command.ExecuteNonQuery();

                //            //if (command.ExecuteNonQuery() != 1)
                //            //    MessageBox.Show("Failed to delete data.");

                //            idx++;
                //        }

                //    }
                //}

                //_mysql.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //private void OnTimer(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        m_timer.Stop();

        //        Task task = LoadChargerRackData();

        //        if (m_timer.Interval != 5000)
        //            m_timer.Interval = 5000;
        //        m_timer.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
        //    }
        //}

        private void CtrlFormation_HandleDestroyed(object sender, EventArgs e)
        {
            m_timer.Stop();
        }

        private async Task LoadChargerRackData()
        {
            try
            {
                Task task = ChargerDataView();
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadChargerRackData] {0}", ex.ToString()));
            }
        }

        private async Task<bool> ChargerDataView()
        {
            try
            {
                //if (this.InvokeRequired)
                {
                    await Task.Run(() =>
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            UpdateCharger();
                        }));

                        //this.BeginInvoke(new Action(() => UpdateCharger()));
                    });
                }
            }
            catch (Exception ex)        // 예외처리
            {
                Console.WriteLine(string.Format("[Exception:ChargerDataView] {0}", ex.ToString()));
                // Return
                return false;
            }

            // Return
            return true;
        }

        private void UpdateCharger()
        {
            //DataSet ds = _mysql.SelectChargerInfo();

            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    string unit_id = row["unit_id"].ToString();

            //    CtrlRack chg = _ListCharger[unit_id];
            //    chg.SetData(row);
            //}
        }
    }
}
