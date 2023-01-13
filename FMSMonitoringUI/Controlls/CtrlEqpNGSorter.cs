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
    public partial class CtrlEqpNGSorter : UserControlEqp
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

        public CtrlEqpNGSorter()
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
            lstTitle.Add("Location");
            lstTitle.Add("Tray ID");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Pick");
            lstTitle.Add("Place");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(26);
            TrayInfoView.RowsHeight(25);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 60);
        }
        #endregion

        #region setData
        public override void SetData(List<_entire_eqp_list> data, Dictionary<string, Color> eqpStatus)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (i > 1) break;

                int row = Convert.ToInt16(data[i].LEVEL);
                TrayInfoView.SetValue(1, row, data[i].TRAY_ID);
                TrayInfoView.SetReworkTray(1, row, data[i].REWORK_FLAG);
            }

            SetEqpMode(data[0].EQP_MODE, eqpStatus[data[0].EQP_MODE]);
            SetEqpStatus(data[0].EQP_STATUS, eqpStatus[data[0].EQP_STATUS]);
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
            WinManageEqp form = new WinManageEqp(EqpID, "", EqpType, 2);
            form.ShowDialog();
        }
    }
}
