/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : CTask
//  Create Date	    : 2018.10.29
//  Author			: LSY
//  Remark			: 
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endregion

namespace MonitoringUI.Common
{
    public class CTaskJson
    {
        #region [Variable]
        string m_Uri = "api.php/";          // Search, Insert, Delete UpData
        string m_UriSp = "sp.php";          // Stored Procedure
        string m_UriQuery = "query.php";    // Test 용도 사용? # 성능저하요인 (문서참조)
        #endregion

        #region [Search]
        /// <summary>
        /// Parameter Load Datle ENum, Query Where , Query OrderBy
        /// </summary>
        /// <param name="TableNum"></param>
        /// <param name="strFilter"></param>
        /// <param name="strOder"></param>
        /// <returns></returns>
        //변경 2019.03.12
        public async Task<object> Search(enDBTable enTable, string strFilter = "", string strOrder = "", string strColumn = "")
        {
            try
            {
                //RestClient Crate
                RESTClient_old restClinet = new RESTClient_old();
                // 검색 조건 생성
                JObject searchFilter = new JObject();
                string strTable = "";

                //Query To Column Name, "*" Is All
                if (strColumn.Length == 0) searchFilter["columns"] = "*";
                else searchFilter["columns"] = strColumn;

                //Filter ADD
                if (strFilter.Length > 0) searchFilter["filter"] = strFilter;
                //Order By ADD
                if (strOrder.Length > 0) searchFilter["order"] += strOrder;
                //enTable To Table Name Get
                strTable = GetTableString(enTable);

                //Table Null Check
                if (strTable.Length < 1) throw new Exception("eNumTable Name Null!!");

                //Jons Result, Return
                var JsonResult = await restClinet.JsonRequest(JsonApiType.Table, JsonCRUD.SELECT, m_Uri + strTable, searchFilter);
                
                //Table Is Type, Return Result
                return GetTableType(enTable, JsonResult);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, Search Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [Search Query]
        /// <summary>
        /// Query To Result
        /// </summary>
        /// <param name="enTable"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public async Task<object> SearchQuery(enDBTable enTable, string strSql)
        {
            try
            {
                RESTClient_old restClinet = new RESTClient_old();
                JObject loadEqpQuery = new JObject();

                loadEqpQuery["query"] = strSql;
                var JsonResult = await restClinet.JsonRequest(JsonApiType.Table, JsonCRUD.SELECT, m_UriQuery, loadEqpQuery);

                return GetTableType(enTable, JsonResult);
            }
            // 예외처리
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, SearchQuery Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [Insert]
        public async Task<object> Insert(enDBTable enTable, JObject searchFilter)
        {
            try
            {
                string strTable = GetTableString(enTable);

                if (strTable.Length < 1) throw new Exception("Table Null : No[ " + enTable.ToString() + " ]");

                //RestClient Crate
                RESTClient_old restClinet = new RESTClient_old();
                // Url Table
                string strUrl = m_Uri + strTable;
                //Jons Result, Return
                var JsonResult = await restClinet.JsonRequest(JsonApiType.Table, JsonCRUD.INSERT, strUrl, searchFilter);
                //Table Is Type, Return
                return JsonConvert.DeserializeObject<JsonRequest>(JsonResult);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, Delete Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [UpDate]
        public async Task<object> UpDate(enDBTable enTable, JObject searchFilter)
        {
            try
            {
                string strTable = GetTableString(enTable);

                if (strTable.Length < 1) throw new Exception("Table Null : No[ " + enTable.ToString() + " ]");

                //RestClient Crate
                RESTClient_old restClinet = new RESTClient_old();
                // Url Table
                string strUrl = m_Uri + strTable;
                //Jons Result, Return
                var JsonResult = await restClinet.JsonRequest(JsonApiType.Table, JsonCRUD.UPDATE, strUrl, searchFilter);
                //Table Is Type, Return
                return JsonConvert.DeserializeObject<JsonRequest>(JsonResult);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, UpDate Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [Delete]
        public async Task<object> Delete(enDBTable enTable, JObject searchFilter)
        {
            try
            {
                string strTable = GetTableString(enTable);

                if (strTable.Length < 1) throw new Exception("Table Null : No[ " + enTable.ToString() + " ]");

                //RestClient Crate
                RESTClient_old restClinet = new RESTClient_old();
                // Url Table
                string strUrl = m_Uri + strTable;
                //Jons Result, Return
                var JsonResult = await restClinet.JsonRequest(JsonApiType.Table, JsonCRUD.DELETE, strUrl, searchFilter);
                //Table Is Type, Return
                return JsonConvert.DeserializeObject<JsonRequest>(JsonResult);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, Delete Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [StoredProcedure]
        /// <summary>
        /// 틀만잡음 구조를 모르겠음.
        /// Input param 순서: 상관 없음
        /// Param mode : IN | OUT | INOUT
        /// IN: 없을 경우 error 발생
        /// OUT/INOUT: optional param의 경우 입력하지 않아도 되며, 리턴 값이 있을 경우 해당 변수에 값을 담아서 리턴한다
        /// </summary>
        /// <param name="enTable"></param>
        /// <param name="JsonCrud"></param>
        /// <param name="searchFilter"></param>
        /// <returns></returns>
        public async Task<object> StoredProcedure(enDBStoredProcedure enSp, JsonCRUD JsonCrud, JObject searchFilter)
        {
            try
            {
                
                string strSp = GetStoredProcedureString(enSp);

                if (strSp.Length < 1) throw new Exception("Stored Procedure Null : No[ " + strSp.ToString() + " ]");

                //RestClient Crate
                RESTClient_old restClinet = new RESTClient_old();

                // Url Table
                string strUrl = m_UriSp + strSp;

                // 추가사항 : Param mode 이 필요함..IN 일 경우 에러 발생?

                //Jons Result, Return
                var JsonResult = await restClinet.JsonRequest(JsonApiType.SP, JsonCrud, strUrl, searchFilter);

                //
                return GetStoredProcedureType(enSp, JsonResult);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, Delete Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [Table Is Type, Return]
        /// <summary>
        /// enTable , JsonResult
        /// </summary>
        /// <param name="TableNum"></param>
        /// <param name="JsonResult"></param>
        /// <returns></returns>
        private object GetTableType(enDBTable TableNum, string JsonResult)
        {
            object obj = new object();

            switch (TableNum)
            {
                #region [Master]
                case enDBTable.MST_PROD_MODEL:
                    obj = JsonConvert.DeserializeObject<JsonModelIDList>(JsonResult);
                    break;
                case enDBTable.MST_OPERATION:
                    obj = JsonConvert.DeserializeObject<JsonOperIDList>(JsonResult);
                    break;
                case enDBTable.MST_EQP_GROUP:
                    obj = JsonConvert.DeserializeObject<JsonEqpGroupList>(JsonResult);
                    break;
                case enDBTable.MST_EQUIPMENT:
                    obj = JsonConvert.DeserializeObject<JsonEquipmentList>(JsonResult);
                    break;
                case enDBTable.MST_AGING_RACK:
                    obj = JsonConvert.DeserializeObject<JsonAgingRackList>(JsonResult);
                    break;
                case enDBTable.MST_ROUTE_OPER:
                    obj = JsonConvert.DeserializeObject<JsonRouteOperList>(JsonResult);
                    break;
                case enDBTable.MST_ROUTE_DEF:
                    obj = JsonConvert.DeserializeObject<JsonRouteIDList>(JsonResult);
                    break;
                case enDBTable.MST_USER:
                    obj = JsonConvert.DeserializeObject<JsonMstUserList>(JsonResult);
                    break;
                case enDBTable.MST_TROUBLE:
                    obj = JsonConvert.DeserializeObject<JsonTroubleList>(JsonResult);
                    break;
                case enDBTable.MST_RECIPE:
                    obj = JsonConvert.DeserializeObject<JsonRecipeList>(JsonResult);
                    break;
                case enDBTable.MST_RECIPE_COMMON:
                    obj = JsonConvert.DeserializeObject<JsonRecipeCommonList>(JsonResult);
                    break;
                case enDBTable.MST_CELL_GRADE_TEMP:
                    obj = JsonConvert.DeserializeObject<JsonCellGradeTempList>(JsonResult);
                    break;
                case enDBTable.MST_WINDOW:
                    obj = JsonConvert.DeserializeObject<JsonMstWindowList>(JsonResult);
                    break;
                #endregion

                #region [Tray]
                case enDBTable.TRAY_CURR:
                case enDBTable.HIST_DB_TRAY_CURR:
                case enDBTable.TRAY_PRO_STEP:
                    obj = JsonConvert.DeserializeObject<JsonTrayList>(JsonResult);
                    break;
                #endregion

                #region [Lot]
                case enDBTable.LOT_INFO:
                    obj = JsonConvert.DeserializeObject<JsonLotIDList>(JsonResult);
                    break;

                #endregion

                #region [Query]
                case enDBTable.JSON_CELL_PRO_CHG:
                    obj = JsonConvert.DeserializeObject<JsonCellProDataList>(JsonResult);
                    break;
                case enDBTable.WIN_PROC_CHANGE:
                    obj = JsonConvert.DeserializeObject<JsonProcChangeList>(JsonResult);
                    break;
                case enDBTable.WIN_TRAY_INFO:
                    //obj = JsonConvert.DeserializeObject<JsonCellValue>(JsonResult);
                    break;
                case enDBTable.CTRL_TROUBLE_INFO:
                    obj = JsonConvert.DeserializeObject<JsonCtrlTroubleInfoList>(JsonResult);
                    break;
                case enDBTable.CTRL_FIRE_RECORD:
                    obj = JsonConvert.DeserializeObject<JsonCtrlFireRecordList>(JsonResult);
                    break;
                case enDBTable.CTRL_TROUBLE_INPUT:
                    obj = JsonConvert.DeserializeObject<JsonCtrlTroubleInputList>(JsonResult);
                    break;
                #endregion

                #region [TEST LSY]
                case enDBTable.RETURN_STRING:
                    obj = JsonConvert.DeserializeObject<JsonReturnStringList>(JsonResult);
                    break;
                #endregion

                default:
                    obj = null;
                    break;
            }
            return obj;
        }
        #endregion

        #region [GetTableString]
        private string GetTableString(enDBTable TableNum)
        {
            string strTableName = "";

            switch (TableNum)
            {
                case enDBTable.MST_PROD_MODEL:
                    strTableName = "tMstProdModel";
                    break;
                case enDBTable.MST_OPERATION:
                    strTableName = "tMstOperation";
                    break;
                case enDBTable.MST_EQP_GROUP:
                    strTableName = "tMstEqpGroup";
                    break;
                case enDBTable.MST_EQUIPMENT:
                    strTableName = "tMstEquipment";
                    break;
                case enDBTable.MST_AGING_RACK:
                    strTableName = "tMstAgingRack";
                    break;
                case enDBTable.MST_ROUTE_OPER:
                    strTableName = "tMstRouteOper";
                    break;
                case enDBTable.MST_ROUTE_DEF:
                    strTableName = "tMstRoutedef";
                    break;
                case enDBTable.MST_USER:
                    strTableName = "tMstUser";
                    break;
                case enDBTable.MST_TROUBLE:
                    strTableName = "tMstTrouble";
                    break;
                case enDBTable.MST_RECIPE:
                    strTableName = "tMstRecipe";
                    break;
                case enDBTable.MST_RECIPE_COMMON:
                    strTableName = "tMstRecipe_Common";
                    break;
                case enDBTable.MST_WINDOW:
                    strTableName = "tMstWindow";
                    break;
                case enDBTable.TRAY_CURR:
                    strTableName = "tTrayCurr";
                    break;
                case enDBTable.HIST_DB_TRAY_CURR:
                    strTableName = "viHistTrayCurr";
                    break;
                case enDBTable.TRAY_PRO_STEP:
                    strTableName = "tTrayProStep";
                    break;
                case enDBTable.LOT_INFO:
                    strTableName = "tLotInfo";
                    break;
                case enDBTable.JSON_CELL_PRO_CHG:
                    strTableName = "JsonCellProChg";
                    break;
                case enDBTable.WIN_PROC_CHANGE:
                    strTableName = "WinProcChange";
                    break;
                case enDBTable.WIN_TRAY_INFO:
                    strTableName = "WinTrayInfo";
                    break;
                case enDBTable.RETURN_STRING:
                    strTableName = "ReturnString";
                    break;
            }

            return strTableName;
        }
        #endregion

        #region [StoredProcedure Is Type, Return]
        private object GetStoredProcedureType(enDBStoredProcedure enSp, string JsonResult)
        {
            object obj = new object();

            switch (enSp)
            {
                case enDBStoredProcedure.MOVE_CURR_TO_HIST:
                    obj = null;
                    break;
            }

            return obj;
        }
        #endregion

        #region [GetTableString]
        private string GetStoredProcedureString(enDBStoredProcedure enSp)
        {
            string strSpName = "";

            switch (enSp)
            {
                case enDBStoredProcedure.MOVE_CURR_TO_HIST:

                    break;
            }

            return strSpName;
        }
        #endregion

        #region [Get Data Time]
        public async Task<object> GetDateTime(int nFlag)
        {
            string strFilter = null;

            try
            {
                JsonReturnStringList returnString = await this.Search(enDBTable.RETURN_STRING, strFilter) as JsonReturnStringList;

                if (returnString == null) return null;
                if (returnString.count < 1) return null;
                if (returnString.code < 0) return null;

                return returnString;
            }
            // 예외처리
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### GetDateTime, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [GetWindowID]
        public async Task<string> GetWindowID(string strWindowName)
        {
            string strFilter = null;
            string strWindowID = "";
            string[] strData = strWindowName.Split('.');

            try
            {
                CString cString = new CString();

                strFilter = cString.FilterStringADD("WindowName", strData[strData.Length - 1], enTableWhere.WHERE, enTableWhereState.EQUALS);

                JsonMstWindowList list = await this.Search(enDBTable.MST_WINDOW, strFilter, "WindowID ASC") as JsonMstWindowList;

                if (list == null) return null;
                if (list.count < 1) return null;
                if (list.code < 0) return null;

                strWindowID = list.MstWindowList[0].WindowID;

                return strWindowID;
            }
            // 예외처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB Load Window ID Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                // Return
                return strWindowID;
            }
        }
        #endregion
    }
}
