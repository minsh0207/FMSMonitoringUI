using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls
{
    public partial class CtrlTitleSubBar : UserControl
    {
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
        #endregion

        public CtrlTitleSubBar()
        {
            InitializeComponent();
        }
    }
}
