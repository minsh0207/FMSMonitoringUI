using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
using MonitoringUI;
using MonitoringUI.Common;
using MySqlX.XDevAPI.Relational;
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
    public partial class CtrlEqpCharger : UserControlEqp
    {
        public delegate void EventHandler(string eqpId, string eqpType, int eqpLevel);
        public event EventHandler Click_Evnet = null;

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
                lbTitle.Text = string.Format($" {_EqpType}");
            }
        }
        #endregion

        public List<string> UnitID { get; set; }

        private Label[,] _chgEqpStatus;
        private Label[,] _chgEqpMode;

        public CtrlEqpCharger()
        {
            InitializeComponent();

            btnLeadTime.Click += CtrlButton1_Click;
        }

        #region CtrlEqpCharger_Load
        private void CtrlEqpCharger_Load(object sender, EventArgs e)
        {
            InitControl();
            InitLanguage();
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            _chgEqpStatus = new Label[uiTlbEqpStatus.ColumnCount, uiTlbEqpStatus.RowCount];
            _chgEqpMode = new Label[uiTlbEqpStatus.ColumnCount, uiTlbEqpStatus.RowCount];

            UnitID = new List<string>();

            for (int col = 0; col < uiTlbEqpStatus.ColumnCount; col++)
            {
                for (int row = 0; row < uiTlbEqpStatus.RowCount; row++)
                {
                    if (col == 2 && row == 0)
                    {
                        _chgEqpStatus[col, row] = new Label
                        {
                            Text = "  X",
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.LightGray
                        };
                        _chgEqpMode[col, row] = new Label
                        {
                            BackColor = Color.LightGray
                        };
                    }
                    else
                    {
                        _chgEqpStatus[col, row] = new Label
                        {
                            Text = "I",
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.FromArgb(255, 255, 128)
                        };

                        _chgEqpMode[col, row] = new Label
                        {
                            BackColor = Color.FromArgb(197, 135, 21)
                        };
                        
                    }

                    uiTlbEqpStatus.Controls.Add(_chgEqpStatus[col, row], col, row);

                    string chgUnitID = string.Format($"CHG0110{col+1}0{row+1}");
                    UnitID.Add(chgUnitID);
                }
            }

            for (int row = 0; row < uiTlbEqpStatus.RowCount; row++)
            {
                uiTlbEqpMode1.Controls.Add(_chgEqpMode[0, row], 0, row);
                uiTlbEqpMode2.Controls.Add(_chgEqpMode[1, row], 0, row);
                uiTlbEqpMode3.Controls.Add(_chgEqpMode[2, row], 0, row);
            }
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            btnLeadTime.CallLocalLanguage();
        }
        #endregion

        #region setData
        public void SetData(List<_entire_eqp_list> data,
                            Dictionary<string, KeyValuePair<string, Color>> eqpStatus,
                            Dictionary<string, Color> processStatus)
        {
            try
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].UNIT_ID == null) continue;

                    int col = i / 4;    // int.Parse(data[i].UNIT_ID.Substring(data[i].UNIT_ID.Length - 3, 1)) - 1;
                    int row = 3 - (i % 4);    // uiTlbEqpStatus.RowCount - int.Parse(data[i].UNIT_ID.Substring(data[i].UNIT_ID.Length - 1, 1));

                    string status = data[i].PROCESS_STATUS == null ? "I" : data[i].PROCESS_STATUS.ToString();
                    _chgEqpStatus[col, row].Text = string.Format($"  {status}");
                    _chgEqpStatus[col, row].BackColor = processStatus[status];

                    _chgEqpMode[col, row].Text = string.Format($"  {data[i].EQP_MODE}");
                    _chgEqpMode[col, row].BackColor = eqpStatus[data[i].EQP_MODE].Value;
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("SetData Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        public override void SetData(List<_entire_eqp_list> data, Dictionary<string, KeyValuePair<string, Color>> eqpStatus)
        {            
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
                default:
                    statusName = LocalLanguage.GetItemString("DEF_Idle");
                    break;
            }

            return statusName;
        }
        #endregion

        #region lbEqpType_MouseDoubleClick
        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //WinManageEqp form = new WinManageEqp(EqpID, "", EqpType, 1);
            //form.ShowDialog();
        }
        #endregion

        #region lbEqpType_MouseClick
        private void lbEqpType_MouseClick(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                WinTroubleInfo winTroubleInfo = new WinTroubleInfo("Charge/Discharge", _EqpType, EqpID, "");
                winTroubleInfo.ShowDialog();
            }
        }
        #endregion

        #region TitleBarLavel Click
        private void CtrlButton1_Click(object sender, EventArgs e)
        {
            if (this.Click_Evnet != null)
                Click_Evnet(EqpID, _EqpType, -1);
        }
        #endregion

        public void uiTlbEqpStatus_Click(object sender, MouseEventArgs e)
        {

            //MessageBox.Show("Cell chosen: (" +
            //                 uiTlbEqpStatus.GetRow((Panel)sender) + ", " +
            //                 uiTlbEqpStatus.GetColumn((Panel)sender) + ")");
        }
    }
}
