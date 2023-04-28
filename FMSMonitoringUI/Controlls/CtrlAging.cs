using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MonitoringUI.Common;
using MySql.Data.MySqlClient;
using System.Reflection;
using MySqlX.XDevAPI;
using System.Threading;
using FMSMonitoringUI.Monitoring;
using OPCUAClientClassLib;
using ControlGallery;
using FMSMonitoringUI.Controlls;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using MonitoringUI.Controlls.CButton;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI.Controlls;
using MySqlX.XDevAPI.Common;

namespace MonitoringUI.Monitoring
{
    public partial class CtrlAging : UserControlRoot
    {
        #region Properties
        public override string Text { get; set; }
        #endregion

        #region [Variable]
        //private MySqlManager _mysql;
        //private Logger _Logger;

        private string _AgingType = string.Empty;
        private string _AgingLine = string.Empty;

        /// <summary>
        /// string=Eqp Text, Color=Eqp Status Color
        /// </summary>
        public Dictionary<string, KeyValuePair<string, Color>> _RackStatus;
        /// <summary>
        /// First=Equipment ID, Second=Eqp Name
        /// </summary>
        public Dictionary<string, string> _EqpName;
        #endregion

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public CtrlAging()
        {
            InitializeComponent();

            //string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            //_Logger = new Logger(logPath, LogMode.Hour);

            _RackStatus = new Dictionary<string, KeyValuePair<string, Color>>();
            _EqpName = new Dictionary<string, string>();

            InitAgingRack();
            InitLanguage();

            //_mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);

            ctrlButtonDataView.Click += CtrlButtonDataView_Click;

            this.Disposed += CtrlRTAging_Disposed;
        }
        #region CtrlAging_Load
        /// <summary>
        /// Total MonitoringUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlAging_Load(object sender, EventArgs e)
        {
            btnHTAging.BackColor = Color.LightYellow;
            btnHTAging.ForeColor = Color.Black;

            InitGridView();
            InitLanguage();

            CLogger.WriteLog(enLogLevel.Info, this.Text, "Window Load");
        }
        #endregion

        #region ProcessStart
        public void ProcessStart(bool onoff)
        {
            // Timer
            if (onoff)
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
                if (_TheadVisiable && this._ProcessThread.IsAlive)
                    this._TheadVisiable = false;

                if (_TheadVisiable)
                    this._ProcessThread.Abort();
            }
        }
        #endregion

