using System;

namespace MonitoringUI.Controlls.CButton
{
    public partial class CtrlButtonStatusChange : CtrlButtonRoot
    {
        public CtrlButtonStatusChange()
        {
            InitializeComponent();
        }

        private void CtrlButtonAdd_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("DEF_CONTROL_307");
        }
    }
}
