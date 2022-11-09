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
    public partial class CtrlButtonManualOutCell : CtrlButtonRoot
    {
        public CtrlButtonManualOutCell()
        {
            InitializeComponent();
        }
        private void CtrlButtonManualOutCell_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("strManualOutCell");
        }
    }
}
