using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinWaterTank : WinFormRoot
    {
        private Point point = new Point();

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        CtrlLED[] _LedMode;

        List<ReadValueId> _CraneInfo;
        List<DataValue> _CraneData;

        OPCUAClient _OPCUAClient = null;
        int _CraneNo = 0;

        public WinWaterTank(OPCUAClient opcua, int craneNo, string barTitle)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _CraneNo = craneNo;

            InitControl();
            InitLanguage();
            InitLedStatus();
            InitGridView();

            Exit.Left = (this.panel2.Width - Exit.Width) / 2;
            Exit.Top = (this.panel2.Height - Exit.Height) / 2;

            titBar.TitleText = string.Format("Water Tank ({0})", barTitle);
        }

        #region WinWaterTank Event
        private void WinWaterTank_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Text) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridWaterTank.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

            this.WindowID = CAuthority.GetWindowsText(this.Text);
        }
        private void WinWaterTank_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
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
                _LedMode[i].Tag = "WaterTank.Mode";
                uiTlbMode.Controls.Add(_LedMode[i], 0, i);
            }

            int btnPos = (this.Width - CDefine.DEF_EXIT_WIDTH) / 2;   // Button Width Size 170            
            this.Exit.Padding = new System.Windows.Forms.Padding(btnPos, 10, btnPos, 10);
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

            foreach (var ctl in gbFMS.Controls)
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
                    //control.BackColor = Color.FromArgb(27, 27, 27);
                }
                //else if (ctl.GetType() == typeof(CtrlLabel))
                //{
                //    CtrlLabel control = ctl as CtrlLabel;
                //    control.CallLocalLanguage();
                //}
            }
        }
        #endregion

        #region InitLedStatus
        private void InitLedStatus()
        {
            // Mode
            for (int i = 0; i < _LedMode.Count(); i++)
            {
                _LedMode[i].LedStatus(0);
                _LedMode[i].BackColor = Color.FromArgb(46, 46, 46);
            }
        }
        #endregion

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Previous Position");
            lstTitle.Add("");
            gridWaterTank.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Line");
            lstTitle.Add("Bay");
            lstTitle.Add("Floor");
            lstTitle.Add("Deep");
            lstTitle.Add("Station");
            gridWaterTank.AddRowsHeaderList(lstTitle);

            gridWaterTank.ColumnHeadersHeight(28);
            gridWaterTank.RowsHeight(24);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>();
            lstTitle.Add("Previous Position");
            gridWaterTank.ColumnMergeList(lstColumn, lstTitle);

            gridWaterTank.SetGridViewStyles();
            gridWaterTank.ColumnHeadersWidth(0, 110);            
        }

        #region SetData
        public void SetData()
        {
            InitLedStatus();
            bool onoff = false;

            // Water Tank
            foreach (var control in gbWaterTank.Controls)
            {
                if (control.GetType() == typeof(CtrlLED))
                {
                    CtrlLED ctl = control as CtrlLED;

                    onoff = GetTagValuetoBool(ctl.Tag);
                    ctl.LedOnOff(onoff);
                }
            }

            int nVal = GetTagValuetoInt(_LedMode[0].Tag);
            int idx = GetDatatoBitIdx(nVal);
            _LedMode[idx].LedOnOff(nVal);

            // FMS
            foreach (var control in gbFMS.Controls)
            {
                if (control.GetType() == typeof(CtrlLabelBox))
                {
                    CtrlLabelBox ctl = control as CtrlLabelBox;

                    ctl.TextData = GetTagValuetoString(ctl.Tag);
                }
            }

            string[] location = { "PrevLocation" };
            string[] item = { "Line", "Bay", "Floor", "Deep", "Station" };

            for (int col = 0; col < location.Length; col++)
            {
                for (int row = 0; row < item.Length; row++)
                {
                    string tagName = string.Format($"{location[col]}.{item[row]}");
                    gridWaterTank.SetValue(col + 1, row, (GetTagValuetoString(tagName)));
                }
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
                System.Diagnostics.Debug.Print(string.Format("### WinConveyorInfo ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

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
        private void GridCellInfo_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 1 && row > -1)
            {
                //MessageBox.Show($"TrayInfoView DoubleClick CellID = {value}");

                //WinCellDetailInfo form = new WinCellDetailInfo();
                //form.SetData();
                //form.ShowDialog();

                //Refresh();
            }
        }
        #endregion

        #region GetTagValue
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

        #region Tray Tag Value
        private string GetPrevLocation(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "Near";
                    break;
                case 2:
                    ret = "Far";
                    break;
            }

            return ret;
        }

        private string GetMode(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "Maintenance Mode";
                    break;
                case 2:
                    ret = "Manual Mode";
                    break;
                case 4:
                    ret = "Control Mode";
                    break;
            }

            return ret;
        }
        #endregion

        
    }
}
