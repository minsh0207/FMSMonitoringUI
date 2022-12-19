/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : CDatabaseRest
//  Create Date	    : 
//  Author			: 
//  Remark			: 
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endregion

#region [Name Space]
namespace MonitoringUI.Common
{
    #region [CDatabaseRest, Class]
    //	[CORE]     DB Rest API 호출을 위한 함수
    //                - method type, 결과 JSON의 Wrapper KEY 변경 등 조정 가능
    //                - Rest API 정보 변경은 App.config에서 변경 (변경 시 전체 공유 필수)
    //	[Service]  DB관련 공통 함수나 자주 사용되는 함수 정의 
    public static class CDatabaseRest
    {
        #region [Variable]
        //Rest API 기본 Header value, Base URI         
        private static string mAPIBaseUri;          //기본 URI
        private static string mAPIBaseSp;           //기본 SP
        private static string mAPIBaseQueryUri;     //Manual Query URI
        private static string mAPIBaseHistUri;      //기본 URI
        private static string mAPIBaseHistSp;       //기본 SP
        private static string mAPIBaseHistQueryUri; //Manual Query URI
        private static string mAPIKey;              //API Key 
        private static string mAPIAuth;             //Authorization value
        private static string mContentType;         //Content type    
        private static int mHIST_NUM = 200;
        private static int mTimeout;
        public const int m_nMaxRestCount = 1000; //Rest 의 결과로 받을수있는 최대값.
        #endregion

        #region [Constructor]
        static CDatabaseRest()
        {
            //Curr
            mAPIBaseUri = CUtills.GetDBRestUri();
            mAPIBaseSp = CUtills.GetDBRestSpUri();
            mAPIBaseQueryUri = CUtills.GetDBRestQueryUri();
            //Hist
            mAPIBaseHistUri = CUtills.GetDBRestHistUri();
            mAPIBaseHistSp = CUtills.GetDBRestHistSpUri();
            mAPIBaseHistQueryUri = CUtills.GetDBRestHistQueryUri();

            mAPIKey = CUtills.GetDBAppConfig(CDefine.DEF_CFG_API_KEY);
            mAPIAuth = CUtills.GetDBAppConfig(CDefine.DEF_CFG_AUTH_KEY);
            mContentType = CDefine.DEF_DB_CONTENT_TYPE;

            mTimeout = 30000;
        }

        // 로그인후에 Uri를 line1 line2로 다시 reset 20190425 KJY
        public static void ResetBaseURI()
        {
            //Curr
            mAPIBaseUri = CUtills.GetDBRestUri();
            mAPIBaseSp = CUtills.GetDBRestSpUri();
            mAPIBaseQueryUri = CUtills.GetDBRestQueryUri();
            //Hist
            mAPIBaseHistUri = CUtills.GetDBRestHistUri();
            mAPIBaseHistSp = CUtills.GetDBRestHistSpUri();
            mAPIBaseHistQueryUri = CUtills.GetDBRestHistQueryUri();

            mAPIKey = CUtills.GetDBAppConfig(CDefine.DEF_CFG_API_KEY);
            mAPIAuth = CUtills.GetDBAppConfig(CDefine.DEF_CFG_AUTH_KEY);
            mContentType = CDefine.DEF_DB_CONTENT_TYPE;

            mTimeout = 30000;
        }
        #endregion

        #region [PostBaseSpRestApi]
        /// <summary>
        ///	[CORE] POST Basic SP Request
        /// JSONRequest Lib를 이용하여 Refactoring 필요 : https://github.com/ademargomes/JsonRequest
        /// ===================================================================
        /// Kosi.Battery.RestFullRequest로 변경 => 추후  Kosi.Battery.RestFullRequest 확인 후 적용 예정 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="spName"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static string PostBaseSpRestApi(string method, string strApiUri, string spName, string jsonData)
        {
            string sResponseResult = "{\"code\":\"-700\"}";

            string apiURL = strApiUri + spName;

            CLogger.Debug(enLogType.DBQuery, apiURL);
            CLogger.Debug(enLogType.DBQuery, $"{method} Action data : [{jsonData}]");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
            // Header 
            request.Headers.Add(CDefine.DEF_DB_API_KEY, mAPIKey);
            request.Headers.Add(CDefine.DEF_DB_AUTH_KEY, mAPIAuth);
            // Http Request Option
            request.ContentType = mContentType + "charset=utf-8";
            request.Method = method;
            request.Timeout = mTimeout;

            //Kosi.Battery.RestFullRequest rest = new Kosi.Battery.RestFullRequest();

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonData);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream stream = response.GetResponseStream();
                    sResponseResult = new StreamReader(stream).ReadToEnd();

