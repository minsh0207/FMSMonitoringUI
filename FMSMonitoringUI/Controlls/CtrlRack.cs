using FMSMonitoringUI.Monitoring;
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
    public partial class CtrlRack : UserControlEqp
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
                lbRackID.Text = string.Format(" Rack ID : {0}", _textBoxText);
            }
        }
        #endregion

        public CtrlRack()
        {
            InitializeComponent();
        }

        #region CtrlRack Event
        private void CtrlRack_Load(object sender, EventArgs e)
        {
            InitGridView();

            TrayInfoView.MouseCellDoubleClick_Evnet += TrayInfoView_MouseCellDoubleClick;
        }        
        #endregion

        #region InitGridView
        private void InitGridView()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Level"),
                LocalLanguage.GetItemString("DEF_Tray_ID"),
                LocalLanguage.GetItemString("DEF_Lot_ID"),
                ""
            };

            TrayInfoView.AddColumnHeaderList(lstTitle);
            TrayInfoView.ColumnHeadersVisible(false);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Level"),
                "1",
                "2"
            };
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(25);
            TrayInfoView.RowsHeight(25);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 50);
            TrayInfoView.ColumnWidth(1, 120);
            TrayInfoView.ColumnWidth(2, 100);

            TrayInfoView.SetTitle(1, 0, LocalLanguage.GetItemString("DEF_Tray_ID"));
            TrayInfoView.SetTitle(2, 0, LocalLanguage.GetItemString("DEF_Avg_Temp"));
            TrayInfoView.SetTitle(2, 1, LocalLanguage.GetItemString("DEF_Start_Time"));
            TrayInfoView.SetTitle(2, 2, LocalLanguage.GetItemString("DEF_Plan_Time"));

            //TrayInfoView.SetTitle(0, 0, "1");
            //TrayInfoView.SetTitle(0, 1, "2");
        }
        #endregion

        #region setData
        public void SetData(_ctrl_formation_chg data, Color processStatus, Color operationMode)
        {
            TrayInfoView.SetValue(1, 1, data.TRAY_ID, data.REWORK_TRAY_1);
            TrayInfoView.SetValue(1, 2, data.TRAY_ID_2, data.REWORK_TRAY_2);
            TrayInfoView.SetValue(3, 0, data.JIG_AVG);

            string time = data.START_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            TrayInfoView.SetValue(3, 1, data.START_TIME.Year == 1 ? "" : time);
            time = data.PLAN_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            TrayInfoView.SetValue(3, 2, data.PLAN_TIME.Year == 1 ? "" : time);

            SetProcessStatus(data.PROCESS_STATUS, processStatus);

            if (data.PROCESS_STATUS == "R")
                SetOperationMode(data.OPERATION_MODE, operationMode);
            else
                SetOperationMode(data.PROCESS_STATUS, processStatus);
        }

        public void SetProcessStatus(string eqp_status, Color color)
        {
            lbEqpStatus.Text = eqp_status;
            lbEqpStatus.BackColor = color;
        }

        public void SetOperationMode(string eqp_status, Color color)
        {
            lbOPStatus.Text = GetProcessStatus(eqp_status);
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
            if (col == 1 && row > 0)
            {
                WinTrayInfo form = new WinTrayInfo(EqpID, "", value.ToString());
                form.ShowDialog();
            }
        }
        #endregion

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinFormationBox form = new WinFormationBox(EqpID, EqpType, UnitID);
            form.ShowDialog();
        }

        #region GetOperationMode 
        private string GetOperationMode(int mode)
        {
            string opModeName = string.Empty;

            switch (mode)
            {
                case 0:
                    opModeName = LocalLanguage.GetItemString("DEF_Data_Error");
                    break;
                case 1:
                    opModeName = LocalLanguage.GetItemString("DEF_OCV");
                    break;
                case 2:
                    opModeName = LocalLanguage.GetItemString("DEF_Charge") + " (CC)";
                    break;
                case 4:
                    opModeName = LocalLanguage.GetItemString("DEF_Charge") + " (CCCV)";
                    break;
                case 8:
                    opModeName = LocalLanguage.GetItemString("DEF_Discharge") + " (CC)";
                    break;
                case 16:
                    opModeName = LocalLanguage.GetItemString("DEF_Discharge") + " (CCCV)";
                    break;
            }

            return opModeName;
        }
        #endregion

        #region GetProcessStatus
        private string GetProcessStatus(string status)
        {
            string statusName = string.Empty;

            switch (status)
            {
                case "I":
                    statusName = LocalLanguage.GetItemString("DEF_Idle");
                    break;
                case "L":
                    statusName = LocalLanguage.GetItemString("DEF_Load_Request");
                    break;
                case "1":
                    statusName = LocalLanguage.GetItemString("DEF_Loading");
                    break;
                case "A":
                    statusName = LocalLanguage.GetItemString("DEF_Tray_Arrived");
                    break;
                case "R":
                    statusName = LocalLanguage.GetItemString("DEF_Running");
                    break;
                case "E":
                    statusName = LocalLanguage.GetItemString("DEF_ProcessEnd");
                    break;
                case "U":
                    statusName = LocalLanguage.GetItemString("DEF_Unload_Request");
                    break;
                case "2":
                    statusName = LocalLanguage.GetItemString("DEF_Unloading");
                    break;
                case "P":
                    statusName = LocalLanguage.GetItemString("DEF_Pause");
                    break;
                case "S":
                    statusName = LocalLanguage.GetItemString("DEF_Stop");
                    break;
                case "T":
                    statusName = LocalLanguage.GetItemString("DEF_Trouble");
                    break;
                case "F":
                    statusName = LocalLanguage.GetItemString("DEF_Fire");
                    break;
                case "X":
                    statusName = LocalLanguage.GetItemString("DEF_Not_Use");
                    break;
                case "":
                    statusName = LocalLanguage.GetItemString("DEF_Unload_Complete");
                    break;
            }

            return statusName;
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
