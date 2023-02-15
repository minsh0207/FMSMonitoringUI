using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
using MonitoringUI;
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
    public partial class CtrlEqpHTAging : UserControlEqp
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
                lbTitle.Text = string.Format($" {_EqpType}");
            }
        }
        int _EqpLevel = 0;
        [DisplayName("EQP Level"), Description("EQP Level"), Category("GroupBox Setting")]
        public int EqpLevel
        {
            get
            {
                return _EqpLevel;
            }
            set
            {
                _EqpLevel = value;
            }
        }
        #endregion

        public delegate void EventHandler(string eqpId, string eqpType, int eqpLevel);
        public event EventHandler Click_Evnet = null;

        public CtrlEqpHTAging()
        {
            InitializeComponent();
            btnLeadTime.Click += CtrlButton1_Click;
        }

        #region CtrlEqpHTAging_Load
        private void CtrlEqpHTAging_Load(object sender, EventArgs e)
        {
            InitLanguage();
        }
        #endregion

        #region InitLanguage
        private  void InitLanguage()
        {
            btnLeadTime.CallLocalLanguage();

            foreach (var ctl in this.Controls)
            {
                if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel control = ctl as CtrlLabel;
                    control.CallLocalLanguage();
                }
            }
        }
        #endregion

        #region setData
        public void SetData(double totalRackCnt, double inAgingCnt)
        {
            lbTotalRack.Text = totalRackCnt.ToString();
            lbInAging.Text = inAgingCnt.ToString();

            double ratio = 100.0 * inAgingCnt / totalRackCnt;
            lbRatio.Text = string.Format($"{ratio:F1}%");
        }
        #endregion

        #region lbEqpType_MouseClick
        private void lbEqpType_MouseClick(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                WinTroubleInfo winTroubleInfo = new WinTroubleInfo(EqpName, _EqpType, EqpID, "", _EqpLevel);
                winTroubleInfo.ShowDialog();
            }
        }
        #endregion

        #region TitleBarLavel Click
        private void CtrlButton1_Click(object sender, EventArgs e)
        {
            if (this.Click_Evnet != null)
                Click_Evnet(EqpID, _EqpType, _EqpLevel);
        }
        #endregion

        
    }
}
