/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : CtrlTextBox
//  Create Date	    : 2018.10.24
//  Author			: LSY
//  Remark			:   
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.ComponentModel;
#endregion

namespace MonitoringUI.Controlls.CButton
{
    public partial class CtrlButtonCancel : CtrlButtonRoot
    {
        public CtrlButtonCancel()
        {
            InitializeComponent();
        }

        private void CtrlButton_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("strCancel");
        }
    }
}