                    stream.Close();
                }
                response.Close();
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"Connection error to DB : {ex.Message}");
            }

            CLogger.Debug(enLogType.DBResult, sResponseResult);

            return sResponseResult;
        }
        #endregion

        #region [PostBaseRestApi]
        /// <summary>
        //	[CORE] POST Basic Request
        // JSONRequest Lib를 이용하여 Refactoring 필요 : https://github.com/ademargomes/JsonRequest
        // ===================================================================
        // Kosi.Battery.RestFullRequest로 변경 => 추후  Kosi.Battery.RestFullRequest 확인 후 적용 예정 
        // Uri Pamater ADD : 2019-01-28
        /// </summary>
        /// <param name="method"></param>
        /// <param name="table"></param>
        /// <param name="jsonData"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public static string PostBaseRestApi(string method, string strApiUri, string table, string jsonData, string filterParam = "")
        {
            string sResponseResult = "{\"code\":\"-700\"}";

            string apiURL = strApiUri + table;
            if (filterParam.Length > 0) apiURL += "?" + filterParam;
            CLogger.Debug(enLogType.DBQuery, apiURL);
            CLogger.Debug(enLogType.DBQuery, $"{method} Action data : [{jsonData}]");

            HttpWebRequest request = WebRequest.Create(apiURL) as HttpWebRequest;
            // Header 
            request.Headers.Add(CDefine.DEF_DB_API_KEY, mAPIKey);
            request.Headers.Add(CDefine.DEF_DB_AUTH_KEY, mAPIAuth);
            // Http Request Option
            request.ContentType = mContentType + "charset=utf-8";
            request.Method = method;
            request.Timeout = mTimeout;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonData);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    //아닐 경우 의 처리
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            sResponseResult = new StreamReader(stream).ReadToEnd();
                            stream.Close();
                        }
                    }
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"Connection error to DB : {ex.Message}");
            }

            CLogger.Debug(enLogType.DBResult, sResponseResult);

            return sResponseResult;
        }
        #endregion

        #region [PostQueryRestApi]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public static string PostQueryRestApi(string strQuery, string strAPIUri)
        {
            string sResponseResult = "{\"code\":\"-700\"}";
            
            //CLogger.Debug(enLogType.DBQuery, mAPIQueryUri);
            //CLogger.Debug(enLogType.DBQuery, $"{CDefine.HTTP_METHOD_POST} Action data : [{strQuery}]");

            HttpWebRequest request = WebRequest.Create(strAPIUri) as HttpWebRequest;
            // Header 
            request.Headers.Add(CDefine.DEF_DB_API_KEY, mAPIKey);
            request.Headers.Add(CDefine.DEF_DB_AUTH_KEY, mAPIAuth);
            // Http Request Option
            request.ContentType = mContentType + "charset=utf-8";
            request.Method = CDefine.HTTP_METHOD_POST;
            request.Timeout = mTimeout;

            //Kosi.Battery.RestFullRequest rest = new Kosi.Battery.RestFullRequest();

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(strQuery);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream stream = response.GetResponseStream();
                        sResponseResult = new StreamReader(stream).ReadToEnd();

                        stream.Close();
                    }
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"Connection error to DB : {ex.Message}");
            }

            CLogger.Debug(enLogType.DBResult, sResponseResult);

            return sResponseResult;
        }
        #endregion

        #region [GetBaseRestApi]
        /// <summary>
        ///	[CORE] GET Basic Request
        /// JSONRequest Lib를 이용하여 Refactoring 필요 : https://github.com/ademargomes/JsonRequest
        /// //===================================================================
        /// Kosi.Battery.RestFullRequest로 변경 => 추후  Kosi.Battery.RestFullRequest 확인 후 적용 예정 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="table"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetBaseRestApi(string method, string strAPIUri, string table, string param = "")
        {
            string sResponseResult = "";

            /* URI Format : {URI}/{TABLE}?{PARAMS}
             * {URI}    : http://192.168.0.1:80/_api/formation
             * {TABLE}  : /ttraycurr
             * {PARAMS} : ?filter=trayid=HHA0000001
             * example  : http://192.168.0.1:80/_api/formation/ttraycurr?filter=trayid=HHA0000001
             */
            string apiURL = strAPIUri + table + "?" + param;
            CLogger.Debug(enLogType.DBQuery, apiURL);

            //Kosi.WebClient로 변경 예정 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
            // Header 
            request.Headers.Add(CDefine.DEF_DB_API_KEY, mAPIKey);
            request.Headers.Add(CDefine.DEF_DB_AUTH_KEY, mAPIAuth);
            // Http Request Option
            request.ContentType = mContentType;
            request.Method = method;
            request.KeepAlive = true;
            request.Timeout = mTimeout;
            //request.ContentLength = contentBytes.Length;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream stream = response.GetResponseStream();
                    sResponseResult = new StreamReader(stream).ReadToEnd();

                    stream.Close();
                }
                
                response.Close();
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"Connection error to Dreamfactory : {ex.Message}");
            }

            CLogger.Debug(enLogType.DBResult, sResponseResult);
            return sResponseResult;
        }
        #endregion

        #region [GetRecordCount]
        /////////////////////////////////////////////////////////////////////
        // [Service] Get Record Count
        //	조건에 부합하는 Record count 반환
        //  return : 반환값은 Count이지만 String으로 반환, Rest 결과가 Error일 경우 빈값으로 반환
        //===================================================================
        public static string GetRecordCount(string strTableName, string strFilter)
        {
            string resultCount = "";

            const string sHttpMethod = CDefine.HTTP_METHOD_GET;

            try
            {
                resultCount = GetBaseRestApi(sHttpMethod, mAPIBaseUri, strTableName, strFilter);
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"Record count error from DB : {ex.Message}");
            }

            return resultCount;
        }
        #endregion

        #region [GetTrayInfo]
        /////////////////////////////////////////////////////////////////////
        //  [Service] Tray 정보 조회 
        //===================================================================
        public static JObject GetTrayInfo(string trayid)
        {
            JObject jResult = null;

            //Method config
            const string sTableName = CDefine.TB_TRAY_CURR;
            const string sHttpMethod = CDefine.HTTP_METHOD_GET;

            //검색 조건 및 정렬 설정
            StringBuilder strFilter = new StringBuilder();
            strFilter.Append("filter=");
            strFilter.Append("TrayID,eq," + trayid);

            //Dummy Tray Info Data
            //var result = @"{'resource':[{'TrayID':'A000000047','ProdModel':'POUCH','LotID':'171010','RouteID':'B101','CellType':'ALL','InputDate':'20171017','InputTime':'144513','InputUnitID':'B10901','InputFlag':null,'FormInputDate':null,'FormInputTime':null,'FormInputFlag':null,'FormOperMode':null,'RwkFlag':null,'RwkUniqOper':null,'InputCellCnt':50,'CurrCellCnt':49,'UnitID':'20010','EqpTypeID':'4','OperGroupID':'1','OperID':'1','BarUnitID':'B10911','BarReadTime':'20171020130124','StartTime':'20171020143258','EndTime':'20171020145153','PlanTime':null,'NextUnitID':null,'NextConveyorID':null,'NextEqpTypeID':'5','NextOperGroupID':'1','NextOperID':'1,'NextLineID':'','Status':'E','MovingToFormation':null,'NormalFlag':null,'DummyFlag':null,'Priority':null,'ProStepFlag':'S','ManualInputFlag':null,'Prod_Code':null,'TrayCnt':1,'TrayID_2':null,'TrayID_3':null,'TrayID_4':null,'TrayID_5':null,'TrayID_6':null,'UpdateTime':'2017-10-20 14:50:54'}]}";
            var result = GetBaseRestApi(sHttpMethod, mAPIBaseUri, sTableName, strFilter.ToString());

            try
            {
                var jResource = JObject.Parse(result);
                jResult = (JObject)jResource["resource"][0];
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"Tray data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [GetEquipmentInfo]
        /////////////////////////////////////////////////////////////////////
        //  [Service] Equipment 정보 조회 
        //===================================================================
        public static JObject GetEquipmentInfo(string eqpid, string unitid)
        {
            JObject jResult = null;

            //Method config
            const string sTableName = CDefine.TB_EQUIPMENT;
            const string sHttpMethod = CDefine.HTTP_METHOD_GET;

            //검색 조건 및 정렬 설정 : RestDB v1.1 버전용 
            StringBuilder strFilter = new StringBuilder();
            strFilter.Append("filter[]=");
            strFilter.Append("EqpTypeID,eq," + eqpid);
            strFilter.Append("&filter[]=");
            strFilter.Append("UnitID,eq," + unitid );
            strFilter.Append("&satisfy=all");

            var result = GetBaseRestApi(sHttpMethod, mAPIBaseUri, sTableName, strFilter.ToString());

            try
            {
                var jResource = JObject.Parse(result);

                if (jResource.ContainsKey("code"))
                {
                    if ((int)jResource["code"] >= 0)
                    {
                        jResult = (JObject)jResource["resource"][0];
                    }
                }

            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"Equipment error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [SelectData]
        /// <summary>
        /// 형식 변경 조회 / 필터 됨.
        /// {
        ///	"columns" : "userid, username, class",
        ///	"filter" : "class = 'm'",
        ///	"order" : "userid desc"
        ///}
        /// </summary>
        /// <param name="enTable"></param>
        /// <param name="strFilter"></param>
        /// <param name="strOrder"></param>
        /// <param name="strColumn"></param>
        /// <returns></returns>
        public static object SelectData(enDBTable enTable, string strFilter, string strOrder = "", string strColumn = "", string strPage = "")
        {
            //JObject jResult = null;
            object obj = null;
            const string sHttpMethod = CDefine.HTTP_METHOD_POST;
            string strTableName = GetTableString(enTable);
            string strJsonData = null;
            string strAPIUri = null;
            strJsonData = "";
            //Column 
            if (strColumn.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("columns", strColumn, strJsonData);
            }
            else
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("columns", "*", strJsonData);
            }
            //Filter
            if (strFilter.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("filter", strFilter, strJsonData);
            }
            //Order By 
            if (strOrder.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("order", strOrder, strJsonData);
            }

            if (strPage.Length > 0)
            {  
                //{"page": "'1', '857'"}
                strJsonData += CUtills.MaskPostBodyFormatSearch("page", strPage, strJsonData);
            }

            //Json Format 
            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);

            if (strTableName.Length < 1) throw new Exception("eNumTable Name Null!!");

            try
            {
                strAPIUri = GetAPIQueryUri(0, enTable);

                var result = PostBaseRestApi(sHttpMethod, strAPIUri, strTableName, strJsonData, "");
                obj = GetTableType(enTable, result);
            }
            catch (Exception ex)
            {
                //CLogger.Error(enLogType.DBResult, $"ERROR : SelectData error from {strTableName} - Query : {bodyItem}");
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, Search Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

            }

            return obj;
        }
        #endregion

        #region [SelectQuery]
        /////////////////////////////////////////////////////////////////////
        //  [Service] Select Query
        //      - 사용자 쿼리를 통한 데이터 조회용
        //      ex) StringBuilder strSQL = new StringBuilder();
        //          strSQL.Append("SELECT A.prodmodel, A.routeid, A.OcvCellBadLimitCnt AS OcvCellBadLimitCnt");
        //          strSQL.Append("   FROM tMstRecipe	A WITH (NOLOCK) ");
        //          CDatabaseRest.SelectQuery(strSQL.ToString());
        //===================================================================
        public static object SelectQuery(enDBTable enTable, string strQuery)
        {
            object obj = null;

            string strJsonData = null;

            strJsonData = "";
            strJsonData = CUtills.MaskPostBodyFormatSearch("Query", strQuery, strJsonData);
            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);
            var JsonResult = PostQueryRestApi(strJsonData, mAPIBaseQueryUri);

            try
            {
                obj = GetTableType(enTable, JsonResult);
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"ERROR : SelectQuery error Query : {strQuery}" + ex.Message);
            }

            return obj;
        }
        #endregion

        #region [SelectQueryList, List<string>]
        public static object SelectQueryList(enDBTable enTable, List<string> lstData, string CellID = null, bool bNGCellFlag = false, int nOffSet = 0)
        {
            CDataBaseQuery CQuery = new CDataBaseQuery();

            //string strTableName = GetTableString(enTable); // Rest 이름?
            string strQuery = CQuery.QueryToSql(enTable, lstData, CellID, bNGCellFlag); // Rest Query?? 별 변수 설정
            string strJsonData = null;
            string strAPIUri = null;

            strJsonData = "";
            strJsonData = CUtills.MaskPostBodyFormatSearch("query", strQuery, strJsonData);

            // 20190527 1000개씩 테스트
            strJsonData += CUtills.MaskPostBodyFormatSearch("page", $"{nOffSet}, 1000", strJsonData);

            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);

            // 이부분을 Rest 함수? 호출 부분으로 변경?
            object obj = null;

            //Get Uri
            strAPIUri = GetAPIQueryUri(1, enTable);

            var JsonResult = PostQueryRestApi(strJsonData, strAPIUri);

            try
            {
                obj = GetTableType(enTable, JsonResult);
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"ERROR : SelectQuery error Query : {strJsonData}" + ex.Message);
            }

            return obj;
        }
        #endregion

        #region [Select countonly]
        //{"Filter": "LineID = '001'" ,"countonly": "1"}
        public static int SelectCountonly(enDBTable enTable, string strFilter)
        {
            //JObject jResult = null;
            JsonRequest jsonRequest = null;
            const string sHttpMethod = CDefine.HTTP_METHOD_POST;
            string strTableName = GetTableString(enTable);
            string strJsonData = null;
            string strAPIUri = null;
            strJsonData = "";

            //Filter
            if (strFilter.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("filter", strFilter, strJsonData);
            }

            strJsonData += CUtills.MaskPostBodyFormatSearch("countonly", "1", strJsonData);

            //Json Format 
            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);

            if (strTableName.Length < 1) throw new Exception("eNumTable Name Null!!");

            try
            {
                //Curr DB, Hist DB URI를 enTable 기준으로 가져온다.
                strAPIUri = GetAPIQueryUri(0, enTable);

                var result = PostBaseRestApi(sHttpMethod, strAPIUri, strTableName, strJsonData, "");
                jsonRequest = JsonConvert.DeserializeObject<JsonRequest>(result);

                //Data Check
                if (jsonRequest == null) throw new Exception();
                if (jsonRequest.code < 0) throw new Exception();

                return jsonRequest.count;
            }
            catch (Exception ex)
            {
                //CLogger.Error(enLogType.DBResult, $"ERROR : SelectData error from {strTableName} - Query : {bodyItem}");
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, Search Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return -1;
            }
        }
        #endregion

        #region [SelectGroupBy]
        //202004020 KJY - RetString 가져오는 json을 위해 추가 bool RetString = false
        public static object SelectGroupBy(enDBTable enTable, string strCols, string strGroupBy, string strFilter, string strOrderBy, bool RetStringFlag = false)
        {
            //JObject jResult = null;
            object obj = null;
            const string sHttpMethod = CDefine.HTTP_METHOD_POST;
            string strTableName = GetTableString(enTable);
            string strJsonData = null;
            string strAPIUri = null;
            strJsonData = "";

            //cols 
            if (strCols.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("cols", strCols, strJsonData);
            }
            else
            {
                //Error
                throw new Exception("Group By : Cols Is Null.");
            }

            //Group By
            if (strGroupBy.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("groupby", strGroupBy, strJsonData);
            }
            else
            {
                //Error
                throw new Exception("Group By : GroupBy Is Null.");
            }

            //Filter
            if (strFilter.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("filter", strFilter, strJsonData);
            }

            //Order By
            if(strOrderBy.Length > 0)
            {
                strJsonData += CUtills.MaskPostBodyFormatSearch("gorder", strOrderBy, strJsonData);
            }

            //Json Format 
            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);

            if (strTableName.Length < 1) throw new Exception("eNumTable Name Null!!");

            try
            {
                //Curr DB, Hist DB URI를 enTable 기준으로 가져온다.
                strAPIUri = GetAPIQueryUri(0, enTable);

                var result = PostBaseRestApi(sHttpMethod, strAPIUri, strTableName, strJsonData, "");
                obj = GetTableType(enTable, result, RetStringFlag);
            }
            catch (Exception ex)
            {
                //CLogger.Error(enLogType.DBResult, $"ERROR : SelectData error from {strTableName} - Query : {bodyItem}");
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### CTaskJson, Search Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

            }

            return obj;
        }
        #endregion

        #region [Num mHistNum < Curr]
        /// <summary>
        /// 운영 DB, Hist DB URI를 enTable 기준으로 가져온다.
        /// </summary>
        /// <param name="nFlag"></param>
        /// <param name="enTable"></param>
        /// <returns></returns>
        private static string GetAPIQueryUri(int nFlag,  enDBTable enTable)
        {
            string strReturn = null;

            switch (nFlag)
            {
                case 0:
                    if ((int)enTable < mHIST_NUM)
                    {
                        strReturn = mAPIBaseUri;
                    }
                    else
                    {
                        strReturn = mAPIBaseHistUri;
                    }
                    break;
                case 1:
                    if ((int)enTable < mHIST_NUM)
                    {
                        strReturn = mAPIBaseQueryUri;
                    }
                    else
                    {
                        strReturn = mAPIBaseHistQueryUri;
                    }
                    break;
                case 2:
                    if ((int)enTable < mHIST_NUM)
                    {
                        strReturn = mAPIBaseSp;
                    }
                    else
                    {
                        strReturn = mAPIBaseHistSp;
                    }
                    break;
                default:
                    strReturn = "";
                    break;
            }

            return strReturn;
        }
        #endregion

        #region [spExecute]
        /////////////////////////////////////////////////////////////////////
        //  [Service] spExecute Stored Procedure : None return value
        //  SP 호출
        //===================================================================
        public static bool spExecute(enDBSp enNum, Dictionary<string, string> updateData)
        {
            bool jResult = false;
            string strSPName = null;

            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_POST;

            strSPName = GetSpString(enNum);

            if (strSPName.Length < 1) return false;
            if(updateData.Count < 1) return false;

            //JSON Data Serialize
            string sSpData = CUtills.MakePostDataFormat(updateData, false);
            
            try
            {
                //var result = "{'resource':[{'EqpTypeID':'5','UnitID':'10010'}]}";
                var result = PostBaseSpRestApi(sHttpMethod, mAPIBaseSp, strSPName, sSpData);

                jResult = true;
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [spExecuteReturn]
        /////////////////////////////////////////////////////////////////////
        //  [Service] spExecute Stored Procedure with Return value
        //  SP 호출
        //===================================================================
        public static bool spExecuteReturn(string strSPName, Dictionary<string, string> updateData, ref JObject jReturnValue)
        {
            bool jResult = false;

            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_POST;

            //JSON Data Serialize
            string sSpData = CUtills.MakePostDataFormat(updateData, false);

            //var result = "{'resource':[{'EqpTypeID':'5','UnitID':'10010'}]}";
            var result = PostBaseSpRestApi(sHttpMethod, mAPIBaseSp, strSPName, sSpData);  // TEST : 

            try
            {
                var jResource = JObject.Parse(result);

                if (jResource.ContainsKey("code"))
                {

                    if ((int)jResource["code"] >= 0)        //DB Return code는 0 >= 만 성공, -일 경우 error
                    {
                        jReturnValue = (JObject)jResource["resource"][0];
                        jResult = true;
                    }
                    else
                    {
                        CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jResource["code"].ToString()}");
                    }
                }
                else
                {
                    CLogger.Error(enLogType.DBResult, $"data error from DB : {jResource["message"].ToString()}");
                }

            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [InsertRecord]
        /////////////////////////////////////////////////////////////////////
        //  [Service] Insert Record 
        //      - UpdateRecord()와 동일하지만 분리 시킴, 추후 UpdateRecord는 Where 조건에 대한 규칙이 변경가능(From Han)
        //===================================================================
        public static bool InsertRecord(enDBTable enTable, Dictionary<string, string> updateData)
        {
            bool jResult = false;
            string strTableName = GetTableString(enTable);
            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_PUT;

            //JSON Data Serialize
            string sUpdateData = CUtills.MakePostDataFormat(updateData, false);

            //var result = "{'resource':[{'EqpTypeID':'5','UnitID':'10010'}]}";       // TEST : 
            var result = PostBaseRestApi(sHttpMethod, mAPIBaseUri, strTableName, sUpdateData, "");

            JsonRequest jsonRequest = JsonConvert.DeserializeObject<JsonRequest>(result);

            try
            {
                //Insert/Update/Delete 처리 완료 (>0), 처리 안된 경우 (=<0)
                if (jsonRequest.code > 0) jResult = true;
                else
                {
                    CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jsonRequest.code.ToString()}");
                    CLogger.Error(enLogType.DBResult, $"data error from DB : {jsonRequest.Message.ToString()}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        public static bool InsertRecord(enDBTable enTable, string updateData)
        {
            bool jResult = false;
            string strTableName = GetTableString(enTable);
            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_PUT;

            var result = PostBaseRestApi(sHttpMethod, mAPIBaseUri, strTableName, updateData, "");

            JsonRequest jsonRequest = JsonConvert.DeserializeObject<JsonRequest>(result);

            try
            {
                //Insert/Update/Delete 처리 완료 (>0), 처리 안된 경우 (=<0)
                if (jsonRequest.code > 0) jResult = true;
                else
                {
                    CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jsonRequest.code.ToString()}");
                    CLogger.Error(enLogType.DBResult, $"data error from DB : {jsonRequest.Message.ToString()}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [UpdateRecord]
        //Rest V1
        public static bool UpdateRecord(enDBTable enTable, Dictionary<string, string> updateData)
        {
            bool jResult = false;
            string strTableName = GetTableString(enTable);
            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_PATCH;

            //JSON Data Serialize
            string sUpdateData = CUtills.MakePostDataFormat(updateData, false);

            //Data Check
            if (strTableName.Length < 1) throw new Exception("eNumTable Name Null!!");

            //var result = "{'resource':[{'EqpTypeID':'5','UnitID':'10010'}]}";
            var result = PostBaseRestApi(sHttpMethod, mAPIBaseUri, strTableName, sUpdateData, "");

            JsonRequest jsonRequest = JsonConvert.DeserializeObject<JsonRequest>(result);

            try
            {
                //Insert/Update/Delete 처리 완료 (>0), 처리 안된 경우 (=<0)
                if (jsonRequest.code > 0) jResult = true;
                else
                {
                    CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jsonRequest.code.ToString()}");
                    CLogger.Error(enLogType.DBResult, $"data error from DB : {jsonRequest.Message.ToString()}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [UpdateRecord]
        //Rest Full V2
        public static bool UpdateRecord(enDBTable enTable, string strSet, string strFilter)
        {
            bool jResult = false;
            string strTableName = GetTableString(enTable);
            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_PATCH;
            string strJsonData = "";

            //
            if (strSet.Length < 1 && strFilter.Length < 1)
            {
                return false;
            }

            // Last "," 제거
            if(strSet.Substring(strSet.Length - 1, 1) == ",")
                strSet = strSet.Substring(0, strSet.Length - 1);

            strJsonData += CUtills.MaskPostBodyFormatSearch("set", strSet, strJsonData);
            strJsonData += CUtills.MaskPostBodyFormatSearch("filter", strFilter, strJsonData);
            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);

            //Data Check
            if (strTableName.Length < 1) throw new Exception("eNumTable Name Null!!");

            try
            {
                var result = PostBaseRestApi(sHttpMethod, mAPIBaseUri, strTableName, strJsonData, "");

                JsonRequest jsonRequest = JsonConvert.DeserializeObject<JsonRequest>(result);

                //Insert/Update/Delete 처리 완료 (>0), 처리 안된 경우 (=<0)
                if (jsonRequest.code > 0) jResult = true;
                else
                {
                    CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jsonRequest.code.ToString()}");
                    CLogger.Error(enLogType.DBResult, $"data error from DB : {jsonRequest.Message.ToString()}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [DeleteRecord]
        //Rest V1
        public static bool DeleteRecord(enDBTable enTable, Dictionary<string, string> updateData)
        {
            bool jResult = false;
            string strTableName = GetTableString(enTable);
            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_DELETE;

            //JSON Data Serialize
            string sUpdateData = CUtills.MakePostDataFormat(updateData, false);

            //Data Check
            if (strTableName.Length < 1) throw new Exception("eNumTable Name Null!!");

            var result = PostBaseRestApi(sHttpMethod, mAPIBaseUri, strTableName, sUpdateData, "");

            JsonRequest jsonRequest = JsonConvert.DeserializeObject<JsonRequest>(result);

            try
            {
                //Insert/Update/Delete 처리 완료 (>0), 처리 안된 경우 (=<0)
                if (jsonRequest.code >= 0) jResult = true;
                else
                {
                    CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jsonRequest.code.ToString()}");
                    CLogger.Error(enLogType.DBResult, $"data error from DB : {jsonRequest.Message.ToString()}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion

        #region [DeleteRecord]
        //Rest v2
        public static bool DeleteRecord(enDBTable enTable, string strFilter)
        {
            bool jResult = false;
            string strTableName = GetTableString(enTable);
            string strJsonData = "";
            //Method config
            const string sHttpMethod = CDefine.HTTP_METHOD_DELETE;
            
            strJsonData += CUtills.MaskPostBodyFormatSearch("filter", strFilter, strJsonData);
            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);

            //Data Check
            if (strTableName.Length < 1) throw new Exception("eNumTable Name Null!!");

            var result = PostBaseRestApi(sHttpMethod, mAPIBaseUri, strTableName, strJsonData, "");

            JsonRequest jsonRequest = JsonConvert.DeserializeObject<JsonRequest>(result);

            try
            {
                //Insert/Update/Delete 처리 완료 (>0), 처리 안된 경우 (=<0)
                if (jsonRequest.code >= 0) jResult = true;
                else
                {
                    CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jsonRequest.code.ToString()}");
                    CLogger.Error(enLogType.DBResult, $"data error from DB : {jsonRequest.Message.ToString()}");
                }
            }
            catch (Exception ex)
            {
                CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
            }

            return jResult;
        }
        #endregion


        //#region [UpdateEquipment]
        ///////////////////////////////////////////////////////////////////////
        ////  [Service] Update Equipment Infomation
        ////  P.K : eqpid, unitid 
        ////===================================================================
        //public static bool UpdateEquipment(string eqpid, string unitid, Dictionary<string,string> updateData)
        //{
        //    bool jResult = false;

        //    //Method config
        //    const string sTableName = CDefine.TB_EQUIPMENT;
        //    const string sHttpMethod = CDefine.HTTP_METHOD_PATCH;

        //    //Set P.K
        //    updateData.Add("EqpTypeID", eqpid);
        //    updateData.Add("UnitID", unitid);

        //    //JSON Data Serialize
        //    string sUpdateData = CUtills.MakePostDataFormat(updateData, false);

        //    //var result = "{'resource':[{'EqpTypeID':'5','UnitID':'10010'}]}";
        //    var result = PostBaseRestApi(sHttpMethod, sTableName, sUpdateData, "");  // TEST : 

        //    try
        //    {
        //        var jResource = JObject.Parse(result);

        //        if (jResource.ContainsKey("code"))
        //        {
        //            if ((int)jResource["code"] >= 0)        //DB Return code는 0 >= 만 성공, -일 경우 error
        //            {
        //                jResult = true;
        //            }
        //            else
        //            {
        //                CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jResource["code"].ToString()}");
        //            }
        //        }
        //        else
        //        {
        //            CLogger.Error(enLogType.DBResult, $"data error from DB : {jResource["message"].ToString()}");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
        //    }

        //    return jResult;
        //}
        //#endregion

        //#region [UpdateTrayInfo]
        ///////////////////////////////////////////////////////////////////////
        ////  [Service] Update tTrayCurr Infomation
        ////  P.K : trayId
        ////===================================================================
        //public static bool UpdateTrayInfo(string trayid, Dictionary<string, string> updateData)
        //{
        //    bool jResult = false;

        //    //Method config
        //    const string sTableName = CDefine.TB_TRAY_CURR;
        //    const string sHttpMethod = CDefine.HTTP_METHOD_PATCH;

        //    //JSON Data Serialize
        //    updateData.Add("TrayID", trayid);
        //    string sUpdateData = CUtills.MakePostDataFormat(updateData, false);

        //    //var result = "{'resource':[{'EqpTypeID':'5','UnitID':'10010'}]}";
        //    var result = PostBaseRestApi(sHttpMethod, sTableName, sUpdateData, "");  // TEST : 

        //    try
        //    {
        //        var jResource = JObject.Parse(result);

        //        if (jResource.ContainsKey("code"))
        //        {
        //            if ((int)jResource["code"] >= 0)        //DB Return code는 0 >= 만 성공, -일 경우 error
        //            {
        //                jResult = true;
        //            }
        //            else
        //            {
        //                CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jResource["code"].ToString()}");
        //            }
        //        }
        //        else
        //        {
        //            CLogger.Error(enLogType.DBResult, $"data error from DB : {jResource["message"].ToString()}");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
        //    }

        //    return jResult;
        //}
        //#endregion

        //#region [SetTroubleEventTm]
        ///////////////////////////////////////////////////////////////////////
        ////  [Service] Troble Event 등록 함수
        ////===================================================================
        ///// <summary>
        ///// Trouble Event 등록을 위한 method
        ///// <para>필수 key : EqpTypeId, UnitId, EventTime, TroubleCode</para>
        ///// <para>옵션 key : UnitStatus, TroubleLevel(기본값:A)</para>
        ///// </summary>
        ///// <returns>정상처리 여부 : true(정상), false(비정상)
        ///// </returns>
        //public static bool SetTroubleEventTm(string cEqpTypeID, string strUnitID, string strEventTime, int nErrCode, string cUnitStatus = "NULL", string cLevel = "A")
        //{
        //    bool jResult = false;

        //    //Method config
        //    const string sTableName = CDefine.TB_TROUBLEEVENT;
        //    const string sHttpMethod = CDefine.HTTP_METHOD_POST;

        //    var postParam = new Dictionary<string, string>();
        //    postParam.Add("EqpTypeID", cEqpTypeID);
        //    postParam.Add("UnitID", strUnitID);
        //    postParam.Add("EventTime", strEventTime);
        //    postParam.Add("UnitStatus", cUnitStatus);
        //    postParam.Add("TroubleCode", nErrCode.ToString());
        //    postParam.Add("TroubleLevel", cLevel);

        //    //JSON Data Serialize
        //    string sInsertData = CUtills.MakePostDataFormat(postParam, false);

        //    var result = PostBaseRestApi(sHttpMethod, sTableName, sInsertData, "");
        //    var jResource = JObject.Parse(result);

        //    try
        //    {
        //        if (jResource.ContainsKey("code"))
        //        {

        //            if ((int)jResource["code"] >= 0)
        //            {
        //                jResult = true;
        //            }
        //            else
        //            {
        //                CLogger.Error(enLogType.DBResult, $"data error from DB Code : {jResource["code"].ToString()}");
        //            }
        //        }
        //        else
        //        {
        //            CLogger.Error(enLogType.DBResult, $"data error from DB : {jResource["message"].ToString()}");
        //        }

        //        /*

        //        if (jResource.ContainsKey("success"))
        //            jResult = true;
        //        else
        //            CLogger.Error(enLogType.DBResult, $"POST Action error : {jResource["error"].ToString()}");

        //        */



        //    }
        //    catch (Exception ex)
        //    {

        //        CLogger.Error(enLogType.DBResult, $"data error from DB : {ex.Message}");
        //    }

        //    return jResult;
        //}
        //#endregion

        #region [DB Load WindowID]
        public static string DBLoadWindowID(string strWindowName)
        {
            string strFilter = null;
            string strWindowID = "";

            strWindowID = CAuthority.WindowsNameToWindowID(strWindowName);

            try
            {
                CString cString = new CString();

                strFilter = cString.FilterStringADD("WindowID", strWindowID, enTableWhere.WHERE, enTableWhereState.EQUALS);

                JsonMstWindowList list = SelectData(enDBTable.MST_WINDOW, strFilter) as JsonMstWindowList;

                if (list == null) throw new Exception("");
                if (list.code < 0) throw new Exception("");
                if (list.count < 1) throw new Exception("");

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

        #region [DB Load Window Title]
        public static string DBLoadWindowTitle(string strWindowID)
        {
            string strFilter = "";
            string strTitle = "";

            try
            {
                CString cString = new CString();

                strFilter = cString.FilterStringADD("WindowID", strWindowID, enTableWhere.WHERE, enTableWhereState.EQUALS);

                JsonMstWindowList list = SelectData(enDBTable.MST_WINDOW, strFilter) as JsonMstWindowList;

                if (list == null) throw new Exception("");
                if (list.code < 0) throw new Exception("");
                if (list.count < 1) throw new Exception("");

                strTitle = list.MstWindowList[0].WindowName_kr;

                if (CDefine.m_enLanguage == enLoginLanguage.France)
                {
                    strTitle = list.MstWindowList[0].WindowName_fr;
                }

                if (CDefine.m_enLanguage == enLoginLanguage.English)
                {
                    strTitle = list.MstWindowList[0].WindowName_en;
                }

                return strTitle;
            }
            // 예외처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB Load Window ID Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                // Return
                return "";
            }
        }
        #endregion

        #region [DB Get Date Time]
        public static string DBGetDateTime(int nFlag)
        {
            string strSQL = "";
            string strData = "";

            switch (nFlag)
            {
                case 0:
                    strSQL = "SELECT CONVERT(VARCHAR(30), GETDATE(), 120) AS RetString";
                    break;
                default:
                    strSQL = "SELECT CONVERT(VARCHAR(10), GETDATE(), 112) + REPLACE(CONVERT(VARCHAR(8), GETDATE(), 108), ':', '') AS RetString";
                    break;
            }

            try
            {
                JsonReturnStringList list = SelectQuery(enDBTable.RETURN_STRING, strSQL) as JsonReturnStringList;

                if (list == null) return null;
                if (list.count < 1) return null;
                if (list.code < 0) return null;

                strData = list.ReturnStringList[0].RetString;
            }
            // 예외처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB Load Window ID Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }

            return strData;
        }
        #endregion

        #region [Get Table String]
        private static string GetTableString(enDBTable TableNum)
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
                case enDBTable.GROUPBY_AGING_CNT:
                    strTableName = "tMstAgingRack";
                    break;
                case enDBTable.MST_AGING_RACK_SPEC:
                case enDBTable.CTRL_AGING_MARGINAL:
                    strTableName = "tMstAgingRackSpec";
                    break;
                case enDBTable.MST_ROUTE_OPER:
                    strTableName = "tMstRouteOper";
                    break;
                case enDBTable.MST_ROUTE_DEF:
                    strTableName = "tMstRouteDef";
                    break;
                case enDBTable.MST_USER:
                    strTableName = "tMstUser";
                    break;
                case enDBTable.MST_WINDOW_USER:
                    strTableName = "tMstWindowUser";
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
                case enDBTable.MST_CELL_GRADE_TEMP:
                    strTableName = "tMstCellGradeTemp";
                    break;
                case enDBTable.TRAY_CURR:
                case enDBTable.GROUPBY_LOT:
                case enDBTable.GROUPBY_TRAY_CURR_CNT:
                    strTableName = "tTrayCurr";
                    break;
                case enDBTable.UNIT_STATE:
                    strTableName = "viUnitState";
                    break;
                case enDBTable.HIST_DB_TRAY_CURR:
                    //strTableName = "viHistTrayCurr";
                    strTableName = "tHistTrayCurr";
                    break;
                case enDBTable.TRAY_PRO_STEP:
                case enDBTable.GROUPBY_TRAY_PRO_STEP_CNT:
                case enDBTable.GROUPBY_TRAY_PRO_STEP_MONI_CNT:
                    strTableName = "tTrayProStep";
                    break;
                case enDBTable.LOT_INFO:
                    strTableName = "tLotInfo";
                    break;
                case enDBTable.CELL_CURR:
                    strTableName = "tCellCurr";
                    break;

                case enDBTable.CELL_PRO_CHG:
                    strTableName = "tCellProCHG";
                    break;
                case enDBTable.CELL_PRO_OCV:
                    strTableName = "tCellProOCV";
                    break;
                case enDBTable.CELL_PRO_IR:
                    strTableName = "tCellProIR";
                    break;
                case enDBTable.CELL_PRO_DCIR:
                    strTableName = "tCellProDCIR";
                    break;

                case enDBTable.UNIT_TEMP:
                    strTableName = "tUnitTemp";
                    break;
                case enDBTable.UNIT_TEMP_HPC:
                    strTableName = "tUnitTempHPC";
                    break;
                case enDBTable.LOG_INFO:
                    strTableName = "tUserEvent";
                    break;
                case enDBTable.CELL_PRO_STEP:
                case enDBTable.GRID_CELL_PRO_STEP_DATA:
                case enDBTable.GROUPBY_CELL_PRO_STEP_JUDGE_CNT:
                case enDBTable.GROUPBY_CELL_PRO_STEP_DAILY_CNT:
                case enDBTable.GROUPBY_CELL_PRO_STEP_CNT:
                    strTableName = "tCellProStep";
                    break;
                case enDBTable.CELL_PRO_DATA:
                    strTableName = "tCellProData";
                    break;
                case enDBTable.USER_EVENT:
                    strTableName = "tUserEvent";
                    break;
                case enDBTable.EQP_STATUS:
                    strTableName = "tEqpStatus";
                    break;
                case enDBTable.TROUBLE_EVENT_TM:
                    strTableName = "tTroubleEventTM";
                    break;
                    
                case enDBTable.TROUBLE_PIN:
                    strTableName = "tTroublePin";
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
                case enDBTable.CTRL_LOG_INFO:
                    strTableName = "CtrlLogInfo";
                    break;
                case enDBTable.RETURN_STRING:
                    strTableName = "ReturnString";
                    break;
                //Hist DB Table
                case enDBTable.HIST_DB_GROUPBY_LOT:
                    // 20191216 KJY Hist Tray는 TrayProStep없는게 대부분이다. LotID 표시하려면 tHistTrayCurr 에서 가져와야 한다. 
                    strTableName = "tHistTrayCurr";
                    break;
                case enDBTable.HIST_DB_GROUPBY_TRAY_PRO_STEP_CNT:
                case enDBTable.HIST_DB_GROUPBY_TRAY_PRO_STEP_MONI_CNT:
                case enDBTable.HIST_DB_TRAY_PRO_STEP:
                    strTableName = "tHistTrayProStep";
                    break;
                case enDBTable.HIST_DB_TRAY_JUDGE:
                    strTableName = "tHistTrayJudge";
                    break;
                case enDBTable.HIST_DB_CELL_CURR:
                case enDBTable.HIST_LOT_ID:
                    strTableName = "tHistCellCurr";
                    break;
                case enDBTable.HIST_DB_CELL_PRO_STEP:
                case enDBTable.HIST_DB_GROUPBY_CELL_PRO_STEP_CNT:
                case enDBTable.HIST_DB_GROUPBY_CELL_PRO_STEP_JUDGE_CNT:
                case enDBTable.HIST_DB_GROUPBY_CELL_PRO_STEP_DAILY_CNT:
                    strTableName = "tHistCellProStep";
                    break;
                case enDBTable.HIST_DB_CELL_PRO_DATA:
                    strTableName = "tHistCellProData";
                    break;
                case enDBTable.HIST_DB_CELL_PRO_DEGAS:
                    strTableName = "tHistCellProDegas";
                    break;
                case enDBTable.MST_CELL_GRADE_DEF:
                    strTableName = "tMstCellGradeDef";
                    break;
                //20210104 KJY for RouteID Copy할때 등급판정룰까지 복사
                case enDBTable.MST_CELL_GRADE:
                    strTableName = "tMstCellGrade";
                    break;
                case enDBTable.MST_EQP_GRADE_DEF:
                    strTableName = "tMstEQPGradeDef";
                    break;
                //20210205 KJY - for CellType Mng
                case enDBTable.MST_CELL_TYPE:
                    strTableName = "tMstCellType";
                    break;
            }

            return strTableName;
        }
        #endregion

        #region [Get SP String]
        private static string GetSpString(enDBSp enNum)
        {
            string strSpName = "";

            switch (enNum)
            {
                case enDBSp.spUserWondowAuth:
                    strSpName = "spMstUserWondowAuth";
                    break;
                case enDBSp.spMstUserWondowAuth:
                    strSpName = "spMstUserWondowAuth";
                    break;
            }

            return strSpName;
        }
        #endregion  

        #region [Get Table Type]
        /// <summary>
        /// enTable , JsonResult
        /// </summary>
        /// <param name="TableNum"></param>
        /// <param name="JsonResult"></param>
        /// <returns></returns>
        /// 20200420 KJY - RetString 가져오는 Json 위해 추가.. bool RetStringFlag=false
        private static object GetTableType(enDBTable TableNum, string JsonResult, bool RetStringFlag=false)
        {
            object obj = new object();

            if(RetStringFlag)
            {
                obj = JsonConvert.DeserializeObject<JsonReturnStringList>(JsonResult);
                return obj;
            }


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
                case enDBTable.MST_AGING_RACK_SPEC:
                case enDBTable.CTRL_AGING_MARGINAL:
                case enDBTable.GROUPBY_AGING_CNT:
                    obj = JsonConvert.DeserializeObject<JsonAgingReckSpecList>(JsonResult);
                    break;
                case enDBTable.MST_ROUTE_OPER:
                case enDBTable.ROUTE_OPER:
                case enDBTable.GROUPBY_ROUTE_OPER:
                    obj = JsonConvert.DeserializeObject<JsonRouteOperList>(JsonResult);
                    break;
                case enDBTable.MST_ROUTE_DEF:
                    obj = JsonConvert.DeserializeObject<JsonRouteDefList>(JsonResult);
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
                case enDBTable.MST_WINDOW_USER:
                    obj = JsonConvert.DeserializeObject<JsonMstWindowUserList>(JsonResult);
                    break;

                //20210104 KJY - for tMstCellGrade
                case enDBTable.MST_CELL_GRADE:
                    obj = JsonConvert.DeserializeObject<JsontCellGradeList>(JsonResult);
                    break;
                //20210205 KJY - for tMstCellType
                case enDBTable.MST_CELL_TYPE:
                    obj = JsonConvert.DeserializeObject<JsonCellTypeList>(JsonResult);
                    break;
                #endregion

                #region [Tray]
                case enDBTable.TRAY_CURR:
                case enDBTable.HIST_DB_TRAY_CURR:
                case enDBTable.HIST_DB_TRAY_CELL_HIST:
                case enDBTable.TRAY_PRO_STEP:
                case enDBTable.HIST_DB_TRAY_PRO_STEP:
                case enDBTable.WIN_TRAY_INFO:
                case enDBTable.HIST_DB_WIN_TRAY_INFO:
                case enDBTable.TRAYCURR_PROC:
                case enDBTable.TRAYCURR_PROCID:
                    obj = JsonConvert.DeserializeObject<JsonTrayList>(JsonResult);
                    break;
                #endregion

                #region [Lot]
                case enDBTable.LOT_INFO:
                case enDBTable.GROUPBY_LOT:
                case enDBTable.HIST_DB_GROUPBY_LOT:
                    obj = JsonConvert.DeserializeObject<JsonLotIDList>(JsonResult);
                    break;
                #endregion

                #region [Cell]
                case enDBTable.CELL_CURR:
                case enDBTable.HIST_DB_CELL_CURR:
                    obj = JsonConvert.DeserializeObject<JsonCellCurrList>(JsonResult);
                    break;
                case enDBTable.CELL_PRO_DATA:
                    obj = JsonConvert.DeserializeObject<JsonCellProDataList>(JsonResult);
                    break;
                case enDBTable.CELL_PRO_STEP:
                case enDBTable.HIST_DB_CELL_PRO_STEP:
                    obj = JsonConvert.DeserializeObject<JsonCellProDataList>(JsonResult);
                    break;
                case enDBTable.GROUPBY_CELL_PRO_STEP_JUDGE_CNT:
                case enDBTable.HIST_DB_GROUPBY_CELL_PRO_STEP_JUDGE_CNT:
                    obj = JsonConvert.DeserializeObject<JsonJudgeReportList>(JsonResult);
                    break;

                case enDBTable.GROUPBY_CELL_PRO_STEP_DAILY_CNT:
                case enDBTable.HIST_DB_GROUPBY_CELL_PRO_STEP_DAILY_CNT:
                    obj = JsonConvert.DeserializeObject<JsonCellDailyCntList>(JsonResult);
                    break;

                case enDBTable.CELL_PRO_CHG:
                    obj = JsonConvert.DeserializeObject<JsonCellDailyCntList>(JsonResult);
                    break;
                case enDBTable.CELL_PRO_OCV:
                    obj = JsonConvert.DeserializeObject<JsonCellDailyCntList>(JsonResult);
                    break;
                case enDBTable.CELL_PRO_IR:
                    obj = JsonConvert.DeserializeObject<JsonCellDailyCntList>(JsonResult);
                    break;
                case enDBTable.CELL_PRO_DCIR:
                    obj = JsonConvert.DeserializeObject<JsonCellDailyCntList>(JsonResult);
                    break;

                #endregion

                #region [Tray Cell Cnt]
                case enDBTable.GROUPBY_TRAY_CURR_CNT:
                case enDBTable.GROUPBY_TRAY_PRO_STEP_CNT:
                case enDBTable.HIST_DB_GROUPBY_TRAY_PRO_STEP_CNT:
                case enDBTable.HIST_DB_GROUPBY_CELL_PRO_STEP_CNT:
                    obj = JsonConvert.DeserializeObject<JsonTrayCellCntList>(JsonResult);
                    break;
                #endregion
                case enDBTable.GROUPBY_CELL_PRO_STEP_CNT: //JsonTrayCellProStepCntList
                    obj = JsonConvert.DeserializeObject<JsonTrayCellProStepCntList>(JsonResult);
                    break;
                #region [View]
                case enDBTable.UNIT_STATE:
                    obj = JsonConvert.DeserializeObject<JsonUnitStateList>(JsonResult);
                    break;
                #endregion
                #region [Query]
                case enDBTable.GRID_CELL_PRO_STEP_DATA:
                case enDBTable.JSON_CELL_PRO_CHG:
                case enDBTable.HIST_DB_GRID_CELL_PRO_STEP_DATA:
                    obj = JsonConvert.DeserializeObject<JsonCellProDataList>(JsonResult);
                    break;
                case enDBTable.WIN_PROC_CHANGE:
                    obj = JsonConvert.DeserializeObject<JsonProcChangeList>(JsonResult);
                    break;
                case enDBTable.EQP_STATUS:
                case enDBTable.WIN_EQP_STATUS:
                case enDBTable.CTRL_EQP_STATUS_REPORT:
                    obj = JsonConvert.DeserializeObject<JsonEqpStatusList>(JsonResult);
                    break;
                case enDBTable.CTRL_TROUBLE_INFO:    //조회
                case enDBTable.CTRL_TROUBLE_ANALYSIS://분석
                    obj = JsonConvert.DeserializeObject<JsonCtrlTroubleInfoList>(JsonResult);
                    break;
                case enDBTable.CTRL_FIRE_RECORD:
                    obj = JsonConvert.DeserializeObject<JsonCtrlFireRecordList>(JsonResult);
                    break;
                case enDBTable.TROUBLE_EVENT_TM:
                case enDBTable.CTRL_TROUBLE_INPUT:
                    obj = JsonConvert.DeserializeObject<JsonCtrlTroubleInputList>(JsonResult);
                    break;
                case enDBTable.LOG_INFO:
                case enDBTable.CTRL_LOG_INFO:
                    obj = JsonConvert.DeserializeObject<JsonLogInfoList>(JsonResult);
                    break;
                case enDBTable.UNIT_TEMP:
                case enDBTable.CTRL_TEMPERATURE:
                    obj = JsonConvert.DeserializeObject<JsonUnitTempList>(JsonResult);
                    break;
                case enDBTable.UNIT_TEMP_HPC:
                case enDBTable.CTRL_TEMPERATURE_HPC:
                    obj = JsonConvert.DeserializeObject<JsonUnitTempHPCList>(JsonResult);
                    break;
                case enDBTable.CTRL_PROC_MONI:
                case enDBTable.CTRL_LOT_MONI:
                case enDBTable.GROUPBY_TRAY_PRO_STEP_MONI_CNT:
                case enDBTable.HIST_DB_GROUPBY_TRAY_PRO_STEP_MONI_CNT:
                    obj = JsonConvert.DeserializeObject<JsonProcMoniList>(JsonResult);
                    break;
                case enDBTable.TROUBLE_PIN:
                case enDBTable.CTRL_EQP_REPAIR:
                    obj = JsonConvert.DeserializeObject<JsonTroublePinList>(JsonResult);
                    break;
                case enDBTable.MST_EQUIPMENT_CH:
                case enDBTable.CTRL_GRIPPER:
                    obj = JsonConvert.DeserializeObject<JsonGripperList>(JsonResult);
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

        #region [DB Save User Event]
        /////////////////////////////////////////////////////////////////////////////
        //  DB Save User Event
        //===========================================================================  
        public static void DBSaveUserEvent(string strWindowID, string strEqpTypeID, string strUnitID, string strCmdID, string strUserID, string strUserEvent)
        {
            Dictionary<string, string> strUPDate = new Dictionary<string, string>();

            try
            {
                strUPDate.Clear();
                //LineID 필수
                strUPDate.Add("LineID", CDefine.m_strLineID);
                strUPDate.Add("WindowID", strWindowID);
                strUPDate.Add("EqpTypeID", strEqpTypeID);
                strUPDate.Add("UnitID", strUnitID);
                strUPDate.Add("CmdID", strCmdID);
                //UserID, UpdateUserID 가 다 필요한가...
                strUPDate.Add("UserID", strUserID);
                strUPDate.Add("UpdateUser", strUserID);
                strUPDate.Add("UserEvent", strUserEvent);
                strUPDate.Add("UpdateTime", DBGetDateTime(0));

                if (CDatabaseRest.InsertRecord(enDBTable.USER_EVENT, strUPDate) == false)
                {
                    throw new Exception("Log : InsertRecord ERROR");
                }
            }

            // 예외처리
            catch (Exception ex)
            {
                // System Degug
                System.Diagnostics.Debug.Print(string.Format("### DB Save User Event Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Select Data T]
        public static List<T> SelectDataT<T>(string strTableName, string bodyItem)
        {
            const string sHttpMethod = CDefine.HTTP_METHOD_POST;
            var result = PostBaseRestApi(sHttpMethod, strTableName, bodyItem, "");

            try
            {
                CMReturn<T> rsc = JsonConvert.DeserializeObject<CMReturn<T>>(result);

                if (rsc.code >= 0 && rsc.count > 0)
                {
                    return rsc.resource;
                }
            }
            catch
            {
                CLogger.Error(enLogType.DBQuery, $"ERROR : SelectDataT error from [{strTableName}][{bodyItem}] ");
                return null;
            }

            return null;
        }
        #endregion

        #region [Select Query T]
        public static List<T> SelectQueryT<T>(string strQuery)
        {
            string strJsonData = null;

            strJsonData = "";
            strJsonData = CUtills.MaskPostBodyFormatSearch("Query", strQuery, strJsonData);
            strJsonData = CUtills.MaskPostBodyFormat(strJsonData);
            var JsonResult = PostQueryRestApi(strJsonData, mAPIBaseQueryUri);

            try
            {
                CMReturn<T> rsc = JsonConvert.DeserializeObject<CMReturn<T>>(JsonResult);

                if (rsc.code >= 0 && rsc.count > 0)
                {
                    return rsc.resource;
                }
            }
            catch
            {
                CLogger.Error(enLogType.DBQuery, $"ERROR : SelectQueryT error from [{strQuery}] ");
                return null;
            }

            return null;
        }
        #endregion

    }
    #endregion


    #region [Rest Query Class]
    public class CRestQuery
    {
        public string table { get; set; }
        public string columns { get; set; }
        public string filter { get; set; }
        public string order { get; set; }
        public string countonly { get; set; }
        public string groupby { get; set; }
        public string having { get; set; }
        public string gorder { get; set; }
        public string set { get; set; }

        public string page { get; set; }

        public string query()
        {
            var strGroupBy = !string.IsNullOrEmpty(groupby) ? string.Concat(" GROUP BY ", groupby) : string.Empty;
            var strOrderBy = !string.IsNullOrEmpty(order) ? string.Concat(" ORDER BY ", order) : string.Empty;
            return string.Concat("SELECT ", columns, " FROM ", table, " WITH(NOLOCK) ", " WHERE ", filter, strGroupBy, strOrderBy);
        }

        public string serialize()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None);
        }
    }
    #endregion

}
#endregion