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
    public partial class CtrlButton : CtrlButtonRoot
    {
        #region Properties
        string _LanguageID = "";
        [DisplayName("LocalLanguage"), Description("Local Language"), Category("Language Setting")]
        public string LanguageID
        {
            get
            {
                return _LanguageID;
            }
            set
            {
                _LanguageID = value;
            }
        }
        #endregion

        public CtrlButton()
        {
            InitializeComponent();
        }

        private void CtrlButton_Load(object sender, EventArgs e)
        {
            //LabelText = LocalLanguage.GetItemString("strConfirm");
            //if (LabelText == "strConfirm")
            //    LabelText = "Confirm";
        }

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                LabelText = LocalLanguage.GetItemString(_LanguageID);
            }
        }
        #endregion

    }
}
