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
    public partial class CtrlButtonModify : CtrlButtonRoot
    {
        public CtrlButtonModify()
        {
            InitializeComponent();
            LabelText = LocalLanguage.GetItemString("strModify");
        }

        private void CtrlButtonModify_Load(object sender, EventArgs e)
        {
            //LabelText = LocalLanguage.GetItemString("strModify");
            if(LabelText.Length == 0)
                LabelText = LocalLanguage.GetItemString("strModify");

            if(LabelText == "strModify")
                LabelText = LocalLanguage.GetItemString("strModify");
        }
    }
}
