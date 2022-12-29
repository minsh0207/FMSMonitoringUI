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
    public partial class WinCellDetailInfo : Form
    {
        private Point point = new Point();

        public WinCellDetailInfo()
        {
            InitializeComponent();

            InitGridViewCellList();
            InitGridViewCell();
            InitGridViewProcessName();
            InitGridViewRecipeInfo();
            InitGridViewProcessData();
        }

        private void WinCellDetailInfo_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridCellIDLIst.MouseCellDoubleClick_Evnet += GridCellIDLIst_MouseCellDoubleClick;
            gridCellInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion
        }

        #region InitGridView
        private void InitGridViewCellList()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("No");      // -1
            lstTitle.Add("Cell ID");
            gridCellIDLIst.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            for (int i = 1; i <= 30; i++)
            {
                lstTitle.Add(i.ToString());
            }
            lstTitle.Add("");
            gridCellIDLIst.AddRowsHeaderList(lstTitle);

            gridCellIDLIst.RowsHeight(26);

            gridCellIDLIst.SetGridViewStyles();
            gridCellIDLIst.ColumnHeadersWidth(0, 60);


        }
        private void InitGridViewCell()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Select Cell ID");      // -1
            lstTitle.Add("");
            gridCellInfo.AddColumnHeaderList(lstTitle);
            gridCellInfo.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Cell ID");

            // 현재 Tray 정보
            //lstTitle.Add("Cerrent Tray Info");          // 1
            lstTitle.Add("Tray ID");
            lstTitle.Add("Cell No");
            lstTitle.Add("Tray InputTime");
            lstTitle.Add("Tray InputEqpID");

            // 등급 판정 관련
            //lstTitle.Add("Cerrent Grade");              // 6
            lstTitle.Add("Grade Code");
            lstTitle.Add("Grade NG Type");
            lstTitle.Add("Grade Defect Type");
            lstTitle.Add("Grade EQP Type");
            lstTitle.Add("Grade Process Type");
            lstTitle.Add("Grade Process No");
            lstTitle.Add("Grade EQP ID");

            // Cell 정보
            //lstTitle.Add("Cerrent Cell Info");          // 14
            lstTitle.Add("Model ID");
            lstTitle.Add("Route ID");
            lstTitle.Add("Lot ID");

            // Cell의 현재 설비 정보
            //lstTitle.Add("Current EQP Info");       // 18
            lstTitle.Add("EQP ID");
            lstTitle.Add("UNIT ID");
            lstTitle.Add("UNITID LEVEL");

            // Cell의 현재 process 정보
            //lstTitle.Add("Current Process Info");   // 22
            lstTitle.Add("Recipe ID");
            lstTitle.Add("Route OrderNo");
            lstTitle.Add("EQP Type");
            lstTitle.Add("Process Type");
            lstTitle.Add("Process No");
            lstTitle.Add("Start Time");
            lstTitle.Add("End Time");

            // Rework 관련 정보
            //lstTitle.Add("Rework Info");            // 30
            lstTitle.Add("Rework Flag");
            lstTitle.Add("Rework Time");
            lstTitle.Add("Rework EQPID");
            lstTitle.Add("Rework UnitID");

            // 화재 관련
            //lstTitle.Add("Fire Info");              // 35
            lstTitle.Add("Fire Flag");
            lstTitle.Add("Fire Time");
            lstTitle.Add("Fire EQPID");
            lstTitle.Add("Fire UnitID");

            // Scrap 관련
            //lstTitle.Add("Scrap Info");             // 40
            lstTitle.Add("Scrap Flag");
            lstTitle.Add("Scrap User");
            lstTitle.Add("Scrap Time");
            lstTitle.Add("");
            gridCellInfo.AddRowsHeaderList(lstTitle);

            gridCellInfo.RowsHeight(26);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Clear();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstColumn.Add(1);
            //lstColumn.Add(6);
            //lstColumn.Add(14);
            //lstColumn.Add(18);
            //lstColumn.Add(22);
            //lstColumn.Add(30);
            //lstColumn.Add(35);
            //lstColumn.Add(40);
            //lstTitle = new List<string>();
            //lstTitle.Clear();
            //lstTitle.Add("Select Cell ID");
            //lstTitle.Add("Cerrent Tray Info");
            //lstTitle.Add("Cerrent Grade Info");
            //lstTitle.Add("Cerrent Cell Info");
            //lstTitle.Add("Current EQP Info");
            //lstTitle.Add("Current Process Info");
            //lstTitle.Add("Rework Info");
            //lstTitle.Add("Fire Info");
            //lstTitle.Add("Scrap Info");
            //gridCellInfo.ColumnMergeList(lstColumn, lstTitle);

            gridCellInfo.SetGridViewStyles();
            gridCellInfo.ColumnHeadersWidth(0, 160);

            
        }
        private void InitGridViewProcessName()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("No");      // -1
            lstTitle.Add("Process Name");
            gridProcessName.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("1");
            lstTitle.Add("2");
            lstTitle.Add("3");
            lstTitle.Add("");
            gridProcessName.AddRowsHeaderList(lstTitle);

            gridProcessName.RowsHeight(26);

            gridProcessName.SetGridViewStyles();
            gridProcessName.ColumnHeadersWidth(0, 60);


        }
        private void InitGridViewRecipeInfo()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Name");      // -1
            lstTitle.Add("Value");
            gridRecipeInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            gridRecipeInfo.AddRowsHeaderList(lstTitle);

            gridRecipeInfo.RowsHeight(26);

            gridRecipeInfo.SetGridViewStyles();
            //gridRecipeInfo.ColumnHeadersWidth(0, 140);
        }
        private void InitGridViewProcessData()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Name");      // -1
            lstTitle.Add("Value");
            gridProcessData.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            gridProcessData.AddRowsHeaderList(lstTitle);

            gridProcessData.RowsHeight(26);

            gridProcessData.SetGridViewStyles();
            //gridProcessData.ColumnHeadersWidth(0, 140);
        }
        #endregion

        #region SetData
        public void SetData()
        {
            for (int i = 0; i < 30; i++)
            {
                string cellid = string.Format("133NMCVC222001A00{0:D2}", i + 1)
;                gridCellIDLIst.SetValue(1, i, cellid);
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
        private void GridCellIDLIst_MouseCellDoubleClick(int col, int row, object value)
        {
            for (int i = 0; i < 30; i++)
            {
                gridCellIDLIst.SetStyleBackColor(col, i, Color.FromArgb(27,27,27));
                gridCellIDLIst.SetStyleForeColor(col, i, Color.White);
            }

            if (col == 1 && row > -1)
            {
                gridCellIDLIst.SetStyleBackColor(col, row, Color.LightBlue);
                gridCellIDLIst.SetStyleForeColor(col, row, Color.Black);

                gridCellInfo.SetValue(1, 0, value.ToString());

                //gridProcessName.SetValue(1, 0, "Assembly");
                gridProcessName.SetValue(1, 0, "LT Aging #1");
                gridProcessName.SetValue(1, 1, "OCV/ACIR");
                gridProcessName.SetValue(1, 2, "NG Sorter #1");
            }
        }
        private void GridCellInfo_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 1 && row > -1)
            {
                MessageBox.Show($"TrayInfoView DoubleClick CellID = {value}");
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
