using FMSMonitoringUI.Controlls;
using FMSMonitoringUI.Monitoring;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Monitoring;
using MonitoringUI.Popup;
using Novasoft.Logger;
using OPCUAClientClassLib;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Threading;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace FMSMonitoringUI
{
    public partial class MainForm : Form    //WinFormRoot
    {
        #region [Dll Import]
        // System Time
        [DllImport("kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME time);
        #endregion

        #region [Variable]
        /// <summary>
        /// Provides access to the OPC UA server and its services.
        /// </summary>
        private ApplicationInstance _Application = null;

        private Logger _Logger; // { get; set; }

        CtrlMonitoring ctrlMonitoring = null;
        CtrlAging ctrlAging = null;
        CtrlFormationCHG ctrlFormationCHG = null;
        CtrlFormationHPC ctrlFormationHPC = null;

        delegate void SetCurrentTimeCallback(string strCurrentTime);

        #endregion

        public MainForm(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

            _Logger = new Logger(ConfigurationManager.AppSettings["LOG_PATH"], LogMode.Hour);

            //SetSystemTime();

            _Application = applicationInstance;
            // Register for the UntrustedCertificate event. Opens trust certificate dialog to trust or reject server certificate
            _Application.UntrustedCertificate += new UntrustedCertificateEventHandler(Application_UntrustedCertificate);

            #region Title Click Event
            barMain.Click_Evnet += Title_ClickEvnet;
            barAging.Click_Evnet += Title_ClickEvnet;
            barFormationCHG.Click_Evnet += Title_ClickEvnet;
            barFormationHPC.Click_Evnet += Title_ClickEvnet;
            #endregion

            #region FMS MonitoringUI
            ctrlMonitoring = new CtrlMonitoring(_Application);
            ctrlAging = new CtrlAging();
            ctrlFormationCHG = new CtrlFormationCHG();
            ctrlFormationHPC = new CtrlFormationHPC();
            #endregion

            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;

            CheckLogin();

            string msg = $"============== Start the FMS Monitoring System  ==============";
            _Logger.Write(LogLevel.Info, msg, LogFileName.AllLog);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (CDefine.m_strLoginID != "")
            {
                SetWindowAuthority();

                Title_ClickEvnet("Main");
            }
        }

        #region MainForm_Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CDefine.m_strLoginID == "")
            {
                this.Close();
                return;
            }

            string msg = $"Login ID : {CDefine.m_strLoginID}";
            _Logger.Write(LogLevel.Info, msg, LogFileName.AllLog);

            #region CurrentTimer
            Thread tCurrentTime = new Thread(new ThreadStart(updateTime));
            tCurrentTime.IsBackground = true;
            tCurrentTime.Start();
            #endregion
        }
        #endregion

        #region SetSystemTime
        private bool SetSystemTime()
        {
            try
            {
                //string strDBTime =  RESTClient.DBGetDateTime(0).GetAwaiter().GetResult();

                string strDBTime = "";  // CDatabaseRest.DBGetDateTime(0);

                if (strDBTime == "" || strDBTime == null)
                    return false;

                SYSTEMTIME st = new SYSTEMTIME();
                DateTime date = new DateTime();
                date = Convert.ToDateTime(strDBTime);
                st.Year = (short)date.Year;
                st.Month = (short)date.Month;
                st.Day = (short)date.Day;
                st.Hour = (short)date.Hour;
                st.Minute = (short)date.Minute;
                st.Second = (short)date.Second;

                SetLocalTime(ref st);

                return true;
            }
            catch (Exception ex)
            {

                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set System Time Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }

        }
        #endregion

        #region CheckLogin
        private void CheckLogin()
        {
            WinLogin winLogIn = new WinLogin();

            winLogIn.ShowDialog();

            if (CDefine.m_strLoginID != "")
            {
                lbUserName.Text = CDefine.m_strLoginName;
                SetLocalizaion(CDefine.m_enLanguage);

                //MainForm_Load(null, null);
            }
        }
        #endregion

        #region SetWindowAuthority
        private void SetWindowAuthority()
        {
            bool bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, ctrlMonitoring.ToString());
            barMain.Enabled = bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, ctrlAging.ToString());
            barAging.Enabled = bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, ctrlFormationCHG.ToString());
            barFormationCHG.Enabled = bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, ctrlFormationHPC.ToString());
            barFormationHPC.Enabled = bView;
        }
        #endregion

        /// <summary>
        /// Title 선택 시 해당 화면으로 전환시킨다.
        /// </summary>
        /// <param name="title"></param>
        private void Title_ClickEvnet(string title)
        {
            if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();

            ctrlMonitoring.ProcessStart(false);
            ctrlAging.ProcessStart(false);
            ctrlFormationCHG.ProcessStart(false);
            ctrlFormationHPC.ProcessStart(false);

            switch (title)
            {
                case "Main":
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls[0].Dispose();
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();
                    scMainPanel.Panel2.Controls.Add(ctrlMonitoring);
                    ctrlMonitoring.ProcessStart(true);
                    this.Text = CAuthority.GetWindowsText(ctrlMonitoring.ToString());
                    break;

                case "Aging":
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls[0].Dispose();
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();
                    scMainPanel.Panel2.Controls.Add(ctrlAging);
                    ctrlAging.ProcessStart(true);
                    this.Text = CAuthority.GetWindowsText(ctrlAging.ToString());
                    break;

                case "Formation(CHG)":
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls[0].Dispose();
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();
                    scMainPanel.Panel2.Controls.Add(ctrlFormationCHG);
                    ctrlFormationCHG.ProcessStart(true);
                    this.Text = CAuthority.GetWindowsText(ctrlFormationCHG.ToString());
                    break;

                case "Formation(HPC)":
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls[0].Dispose();
                    //if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();
                    scMainPanel.Panel2.Controls.Add(ctrlFormationHPC);
                    ctrlFormationHPC.ProcessStart(true);
                    this.Text = CAuthority.GetWindowsText(ctrlFormationHPC.ToString());
                    break;
            }

            _Logger.Write(LogLevel.Info, $"MonitoringUI - {this.Text}", LogFileName.AllLog);
        }

        #region Application_UntrustedCertificate
        public void Application_UntrustedCertificate(object sender, UntrustedCertificateEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new UntrustedCertificateEventHandler(Application_UntrustedCertificate), sender, e);
                return;
            }

            try
            {
                TrustCertificateDialogSettings settings = new TrustCertificateDialogSettings()
                {
                    Application = e.Application,
                    UntrustedCertificate = e.Certificate,
                    Issuers = e.Issuers,
                    ValidationError = e.ValidationError,
                    SaveToTrustList = false
                };

                e.Accept = TrustCertificateDialog.ShowDialog(this, settings, 30000);

                if (settings.SaveToTrustList)
                {
                    e.Persist = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionDlg.Show(this.Text, ex);
                _Logger.Write(LogLevel.Error, $"{ex}", LogFileName.ErrorLog);
            }
        }
        #endregion

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //string node = "ns=2;i=3562";
        //    //WriteValueInfo info = new WriteValueInfo()
        //    //{
        //    //    Value = 20,
        //    //    DataType = BuiltInType.UInt16,
        //    //    NodeId = NodeId.Parse(node)
        //    //};

        //    //_clientFMS.Write(info);
        //}

        #region language세팅
        private void SetLocalizaion(enLoginLanguage enLanguage)
        {
            switch (enLanguage)
            {
                case enLoginLanguage.France:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
                    break;
                case enLoginLanguage.Korean:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko-KR");
                    break;
                case enLoginLanguage.English:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    break;
            }
            LocalLanguage.resxLanguage = new ResourceManager("MonitoringUI.WinFormRoot", typeof(WinFormRoot).Assembly);
        }
        #endregion

        #region 날짜 표시 Thread
        private void updateTime()
        {
            string strCurrentTime = "";
            while (true)
            {
                strCurrentTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //lbCurrentTime.Text = strCurrentTime;
                SetCurrentTime(strCurrentTime);
                Task.Delay(1000).GetAwaiter().GetResult();
            }
        }
        private void SetCurrentTime(string strCurrentTime)
        {

            try
            {
                if (this.lbCurrentTime.InvokeRequired)
                {
                    SetCurrentTimeCallback d = new SetCurrentTimeCallback(SetCurrentTime);
                    this.Invoke(d, new object[] { strCurrentTime });
                }
                else
                {
                    this.lbCurrentTime.Text = strCurrentTime;
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        #endregion

        
    }
}
