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
    public partial class CtrlTextBoxUserID : CtrlTextBoxRoot
    {

        #region [Constructor]
        public CtrlTextBoxUserID()
        {
            InitializeComponent();
        }
        #endregion

        #region [Window Event]
        private void CtrlTextBox_Load(object sender, EventArgs e)
        {
            //TitleText = LocalLanguage.GetItemString("strUserID");
            TitleText = "Login ID";
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