        #region CtrlRTAging_Disposed
        private void CtrlRTAging_Disposed(object sender, EventArgs e)
        {
            if (_TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (_TheadVisiable)
                this._ProcessThread.Abort();
        }
        #endregion

        #region CtrlRTAging_HandleDestroyed
        private void CtrlRTAging_HandleDestroyed(object sender, EventArgs e)
        {
            if (_TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (_TheadVisiable)
                this._ProcessThread.Abort();
        }
        #endregion

        
        private void MoveNextRTAgingTab()
        {
            int nIndex = AgingTab.SelectedIndex;
            if (nIndex == (AgingTab.TabCount - 1))
                AgingTab.SelectTab(0);
            else
                AgingTab.SelectTab(nIndex + 1);
        }
        
        public int GetDelayTime(string strDelayTime)
        {
            int iDelayTime = 0;

            if (strDelayTime == null) return 0;
            if (strDelayTime.Trim().Length == 0) return 0;
            if (strDelayTime.Trim() == "NULL" || strDelayTime.Trim() == "null") return 0;

            try
            {
                iDelayTime = int.Parse(strDelayTime.Trim());
            }
            catch
            {
                return 0;
            }

            return iDelayTime;
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #region InitAgingRack
        private void InitAgingRack()
        {
            // 좌 더블클릭 - Rack 설정
            ht011.MouseDoubleClick += Rack_DoubleClick;
            ht012.MouseDoubleClick += Rack_DoubleClick;
            ht013.MouseDoubleClick += Rack_DoubleClick;
            ht014.MouseDoubleClick += Rack_DoubleClick;
            lt011.MouseDoubleClick += Rack_DoubleClick;
            lt012.MouseDoubleClick += Rack_DoubleClick;
            lt013.MouseDoubleClick += Rack_DoubleClick;
            lt014.MouseDoubleClick += Rack_DoubleClick;
            lt021.MouseDoubleClick += Rack_DoubleClick;
            lt022.MouseDoubleClick += Rack_DoubleClick;
            lt022.MouseDoubleClick += Rack_DoubleClick;
            lt024.MouseDoubleClick += Rack_DoubleClick;

            // 우클릭 - Trouble
            ht011.Click += Rack_Click;
            ht012.Click += Rack_Click;
            ht013.Click += Rack_Click;
            ht014.Click += Rack_Click;
            lt011.Click += Rack_Click;
            lt012.Click += Rack_Click;
            lt013.Click += Rack_Click;
            lt014.Click += Rack_Click;
            lt021.Click += Rack_Click;
            lt022.Click += Rack_Click;
            lt023.Click += Rack_Click;
            lt024.Click += Rack_Click;

            initAgingTab_Language();
        }
        #endregion

        #region InitGridView
        private void InitGridView(bool changeLanguage = false)
        {
            string[] columnName = {
                LocalLanguage.GetItemString("DEF_Status_Name"), 
                LocalLanguage.GetItemString("DEF_Total_Rack_Count"), 
                LocalLanguage.GetItemString("DEF_In_Aging"), 
                LocalLanguage.GetItemString("DEF_Empty_Rack"),                 
                LocalLanguage.GetItemString("DEF_Unloading_Rack"), 
                LocalLanguage.GetItemString("DEF_No_Input_Rack"), 
                LocalLanguage.GetItemString("DEF_No_Output_Rack"), 
                LocalLanguage.GetItemString("DEF_Bad_Rack"),
                LocalLanguage.GetItemString("DEF_Tatal_Trouble"),
                LocalLanguage.GetItemString("DEF_Ratio").Replace(":", "")};

            List<string> lstTitle = new List<string>();

            foreach (var item in columnName)
            {
                lstTitle.Add(item);
            }
            AgingInfoView_HT.AddColumnHeaderList(lstTitle);
            AgingInfoView_LT1.AddColumnHeaderList(lstTitle);
            AgingInfoView_LT2.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Count");
            AgingInfoView_HT.AddRowsHeaderList(lstTitle);
            AgingInfoView_LT1.AddRowsHeaderList(lstTitle);
            AgingInfoView_LT2.AddRowsHeaderList(lstTitle);

            AgingInfoView_HT.ColumnHeadersHeight(30);
            AgingInfoView_HT.RowsHeight(30);
            AgingInfoView_LT1.ColumnHeadersHeight(30);
            AgingInfoView_LT1.RowsHeight(30);
            AgingInfoView_LT2.ColumnHeadersHeight(30);
            AgingInfoView_LT2.RowsHeight(30);

            AgingInfoView_HT.SetGridViewStyles();
            AgingInfoView_HT.ColumnHeadersWidth(0, 140);
            AgingInfoView_LT1.SetGridViewStyles();
            AgingInfoView_LT1.ColumnHeadersWidth(0, 140);
            AgingInfoView_LT2.SetGridViewStyles();
            AgingInfoView_LT2.ColumnHeadersWidth(0, 140);

            if (changeLanguage == false)
            {
                AgingTab.SelectedIndex = 0;

                _AgingType = "H";
                _AgingLine = "01";
            }
        }
        #endregion

        #region InitLanguage
        public void InitLanguage()
        {
            // CtrlTaggingName 언어 변환 호출

            btnHTAging.CallLocalLanguage();
            btnLTAging1.CallLocalLanguage();
            btnLTAging2.CallLocalLanguage();

            _RackStatus.Clear();

            foreach (var ctl in panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlTaggingName))
                {
                    CtrlTaggingName tagName = ctl as CtrlTaggingName;
                    tagName.CallLocalLanguage();

                    var tag = new KeyValuePair<string, Color>(tagName.TagText, tagName.TagColor);
                    _RackStatus.Add(tagName.StatusCode, tag);
                }
                else if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel tagName = ctl as CtrlLabel;
                    tagName.CallLocalLanguage();
                }
            }

            InitGridView(true);
        }
        #endregion

