using FormationMonCtrl;
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
        public delegate void EventHandler(string eqpId, string eqpType, int eqpLevel);
        public event EventHandler Click_Evnet = null;

        public CtrlEqpHTAging()
        {
            InitializeComponent();
            ctrlButton1.Click += CtrlButton1_Click;
        }

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

        #region setData
        public void SetData(double totalRackCnt, double inAgingCnt)
        {
            lbTotalRack.Text = totalRackCnt.ToString();
            lbInAging.Text = inAgingCnt.ToString();

            double ratio = 100.0 * inAgingCnt / totalRackCnt;
            lbRatio.Text = string.Format($"{ratio:F1}%");
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
