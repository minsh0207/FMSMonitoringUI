using ExcelDataReader.Log;
using FMSMonitoringUI.Common;
using FMSMonitoringUI.Controlls;
using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Monitoring;
using MonitoringUI.Popup;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Icao;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Threading;
using UnifiedAutomation.GettingStarted;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using IWshRuntimeLibrary;       // 바탕화면 바로가기 Icon
using System.Windows.Shapes;

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

        CtrlMonitoring _CtrlMonitoring = null;
        CtrlAging _CtrlAging = null;
        CtrlFormationCHG _CtrlFormationCHG = null;
        CtrlFormationHPC _CtrlFormationHPC = null;

        delegate void SetCurrentTimeCallback(string strCurrentTime);

        // Trouble Equipment List Dictionary
        // 사용자가 Trouble PopUP 창을 닫을 경우에 대해 정보를 가지고 있으면서 체크를 해준다.
        private Dictionary<string, CTroubleEquipmentList> _TroubleEquipmentList;
        private Dictionary<string, CTroubleEquipmentList> _TroubleAgingList;
        private Dictionary<string, CTroubleEquipmentList> _TroubleConveyorList;
        private List<string> _TroublePopupList;

        private string _MainFormText = string.Empty;
        #endregion

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;

        private Thread _LogOutThread;
        private int _LogOutCount = 0;
        #endregion

        //static WshShell wsh = new WshShell();

        public MainForm(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

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
            _CtrlMonitoring = new CtrlMonitoring(_Application);
            _CtrlMonitoring.Tag = barMain.TitleText;
            _CtrlMonitoring.TroubleOccurEvent += _CtrlMonitoring_TroubleOccurEvent;

            _CtrlAging = new CtrlAging();
            _CtrlAging.Tag = barAging.TitleText;
            // Aging에 있는 Rack상태 정보를 가져온다.
            _CtrlMonitoring._RackStatus = _CtrlAging._RackStatus;
            _CtrlFormationCHG = new CtrlFormationCHG();
            _CtrlFormationCHG.Tag = barFormationCHG.TitleText;
            // Formation에 있는 Process Status정보를 가져온다.
            _CtrlMonitoring._ProcessStatus = _CtrlFormationCHG._EqpStatus;
            
            _CtrlFormationHPC = new CtrlFormationHPC();
            _CtrlFormationHPC.Tag = barFormationHPC.TitleText;
            #endregion

            _TroubleEquipmentList = new Dictionary<string, CTroubleEquipmentList>();
            _TroubleAgingList = new Dictionary<string, CTroubleEquipmentList>();
            _TroubleConveyorList = new Dictionary<string, CTroubleEquipmentList>();
            _TroublePopupList = new List<string>();

            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;

            AlarmOccur.Visible = false;

            CDefine.m_strLanguage = enLoginLanguage.English.ToString();

            CheckLogin();

            LoadEqpName().GetAwaiter().GetResult();

            _MainFormText = "[FMS Monitoring System]";

            //lbVersionInfo.Text = " Ver. " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lbVersionInfo.Text = CVersionHistory.GetVersion();  // " Ver.2023.05.08.001";

            CLogger.WriteLog(enLogLevel.Info, "", "");
            CLogger.WriteLog(enLogLevel.Info, _MainFormText, $"== Start the FMS Monitoring System : {CVersionHistory.GetVersion()}==");
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (CDefine.m_strLoginID != "")
            {
                SetWindowAuthority();

                Title_ClickEvnet(_CtrlMonitoring.Tag.ToString());

                InitLanguage();
            }
        }

        #region MainForm Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CDefine.m_strLoginID == "")
            {
                this.Close();
                return;
            }

            // 바로가기 경로 설정
            //string Desktop_Dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //DirectoryInfo DirInfo = new DirectoryInfo(Desktop_Dir);
            //string LinkFileName = Desktop_Dir.ToString() + @"\FMS Monitoring.exe";
            //FileInfo LinkFile = new FileInfo(LinkFileName);

            //// 이미 존재하는 경우 return
            //if (LinkFile.Exists)
            //{ return; }

            // 바로가기 생성
            //WshShell wsh = new WshShell();
            //IWshShortcut Link = wsh.CreateShortcut(@"C:\Users\msh\Desktop.lnk");

            //// 원본 파일의 경로 
            //StringBuilder SB = new StringBuilder();
            //SB.Append(Application.ExecutablePath);
            ////SB.Append(@"\FMSMonitoringUI.exe");
            //Link.TargetPath = SB.ToString();
            //Link.IconLocation = Application.StartupPath + @"\res\Verkor_icon_x48.ico";
            //Link.Save();

            CLogger.WriteLog(enLogLevel.Info, _MainFormText, $"LoginID : {CDefine.m_strLoginID}, UserName : {CDefine.m_strLoginName}");

            #region CurrentTimer
            Thread tCurrentTime = new Thread(new ThreadStart(updateTime));
            tCurrentTime.IsBackground = true;
            tCurrentTime.Start();
            #endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));


            // 현장가서 활성화 시킴. 자동 Logout
            //this.BeginInvoke(new MethodInvoker(delegate ()
            //{
            //    _LogOutThread = new Thread(() => LogOutThreadCallback());
            //    _LogOutThread.IsBackground = true; _LogOutThread.Start();
            //}));

            CreateDesktopIcon();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (this._TheadVisiable)
                this._ProcessThread.Abort();

        }
        #endregion

        #region CreateDesktopIcon
        /// <summary>
        /// 바탕화면 바로가기 Icon 생성
        /// </summary>
        private void CreateDesktopIcon()
        {
            // 바로가기 생성
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
#if DEBUG
            string IconName = "FMS MonitoringD";
#else
            string IconName = "FMS Monitoring";
#endif

            string LinkFileName = path + $"/{IconName}.lnk";
            FileInfo LinkFile = new FileInfo(LinkFileName);

            if (LinkFile.Exists == false)
            {
                WshShell wsh = new WshShell();
                IWshShortcut myShotCut;

                myShotCut = (IWshShortcut)wsh.CreateShortcut(path + $"/{IconName}.lnk");
                myShotCut.TargetPath = Application.ExecutablePath;
                myShotCut.WorkingDirectory = Application.StartupPath;
                myShotCut.Description = $"{IconName}";
                myShotCut.IconLocation = Application.StartupPath + @"\Verkor_icon_x48.ico";
                myShotCut.Save();
            }
        }
