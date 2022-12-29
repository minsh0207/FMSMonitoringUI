using ExcelDataReader.Log;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
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

        public WinBCRConveyorInfo()
        {
            InitializeComponent();

            //InitGridView();

            InitControl();

            InitLedStatus();
        }

        private void WinCVTrayInfo_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            //gridCVInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion
        }

        private void InitControl()
        {
            foreach (var ctl in panel3.Controls)
            {
                if (ctl.GetType() == typeof(CtrlGroupBox))
                {
                    CtrlGroupBox control = ctl as CtrlGroupBox;
                    control.CallLocalLanguage();
                }
            }

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
            // Control Mode
            //ledMaintMode.LedStatus(0);
            //ledManualMode.LedStatus(0);
            //ledControlMode.LedStatus(0);

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

        private void InitGridView()
        {
            //List<string> lstTitle = new List<string>();
            //lstTitle.Add("Equipment Status");   //-1
            //lstTitle.Add("");
            //gridCVInfo.AddColumnHeaderList(lstTitle);
            //gridCVInfo.ColumnHeadersVisible(true);

            //lstTitle = new List<string>();
            //lstTitle.Add("Power");
            //lstTitle.Add("Mode");
            //lstTitle.Add("Status");
            //lstTitle.Add("Trouble ErrorNo");
            //lstTitle.Add("Trouble ErrorLevel");

            //lstTitle.Add("FMS Status");     // 5            
            //lstTitle.Add("Trouble Status");
            //lstTitle.Add("Trouble ErrorNo");
            //lstTitle.Add("TimeSync");

            //lstTitle.Add("Conveyor Information");   // 9
            //lstTitle.Add("Conveyor No");
            //lstTitle.Add("Conveyor Type");
            //lstTitle.Add("Station Status");
            //lstTitle.Add("Tray Exist");
            //lstTitle.Add("Tray Type");
            //lstTitle.Add("Tray Count");
            //lstTitle.Add("Tray ID 1");
            //lstTitle.Add("Tray ID 2");
            //lstTitle.Add("Carriage Pos");

            //lstTitle.Add("Conveyor Command");       // 19
            //lstTitle.Add("Command Ready");
            //lstTitle.Add("Destination");
            //lstTitle.Add("Magazine Command");
            //gridCVInfo.AddRowsHeaderList(lstTitle);

            //gridCVInfo.ColumnHeadersHeight(24);
            //gridCVInfo.RowsHeight(24);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstColumn.Add(5);
            //lstColumn.Add(9);
            //lstColumn.Add(19);
            //lstTitle = new List<string>();
            //lstTitle.Add("Equipment Status");
            //lstTitle.Add("FMS Status");
            //lstTitle.Add("Conveyor Information");
            //lstTitle.Add("Conveyor Command");
            //gridCVInfo.ColumnMergeList(lstColumn, lstTitle);

            //gridCVInfo.SetGridViewStyles();
            //gridCVInfo.ColumnHeadersWidth(0, 200);            
        }

        #region SetData
        public void SetData(List<DataValue> data)
        {
            InitLedStatus();

            bool onoff = bool.Parse(data[(int)enSiteTagList.Power].Value.ToString());
            ledPower.LedOnOff(true);

            int value = int.Parse(data[(int)enSiteTagList.Mode].Value.ToString());
            int idx = GetDatatoBitIdx(value);
            _LedMode[idx].LedOnOff(true);

            value = int.Parse(data[(int)enSiteTagList.Status].Value.ToString());
            idx = GetDatatoBitIdx(value);
            _LedStatus[idx].LedStatus(value);

            ledTroubleStatus.LedOnOff(false);

            //int idx = 1;
            //for (int i = 0; i < gridCVInfo.RowCount; i++)
            //{
            //    if (!gridCVInfo._CellMerge.Contains(i))
            //    {
            //        object value;
            //        bool status = false;

            //        switch (idx)
            //        {
            //            case (int)enSiteTagList.Power:
            //                value = (bool.Parse(data[(int)enSiteTagList.Power].Value.ToString()) == true ? 
            //                    "On" : "Off");
                            
            //                break;

            //            case (int)enSiteTagList.ConveyorType:
            //                value = GetConveyorType(int.Parse(data[(int)enSiteTagList.ConveyorType].Value.ToString()));
            //                break;

            //            case (int)enSiteTagList.StationStatus:
            //                value = GetStationStatus(int.Parse(data[(int)enSiteTagList.StationStatus].Value.ToString()));
            //                break;

            //            case (int)enSiteTagList.TrayExist:
            //                value = (bool.Parse(data[(int)enSiteTagList.TrayExist].Value.ToString()) == true ?
            //                    "Exist" : "Not Exist");

            //                status = bool.Parse(data[(int)enSiteTagList.TrayExist].Value.ToString());
            //                ledPower.LedOnOff(status);
            //                break;

            //            case (int)enSiteTagList.TrayType:
            //                value = GetTrayType(int.Parse(data[(int)enSiteTagList.TrayType].Value.ToString()));
            //                break;

            //            case (int)enSiteTagList.MagazineCommand:
            //                value = GetMagazineCommand(int.Parse(data[(int)enSiteTagList.MagazineCommand].Value.ToString()));
            //                break;

            //            default:
            //                value = data[idx].Value;
            //                break;
            //        }

            //        gridCVInfo.SetValue(1, i, value);
            //        idx++;
            //    }                
            //}

            // Equipment Status
            //gridCVInfo.SetValue(1, 0, data[(int)enSiteTagList.Power].Value);
            //gridCVInfo.SetValue(1, 1, data[(int)enSiteTagList.ConveyorNo].Value);
            //gridCVInfo.SetValue(1, 2, siteInfo.TrayIdL1);
            //gridCVInfo.SetValue(1, 3, siteInfo.TrayIdL2);
            //gridCVInfo.SetValue(1, 3, siteInfo.TrayIdL2);

            //gridCVInfo.SetValue(1, 0, siteInfo.ConveyorNo);
            //gridCVInfo.SetValue(1, 1, GetConveyorType(siteInfo.ConveyorType));
            //gridCVInfo.SetValue(1, 2, siteInfo.TrayIdL1);
            //gridCVInfo.SetValue(1, 3, siteInfo.TrayIdL2);
            //gridCVInfo.SetValue(1, 4, (siteInfo.TrayExist == true ? "Exist" : "Not Exist"));
            //gridCVInfo.SetValue(1, 5, siteInfo.TrayCount);
            //gridCVInfo.SetValue(1, 6, GetTrayType(siteInfo.TrayType));
            //gridCVInfo.SetValue(1, 7, GetStationStatus(siteInfo.StationStatus));
            //gridCVInfo.SetValue(1, 8, siteInfo.Destination);

            //BindingSource bindingSource = new BindingSource();

            //bindingSource.DataSource = data;
            //gridCVInfo.DataSource(bindingSource);

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

        #region DataGridView Event
        //private void GridCellInfo_MouseCellDoubleClick(int col, int row, object value)
        //{
        //    if (col == 1 && row > -1)
        //    {
        //        //MessageBox.Show($"TrayInfoView DoubleClick CellID = {value}");

        //        WinCellDetailInfo form = new WinCellDetailInfo();
        //        form.SetData();
        //        form.ShowDialog();

        //        Refresh();
        //    }
        //}
        #endregion

        #region Button Event
        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Tray Tag Value
        private string GetConveyorType(int idx)
        {
            string ret = string.Empty;

            switch (idx)
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

        private string GetStationStatus(int idx)
        {
            string ret = string.Empty;

            switch (idx)
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

        private string GetTrayType(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "BD - Before Degas Long Tray";
                    break;
                case 2:
                    ret = "AD - After Degas Short Tray";
                    break;
            }

            return ret;
        }

        private string GetMagazineCommand(int idx)
        {
            string ret = string.Empty;

            switch (idx)
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
    }
}
