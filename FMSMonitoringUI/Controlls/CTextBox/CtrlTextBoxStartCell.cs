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
using MonitoringUI.Controlls.CComboBox;
#endregion

#region [Name Space]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlTextBoxStartCell : CtrlTextBoxRoot
    {
        #region [Constructor]
        public CtrlTextBoxStartCell()
        {
            InitializeComponent();
        }
        #endregion

        #region [Window Event]
        private void CtrlTextBox_Load(object sender, EventArgs e)
        {
            TitleText = LocalLanguage.GetItemString("strStartCell");
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