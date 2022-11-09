using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls.CDateTime
{
    public partial class CtrlDateTimePlanTime : UserControlRoot
    {

        #region Properties
        System.DateTime _dateTimeEnd = System.DateTime.Now;
        [DisplayName("PlanTime"), Description("Plan Time"), Category("EndTime Setting")]
        public System.DateTime PlanTime
        {
            get
            {
                return dtpFrom.Value;
            }
            set
            {
                _dateTimeEnd = value;
                dtpFrom.Value = _dateTimeEnd;

            }
        }
        #endregion
        public CtrlDateTimePlanTime()
        {
            InitializeComponent();
        }

        private void CtrlDateTimePlanTime_Load(object sender, EventArgs e)
        {
            lbTitle.Text = LocalLanguage.GetItemString("strPlanTime");
        }
    }
}
