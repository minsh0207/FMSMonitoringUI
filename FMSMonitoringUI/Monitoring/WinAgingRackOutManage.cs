using MonitoringUI.Common;
using MonitoringUI.Popup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Monitoring
{
    public partial class WinAgingRackOutManage : WinFormRoot
    {
        string m_strAgingType;
        string m_strUnitID;
        string m_strTrayID;
        bool m_isEmptyTray;

        public WinAgingRackOutManage()
        {
            InitializeComponent();
        }

        public WinAgingRackOutManage(string strAgingType, string strUnitID, string strTrayID, string strRackName, DateTime startTime, DateTime planTime, string CurrProcName, string nextProcName, bool isEmptyTray)
        {

            InitializeComponent();

            m_strAgingType = strAgingType;
            m_strUnitID = strUnitID;
            m_strTrayID = strTrayID;
            m_isEmptyTray = isEmptyTray;


            ctrlTitleBar1.TitleText = LocalLanguage.GetItemString("strTrayOutManage"); // 출고시간 관리
            btOutNow.Text = LocalLanguage.GetItemString("strEmptyTrayOutImmediately");  // 지금 출고

            tbRackID.TextData = strRackName;
            tbTrayID.TextData = strTrayID;

            tbCurrentProcessName.TextData = CurrProcName;
            tbNextProcessName.TextData = nextProcName;

            dtStartTime.StartTime = startTime;
            dtPlanTime.PlanTime = planTime;

            btConfirm.Click += BtConfirm_Click;
            btExit.Click += BtExit_Click;

            btOutNow.Visible = false;
            if (m_isEmptyTray) btOutNow.Visible = true;



            /// 
            /// 화면권한 관련
            /// 
            bool bView = false;
            bool bSave = false;
            // 화면ID 설정
            Tag = CAuthority.WindowsNameToWindowID(this.GetType().FullName.ToString());

            // 여기서 상온6호기는 부모의 권한을 따라 가도록 하자. 
            // CDefine.DEF_WINDOW_MONI_WIN_AGING_RACK_SETTING
            if(isRT6Aging(m_strUnitID) ==true)
            {
                //Get Authority
                CAuthority.GetAuthority(CDefine.m_strLoginID, CDefine.DEF_WINDOW_MONI_WIN_AGING_RACK_SETTING, ref bView, ref bSave);
            } else
            {
                //Get Authority
                CAuthority.GetAuthority(CDefine.m_strLoginID, Tag.ToString(), ref bView, ref bSave);
            }
            
            this.WindowID = Tag.ToString();
            ///
            ///
            ///

            btConfirm.Enabled = bSave;
            btOutNow.Enabled = bSave;

            this.DialogResult = DialogResult.Cancel;

        }

        private bool isRT6Aging(string RackID)
        {
            if (RackID.Length < 8) return false;
            if (RackID.Substring(0, 1) == "H") return false;

            if (RackID.Substring(0, 3) == "R06") return true;

            return false;
        }

        private void btOutNow_Click(object sender, EventArgs e)
        {
            if (CMessage.MsgQuestionYN(LocalLanguage.GetItemString("DEF_MSG_29")).ToString().ToUpper() != "YES") return;

            //=======================================================================
            //  저장/삭제 사번 입력
            //-----------------------------------------------------------------------
            string strSaveUserID = null;
            string strEventStr = string.Empty;
            string strCommandInfo = string.Empty;
            string strSetSting = string.Empty;

            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID.Length < 1) return;
            strSaveUserID = CDefine.m_strSaveLoginID;

            ///
            bool bView = false;
            bool bSave = false;
            //Get Authority
            //CAuthority.GetAuthority(strSaveUserID, Tag.ToString(), ref bView, ref bSave);
            //20211112 KJY - 상온6호기는 부모 Window의 권한으로 처리한다.
            if (isRT6Aging(m_strUnitID) == true)
            {
                //Get Authority
                CAuthority.GetAuthority(CDefine.m_strLoginID, CDefine.DEF_WINDOW_MONI_WIN_AGING_RACK_SETTING, ref bView, ref bSave);
            }
            else
            {
                //Get Authority
                CAuthority.GetAuthority(CDefine.m_strLoginID, Tag.ToString(), ref bView, ref bSave);
            }
            if (bSave == false)
            {
                // 권한이 없습니다.
                CMessage.MsgError(LocalLanguage.GetItemString("strNoAuth"));
                return;
            }

            // tMastAgingRack 의 Status를 F로 바꾸고, EndTime에 현재시간을 저장한다.
            JObject jsonBody = new JObject();
            DateTime updtm = DateTime.Now;
            string UpdateTime = updtm.ToString("yyyy-MM-dd HH:mm:ss");
            string EndTime = updtm.ToString("yyyyMMddHHmmss");


            string strSet = $"Status = 'F', EndTime = '{EndTime}', UpdateTime = '{UpdateTime}' ";
            jsonBody["set"] = strSet;
            jsonBody["filter"] = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{m_strAgingType}' AND  RackID = '{m_strUnitID}' AND TrayID = '{m_strTrayID}'";

            strSetSting += $"[Tray Out Promptly:{jsonBody.ToString()}]";

            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = RestClient.JsonRequest(JsonApiType.Table, JsonCRUD.PATCH, "api.php/tMstAgingRack", jsonBody).GetAwaiter().GetResult();
                JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

                if (ret.code == 1) // Success
                {
                    CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.
                    strEventStr = $"[SEND_COMMAND] [AgingRack Setting] [{strSetSting}]";
                    CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                    CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                    //완료후 창닫기
                    this.DialogResult = DialogResult.OK;
                    BtExit_Click(sender, e);
                    return;
                }
                else
                {
                    CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                    strEventStr = $"[SEND_COMMAND:Fail] [AgingRack Setting] [{strSetSting}]";
                    CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                    CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                    return;
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:btOutNow_Click] {0}", ex.ToString()));
                return;
            }
        }
        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtConfirm_Click(object sender, EventArgs e)
        {
            if (CMessage.MsgQuestionYN(LocalLanguage.GetItemString("DEF_MSG_29")).ToString().ToUpper() != "YES") return;

            //=======================================================================
            //  저장/삭제 사번 입력
            //-----------------------------------------------------------------------
            string strSaveUserID = null;
            string strEventStr = string.Empty;
            string strCommandInfo = string.Empty;
            string strSetString = string.Empty;

            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID.Length < 1) return;
            strSaveUserID = CDefine.m_strSaveLoginID;


            //20211112 KJY - 상온6호기는 부모 Window의 권한으로 처리한다.
            bool bView = false;
            bool bSave = false;
            if (isRT6Aging(m_strUnitID) == true)
            {
                //Get Authority
                CAuthority.GetAuthority(strSaveUserID, CDefine.DEF_WINDOW_MONI_WIN_AGING_RACK_SETTING, ref bView, ref bSave);
            }
            else
            {
                //Get Authority
                CAuthority.GetAuthority(strSaveUserID, Tag.ToString(), ref bView, ref bSave);
            }
            if (bSave == false)
            {
                // 권한이 없습니다.
                CMessage.MsgError(LocalLanguage.GetItemString("strNoAuth"));
                return;
            }


            strSetString = $"PlanTime: {dtPlanTime.PlanTime.ToString()}";

            // DB정보 update
            if (SaveRackInfo().GetAwaiter().GetResult())
            {
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.
                strEventStr = $"[Change Tray Out Plan Time]  [{strSetString}]";
                CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                //완료후 창닫기
                this.DialogResult = DialogResult.OK;
                BtExit_Click(sender, e);
                return;

            }
            else
            {
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                strEventStr = $"[SEND_COMMAND:Fail] [AgingRack Setting] [{strSetString}]";
                CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                return;
            }

        }
        private async Task<bool> SaveRackInfo()
        {
            JObject jsonBody = new JObject();
            string strSet = string.Empty;

            DateTime updtm = DateTime.Now;
            string UpdateTime = updtm.ToString("yyyy-MM-dd HH:mm:ss");

            string strSetString = string.Empty;

           
            // PlanTime 조정
            DateTime dt = dtPlanTime.PlanTime;
            string PlanTime = dt.ToString("yyyyMMddHHmm00");

            if (strSet.Length > 0)
                strSet = strSet + $", EndTime = '{PlanTime}' ";
            else
                strSet = $"EndTime = '{PlanTime}', UpdateTime = '{UpdateTime}' ";



            
            // Rest Server V.2.x 에서는 set과 filter 가 필요하다.
            if (strSet.Length <= 0)
                return false;

            jsonBody["set"] = strSet;
            jsonBody["filter"] = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{m_strAgingType}' AND RackID = '{m_strUnitID}' ";

            strSetString += $"[SAVE:{jsonBody.ToString()}]";

            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = await RestClient.JsonRequest(JsonApiType.Table, JsonCRUD.PATCH, "api.php/tMstAgingRack", jsonBody);
                JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

                if (ret.code == 1) // Success
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:GetRAckInfo] {0}", e.ToString()));
                return false;
            }

            
            

        }
    }
}
