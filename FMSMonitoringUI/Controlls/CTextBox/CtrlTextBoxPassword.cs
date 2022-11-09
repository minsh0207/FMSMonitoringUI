//***************************************************************************
//  Description	    : CtrlTextBoxLotID
//  Create Date	    : 2018.11.08
//  Author			: LSY
//  Remark			:   
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.ComponentModel;
using MonitoringUI.Controlls.CComboBox;
#endregion

#region [Name Space]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlTextBoxPassword : CtrlTextBoxRoot
    {

        #region [Constructor]
        public CtrlTextBoxPassword()
        {
            InitializeComponent();
        }
        #endregion

        #region [Window Event]
        private void CtrlTextBox_Load(object sender, EventArgs e)
        {
            //TitleText = LocalLanguage.GetItemString("strUserID");
            TitleText = "Password";
        }
        #endregion

        #region [Properties]
        string _textBoxText = "";
        [DisplayName("TextBoxText"), Description("TextBox Text"), Category("TextBox Setting")]
        public string TextBoxText
        {
            get
            {
                return _textBoxText;
            }
            set
            {
                _textBoxText = value;
                TextData = _textBoxText;
            }
        }
        #endregion
    }
    #endregion
}
#endregion