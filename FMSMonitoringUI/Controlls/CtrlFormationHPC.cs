using ControlGallery;
using DBHandler;
using FMSMonitoringUI.Controlls;
using FMSMonitoringUI.Controlls.WindowsForms;
using FormationMonCtrl;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MySqlX.XDevAPI;
using Novasoft.Logger;
using OPCUAClientClassLib;
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
using System.Web.Http.Results;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FMSMonitoringUI
{
    public partial class CtrlFormationHPC : UserControlRoot
    {
        #region [Variable]
        private Logger _Logger;

        private string _EqpID = string.Empty;

        /// <summary>
        /// string=Eqp Text, Color=Eqp Status Color
        /// </summary>
        private Dictionary<string, Color> _EqpStatus;
        private Dictionary<int, Color> _OpMode;
        #endregion

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        //private MySqlManager _mysql;

        /// <summary>
        /// First=Charger UnitID, Second=Charger Control
        /// </summary>
        private Dictionary<string, CtrlHPC> _ListHPC = new Dictionary<string, CtrlHPC>();

        public CtrlFormationHPC()
        {
            InitializeComponent();

            _EqpStatus = new Dictionary<string, Color>();
            _OpMode = new Dictionary<int, Color>();

            InitFormationBox();

            //_mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);

            // Timer
            //m_timer.Tick += new EventHandler(OnTimer);
            //m_timer.Stop();
        }

        #region CtrlFormationHPC Load
        private void CtrlFormationHPC_Load(object sender, EventArgs e)
        {
            InitLanguage();
            InitControls();
        }
        #endregion

        #region CtrlFormation HandleDestroyed
        private void CtrlFormation_HandleDestroyed(object sender, EventArgs e)
        {
            //m_timer.Stop();

            if (this._TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (this._TheadVisiable)
                this._ProcessThread.Abort();
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            // CtrlTaggingName 언어 변환 호출
            foreach (var ctl in this.panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlTaggingName))
                {
                    CtrlTaggingName tagName = ctl as CtrlTaggingName;
                    tagName.CallLocalLanguage();

                    _EqpStatus.Add(tagName.StatusCode, tagName.TagColor);
                }
                else if (ctl.GetType() == typeof(CtrlTaggingNameLong))
                {
                    CtrlTaggingNameLong tagName = ctl as CtrlTaggingNameLong;
                    tagName.CallLocalLanguage();

                    _OpMode.Add(Convert.ToInt16(tagName.StatusCode), tagName.TagColor);
                }
                else if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel tagName = ctl as CtrlLabel;
                    tagName.CallLocalLanguage();
                }
            }

            ctrlHPC1.CallLocalLanguage();
            ctrlHPC2.CallLocalLanguage();
            ctrlHPCTemp1.CallLocalLanguage();
            ctrlHPCTemp2.CallLocalLanguage();
        }
        #endregion

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
            this.HandleDestroyed += CtrlFormation_HandleDestroyed;
        }

        private void InitControls()
        {
            _ListHPC.Clear();

            ctrlHPC1.MouseDoubleClick += Charger_MouseDoubleClick;
            _ListHPC.Add(ctrlHPC1.UnitID, ctrlHPC1);

            ctrlHPC2.MouseDoubleClick += Charger_MouseDoubleClick;
            _ListHPC.Add(ctrlHPC2.UnitID, ctrlHPC2);

            if (_EqpID == "") _EqpID = ctrlHPC2.EqpID;
        }

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LoadFormationHPC(_EqpID).GetAwaiter().GetResult();
                        LoadFormationHPCTemp(_EqpID).GetAwaiter().GetResult();
                    }));

                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### FormationCHG ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region LoadFormationHPC
        private async Task LoadFormationHPC(string eqpid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT A.unit_id, A.tray_id, A.eqp_mode, A.eqp_status, A.operation_mode, A.start_time, A.plan_time,");
                //strSQL.Append($"       B.pressure, B.event_time, ROUND(SUM({GetJigNoString("B")})/{CDefine.DEF_MAX_CELL_COUNT}, 1) as temp_avg,");
                strSQL.Append("       B.pressure, B.event_time, B.jig_avg,");
                strSQL.Append("       C.trouble_code, C.trouble_name,");
                strSQL.Append("       D.process_name");
                strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                strSQL.Append("        LEFT OUTER JOIN fms_v.tb_dat_temp_hpc    B");
                strSQL.Append("             ON A.eqp_id = B.eqp_id AND B.unit_id = A.unit_id ");
                strSQL.Append("                 AND B.event_time = (SELECT MAX(event_time) FROM tb_dat_temp_hpc WHERE eqp_id = A.eqp_id AND unit_id = B.unit_id)");
                strSQL.Append("         LEFT OUTER JOIN fms_v.tb_mst_trouble   C");
                strSQL.Append("             ON A.eqp_trouble_code = C.trouble_code AND A.eqp_type = C.eqp_type");
                strSQL.Append("         LEFT OUTER JOIN fms_v.tb_mst_route_order    D");
                strSQL.Append("             ON A.route_order_no = D.route_order_no");
                //필수값
                strSQL.Append($" WHERE A.eqp_id = '{eqpid}'");
                strSQL.Append("    AND A.unit_id = B.unit_id");
                //strSQL.Append("    AND A.eqp_type = D.eqp_type");
                strSQL.Append(" GROUP BY A.unit_id");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonCtrlFormationHPCResponse result = rest.ConvertCtrlFormationHPC(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);

                        RestServer.LedStatus(2);
                    }
                    else
                    {
                        string log = "CtrlFormationHPC : jsonResult is null";
                        _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);

                        RestServer.LedStatus(4);
                    }
                }
                else
                {
                    string log = "CtrlFormationHPC : jsonResult is null";
                    _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);

                    RestServer.LedStatus(4);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("[Exception:LoadFormationHPC] {0}", ex.ToString()));
            }
        }
        private async Task LoadFormationHPCTemp(string eqpid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT A.unit_id, A.tray_id,");
                strSQL.Append("        B.event_time,");
                strSQL.Append("        C.cell_no, C.cell_id,");
                strSQL.Append($"             CASE {GetJigTempString()} END AS temp_jig");
                strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                strSQL.Append("        LEFT OUTER JOIN fms_v.tb_dat_temp_hpc    B");
                strSQL.Append("             ON A.eqp_id = B.eqp_id AND B.unit_id = A.unit_id ");
                strSQL.Append("                 AND B.event_time = (SELECT MAX(event_time) FROM tb_dat_temp_hpc WHERE eqp_id = A.eqp_id AND unit_id = B.unit_id)");
                strSQL.Append("         LEFT OUTER JOIN fms_v.tb_dat_cell   C");
                strSQL.Append("             ON A.tray_id = C.tray_id");
                //필수값
                strSQL.Append($" WHERE A.eqp_id = '{eqpid}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonCtrlFormationHPCTempResponse result = rest.ConvertCtrlFormationHPCTemp(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "CtrlFormationHPCTemp : jsonResult is null";
                        _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                    }
                }
                else
                {
                    string log = "CtrlFormationHPCTemp : jsonResult is null";
                    _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("[Exception:LoadFormationHPCTemp] {0}", ex.ToString()));
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_ctrl_formation_hpc> data)
        {
            if (data == null || data.Count == 0) return;

            for (int i = 0; i < data.Count; i++)
            {
                if (_ListHPC.ContainsKey(data[i].UNIT_ID))
                {
                    CtrlHPC hpc = _ListHPC[data[i].UNIT_ID];
                    hpc.SetData(data[i], _EqpStatus[data[i].EQP_STATUS], _OpMode[data[i].OPERATION_MODE]);
                }
            }
        }
        public void SetData(List<_ctrl_formation_hpc_temp> data)
        {
            if (data == null || data.Count == 0) return;

            ctrlHPCTemp1.SetData(data);
            ctrlHPCTemp2.SetData(data);
        }
        #endregion

        private void Charger_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ;
        }



        //public static CtrlFormationBoxCHG FindByName(Control root, string strName)
        //{
        //    for (int i = 0; i < root.Controls.Count; i++)
        //    {
        //        if (root.Controls[i] is ElementHost)
        //        {
        //            if (((ElementHost)root.Controls[i]).Child is CtrlFormationBoxCHG)
        //            {
        //                CtrlFormationBoxCHG eh = (CtrlFormationBoxCHG)((ElementHost)root.Controls[i]).Child;
        //                if (eh.Name == strName)
        //                    return eh;
        //            }
        //        }
        //    }

        //    return null;
        //}

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
        //        System.Diagnostics.Debug.Print(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
        //    }
        //}

        

        private async Task LoadChargerRackData()
        {
            try
            {
                Task task = ChargerDataView();
                await task;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("[Exception:LoadChargerRackData] {0}", ex.ToString()));
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
                            UpdateHPC();
                        }));

                        //this.BeginInvoke(new Action(() => UpdateHPC()));
                    });
                }
            }
            catch (Exception ex)        // 예외처리
            {
                System.Diagnostics.Debug.Print(string.Format("[Exception:ChargerDataView] {0}", ex.ToString()));
                // Return
                return false;
            }

            // Return
            return true;
        }

        private void UpdateHPC()
        {
            //DataSet ds = _mysql.SelectHPCInfo();

            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    string unit_id = row["unit_id"].ToString();

            //    CtrlHPC chg = _ListHPC[unit_id];
            //    chg.SetData(row);
            //}
        }

        private string GetJigNoString(string alias)
        {
            StringBuilder strJIGNo = new StringBuilder();

            for (int i = 0; i < CDefine.DEF_MAX_CELL_COUNT; i++)
            {
                string jigNo = string.Format("{0:D2}", i + 1);
                if (i < CDefine.DEF_MAX_CELL_COUNT-1)
                {
                    strJIGNo.Append($"{alias}.jig_{jigNo}+");
                }
                else
                {
                    strJIGNo.Append($"{alias}.jig_{jigNo}");
                }
            }

            return strJIGNo.ToString();
        }

        private string GetJigTempString()
        {
            StringBuilder strJIGNo = new StringBuilder();

            for (int i = 0; i < CDefine.DEF_MAX_CELL_COUNT; i++)
            {
                string jigNo = string.Format("{0:D2}", i + 1);
                strJIGNo.Append($"WHEN C.cell_no = {i + 1} THEN B.jig_{jigNo} ");
            }

            return strJIGNo.ToString();
        }

        
    }
}
