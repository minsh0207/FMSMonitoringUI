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
//using AutoUpdaterDotNET;
//using System.Windows.Input;

namespace MonitoringUI.Popup
{
    public partial class WinLogin : WinFormRoot
    {
        bool m_bHotKey = false;

        public WinLogin()
        {
            // AutoUpdater 설정
            // Release 일때만... 

            InitializeComponent();
            InitControl();


//#if (DEBUG == fasle)
//            AutoUpdater.Start("http://ecs-1-spare/MonitoringUI/MonitoringUI.xml");
//            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
//            AutoUpdater.Mandatory = true;
//            AutoUpdater.UpdateMode = Mode.Forced;
//#endif
        }

        private void InitControl()
        {
            btConfirm.LabelText = LocalLanguage.GetItemString("DEF_CONTROL_007"); //로그인
            btExit.LabelText = LocalLanguage.GetItemString("DEF_CONTROL_009"); //종료

            if (btConfirm.LabelText == "strConfirm") btConfirm.LabelText = "LogIn";
            if (btExit.LabelText == "strExit") btConfirm.LabelText = "Exit";

            btConfirm.Click += BtConfirm_Click;
            btExit.Click += BtExit_Click;

            tbPassword.OnTextBoxKeyDownEvent += TbPassword_KeyDown;
            tbPassword.OnTextBoxDoubleClickEvent += TbPassword_DoubleClick;
        }

        private void TbPassword_DoubleClick(object sender, EventArgs e)
        {
            if(m_bHotKey)
            {
                tbLoginID.TextData  = "DEVELOPER";
                tbPassword.TextData = "DEVELOPER";

                BtConfirm_Click(sender, e);
            }
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

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            if (tbLoginID.TextData.Length < 1 || tbPassword.TextData.Length < 1)
                return;

            if (rbLine1.Checked)
            {
                CDefine.m_strLineID = "001";
                CDefine.m_strBizRestURI = CUtills.GetAppConfig("BizRestUri_Area001");   //19.05.27 PYG BizRestURI를 AppConfig로 분리
            }
            else if (rbLine2.Checked)
            {
                CDefine.m_strLineID = "002";
                CDefine.m_strBizRestURI = CUtills.GetAppConfig("BizRestUri_Area002");   //19.05.27 PYG BizRestURI를 AppConfig로 분리
            }
                

            // 로그인 루틴
            LogIn().GetAwaiter().GetResult();

            CDefine.m_strLoginID = tbLoginID.TextData;

            CDatabaseRest.ResetBaseURI();

            switch (cbLanguage.SelectedItem.ToString())
            {
                case "CHINESE":
                    CDefine.m_enLanguage = enLoginLanguage.Chinese;
                    break;
                case "KOREAN":
                    CDefine.m_enLanguage = enLoginLanguage.Korean;
                    break;
                case "ENGLISH":
                    CDefine.m_enLanguage = enLoginLanguage.English;
                    break;

            }
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

#region [LogIn]
        private async Task LogIn()
        {
            try
            {
                //tbLginID.TextData
                //tbPassword.TextData
                // Login ID Check
                //if (txtLoginID.Text.Length < 1)
                if (tbLoginID.TextData.Length < 1)
                {
                    // Msg
                    CMessage.MsgInformation("Please enter your Login ID.");
                    return;
                }

                // Password Check
                //if (txtPassword.Text.Length < 1)
                if (tbPassword.TextData.Length < 1)
                {
                    // Msg
                    CMessage.MsgInformation("Please enter your Password.");
                    return;
                }

                // Login
                //if (await m_user.UserSaveLogin(txtLoginID.Text, txtPassword.Text) != true)
                if (await CUser.UserMainLogin(tbLoginID.TextData, tbPassword.TextData) != true)
                {
                    CMessage.MsgError("Please login After checking the user ID and Password.");
                    return;
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
