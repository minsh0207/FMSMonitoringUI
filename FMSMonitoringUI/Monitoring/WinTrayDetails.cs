using MonitoringUI;
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
    public partial class WinTrayDetails : WinFormRoot
    {
        private Point point = new Point();

        public WinTrayDetails()
        {
            InitializeComponent();

            InitGridView();
        }

        private void WinTrayDetails_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Text) == false)
            {
                Exit_Click(null, null);
                return;
            }

            InitControl();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridTrayInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion

            this.WindowID = CAuthority.GetWindowsText(this.Text);
        }

        #region InitControl
        private void InitControl()
        {
            int btnPos = (this.Width - CDefine.DEF_EXIT_WIDTH) / 2;   // Button Width Size 170            
            this.Exit.Padding = new System.Windows.Forms.Padding(btnPos, 10, btnPos, 10);
        }
        #endregion

        #region InitGridView
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
        #endregion

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

                //WinCellDetailInfo form = new WinCellDetailInfo(value.ToString());
                //form.SetData();
                //form.ShowDialog();

                //Refresh();
            }
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
