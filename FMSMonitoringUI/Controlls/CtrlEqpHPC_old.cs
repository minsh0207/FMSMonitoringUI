﻿using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlEqpHPC_old : UserControlEqp
    {
        public CtrlEqpHPC_old()
        {
            InitializeComponent();            
        }

        #region Properties
        string _EqpType = "";
        [DisplayName("EQP TYPE"), Description("EQP TYPE"), Category("GroupBox Setting")]
        public string EqpType
        {
            get
            {
                return _EqpType;
            }
            set
            {
                _EqpType = value;
                lbEqpType.Text = _EqpType;                
            }
        }
        #endregion

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("JIG #1");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("JIG #2");
            lstTitle.Add("");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(21);
            TrayInfoView.RowsHeight(20);

            TrayInfoView.SetGridViewStyles();

            //TrayInfoView.Rows.Add(new string[] { "" });
            //TrayInfoView.Rows.Add(new string[] { " JIG #2" });
            //TrayInfoView.Rows.Add(new string[] { "" });

            //TrayInfoView.EnableHeadersVisualStyles = false;
            //TrayInfoView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 27, 27);

            //TrayInfoView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //TrayInfoView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //for (int i = 0; i < TrayInfoView.ColumnCount; i++)
            //{
            //    TrayInfoView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    TrayInfoView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            //TrayInfoView.CurrentCell = null;
            //TrayInfoView.ClearSelection();
        }

        #region setData
        public override void SetData(List<_entire_eqp_list> data)
        {
            //int nLocation = int.Parse(row["Location"].ToString());

            //int nRow = (nLocation == 0 ? 0 : 2); 
            //TrayInfoView.SetValue(0, nRow, row["tray_id"].ToString());
            //TrayInfoView.SetReworkTray(0, nRow, row["rework_flag"].ToString());
        }

        public override void SetEqpStatus(string eqp_status, Color color)
        {
            lbEqpStatus.Text = eqp_status;
            lbEqpStatus.BackColor = color;
        }

        public void SetOperationStatus(string op_status, Color color)
        {
            lbOPStatus.Text = op_status;
            lbOPStatus.BackColor = color;
        }
        #endregion

        private void CtrlEqpControl_Load(object sender, EventArgs e)
        {
            InitGridView();
        }

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinManageEqp form = new WinManageEqp(EqpID, EqpType, 1);
            form.ShowDialog();
        }
    }
}