#endregion

#region InitLanguage
        private void InitLanguage()
        {
            // CtrlTaggingName 언어 변환 호출
            foreach (var ctl in scMainPanel.Panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlTitleBarLabel))
                {
                    CtrlTitleBarLabel tagName = ctl as CtrlTitleBarLabel;
                    tagName.CallLocalLanguage();
                }
            }

            cbUsePopUp.CallLocalLanguage();

#region FMS MonitoringUI
            _CtrlMonitoring.Text = CAuthority.GetWindowsText(_CtrlMonitoring.ToString());
            _CtrlAging.Text = CAuthority.GetWindowsText(_CtrlAging.ToString());
            _CtrlFormationCHG.Text = CAuthority.GetWindowsText(_CtrlFormationCHG.ToString());
            _CtrlFormationHPC.Text = CAuthority.GetWindowsText(_CtrlFormationHPC.ToString());
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
                System.Diagnostics.Debug.Print(string.Format("SetSystemTime Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("SetSystemTime Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);

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
                lbUserName.Text = $"{CDefine.m_strLoginName} ({CDefine.m_strLoginID})";
                SetLocalizaion(CDefine.m_enLanguage);
            }
        }
#endregion

#region SetWindowAuthority
        private void SetWindowAuthority()
        {
            bool bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, _CtrlMonitoring.ToString());
            barMain.Enabled = bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, _CtrlAging.ToString());
            barAging.Enabled = bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, _CtrlFormationCHG.ToString());
            barFormationCHG.Enabled = bView;

            bView = CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, _CtrlFormationHPC.ToString());
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

            _CtrlMonitoring.ProcessStart(false);            
            _CtrlAging.ProcessStart(false);
            _CtrlFormationCHG.ProcessStart(false);
            _CtrlFormationHPC.ProcessStart(false);

            barMain.SetTitelColor(Color.White);
            barAging.SetTitelColor(Color.White);
            barFormationCHG.SetTitelColor(Color.White);
            barFormationHPC.SetTitelColor(Color.White);

            Color SelectColor = Color.FromArgb(0, 129, 110);

            if (title == _CtrlMonitoring.Tag.ToString())
            {
                scMainPanel.Panel2.Controls.Add(_CtrlMonitoring);
                _CtrlMonitoring.InitLanguage();
                _CtrlMonitoring.ProcessStart(true);

                barMain.SetTitelColor(SelectColor);
                this.Text = CAuthority.GetWindowsText(_CtrlMonitoring.ToString());
            }
            else if (title == _CtrlAging.Tag.ToString())
            {
                scMainPanel.Panel2.Controls.Add(_CtrlAging);
                _CtrlAging.InitLanguage();
                _CtrlAging.ProcessStart(true);

                barAging.SetTitelColor(SelectColor);
                this.Text = CAuthority.GetWindowsText(_CtrlAging.ToString());
            }
            else if (title == _CtrlFormationCHG.Tag.ToString())
            {
                scMainPanel.Panel2.Controls.Add(_CtrlFormationCHG);
                _CtrlFormationCHG.InitLanguage();
                _CtrlFormationCHG.ProcessStart(true);

                barFormationCHG.SetTitelColor(SelectColor);
                this.Text = CAuthority.GetWindowsText(_CtrlFormationCHG.ToString());
            }
            else if (title == _CtrlFormationHPC.Tag.ToString())
            {
                scMainPanel.Panel2.Controls.Add(_CtrlFormationHPC);
                _CtrlFormationHPC.InitLanguage();
                _CtrlFormationHPC.ProcessStart(true);

                barFormationHPC.SetTitelColor(SelectColor);
                this.Text = CAuthority.GetWindowsText(_CtrlFormationHPC.ToString());
            }

            CLogger.WriteLog(enLogLevel.Info, _MainFormText, $"FMSMonitoringUI - {this.Text}");
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

                //e.Accept = TrustCertificateDialog.ShowDialog(this, settings, 30000);
                TrustCertificateDialog dialog = new TrustCertificateDialog();
                dialog.StartPosition = FormStartPosition.CenterParent;
                e.Accept = dialog.ShowDialog(this, settings, 30000);

                if (settings.SaveToTrustList)
                {
                    e.Persist = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionDlg.Show(_MainFormText, ex);

                string log = string.Format("Application_UntrustedCertificate Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
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
                //strCurrentTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                strCurrentTime = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
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

#region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LoadTroubleEqpAlarm().GetAwaiter().GetResult();
                    }));

                    Thread.Sleep(3000);

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LoadTroubleAgingAlarm().GetAwaiter().GetResult();
                    }));

                    Thread.Sleep(3000);

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        // Main창에서 Alarm발생여부 Icon 표시
                        if (_TroubleEquipmentList.Count > 0 || _TroubleAgingList.Count > 0 || _TroubleConveyorList.Count > 0)
                            AlarmOccur.Visible = true;
                        else
                            AlarmOccur.Visible = false;
                    }));
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region LoadTroubleEqpAlarm
        private async Task LoadTroubleEqpAlarm()
        {
            //// Set Query
            StringBuilder strSQL = new StringBuilder();

            try
            {
                RESTClient rest = new RESTClient();                

                strSQL.Append(" SELECT A.id, A.eqp_id, A.eqp_status, A.eqp_name, A.eqp_name_local, A.eqp_trouble_code,");
                strSQL.Append("        B.trouble_category, B.trouble_name, B.trouble_name_local");
                strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_trouble    B");
                strSQL.Append("         ON A.eqp_type = B.eqp_type AND A.eqp_trouble_code = B.trouble_code");
                //필수값
                strSQL.Append(" WHERE (A.eqp_type NOT IN ('SCH', 'SCF', 'SCL'))");
                strSQL.Append("    AND ((A.eqp_type = 'HPC' AND A.unit_id IS NOT NULL)");
                strSQL.Append("      OR (A.eqp_type = 'CHG' AND A.unit_id IS NOT NULL)");
                strSQL.Append("      OR (A.eqp_type = 'MIC' AND A.unit_id IS NOT NULL)");
                strSQL.Append("      OR (A.eqp_type NOT IN ('HPC', 'CHG', 'MIC')))");
                strSQL.Append("    AND (A.eqp_status = 'T' OR A.eqp_status = 'F' OR A.eqp_status = 'F2')");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonTroubleEquipmentResponse result = rest.ConvertTroubleEquipment(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);

                        if (cbUsePopUp.Checked == true)
                        {
                            TroubleWindowShow(_TroubleEquipmentList);
                        }
                    }
                    else
                    {
                        string log = "ConvertTroubleEquipment : result is null";
                        CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                    }
                }
                else
                {
                    string log = "ConvertTroubleEquipment : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                }

                //rest = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadTroubleAlarm Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadTroubleAlarm Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region LoadTroubleAgingAlarm
        private async Task LoadTroubleAgingAlarm()
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();
                string type = string.Format("aging_type LIKE '{0}%'", "H");

                strSQL.Append(" SELECT A.aging_type, A.line, A.lane, A.bay, A.floor, A.rack_id, A.status, A.trouble_code,");
                strSQL.Append("        B.trouble_name, B.trouble_name_local");
                strSQL.Append(" FROM fms_v.tb_mst_aging   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_trouble    B");
                strSQL.Append("         ON concat(A.aging_type, 'TA') = B.eqp_type AND A.trouble_code = B.trouble_code");
                //필수값
                strSQL.Append(" WHERE (A.status = 'T' AND concat(A.aging_type,'TA') = B.eqp_type)");
                strSQL.Append("    OR (A.fire_flag = 'Y' AND concat(A.aging_type,'TA') = B.eqp_type)");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonTroubleAgingResponse result = rest.ConvertTroubleAging(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);

                        if (cbUsePopUp.Checked == true)
                        {
                            TroubleWindowShow(_TroubleAgingList);
                        }
                    }
                    else
                    {
                        string log = "ConvertTroubleAging : result is null";
                        CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                    }
                }
                else
                {
                    string log = "ConvertTroubleAging : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadTroubleAgingAlarm Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadTroubleAgingAlarm Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region ReadTroubleName
        private async Task ReadTroubleName(string eqpType, int controlNo, string troubleCode)
        {
            try
            {
                if (troubleCode == "0")     // Trouble 해제
                {
                    _TroubleConveyorList.Remove(controlNo.ToString());
                    return;
                }

                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT trouble_category, trouble_name, trouble_name_local");
                strSQL.Append(" FROM fms_v.tb_mst_trouble");
                //필수값
                strSQL.Append($" WHERE eqp_type = '{eqpType}' AND trouble_code = '{troubleCode}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonTroubleConveyorResponse result = rest.ConvertTroubleConveyor(jsonResult);

                    if (result != null)
                    {
                        if (result.DATA.Count > 0)
                        {
                            result.DATA[0].ID = controlNo;
                            result.DATA[0].EQP_ID = eqpType + controlNo;
                            result.DATA[0].EQP_NAME = eqpType + controlNo;
                            result.DATA[0].EQP_NAME_LOCAL = eqpType + controlNo;
                        }
                        else
                        {
                            _trouble_conveyor_list cvItem = new _trouble_conveyor_list();
                            cvItem.EQP_STATUS = "T";
                            cvItem.EQP_TROUBLE_CODE = troubleCode;
                            cvItem.TROUBLE_NAME = $"Trouble Code : {troubleCode}";
                            cvItem.TROUBLE_NAME_LOCAL = $"Trouble Code : {troubleCode}";

                            result.DATA.Add(cvItem);

                            result.DATA[0].ID = controlNo;
                            result.DATA[0].EQP_ID = eqpType + controlNo;
                            result.DATA[0].EQP_NAME = eqpType + controlNo;
                            result.DATA[0].EQP_NAME_LOCAL = eqpType + controlNo;
                        }

                        SetData(result.DATA);

                        if (cbUsePopUp.Checked == true)
                        {
                            TroubleWindowShow(_TroubleConveyorList);
                        }
                    }
                    else
                    {
                        string log = "ConvertTroubleAging : result is null";
                        CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                    }
                }
                else
                {
                    string log = "ConvertTroubleAging : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadTroubleAgingAlarm Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadTroubleAgingAlarm Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region SetData
        public void SetData(List<_trouble_equipment_list> data)
        {
            if (data == null || data.Count == 0)
            {
                _TroubleEquipmentList.Clear();
                return;
            }

            bool bStatus = true;
            bool bStatusPrev = false;

            // 설비에서 Alarm 해지 시 _TroubleEquipmentList에서도 제거해 준다.
            for (int i = 0; i < _TroubleEquipmentList.Count; i++)
            {
                int nEqpTypeID = Convert.ToInt16(_TroubleEquipmentList.Keys.ToList()[i]);

                var varTemp = data.FirstOrDefault(t => t.ID == nEqpTypeID);

                if (varTemp == null)
                {
                    _TroubleEquipmentList.Remove(nEqpTypeID.ToString());
                }
            }

            foreach (var item in data)
            {
                bStatus = true;         //
                bStatusPrev = false;

                if (_TroubleEquipmentList.ContainsKey(item.ID.ToString()) == false)
                {
                    TroubleListAdd(item, bStatus, bStatusPrev);
                }
                else
                {
                    var varTemp = _TroubleEquipmentList[item.ID.ToString()];

                    varTemp.bStatusPrev = varTemp.bStatus;
                    varTemp.bStatus = bStatus;
                    varTemp.strStatus = item.EQP_STATUS == "T" ? "TROUBLE" : "FIRE";
                    if (varTemp.strStatus == "TROUBLE")
                        varTemp.strContent = CDefine.m_enLanguage == enLoginLanguage.English ? item.TROUBLE_NAME : item.TROUBLE_NAME_LOCAL;
                    else
                        varTemp.strContent = "FIRE";
                    varTemp.strTroubleCode = item.EQP_TROUBLE_CODE;
                    //varTemp.nAlarmCnt++;
                }
            }
        }

        public void SetData(List<_trouble_aging_list> data)
        {
            if (data == null || data.Count == 0)
            {
                _TroubleAgingList.Clear();
                return;
            }

            bool bStatus = true;
            bool bStatusPrev = false;

            // 설비에서 Alarm 해지 시 _TroubleAgingList 제거해 준다.
            for (int i = 0; i < _TroubleAgingList.Count; i++)
            {
                string strUnitID = _TroubleAgingList.Keys.ToList()[i];

                var varTemp = data.FirstOrDefault(t => t.RACK_ID == strUnitID);

                if (varTemp == null)
                {
                    _TroubleAgingList.Remove(strUnitID);
                }
            }

            foreach (var item in data)
            {
                bStatus = true;         //
                bStatusPrev = false;

                if (_TroubleAgingList.ContainsKey(item.RACK_ID) == false)
                {
                    TroubleListAdd(item, bStatus, bStatusPrev);
                }
                else
                {
                    var varTemp = _TroubleAgingList[item.RACK_ID];

                    varTemp.bStatusPrev = varTemp.bStatus;
                    varTemp.bStatus = bStatus;
                    varTemp.strStatus = item.STATUS == "T" ? "TROUBLE" : "";
                    varTemp.strContent = CDefine.m_enLanguage == enLoginLanguage.English ? item.TROUBLE_NAME : item.TROUBLE_NAME_LOCAL;
                    varTemp.strTroubleCode = item.TROUBLE_CODE;
                    varTemp.nAlarmCnt++;
                }
            }
        }

        public void SetData(List<_trouble_conveyor_list> data)
        {

            //if (data == null || data.Count == 0)
            //{
            //    _TroubleConveyorList.Clear();
            //    return;
            //}

            bool bStatus = true;
            bool bStatusPrev = false;

            // 설비에서 Alarm 해지 시 _TroubleConveyorList 제거해 준다.
            //for (int i = 0; i < _TroubleConveyorList.Count; i++)
            //{
            //    int nEqpTypeID = Convert.ToInt16(_TroubleConveyorList.Keys.ToList()[i]);

            //    var varTemp = data.FirstOrDefault(t => t.ID == nEqpTypeID);

            //    if (varTemp == null)
            //    {
            //        _TroubleConveyorList.Remove(nEqpTypeID.ToString());
            //    }
            //}

            foreach (var item in data)
            {
                bStatus = true;         //
                bStatusPrev = false;

                if (_TroubleConveyorList.ContainsKey(item.ID.ToString()) == false)
                {
                    TroubleListAdd(item, bStatus, bStatusPrev);
                }
                else
                {
                    var varTemp = _TroubleConveyorList[item.ID.ToString()];

                    varTemp.bStatusPrev = varTemp.bStatus;
                    varTemp.bStatus = bStatus;
                    varTemp.strStatus = item.EQP_STATUS == "T" ? "TROUBLE" : "FIRE";
                    if (varTemp.strStatus == "TROUBLE")
                        varTemp.strContent = CDefine.m_enLanguage == enLoginLanguage.English ? item.TROUBLE_NAME : item.TROUBLE_NAME_LOCAL;
                    else
                        varTemp.strContent = "FIRE";
                    varTemp.strTroubleCode = item.EQP_TROUBLE_CODE;
                    //varTemp.nAlarmCnt++;
                }
            }
        }
#endregion


#region Trouble List Add
        /////////////////////////////////////////////////////////////////////
        //	Trouble Equipment List Add
        //===================================================================
        private void TroubleListAdd(_trouble_equipment_list troubleData, bool bStatus, bool bStatusPrev)
        {
            try
            {
                string strTroubleStatus;
                if (troubleData.EQP_STATUS == "T")
                    strTroubleStatus = CDefine.m_enLanguage == enLoginLanguage.English ? troubleData.TROUBLE_NAME : troubleData.TROUBLE_NAME_LOCAL;
                else
                    strTroubleStatus = "FIRE";
                // Add Data
                CTroubleEquipmentList troubleList = new CTroubleEquipmentList
                {                    
                    nEqpTypeID = troubleData.ID,
                    strEqpID = troubleData.EQP_ID,
                    strUnitName = CDefine.m_enLanguage == enLoginLanguage.English ? troubleData.EQP_NAME : troubleData.EQP_NAME_LOCAL,
                    bStatus = bStatus,
                    bStatusPrev = bStatusPrev,
                    strStatus = troubleData.EQP_STATUS == "T" ? "TROUBLE" : "FIRE",
                    strContent = strTroubleStatus,
                    strTroubleCode = troubleData.EQP_TROUBLE_CODE,
                    nAlarmCnt = 1
                };

                _TroubleEquipmentList.Add(troubleData.ID.ToString(), troubleList);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("TroubleEquipmentListAdd Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("TroubleEquipmentListAdd Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
        /////////////////////////////////////////////////////////////////////
        //	Trouble Aging List Add
        //===================================================================
        private void TroubleListAdd(_trouble_aging_list troubleData, bool bStatus, bool bStatusPrev)
        {
            try
            {
                string rackName = string.Format($"{troubleData.AGING_TYPE}T-{troubleData.LINE}Line-{troubleData.LANE}Lane-{troubleData.BAY}Bay-{troubleData.FLOOR}F");
                // Add Data
                CTroubleEquipmentList troubleList = new CTroubleEquipmentList
                {
                    strUnitID = troubleData.RACK_ID,
                    strUnitName = rackName,
                    bStatus = bStatus,
                    bStatusPrev = bStatusPrev,
                    strStatus = troubleData.STATUS == "T" ? "TROUBLE" : "",
                    strContent = CDefine.m_enLanguage == enLoginLanguage.English ? troubleData.TROUBLE_NAME : troubleData.TROUBLE_NAME_LOCAL,
                    strTroubleCode = troubleData.TROUBLE_CODE,
                    nAlarmCnt = 1
                };

                _TroubleAgingList.Add(troubleData.RACK_ID, troubleList);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("TroubleAgingListAdd Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("TroubleAgingListAdd Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
        /////////////////////////////////////////////////////////////////////
        //	Trouble Conveyor List Add
        //===================================================================
        private void TroubleListAdd(_trouble_conveyor_list troubleData, bool bStatus, bool bStatusPrev)
        {
            try
            {
                string strTroubleStatus;
                if (troubleData.EQP_STATUS == "T")
                    strTroubleStatus = CDefine.m_enLanguage == enLoginLanguage.English ? troubleData.TROUBLE_NAME : troubleData.TROUBLE_NAME_LOCAL;
                else
                    strTroubleStatus = "FIRE";

                // Add Data
                CTroubleEquipmentList troubleList = new CTroubleEquipmentList
                {
                    nEqpTypeID = troubleData.ID,
                    strEqpID = troubleData.EQP_ID,
                    strUnitName = CDefine.m_enLanguage == enLoginLanguage.English ? troubleData.EQP_NAME : troubleData.EQP_NAME_LOCAL,
                    bStatus = bStatus,
                    bStatusPrev = bStatusPrev,
                    strStatus = troubleData.EQP_STATUS == "T" ? "TROUBLE" : "FIRE",
                    strContent = strTroubleStatus,
                    strTroubleCode = troubleData.EQP_TROUBLE_CODE,
                    nAlarmCnt = 1
                };

                _TroubleConveyorList.Add(troubleData.ID.ToString(), troubleList);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("TroubleConveyorListAdd Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("TroubleConveyorListAdd Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region [Trouble WIndow Show]
        /////////////////////////////////////////////////////////////////////
        //	Trouble WIndow Show
        //===================================================================
        //private void TroubleWindowShow()
        //{
        //    try
        //    {
        //        foreach (var trouble in _TroubleEquipmentList)
        //        {  

        //            if (trouble.Value.bStatus != trouble.Value.bStatusPrev ||
        //                trouble.Value.strTroubleCode != trouble.Value.strTroubleCodePrev)
        //            {
        //                string troubleTitle = $"{trouble.Value.strUnitName}_{trouble.Value.strTroubleCode}";

        //                trouble.Value.strTroubleCodePrev = trouble.Value.strTroubleCode;
        //                trouble.Value.bStatusPrev = trouble.Value.bStatus;

        //                if (_TroublePopupList.Contains(troubleTitle))
        //                {
        //                    continue;   // 동일 Trouble 발생시 Popup창이 띄워져 있으면 새로 호출하지 않도록 한다.
        //                }            

        //                if (trouble.Value.bStatus == true)
        //                {
        //                    WinTroubleAlarm troubleAlarm = new WinTroubleAlarm();
        //                    troubleAlarm.SetTroubleInfo(trouble.Value.strContent, trouble.Value.strUnitName, trouble.Value.strTroubleCode);
        //                    troubleAlarm.TroubleCloseEvent += TroubleAlarm_TroubleCloseEvent;
        //                    troubleAlarm.Show();

        //                    //troubleAlarm.lblTroubleName.Text = trouble.Value.strContent;
        //                    //troubleAlarm.lblTroubleName.AutoSize = true;
        //                    //troubleAlarm.AutoFontSize(troubleAlarm.lblTroubleName, trouble.Value.strContent);
        //                    //troubleAlarm.lblTroubleUnitName.Text = trouble.Value.strUnitName;

        //                    string log = string.Format("TroubleWindowShow : EQP ID = {0}, Unit ID = {1}, Alarm Code = {2}, Alarm Name = {3}",
        //                        _CtrlMonitoring._EqpName[trouble.Value.strEqpID], trouble.Value.strUnitName,
        //                        trouble.Value.strTroubleCode, trouble.Value.strContent);

        //                    CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);

        //                    _TroublePopupList.Add(troubleTitle);
        //                }
        //            }
        //        }

        //        foreach (var trouble in _TroubleAgingList)
        //        {
        //            if (trouble.Value.bStatus != trouble.Value.bStatusPrev ||
        //                trouble.Value.strTroubleCode != trouble.Value.strTroubleCodePrev)
        //            {
        //                string troubleTitle = $"{trouble.Value.strUnitName}_{trouble.Value.strTroubleCode}";

        //                trouble.Value.bStatusPrev = trouble.Value.bStatus;
        //                trouble.Value.strTroubleCodePrev = trouble.Value.strTroubleCode;

        //                if (_TroublePopupList.Contains(troubleTitle))
        //                {
        //                    continue;   // 동일 Trouble 발생시 Popup창이 띄워져 있으면 새로 호출하지 않도록 한다.
        //                }

        //                if (trouble.Value.bStatus == true)
        //                {
        //                    WinTroubleAlarm troubleAlarm = new WinTroubleAlarm();

        //                    troubleAlarm.TroubleCloseEvent += TroubleAlarm_TroubleCloseEvent;
        //                    troubleAlarm.Show();

        //                    troubleAlarm.lblTroubleName.Text = trouble.Value.strContent;
        //                    troubleAlarm.lblTroubleUnitName.Text = trouble.Value.strUnitName;

        //                    string log = string.Format("TroubleWindowShow : EQP ID = {0}, Unit ID = {1}, Alarm Code = {2}, Alarm Name = {3}",
        //                        _CtrlMonitoring._EqpName[trouble.Value.strEqpID], trouble.Value.strUnitName,
        //                        trouble.Value.strTroubleCode, trouble.Value.strContent);

        //                    CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);

        //                    _TroublePopupList.Add(troubleTitle);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // System Debug
        //        System.Diagnostics.Debug.Print(string.Format("TroubleWindowShow Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

        //        string log = string.Format("TroubleWindowShow Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
        //        CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
        //    }
        //}
        private void TroubleWindowShow(Dictionary<string, CTroubleEquipmentList> troubleList)
        {
            try
            {
                foreach (var trouble in troubleList)
                {

                    if (trouble.Value.bStatus != trouble.Value.bStatusPrev ||
                        trouble.Value.strTroubleCode != trouble.Value.strTroubleCodePrev)
                    {
                        string troubleTitle = $"{trouble.Value.strUnitName}_{trouble.Value.strTroubleCode}";

                        trouble.Value.strTroubleCodePrev = trouble.Value.strTroubleCode;
                        trouble.Value.bStatusPrev = trouble.Value.bStatus;

                        if (_TroublePopupList.Contains(troubleTitle))
                        {
                            continue;   // 동일 Trouble 발생시 Popup창이 띄워져 있으면 새로 호출하지 않도록 한다.
                        }

                        if (trouble.Value.bStatus == true)
                        {
                            WinTroubleAlarm troubleAlarm = new WinTroubleAlarm();
                            troubleAlarm.SetTroubleInfo(trouble.Value.strContent, trouble.Value.strUnitName, trouble.Value.strTroubleCode);
                            troubleAlarm.TroubleCloseEvent += TroubleAlarm_TroubleCloseEvent;
                            troubleAlarm.Show();

                            string log = string.Format("TroubleWindowShow : EQP ID = {0}, Unit ID = {1}, Alarm Code = {2}, Alarm Name = {3}",
                                _CtrlMonitoring._EqpName[trouble.Value.strEqpID], trouble.Value.strUnitName,
                                trouble.Value.strTroubleCode, trouble.Value.strContent);

                            CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);

                            _TroublePopupList.Add(troubleTitle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("TroubleWindowShow Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("TroubleWindowShow Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }

#endregion

#region LoadEqpName
        private async Task LoadEqpName()
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT eqp_name, eqp_name_local, IF(unit_id IS NULL, eqp_id, unit_id) AS eqp_id");
                strSQL.Append(" FROM fms_v.tb_mst_eqp");
                //필수값
                //strSQL.Append($" WHERE unit_id IS NULL");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonMstEqpResponse result = rest.ConvertMstEqp(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertMstEqp : jsonResult is null";
                        CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                    }
                }
                else
                {
                    string log = "ConvertMstEqp : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadEqpName Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadEqpName Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region SetData
        public void SetData(List<_mst_eqp> data)
        {
            if (data == null || data.Count == 0) return;

            Dictionary<string, string > dict = new Dictionary<string, string>();
            foreach (var item in data)
            {
                if (CDefine.m_enLanguage == enLoginLanguage.English)
                {
                    dict.Add(item.EQP_ID, item.EQP_NAME);
                }
                else
                {
                    dict.Add(item.EQP_ID, item.EQP_NAME_LOCAL);
                }
            }

            _CtrlMonitoring._EqpName = dict;
            _CtrlAging._EqpName = dict;
            _CtrlFormationCHG._EqpName = dict;
            _CtrlFormationHPC._EqpName = dict;
        }
#endregion

#region Event
        private void TroubleAlarm_TroubleCloseEvent(string troubleTitle)
        {
            _TroublePopupList.Remove(troubleTitle);
        }

        private void _CtrlMonitoring_TroubleOccurEvent(string eqpType, int controlNo, string troubleCode)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                ReadTroubleName(eqpType, controlNo, troubleCode).GetAwaiter().GetResult();
            }));

            //string troubleTitle = $"{unitName}_{troubleCode}";


        }
#endregion

#region LogOutThreadCallback
        private void LogOutThreadCallback()
        {
            try
            {
                while (true)
                {
                    GC.Collect();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LogOut();
                    }));

                    Thread.Sleep(60000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("LogOutThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LogOutThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region LogOut
        public void LogOut()
        {
            try
            {

                if (_LogOutCount > (48 * 60))  // 2day
                {
                    CDefine.m_strLoginID = "";
                    lbUserName.Text = "LogOut";
                    ProgramRestart();

                    string log = string.Format("Logged out due to timeout.");
                    CLogger.WriteLog(enLogLevel.Info, _MainFormText, log);
                }
                else
                {
                    //_LogOutCount++;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LogOut Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LogOut Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }
#endregion

#region 윈도우 프로시저 처리하기 - WndProc(message)
        /// <summary>
        /// 윈도우 프로시저 처리하기
        /// </summary>
        /// <param name="message">메시지</param>
        //protected override void WndProc(ref Message message)
        //{
        //    const uint WM_MOUSEACTIVATE = 0x0021;
        //    const uint WM_MOUSEMOVE = 0x0200;

        //    if (message.Msg == WM_MOUSEACTIVATE || message.Msg == WM_MOUSEMOVE)
        //    {
        //        _LogOutCount = 0;
        //    }

        //    base.WndProc(ref message);
        //}
#endregion

        private void ProgramRestart()
        {
            try
            {
                Application.EnableVisualStyles();

                Application.Restart();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("ProgramRestart Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProgramRestart Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, _MainFormText, log);
            }
        }

#region LogIn_Click
        private void LogIn_Click(object sender, EventArgs e)
        {
            CheckLogin();

            InitLanguage();

            //this.Invoke(new MethodInvoker(delegate ()
            //{
            //if (this.Text.Substring(0, 9) == "[MON-001]")
            {
                    _CtrlMonitoring.InitLanguage();
                }
                //else if (this.Text.Substring(0, 9) == "[MON-002]")
                {
                    _CtrlAging.InitLanguage();
                }
                //else if (this.Text.Substring(0, 9) == "[MON-003]")
                {
                    _CtrlFormationCHG.InitLanguage();
                }
                //else if (this.Text.Substring(0, 9) == "[MON-004]")
                {
                    _CtrlFormationHPC.InitLanguage();
                }
            //}));
        }
#endregion

#region lbVersionInfo_Click
        private void lbVersionInfo_Click(object sender, EventArgs e)
        {
            WinVersionHistory form = new WinVersionHistory();
            form.Show();
        }
#endregion
    }
}
