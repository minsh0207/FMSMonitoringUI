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
using System.Windows.Forms.DataVisualization.Charting;

namespace FMSMonitoringUI.Controlls.WindowsForms
{
    public partial class CtrlGroupBox : UserControl
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
        string _labelText = "";
        [DisplayName("TitleText"), Description("Title"), Category("GroupBox Setting")]
        public string TitleText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
                groupBox.Text = value;
            }
        }
        #endregion

        public CtrlGroupBox()
        {
            InitializeComponent();
        }

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                groupBox.Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
        #endregion
    }
}
