﻿using MonitoringUI.Common;
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
    public partial class WinCellInfo : Form
    {
        private Point point = new Point();

        public WinCellInfo()
        {
            InitializeComponent();

            InitGridView();
        }

        private void WinCellInfo_Load(object sender, EventArgs e)
        {
            
            InitsplitContainer();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridCellInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
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
            lstTitle.Add("Cell No");
            lstTitle.Add("Cell ID");
            lstTitle.Add("Start Time");
            lstTitle.Add("End Time");
            lstTitle.Add("EQP Name");
            lstTitle.Add("UNIT Name");
            lstTitle.Add("NG CODE");
            gridCellInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            gridCellInfo.AddRowsHeaderList(lstTitle);

            gridCellInfo.ColumnHeadersHeight(30);
            gridCellInfo.RowsHeight(30);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Tray Information");
            //TrayInfoView.ColumnMergeList(lstColumn, lstTitle);

            gridCellInfo.SetGridViewStyles();
            gridCellInfo.ColumnHeadersWidth(0, 60);            
        }

        #region SetData
        public void SetData()
        {
            gridCellInfo.SetValue(0, 0, "1");
            gridCellInfo.SetValue(1, 0, "133NMCVC222001A0002");
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

                WinCellDetailInfo form = new WinCellDetailInfo(value.ToString());
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
