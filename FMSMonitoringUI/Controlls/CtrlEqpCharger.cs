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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        //public List<string> UnitID { get; set; }
        /// <summary>
        /// First=Equipment ID, Second=Eqp Name
        /// </summary>
        public Dictionary<string, string> _EqpName;

        private Label[,] _chgEqpStatus;
        private Label[,] _chgEqpMode;
        private CtrlRackStatus[,] _rackStatus;

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
            _rackStatus = new CtrlRackStatus[uiTlbEqpStatus.ColumnCount, uiTlbEqpStatus.RowCount];

            //UnitID = new List<string>();
            //_EqpName = new Dictionary<string, string>();

            for (int col = 0; col < uiTlbEqpStatus.ColumnCount; col++)
            {
                for (int row = 0; row < uiTlbEqpStatus.RowCount; row++)
                {

                    _rackStatus[col, row] = new CtrlRackStatus();
                    _rackStatus[col, row].Dock = DockStyle.Left;

                    int floor = 4 - row;
                    string unitID = string.Format($"CHG0110{col + 1}0{floor}");

                    _rackStatus[col, row].EqpType = EqpType;
                    _rackStatus[col, row].EqpID = EqpID;
                    _rackStatus[col, row].UnitID = unitID;

                    uiTlbEqpStatus.Controls.Add(_rackStatus[col, row], col, row);
                }
            }

            _rackStatus[2, 0].SetData("", Color.LightGray, " X ", Color.LightGray);
        }
        #endregion

        #region InitLanguage
        public void InitLanguage()
        {
            btnLeadTime.CallLocalLanguage();
        }
        #endregion

        public void SetUnitName(Dictionary<string, string> eqpName)
        {
            int maxFloor = uiTlbEqpStatus.RowCount;
            int maxBay = uiTlbEqpStatus.ColumnCount;

            for (int col = 0; col < maxBay; col++)
            {
                for (int row = 0; row < maxFloor; row++)
                {   
                    int floor = maxFloor - row;
                    string unitID = string.Format($"CHG0110{col + 1}0{floor}");

                    if (col == 2 && floor == 4) continue;       // CHG0110304는 사용하지 않음.
                    _rackStatus[col, row].EqpName = eqpName[unitID];
                }
            }
        }

        #region setData
        public void SetData(List<_entire_eqp_list> data,
                            Dictionary<string, KeyValuePair<string, Color>> eqpStatus,
                            Dictionary<string, Color> processStatus)
        {
            try
            {
                int maxFloor = uiTlbEqpStatus.RowCount;
                int maxBay = uiTlbEqpStatus.ColumnCount;
                string status;

                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].UNIT_ID == null) continue;

                    int col = i / maxFloor;    // int.Parse(data[i].UNIT_ID.Substring(data[i].UNIT_ID.Length - 3, 1)) - 1;
                    int row = maxBay - (i % maxFloor);    // uiTlbEqpStatus.RowCount - int.Parse(data[i].UNIT_ID.Substring(data[i].UNIT_ID.Length - 1, 1));

                    if (data[i].EQP_STATUS == "T" || data[i].EQP_STATUS == "F")
                    {
                        status = data[i].EQP_STATUS;
                        _rackStatus[col, row].SetData(data[i].EQP_MODE, eqpStatus[data[i].EQP_MODE].Value, status, eqpStatus[status].Value);
                    }
                    else
                    {
                        status = data[i].PROCESS_STATUS ?? "I";
                        _rackStatus[col, row].SetData(data[i].EQP_MODE, eqpStatus[data[i].EQP_MODE].Value, status, processStatus[status]);
                    }
                    
                    
                    //_chgEqpStatus[col, row].Text = string.Format($"  {status}");
                    //_chgEqpStatus[col, row].BackColor = processStatus[status];

                    //_chgEqpMode[col, row].Text = string.Format($"  {data[i].EQP_MODE}");
                    //_chgEqpMode[col, row].BackColor = eqpStatus[data[i].EQP_MODE].Value;
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

        //#region lbEqpType_MouseClick
        //private void lbEqpType_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (((MouseEventArgs)e).Button == MouseButtons.Right)
        //    {
        //        WinTroubleInfo winTroubleInfo = new WinTroubleInfo("Charge/Discharge", _EqpType, EqpID, "");
        //        winTroubleInfo.ShowDialog();
        //    }
        //}
        //#endregion

        #region TitleBarLavel Click
        private void CtrlButton1_Click(object sender, EventArgs e)
        {
            if (this.Click_Evnet != null)
                Click_Evnet(EqpID, _EqpType, -1);
        }
        #endregion

        //public void uiTlbEqpStatus_Click(object sender, MouseEventArgs e)
        //{

        //    //MessageBox.Show("Cell chosen: (" +
        //    //                 uiTlbEqpStatus.GetRow((Panel)sender) + ", " +
        //    //                 uiTlbEqpStatus.GetColumn((Panel)sender) + ")");
        //}
    }
}
