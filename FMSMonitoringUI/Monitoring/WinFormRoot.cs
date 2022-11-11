using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Resources;

namespace MonitoringUI
{
    

    public partial class WinFormRoot : Form
    {

        #region Properties
        [DisplayName("WindowID"), Description("Window ID"), Category("Window Setting")]
        public string WindowID
        {
            get
            {
                return statusLabel.Text;
            }
            set
            {
                statusLabel.Text = value;
            }
        }
        #endregion

        public WinFormRoot()
        {
            
            InitializeComponent();
        }
    }

    // for Language Localization
    public static class LocalLanguage
    {
        public static ResourceManager resxLanguage = new ResourceManager("MonitoringUI.WinFormRoot", typeof(WinFormRoot).Assembly);
        public static string GetItemString(string strName)
        {
            string strNameTo = "";
            resxLanguage = new ResourceManager("MonitoringUI.WinFormRoot", typeof(WinFormRoot).Assembly);
            //찾을수없다면 그대로 출력
            strNameTo = resxLanguage.GetString(strName) != null ? resxLanguage.GetString(strName) : strName;
            return strNameTo;
        }

    }
}
