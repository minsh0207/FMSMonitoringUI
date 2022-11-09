/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    :
//  Create Date	    :
//  Author			:
//  Remark			:   
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [Using]
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

#region [NameSpace]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlTextBoxRoot : UserControlRoot
    {
        #region [Variable, Menber]
        public delegate void OnTextBoxKeyDownHandler(object sender, KeyEventArgs e);
        public OnTextBoxKeyDownHandler OnTextBoxKeyDownEvent = null;
        public delegate void OnTextBoxDoubleClickHandler(object sender, EventArgs e);
        public OnTextBoxDoubleClickHandler OnTextBoxDoubleClickEvent = null;


        public delegate void OnTextBoxTextChangedHandler(object sender, EventArgs e);
        public OnTextBoxTextChangedHandler OnTextBoxTextChangeEvent = null;
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

        string _TextData="";
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
        //20190129 KJY - for password
        [DisplayName("PasswordChar"), Description("Password Char"), Category("TextBox Setting")]
        public char PasswordChar
        {
            get
            {
                return TextBoxData.PasswordChar;
            }
            set
            {
                TextBoxData.PasswordChar = value;
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
        [DisplayName("MaxLength"), Description("Text MaxLength"), Category("TextBox Setting")]
        public int MaxLength
        {
            get
            {
                return TextBoxData.MaxLength;
            }
            set
            {
                TextBoxData.MaxLength = value;
            }
        }


        [DefaultValue(false)]
        [Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        [DefaultValue(false)]
        [Browsable(true)]
        public HorizontalAlignment TextBoxAlign
        {
            get
            {
                return TextBoxData.TextAlign;
            }
            set
            {
                TextBoxData.TextAlign = value;
            }
        }

        [DefaultValue(false)]
        [Browsable(true)]
        public bool ReadOnly
        {
            get
            {
                return TextBoxData.ReadOnly;
            }
            set
            {
                TextBoxData.ReadOnly = value;
            }
        }


        #endregion

        #region [Constructor]
        public CtrlTextBoxRoot()
        {
            InitializeComponent();

            AutoSize = false;
            this.Resize += new EventHandler(CtrlTextBoxRoot_Resize);
        }
        #endregion

        #region [CtrlTextBoxRoot_Resize]
        private void CtrlTextBoxRoot_Resize(object sender, EventArgs e)
        {
            int nWidth = Convert.ToInt32(Width * 0.4);

            if (nWidth > 150) nWidth = 150;

            //this. Resize ..
            lbTitle.Top = 1;
            lbTitle.Left = 1;
            lbTitle.Width = nWidth;
            lbTitle.Height = Height - 2;

            TextBoxData.Top = 1;
            TextBoxData.Left = nWidth + 5;
            TextBoxData.Width = (Width - nWidth);
            TextBoxData.Height = Height - 2;
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
                case 0:
                    break;
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

            OnTextBoxTextChangeEvent?.Invoke(sender, e);
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

        private void TextBoxData_DoubleClick(object sender, EventArgs e)
        {
            OnTextBoxDoubleClickEvent?.Invoke(sender, e);
        }
    }
    #endregion
}
#endregion