using FMSMonitoringUI.Monitoring;
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
    public partial class CtrlEqpMicroCurrent : UserControlEqp
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
                lbEqpType.Text = string.Format($" {_EqpType}");
            }
        }
        #endregion

        public CtrlEqpMicroCurrent()
        {
            InitializeComponent();

            TrayInfoView.MouseCellDoubleClick_Evnet += TrayInfoView_MouseCellDoubleClick;
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
            lstTitle.Add("Tray ID");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(22);
            TrayInfoView.RowsHeight(21);

            TrayInfoView.SetGridViewStyles();
        }
        #endregion

        #region setData
        public override void SetData(List<_entire_eqp_list> data, Dictionary<string, KeyValuePair<string, Color>> eqpStatus)
        {
            int row = Convert.ToInt16(data[0].LEVEL);
            TrayInfoView.SetValue(0, row, data[0].TRAY_ID);
            TrayInfoView.SetReworkTray(0, row, data[0].REWORK_FLAG);

            SetEqpMode(data[0].EQP_MODE, eqpStatus[data[0].EQP_MODE]);
            SetEqpStatus(data[0].EQP_STATUS, eqpStatus[data[0].EQP_STATUS]);
        }
        private void SetEqpMode(string eqp_mode, KeyValuePair<string, Color> valuePair)
        {
            lbEqpMode.Text = eqp_mode;
            lbEqpMode.BackColor = valuePair.Value;
        }

        private void SetEqpStatus(string eqp_status, KeyValuePair<string, Color> valuePair)
        {
            lbEqpStatus.Text = valuePair.Key;   // GetEqpStatusText(eqp_status);
            lbEqpStatus.BackColor = valuePair.Value;
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

        #region DataGridView Event
        private void TrayInfoView_MouseCellDoubleClick(int col, int row, object value)
        {
            WinTrayInfo form = new WinTrayInfo(EqpID, "", value.ToString());
            form.ShowDialog();
        }
        #endregion

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinManageEqp form = new WinManageEqp(EqpID, "", EqpType, 1);
            form.ShowDialog();
        }
    }
}
