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
    public partial class CtrlDateTimeD2D : UserControlRoot
    {

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

        public CtrlDateTimeD2D()
        {
            InitializeComponent();
            
        }

        private void CtrlDateTimeD2D_Load(object sender, EventArgs e)
        {
            lbTitle.Text = LocalLanguage.GetItemString("strDateRange");

        }
    }
}
