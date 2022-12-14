using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Configuration;

namespace MonitoringUI
{
    public enum JsonApiType
    {
        Table = 0,
        SP
    }
    public enum JsonCRUD
    {
        SELECT = 0,
        INSERT,
        UPDATE,
        DELETE,
        SP_IN,
        SP_OUT,
        SP_INOUT,
        PATCH // 20190123 KJY
    }
    public enum RestServerType
    {
        WORKING,
        HISTORY,
        FORMATION_BIZ,
        PLC_BIZ
    }

    public enum RestServerVersion
    {
        V1,
        V2
    }

    
    public class RESTClient_old
    {
        static HttpClient httpClient = null;


        public RESTClient_old()
        {
            //
            httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("http://ubisam.mynetgear.com:8888/pneg/");
            //httpClient.BaseAddress = new Uri("http://192.168.100.1:8888");

            httpClient.BaseAddress = new Uri(GetRestUri(RestServerType.WORKING));           // Rest URI를 Config에서 가져오도록 수정
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add(
                "APIKey", "qbHIpYOIr5y6mIjBvb+msA==");

        }

        public RESTClient_old(bool ManualCommandFlag) // for Formation Biz (수동명령시)
        {
            //
            httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("http://192.168.10.198:9001/");
            httpClient.BaseAddress = new Uri(GetRestUri(RestServerType.WORKING));           // Rest URI를 Config에서 가져오도록 수정
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add(
                "APIKey", "formation");

        }

        public RESTClient_old(RestServerType restServerType, RestServerVersion restServerVersion = RestServerVersion.V1) // 
        {
            //공통
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            switch(restServerType)
            {
                case RestServerType.WORKING:
                    if(restServerVersion == RestServerVersion.V1)
                        //httpClient.BaseAddress = new Uri("http://192.168.100.1:8888/");
                        httpClient.BaseAddress = new Uri(GetRestUri(RestServerType.WORKING));
                    else
                        //httpClient.BaseAddress = new Uri("http://192.168.100.1:8888/");
                        httpClient.BaseAddress = new Uri(GetRestUri(RestServerType.WORKING));
                    httpClient.DefaultRequestHeaders.Add(
                        "APIKey", "qbHIpYOIr5y6mIjBvb+msA==");
                    break;
                case RestServerType.HISTORY:
                    //httpClient.BaseAddress = new Uri("http://192.168.100.2:8888/");
                    httpClient.BaseAddress = new Uri(GetRestUri(RestServerType.HISTORY));
                    httpClient.DefaultRequestHeaders.Add(
                        "APIKey", "qbHIpYOIr5y6mIjBvb+msA==");
                    break;
                case RestServerType.FORMATION_BIZ:
                    httpClient.BaseAddress = new Uri(Common.CDefine.m_strBizRestURI);   //19.05.27 PYG BizRestURI를 AppConfig로 분리, Login 할때 Global.Variable 값 변경
                    httpClient.DefaultRequestHeaders.Add(
                        "APIKey", "formation");
                    break;
                case RestServerType.PLC_BIZ:
                    break;
            }
            

        }

        /// <summary>
        /// Rest Root URI(IP:Port)를 Config에서 가져오는 함수
        /// </summary>
        /// <param name="RestType"></param>
        /// <returns></returns>
        public string GetRestUri(RestServerType RestType)
        {
            string restURIFromConfig = string.Empty;

            switch (RestType)
            {
                case RestServerType.WORKING:
                    restURIFromConfig = string.Format("{0}:{1}", ConfigurationManager.AppSettings["DBRestUri"], ConfigurationManager.AppSettings["DBRestPort"]); ;
                    break;
                case RestServerType.HISTORY:
                    restURIFromConfig = string.Format("{0}:{1}", ConfigurationManager.AppSettings["DBRestHistUri"], ConfigurationManager.AppSettings["DBRestPort"]);
                    break;
            }

            return restURIFromConfig;
        }


