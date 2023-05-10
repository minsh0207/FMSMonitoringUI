using ExcelDataReader.Log;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MonitoringUI.Controlls.CComboBox;
using MonitoringUI.Controlls.CDateTime;
using MonitoringUI.Popup;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json.Linq;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml.Linq;
using UnifiedAutomation.UaBase;
using static System.Net.Mime.MediaTypeNames;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinBCRConveyorInfo : WinFormRoot
    {
        private Point _Point = new Point();

        private string _trayID1 = string.Empty;
        private string _trayID2 = string.Empty;

        //#region Working Thread
        //private Thread _ProcessThread;
        //private bool _TheadVisiable;
        //#endregion

        // Timer
        DispatcherTimer m_timer;

        CtrlLED[] _LedMode;
        CtrlLED[] _LedStatus;

        OPCUAClient _OPCUAClient = null;
        private int _ConveyorNo = 0;
        private string _ConveyorType = string.Empty;
        private bool _FirstActivate;

        private List<InfoData> _CmdInfoData;

        public WinBCRConveyorInfo(OPCUAClient opcua, int conveyorNo, string conveyorType)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _ConveyorNo = conveyorNo;
            _ConveyorType = conveyorType;

            InitControl();
            InitLanguage();
            InitLedStatus();

            _FirstActivate = true;
        }

        #region WinBCRConveyorInfo Event
        private void WinBCRConveyorInfo_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Name) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            // Init Timer
            m_timer = new DispatcherTimer();

            //m_timer.Interval = TimeSpan.FromSeconds(2);
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Start();

            //_TheadVisiable = true;

            //this.BeginInvoke(new MethodInvoker(delegate ()
            //{
            //    _ProcessThread = new Thread(() => ProcessThreadCallback());
            //    _ProcessThread.IsBackground = true; _ProcessThread.Start();
            //}));

            //_ProcessThread = new Thread(() => ProcessThreadCallback());
            //_ProcessThread.IsBackground = true; _ProcessThread.Start();

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }

        private void WinBCRConveyorInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this._ProcessThread.IsAlive)
            //    this._TheadVisiable = false;

            //this._ProcessThread.Abort();

            m_timer.Stop();
        }
        #endregion

        //화면 깜빡임 방지
        #region CreateParams
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            string[] titleMode = { "Maintenance Mode", "Manual Mode", "Control Mode" };

            _LedMode = new CtrlLED[titleMode.Length];
            for (int i = 0; i < titleMode.Length; i++)
            {
                _LedMode[i] = new CtrlLED();
                _LedMode[i].TitleText = titleMode[i];
                //_LedMode[i].Dock = DockStyle.Fill;
                _LedMode[i].Tag = "EquipmentStatus.Mode";
                uiTlbMode.Controls.Add(_LedMode[i], 0, i);
            }

            string[] titleStatus = { "Idle", "Run", "Trouble" };
            _LedStatus = new CtrlLED[titleStatus.Length];
            for (int i = 0; i < titleStatus.Length; i++)
            {
                _LedStatus[i] = new CtrlLED();
                _LedStatus[i].TitleText = titleStatus[i];
                //_LedStatus[i].Dock = DockStyle.Fill;
                _LedStatus[i].Tag = "EquipmentStatus.Status";
                uiTlbStatus.Controls.Add(_LedStatus[i], i, 0);
            }

            Exit.Left = (this.panel2.Width - Exit.Width) / 2;             
            Exit.Top = (this.panel2.Height - Exit.Height) / 2;

            var dt = TableLanguage();
            CmdMagazineCommand.DataSource(dt);

            CmdMagazineCommand.SelectedIndex = 0;
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            titBar.CallLocalLanguage();

            foreach (var ctl in panel3.Controls)
            {
                if (ctl.GetType() == typeof(CtrlGroupBox))
                {
                    CtrlGroupBox control = ctl as CtrlGroupBox;
                    control.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlLabelBox))
                {
                    CtrlLabelBox control = ctl as CtrlLabelBox;
                    control.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel control = ctl as CtrlLabel;
                    control.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlTextBox))
                {
                    CtrlTextBox control = ctl as CtrlTextBox;
                    control.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlComboBox2))
                {
                    CtrlComboBox2 control = ctl as CtrlComboBox2;
                    control.CallLocalLanguage();
                }
            }

            Write.CallLocalLanguage();
            Exit.CallLocalLanguage();
        }
        #endregion

        #region InitLedStatus
        private void InitLedStatus()
        {
            // Mode
            for (int i = 0; i < _LedMode.Count(); i++)
            {
                _LedMode[i].LedStatus(0);
            }

            // Status
            for (int i = 0; i < _LedStatus.Count(); i++)
            {
                _LedStatus[i].LedStatus(0);
            }
        }
        #endregion

        #region [Timer Event]
        /////////////////////////////////////////////////////////////////////
        //	Timer Event
        //===================================================================
        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                //timer Stop And Start
                m_timer.Stop();

                List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];
                List<DataValue> data = _OPCUAClient.ReadNodeID(cvInfo);
                this.BeginInvoke(new Action(() => SetData(data, cvInfo)));

                //Set Time interval
                if (m_timer.Interval.Seconds.ToString() != "2")
                    m_timer.Interval = TimeSpan.FromSeconds(2);

                //timer Stop And Start
                m_timer.Start();

            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WinBCRConveyorInfo Timer Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.Error, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "OnTimer Error Exception : " + ex.Message);
            }
        }
        #endregion

        #region ProcessThreadCallback
        //private void ProcessThreadCallback()
        //{
        //    try
        //    {
        //        while (this._TheadVisiable == true)
        //        {
        //            GC.Collect();

        //            this.BeginInvoke(new MethodInvoker(delegate ()
        //            {
        //                List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];
        //                List<DataValue> data = _OPCUAClient.ReadNodeID(cvInfo);
        //                this.BeginInvoke(new Action(() => SetData(data, cvInfo)));
        //            }));

        //            Thread.Sleep(2000);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // System Debug
        //        System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

        //        string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
        //        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
        //    }
        //}
        #endregion

        #region SetData
        public void SetData(List<DataValue> data, List<ReadValueId> cvInfo)
        {
            if (data == null || data.Count == 0) return;

            InitLedStatus();

            //bool onoff = bool.Parse(data[(int)enCVTagList.Power].Value.ToString());
            //ledPower.LedOnOff(onoff);

            int value = GetTagValuetoInt("EquipmentStatus.Mode", data, cvInfo);
            int idx = GetDatatoBitIdx(value);
            _LedMode[idx].LedControlMode(value);

            value = GetTagValuetoInt("EquipmentStatus.Status", data, cvInfo);
            idx = GetDatatoBitIdx(value);
            _LedStatus[idx].LedStatus(value);

            bool onoff = GetTagValuetoBool("FmsStatus.Trouble.Status", data, cvInfo);
            ledTroubleStatus.LedOnOff(onoff);

            // Conveyor
            string tagValue = GetTagValuetoString("ConveyorInformation.TrackNo", data, cvInfo);
            if (tagValue == "0")
                ConveyorNo.TextData = _ConveyorNo.ToString();
            else
                ConveyorNo.TextData = tagValue;

            int cvTypeIdx = GetTagValuetoInt("ConveyorInformation.ConveyorType", data, cvInfo);
            ConveyorType.TextData = GetConveyorType(data[cvTypeIdx].Value);

            tagValue = GetTagValuetoString("EquipmentStatus.Trouble.ErrorNo", data, cvInfo);
            CVTroubleErrNo.TextData = tagValue;

            tagValue = GetTagValuetoString("EquipmentStatus.Trouble.ErrorLevel", data, cvInfo);
            TroubleErrLevel.TextData = tagValue;

            tagValue = GetTagValuetoString("ConveyorInformation.Direction", data, cvInfo);
            Direction.TextData = GetDirection(tagValue);

            tagValue = GetTagValuetoString("ConveyorInformation.TrackingDestination", data, cvInfo);
            TrackingDestination.TextData = tagValue;

            //CommandReady.TextData = data[(int)enCVTagList.CommandReady].Value.ToString();
            onoff = GetTagValuetoBool("ConveyorCommand.CommandReady", data, cvInfo);
            ledCommandReady.LedOnOff(onoff);

            tagValue = GetTagValuetoString("ConveyorInformation.StationStatus", data, cvInfo);
            StationStatus.TextData = GetStationStatus(tagValue);

            //TrayExist.TextData = data[(int)enCVTagList.TrayExist].Value.ToString();
            onoff = GetTagValuetoBool("ConveyorInformation.TrayExist", data, cvInfo);
            ledTrayExist.LedOnOff(onoff);

            tagValue = GetTagValuetoString("ConveyorInformation.TrayType", data, cvInfo);
            TrayType.TextData = GetTrayType(tagValue);

            tagValue = GetTagValuetoString("ConveyorInformation.TrayCount", data, cvInfo);
            TrayCount.TextData = tagValue;

            tagValue = GetTagValuetoString("ConveyorInformation.TrayIdL1", data, cvInfo);
            TrayID1.TextData = tagValue;
            _trayID1 = tagValue;

            tagValue = GetTagValuetoString("ConveyorInformation.TrayIdL2", data, cvInfo);
            TrayID2.TextData = tagValue;
            //if (Convert.ToString(data[tagIdx].Value) == "")
            //    TrayID2.Visible = false;
            //else
            //    TrayID2.Visible = true;            
            _trayID2 = tagValue;

            // StationStatus 활성화 여부 체크
            if (CheckStationStatus(data[cvTypeIdx].Value))
                StationStatus.Visible = true;
            else
                StationStatus.Visible = false;

            // FMS
            tagValue = GetTagValuetoString("FmsStatus.Trouble.ErrorNo", data, cvInfo);
            FMSTroubleErrNo.TextData =  tagValue;

            bool pause = GetTagValuetoBool("ConveyorInformation.TrackPause", data, cvInfo);

            TrackPauseOn.Checked = pause;
            TrackPauseOff.Checked = !pause;

            CmdTrayCount.SetTextBoxEnable(pause);
            CmdTrayID1.SetTextBoxEnable(pause);
            CmdTrayID2.SetTextBoxEnable(pause);
            CmdDestination.SetTextBoxEnable(pause);
            CmdRTVFrom.SetTextBoxEnable(pause);
            CmdRTVTo.SetTextBoxEnable(pause);
            CmdMagazineCommand.SetComboBoxEnable(pause);

            Write.Visible = pause;

            if (_FirstActivate == true)
            {
                tagValue = GetTagValuetoString("ConveyorCommand.TrayCount", data, cvInfo);
                CmdTrayCount.TextData = tagValue;

                tagValue = GetTagValuetoString("ConveyorCommand.TrayIdL1", data, cvInfo);
                CmdTrayID1.TextData = tagValue;

                tagValue = GetTagValuetoString("ConveyorCommand.TrayIdL2", data, cvInfo);
                CmdTrayID2.TextData = tagValue;

                tagValue = GetTagValuetoString("ConveyorCommand.Destination", data, cvInfo);
                CmdDestination.TextData = tagValue;

                tagValue = GetTagValuetoString("ConveyorCommand.RTVFrom", data, cvInfo);
                CmdRTVFrom.TextData = tagValue;

                tagValue = GetTagValuetoString("ConveyorCommand.RTVTo", data, cvInfo);
                CmdRTVTo.TextData = tagValue;

                value = GetTagValuetoInt("ConveyorCommand.MagazineCommand", data, cvInfo);
                idx = GetMagazineCommandIndex(value);
                CmdMagazineCommand.SelectedIndex = idx;

                _FirstActivate = false;
            }

            //if (CheckMagazineCommand(data[cvTypeIdx].Value))
            //    cmdMagazineCommand.Visible = true;
            //else
            //    cmdMagazineCommand.Visible = false;
        }
        #endregion

        #region GetTrayID
        public void GetTrayID(ref string trayID1, ref string trayID2)
        {
            trayID1 = _trayID1;
            trayID2 = _trayID2;
        }
        #endregion        

        #region Titel Mouse Event
        private void Title_MouseDownEvnet(object sender, MouseEventArgs e)
        {
            _Point = new Point(e.X, e.Y);
        }

        private void Title_MouseMoveEvnet(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (_Point.X - e.X), this.Top - (_Point.Y - e.Y));
            }
        }
        #endregion

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Write_Click(object sender, EventArgs e)
        {
            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID == "") return;

            _CmdInfoData = new List<InfoData>();

            AddTrayInfoData("ConveyorCommand.TrayCount", CmdTrayCount.TextData, BuiltInType.UInt16);
            AddTrayInfoData("ConveyorCommand.TrayIdL1", CmdTrayID1.TextData, BuiltInType.String);
            AddTrayInfoData("ConveyorCommand.TrayIdL2", CmdTrayID2.TextData, BuiltInType.String);
            AddTrayInfoData("ConveyorCommand.Destination", CmdDestination.TextData, BuiltInType.UInt16);
            AddTrayInfoData("ConveyorCommand.RTVFrom", CmdRTVFrom.TextData, BuiltInType.UInt16);
            AddTrayInfoData("ConveyorCommand.RTVTo", CmdRTVTo.TextData, BuiltInType.UInt16);

            string magazineCmd = CmdMagazineCommand.SelectedKeyString;
            AddTrayInfoData("ConveyorCommand.MagazineCommand", magazineCmd, BuiltInType.UInt16);

            bool results = _OPCUAClient.NodesToWriteValue(_CmdInfoData);

            if (results == true)
            {
                CMessage.MsgInformation("Save successful");
            }
            else
            {
                CMessage.MsgInformation("Save failed");
            }

            string log = $"TrayCount={CmdTrayCount.TextData},TrayIdL1={CmdTrayID1.TextData},TrayIdL2={CmdTrayID2.TextData},Destination={CmdDestination.TextData}" +
                         $",RTVFrom={CmdRTVFrom.TextData},RTVTo={CmdRTVTo.TextData},MagazineCommand={magazineCmd}";
            SetUserEventLog("WriteCommand", _trayID1, log).GetAwaiter().GetResult();
        }
        #endregion

        #region TableLanguage
        private DataTable TableLanguage()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("0", "None");
            dt.Rows.Add("1", "Magazine");
            dt.Rows.Add("2", "Bypass");
            dt.Rows.Add("4", "Dispense and Magazine");
            dt.Rows.Add("8", "Dispense and Bypass");

            return dt;
        }
        #endregion

        #region Tray Tag Value
        private string GetConveyorType(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

            string ret = string.Empty;
            int cvType = Convert.ToInt32(idx);

            switch (cvType)
            {
                case 1:
                    ret = "Conveyor Unit";
                    break;
                case 2:
                    ret = "InStation";
                    break;
                case 4:
                    ret = "OutStation";
                    break;
                case 8:
                    ret = "InOutStation";
                    break;
                case 16:
                    ret = "BufferStation";
                    break;
                case 32:
                    ret = "Diverter";
                    break;
                case 64:
                    ret = "Magazine";
                    break;
                case 128:
                    ret = "Dispenser";
                    break;
                case 256:
                    ret = "MZ / DP";
                    break;
            }

            return ret;
        }

        private string GetStationStatus(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

            string ret = string.Empty;

            int cvStatus = Convert.ToInt32(idx);

            switch (cvStatus)
            {
                case 0:
                    ret = "Not Used";
                    break;
                case 1:
                    ret = "Station Down";
                    break;
                case 2:
                    ret = "Station Up";
                    break;
            }

            return ret;
        }

        private string GetTrayType(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

            string ret = string.Empty;

            int trayType = Convert.ToInt32(idx);

            switch (trayType)
            {
                case 1:
                    ret = "BD\nBefore Degas Long Tray";
                    break;
                case 2:
                    ret = "AD\nAfter Degas Short Tray";
                    break;
            }

            return ret;
        }

        private string GetMagazineCommand(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

            string ret = string.Empty;

            int mzCmd = Convert.ToInt32(idx);

            switch (mzCmd)
            {
                case 1:
                    ret = "Magazine";    //"적재";
                    break;
                case 2:
                    ret = "Bypass";
                    break;
                case 4:
                    ret = "Dispense and Magazine";   // "배출후 적재";
                    break;
                case 8:
                    ret = "Dispense and Bypass";   // "강제배출(1단)";
                    break;
            }

            return ret;
        }

        private int GetMagazineCommandIndex(object idx)
        {
            if (idx == null || idx.ToString() == "") return 0;

            int ret = 0;

            int mzCmd = Convert.ToInt32(idx);

            switch (mzCmd)
            {
                case 1:
                    ret = 1;    //"적재";
                    break;
                case 2:
                    ret = 2;    // "Bypss";
                    break;
                case 4:
                    ret = 3;   // "배출후 적재";
                    break;
                case 8:
                    ret = 4;   // "강제배출(1단)";
                    break;
            }

            return ret;
        }

        private string GetDirection(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

            string ret = string.Empty;

            bool mzCmd = Convert.ToBoolean(idx);

            if (mzCmd == true)
            {
                ret = _ConveyorType == "Conveyor" ? "Backward (Unloading)" : "Dispenser";
            }
            else
            {
                ret = _ConveyorType == "Conveyor" ? "Forward (Loading)" : "Magazine";
            }

            return ret;
        }
        #endregion

        #region GetDatatoBitIdx
        private int GetDatatoBitIdx(int data)
        {
            int idx = 0;

            for (int i = 0; i < 3; i++)
            {
                int val = (0x1 << i);
                bool bitOn = ((int)data & val) == val;

                if (bitOn)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }
        #endregion   

        #region CheckStationStatus
        /// <summary>
        /// Conveyor Type이 2,4,8,32 일때만 StationStatus Tag을 Enable
        /// </summary>
        private bool CheckStationStatus(object idx)
        {
            if (idx == null || idx.ToString() == "") return false;

            int cvType = Convert.ToInt32(idx);

            if (cvType == 2 || cvType == 4 || cvType == 8 || cvType == 32)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region CheckMagazineCommand
        /// <summary>
        /// Conveyor Type이 64,128,256 일때만 StationStatus Tag을 Enable
        /// </summary>
        private bool CheckMagazineCommand(object idx)
        {
            if (idx == null || idx.ToString() == "") return false;

            int cvType = Convert.ToInt32(idx);

            if (cvType == 64 || cvType == 128 || cvType == 256)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region GetTagIndex
        private int GetTagIndex(string tagPath, List<ReadValueId> cvInfo)
        {
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            return idx < 0 ? 0 : idx;
        }
        #endregion

        #region GetTagValue
        private string GetTagValuetoString(string tagPath, List<DataValue> data, List<ReadValueId> cvInfo)
        {
            string val = string.Empty;
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            if (idx > -1)
                val = Convert.ToString(data[idx].Value);
            
            return val;
        }

        private bool GetTagValuetoBool(string tagPath, List<DataValue> data, List<ReadValueId> cvInfo)
        {
            bool val = false;
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            if (idx > -1)
                val = Convert.ToBoolean(data[idx].Value);

            return val;
        }

        private int GetTagValuetoInt(string tagPath, List<DataValue> data, List<ReadValueId> cvInfo)
        {
            int val = 0;
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            if (idx > -1)
                val = Convert.ToInt16(data[idx].Value);

            return val;
        }
        #endregion

        #region AddTrayInfoData
        public void AddTrayInfoData(string browsename, object value, BuiltInType type)
        {
            List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];

            int tagIdx = GetTagIndex(browsename, cvInfo);

            NodeId nodeid = cvInfo[tagIdx].NodeId;
            InfoData trayInfo = new InfoData(nodeid, value, type);
            _CmdInfoData.Add(trayInfo);
        }
        #endregion

        #region TrackPause_Click
        private void TrackPause_Click(object sender, EventArgs e)
        {
            _CmdInfoData = new List<InfoData>();

            string val = TrackPauseOn.Checked == true ? "1" : "0";
            AddTrayInfoData("ConveyorInformation.TrackPause", val, BuiltInType.Boolean);

            if (TrackPauseOn.Checked == false)
            {
                CmdTrayCount.TextData = "0";
                CmdTrayID1.TextData = "";
                CmdTrayID2.TextData = "";
                CmdDestination.TextData = "0";
                CmdRTVFrom.TextData = "0";
                CmdRTVTo.TextData = "0";
                CmdMagazineCommand.SelectedIndex = 0;

                AddTrayInfoData("ConveyorCommand.TrayCount", CmdTrayCount.TextData, BuiltInType.UInt16);
                AddTrayInfoData("ConveyorCommand.TrayIdL1", CmdTrayID1.TextData, BuiltInType.String);
                AddTrayInfoData("ConveyorCommand.TrayIdL2", CmdTrayID2.TextData, BuiltInType.String);
                AddTrayInfoData("ConveyorCommand.Destination", CmdDestination.TextData, BuiltInType.UInt16);
                AddTrayInfoData("ConveyorCommand.RTVFrom", CmdRTVFrom.TextData, BuiltInType.UInt16);
                AddTrayInfoData("ConveyorCommand.RTVTo", CmdRTVTo.TextData, BuiltInType.UInt16);
                AddTrayInfoData("ConveyorCommand.MagazineCommand", 0, BuiltInType.UInt16);
            }            

            bool results = _OPCUAClient.NodesToWriteValue(_CmdInfoData);

            string pause = val == "1" ? "On" : "Off";

            if (results == true)
            {   
                CMessage.MsgInformation($"Track pause {pause} successful");
            }
            else
            {
                CMessage.MsgInformation($"Track pause {pause} failed");
            }
        }
        #endregion

        #region SetUserEventLog
        private async Task SetUserEventLog(string userEvent, string trayId, string userEventLog)
        {
            try
            {
                RESTClient rest = new RESTClient();

                _jsonUserEventRequest request = new _jsonUserEventRequest();
                request.ACTION_ID = "USER_EVENT";
                request.ACTION_USER = "MON";
                request.REQUEST_TIME = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}";

                //Request 세팅
                request.USER_ID = CDefine.m_strSaveLoginID;
                string windowid = CAuthority.WindowsNameToWindowID(this.Name);
                request.WINDOW_ID = windowid;
                request.TRAY_ID = trayId;
                request.CELL_ID = null;
                request.USER_EVENT = userEvent;
                request.USER_EVENT_LOG = userEventLog;

                var jsonResult = await rest.SetJson(CRestModulePath.POST_USER_EVENT, request);

                if (jsonResult != null)
                {
                    _jsonManualCommandResponse result = rest.ConvertManualCommand(jsonResult);

                    if (result != null)
                    {
                        if (result.RESPONSE_CODE == "200")
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        string log = "SetUserEventLog : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                        return;
                    }
                }
                else
                {
                    string log = "SetUserEventLog : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("SetUserEventLog Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("SetUserEventLog Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion
    }
}
