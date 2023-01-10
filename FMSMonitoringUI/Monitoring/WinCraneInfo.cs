using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using OPCUAClientClassLib;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinCraneInfo : Form
    {
        List<ReadValueId> _CraneInfo;
        List<DataValue> _CraneData;

        private Point point = new Point();

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        CtrlLED[] _LedMode;
        CtrlLED[] _LedStatus;
        CtrlLED[] _LedForkPos;
        CtrlLED[] _LedJobType;

        OPCUAClient _OPCUAClient = null;
        int _CraneNo = 0;

        public WinCraneInfo(OPCUAClient opcua, int craneNo)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _CraneNo = craneNo;

            InitControl();
            InitLanguage();
            InitLedStatus();

            InitGridViewCraneCmd();

        }

        #region WinCraneInfo
        private void WinCraneInfo_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            //gridCraneCmd.MouseCellClick_Evnet += GridProcessFlow_MouseCellClick;
            #endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));
        }
        private void WinCraneInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
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
                _LedMode[i].Tag = "EquipmentStatus.Mode";
                uiTlbMode.Controls.Add(_LedMode[i], 0, i);
            }

            string[] titleStatus = { "Idle", "Run", "Trouble" };
            _LedStatus = new CtrlLED[titleStatus.Length];
            for (int i = 0; i < titleStatus.Length; i++)
            {
                _LedStatus[i] = new CtrlLED();
                _LedStatus[i].TitleText = titleStatus[i];
                _LedStatus[i].Tag = "EquipmentStatus.Status";
                uiTlbStatus.Controls.Add(_LedStatus[i], i, 0);
            }

            string[] titleForkPos = { "Center", "Left depth1", "Left depth2", "Right depth1", "Right depth2" };
            _LedForkPos = new CtrlLED[titleForkPos.Length];
            for (int i = 0; i < titleForkPos.Length; i++)
            {
                _LedForkPos[i] = new CtrlLED();
                _LedForkPos[i].TitleText = titleForkPos[i];
                _LedForkPos[i].Tag = "CraneCommand.ForkPosition";
                uiTlbForkPos.Controls.Add(_LedForkPos[i], 0, i);
            }

            string[] titleJogType = { "In", "Out", "RacktoRack", "Pass",  "Move" };
            _LedJobType = new CtrlLED[titleJogType.Length];
            int idx = 0;
            for (int col = 0; col < uiTlbJogType1.ColumnCount; col++)
            {
                _LedJobType[idx] = new CtrlLED();
                _LedJobType[idx].TitleText = titleJogType[idx];
                _LedJobType[idx].Tag = "CraneCommand.JobType";
                uiTlbJogType1.Controls.Add(_LedJobType[idx], col, 0);
                idx++;
            }
            for (int col = 0; col < uiTlbJogType2.ColumnCount; col++)
            {
                _LedJobType[idx] = new CtrlLED();
                _LedJobType[idx].TitleText = titleJogType[idx];
                _LedJobType[idx].Tag = "CraneCommand.JobType";
                uiTlbJogType2.Controls.Add(_LedJobType[idx], col, 0);
                idx++;
            }
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

        #region InitLedStatus
        private void InitLedStatus()
        {
            // Mode
            for (int i = 0; i < _LedMode.Length; i++)
            {
                _LedMode[i].LedStatus(0);
            }

            // Status
            for (int i = 0; i < _LedStatus.Length; i++)
            {
                _LedStatus[i].LedStatus(0);
            }

            // ForkPosition
            for (int i = 0; i < _LedForkPos.Length; i++)
            {
                _LedForkPos[i].LedStatus(0);
            }

            // ForkPosition
            for (int i = 0; i < _LedForkPos.Length; i++)
            {
                _LedJobType[i].LedStatus(0);
            }
        }
        #endregion

        private void InitGridViewCraneCmd()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("From Location");   
            lstTitle.Add("To Location");
            gridCraneCmd.AddColumnHeaderList(lstTitle);
            gridCraneCmd.ColumnHeadersVisible(true);

            lstTitle = new List<string>();
            lstTitle.Add("Line");
            lstTitle.Add("Bay");
            lstTitle.Add("Floor");
            lstTitle.Add("Deep");
            lstTitle.Add("Station");
            lstTitle.Add("Forking Enable");
            gridCraneCmd.AddRowsHeaderList(lstTitle);

            gridCraneCmd.ColumnHeadersHeight(24);
            gridCraneCmd.RowsHeight(24);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Crane Command");
            //gridCraneCmd.ColumnMergeList(lstColumn, lstTitle);

            gridCraneCmd.SetGridViewStyles();
            gridCraneCmd.ColumnHeadersWidth(0, 100);
        }

        public void SetData()
        {
            InitLedStatus();
            bool onoff = false;

            // Stacker Crane
            foreach (var control in gbSCrane.Controls)
            {
                if (control.GetType() == typeof(CtrlLED))
                {
                    CtrlLED ctl = control as CtrlLED;

                    onoff = GetTagValuetoBool(ctl.Tag);
                    ctl.LedOnOff(onoff);
                }
                else if (control.GetType() == typeof(CtrlLabelBox))
                {
                    CtrlLabelBox ctl = control as CtrlLabelBox;

                    ctl.TextData = GetTagValuetoString(ctl.Tag);
                }
            }

            int nVal = GetTagValuetoInt(_LedMode[0].Tag);
            int idx = GetDatatoBitIdx(nVal);
            _LedMode[idx].LedOnOff(nVal);

            nVal = GetTagValuetoInt(_LedStatus[0].Tag);
            idx = GetDatatoBitIdx(nVal);
            _LedStatus[idx].LedStatus(nVal);

            nVal = GetTagValuetoInt(_LedForkPos[0].Tag);
            idx = GetDatatoBitIdx(nVal);
            _LedForkPos[idx].LedOnOff(nVal);

            int nBay = GetTagValuetoInt(lbCarriagePos.Tag);
            int nFloor = GetTagValuetoInt("Carriage.PosFloor");
            lbCarriagePos.TextData = string.Format($"{nBay}Bay-{nFloor}F");

            // FMS
            foreach (var control in gbFMS.Controls)
            {
                if (control.GetType() == typeof(CtrlLED))
                {
                    CtrlLED ctl = control as CtrlLED;

                    onoff = GetTagValuetoBool(ctl.Tag);
                    ctl.LedOnOff(onoff);
                }
                else if (control.GetType() == typeof(CtrlLabelBox))
                {
                    CtrlLabelBox ctl = control as CtrlLabelBox;

                    ctl.TextData = GetTagValuetoString(ctl.Tag);
                }
            }

            nVal = GetTagValuetoInt(_LedJobType[0].Tag);
            if (nVal > 0) _LedJobType[nVal - 1].LedOnOff(nVal);

            string[] location = { "LocationFrom", "LocationTo" };
            string[] item = { "Line", "Bay", "Floor", "Deep", "Station" };

            for (int col = 0; col < location.Length; col++)
            {
                for (int row = 0; row < item.Length; row++)
                {
                    string tagName = string.Format($"{location[col]}.{item[row]}");
                    gridCraneCmd.SetValue(col + 1, row, (GetTagValuetoString(tagName)));
                }
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

                    _CraneInfo = _OPCUAClient.CraneNodeID[_CraneNo];
                    _CraneData = _OPCUAClient.ReadNodeID(_CraneInfo);

                    if (_CraneData.Count > 0)
                    {
                        this.BeginInvoke(new Action(() => SetData()));
                    }

                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        public void SetTitleName(string title)
        {
            ctrlTitleBar.TitleText = title;
        }

        #region Titel Mouse Event
        private void Title_MouseDownEvnet(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void Title_MouseMoveEvnet(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }
        #endregion

        #region DataGridView Event
        //private void GridProcessFlow_MouseCellClick(int col, int row, object value)
        //{
        //    if (col == gridCraneCmd.ColumnCount -1 && row > -1)
        //    {
        //        WinCellDetailInfo form = new WinCellDetailInfo();
        //        form.SetData();
        //        form.ShowDialog();
        //    }
        //}
        #endregion

        //private void ctrlButton1_Click(object sender, EventArgs e)
        //{
        //    WinCellDetailInfo form = new WinCellDetailInfo();
        //    form.SetData();
        //    form.ShowDialog();
        //}

        #region
        private bool GetTagValuetoBool(object browerName)
        {
            int tagIdx = _CraneInfo.FindIndex(x => x.UserData.ToString() == browerName.ToString());
            
            if (tagIdx < 0) return false;

            return Convert.ToBoolean(_CraneData[tagIdx].Value.ToString());
        }
        private int GetTagValuetoInt(object browerName)
        {
            int tagIdx = _CraneInfo.FindIndex(x => x.UserData.ToString() == browerName.ToString());

            if (tagIdx < 0) return 0;

            return Convert.ToInt32(_CraneData[tagIdx].Value.ToString());
        }
        private string GetTagValuetoString(object browerName)
        {
            int tagIdx = _CraneInfo.FindIndex(x => x.UserData.ToString() == browerName.ToString());

            if (tagIdx < 0) return "";

            return _CraneData[tagIdx].Value.ToString();
        }
        #endregion

        #region GetDatatoBitIdx
        private int GetDatatoBitIdx(int data)
        {
            int idx = 0;

            for (int i = 0; i < 8; i++)
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

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
