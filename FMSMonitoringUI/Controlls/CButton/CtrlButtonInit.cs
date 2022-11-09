//  Description	    : Control
//  Create Date	    : 2018.10.29
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
    public partial class CtrlButtonInit : CtrlButtonRoot
    {
        public CtrlButtonInit()
        {
            InitializeComponent();
        }

        private void CtrlButton_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("strInit");
        }
    }
}
