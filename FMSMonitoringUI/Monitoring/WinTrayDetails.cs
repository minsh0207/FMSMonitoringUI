using MonitoringUI.Common;
using MonitoringUI.Controlls;
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
    public partial class WinTrayDetails : Form
    {
        private Point point = new Point();

        public WinTrayDetails()
        {
            InitializeComponent();

            InitGridView();
        }

        private void WinTrayDetails_Load(object sender, EventArgs e)
        {
            
            InitsplitContainer();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridTrayInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
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
            string[] columnName = { "No", "Location", "Tray ID", "Cell ID", "Start Operation", "End Operation",
                                    "Before Process End Operation", "Process Time", "Delay Time"};
            List<string> lstTitle = new List<string>();
            lstTitle = columnName.ToList();
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            gridTrayInfo.AddRowsHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersHeight(30);
            gridTrayInfo.RowsHeight(30);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Tray Information");
            //TrayInfoView.ColumnMergeList(lstColumn, lstTitle);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 60);            
        }

        #region SetData
        public void SetData(string trayid)
        {
            gridTrayInfo.SetValue(0, 0, "1");
            gridTrayInfo.SetValue(1, 0, "HT Aging");
            gridTrayInfo.SetValue(2, 0, trayid);
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
    }
}
