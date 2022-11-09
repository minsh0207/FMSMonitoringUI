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
    public partial class CtrlDateTimeDT : UserControlRoot
    {
        #region Properties
        System.DateTime _dateTimeStart = System.DateTime.Now;
        [DisplayName("StartTime"), Description("Start Time"), Category("StartTime Setting")]
        public System.DateTime StartTime
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
        #endregion


        string strTitleName = string.Empty;

        public CtrlDateTimeDT()
        {
            strTitleName = "strDateRange";
            InitializeComponent();
        }

        public void ChangeTitle(string strTitle)
        {
            if (strTitle != null) strTitleName = strTitle;
            else strTitleName = "strDateRange";
            lbTitle.Text = LocalLanguage.GetItemString(strTitleName);
        }

        private void CtrlDateTimeDT_Load(object sender, EventArgs e)
        {
            //lbTitle.Text = LocalLanguage.GetItemString("strDateRange");
            lbTitle.Text = LocalLanguage.GetItemString(strTitleName);
        }
    }
}
