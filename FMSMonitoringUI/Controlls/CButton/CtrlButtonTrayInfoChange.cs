/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : CtrlButton
//  Create Date	    : 2018.10.24
//  Author			: LSY
//  Remark			:   
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
#endregion

namespace MonitoringUI.Controlls.CButton
{
    public partial class CtrlButtonTrayInfoChange : CtrlButtonRoot
    {
        public CtrlButtonTrayInfoChange()
        {
            InitializeComponent();
        }
        
        private void CtrlButton_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("DEF_CONTROL_118");
        }
    }
}
