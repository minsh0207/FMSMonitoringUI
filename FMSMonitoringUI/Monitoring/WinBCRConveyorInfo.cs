using ExcelDataReader.Log;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MonitoringUI.Controlls.CComboBox;
using MonitoringUI.Controlls.CDateTime;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinBCRConveyorInfo : Form
    {
        public static readonly int _CVModeCount = 3;
        public static readonly int _CVStatusCount = 3;

        private Point _Point = new Point();

        CtrlLED[] _LedMode;
        CtrlLED[] _LedStatus;

        OPCUAClient _OPCUAClient = null;
        List<ReadValueId> _ConveyorNodeID = null;

        public WinBCRConveyorInfo(OPCUAClient opcua, List<ReadValueId> conveyorNodeID)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _ConveyorNodeID = conveyorNodeID;

            // Timer 
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Stop();

            InitControl();
            InitLanguage();
            InitLedStatus();
        }

        #region WinBCRConveyorInfo Event
        private void WinBCRConveyorInfo_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion
        }

        private void WinBCRConveyorInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_timer.Stop();
        }
        #endregion

        #region MonitoringTimer
        public void ShowForm()
        {
            // Timer
            m_timer.Start();

            this.Show();
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            foreach (var ctl in panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlTitleBar))
                {
                    CtrlTitleBar control = ctl as CtrlTitleBar;
                    control.CallLocalLanguage();
                }
            }

            foreach (var ctl in panel2.Controls)
            {
                if (ctl.GetType() == typeof(CtrlButton))
                {
                    CtrlButton control = ctl as CtrlButton;
                    control.CallLocalLanguage();
                }
            }

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
            }
        }
        #endregion

        private void InitControl()
        {

            string[] titleMode = { "Maintenance Mode", "Manual Mode", "Control Mode" };

            _LedMode = new CtrlLED[_CVModeCount];
            for (int i = 0; i < _CVModeCount; i++)
            {
                _LedMode[i] = new CtrlLED();
                _LedMode[i].TitleText = titleMode[i];
                _LedMode[i].Dock = DockStyle.Fill;
                uiTlbMode.Controls.Add(_LedMode[i], 0, i);
            }

            string[] titleStatus = { "Idle", "Run", "Trouble" };
            _LedStatus = new CtrlLED[_CVStatusCount];
            for (int i = 0; i < _CVModeCount; i++)
            {
                _LedStatus[i] = new CtrlLED();
                _LedStatus[i].TitleText = titleStatus[i];
                _LedStatus[i].Dock = DockStyle.Fill;
                uiTlbStatus.Controls.Add(_LedStatus[i], i, 0);
            }
        }

        private void InitLedStatus()
        {
            // Mode
            for (int i = 0; i < _CVModeCount; i++)
            {
                _LedMode[i].LedStatus(0);
            }

            // Status
            for (int i = 0; i < _CVStatusCount; i++)
            {
                _LedStatus[i].LedStatus(0);
            }
        }

        #region SetData
        public void SetData(List<DataValue> data)
        {
            if (data.Count == 0) return;

            InitLedStatus();

            bool onoff = bool.Parse(data[(int)enCVTagList.Power].Value.ToString());
            ledPower.LedOnOff(onoff);

            int value = int.Parse(data[(int)enCVTagList.Mode].Value.ToString());
            int idx = GetDatatoBitIdx(value);
            _LedMode[idx].LedOnOff(true);

            value = int.Parse(data[(int)enCVTagList.Status].Value.ToString());
            idx = GetDatatoBitIdx(value);
            _LedStatus[idx].LedStatus(value);

            onoff = bool.Parse(data[(int)enCVTagList.FMSStatus].Value.ToString());
            ledTroubleStatus.LedOnOff(onoff);

            // Conveyor
            ConveyorNo.TextData= data[(int)enCVTagList.ConveyorNo].Value.ToString();
            ConveyorType.TextData = GetConveyorType(data[(int)enCVTagList.ConveyorType].Value);
            CVTroubleErrNo.TextData = data[(int)enCVTagList.EqpErrorNo].Value.ToString();
            TroubleErrLevel.TextData = data[(int)enCVTagList.EqpErrorLevel].Value.ToString();
            CommandReady.TextData = data[(int)enCVTagList.CommandReady].Value.ToString();
            StationStatus.TextData = GetStationStatus(data[(int)enCVTagList.StationStatus].Value);
            TrayExist.TextData = data[(int)enCVTagList.TrayExist].Value.ToString();
            TrayType.TextData = GetTrayType(data[(int)enCVTagList.TrayType].Value);
            TrayCount.TextData = data[(int)enCVTagList.TrayCount].Value.ToString();
            TrayID1.TextData = data[(int)enCVTagList.TrayIdL1].Value.ToString();
            TrayID2.TextData = data[(int)enCVTagList.TrayIdL2].Value.ToString();

            // FMS
            FMSTroubleErrNo.TextData = data[(int)enCVTagList.FMSErrorNo].Value.ToString();
            Destination.TextData = data[(int)enCVTagList.Destination].Value.ToString();
            MagazineCommand.TextData = GetMagazineCommand(data[(int)enCVTagList.MagazineCommand].Value);
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
        #endregion

        #region OnTimer
        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                m_timer.Stop();

                List<DataValue> data = _OPCUAClient.ReadNodeID(_ConveyorNodeID);
                SetData(data); 

                if (m_timer.Interval != 1000)
                    m_timer.Interval = 1000;
                m_timer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
            }
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
                    ret = "적재";
                    break;
                case 2:
                    ret = "Bypass";
                    break;
                case 4:
                    ret = "배출후 적재";
                    break;
                case 8:
                    ret = "강제배출(1단)";
                    break;
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
    }
}
