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

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlControlStatus : UserControl
    {
        #region Properties
        string _RestLanguageID = "";
        [DisplayName("Rest LocalLanguage"), Description("Local Language"), Category("Language Setting")]
        public string RestLanguageID
        {
            get
            {
                return _RestLanguageID;
            }
            set
            {
                _RestLanguageID = value;
            }
        }
        string _PlcLanguageID = "";
        [DisplayName("PLC LocalLanguage"), Description("Local Language"), Category("Language Setting")]
        public string PlcLanguageID
        {
            get
            {
                return _PlcLanguageID;
            }
            set
            {
                _PlcLanguageID = value;
            }
        }
        #endregion

        public CtrlControlStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// plcno : OPC Sever No, status : 1=Connecting,2=Connect, 4=Disconnect
        /// </summary>
        /// <param name="plcno"></param>
        /// <param name="status"></param>
        public void SetPLCConnectionStatus(int plcno, int status)
        {
            if (plcno == 0) PLCServer1.LedStatus(status);
            else if (plcno == 1) PLCServer2.LedStatus(status);
            else if (plcno == 2) PLCServer3.LedStatus(status);
            else if (plcno == 3) PLCServer4.LedStatus(status);
        }

        /// <summary>
        /// status : 1=Connecting,2=Connect, 4=Disconnect
        /// </summary>
        /// <param name="status"></param>
        public void SetRestConnectionStatus(int status)
        {
            RestServer.LedStatus(status);
        }

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {

            if (_RestLanguageID != "")
            {
                RestServer.TitleText = LocalLanguage.GetItemString(_RestLanguageID);
            }

            if (_PlcLanguageID != "")
            {
                PLCServer1.TitleText = LocalLanguage.GetItemString(_PlcLanguageID) + " #1";
                PLCServer2.TitleText = LocalLanguage.GetItemString(_PlcLanguageID) + " #2";
                PLCServer3.TitleText = LocalLanguage.GetItemString(_PlcLanguageID) + " #3";
                PLCServer4.TitleText = LocalLanguage.GetItemString(_PlcLanguageID) + " #4";
            }
        }
        #endregion
    }
}
