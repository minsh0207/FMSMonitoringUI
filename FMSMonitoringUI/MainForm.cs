using FMSMonitoringUI.Controlls;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Monitoring;
using Novasoft.Logger;
using OPCUAClientClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace FMSMonitoringUI
{
    public partial class MainForm : Form
    {
        #region Fields
        /// <summary>
        /// Provides access to the OPC UA server and its services.
        /// </summary>
        private ApplicationInstance _Application = null;

        private Logger _Logger; // { get; set; }

        #endregion
        public MainForm(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

            _Application = applicationInstance;
            // Register for the UntrustedCertificate event. Opens trust certificate dialog to trust or reject server certificate
            _Application.UntrustedCertificate += new UntrustedCertificateEventHandler(Application_UntrustedCertificate);

            #region Title Click
            barMain.Click_Evnet += Title_ClickEvnet;
            barAging.Click_Evnet += Title_ClickEvnet;
            barFormation.Click_Evnet += Title_ClickEvnet;
            #endregion

            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);

            Title_ClickEvnet("Main");
            
        }

        /// <summary>
        /// Title 선택 시 해당 화면으로 전환시킨다.
        /// </summary>
        /// <param name="title"></param>
        private void Title_ClickEvnet(string title)
        {
            switch (title)
            {
                case "Main":
                    CtrlMain ctrlMain = new CtrlMain();
                    if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls[0].Dispose();
                    if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();
                    scMainPanel.Panel2.Controls.Add(ctrlMain);
                    break;
                case "Aging":
                    CtrlAging ctrlAging = new CtrlAging();
                    if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls[0].Dispose();
                    if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();
                    scMainPanel.Panel2.Controls.Add(ctrlAging);
                    break;
                case "Formation":
                    CtrlFormation1 ctrlFormation = new CtrlFormation1();
                    if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls[0].Dispose();
                    if (scMainPanel.Panel2.Controls.Count > 0) scMainPanel.Panel2.Controls.Clear();
                    scMainPanel.Panel2.Controls.Add(ctrlFormation);
                    break;
            }

            _Logger.Write(LogLevel.Information, $"MonitoringUI - {title}", LogFileName.AllLog);
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            //string node = "ns=2;i=3562";
            //WriteValueInfo info = new WriteValueInfo()
            //{
            //    Value = 20,
            //    DataType = BuiltInType.UInt16,
            //    NodeId = NodeId.Parse(node)
            //};

            //_clientFMS.Write(info);
        }
    }
}
