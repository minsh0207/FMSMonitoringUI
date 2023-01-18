﻿using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
using MySqlX.XDevAPI.Relational;
using OPCUAClientClassLib;
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
    public partial class CtrlHPC : UserControlEqp
    {
        #region Properties
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
        string _textBoxText = "";
        [DisplayName("TextBoxText"), Description("TextBox Text"), Category("GroupBox Setting")]
        public string TextBoxText
        {
            get
            {
                return _textBoxText;
            }
            set
            {
                _textBoxText = value;
                lbRackID.Text = string.Format(" {0}", _textBoxText);
            }
        }
        #endregion

        public CtrlHPC()
        {
            InitializeComponent();

            TrayInfoView.MouseCellDoubleClick_Evnet += TrayInfoView_MouseCellDoubleClick;
        }

        #region CtrlHPC Event
        private void CtrlHPC_Load(object sender, EventArgs e)
        {
            InitGridView();
        }
        #endregion

        #region InitGridView
        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            TrayInfoView.AddColumnHeaderList(lstTitle);
            TrayInfoView.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Tray ID");
            lstTitle.Add("Control Mode");
            lstTitle.Add("Status");
            lstTitle.Add("Operation Mode");
            lstTitle.Add("Current Process");
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Avg Temp");
            lstTitle.Add("Pressure");
            lstTitle.Add("Trouble Code");
            lstTitle.Add("Trouble Name");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(30);
            TrayInfoView.RowsHeight(30);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 140);
        }
        #endregion

        #region setData
        public void SetData(_ctrl_formation_hpc data, Color eqpStatus, Color operationMode)
        {
            int nRow = 0;
            TrayInfoView.SetValue(1, nRow, data.TRAY_ID); nRow++;
            TrayInfoView.SetValue(1, nRow, GetEqpStatus(data.EQP_MODE)); nRow++;
            TrayInfoView.SetValue(1, nRow, GetEqpStatus(data.EQP_STATUS)); nRow++;
            TrayInfoView.SetValue(1, nRow, GetOperationMode(data.OPERATION_MODE)); nRow++;
            TrayInfoView.SetValue(1, nRow, data.PROCESS_NAME); nRow++;
            TrayInfoView.SetValue(1, nRow, data.START_TIME.Year == 1 ? "" : data.START_TIME.ToString()); nRow++;
            TrayInfoView.SetValue(1, nRow, data.PLAN_TIME.Year == 1 ? "" : data.PLAN_TIME.ToString()); nRow++;
            TrayInfoView.SetValue(1, nRow, data.JIG_AVG); nRow++;
            TrayInfoView.SetValue(1, nRow, data.PRESSURE); nRow++;
            TrayInfoView.SetValue(1, nRow, data.TROUBLE_CODE); nRow++;
            TrayInfoView.SetValue(1, nRow, data.TROUBLE_NAME);

            SetEqpStatus(data.EQP_STATUS, eqpStatus);

            if (data.EQP_STATUS == "R")
                SetOperationMode(data.OPERATION_MODE, operationMode);
            else
                SetOperationMode(data.EQP_STATUS, eqpStatus);
        }

        public void SetEqpStatus(string eqp_status, Color color)
        {
            lbEqpStatus.Text = eqp_status;
            lbEqpStatus.BackColor = color;
        }

        public void SetOperationMode(string eqp_status, Color color)
        {
            lbOPStatus.Text = GetEqpStatus(eqp_status, false);
            lbOPStatus.BackColor = color;
        }
        public void SetOperationMode(int op_status, Color color)
        {
            lbOPStatus.Text = GetOperationMode(op_status);
            lbOPStatus.BackColor = color;
        }
        #endregion

        #region DataGridView Event
        private void TrayInfoView_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 1 && row == 0)
            {
                WinTrayInfo form = new WinTrayInfo(EqpID, "", value.ToString());
                form.ShowDialog();
            }
        }
        #endregion

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinFormationHPC form = new WinFormationHPC(lbRackID.Text, UnitID);            
            form.Show();
        }

        #region GetOperationMode 
        private string GetOperationMode(int mode)
        {
            string opModeName = string.Empty;

            switch (mode)
            {
                case 1:
                    opModeName = "OCV";
                    break;
                case 2:
                    opModeName = "Charge (CC)";
                    break;
                case 4:
                    opModeName = "Charge (CCCV)";
                    break;
                case 8:
                    opModeName = "Discharge (CC)";
                    break;
                case 16:
                    opModeName = "Discharge (CCCV)";
                    break;
            }

            return opModeName;
        }
        #endregion

        #region GetEqpStatus
        private string GetEqpStatus(string status, bool fullString=true)
        {
            string statusName = string.Empty;

            switch (status)
            {
                case "C":
                    statusName = "Control Mode";
                    break;
                case "M":
                    statusName = "Maintenance Mode";
                    break;
                case "I":
                    statusName = "Idle";
                    break;
                case "R":
                    statusName = "Running";
                    break;
                case "T":
                    statusName = "Machine Trouble";
                    break;
                case "P":
                    statusName = "Pause";
                    break;
                case "S":
                    statusName = "Stop";
                    break;
                case "L":
                    statusName = "Loading";
                    break;
                case "F":
                    if (fullString)
                        statusName = string.Format($"Fire\r\n(Temperature Alarm Only)");
                    else
                        statusName = "Fire";                    
                    break;
                case "F2":
                    if (fullString)
                        statusName = string.Format($"Fire\r\n(Smoke Only or Both)");
                    else
                        statusName = "Fire2";
                    break;
            }

            return statusName;
        }
        #endregion
    }
}
