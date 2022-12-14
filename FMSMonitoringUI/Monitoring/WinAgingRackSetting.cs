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
    public partial class WinAgingRackSetting : WinFormRoot
    {
        private string m_strAgingType = string.Empty;
        private string m_strUnitID = string.Empty;
        private string m_strTrayID = string.Empty;
        private string m_strHogi = string.Empty;
        private string m_strLine = string.Empty;
        private string m_strBay = string.Empty;
        private string m_strRack = string.Empty;

        //20200401 KJY for Status (출고지연 알람상태전달을 위해)
        private string m_strStatus = string.Empty;

        JsonTray m_jsonTray = null;
        JsonAgingRack m_jsonAgingRackInfo = null;
        JsonRouteOperList m_jsonRouteOper = null;

        private int m_nCurrentIndex = -1;

        string m_strSetStr = string.Empty;

        //RackID, TrayID, PlanTime, Status

        public WinAgingRackSetting()
        {
            InitializeComponent();
        }

        public WinAgingRackSetting(string strAgingType, string strUnitID, string strTrayID, string strStatus = "E")
        {
            this.m_strAgingType = strAgingType;
            this.m_strUnitID = strUnitID;
            this.m_strTrayID = strTrayID;

            //20200401 KJY for Status (출고지연 알람상태전달을 위해)  0이나 null이 아니면 alram off 를 보여주어야 한다.
            m_strStatus = strStatus;

            if (strAgingType.Length <1 || strUnitID.Length < 8 )
            {
                return;
            }

            m_strHogi = m_strUnitID.Substring(1, 2);
            m_strLine = m_strUnitID.Substring(3, 1);
            m_strBay = m_strUnitID.Substring(4, 2);
            m_strRack = m_strUnitID.Substring(6, 2);

            

            InitializeComponent();
            initControl();

            this.Tag = CDefine.DEF_WINDOW_MONI_WIN_AGING_RACK_SETTING;
        }

        private void initControl()
        {
            // language
            ctrlTitleBar1.TitleText = LocalLanguage.GetItemString("DEF_CONTROL_072"); // Aging Rack 설정
            rbNoIn.Text = LocalLanguage.GetItemString("DEF_CONTROL_074");  // 입고 금지
            rbNoOut.Text = LocalLanguage.GetItemString("DEF_CONTROL_180");  // 출고 금지
            rbYesIn.Text = LocalLanguage.GetItemString("DEF_CONTROL_075");  // 입고 가능
            rbYesOut.Text = LocalLanguage.GetItemString("DEF_CONTROL_177");  // 출고 가능
            rbDeleteRackInfo.Text = LocalLanguage.GetItemString("DEF_CONTROL_076");  // Rack 정보 삭제
            //rbFireInit.Text = LocalLanguage.GetItemString("strEQPStatusReset"); ; // 설비 상태 초기화
            rbFireInit.Text = LocalLanguage.GetItemString("strFireInit");  //"화재 정보 초기화";
            gbJobKind.Text = LocalLanguage.GetItemString("strJobKInd");  // 작업종류

            rdInitTrouble.Text = LocalLanguage.GetItemString("strRackTroubleInit"); // Trouble 초기화 

            rbManualInputOkTray.Text = LocalLanguage.GetItemString("DEF_CONTROL_311");  // 수동입고 완료
            rbManualOutputOkTray.Text = LocalLanguage.GetItemString("DEF_CONTROL_312");  // 수동출고 완료

            cbChangePlantime.Text = LocalLanguage.GetItemString("DEF_CONTROL_184"); // 수정

            //20200407 KJY rbDelayAlarmOff 출고지연알람해제
            rbDelayAlarmOff.Text = LocalLanguage.GetItemString("strDelayAlarmOFF"); // 출고지연알람해제
            
            //
            gbChangeRouteID.Text = LocalLanguage.GetItemString("strReserveChangeRouteID"); // RouteID 변경 예약 정보



            //20201207 KJY - RouteID 변경예약버튼 명칭
            btReserve.Text = LocalLanguage.GetItemString("strDoReserveRouteIDChange"); // RouteID 변경 예약
            btCancelReserve.Text = LocalLanguage.GetItemString("strCancelReserveRouteIDChange"); // 변경 예약 취소

            //20211111 KJY - 출고시간 관리
            btManageOut.Text = LocalLanguage.GetItemString("strTrayOutManage"); // 축고시간 관리


            // Tray정보 가져오기 - 현재공정 확인
            GetTrayInfo().GetAwaiter().GetResult();
            tbRackID.TextData = m_strUnitID;
            tbTrayID.TextData = m_strTrayID;



            //20191030 KJY - 강제입고된 공트레이에 대한 "지금 출고" 기능 추가
            btOutNow.Visible = false;
            if (m_jsonTray != null && m_jsonTray.Flag == "E")
            {
                btOutNow.Text = LocalLanguage.GetItemString("strEmptyTrayOutImmediately");  // 지금 출고
                btOutNow.Visible = true;
            }
            if (m_strTrayID.Length < 10)
            {
                btManageOut.Visible = false;
            } else
            {
                btManageOut.Visible = true;
            }
            

            //AgingRack 정보를 가져온다.
            GetAgingRackInfo().GetAwaiter().GetResult();

            //20200617 KJY 상온공정이면서, 출고 금지가 걸려있고, 공트레이가 아닌 트레이만 다음공정 변경 예약이 가능하다.
            //if (m_strAgingType == "R" && m_jsonAgingRackInfo.Status == "O" && m_jsonTray.Status != "E")
            //20210112 KJY - m_jsonTray가 null이면 에러나서 수정
            if (m_strAgingType == "R" && m_jsonAgingRackInfo.Status == "O" && (m_jsonTray != null && m_jsonTray.Status != "E"))
                {
                btCancelReserve.Visible = true;
                btReserve.Visible = true;
                //gbChangeRouteID.Visible = true;
            }
            else
            {
                btCancelReserve.Visible = false;
                btReserve.Visible = false;
                //gbChangeRouteID.Visible = false;
            }

            if (m_jsonTray != null)
            {
                if(m_jsonRouteOper != null)
                {
                    tbCurrentProcessName.TextData = tbProcessName.TextData = GetOperName(m_jsonTray.EqpTypeID, m_jsonTray.OperGroupID, m_jsonTray.OperID);
                    if (m_nCurrentIndex >= 0)
                        tbNextProcessName.TextData = m_jsonRouteOper.RouteOperList[m_nCurrentIndex+1].OperName;


                    //20200616 KJY - 예약공정명 표시
                    if (m_jsonAgingRackInfo.ReservedRouteID != null && m_jsonAgingRackInfo.ReservedRouteID.Length > 0)
                    {
                        tbReservedRouteID.TextData = m_jsonAgingRackInfo.ReservedRouteID;
                        if (m_jsonAgingRackInfo.ReservedProcID != null && m_jsonAgingRackInfo.ReservedProcID.Length == 3)
                        {
                            string rEqpTypeID = m_jsonAgingRackInfo.ReservedProcID.Substring(0, 1);
                            string rOperGroupID = m_jsonAgingRackInfo.ReservedProcID.Substring(1, 1);
                            string rOperID = m_jsonAgingRackInfo.ReservedProcID.Substring(2, 1);
                            tbReservedProc.TextData = GetOperName(rEqpTypeID, rOperGroupID, rOperID);
                        }
                    }
                }

            }

            Controlls.CDateTime.CtrlDateTimeDT a = new Controlls.CDateTime.CtrlDateTimeDT();

            dtStartTime.ChangeTitle("strStartTime");

            //20190923 KJY - 공정시작시간 표시
            dtStartTime.Enabled = false;
            string strStartTime = m_jsonAgingRackInfo.StartTime;
            DateTime dtStart = new DateTime();
            if (strStartTime != null && strStartTime.Length > 0)
            {
                dtStart = DateTime.ParseExact(strStartTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                dtStartTime.StartTime = dtStart;
            }




            // PlanTime(EndTime)도 맞춰줘야 한다.
            string strEndTime = m_jsonAgingRackInfo.EndTime;
            DateTime dtEndTime = new DateTime() ;
            if (strEndTime != null)
            {
                if (strEndTime == "99999999999999" || strEndTime == "99991231235959" || strEndTime == "99991231125959" || strEndTime == "999912311235959")
                    dtEndTime = DateTime.ParseExact("99981230235959", "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                else
                    dtEndTime = DateTime.ParseExact(strEndTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                dtPlanTime.PlanTime = dtEndTime;
            }
            



            btConfirm.Click += BtConfirm_Click;
            btExit.Click += BtExit_Click;

            //radio button 설정
            // 현재 Tray가 있는 경우, 출고 금지, Rack정보 초기화 버튼 활성
            if (m_strTrayID.Length > 0)
            {
                // 현재 출고 금지면  출고 가능, Rack정보 초기화 버튼 활성.
                if (m_jsonAgingRackInfo.Status == "O")
                {
                    rbNoIn.Visible = false;
                    rbYesIn.Visible = false;
                    rbNoOut.Visible = false;

                } else
                {
                    rbNoIn.Visible = false;
                    rbYesIn.Visible = false;
                    rbYesOut.Visible = false;

                    if (m_jsonAgingRackInfo.Status == "1")  //입고중   PYG
                    {
                        rbManualInputOkTray.Visible = true;
                    }
                    else if (m_jsonAgingRackInfo.Status == "2")    //출고중 PYG
                    {
                        rbManualOutputOkTray.Visible = true;
                    }

                }

                
            } else
            {
                // Tray가 없으면 
                    // 현재 입고 금지면 입고 가능
                    // 연재 입고 금지가 아니면 입고 금지

                if(m_jsonAgingRackInfo.Status == "X")
                {
                    rbDeleteRackInfo.Visible = false;
                    rbNoIn.Visible = false;

                    rbNoOut.Visible = false;
                    rbYesOut.Visible = false;
                }
                else
                {
                    rbDeleteRackInfo.Visible = false;
                    rbNoOut.Visible = false;
                    rbYesIn.Visible = false;
                    rbYesOut.Visible = false;
                }

                //20210112 KJY - 출고 금지 랙에 트레이정보가 없을수도 있다.
                if (m_jsonAgingRackInfo.Status == "O")
                {
                    rbDeleteRackInfo.Visible = true;

                }

            }

            if(m_jsonAgingRackInfo.Status == "T")
            {
                rdInitTrouble.Visible = true;
            } else
            {
                rdInitTrouble.Visible = false;
            }

            //20200401 KJY - for 출고지연알람 해제
            //현재 알람중인지....
            if(m_strStatus == "A")
            {
                rbDelayAlarmOff.Visible = true;
            } else
            {
                rbDelayAlarmOff.Visible = false;
            }

            

            /// 
            /// 화면권한 관련
            /// 
            bool bView = false;
            bool bSave = false;
            // 화면ID 설정
            Tag = CAuthority.WindowsNameToWindowID(this.GetType().FullName.ToString());
            //Get Authority
            CAuthority.GetAuthority(CDefine.m_strLoginID, Tag.ToString(), ref bView, ref bSave);
            this.WindowID = Tag.ToString();
            ///
            ///
            ///
            btConfirm.Enabled = bSave;



        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {

            if(rbDeleteRackInfo.Checked)
                if (CMessage.MsgQuestionYN(LocalLanguage.GetItemString("DEF_MSG_72")).ToString().ToUpper() != "YES") return;
                else 
                if (CMessage.MsgQuestionYN(LocalLanguage.GetItemString("DEF_MSG_27")).ToString().ToUpper() != "YES") return;

            //=======================================================================
            //  저장/삭제 사번 입력
            //-----------------------------------------------------------------------
            string strSaveUserID = null;
            string strEventStr = string.Empty;
            string strCommandInfo = string.Empty;

            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID.Length < 1) return;
            strSaveUserID = CDefine.m_strSaveLoginID;

            ///
            bool bView = false;
            bool bSave = false;
            //Get Authority

            // 20200401 KJY - for 알람해제는 별도의 권한으로 관리. (WindowID : MON-007-1)
            if (m_strStatus == "A" && rbDelayAlarmOff.Checked == true)
            {
                CAuthority.GetAuthority(strSaveUserID, "MON-007-1", ref bView, ref bSave);
            }
            else
            {
                CAuthority.GetAuthority(strSaveUserID, Tag.ToString(), ref bView, ref bSave);
            }
            if (bSave == false)
            {
                // 권한이 없습니다.
                CMessage.MsgError(LocalLanguage.GetItemString("strNoAuth"));
                return;
            }

            ///

            // Update 
            if (rbFireInit.Checked)
            {
                // Formation Biz로 화재정보 초기화 명령전달.
                if (SendFireInitCommand().GetAwaiter().GetResult() == false)
                {
                    CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                    strEventStr = $"[SEND_COMMAND:Fail] [AgingRack Setting][{m_strSetStr}]";
                    CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                    return;
                }
            }

            // DB정보 update
            if(SaveRackInfo().GetAwaiter().GetResult())
            {
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.
                strEventStr = $"[SEND_COMMAND] [AgingRack Setting] [{m_strSetStr}]";
                CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                //완료후 창닫기
                BtExit_Click(sender, e);
                return;

            } else
            {
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                strEventStr = $"[SEND_COMMAND:Fail] [AgingRack Setting] [{m_strSetStr}]";
                CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                return;
            }
            
        }

        #region SendCommand REST
        private async Task<bool> SendFireInitCommand()
        {
            string strUri = string.Empty;
            JObject JsonBody;

            //RESTClient RestClient = new RESTClient(true);
            RESTClient_old RestClient = new RESTClient_old(RestServerType.FORMATION_BIZ);

            strUri = "fms/387/";
            JsonBody = GetFireCommandBody();

            if (JsonBody == null)
            {
                CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                return false;
            }

            m_strSetStr = $"[FireReset:{strUri}:{JsonBody.ToString()}]";
            var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, strUri, JsonBody, true);

            //JsonManualCommandResponse
            JsonManualCommandResponse response = JsonConvert.DeserializeObject<JsonManualCommandResponse>(JsonResult);

            if (response.Ret == "0") //성공
            {
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.
                return true;
            }
            else // "1" 실패
            {
                CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                return false;
            }
        }
        private JObject GetFireCommandBody()
        {
            JObject jsonBody = new JObject();
            //Direction
            jsonBody["Direction"] = "0";
            //ObjectId
            if(m_strAgingType == "H")
                jsonBody["ObjectId"] = $"{CDefine.m_strLineID}330010";
            else
            {
                if (m_strHogi == "01" || m_strHogi == "02" || m_strHogi == "03")
                    jsonBody["ObjectId"] = $"{CDefine.m_strLineID}310010";
                else if (m_strHogi == "04" || m_strHogi == "05" || m_strHogi == "06")
                    jsonBody["ObjectId"] = $"{CDefine.m_strLineID}310020";
                else if (m_strHogi == "07" || m_strHogi == "08")
                    jsonBody["ObjectId"] = $"{CDefine.m_strLineID}310030";
                else
                    return null;
            }
            //Reply
            jsonBody["Reply"] = "1";
            //CommandID
            jsonBody["CommandID"] = "387";
            //SequenceNo
            jsonBody["SequenceNo"] = "00006";
            //BoxID
            jsonBody["BoxID"] = "9";
            //BodyLength
            jsonBody["BodyLength"] = "0008";
            //Status
            //jsonBody["Status"] = "";



            jsonBody["AgingType"] = m_strAgingType;
            jsonBody["Hogi"] = m_strHogi;
            jsonBody["Line"] = m_strLine;
            jsonBody["Bay"] = m_strBay;
            jsonBody["Rack"] = m_strRack;

            return jsonBody;
        }
        #endregion


        private string GetOperName(string strEqpTypeID, string strOperGroupID, string strOperID)
        {
            for(int i=0; i< m_jsonRouteOper.count; i++)
            {
                if(m_jsonRouteOper.RouteOperList[i].EqpTypeID == strEqpTypeID &&
                    m_jsonRouteOper.RouteOperList[i].OperGroupID == strOperGroupID &&
                    m_jsonRouteOper.RouteOperList[i].OperID == strOperID)
                {
                    m_nCurrentIndex = i;
                    return m_jsonRouteOper.RouteOperList[i].OperName;
                }
            }
            return "";
        }

        private async Task<bool> SaveRackInfo()
        {
            JObject jsonBody = new JObject();
            string checkedValue = string.Empty;
            string strSet = string.Empty;

            DateTime updtm = DateTime.Now;
            string UpdateTime = updtm.ToString("yyyy-MM-dd HH:mm:ss");

            bool bIsUseRestSP = false;  // 수동 입고 처리 추가 19.07.22 PYG
            string strSpName = string.Empty;

            if (rbNoIn.Checked) //입고 금지
            {
                checkedValue = "X";
                strSet = $"Status = '{checkedValue}', UpdateTime = '{UpdateTime}' ";
            } else if(rbYesIn.Checked) // 입고 가능
            {
                checkedValue = "E";
                strSet = $"Status = '{checkedValue}', UpdateTime = '{UpdateTime}' ";
            } else if (rbNoOut.Checked) // 출고 금지
            {
                checkedValue = "O";
                strSet = $"Status = '{checkedValue}', UpdateTime = '{UpdateTime}' ";
            } else if (rbYesOut.Checked) // 출고 가능  
            {
                checkedValue = "F";
                strSet = $"Status = '{checkedValue}', UpdateTime = '{UpdateTime}' ";
            }
            else if (rdInitTrouble.Checked) //  Trouble 초기화
            {
                if(m_jsonAgingRackInfo.TrayID != null)
                {
                    if(m_jsonAgingRackInfo.TrayID.Length > 0)
                        checkedValue = "F";
                    else
                        checkedValue = "E";
                } else
                    checkedValue = "E";

                strSet = $"Status = '{checkedValue}', UpdateTime = '{UpdateTime}' ";
            }

            else if (rbDeleteRackInfo.Checked) // Rack정보 삭제
            {
                // 얘는 따른 얘기지..  Status,FireStatus, TrayCnt, StartTime, EndTime, TrayID = NULL
                strSet = $"Status='E' ,FireStatus='null', TrayCnt='null', StartTime='null', EndTime='null', TrayID='null', UpdateTime = '{UpdateTime}' ";
            } else if(rbFireInit.Checked)
            {
                strSet = $"FireStatus='null', UpdateTime = '{UpdateTime}' ";
            }else if (rbManualInputOkTray.Checked)      // 수동 입고완료 
            {
                // 수동 입고 처리 추가 19.07.22 PYG
                bIsUseRestSP = true;

                jsonBody.RemoveAll();
                jsonBody["as_LineID"] = CDefine.m_strLineID;
                jsonBody["as_RackID"] = m_jsonAgingRackInfo.RackID;
                jsonBody["as_TrayID"] = m_jsonAgingRackInfo.TrayID;
                jsonBody["as_Status"] = "F";

                strSpName = "spSetAgingRack";       // 입고완료처리 
            }else if (rbManualOutputOkTray.Checked) // 수동 출고완료
            {
                // 수동 입고 처리 추가 19.07.22 PYG
                bIsUseRestSP = true;

                jsonBody.RemoveAll();
                jsonBody["as_LineID"] = CDefine.m_strLineID;
                jsonBody["as_RackID"] = m_jsonAgingRackInfo.RackID;
                jsonBody["as_TrayID"] = m_jsonAgingRackInfo.TrayID;
                jsonBody["as_Status"] = "E";

                strSpName = "spSetAgingRack";       // 출고완료처리 
            }
            //20200402 KJY - for DealyAlarm OFF
            else if (rbDelayAlarmOff.Checked)
            {
                checkedValue = "1";
                strSet = $"DelayAlarmFlag = '{checkedValue}', UpdateTime = '{UpdateTime}' ";
            }


            //PlanTime 변경할때 
            if (cbChangePlantime.Checked)
            {
                // PlanTime 조정
                DateTime dt = dtPlanTime.PlanTime;
                string PlanTime = dt.ToString("yyyyMMddHHmm00");

                if (strSet.Length > 0)
                    strSet = strSet + $", EndTime = '{PlanTime}' ";
                else
                    strSet = $"EndTime = '{PlanTime}', UpdateTime = '{UpdateTime}' ";
            }
            

            if (!bIsUseRestSP)
            {
                // Rest Server V.2.x 에서는 set과 filter 가 필요하다.
                if (strSet.Length <= 0)
                    return false;

                jsonBody["set"] = strSet;
                jsonBody["filter"] = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{m_strAgingType}' AND  Hogi='{m_strHogi}' AND RackID = '{m_strUnitID}' ";

                m_strSetStr += $"[SAVE:{jsonBody.ToString()}]";

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

            }else // SP 호출 시    19.07.22 PYG
            {
                if (string.IsNullOrEmpty(strSpName))
                    return false;

                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = await RestClient.JsonRequest(JsonApiType.SP, JsonCRUD.SP_IN, $"sp.php/{strSpName}", jsonBody);
                REST_RESULT_CUD_SP result = JsonConvert.DeserializeObject<REST_RESULT_CUD_SP>(JsonResult);
                string err_msg = $"Code:{result.code}, Message:{result.message}";
                //
                if (result.code >= 0)
                {
                    var on_ret_num = result.resource[0].on_ret_num;
                    var os_ret_msg = result.resource[0].os_ret_msg;

                    err_msg = $"Code:{result.code}, Message:{result.message}, on_ret_num:{result.resource[0].on_ret_num}, os_ret_msg:{result.resource[0].os_ret_msg}";

                    //if (result.resource.on_ret_num == 0)
                    if (result.resource[0].on_ret_num == "0")
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                }else
                {
                    return false;
                }

            }


            // formation BiZ로도 화재 해제를 보낸다.
            // TODO



        }

        private async Task RomoveAgingRackInfo()
        {
            JObject jsonBody = new JObject();

            //tMstAgingRackINfo
            jsonBody["LineID"] = CDefine.m_strLineID;
            jsonBody["AgingType"] = m_strAgingType;
            jsonBody["Hogi"] = m_strHogi;
            jsonBody["RackID"] = m_strUnitID;

            // Clear Data
            jsonBody["TrayCnt"] = "0";
            jsonBody["TrayID"] = "";
            jsonBody["StartTime"] = "";
            jsonBody["EndTime"] = "";
            jsonBody["Status"] = "E";

            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = await RestClient.JsonRequest(JsonApiType.Table, JsonCRUD.PATCH, "api.php/tMstAgingRack", jsonBody);
                JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

                if (ret.code == 1) // Success
                {
                    CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.
                }
                else
                {
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:RomoveAgingRackInfo] {0}", e.ToString()));
            }
        }



        private async Task GetAgingRackInfo()
        {
            JObject jsonBodyy = new JObject();

            jsonBodyy["column"] = "*";
            jsonBodyy["filter"] = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{m_strAgingType}' AND Hogi = '{m_strHogi}' AND RackID = '{m_strUnitID}' ";

            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "api.php/tMstAgingRack", jsonBodyy);
                JsonAgingRackList jsonAgingRackList = JsonConvert.DeserializeObject<JsonAgingRackList>(JsonResult);

                if (jsonAgingRackList.code == 0 && jsonAgingRackList.count == 1)
                {
                    m_jsonAgingRackInfo = jsonAgingRackList.AgingRackList[0];
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:GetRAckInfo] {0}", e.ToString()));
            }

        }



        private async Task GetTrayInfo()
        {
            JObject jsonBodyy = new JObject();

            jsonBodyy["column"] = "*";
            jsonBodyy["filter"] = $"LineID = '{CDefine.m_strLineID}' AND TrayID = '{m_strTrayID}' ";


            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "api.php/tTrayCurr", jsonBodyy);
                JsonTrayList jsonTrayList = JsonConvert.DeserializeObject<JsonTrayList>(JsonResult);

                if(jsonTrayList.code ==0 && jsonTrayList.count==1)
                {
                    m_jsonTray = jsonTrayList.TrayList[0];

                    // 여기서 다음공정까지 check 하자
                    GetRouteOper().GetAwaiter().GetResult();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:GetRAckInfo] {0}", e.ToString()));
            }




        }

        private async Task GetRouteOper()
        {
            JObject jsonBodyy = new JObject();

            jsonBodyy["column"] = "*";
            jsonBodyy["filter"] = $"ProdModel = '{m_jsonTray.ProdModel}' AND RouteID = '{m_jsonTray.RouteID}' ";
            jsonBodyy["order"] = "RowNumber asc";

            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "api.php/tMstRouteOper", jsonBodyy);
                JsonRouteOperList jsonOperList = JsonConvert.DeserializeObject<JsonRouteOperList>(JsonResult);

                if (jsonOperList.code == 0 && jsonOperList.count > 1)
                {
                    m_jsonRouteOper = jsonOperList;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:GetRAckInfo] {0}", e.ToString()));
            }
        }

        private void cbChangePlantime_CheckedChanged(object sender, EventArgs e)
        {

            // 모든 check 해제
            rbDeleteRackInfo.Checked = false;
            rbFireInit.Checked = false;
            rbNoIn.Checked = false;
            rbNoOut.Checked = false;
            rbYesIn.Checked = false;
            rbYesOut.Checked = false;

        }

        private void WinAgingRackSetting_Load(object sender, EventArgs e)
        {
            // 모든 check 해제
            rbDeleteRackInfo.Checked = false;
            rbFireInit.Checked = false;
            rbNoIn.Checked = false;
            rbNoOut.Checked = false;
            rbYesIn.Checked = false;
            rbYesOut.Checked = false;
            rdInitTrouble.Checked = false;
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

            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID.Length < 1) return;
            strSaveUserID = CDefine.m_strSaveLoginID;

            ///
            bool bView = false;
            bool bSave = false;
            //Get Authority
            CAuthority.GetAuthority(strSaveUserID, Tag.ToString(), ref bView, ref bSave);
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
            jsonBody["filter"] = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{m_strAgingType}' AND  Hogi='{m_strHogi}' AND RackID = '{m_strUnitID}' AND TrayID = '{m_strTrayID}'";

            m_strSetStr += $"[EmptyTray Out:{jsonBody.ToString()}]";

            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = RestClient.JsonRequest(JsonApiType.Table, JsonCRUD.PATCH, "api.php/tMstAgingRack", jsonBody).GetAwaiter().GetResult();
                JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

                if (ret.code == 1) // Success
                {
                    CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.
                    strEventStr = $"[SEND_COMMAND] [AgingRack Setting] [{m_strSetStr}]";
                    CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                    CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                    //완료후 창닫기
                    BtExit_Click(sender, e);
                    return;
                }
                else
                {
                    CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                    strEventStr = $"[SEND_COMMAND:Fail] [AgingRack Setting] [{m_strSetStr}]";
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

        private void btReserve_Click(object sender, EventArgs e)
        {
            // 
            string ProdModel = string.Empty;
            if (m_jsonTray != null) ProdModel = m_jsonTray.ProdModel;
            else ProdModel = null;
            WinReserveChangeRouteID winReserveChangeRouteID = new WinReserveChangeRouteID(m_strUnitID, m_jsonTray);
            if(winReserveChangeRouteID.ShowDialog()==DialogResult.OK)
            {
                // reload
                ReloadReserveGroupBox();
            }
        }

        private void ReloadReserveGroupBox()
        {
            tbReservedProc.TextData = "";
            tbReservedRouteID.TextData = "";

            GetAgingRackInfo().GetAwaiter().GetResult();
            if (m_jsonAgingRackInfo.ReservedRouteID != null && m_jsonAgingRackInfo.ReservedRouteID.Length > 0)
            {
                tbReservedRouteID.TextData = m_jsonAgingRackInfo.ReservedRouteID;
                if (m_jsonAgingRackInfo.ReservedProcID != null && m_jsonAgingRackInfo.ReservedProcID.Length == 3)
                {
                    string rEqpTypeID = m_jsonAgingRackInfo.ReservedProcID.Substring(0, 1);
                    string rOperGroupID = m_jsonAgingRackInfo.ReservedProcID.Substring(1, 1);
                    string rOperID = m_jsonAgingRackInfo.ReservedProcID.Substring(2, 1);
                    tbReservedProc.TextData = GetOperName(rEqpTypeID, rOperGroupID, rOperID);
                }
            }
        }

        private void btCancelReserve_Click(object sender, EventArgs e)
        {
            // 예약된 RouteID 변경정보를 Clear한다.
            if (CMessage.MsgQuestionYN(LocalLanguage.GetItemString("DEF_MSG_74")).ToString().ToUpper() != "YES") return;

            //=======================================================================
            //  저장/삭제 사번 입력
            //-----------------------------------------------------------------------
            string strSaveUserID = null;
            string strEventStr = string.Empty;
            string strCommandInfo = string.Empty;

            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID.Length < 1) return;
            strSaveUserID = CDefine.m_strSaveLoginID;

            ///
            bool bView = false;
            bool bSave = false;
            //Get Authority
            CAuthority.GetAuthority(strSaveUserID, Tag.ToString(), ref bView, ref bSave);
            if (bSave == false)
            {
                // 권한이 없습니다.
                CMessage.MsgError(LocalLanguage.GetItemString("strNoAuth"));
                return;
            }


            // Reserve 관련 세개 컬럼 Clear
            CancelChageRouteID(strSaveUserID).GetAwaiter().GetResult();

            
        }

        private async Task CancelChageRouteID(string strSaveUserID)
        {
            JObject jsonBody = new JObject();

            //

            string strEventStr = string.Empty;
            string strSet = string.Empty;

            strSet = "ReserveRouteIDChageFlag = 'null', ReservedRouteID = 'null', ReservedProcID = 'null'";


            jsonBody["set"] = strSet;
            jsonBody["filter"] = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{m_strAgingType}' AND  Hogi='{m_strHogi}' AND RackID = '{m_strUnitID}' ";


            try
            {
                RESTClient_old RestClient = new RESTClient_old();
                var JsonResult = await RestClient.JsonRequest(JsonApiType.Table, JsonCRUD.PATCH, "api.php/tMstAgingRack", jsonBody);
                JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

                if (ret.code == 1) // Success
                {
                    strEventStr = $"[RouteID Change] [Cancel Reservation:SUCCESS] [RackID:{m_strUnitID}]";
                    CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                    CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);

                    CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.

                    ReloadReserveGroupBox();
                }
                else
                {
                    strEventStr = $"[RouteID Change] [Cancel Reservation:Fail] [RackID:{m_strUnitID}]";
                    CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                    CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);

                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:CancelChageRouteID] {0}", e.ToString()));
            }

        }

        private void btManageOut_Click(object sender, EventArgs e)
        {

            bool isEmptyTray = false;
            if (m_jsonTray != null && m_jsonTray.Flag == "E")
            {
                isEmptyTray = true;
            }

            // WinAgingRackOutManage 팝업
            WinAgingRackOutManage winAgingRackOutManage = new WinAgingRackOutManage(m_strAgingType, m_strUnitID, m_strTrayID, tbRackID.TextData, dtStartTime.StartTime, dtPlanTime.PlanTime, tbCurrentProcessName.TextData, tbNextProcessName.TextData, isEmptyTray);
            if(winAgingRackOutManage.ShowDialog() == DialogResult.OK)
            {
                // WinAgingRackSetting 다시 reload해야 하는데.. 
                initControl();
            }
        }
    }
}
