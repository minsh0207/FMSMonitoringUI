using MonitoringUI.Common;
using MonitoringUI.Controlls;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinWaterTank : Form
    {
        private Point point = new Point();

        public WinWaterTank()
        {
            InitializeComponent();

            InitGridView();
        }

        private void WinWaterTank_Load(object sender, EventArgs e)
        {
            
            InitsplitContainer();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridWaterTank.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion
        }

        private void InitsplitContainer()
        {
            //splitContainer1.BackColor = Color.LightGray;            // Color.FromArgb(53, 53, 53);
            //splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            //splitContainer2.Panel2.BackColor = Color.LightGray;     //Color.FromArgb(53, 53, 53);
            //splitContainer2.BorderStyle = BorderStyle.FixedSingle;

            //splitContainer3.BorderStyle = BorderStyle.FixedSingle;
            //splitContainer3.Panel2.BackColor = Color.FromArgb(27, 27, 27);
        }

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

            gridWaterTank.ColumnHeadersHeight(24);
            gridWaterTank.RowsHeight(24);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>();
            lstTitle.Add("Previous Position");
            gridWaterTank.ColumnMergeList(lstColumn, lstTitle);

            gridWaterTank.SetGridViewStyles();
            gridWaterTank.ColumnHeadersWidth(0, 100);            
        }

        #region SetData
        public void SetData(SiteTagInfo siteInfo)
        {
            //gridWaterTank.SetValue(1, 0, siteInfo.ConveyorNo);
            //gridWaterTank.SetValue(1, 1, GetConveyorType(siteInfo.ConveyorType));
            //gridWaterTank.SetValue(1, 2, siteInfo.TrayIdL1);
            //gridWaterTank.SetValue(1, 3, siteInfo.TrayIdL2);
            //gridWaterTank.SetValue(1, 4, (siteInfo.TrayExist == true ? "Exist" : "Not Exist"));
            //gridWaterTank.SetValue(1, 5, siteInfo.TrayCount);
            //gridWaterTank.SetValue(1, 6, GetTrayType(siteInfo.TrayType));
            //gridWaterTank.SetValue(1, 7, GetStationStatus(siteInfo.StationStatus));
            //gridWaterTank.SetValue(1, 8, siteInfo.Destination);
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

                WinCellDetailInfo form = new WinCellDetailInfo();
                form.SetData();
                form.ShowDialog();

                Refresh();
            }
        }
        #endregion

        #region Button Event
        private void ctrlButtonExit1_Click(object sender, EventArgs e)
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
