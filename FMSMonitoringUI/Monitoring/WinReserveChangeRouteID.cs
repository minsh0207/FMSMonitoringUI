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
    public partial class WinReserveChangeRouteID : WinFormRoot
    {
        string m_strProdModel = string.Empty;
        CString m_string;
        string m_strSetStr = string.Empty;
        string m_strUnitID = string.Empty;
        JsonTray m_tray;

        public WinReserveChangeRouteID(string UnitID, JsonTray tray = null)
        {
            m_strUnitID = UnitID;
            if (tray != null)
            {
                m_strProdModel = tray.ProdModel;
                m_tray = tray;
            }

            InitializeComponent();
            initControl();
        }

        private void initControl()
        {
            m_string = new CString();
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
            btModify.Enabled = bSave;

            cbRoute.OnCboItemChanged += cboRoute_SelectionChanged;


            //20201207 KJY - ProdModel 명칭 보여주기 추가
            cbProdModel.TextData = this.m_strProdModel;

            string strFilter = m_string.FilterStringADD("ProdModel", m_strProdModel, enTableWhere.WHERE, enTableWhereState.EQUALS);
            string strOrder = "DefaultFlag DESC";
            cbRoute.InitComboBoxList(false, strFilter, strOrder);


            // 20201221 KJY - 현재 Tray와 동일한 RouteID, 공정ID 선택
            SelectCurrentTray();


            
        }

        private void SelectCurrentTray()
        {
            // RouteID 맞춰주기
            if(cbRoute.ComboObject.Items != null && cbRoute.ComboObject.Items.Count > 0)
            {
                for(int i=0; i< cbRoute.ComboObject.Items.Count; i++)
                {
                    if(m_tray.RouteID == ((System.Data.DataRowView)cbRoute.ComboObject.Items[i]).Row.ItemArray[0].ToString())
                    {
                        cbRoute.SelectedIndex = i;
                        break;
                    }
                }
            }

            // ProcID 맞춰주기
            if (cboProc.ComboObject.Items != null && cboProc.ComboObject.Items.Count > 0)
            {
                for (int i = 0; i < cboProc.ComboObject.Items.Count; i++)
                {
                    if (m_tray.NextEqpTypeID + m_tray.NextOperGroupID + m_tray.NextOperID == ((System.Data.DataRowView)cboProc.ComboObject.Items[i]).Row.ItemArray[0].ToString())
                    {
                        cboProc.SelectedIndex = i;
                        break;
                    }
                }
            }


        }

        private void cboRoute_SelectionChanged(string ItemID, string ItemName)
        {
            string strFilter = "";
            strFilter += m_string.FilterStringADD("ProdModel", m_strProdModel, enTableWhere.WHERE, enTableWhereState.EQUALS);
            strFilter += m_string.FilterStringADD("RouteID", cbRoute.SelectedKeyString, enTableWhere.AND, enTableWhereState.EQUALS);
            strFilter += m_string.FilterStringADD("EqpTypeID", "0", enTableWhere.AND, enTableWhereState.DIFF);
            strFilter += m_string.FilterStringADD("OperGroupID", "0", enTableWhere.AND, enTableWhereState.DIFF);
            strFilter += m_string.FilterStringADD("OperID", "0", enTableWhere.AND, enTableWhereState.DIFF);

            string strOrder = "RowNumber ASC";

            cboProc.InitComboBoxList(false, strFilter, strOrder);
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            // login
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

            CAuthority.GetAuthority(strSaveUserID, Tag.ToString(), ref bView, ref bSave);

            if (bSave == false)
            {
                // 권한이 없습니다.
                CMessage.MsgError(LocalLanguage.GetItemString("strNoAuth"));
                return;
            }

            // 저장시작

            string strRouteID = cbRoute.SelectedKeyString;
            string strProcID = cboProc.SelectedKeyString;

            if(strRouteID == null || strRouteID.Length <1)
            {
                // RouteID를 선택하세요
                return;
            }
            if (strProcID == null || strProcID.Length < 3)
            {
                // 공정을 선택하세요
                return;
            }

            // DB정보 update
            if (SaveRackInfo(strRouteID, strProcID, false).GetAwaiter().GetResult())
            {
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.
                strEventStr = $"[AgingRack Raserve to Change Tray RouteID] [{m_strSetStr}]";
                CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                //완료후 창닫기
                this.DialogResult = DialogResult.OK;
                btCancel_Click(sender, e);
                return;

            }
            else
            {
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                strEventStr = $"[Fail] [AgingRack Raserve to Change Tray RouteID] [{m_strSetStr}]";
                CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, m_strUnitID, "", strSaveUserID, strEventStr);
                CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);
                return;
            }



        }

        private async Task<bool> SaveRackInfo(string RouteID, string ProcID, bool ClearFlag=false)
        {
            JObject jsonBody = new JObject();
            string strSet = string.Empty;
            DateTime updtm = DateTime.Now;
            string UpdateTime = updtm.ToString("yyyy-MM-dd HH:mm:ss");
            string strHogi = m_strUnitID.Substring(1, 2);

            if (ClearFlag==true)
            {
                strSet = $"ReserveRouteIDChageFlag = 'null' , ReservedRouteID = 'null' , ReservedProcID = 'null' , UpdateTime = '{UpdateTime}' ";
            } else
            {
                strSet = $"ReserveRouteIDChageFlag = '1' , ReservedRouteID = '{RouteID}' , ReservedProcID = '{ProcID}' , UpdateTime = '{UpdateTime}' ";
            }


            jsonBody["set"] = strSet;
            jsonBody["filter"] = $"LineID = '{CDefine.m_strLineID}' AND AgingType = 'R' AND  Hogi='{strHogi}' AND RackID = '{m_strUnitID}' ";

            m_strSetStr += $"[Change RouteID : {jsonBody.ToString()}]";


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
                Console.WriteLine(string.Format("[Exception:SaveRackInfo] {0}", e.ToString()));
                return false;
            }


        }


        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
