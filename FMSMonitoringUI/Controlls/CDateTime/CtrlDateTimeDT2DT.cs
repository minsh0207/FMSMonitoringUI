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
    public partial class CtrlDateTimeDT2DT : UserControlRoot
    {


        public delegate void OnValueChangeEvent();
        public OnValueChangeEvent OnValueChanged = null;

        #region Properties
        System.DateTime _dateTimeStart = System.DateTime.Now;
        [DisplayName("StartDate"), Description("Start Date"), Category("Date Setting")]
        public System.DateTime StartDate
        {
            get
            {
                return dtpFrom.Value;
            }
            set
            {
                _dateTimeStart = value;
                dtpFrom.Value = _dateTimeStart;


            }
        }
        System.DateTime _dateTimeEnd = System.DateTime.Now;
        [DisplayName("EndDate"), Description("End Date"), Category("Date Setting")]
        public System.DateTime EndDate
        {
            get
            {
                return dtpEnd.Value;
            }
            set
            {
                _dateTimeStart = value;
                dtpEnd.Value = _dateTimeStart;


            }
        }
        #endregion

        public CtrlDateTimeDT2DT()
        {
            InitializeComponent();
        }

        private void CtrlDateTimeDT2DT_Load(object sender, EventArgs e)
        {
            lbTitle.Text = LocalLanguage.GetItemString("strDateRange");
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (OnValueChanged == null) return;
            OnValueChanged();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (OnValueChanged == null) return;
            OnValueChanged();
        }
    }
}
