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
using System.Windows.Forms.DataVisualization.Charting;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlEqpHPC : UserControlEqp
    {
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
            }
        }
        string _unitD = "";
        [DisplayName("Unit ID"), Description("Unit ID"), Category("GroupBox Setting")]
        public string UnitID
        {
            get
            {
                return _unitD;
            }
            set
            {
                _unitD = value;
            }
        }
        string _TitleText = "";
        [DisplayName("Title Text"), Description("EQP Title"), Category("GroupBox Setting")]
        public string TitleText
        {
            get
            {
                return _TitleText;
            }
            set
            {
                _TitleText = value;
                lbEqpType.Text = string.Format($" {_TitleText}");
            }
        }
        #endregion

        public CtrlEqpHPC()
        {
            InitializeComponent();            
        }

        #region CtrlEqpControl_Load
        private void CtrlEqpControl_Load(object sender, EventArgs e)
        {
            InitGridView();
        }
        #endregion

        #region InitGridView
        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("JIG ID");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(25);
            TrayInfoView.RowsHeight(25);

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
        #endregion

        #region setData
        public override void SetData(List<_entire_eqp_list> data, Dictionary<string, Color> eqpStatus)
        {
            foreach (var hpc in data)
            {
                if (hpc.UNIT_ID == _unitD)
                {
                    int row = 0;
                    TrayInfoView.SetValue(0, row, hpc.TRAY_ID);
                    TrayInfoView.SetReworkTray(0, row, hpc.REWORK_FLAG);

                    SetEqpMode(hpc.EQP_MODE, eqpStatus[hpc.EQP_MODE]);
                    SetEqpStatus(hpc.EQP_STATUS, eqpStatus[hpc.EQP_STATUS]);
                }
            }
        }
        private void SetEqpMode(string eqp_mode, Color color)
        {
            lbEqpMode.Text = eqp_mode;
            lbEqpMode.BackColor = color;
        }

        private void SetEqpStatus(string eqp_status, Color color)
        {
            lbEqpStatus.Text = GetEqpStatusText(eqp_status);
            lbEqpStatus.BackColor = color;
        }
        #endregion

        #region GetEqpStatusText
        private string GetEqpStatusText(string eqp_status)
        {
            string statusText;

            switch (eqp_status)
            {
                case "I":
                    statusText = "Idle";
                    break;
                case "R":
                    statusText = "Running";
                    break;
                case "T":
                    statusText = "Trouble";
                    break;
                case "P":
                    statusText = "Pause";
                    break;
                case "S":
                    statusText = "Stop";
                    break;
                case "L":
                    statusText = "Loading";
                    break;
                case "F":
                    statusText = "Fire";
                    break;
                case "F2":
                    statusText = "Fire2";
                    break;
                default:
                    statusText = "None";
                    break;
            }

            return statusText;
        }
        #endregion

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinManageEqp form = new WinManageEqp(EqpID, UnitID, EqpType, 1);
            form.ShowDialog();
        }
    }
}
