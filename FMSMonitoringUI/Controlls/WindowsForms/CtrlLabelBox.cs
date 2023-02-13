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

namespace FMSMonitoringUI.Controlls.WindowsForms
{
    public partial class CtrlLabelBox : UserControl
    {
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
        public CtrlLabelBox()
        {
            InitializeComponent();
        }

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
