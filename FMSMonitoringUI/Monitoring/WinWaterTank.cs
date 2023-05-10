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
using System.Windows.Threading;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinWaterTank : WinFormRoot
    {
        private Point point = new Point();

        private string _trayID1 = string.Empty;
        private string _trayID2 = string.Empty;

        //#region Working Thread
        //private Thread _ProcessThread;
        //private bool _TheadVisiable;
        //#endregion

        // Timer
        DispatcherTimer m_timer;

        CtrlLED[] _LedMode;

        List<ReadValueId> _CraneInfo;
        List<DataValue> _CraneData;

        OPCUAClient _OPCUAClient = null;
        int _CraneNo = 0;
        string _TankIdx = string.Empty;

        public WinWaterTank(OPCUAClient opcua, int craneNo, string barTitle, int tankIdx)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _CraneNo = craneNo;
            _TankIdx = (tankIdx == 1 ? "WaterTank1." : "WaterTank2.");

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
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Name) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            //#region DataGridView Event
            //gridWaterTank.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            //#endregion

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

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }
        private void WinWaterTank_FormClosed(object sender, FormClosedEventArgs e)
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
                _LedMode[i].Tag = "Mode";
                uiTlbMode.Controls.Add(_LedMode[i], 0, i);
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
                    CtrlGroupBox grBox = ctl as CtrlGroupBox;
                    grBox.CallLocalLanguage();

                    foreach (var ctl2 in grBox.Controls)
                    {
                        if (ctl2.GetType() == typeof(CtrlLabelBox))
                        {
                            CtrlLabelBox control = ctl2 as CtrlLabelBox;
                            control.CallLocalLanguage();
                        }
                        else if (ctl2.GetType() == typeof(CtrlLabel))
                        {
                            CtrlLabel tagName = ctl2 as CtrlLabel;
                            tagName.CallLocalLanguage();
                        }
                    }
                }
            }

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
                //_LedMode[i].BackColor = Color.FromArgb(46, 46, 46);
            }
        }
        #endregion

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Previous_Position"),
                ""
            };
            gridWaterTank.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Lane"),
                LocalLanguage.GetItemString("DEF_Bay"),
                LocalLanguage.GetItemString("DEF_Floor"),
                //LocalLanguage.GetItemString("DEF_Deep"),
                LocalLanguage.GetItemString("DEF_Station")
            };
            gridWaterTank.AddRowsHeaderList(lstTitle);

            gridWaterTank.ColumnHeadersHeight(28);
            gridWaterTank.RowsHeight(24);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Previous_Position")
            };
            gridWaterTank.ColumnMergeList(lstColumn, lstTitle);

            gridWaterTank.SetGridViewStyles();
            gridWaterTank.ColumnHeadersWidth(0, 110);            
        }

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

                _CraneInfo = _OPCUAClient.CraneNodeID[_CraneNo];
                _CraneData = _OPCUAClient.ReadNodeID(_CraneInfo);

                if (_CraneData.Count > 0)
                {
                    this.BeginInvoke(new Action(() => SetData()));
                }

                //Set Time interval
                if (m_timer.Interval.Seconds.ToString() != "2")
                    m_timer.Interval = TimeSpan.FromSeconds(2);

                //timer Stop And Start
                m_timer.Start();

            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WinCraneInfo Timer Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.Error, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "OnTimer Error Exception : " + ex.Message);
            }
        }
        #endregion

        #region ProcessThreadCallback
        //private void ProcessThreadCallback()
        //{
        //    try
        //    {
        //        //while (this._TheadVisiable == true)
        //        {
        //            GC.Collect();

        //            _CraneInfo = _OPCUAClient.CraneNodeID[_CraneNo];
        //            _CraneData = _OPCUAClient.ReadNodeID(_CraneInfo);

        //            if (_CraneData.Count > 0)
        //            {
        //                this.BeginInvoke(new Action(() => SetData()));
        //            }

        //            //Thread.Sleep(2000);
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

                    onoff = GetTagValuetoBool(_TankIdx + ctl.Tag);
                    ctl.LedOnOff(onoff);
                }
            }

            int nVal = GetTagValuetoInt(_TankIdx + _LedMode[0].Tag);
            int idx = GetDatatoBitIdx(nVal);
            _LedMode[idx].LedOnOff(nVal);

            // FMS
            foreach (var control in gbFMS.Controls)
            {
                if (control.GetType() == typeof(CtrlLabelBox))
                {
                    CtrlLabelBox ctl = control as CtrlLabelBox;

                    ctl.TextData = GetTagValuetoString(_TankIdx + ctl.Tag);

                    if (ctl.Tag.ToString() == _TankIdx + "TrayIdL1")
                        _trayID1 = ctl.TextData;
                    else if (ctl.Tag.ToString() == _TankIdx + "TrayIdL2")
                        _trayID2 = ctl.TextData;
                }
            }

            string[] location = { "PrevLocation" };
            string[] item = { "Lane", "Bay", "Floor", "Station" };

            for (int col = 0; col < location.Length; col++)
            {
                for (int row = 0; row < item.Length; row++)
                {
                    string tagName = string.Format($"{location[col]}.{item[row]}");
                    gridWaterTank.SetValue(col + 1, row, (GetTagValuetoString(_TankIdx + tagName)));
                }
            }
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
        //private void GridCellInfo_MouseCellDoubleClick(int col, int row, object value)
        //{
        //    if (col == 1 && row > -1)
        //    {
        //        //MessageBox.Show($"TrayInfoView DoubleClick CellID = {value}");

        //        //WinCellDetailInfo form = new WinCellDetailInfo();
        //        //form.SetData();
        //        //form.Show();

        //        //Refresh();
        //    }
        //}
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

            return Convert.ToInt16(_CraneData[tagIdx].Value.ToString());
        }
        private string GetTagValuetoString(object browerName)
        {
            int tagIdx = _CraneInfo.FindIndex(x => x.UserData.ToString() == browerName.ToString());

            if (tagIdx < 0) return "";

            return (_CraneData[tagIdx].Value != null ? _CraneData[tagIdx].Value.ToString() : "");
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
