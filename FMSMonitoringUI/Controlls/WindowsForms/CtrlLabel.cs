using MonitoringUI;
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
    public partial class CtrlLabel : Label
    {
        #region Properties
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

        public CtrlLabel()
        {
            InitializeComponent();
        }

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
        #endregion
    }
}
