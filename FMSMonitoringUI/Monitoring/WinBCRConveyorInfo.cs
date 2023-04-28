using ExcelDataReader.Log;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MonitoringUI.Controlls.CComboBox;
using MonitoringUI.Controlls.CDateTime;
using MySqlX.XDevAPI.Relational;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            int tagIdx = GetTagIndex("EquipmentStatus.Mode", cvInfo);
            int value = int.Parse(data[tagIdx].Value.ToString());
            int idx = GetDatatoBitIdx(value);
            _LedMode[idx].LedControlMode(value);

            tagIdx = GetTagIndex("EquipmentStatus.Status", cvInfo);
            value = int.Parse(data[tagIdx].Value.ToString());
            idx = GetDatatoBitIdx(value);
            _LedStatus[idx].LedStatus(value);

            tagIdx = GetTagIndex("FmsStatus.Trouble.Status", cvInfo);
            bool onoff = bool.Parse(data[tagIdx].Value.ToString());
            ledTroubleStatus.LedOnOff(onoff);

            // Conveyor
            tagIdx = GetTagIndex("ConveyorInformation.TrackNo", cvInfo);
            if (data[tagIdx].Value.ToString() == "0")
                ConveyorNo.TextData = _ConveyorNo.ToString();
            else
                ConveyorNo.TextData = data[tagIdx].Value.ToString();

            int cvTypeIdx = GetTagIndex("ConveyorInformation.ConveyorType", cvInfo);
            ConveyorType.TextData = GetConveyorType(data[cvTypeIdx].Value);

            tagIdx = GetTagIndex("EquipmentStatus.Trouble.ErrorNo", cvInfo);
            CVTroubleErrNo.TextData = data[tagIdx].Value.ToString();

            tagIdx = GetTagIndex("EquipmentStatus.Trouble.ErrorLevel", cvInfo);
            TroubleErrLevel.TextData = data[tagIdx].Value.ToString();

            tagIdx = GetTagIndex("ConveyorInformation.Direction", cvInfo);
            Direction.TextData = GetDirection(data[tagIdx].Value);

            tagIdx = GetTagIndex("ConveyorInformation.TrackingDestination", cvInfo);
            TrackingDestination.TextData = data[tagIdx].Value.ToString();

            //CommandReady.TextData = data[(int)enCVTagList.CommandReady].Value.ToString();
            tagIdx = GetTagIndex("ConveyorCommand.CommandReady", cvInfo);
            onoff = bool.Parse(data[tagIdx].Value.ToString());
            ledCommandReady.LedOnOff(onoff);

            tagIdx = GetTagIndex("ConveyorInformation.StationStatus", cvInfo);
            StationStatus.TextData = GetStationStatus(data[tagIdx].Value);

            //TrayExist.TextData = data[(int)enCVTagList.TrayExist].Value.ToString();
            tagIdx = GetTagIndex("ConveyorInformation.TrayExist", cvInfo);
            onoff = bool.Parse(data[tagIdx].Value.ToString());
            ledTrayExist.LedOnOff(onoff);

            tagIdx = GetTagIndex("ConveyorInformation.TrayType", cvInfo);
            TrayType.TextData = GetTrayType(data[tagIdx].Value);

            tagIdx = GetTagIndex("ConveyorInformation.TrayCount", cvInfo);
            TrayCount.TextData = data[tagIdx].Value.ToString();

            tagIdx = GetTagIndex("ConveyorInformation.TrayIdL1", cvInfo);
            TrayID1.TextData = Convert.ToString(data[tagIdx].Value);
            _trayID1 = Convert.ToString(data[tagIdx].Value);

            tagIdx = GetTagIndex("ConveyorInformation.TrayIdL2", cvInfo);
            TrayID2.TextData = Convert.ToString(data[tagIdx].Value);
            //if (Convert.ToString(data[tagIdx].Value) == "")
            //    TrayID2.Visible = false;
            //else
            //    TrayID2.Visible = true;            
            _trayID2 = Convert.ToString(data[tagIdx].Value);


            if (CheckStationStatus(data[tagIdx].Value))
                StationStatus.Visible = true;
            else
                StationStatus.Visible = false;

            // FMS
            tagIdx = GetTagIndex("FmsStatus.Trouble.ErrorNo", cvInfo);
            FMSTroubleErrNo.TextData = data[tagIdx].Value.ToString();

            if (_FirstActivate == true)
            {
                tagIdx = GetTagIndex("ConveyorInformation.TrackPause", cvInfo);
                bool pause = Convert.ToBoolean(data[tagIdx].Value);

                if (pause == true)
                {
                    TrackPauseOn.Checked = true;
                    TrackPauseOff.Checked = false;
                }
                else
                {
                    TrackPauseOn.Checked = false;
                    TrackPauseOff.Checked = true;
                }

                tagIdx = GetTagIndex("ConveyorCommand.TrayCount", cvInfo);
                CmdTrayCount.TextData = data[tagIdx].Value.ToString();

                tagIdx = GetTagIndex("ConveyorCommand.TrayIdL1", cvInfo);
                CmdTrayID1.TextData = Convert.ToString(data[tagIdx].Value);

                tagIdx = GetTagIndex("ConveyorCommand.TrayIdL2", cvInfo);
                CmdTrayID2.TextData = Convert.ToString(data[tagIdx].Value);

                tagIdx = GetTagIndex("ConveyorCommand.Destination", cvInfo);
                CmdDestination.TextData = data[tagIdx].Value.ToString();

                _FirstActivate = false;
            }            

            tagIdx = GetTagIndex("ConveyorCommand.MagazineCommand", cvInfo);
            MagazineCommand.TextData = GetMagazineCommand(data[tagIdx].Value);

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
            _CmdInfoData = new List<InfoData>();

            string val = TrackPauseOn.Checked == true ? "1" : "0";
            AddTrayInfoData("ConveyorInformation.TrackPause", val, BuiltInType.Boolean);

            AddTrayInfoData("ConveyorCommand.TrayCount", CmdTrayCount.TextData, BuiltInType.UInt16);
            AddTrayInfoData("ConveyorCommand.TrayIdL1", CmdTrayID1.TextData, BuiltInType.String);
            AddTrayInfoData("ConveyorCommand.TrayIdL2", CmdTrayID2.TextData, BuiltInType.String);
            AddTrayInfoData("ConveyorCommand.Destination", CmdDestination.TextData, BuiltInType.UInt16);

            _OPCUAClient.NodesToWriteValue(_CmdInfoData);
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

            if (mzCmd)
            {
                ret = "Forward (Loading)";
            }
            else
            {
                ret = "Backward (Unloading)";
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

        public void AddTrayInfoData(string browsename, object value, BuiltInType type)
        {
            List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];

            int tagIdx = GetTagIndex(browsename, cvInfo);

            NodeId nodeid = cvInfo[tagIdx].NodeId;
            InfoData trayInfo = new InfoData(nodeid, value, type);
            _CmdInfoData.Add(trayInfo);
        }
    }
}
