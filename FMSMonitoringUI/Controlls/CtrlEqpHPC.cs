using FMSMonitoringUI.Monitoring;
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
        public override void SetData(List<_entire_eqp_list> data, Dictionary<string, KeyValuePair<string, Color>> eqpStatus)
        {
            try
            {
                foreach (var hpc in data)
                {
                    if (hpc.UNIT_ID == _unitD)
                    {
                        int row = 0;
                        TrayInfoView.SetValue(0, row, hpc.TRAY_ID, hpc.REWORK_TRAY_1);

                        SetEqpMode(hpc.EQP_MODE, eqpStatus[hpc.EQP_MODE]);
                        SetEqpStatus(hpc.EQP_STATUS, eqpStatus[hpc.EQP_STATUS]);
                    }
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("SetData Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
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
            form.Show();
        }
        #endregion

        #region lbEqpType_MouseDoubleClick
        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinFormationHPC form = new WinFormationHPC(lbEqpType.Text, EqpID, EqpType, UnitID);
            form.Show();
        }
        #endregion

        #region lbEqpType_MouseClick
        private void lbEqpType_MouseClick(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                WinTroubleInfo winTroubleInfo = new WinTroubleInfo(EqpName, _EqpType, "", _unitD);
                winTroubleInfo.Show();
            }
        }
        #endregion
    }
}
