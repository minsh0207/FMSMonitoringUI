using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MonitoringUI.Common
{
    //for 수동명령
    public enum eEQPCommandID
    {
        NONE = 0,
        EQPSTOP = 129,
        EQPRESTART = 133,
        EQPSTATUSREPORT = 135,
        EQPTRAYUNLOAD = 137,
        EQPRESTARTOCV = 833,
        
        //화재
        FMS = 387,
        EQPREREQUEST = 911,     // 실처리 재요청
        EQPMODECHANGE = 921
    }

    public enum eEQPCommandStatus
    {
        C=0, // Control Mode (921, 0 XXXXX)
        M=1, // Manuial Mode (921, 1 XXXXX)
        E, // 현공정 종료 (129.E), 불량채널 재측정 종료(133.E)
        P, // 현공정 일시정지(129.P) , 연속시작(133.P)
        R, // 공정 재시작(133.R)
        I, // 설비상태 초기화 (133.I  XXXXX)
        U,  // Tray배출 (137.U, 833.U)
        B, // Barcode 다시 읽기
        A,  // 불량채널 재측정 시작  (133.A)
        NONE  // 
    }

    public enum eAgingRackInfo
    {
        TOTAL, // 전체 Rack Count
        F, // Tray있는경우
        E, // Tray없는경우
        U, // Unload Request
        B, // Rack 불량
        X, // 입고금지
        O // 출고금지
    }

    public enum eAgingType
    {
        H,
        R
    }

    public enum eFormationBoxInfo
    {
        TOTAL,  // 전체
        P,      // Power ON
        O,      // Power OFF
        M,      // 유지보수
        R,      // 가동중
        I,      // 작업 대기중
        T,      // Trouble
        S,      // Pause
        N,      // Manual - 안쓰는듯
        A,      // Abnormal - 안쓰는듯
        D,      // Disconnected
        NONE
    }

    public class CMonitoringTask
    {
        internal static JObject GetManualCommandBody(string strObjectID,  string strBoxID, eEQPCommandID m_eEQPCommandID, eEQPCommandStatus m_eEQPCommandStatus,
            string strDirection = "0", string strReply = "1", string strSequenceNo = "00001", string strBodyLength = "0001")
        {
            JObject JsonBody = new JObject();

            JsonBody["Direction"] = strDirection;
            JsonBody["ObjectId"] = strObjectID;
            JsonBody["Reply"] = strReply;
            JsonBody["CommandID"] = ((int)m_eEQPCommandID).ToString();
            JsonBody["SequenceNo"] = strSequenceNo;
            JsonBody["BoxID"] = strBoxID;

            // 19.07.09 PYG Body가 없는 Manual Command 처리
            if(m_eEQPCommandStatus != eEQPCommandStatus.NONE)
            {
                JsonBody["BodyLength"] = strBodyLength;
                JsonBody["Status"] = m_eEQPCommandStatus.ToString();
            }
            else
            {
                JsonBody["BodyLength"] = "0000";
            }

            //if (m_eEQPCommandID == eEQPCommandID.EQPMODECHANGE)
            //    JsonBody["Mode"] = ((int)m_eEQPCommandStatus).ToString();
            //else if (m_eEQPCommandID == eEQPCommandID.EQPRESTART || m_eEQPCommandID == eEQPCommandID.EQPSTOP || m_eEQPCommandID == eEQPCommandID.EQPTRAYUNLOAD)
            

            if (m_eEQPCommandID == eEQPCommandID.FMS)
            {

            }

            return JsonBody;
        }


        public int GetRackCountInfo(eAgingType agingType, string strHogi, eAgingRackInfo agingRackInformation)
        {
            JObject JsonBody = new JObject();
            string strFilter = "";

            
            if(agingRackInformation == eAgingRackInfo.TOTAL)
                strFilter = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{agingType.ToString()}' AND Hogi='{strHogi}'";
            else if (agingRackInformation == eAgingRackInfo.E)
                strFilter = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{agingType.ToString()}' AND Hogi='{strHogi}' AND (Status = '{agingRackInformation.ToString()}' OR Status is null OR Status = '')";
            else
                strFilter = $"LineID = '{CDefine.m_strLineID}' AND AgingType = '{agingType.ToString()}' AND Hogi='{strHogi}' AND Status = '{agingRackInformation.ToString()}'";

            JsonBody["column"] = "*";
            JsonBody["filter"] = strFilter;
            JsonBody["countonly"] = "1";


            return GetAgingRackCountRest(JsonBody).GetAwaiter().GetResult();


        }

        private async Task<int> GetAgingRackCountRest(JObject jsonBody)
        {
            RESTClient_old RestClient = new RESTClient_old();

            var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "api.php/tMstAgingRack", jsonBody);
            JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

            if (ret != null)
                return ret.count;
            else
                return 0;
        }

        public async Task<bool> CheckDBConnection()
        {
            JObject jsonBody = new JObject();
            jsonBody["columns"] = "*";
            jsonBody["countonly"] = "1";

            RESTClient_old RestClient = new RESTClient_old();

            var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "api.php/tMstUser", jsonBody);
            JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

            if (ret != null)
            {
                if (ret.code != 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public async Task<bool> CheckAgingFire()
        {
            JObject jsonBody = new JObject();
            string strFilter = "";
            strFilter = $"FireStatus = 'F' AND LineID = '{CDefine.m_strLineID}' ";
            jsonBody["Filter"] = strFilter;
            jsonBody["columns"] = "*";
            jsonBody["countonly"] = "1";

            RESTClient_old RestClient = new RESTClient_old();

            var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "api.php/tMstAgingRack", jsonBody);
            JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

            if (ret != null)
            {
                if (ret.code == 0 && ret.count > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public async Task<bool> CheckFormationFire()
        {
            JObject jsonBody = new JObject();
            string strFilter = "";
            strFilter = $"FireStatus = 'F' AND EqpTypeID='1' AND LineID = '{CDefine.m_strLineID}' ";
            jsonBody["Filter"] = strFilter;
            jsonBody["columns"] = "*";
            jsonBody["countonly"] = "1";

            RESTClient_old RestClient = new RESTClient_old();

            var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "api.php/tMstEquipment", jsonBody);
            JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

            if (ret != null)
            {
                if (ret.code == 0 && ret.count > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public async Task<string> GetAgingRackCount(eAgingRackInfo eAgingRackStatus)
        {
            JObject jsonBody = new JObject();
            string strSQL = "";
         
            switch (eAgingRackStatus)
            {
                case eAgingRackInfo.TOTAL: //전체
                    strSQL = $"SELECT AgingType, Hogi, count(*) AS Count FROM tMstAgingRack WITH (NOLOCK) WHERE LineID='{CDefine.m_strLineID}' GROUP BY AgingType, Hogi";
                    break;
                case eAgingRackInfo.E:  // Empty
                    strSQL = $"SELECT AgingType, Hogi, count(*) AS Count FROM tMstAgingRack WITH (NOLOCK) WHERE LineID='{CDefine.m_strLineID}' AND (Status = 'E' or Status is null) GROUP BY AgingType, Hogi";
                    break;
                case eAgingRackInfo.F:  // 사용중인 Rack (출고 금지도 포함해야 맞을듯)
                    //strSQL = $"SELECT AgingType, Hogi, count(*) AS Count FROM tMstAgingRack WITH (NOLOCK) WHERE LineID='{CDefine.m_strLineID}' AND (Status = 'F' or Status = 'X' )  GROUP BY AgingType, Hogi";
                    // 'X'는 빼자
                    strSQL = $"SELECT AgingType, Hogi, count(*) AS Count FROM tMstAgingRack WITH (NOLOCK) WHERE LineID='{CDefine.m_strLineID}' AND (Status = 'F' )  GROUP BY AgingType, Hogi";
                    break;
                case eAgingRackInfo.X:  // 입고금지
                    strSQL = $"SELECT AgingType, Hogi, count(*) AS Count FROM tMstAgingRack WITH (NOLOCK) WHERE LineID='{CDefine.m_strLineID}' AND Status = 'X'  GROUP BY AgingType, Hogi";
                    break;
                case eAgingRackInfo.O:  // 출고 금지
                    strSQL = $"SELECT AgingType, Hogi, count(*) AS Count FROM tMstAgingRack WITH (NOLOCK) WHERE LineID='{CDefine.m_strLineID}' AND Status = 'O'  GROUP BY AgingType, Hogi";
                    break;
                case eAgingRackInfo.B:  // 불량
                    strSQL = $"SELECT AgingType, Hogi, count(*) AS Count FROM tMstAgingRack WITH (NOLOCK) WHERE LineID='{CDefine.m_strLineID}' AND Status = 'B'  GROUP BY AgingType, Hogi";
                    break;
            }
            jsonBody["query"] = strSQL;
            RESTClient_old RestClient = new RESTClient_old();

            var JsonResult = await RestClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "query.php", jsonBody);

            return JsonResult;

        }

        public async Task<JObject> GetFormationBoxCount()
        {

            string strQuery = "";

            strQuery = "SELECT A.LineNum, A.TotalCount, B.IdleCount, C.RunningCount, D.PowerONCount, E.PowerOFFCount, F.MaintenenceCount, G.TroubleCount, H.DisconnectCount  FROM "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS TotalCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}'  "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) A "
                + " LEFT OUTER JOIN "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS IdleCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' AND UnitStatus = 'I' "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) B "
                + " ON A.LineNum = B.LineNum "
                + " LEFT OUTER JOIN "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS RunningCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' AND UnitStatus = 'R' "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) C "
                + " ON A.LineNum = C.LineNum "
                + " LEFT OUTER JOIN "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS PowerONCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' AND UnitStatus = 'P' "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) D "
                + " ON A.LineNum = D.LineNum "
                + " LEFT OUTER JOIN "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS PowerOFFCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' AND UnitStatus = 'O' "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) E "
                + " ON A.LineNum = E.LineNum "
                + " LEFT OUTER JOIN "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS MaintenenceCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' AND UnitStatus = 'M' "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) F "
                + " ON A.LineNum = F.LineNum "
                + " LEFT OUTER JOIN "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS TroubleCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' AND UnitStatus = 'T' "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) G "
                + " ON A.LineNum = G.LineNum "
                + " LEFT OUTER JOIN "
                + " ( "
                + " SELECT SUBSTRING(UnitID, 1, 1) as LineNum,  count(*) AS DisconnectCount "
                + " FROM tMstEquipment WITH (NOLOCK)"
                + $" WHERE LineID='{CDefine.m_strLineID}' AND EqptypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' AND UnitStatus = 'D' "
                + " GROUP BY SUBSTRING(UnitID, 1, 1)  "
                + " ) H "
                + " ON A.LineNum = H.LineNum "
                + " ORDER BY A.LineNum ASC ";
            JObject jsonBody = new JObject();
            jsonBody["query"] = strQuery;

            RESTClient_old restClient = new RESTClient_old(RestServerType.WORKING, RestServerVersion.V1);
            var JsonResult = await restClient.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "query.php", jsonBody);

            JObject joFormationBoxCount = JObject.Parse(JsonResult);

            return joFormationBoxCount;
        }


        

    }
}
