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
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinBCRConveyorInfo : Form
    {
        private Point point = new Point();

        public WinBCRConveyorInfo()
        {
            InitializeComponent();

            InitGridView();

            
        }

        private void WinCVTrayInfo_Load(object sender, EventArgs e)
        {
            InitControl();

            

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
        }

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Equipment Status");   //-1
            lstTitle.Add("");
            gridCVInfo.AddColumnHeaderList(lstTitle);
            gridCVInfo.ColumnHeadersVisible(true);

            lstTitle = new List<string>();
            lstTitle.Add("Power");
            lstTitle.Add("Mode");
            lstTitle.Add("Status");
            lstTitle.Add("Trouble ErrorNo");
            lstTitle.Add("Trouble ErrorLevel");

            lstTitle.Add("FMS Status");     // 5            
            lstTitle.Add("Trouble Status");
            lstTitle.Add("Trouble ErrorNo");
            lstTitle.Add("TimeSync");

            lstTitle.Add("Conveyor Information");   // 9
            lstTitle.Add("Conveyor No");
            lstTitle.Add("Conveyor Type");
            lstTitle.Add("Station Status");
            lstTitle.Add("Tray Exist");
            lstTitle.Add("Tray Type");
            lstTitle.Add("Tray Count");
            lstTitle.Add("Tray ID 1");
            lstTitle.Add("Tray ID 2");
            lstTitle.Add("Carriage Pos");

            lstTitle.Add("Conveyor Command");       // 19
            lstTitle.Add("Command Ready");
            lstTitle.Add("Destination");
            lstTitle.Add("Magazine Command");
            gridCVInfo.AddRowsHeaderList(lstTitle);

            gridCVInfo.ColumnHeadersHeight(24);
            gridCVInfo.RowsHeight(24);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstColumn.Add(5);
            lstColumn.Add(9);
            lstColumn.Add(19);
            lstTitle = new List<string>();
            lstTitle.Add("Equipment Status");
            lstTitle.Add("FMS Status");
            lstTitle.Add("Conveyor Information");
            lstTitle.Add("Conveyor Command");
            gridCVInfo.ColumnMergeList(lstColumn, lstTitle);

            gridCVInfo.SetGridViewStyles();
            gridCVInfo.ColumnHeadersWidth(0, 200);            
        }

        #region SetData
        public void SetData(List<DataValue> data)
        {
            ledPower.LedOnOff(true);
            ledControlMode.LedOnOff(true);

            ledIdle.LedStatus(0);
            ledRun.LedStatus(0);
            ledTrouble.LedStatus(0);

            ledIdle.LedStatus(1);

            ledTroubleStatus.LedOnOff(false);

            int idx = 1;
            for (int i = 0; i < gridCVInfo.RowCount; i++)
            {
                if (!gridCVInfo._CellMerge.Contains(i))
                {
                    object value;
                    bool status = false;

                    switch (idx)
                    {
                        case (int)enSiteTagList.Power:
                            value = (bool.Parse(data[(int)enSiteTagList.Power].Value.ToString()) == true ? 
                                "On" : "Off");
                            
                            break;

                        case (int)enSiteTagList.ConveyorType:
                            value = GetConveyorType(int.Parse(data[(int)enSiteTagList.ConveyorType].Value.ToString()));
                            break;

                        case (int)enSiteTagList.StationStatus:
                            value = GetStationStatus(int.Parse(data[(int)enSiteTagList.StationStatus].Value.ToString()));
                            break;

                        case (int)enSiteTagList.TrayExist:
                            value = (bool.Parse(data[(int)enSiteTagList.TrayExist].Value.ToString()) == true ?
                                "Exist" : "Not Exist");

                            status = bool.Parse(data[(int)enSiteTagList.TrayExist].Value.ToString());
                            ledPower.LedOnOff(status);
                            break;

                        case (int)enSiteTagList.TrayType:
                            value = GetTrayType(int.Parse(data[(int)enSiteTagList.TrayType].Value.ToString()));
                            break;

                        case (int)enSiteTagList.MagazineCommand:
                            value = GetMagazineCommand(int.Parse(data[(int)enSiteTagList.MagazineCommand].Value.ToString()));
                            break;

                        default:
                            value = data[idx].Value;
                            break;
                    }

                    gridCVInfo.SetValue(1, i, value);
                    idx++;
                }                
            }

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
    }
}
