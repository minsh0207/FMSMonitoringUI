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
    public partial class WinTrayInfo : Form
    {
        private Point point = new Point();

        public WinTrayInfo()
        {
            InitializeComponent();

            InitGridViewTray();
            InitGridViewProcessFlow();
        }

        private void WinTrayInfo_Load(object sender, EventArgs e)
        {            
            InitsplitContainer();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridProcessFlow.MouseCellClick_Evnet += GridProcessFlow_MouseCellClick;
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

        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Model");
            lstTitle.Add("Tray ID");
            lstTitle.Add("Binding Time");
            lstTitle.Add("Route ID");
            lstTitle.Add("Lot ID");
            lstTitle.Add("Current Process");
            lstTitle.Add("Current Equipment");
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Cell Count");
            lstTitle.Add("Tray Type");

            gridTrayInfo.AddRowsHeaderList(lstTitle);

            //TrayInfoView.ColumnHeadersHeight(30);
            gridTrayInfo.RowsHeight(30);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Tray Information");
            //TrayInfoView.ColumnMergeList(lstColumn, lstTitle);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 140);
        }

        private void InitGridViewProcessFlow()
        {
            string[] columnName = { "No", "Process Name", "Equipment Name", 
                                    "Start Time", "End Time", "Cell Count", "Recipe" };
            List<string> lstTitle = new List<string>();
            lstTitle = columnName.ToList();
            gridProcessFlow.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            gridProcessFlow.AddRowsHeaderList(lstTitle);

            gridProcessFlow.ColumnHeadersHeight(24);
            gridProcessFlow.RowsHeight(24);

            gridProcessFlow.SetGridViewStyles();
            gridProcessFlow.ColumnHeadersWidth(0, 50);

            // Cell에 Button 추가
            gridProcessFlow.SetStyleButton(columnName.Length - 1, 0, "Click");            
        }

        public void SetData(string trayid)
        {
            gridTrayInfo.SetValue(1, 1, trayid);
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
        private void GridProcessFlow_MouseCellClick(int col, int row, object value)
        {
            if (col == gridProcessFlow.ColumnCount -1 && row > -1)
            {
                WinCellDetailInfo form = new WinCellDetailInfo();
                form.SetData();
                form.ShowDialog();
            }
        }
        #endregion

        private void ctrlButton1_Click(object sender, EventArgs e)
        {
            WinCellDetailInfo form = new WinCellDetailInfo();
            form.SetData();
            form.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
