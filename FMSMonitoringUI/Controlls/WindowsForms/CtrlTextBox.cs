using MonitoringUI;
using MonitoringUI.Controlls.CComboBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Controlls.WindowsForms
{
    public partial class CtrlTextBox : UserControl
    {
        public delegate void OnTextBoxKeyDownHandler(object sender, KeyEventArgs e);
        public OnTextBoxKeyDownHandler OnTextBoxKeyDownEvent = null;

        public delegate void OnTextBoxDoubleClickHandler(object sender, EventArgs e);
        public OnTextBoxDoubleClickHandler OnTextBoxDoubleClickEvent = null;

        public delegate void OnTextBoxTextChangedHandler(object sender, EventArgs e);
        public OnTextBoxTextChangedHandler OnTextBoxTextChangeEvent = null;

        #region Properties
        Single _TitleWidth = 150F;
        [DisplayName("Column Width"), Description("Column Width"), Category("TablePanel Setting")]
        public Single TitleWidth
        {
            get
            {
                return _TitleWidth;
            }
            set
            {
                _TitleWidth = value;

                Single panelWidth = (Single)(this.Size.Width - (int)_TitleWidth);
                tableLayoutPanel.ColumnStyles.Clear();
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, panelWidth));
                Invalidate();
            }
        }

        int _TxtMode = 0;
        [DisplayName("TextMode"), Description("TextMode"), Category("Text Mode Setting")]
        public int TextMode
        {
            set
            {
                _TxtMode = value;
            }
        }

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

        string _textData = "";
        [DisplayName("TextBoxText"), Description("TextBox Text"), Category("TextBox Setting")]
        public string TextData
        {
            get
            {
                return _textData;
            }
            set
            {
                _textData = value;
                TextBoxData.Text = _textData;
            }
        }

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
        public CtrlTextBox()
        {
            InitializeComponent();
        }

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

        #region [TextBox Key Down]
        private void TextBoxData_KeyDown(object sender, KeyEventArgs e)
        {
            OnTextBoxKeyDownEvent?.Invoke(sender, e);
        }
        private void TextBoxData_DoubleClick(object sender, EventArgs e)
        {
            OnTextBoxDoubleClickEvent?.Invoke(sender, e);
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

        #region SetTextBoxEnable
        public void SetTextBoxEnable(bool enable)
        {
            //TextBoxData.Enabled = enable;

            if (enable)
            {
                TextBoxData.BackColor = Color.White;
                TextBoxData.ForeColor = Color.Black;
                TextBoxData.BorderStyle = BorderStyle.Fixed3D;
                TextBoxData.ReadOnly = false;
                TextBoxData.Margin = new Padding(2, 2, 2, 2);
            }
            else
            {
                TextBoxData.BackColor = Color.FromArgb(27, 27, 27);
                TextBoxData.ForeColor = Color.White;
                TextBoxData.BorderStyle = BorderStyle.None;
                TextBoxData.ReadOnly = true;
                TextBoxData.Margin = new Padding(2, 6, 2, 2);
            }
        }
        #endregion

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                lbTitle.Text = LocalLanguage.GetItemString(_LanguageID) + " ";
            }
        }
        #endregion
    }
}