        public async Task<string> GetJson(JsonApiType type, JsonCRUD crud, string RequestUri, object RequestBody, bool isFormationBiz=false, bool isHist = false)
        {
            try
            {
                string strUri = "";
                //변경
                if (isFormationBiz == false)
                {
                    if (MonitoringUI.Common.CDefine.m_strLineID == "001") strUri = "line1/";
                    else strUri = "line2/";
                }

                if(isHist == true)
                {
                    strUri = "hist/";
                }

                


                HttpResponseMessage response = httpClient.PostAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
            catch(Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### GetJson, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }

        #region [Json Request]
        public async Task<string> JsonRequest(JsonApiType type, JsonCRUD crud, string RequestUri, object RequestBody)
        {
            HttpResponseMessage response;
            var responseString = "";
            string strUri = "";

            //변경
            if (MonitoringUI.Common.CDefine.m_strLineID == "001") strUri = "line1/";
            else strUri = "line2/";

            try
            {
                switch(type)
                {
                    case JsonApiType.Table:
                        switch (crud)
                        {
                            //Post, Query Return.
                            case JsonCRUD.SELECT:
                                response = httpClient.PostAsJsonAsync(strUri+ RequestUri, RequestBody).Result;
                                responseString = await response.Content.ReadAsStringAsync();
                                break;
                            // POST
                            case JsonCRUD.INSERT:
                                //response = httpClient.PostAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                                //responseString = await response.Content.ReadAsStringAsync();
                                //break;
                            //Put, Result Return.
                            case JsonCRUD.DELETE:
                            case JsonCRUD.UPDATE:
                                response = httpClient.PutAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                                response.EnsureSuccessStatusCode();

                                responseString = await response.Content.ReadAsStringAsync();
                                break;
                            //PATCH
                            case JsonCRUD.PATCH:
                                response = httpClient.PatchJsonAsync(strUri + RequestUri, typeof(JObject), RequestBody).Result;
                                responseString = await response.Content.ReadAsStringAsync();
                                break;
                        }

                        break;
                    case JsonApiType.SP:
                        response = httpClient.PostAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                        responseString = await response.Content.ReadAsStringAsync();
                        break;
                    default:
                        return "";
                }
                
                return responseString;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Json Request, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        // 20210308 KJY - line1, line2 구분
        public async Task<string> JsonRequestLine(string strLine, JsonApiType type, JsonCRUD crud, string RequestUri, object RequestBody)
        {
            HttpResponseMessage response;
            var responseString = "";
            string strUri = "";

            //변경
            //if (MonitoringUI.Common.CDefine.m_strLineID == "001") strUri = "line1/";
            //else strUri = "line2/";
            strUri = strLine + "/";


            try
            {
                switch (type)
                {
                    case JsonApiType.Table:
                        switch (crud)
                        {
                            //Post, Query Return.
                            case JsonCRUD.SELECT:
                                response = httpClient.PostAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                                responseString = await response.Content.ReadAsStringAsync();
                                break;
                            // POST
                            case JsonCRUD.INSERT:
                            //response = httpClient.PostAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                            //responseString = await response.Content.ReadAsStringAsync();
                            //break;
                            //Put, Result Return.
                            case JsonCRUD.DELETE:
                            case JsonCRUD.UPDATE:
                                response = httpClient.PutAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                                response.EnsureSuccessStatusCode();

                                responseString = await response.Content.ReadAsStringAsync();
                                break;
                            //PATCH
                            case JsonCRUD.PATCH:
                                response = httpClient.PatchJsonAsync(strUri + RequestUri, typeof(JObject), RequestBody).Result;
                                responseString = await response.Content.ReadAsStringAsync();
                                break;
                        }

                        break;
                    case JsonApiType.SP:
                        response = httpClient.PostAsJsonAsync(strUri + RequestUri, RequestBody).Result;
                        responseString = await response.Content.ReadAsStringAsync();
                        break;
                    default:
                        return "";
                }

                return responseString;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Json Request, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        //https://docs.microsoft.com/ko-kr/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client

        //static async Task<Uri> CreateProductAsync(object product, string RequestUri)
        //{
        //    HttpResponseMessage response = await httpClient.PostAsJsonAsync(RequestUri, product);

        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

        //static async Task<object> UpdateProductAsync(object product, string RequestUri)
        //{
        //    HttpResponseMessage response = await httpClient.PutAsJsonAsync(RequestUri, product);

        //    response.EnsureSuccessStatusCode();

        //    // Deserialize the updated product from the response body.
        //    product = await response.Content.ReadAsAsync<object>();

        //    return product;
        //}
        //static async Task<HttpStatusCode> DeleteProductAsync(string id)
        //{
        //    HttpResponseMessage response = await httpClient.DeleteAsync($"api/products/{id}");
        //    return response.StatusCode;
        //}


        #region Get DB DateTime
        public static async Task<string> DBGetDateTime(int nFlag)
        {
            try
            {
                string strSQL = "";

                RESTClient_old restClinet = new RESTClient_old();
                JObject getDBGetDateTimeQyery = new JObject();
                if(nFlag == 0)
                    strSQL = "SELECT CONVERT(VARCHAR(30), GETDATE(), 120) AS RetString";
                else if(nFlag == 1)
                    strSQL = "SELECT CONVERT(VARCHAR(10), GETDATE(), 112) + REPLACE(CONVERT(VARCHAR(8), GETDATE(), 108), ':', '') AS RetString";

                getDBGetDateTimeQyery["query"] = strSQL;
                var JsonResult = await restClinet.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "query.php", getDBGetDateTimeQyery);
                JsonReturnStringList DBDateTime = JsonConvert.DeserializeObject<JsonReturnStringList>(JsonResult);

                if (DBDateTime.code == 0)
                {
                    return DBDateTime.ReturnStringList[0].RetString;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB Load Formation Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

    }
    #region Add HttpClientExtensions for PATCH
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(client.BaseAddress + requestUri),
                Content = content,
            };

            return client.SendAsync(request);
        }
        public static Task<HttpResponseMessage> PatchJsonAsync(this HttpClient client, string requestUri, Type type, object value)
        {
            return client.PatchAsync(requestUri, new ObjectContent(type, value, new JsonMediaTypeFormatter(), "application/json"));
        }

    } 
    #endregion
}
