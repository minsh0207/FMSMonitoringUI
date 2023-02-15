using FMSMonitoringUI.Monitoring;
using MonitoringUI;
using MonitoringUI.Common;
using MySqlX.XDevAPI.Relational;
using OPCUAClientClassLib;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlHPC : UserControlEqp
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
        string _LanguageID = "";
        [DisplayName("LocalLanguage"), Description("Local Language"), Category("Language Setting")]
        public string LanguageID
        {
            get
            {
                return _LanguageID;
            }
            set
            {
                _LanguageID = value;
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

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Tray_ID"),
                LocalLanguage.GetItemString("DEF_Control_Mode").Replace(" :", ""),
                LocalLanguage.GetItemString("DEF_Status").Replace(" :", ""),
                LocalLanguage.GetItemString("DEF_Operation_Mode"),
                LocalLanguage.GetItemString("DEF_Current_Process"),
                LocalLanguage.GetItemString("DEF_Start_Time"),
                LocalLanguage.GetItemString("DEF_Plan_Time"),
                LocalLanguage.GetItemString("DEF_Avg_Temp"),
                LocalLanguage.GetItemString("DEF_Pressure"),
                LocalLanguage.GetItemString("DEF_Trouble_Code"),
                LocalLanguage.GetItemString("DEF_Trouble_Name")
            };
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(30);
            TrayInfoView.RowsHeight(30);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 140);
        }
        #endregion

        #region setData
        public void SetData(_ctrl_formation_hpc data, Color eqpStatusColor, Color opModeColor)
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
            string troubleName = (CDefine.m_enLanguage == enLoginLanguage.English ? data.TROUBLE_NAME : data.TROUBLE_NAME_LOCAL);
            TrayInfoView.SetValue(1, nRow, troubleName);

            TrayInfoView.SetReworkTray(1, 0, data.REWORK_FLAG);

            SetEqpStatus(data.EQP_STATUS, eqpStatusColor);

            if (data.EQP_STATUS == "R")
                SetOperationMode(data.OPERATION_MODE, opModeColor);
            else
                SetOperationMode(data.EQP_STATUS, eqpStatusColor);
        }

        public void SetEqpStatus(string eqp_status, Color color)
        {
            lbEqpStatus.Text = eqp_status;
            lbEqpStatus.BackColor = color;
        }

        /// <summary>
        /// 설비 상태가 Run이 아닌경우 장비 상태를 표시해준다.
        /// </summary>
        public void SetOperationMode(string eqp_status, Color color)
        {
            lbOPMode.Text = GetEqpStatus(eqp_status, false);
            lbOPMode.BackColor = color;
        }
        /// <summary>
        /// 설비 상태가 Run일 경우 Operation Mode 상태를 표시해준다.
        /// </summary>
        public void SetOperationMode(int op_mode, Color color)
        {
            lbOPMode.Text = GetOperationMode(op_mode, false);
            lbOPMode.BackColor = color;
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

        #region lbEqpType_MouseDoubleClick
        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinFormationHPC form = new WinFormationHPC(lbRackID.Text, EqpID, EqpType, UnitID);            
            form.Show();
        }
        #endregion

        #region GetOperationMode 
        private string GetOperationMode(int mode, bool fullString = true)
        {
            string opModeName = string.Empty;

            switch (mode)
            {
                case 1:
                    opModeName = LocalLanguage.GetItemString("DEF_OCV");
                    break;
                case 2:
                    if (fullString)
                        opModeName = LocalLanguage.GetItemString("DEF_Charge") + " (CC)";
                    else
                        opModeName = LocalLanguage.GetItemString("DEF_Charge");
                    break;
                case 4:
                    if (fullString)
                        opModeName = LocalLanguage.GetItemString("DEF_Charge") + " (CCCV)";
                    else
                        opModeName = LocalLanguage.GetItemString("DEF_Charge");
                    break;
                case 8:
                    if (fullString)
                        opModeName = LocalLanguage.GetItemString("DEF_Discharge") + " (CC)";
                    else
                        opModeName = LocalLanguage.GetItemString("DEF_Discharge");
                    break;
                case 16:
                    if (fullString)
                        opModeName = LocalLanguage.GetItemString("DEF_Discharge") + " (CCCV)";
                    else
                        opModeName = LocalLanguage.GetItemString("DEF_Discharge");
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
                    statusName = LocalLanguage.GetItemString("DEF_Control_Mode").Replace(" :", "");
                    break;
                case "M":
                    statusName = LocalLanguage.GetItemString("DEF_Maintenance_Mode");
                    break;
                case "I":
                    statusName = LocalLanguage.GetItemString("DEF_Idle");
                    break;
                case "R":
                    statusName = LocalLanguage.GetItemString("DEF_Running");
                    break;
                case "T":
                    statusName = LocalLanguage.GetItemString("DEF_Machine_Trouble");
                    break;
                case "P":
                    statusName = LocalLanguage.GetItemString("DEF_Pause");
                    break;
                case "S":
                    statusName = LocalLanguage.GetItemString("DEF_Stop");
                    break;
                case "L":
                    statusName = LocalLanguage.GetItemString("DEF_Loading");
                    break;
                case "F":
                    if (fullString)
                        statusName = $"{LocalLanguage.GetItemString("DEF_Fire")}\r\n{LocalLanguage.GetItemString("DEF_Temperature_Alarm_Only")}";
                    else
                        statusName = LocalLanguage.GetItemString("DEF_Fire");
                    break;
                case "F2":
                    if (fullString)
                        statusName = $"{LocalLanguage.GetItemString("DEF_Fire2")}\r\n{LocalLanguage.GetItemString("DEF_Smoke_Only_or_Both")}";
                    else
                        statusName = LocalLanguage.GetItemString("DEF_Fire2");
                    break;
            }

            return statusName;
        }
        #endregion

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                lbRackID.Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
        #endregion

        #region lbEqpType_MouseClick
        private void lbEqpType_MouseClick(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                WinTroubleInfo winTroubleInfo = new WinTroubleInfo(EqpName, _EqpType, "", _unitD);
                winTroubleInfo.ShowDialog();
            }
        }
        #endregion
    }
}
