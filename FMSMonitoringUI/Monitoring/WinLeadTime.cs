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
using System.Windows.Forms.DataVisualization.Charting;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinLeadTime : Form
    {
        private Point point = new Point();

        public WinLeadTime()
        {
            InitializeComponent();

            InitGridViewTray();
            InitChart();
        }

        private void WinLeadTime_Load(object sender, EventArgs e)
        {            
            InitsplitContainer();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridTrayInfo.MouseCellDoubleClick_Evnet += GridTrayInfo_MouseCellDoubleClick;
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

        private void InitChart()
        {
            chart1.Series[0].Points.Add(80);
            chart1.Series[0].Points.Add(50);
            chart1.Series[0].Points.Add(90);
            chart1.Series[0].Points.Add(40);
            chart1.Series[0].Points.Add(70);
            chart1.Series[0].Points.Add(60);
            chart1.Series[0].Points.Add(70);
            chart1.Series[0].Points.Add(80);
        }

        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("No");
            lstTitle.Add("Location");
            lstTitle.Add("Tray ID");
            lstTitle.Add("Start Operation");
            lstTitle.Add("Plan Operation");
            lstTitle.Add("Process Time");
            lstTitle.Add("Specs (MES)");
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

        public void SetData(string rackid)
        {
            gridTrayInfo.SetValue(0, 0, "1");
            gridTrayInfo.SetValue(1, 0, rackid);
            gridTrayInfo.SetValue(2, 0, "TRV000001");
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
        private void GridTrayInfo_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 2 && row > -1)
            {
                WinTrayDetails form = new WinTrayDetails();
                form.SetData(value.ToString());
                form.ShowDialog();
            }
        }
        #endregion

        #region Button Click
        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
