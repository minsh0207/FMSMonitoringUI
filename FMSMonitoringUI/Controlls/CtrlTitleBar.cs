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
    public partial class CtrlTitleBar : UserControl
    {
        public delegate void EventHandler(string title);
        public event EventHandler Click_Evnet = null;

        public delegate void MouseMoveEventHandler(object sender, MouseEventArgs e);
        public event MouseMoveEventHandler MouseMove_Evnet = null;

        public delegate void MouseDownEventHandler(object sender, MouseEventArgs e);
        public event MouseDownEventHandler MouseDown_Evnet = null;

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

        public CtrlTitleBar()
        {
            InitializeComponent();
        }

        public void LbTitle_Click(object sender, EventArgs e)
        {
            if (this.Click_Evnet != null)                
                Click_Evnet(TitleText);
        }

        private void LbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseMove_Evnet != null)
                MouseMove_Evnet(sender, e);
        }

        private void lbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.MouseDown_Evnet != null)
                MouseDown_Evnet(sender, e);
        }

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                lbTitle.Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
        #endregion
    }
}
