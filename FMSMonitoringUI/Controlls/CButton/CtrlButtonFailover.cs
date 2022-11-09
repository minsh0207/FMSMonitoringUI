using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace MonitoringUI.Controlls.CButton
{
    public partial class CtrlButtonFailover : CtrlButtonRoot
    {
        public CtrlButtonFailover()
        {
            InitializeComponent();
        }

        private void CtrlButtonAdd_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("DEF_CONTROL_164");
        }
    }
}
