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
    public partial class CtrlDateTimeD : UserControlRoot
    {
        public CtrlDateTimeD()
        {
            InitializeComponent();
        }

        private void CtrlDateTimeD_Load(object sender, EventArgs e)
        {
            lbTitle.Text = LocalLanguage.GetItemString("strDateRange");

        }
    }
}
