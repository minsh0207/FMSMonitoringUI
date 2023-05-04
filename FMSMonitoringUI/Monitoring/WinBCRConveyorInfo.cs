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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinBCRConveyorInfo : WinFormRoot
    {
        private Point _Point = new Point();

        private string _trayID1 = string.Empty;
        private string _trayID2 = string.Empty;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        CtrlLED[] _LedMode;
        CtrlLED[] _LedStatus;

        OPCUAClient _OPCUAClient = null;
        int _ConveyorNo = 0;
        bool _FirstActivate;

        private List<InfoData> _CmdInfoData;

        public WinBCRConveyorInfo(OPCUAClient opcua, int conveyorNo)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _ConveyorNo = conveyorNo;

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

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }

        private void WinBCRConveyorInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
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

        #region MonitoringTimer
        public void ShowForm()
        {
            this.Show();
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

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];
                    List<DataValue> data = _OPCUAClient.ReadNodeID(cvInfo);
                    this.BeginInvoke(new Action(() => SetData(data, cvInfo)));

                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region SetData
        public void SetData(List<DataValue> data, List<ReadValueId> cvInfo)
        {
            if (data == null || data.Count == 0) return;

            InitLedStatus();

            //bool onoff = bool.Parse(data[(int)enCVTagList.Power].Value.ToString());
            //ledPower.LedOnOff(onoff);

            string tagValue = GetTagValue("EquipmentStatus.Mode", data, cvInfo);
            int value = int.Parse(tagValue);
            int idx = GetDatatoBitIdx(value);
            _LedMode[idx].LedControlMode(value);

            tagValue = GetTagValue("EquipmentStatus.Status", data, cvInfo);
            value = int.Parse(tagValue);
            idx = GetDatatoBitIdx(value);
            _LedStatus[idx].LedStatus(value);

            tagValue = GetTagValue("FmsStatus.Trouble.Status", data, cvInfo);
            bool onoff = bool.Parse(tagValue);
            ledTroubleStatus.LedOnOff(onoff);

            // Conveyor
            tagValue = GetTagValue("ConveyorInformation.TrackNo", data, cvInfo);
            if (tagValue == "0")
                ConveyorNo.TextData = _ConveyorNo.ToString();
            else
                ConveyorNo.TextData = tagValue;

            int cvTypeIdx = GetTagIndex("ConveyorInformation.ConveyorType", cvInfo);
            ConveyorType.TextData = GetConveyorType(data[cvTypeIdx].Value);

            tagValue = GetTagValue("EquipmentStatus.Trouble.ErrorNo", data, cvInfo);
            CVTroubleErrNo.TextData = tagValue;

            tagValue = GetTagValue("EquipmentStatus.Trouble.ErrorLevel", data, cvInfo);
            TroubleErrLevel.TextData = tagValue;

            tagValue = GetTagValue("ConveyorInformation.Direction", data, cvInfo);
            Direction.TextData = GetDirection(tagValue);

            tagValue = GetTagValue("ConveyorInformation.TrackingDestination", data, cvInfo);
            TrackingDestination.TextData = tagValue;

            //CommandReady.TextData = data[(int)enCVTagList.CommandReady].Value.ToString();
            tagValue = GetTagValue("ConveyorCommand.CommandReady", data, cvInfo);
            onoff = bool.Parse(tagValue);
            ledCommandReady.LedOnOff(onoff);

            tagValue = GetTagValue("ConveyorInformation.StationStatus", data, cvInfo);
            StationStatus.TextData = GetStationStatus(tagValue);

            //TrayExist.TextData = data[(int)enCVTagList.TrayExist].Value.ToString();
            tagValue = GetTagValue("ConveyorInformation.TrayExist", data, cvInfo);
            onoff = bool.Parse(tagValue);
            ledTrayExist.LedOnOff(onoff);

            tagValue = GetTagValue("ConveyorInformation.TrayType", data, cvInfo);
            TrayType.TextData = GetTrayType(tagValue);

            tagValue = GetTagValue("ConveyorInformation.TrayCount", data, cvInfo);
            TrayCount.TextData = tagValue;

            tagValue = GetTagValue("ConveyorInformation.TrayIdL1", data, cvInfo);
            TrayID1.TextData = tagValue;
            _trayID1 = tagValue;

            tagValue = GetTagValue("ConveyorInformation.TrayIdL2", data, cvInfo);
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
            tagValue = GetTagValue("FmsStatus.Trouble.ErrorNo", data, cvInfo);
            FMSTroubleErrNo.TextData =  tagValue;

            tagValue = GetTagValue("ConveyorInformation.TrackPause", data, cvInfo);
            bool pause = Convert.ToBoolean(tagValue);

            if (pause == true)
            {
                TrackPauseOn.Checked = true;
                TrackPauseOff.Checked = false;

                CmdTrayCount.SetTextBoxEnable(true);
                CmdTrayID1.SetTextBoxEnable(true);
                CmdTrayID2.SetTextBoxEnable(true);
                CmdDestination.SetTextBoxEnable(true);

                Write.Visible = true;
            }
            else
            {
                TrackPauseOn.Checked = false;
                TrackPauseOff.Checked = true;

                CmdTrayCount.SetTextBoxEnable(false);
                CmdTrayID1.SetTextBoxEnable(false);
                CmdTrayID2.SetTextBoxEnable(false);
                CmdDestination.SetTextBoxEnable(false);

                Write.Visible = false;
            }

            if (_FirstActivate == true)
            {
                tagValue = GetTagValue("ConveyorCommand.TrayCount", data, cvInfo);
                CmdTrayCount.TextData = tagValue;

                tagValue = GetTagValue("ConveyorCommand.TrayIdL1", data, cvInfo);
                CmdTrayID1.TextData = tagValue;

                tagValue = GetTagValue("ConveyorCommand.TrayIdL2", data, cvInfo);
                CmdTrayID2.TextData = tagValue;

                tagValue = GetTagValue("ConveyorCommand.Destination", data, cvInfo);
                CmdDestination.TextData = tagValue;

                _FirstActivate = false;
            }            

            tagValue = GetTagValue("ConveyorCommand.MagazineCommand", data, cvInfo);
            MagazineCommand.TextData = GetMagazineCommand(tagValue);

            if (CheckMagazineCommand(data[cvTypeIdx].Value))
                MagazineCommand.Visible = true;
            else
                MagazineCommand.Visible = false;
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

            bool results = _OPCUAClient.NodesToWriteValue(_CmdInfoData);

            if (results == true)
            {
                CMessage.MsgInformation("Save successful");
            }
            else
            {
                CMessage.MsgInformation("Save failed");
            }

            string log = $"TrayCount={CmdTrayCount.TextData},TrayIdL1={CmdTrayID1.TextData},TrayIdL2={CmdTrayID2.TextData},Destination={CmdDestination.TextData}";
            SetUserEventLog("WriteCommand", _trayID1, log).GetAwaiter().GetResult();
        }
        #endregion        

        #region Tray Tag Value
        private string GetConveyorType(object idx)
        {
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
            string ret = string.Empty;

            int mzCmd = Convert.ToInt32(idx);

            switch (mzCmd)
            {
                case 1:
                    ret = "Loading";    //"적재";
                    break;
                case 2:
                    ret = "Bypass";
                    break;
                case 4:
                    ret = "Load after discharge";   // "배출후 적재";
                    break;
                case 8:
                    ret = "Force Tray Unload";   // "강제배출(1단)";
                    break;
            }

            return ret;
        }

        private string GetDirection(object idx)
        {
            string ret = string.Empty;

            bool mzCmd = Convert.ToBoolean(idx);

            if (mzCmd == true)
            {
                ret = "Backward (Unloading)";
            }
            else
            {
                ret = "Forward (Loading)";
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
            if (idx == null || idx.ToString() == "")    return false;

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
            return cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));
        }
        #endregion

        #region GetTagValue
        private string GetTagValue(string tagPath, List<DataValue> data, List<ReadValueId> cvInfo)
        {
            string val = string.Empty;
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            if (idx > -1)
                val = Convert.ToString(data[idx].Value);
            
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

                AddTrayInfoData("ConveyorCommand.TrayCount", CmdTrayCount.TextData, BuiltInType.UInt16);
                AddTrayInfoData("ConveyorCommand.TrayIdL1", CmdTrayID1.TextData, BuiltInType.String);
                AddTrayInfoData("ConveyorCommand.TrayIdL2", CmdTrayID2.TextData, BuiltInType.String);
                AddTrayInfoData("ConveyorCommand.Destination", CmdDestination.TextData, BuiltInType.UInt16);
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
