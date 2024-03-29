﻿using ControlGallery;
using FMSMonitoringUI.Controlls;
using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MySqlX.XDevAPI;
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
        #region Properties
        public override string Text { get; set; }
        #endregion

        #region [Variable]
        private string _EqpID = string.Empty;

        /// <summary>
        /// string=Eqp Text, Color=Eqp Status Color
        /// </summary>
        public Dictionary<string, Color> _EqpStatus = new Dictionary<string, Color>();
        private Dictionary<int, Color> _OpMode = new Dictionary<int, Color>();
        /// <summary>
        /// First=Equipment ID, Second=Eqp Name
        /// </summary>
        public Dictionary<string, string> _EqpName;
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

            InitLanguage();     // CtrlMonitoring으로 _EqpStatus를 넘겨줘야 해서 미리 초기화 시킴.
        }

        #region CtrlFormationCHG Load
        private void CtrlFormationCHG_Load(object sender, EventArgs e)
        {
            InitControls();
            //InitLanguage();

            CLogger.WriteLog(enLogLevel.Info, this.Text, "Window Load");
        }
        #endregion

        #region CtrlFormation HandleDestroyed
        private void CtrlFormation_HandleDestroyed(object sender, EventArgs e)
        {
            if (this._TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (this._TheadVisiable)
                this._ProcessThread.Abort();
        }
        #endregion

        #region InitControls
        private void InitControls()
        {
            _ListCharger.Clear();

            foreach (var ctl in splitContainer1.Panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlRack))
                {
                    CtrlRack charger = ctl as CtrlRack;

                    //charger.MouseDoubleClick += Charger_MouseDoubleClick;
                    _ListCharger.Add(charger.UnitID, charger);

                    if (charger.UnitID != "CHG0110304")     // 마짐가 Rack은 사용안함.
                        charger.EqpName = _EqpName[charger.UnitID];

                    if (_EqpID == "") _EqpID = charger.EqpID;
                }
            }
        }
        #endregion

        #region InitLanguage
        public void InitLanguage()
        {
            _EqpStatus.Clear();
            _OpMode.Clear();

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

            foreach (var ctl in splitContainer1.Panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlRack))
                {
                    CtrlRack charger = ctl as CtrlRack;
                    charger.CallLocalLanguage();
                }
            }
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
        }
        #endregion

        #region InitFormationBox
        private void InitFormationBox()
        {
            this.HandleDestroyed += CtrlFormation_HandleDestroyed;
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

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LoadFormationCHG(_EqpID).GetAwaiter().GetResult();
                    }));

                    Thread.Sleep(5000);
                }   
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region LoadFormationCHG
        private async Task LoadFormationCHG(string eqpid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                //strSQL.Append(" SELECT A.unit_id, A.eqp_name, A.eqp_name_local, A.tray_id, B.tray_id_2,");
                //strSQL.Append("        A.start_time, A.plan_time, A.process_status, A.operation_mode,");
                //strSQL.Append("        B.*,");
                //strSQL.Append("        C.rework_flag");
                //strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                //strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_temp_unit  B");
                //strSQL.Append("         ON A.unit_id = B.unit_id");
                //strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray  C");
                //strSQL.Append("         ON A.tray_id = B.tray_id");
                //strSQL.Append("         AND (B.unit_id, B.event_time) in (");
                //strSQL.Append("         SELECT unit_id, max(event_time) as event_time FROM fms_v.tb_dat_temp_unit GROUP BY unit_id)");

                strSQL.Append(" SELECT A.unit_id, A.eqp_name, A.eqp_name_local, A.tray_id, A.tray_id_2,");
                strSQL.Append("        A.start_time, A.plan_time, A.process_status, A.operation_mode, A.eqp_temp_lsl, A.eqp_temp_usl,");
                strSQL.Append("        B.*,");
                strSQL.Append("        C.rework_flag AS rework_tray_1,");
                strSQL.Append("        D.rework_flag AS rework_tray_2");
                strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_temp_unit  B");
                strSQL.Append("         ON A.eqp_type = B.eqp_type");
                strSQL.Append("             AND B.eqp_id = A.eqp_id");
                strSQL.Append("             AND B.unit_id = A.unit_id");
                strSQL.Append("             AND B.event_time = (SELECT MAX(event_time) AS event_time_max FROM tb_dat_temp_unit WHERE unit_id = B.unit_id)");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray  C");
                strSQL.Append("         ON C.tray_id = A.tray_id");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray  D");
                strSQL.Append("         ON D.tray_id = A.tray_id_2");
                //필수값
                strSQL.Append($" WHERE A.eqp_id = '{_EqpID}'");
                strSQL.Append("        AND (A.eqp_type = 'CHG' AND A.unit_id IS NOT NULL)");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonCtrlFormationCHGResponse result = rest.ConvertCtrlFormationCHG(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);

                        RestServer.LedStatus(2);
                    }
                    else
                    {
                        string log = "ConvertCtrlFormationCHG : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                        RestServer.LedStatus(4);
                    }
                }
                else
                {
                    string log = "ConvertCtrlFormationCHG : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                    RestServer.LedStatus(4);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadFormationCHG Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadFormationCHG Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_ctrl_formation_chg> data)
        {
            if (data == null || data.Count == 0) return;

            for (int i = 0; i < data.Count; i++)
            {
                CtrlRack chg = _ListCharger[data[i].UNIT_ID];
                if (data[i].PROCESS_STATUS == null)
                {
                    data[i].PROCESS_STATUS = "I";
                }

                if (_EqpStatus.ContainsKey(data[i].PROCESS_STATUS) && _OpMode.ContainsKey(data[i].OPERATION_MODE))
                {
                    chg.SetData(data[i], _EqpStatus[data[i].PROCESS_STATUS], _OpMode[data[i].OPERATION_MODE]);
                }
                
                //Color eqpStatus = _EqpStatus[data[i].PROCESS_STATUS];
                //Color opStatus = _OpMode[data[i].OPERATION_MODE];

                //chg.SetData(data[i], eqpStatus, opStatus);
            }

            ctrlRackTemp.SetData(data);
        }
        #endregion

        //private void Charger_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    CtrlRack unit = sender as CtrlRack;

        //    CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"Charger : Eqp ID = {unit.EqpID}, Unit ID = {unit.UnitID}");

        //    WinFormationBox form = new WinFormationBox(unit.EqpID, unit.EqpType, unit.UnitID);
        //    form.Show();
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
            //        string temperature = string.Format($"{i+40}℃");
            //        string lotID = string.Format($"LotID{i}00{j}");

            //        formationCell.setBox(trayID, startTime, temperature, lotID);
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

        

        
    }
}
