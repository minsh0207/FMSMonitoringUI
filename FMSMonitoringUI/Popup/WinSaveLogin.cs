/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : WinSaveLogin
//  Create Date	    : 2018.10.25
//  Author			: LSY
//  Remark			: 
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MonitoringUI.Common;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI.Controlls.CButton;
using MonitoringUI.Controlls.CComboBox;
#endregion

#region [NameSpace]
namespace MonitoringUI.Popup
{
    #region [Class]
    public partial class WinSaveLogin : WinFormRoot
    {
        #region [Variable]
        /////////////////////////////////////////////////////////////////////
        //	Variable
        //===================================================================
        private bool m_bHotKey = false;
        #endregion

        #region [Constructor]
        public WinSaveLogin()
        {
            InitializeComponent();

            CDefine.m_strSaveLoginID = "";
            CDefine.m_strSaveLoginPass = "";
            CDefine.m_strSaveLoginName = "";
            CDefine.m_strSaveLoginClass = "";

            Initialize();
        }
        #endregion

        #region [Window Event]
        #region [Loaded Window_Loaded]
        /////////////////////////////////////////////////////////////////////
        //	Loaded
        //===================================================================
        private void Window_Loaded(object sender, EventArgs e)
        {
            try
            {
                // 화면ID 설정
                //this.Tag = CDataBase.DBLoadWindowID(this.ToString());
                this.StartPosition = FormStartPosition.CenterParent;
                // Init
                InitControl();
                InitLanguage();
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Window Loaded Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.Error, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "Window_Loaded Error Exception : " + ex.Message);
            }
        }
        #endregion

        #region [Window Closed]
        private void Window_Closed(object sender, FormClosedEventArgs e)
        {
        }
        #endregion
        #endregion

        #region [Init]
        #region [Initialize]
        /////////////////////////////////////////////////////////////////////
        //	Init Control
        //===================================================================
        private void Initialize()
        {
            try
            {
                btConfirm.LabelText = LocalLanguage.GetItemString("DEF_CONTROL_007"); // 로그인

                btConfirm.Click += btnLogin_Click;
                btExit.Click += btnExit_Click;

            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Initialize Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                //CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "InitControl Error Exception : " + ex.Message);
            }
        }
        #endregion

        #region [InitControl]
        /////////////////////////////////////////////////////////////////////
        //	Init Control
        //===================================================================
        private void InitControl()
        {
            try
            {
                //Set This Focus
                this.Focus();

                tbPassword.OnTextBoxKeyDownEvent += TbPassword_KeyDown;
                tbPassword.OnTextBoxDoubleClickEvent += TbPassword_DoubleClick;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Window Init Control Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                //CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "InitControl Error Exception : " + ex.Message);
            }
        }
        #endregion

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
        #endregion

        #region [Button & Action Event]
        #region [Login Event]
        /////////////////////////////////////////////////////////////////////
        //	Login Event
        //===================================================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn().GetAwaiter().GetResult();

            this.Close();
        }
        #endregion

        #region [Exit Event]
        /////////////////////////////////////////////////////////////////////
        //	Exit Event
        //===================================================================
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            // 윈도우 종료
            this.Close();
        }
        #endregion

        #region [Password MouseDoubleClick Event]
        /////////////////////////////////////////////////////////////////////
        //	Password MouseDoubleClick Event 
        //===================================================================
        private void TbPassword_DoubleClick(object sender, EventArgs e)
        {
            if (m_bHotKey)
            {
                tbLoginID.TextData = "MSH";
                tbPassword.TextData = "1";

                // Login
                btnLogin_Click(sender, e);
            }
        }
        #endregion
        #endregion

        #region [Key Event]
        #region [txt Password KeyDown]
        /////////////////////////////////////////////////////////////////////
        //	Password KeyDown
        //===================================================================
        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
#if (DEBUG)
            // Alt + Control Key 입력시
           if (e.KeyCode == Keys.ControlKey)
            {
                m_bHotKey = true;
            }
#endif
            // Enter Key 입력시
            if (e.KeyCode == Keys.Enter)
            {
                // Login
                btnLogin_Click(sender, e);
            }
        }
        #endregion
        #endregion

        #region [Method]
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
                    this.DialogResult = DialogResult.No;
                    // Msg
                    CMessage.MsgInformation("Please enter your Login ID.");
                    return;
                }

                // Password Check
                //if (txtPassword.Text.Length < 1)
                if (tbPassword.TextData.Length < 1)
                {
                    this.DialogResult = DialogResult.No;
                    // Msg
                    CMessage.MsgInformation("Please enter your Password.");
                    return;
                }

                // Login
                //if (await m_user.UserSaveLogin(txtLoginID.Text, txtPassword.Text) != true)
                if (await CUser.UserMainLogin(tbLoginID.TextData, tbPassword.TextData, true) != true)
                {
                    this.DialogResult = DialogResult.No;

                    CMessage.MsgError("Please login After checking the user ID and Password.");
                    return;
                }

                this.DialogResult = DialogResult.Yes;

                // 종료
                //btnExit_Click(null, null);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### LogIn PopUP,  Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #endregion

        private void btConfirm_Load(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
#endregion