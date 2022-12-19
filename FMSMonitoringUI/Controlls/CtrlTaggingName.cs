using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls
{
    public partial class CtrlTaggingName : UserControl
    {
        #region Properties
        Color _tagColor = Color.Red;
        [DisplayName("TagColor"), Description("Tag Color"), Category("Tag Setting")]
        public Color TagColor
        {
            get
            {
                return lbColor.BackColor;
            }
            set
            {
                _tagColor = value;
                lbColor.BackColor = _tagColor;
            }
        }

        Color _textColor = Color.White;
        [DisplayName("TextColor"), Description("Text Color"), Category("Tag Setting")]
        public Color TextColor
        {
            get
            {
                return lbColor.ForeColor;
            }
            set
            {
                _textColor = value;
                lbColor.ForeColor = _textColor;
            }
        }

        string _colorText = "-";
        [DisplayName("ColorText"), Description("Color Text"), Category("Tag Setting")]
        public string ColorText
        {
            get
            {
                return lbColor.Text;
            }
            set
            {
                _colorText = value;
                lbColor.Text = _colorText;
            }
        }

        string _tagText = "TagText";
        [DisplayName("TagText"), Description("Tag Text"), Category("Tag Setting")]
        public string TagText
        {
            get
            {
                return lbTag.Text;
            }
            set
            {
                _tagText = value;
                lbTag.Text = _tagText;
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

        public CtrlTaggingName()
        {
            InitializeComponent();
        }

        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                lbTag.Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
    }
}
