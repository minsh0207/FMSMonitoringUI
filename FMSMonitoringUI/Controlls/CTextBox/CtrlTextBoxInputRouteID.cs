using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitoringUI.Controlls.CComboBox;

namespace MonitoringUI.Controlls.TextBox
{
    public partial class CtrlTextBoxInputRouteID : CtrlTextBoxRoot
    {
        #region Properties
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

        public CtrlTextBoxInputRouteID()
        {
            InitializeComponent();
        }

        private void CtrlTextBoxInputRouteID_Load(object sender, EventArgs e)
        {
            TitleText = LocalLanguage.GetItemString("DEF_CONTROL_093");
        }
    }
}
