using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls.CButton
{
    public partial class CtrlButtonDeleteTray : CtrlButtonRoot
    {
        public CtrlButtonDeleteTray()
        {
            InitializeComponent();
        }

        private void CtrlButtonDeleteTray_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("strDeleteTray");
        }
    }
}
