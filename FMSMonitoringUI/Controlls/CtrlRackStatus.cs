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
    public partial class CtrlRackStatus : UserControlEqp
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
            }
        }
        #endregion

        public string UnitID { get; set; }

        public CtrlRackStatus()
        {
            InitializeComponent();

        }

        #region setData
        public void SetData(string eqpMode, Color eqpStatus, string porcessStatus, Color porcessColor)
        {
            try
            {
                lbPorcessStatus.Text = porcessStatus;
                lbPorcessStatus.BackColor = porcessColor;

                lbEqpMode.Text = eqpMode;
                lbEqpMode.BackColor = eqpStatus;
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

        private void lbRackStatus_Click(object sender, MouseEventArgs e)
        {
            if (lbPorcessStatus.Text != " X ")  // PorcessStatus에 X:사용금지와 구분하기 위해 ' X '로 변경
            {
                if (((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    WinTroubleInfo winTroubleInfo = new WinTroubleInfo(EqpName, _EqpType, "", UnitID);
                    winTroubleInfo.ShowDialog();
                }
                else
                {
                    WinFormationBox form = new WinFormationBox(EqpID, EqpType, UnitID);
                    form.ShowDialog();
                }
            }
        }
    }
}
