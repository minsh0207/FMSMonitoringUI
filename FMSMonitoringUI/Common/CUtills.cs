/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//	Class Name		: CUtills
//  Description		: 
//  Create Data		: 
//  Author			: 
//  Remark			: Root = Main/"App.config"
//                    Parameter Name To Value
//                    Json Parameter String Format
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Newtonsoft.Json;
#endregion

#region [NameSpace]
namespace MonitoringUI.Common
{
    #region [Class]
    /// <summary>
    /// App Configuration의 값을 반환
    /// </summary>
    public static class CUtills
    {
        #region [Get AppConfig]
        /////////////////////////////////////////////////////////////////////
        //	AppConfig value 가져오기
        //===================================================================
        public static string GetAppConfig(string key)
        {
            string strDefault = "";
            string strCfgValue = "";

            strCfgValue = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(strCfgValue))
                strCfgValue = strDefault;

            return strCfgValue;
        }
        #endregion      

        #region [Get AppConfig]
        public static int GetAppConfig(string key, int defaultValue)
        {
            int strReturn = defaultValue;
            string strCfgValue = "";

            strCfgValue = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(strCfgValue))
            {
                strReturn = Convert.ToInt32(strCfgValue);
            }

            return strReturn;
        }
        #endregion

        #region [Get DB Rest Uri]
        /////////////////////////////////////////////////////////////////////
        //	DreamFactory Rest Base URI
        //===================================================================
        public static string GetDBRestUri()
        {
            string sUri = "";

            if(CDefine.m_strLineID =="001")
                sUri = ConfigurationManager.AppSettings["DBRestUri"] +":" + ConfigurationManager.AppSettings["DBRestPort"] + "/line1" + ConfigurationManager.AppSettings["DBRestBaseResource"];
            else
                sUri = ConfigurationManager.AppSettings["DBRestUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + "/line2" + ConfigurationManager.AppSettings["DBRestBaseResource"];
            return sUri;
        }
        #endregion

        #region [Get DB Rest SP Uri]
        public static string GetDBRestSpUri()
        {
            string sUri = "";

            if (CDefine.m_strLineID == "001")
                sUri = ConfigurationManager.AppSettings["DBRestUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + "/line1" + ConfigurationManager.AppSettings["DBRestBaseSPResource"];
            else
                sUri = ConfigurationManager.AppSettings["DBRestUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + "/line2" + ConfigurationManager.AppSettings["DBRestBaseSPResource"];

            return sUri;
        }
        #endregion

        #region [Get DB Rest Query Uri]
        public static string GetDBRestQueryUri()
        {
            string sUri = "";

            if (CDefine.m_strLineID == "001")
                sUri = ConfigurationManager.AppSettings["DBRestUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + "/line1" + ConfigurationManager.AppSettings["DBRestQueryResource"];
            else
                sUri = ConfigurationManager.AppSettings["DBRestUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + "/line2" + ConfigurationManager.AppSettings["DBRestQueryResource"];

            return sUri;
        }
        #endregion

        #region [Get DB Rest Hist Uri]
        /////////////////////////////////////////////////////////////////////
        //	DreamFactory Rest Base URI, Hist
        //===================================================================
        public static string GetDBRestHistUri()
        {
            string sUri = "";
            sUri = ConfigurationManager.AppSettings["DBRestHistUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + ConfigurationManager.AppSettings["DBRestHistBaseResource"];
            return sUri;
        }
        #endregion

        #region [Get DB Rest Hist Sp Uri]
        public static string GetDBRestHistSpUri()
        {
            string sUri = "";
            sUri = ConfigurationManager.AppSettings["DBRestHistUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + ConfigurationManager.AppSettings["DBRestHistBaseSPResource"];
            return sUri;
        }
        #endregion

        #region [Get DB Rest Hist Query Uri]
        public static string GetDBRestHistQueryUri()
        {
            string sUri = "";
            sUri = ConfigurationManager.AppSettings["DBRestHistUri"] + ":" + ConfigurationManager.AppSettings["DBRestPort"] + ConfigurationManager.AppSettings["DBRestHistQueryResource"];
            return sUri;
        }
        #endregion

        #region [Get DB App Config]
        /////////////////////////////////////////////////////////////////////
        //	DB Rest API 관련 AppConfig value 가져오기 
        //  App.config에 설정된 값 가져오기 
        //===================================================================
        public static string GetDBAppConfig(string key)
        {
            string strDefault = "";
            string strCfgValue = "";

            strCfgValue = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(strCfgValue))
                strCfgValue = strDefault;

            return strCfgValue;
        }
        #endregion

        #region [Make Post Data Format]
        ///////////////////////////////////////////////////////////////////////////////
        //	DB Rest API Post DATA Format => DB Rest API Wrapper구조가 변경될 경우 이 부분만 수정 
        //  PARAM strPostData : Update column & value
        //  PARAM useWrapper : json wrapping key 사용 유무
        //=================================================================================================
        public static string MakePostDataFormat(Dictionary<string, string> strPostData, bool useWrapper)
        {
            //JSON Serialize
            var sJsonData = JsonConvert.SerializeObject(strPostData, Formatting.None);

            //DreamFactory용 Wrapping Key 생성 : resource
            StringBuilder strPostBody = new StringBuilder();

            if (useWrapper)
            {
                strPostBody.Append("{\"resource\":");
                strPostBody.Append(sJsonData);
                strPostBody.Append("}");
            }
            else
            {
                strPostBody.Append(sJsonData);
            }
            

            return strPostBody.ToString();
        }
        #endregion

        #region [Mask Post Body Format Search]
        public static string MaskPostBodyFormatSearch(string strGubun,  string strPostData,string strJsonData)
        {

            //DreamFactory용 Wrapping Key 생성 : resource
            StringBuilder strPostBody = new StringBuilder();

            if(strJsonData.Length > 0) strPostBody.Append(",");
            strPostBody.Append(JsonConvert.SerializeObject(strGubun, Formatting.None));
            strPostBody.Append(":");
            strPostBody.Append(JsonConvert.SerializeObject(strPostData, Formatting.None));
            return strPostBody.ToString();

        }
        #endregion

        #region [Mask Post Body Format]
        public static string MaskPostBodyFormat(string strPostData)
        {
            //JSON Serialize
            //var sJsonData = JsonConvert.SerializeObject(strPostData, Formatting.None);

            //DreamFactory용 Wrapping Key 생성 : resource
            StringBuilder strPostBody = new StringBuilder();
            strPostBody.Append("{");
            strPostBody.Append(strPostData);
            strPostBody.Append("}");

            return strPostBody.ToString();
        }
        #endregion

        #region [Get Current TimeStr]
        public static string GetCurrentTimeStr()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        #endregion
    }

    #endregion
}
#endregion