        #region Rack_Click
        private void Rack_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                try
                {
                    // Get agingBay info from Double Clicked object
                    AgingControls.AgingLineControl agingBay = (AgingControls.AgingLineControl)sender;
                    AgingControls.AgingRack rack = agingBay.FindRackOfCurrentMousePosition();

                    if (rack != null)
                    {
                        string strUnitID = rack.RackID; // +"0";
                        string strEqpType = agingBay.EqpID.Substring(2, 3);
                        string strEqpName = _EqpName[agingBay.EqpID];

                        // Data Check
                        if (strUnitID.Length < 1) return;

                        CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"Rack TroubleInfo : Eqp Name = {strEqpName}, Unit ID = {strUnitID}");

                        WinTroubleInfo winTroubleInfo = new WinTroubleInfo(strEqpName, strEqpType, "", strUnitID);
                        winTroubleInfo.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    // System Debug
                    System.Diagnostics.Debug.Print(string.Format("Rack_Click Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                    string log = string.Format("Rack_Click Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);
                }
            }
        }
        #endregion

        #region Rack_DoubleClick
        private void Rack_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    // Get agingBay info from Double Clicked object
                    AgingControls.AgingLineControl agingBay = (AgingControls.AgingLineControl)sender;
                    AgingControls.AgingRack rack = agingBay.FindRackOfCurrentMousePosition();

                    if (rack != null)
                    {
                        string strUnitID = rack.RackID;
                        string strEqpName = _EqpName[agingBay.EqpID];

                        // Data Check
                        if (strUnitID.Length < 1) return;

                        // Rack 설정
                        //WinAgingRackSetting winAgingRackSetting = new WinAgingRackSetting(CDefine.DEF_AGING_TYPE_RT, strUnitID, strTrayID, strStatus);
                        //winAgingRackSetting.ShowDialog();

                        // Rack Info
                        //DataSet ds = _mysql.SelectRackInfo(strRackID);

                        CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"Rack Click : Eqp Name = {strEqpName}, Unit ID = {strUnitID}");

                        WinAgingRackSetting winRack = new WinAgingRackSetting(agingBay.EqpID, strUnitID, _RackStatus);
                        winRack.Show();
                    }

                    //CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "CtrlAging_MouseDown : Start Timer");
                }
                catch (Exception ex)
                {
                    // System Debug
                    System.Diagnostics.Debug.Print(string.Format("AgingLineControl_DoubleClick Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                    string log = string.Format("AgingLineControl_DoubleClick Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);
                }
            }
        }
        #endregion


        private void CtrlButtonDataView_Click(object sender, EventArgs e)
        {
            //m_timer.Stop();
            //WinAgingInfo winAgingInfo = new WinAgingInfo(CDefine.DEF_AGING_TYPE_RT);
            //winAgingInfo.ShowDialog();
            //m_timer.Start();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    m_timer.Stop();
        //    WinAgingRackSetting winAgingRackSetting = new WinAgingRackSetting();
        //    winAgingRackSetting.ShowDialog();
        //    m_timer.Start();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    m_timer.Stop();
        //    WinTroubleInfo winTroubleInfo = new WinTroubleInfo();
        //    winTroubleInfo.ShowDialog();
        //    m_timer.Start();
        //}


        #region AgingTab_SelectedIndexChanged
        // 탭을 선택하면 눈에 띄게 좀 바꿀라고 했는데 안되네.. 쩝.
        // 이건 나중에 여유 있을때 해보자
        private void AgingTab_SelectedIndexChanged(object sender, EventArgs e)
        {   
            // 선택된 TabPage만 잘 보이게
            int selectedIndex = AgingTab.SelectedIndex;
            string strTabName = string.Empty;

            for (int i = 0; i < AgingTab.TabCount; i++)
            {
                switch (i)
                {
                    case 0:
                        strTabName = $"HT {LocalLanguage.GetItemString("lbMonTabAging")}";
                        break;
                    default:
                        strTabName = $"LT {LocalLanguage.GetItemString("lbMonTabAging")} #{i}";
                        break;
                }
                AgingTab.TabPages[i].Text = strTabName;
                if(i==selectedIndex)
                {
                    AgingTab.TabPages[i].ForeColor = Color.Blue;
                }
                else
                {
                    AgingTab.TabPages[i].ForeColor = Color.Black;
                }
            }

            LoadAgingRackData(selectedIndex).GetAwaiter().GetResult();
            LoadAgingRackCount(selectedIndex).GetAwaiter().GetResult();            
        }
        #endregion

        /// <summary>
        /// Loading시 Aging Tab Title에 언어적용
        /// </summary>
        private void initAgingTab_Language()
        {
            string strTabName;  // = $"{LocalLanguage.GetItemString("lbMonTabAging")} #{(i * 2) + 1}, #{(i * 2) + 2}";

            for (int i = 0; i < AgingTab.TabCount; i++)
            {
                switch (i)
                {
                    case 0:
                        strTabName = $"HT {LocalLanguage.GetItemString("lbMonTabAging")}";
                        break;
                    default:
                        strTabName = $"LT {LocalLanguage.GetItemString("lbMonTabAging")} #{i}";
                        break;
                }
                AgingTab.TabPages[i].Text = strTabName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //updateTable();

            //_mysql.UpdateAgingInfo("status", "G", "aging_type", "L");
            //_mysql.UpdateAgingInfo("status", "G", "aging_type", "H");

            //string starttime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
            //_mysql.UpdateAgingInfo("start_time", starttime, "aging_type", "H");
            //_mysql.UpdateAgingInfo("start_time", starttime, "aging_type", "L");

            //Thread.Sleep(5000);

            //starttime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
            //_mysql.UpdateAgingInfo("end_time", starttime, "aging_type", "H");
            //_mysql.UpdateAgingInfo("end_time", starttime, "aging_type", "L");

            //_mysql.UpdateAgingInfo("tray_cnt", "2", "aging_type", "H");
            //_mysql.UpdateAgingInfo("tray_cnt", "2", "aging_type", "L");
        }

        private void updateTable()
        {
            try
            {
                

                string connection = ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString;

                int idx = 1;
                //accounts_table의 특정 id의 name column과 phone column 데이터를 수정합니다.

                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    for (int line = 1; line <= 4; line++)
                    {
                        for (int bay = 1; bay <= 16; bay++)
                        {
                            for (int deck = 1; deck <= 5; deck++)
                            {
                                string trayid1 = string.Format($"LTA21{{0:D4}}", idx);
                                string trayid2 = string.Format($"LTA22{{0:D4}}", idx);
                                string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                                                                   $"SET tray_id = '{trayid1}', tray_id_2 = '{trayid2}' " +
                                                                   $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND floor = '{{1:D2}}'", bay, deck);


                                //string starttime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                                //string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                                //                                   $"SET start_time = '{starttime}' " +
                                //                                   $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);

                                //string starttime = "G";
                                //string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                                //                                   $"SET status = '{starttime}' " +
                                //                                   $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);



                                MySqlCommand command = new MySqlCommand(updateQuery, conn);

                                command.Connection.Open();

                                command.ExecuteNonQuery();

                                command.Connection.Close();

                                //if (command.ExecuteNonQuery() != 1)
                                //    MessageBox.Show("Failed to delete data.");

                                idx++;
                            }

                        }
                    }
                }
                

                //_mysql.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
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
                        LoadAgingRackData(AgingTab.SelectedIndex).GetAwaiter().GetResult();
                    }));

                    Thread.Sleep(2500);

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LoadAgingRackCount(AgingTab.SelectedIndex).GetAwaiter().GetResult();
                    }));

                    Thread.Sleep(2500);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Aging ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region LoadAgingRackData
        private async Task LoadAgingRackData(int selectedTabIndex = 0)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                // Rack 정보
                strSQL.Append(" SELECT aging_type, line, lane, rack_id, tray_id, tray_id_2, status, process_no, fire_flag, use_flag");
                strSQL.Append(" FROM fms_v.tb_mst_aging");
                //필수값
                strSQL.Append($" WHERE aging_type = '{_AgingType}' AND line = '{_AgingLine}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonAgingRackDataResponse result = rest.ConvertAgingRackData(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA, selectedTabIndex);
                        RestServer.LedStatus(2);
                    }
                    else
                    {
                        string log = "ConvertAgingRackData : REST result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                        RestServer.LedStatus(4);
                    }
                }
                else
                {
                    string log = "ConvertAgingRackData : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                    RestServer.LedStatus(4);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadAgingRackData Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadAgingRackData Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region LoadAgingRackCount
        private async Task LoadAgingRackCount(int selectedTabIndex = 0)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                //// Tray Count 정보
                strSQL.Append(" SELECT COUNT(aging_type) AS total_rack_cnt,");
                strSQL.Append("        COUNT(if(status = 'F', status, null)) AS in_aging,");
                strSQL.Append("        COUNT(if(status = 'E', status, null)) AS empty_rack,");
                strSQL.Append("        COUNT(if(status = 'U', status, null)) AS unloading_rack,");
                strSQL.Append("        COUNT(if(status = 'X', status, null)) AS no_input_rack,");
                strSQL.Append("        COUNT(if(status = 'O', status, null)) AS no_output_rack,");
                strSQL.Append("        COUNT(if(status = 'B', status, null)) AS bad_rack,");
                strSQL.Append("        COUNT(if(status = 'T', status, null)) AS total_trouble");
                strSQL.Append(" FROM fms_v.tb_mst_aging");
                //필수값
                strSQL.Append($" WHERE aging_type = '{_AgingType}' AND line = '{_AgingLine}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonAgingRackCountResponse result = rest.ConvertAgingRackCount(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA, selectedTabIndex);
                    }
                    else
                    {
                        string log = "ConvertAgingRackCount : REST result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.Text, log);
                    }
                }
                else
                {
                    string log = "ConvertAgingRackCount : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadAgingRackCount Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadAgingRackCount Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region SetData
        private void SetData(List<_aging_rack_data> data, int selectedIndex)
        {
            if (data == null || data.Count == 0) return;

            Dictionary<string, List<_aging_rack_data>> rackData = new Dictionary<string, List<_aging_rack_data>>();

            foreach (var item in data)
            {
                string rackId = string.Format($"{item.AGING_TYPE}{item.LINE}{item.LANE}");
                if (rackData.ContainsKey(rackId))
                {
                    rackData[rackId].Add(item);
                }
                else
                {
                    rackData[rackId] = new List<_aging_rack_data> { item };
                }
            }

            switch (selectedIndex)
            {
                case 0:
                    ht011.SetData(rackData[ht011.LinePrefix], _RackStatus);
                    ht012.SetData(rackData[ht012.LinePrefix], _RackStatus);
                    ht013.SetData(rackData[ht013.LinePrefix], _RackStatus);
                    ht014.SetData(rackData[ht014.LinePrefix], _RackStatus);
                    break;
                case 1:
                    lt011.SetData(rackData[lt011.LinePrefix], _RackStatus);
                    lt012.SetData(rackData[lt012.LinePrefix], _RackStatus);
                    lt013.SetData(rackData[lt013.LinePrefix], _RackStatus);
                    lt014.SetData(rackData[lt014.LinePrefix], _RackStatus);
                    break;
                case 2:
                    lt021.SetData(rackData[lt021.LinePrefix], _RackStatus);
                    lt022.SetData(rackData[lt022.LinePrefix], _RackStatus);
                    lt023.SetData(rackData[lt023.LinePrefix], _RackStatus);
                    lt024.SetData(rackData[lt024.LinePrefix], _RackStatus);
                    break;
            }
        }

        private void SetData(List<_aging_rack_count> data, int selectedIndex)
        {
            if (data == null || data.Count == 0) return;

            CtrlDataGridView gridRackCount = new CtrlDataGridView();

            switch (selectedIndex)
            {
                case 0:
                    gridRackCount = AgingInfoView_HT;
                    break;
                case 1:
                    gridRackCount = AgingInfoView_LT1;
                    break;
                case 2:
                    gridRackCount = AgingInfoView_LT2;
                    break;
            }

            int col = 1;
            gridRackCount.SetValue(col, 0, data[0].TOTAL_RACK_CNT); col++;
            gridRackCount.SetValue(col, 0, data[0].IN_AGING); col++;
            gridRackCount.SetValue(col, 0, data[0].EMPTY_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].UNLOADING_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].NO_INPUT_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].NO_OUTPUT_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].BAD_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].TOTAL_TROUBLE); col++;
                        
            double ratio = 100.0 * data[0].IN_AGING / data[0].TOTAL_RACK_CNT;
            gridRackCount.SetValue(col, 0, string.Format($"{ratio:F1}%"));
        }
        #endregion

        #region AgingTab_Click
        private void AgingTab_Click(object sender, EventArgs e)
        {
            CtrlButtonType2 btn = (CtrlButtonType2)sender;
            int tabIdx = int.Parse(btn.Tag.ToString());

            foreach (var ctl in this.Controls)
            {
                if (ctl.GetType() == typeof(CtrlButtonType2))
                {
                    CtrlButtonType2 btnCtrl = ctl as CtrlButtonType2;

                    btnCtrl.BackColor = Color.FromArgb(27, 27, 27);
                    btnCtrl.ForeColor = Color.White;
                }
            }

            btn.BackColor = Color.LightYellow;
            btn.ForeColor = Color.Black;
            
            switch (tabIdx)
            {
                case 0:
                    _AgingType = "H";
                    _AgingLine = "01";
                    break;
                case 1:
                    _AgingType = "L";
                    _AgingLine = "01";
                    break;
                case 2:
                    _AgingType = "L";
                    _AgingLine = "02";
                    break;
                default:
                    _AgingType = "H";
                    _AgingLine = "01";
                    break;
            }

            AgingTab.SelectedTab = AgingTab.TabPages[tabIdx];

            CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"AgingTab : {btn.Text}");
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //updateTable();
        }

        #region emptySpace_Paint
        // Aging에 사용하지 않는 부분 표시
        private void emptySpace_Paint(object sender, PaintEventArgs e)
        {
            Pen line = new Pen(Color.White);

            Panel pnl = sender as Panel;

            e.Graphics.DrawLine(line, 0, 0 , pnl.Width, pnl.Height);
            e.Graphics.DrawLine(line, 0, pnl.Height, pnl.Width, 0);

            //Graphics graphics = CreateGraphics();
            //Pen pen = new Pen(Color.Black);
            //graphics.DrawLine(pen, 0, 0, 400, 400);
            //graphics.DrawLine(pen, 0, 400, 400, 0);

            e.Graphics.Dispose();
        }
        #endregion
    }
}
