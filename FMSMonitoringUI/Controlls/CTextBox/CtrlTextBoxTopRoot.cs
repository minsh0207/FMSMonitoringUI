/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : CtrlTextBoxLotID
//  Create Date	    : 2018.10.24
//  Author			: LSY
//  Remark			:   
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [USing]
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

#region [NameSpace]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlTextBoxTopRoot : UserControlRoot
    {
        #region [Variable, Menber]
        public delegate void OnTextBoxKeyDownHandler(object sender, KeyEventArgs e);
        public OnTextBoxKeyDownHandler OnTextBoxKeyDownEvent = null;
        #endregion

        //Input Data Mode Control.
        int _TxtMode = 0;

        #region Properties
        string _labelText = "";
        [DisplayName("TitleText"), Description("Title"), Category("TextBox Setting")]
        public string TitleText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
                lbTitle.Text = _labelText;
            }
        }

        string _TextData = "";
        [DisplayName("TextData"), Description("Data"), Category("TextBox Setting")]
        public string TextData
        {
            get
            {
                return _TextData;
            }
            set
            {
                _TextData = value;
                TextBoxData.Text = _TextData;
            }
        }

        [DisplayName("TextMode"), Description("TextMode"), Category("Text Mode Setting")]
        public int TextMode
        {
            set
            {
                _TxtMode = value;
            }
        }
        #endregion

        #region [Constructor]
        public CtrlTextBoxTopRoot()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Ctrl_Resize);
        }
        #endregion

        #region [Ctrl_Resize]
        private void Ctrl_Resize(object sender, EventArgs e)
        {
            //this. Resize ..
            lbTitle.Top = 1;
            lbTitle.Left = 1;
            lbTitle.Width = Width - 2;

            TextBoxData.Top = 37;
            TextBoxData.Left = 1;
            TextBoxData.Width = Width - 2;
        }
        #endregion

        #region [LanguageSet]
        public void LanguageSet(string strTitle)
        {
            TitleText = LocalLanguage.GetItemString(strTitle);
        }
        #endregion

        #region [Text Changed]
        private void TextBoxData_TextChanged(object sender, EventArgs e)
        {
            switch (_TxtMode)
            {
                //case 0:
                //    break;  
                case 1:
                    TextBoxData.Text = AreAllValidNumericChars(TextBoxData.Text);
                    break;
                case 2:
                    TextBoxData.Text = AreAllValidNumericChars(TextBoxData.Text, true, false);
                    break;
                case 3:
                    TextBoxData.Text = AreAllValidNumericChars(TextBoxData.Text, true, true);
                    break;
                case 4:
                    TextBoxData.Text = AreAllValidNumericChars(TextBoxData.Text, false, true);
                    break;
                default:
                    break;
            }
            //Data Set 이 없다면 TextBox에 데이터 접근 불가.
            TextData = TextBoxData.Text;

            // 커서 위치
            TextBoxData.SelectionStart = TextBoxData.Text.Length;
        }
        #endregion

        #region [문자열 숫자만 입력 설정]
        /////////////////////////////////////////////////////////////////////
        //	문자열 숫자만 입력 설정(숫자, -, 소수점)
        //===================================================================
        public string AreAllValidNumericChars(string strText, bool bDecimal = false, bool bSymbol = false)
        {
            string strNumberic = "";
            int nLength = strText.Length;

            for (int nCnt = 0; nCnt < nLength; nCnt++)
            {
                char ch = strText[nCnt];

                // 숫자
                if (Char.IsDigit(ch)) strNumberic = strNumberic + strText[nCnt].ToString();

                // 부호
                if (bSymbol == true && ch == '-' && nCnt == 0)
                    strNumberic = strNumberic + strText[nCnt].ToString();

                // 소수점
                if (bDecimal == true && ch == '.' && nCnt > 0)
                {
                    if (nCnt == 1 && strText.Substring(0, 1) != "-")
                        strNumberic = strNumberic + strText[nCnt].ToString();
                    if (nCnt > 1)
                        strNumberic = strNumberic + strText[nCnt].ToString();
                }
            }

            return strNumberic;
        }
        #endregion

        #region [TextBox Key Down]
        private void TextBoxData_KeyDown(object sender, KeyEventArgs e)
        {
            OnTextBoxKeyDownEvent?.Invoke(sender, e);
        }
        #endregion
    }
    #endregion
}
#endregion