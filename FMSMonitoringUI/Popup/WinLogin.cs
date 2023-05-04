using MonitoringUI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitoringUI.Controlls.CComboBox;
using System.Resources;
using System.Threading;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using AutoUpdaterDotNET;
//using System.Windows.Input;

namespace MonitoringUI.Popup
{
    public partial class WinLogin : WinFormRoot
    {
        bool m_bHotKey = false;
        int m_RetryCount = 0;

        public WinLogin()
        {
            // AutoUpdater 설정
            // Release 일때만... 

            InitializeComponent();

#if (DEBUG == fasle)
            AutoUpdater.Start("http://ecs-1-spare/MonitoringUI/MonitoringUI.xml");
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.Forced;
#endif
        }

        #region WinLogin Load
        private void WinLogin_Load(object sender, EventArgs e)
        {
            InitControl();
            InitLanguage();
        }
        #endregion

        private void InitControl()
        {
            cbLanguage_SelectedIndexChanged(CDefine.m_strLanguage, "");

            var dt = TableLanguage();
            cbLanguage.DataSource(dt);

            btConfirm.Click += BtConfirm_Click;
            btExit.Click += BtExit_Click;

            tbPassword.OnTextBoxKeyDownEvent += TbPassword_KeyDown;
            tbPassword.OnTextBoxDoubleClickEvent += TbPassword_DoubleClick;

            if (CDefine.m_enLanguage == enLoginLanguage.English)
                cbLanguage.SelectedIndex = 0;
            else if (CDefine.m_enLanguage == enLoginLanguage.France)
                cbLanguage.SelectedIndex = 1;

            cbLanguage.OnCboItemChanged += cbLanguage_SelectedIndexChanged;            
        }

        #region InitLanguage
        private void InitLanguage()
        {
            // CtrlTaggingName 언어 변환 호출
            foreach (var ctl in panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlTextBox))
                {
                    CtrlTextBox tagName = ctl as CtrlTextBox;
                    tagName.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlButton))
                {
                    CtrlButton tagName = ctl as CtrlButton;
                    tagName.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlComboBox))
                {
                    CtrlComboBox tagName = ctl as CtrlComboBox;
                    tagName.CallLocalLanguage();
                }
            }
        }
        #endregion

        private void TbPassword_DoubleClick(object sender, EventArgs e)
        {
#if (DEBUG)
            if (m_bHotKey)
            {
                tbLoginID.TextData  = "DEV";
                tbPassword.TextData = "1";

                BtConfirm_Click(sender, e);
            }
#endif
        }

        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
#if (DEBUG)
            if (e.KeyCode == Keys.ControlKey)
                m_bHotKey = true;
            else
                m_bHotKey = false;
#endif
            // Enter Key 입력시
            if(e.KeyCode == Keys.Enter)
            {
                BtConfirm_Click(sender, e);
            }

        }

        private void cbLanguage_SelectedIndexChanged(string ItemID, string ItemName)
        {
            if (ItemID == enLoginLanguage.France.ToString())
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
                CDefine.m_enLanguage = enLoginLanguage.France;
                CDefine.m_strLanguage = enLoginLanguage.France.ToString();
            }
            else if (ItemID == enLoginLanguage.English.ToString())
            {
                CDefine.m_enLanguage = enLoginLanguage.English;
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                CDefine.m_strLanguage = enLoginLanguage.English.ToString();
            }
            

            //switch (ItemID)
            //{
            //    case "FRANCE":
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            //        CDefine.m_enLanguage = enLoginLanguage.France;
            //        break;
            //    case "KOREAN":
            //        CDefine.m_enLanguage = enLoginLanguage.Korean;
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //        break;
            //    case "ENGLISH":
            //        CDefine.m_enLanguage = enLoginLanguage.English;
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //        break;

            //}

            LocalLanguage.resxLanguage = new ResourceManager("MonitoringUI.WinFormRoot", typeof(WinFormRoot).Assembly);

            InitLanguage();

            Refresh();
        }

        private DataTable TableLanguage()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            //dt.Rows.Add("CHINESE", "CHINESE");
            //dt.Rows.Add("KOREAN", "KOREAN");
            dt.Rows.Add(enLoginLanguage.English.ToString(), enLoginLanguage.English.ToString());
            dt.Rows.Add(enLoginLanguage.France.ToString(), enLoginLanguage.France.ToString());

            return dt;
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            if (tbLoginID.TextData.Length < 1 || tbPassword.TextData.Length < 1)
                return;

            //if (rbLine1.Checked)
            //{
            //    CDefine.m_strLineID = "001";
            //    CDefine.m_strBizRestURI = CUtills.GetAppConfig("BizRestUri_Area001");   //19.05.27 PYG BizRestURI를 AppConfig로 분리
            //}
            //else if (rbLine2.Checked)
            //{
            //    CDefine.m_strLineID = "002";
            //    CDefine.m_strBizRestURI = CUtills.GetAppConfig("BizRestUri_Area002");   //19.05.27 PYG BizRestURI를 AppConfig로 분리
            //}
                

            // 로그인 루틴
            LogIn().GetAwaiter().GetResult();

            //CDefine.m_strLoginID = tbLoginID.TextData;

            //CDatabaseRest.ResetBaseURI();

            //switch (cbLanguage.SelectedItem.ToString())
            //{
            //    case "FRANCE":
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            //        CDefine.m_enLanguage = enLoginLanguage.France;
            //        break;
            //    case "KOREAN":
            //        CDefine.m_enLanguage = enLoginLanguage.Korean;
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //        break;
            //    case "ENGLISH":
            //        CDefine.m_enLanguage = enLoginLanguage.English;
            //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");                    
            //        break;

            //}

            //LocalLanguage.resxLanguage = new ResourceManager("MonitoringUI.WinFormRoot", typeof(WinFormRoot).Assembly);

            if (m_RetryCount >= 5)      // Password Check 횟수
            {
                this.Close();
            }
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region LogIn
        private async Task LogIn()
        {
            try
            {
                if (tbLoginID.TextData.Length < 1)
                {
                    // Msg
                    CMessage.MsgInformation("Please enter your Login ID.");
                    return;
                }

                // Password Check
                if (tbPassword.TextData.Length < 1)
                {
                    // Msg
                    CMessage.MsgInformation("Please enter your Password.");
                    return;
                }

                // Login
                if (await CUser.UserMainLogin(tbLoginID.TextData, tbPassword.TextData) == false)
                {
                    m_RetryCount++;
                    CMessage.MsgError($"Please login After checking the user ID and Password.[{m_RetryCount}/5]");
                    return;
                }
                else
                {
                    if (CDefine.m_strLoginID == CDefine.m_strLoginPass)
                    {
                        CMessage.MsgError($"Please Change the password in WebUI.");
                    }
                }

                // 종료
                BtExit_Click(null, null);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### LogIn PopUP,  Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion
    }
}
