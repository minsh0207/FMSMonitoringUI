using Microsoft.Office.Interop.Excel;
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

namespace FMSMonitoringUI.Controlls.CTextBox
{
    public partial class CtrlTextBox : UserControl
    {
        #region Properties
        Single _TitleWidth = 250F;
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
                tableLayoutPanel.ColumnStyles.Clear();
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, _TitleWidth));
                Invalidate();
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
                lbText.Text = _TextData;
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

        private void CtrlTextBox_Load(object sender, EventArgs e)
        {
            if (LanguageID == "")
            {
                lbTitle.Text = _labelText;
            }
            else
            {
                lbTitle.Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
    }
}
