using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls
{
    public partial class CtrlBarSearchCondition : UserControlRoot
    {
        public CtrlBarSearchCondition()
        {
            InitializeComponent();
        }

        private void CtrlBarSearchCondition_Load(object sender, EventArgs e)
        {
            lbTitle.Text = LocalLanguage.GetItemString("strSearchCondition");
        }
    }
}
