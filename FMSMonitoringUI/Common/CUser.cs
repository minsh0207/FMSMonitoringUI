/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CUser
//  Create Data		: 2018.10.25
//  Author			: LSY
//  Remark			: 
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using Novasoft.Logger;
using RestClientLib;
using System;
using System.Text;
using System.Threading.Tasks;
//using Monitoring.Popup;
#endregion

#region [Name Space]
namespace MonitoringUI.Common
{
    #region [Class CUser]
    public static class CUser
	{
        #region [User Main Login]
        public static async Task<bool> UserMainLogin(string sLoginID, string sPassword, bool bSaveLogin = false)
        {
            // 2023.01.19 nvmsh : 조회에 실패 났을 경우 기존 권한을 그대로 유지시키기 위해 주석 처리함.
            //CDefine.m_strLoginID = "";
            //CDefine.m_strLoginPass = "";
            //CDefine.m_strLoginName = "";
            //CDefine.m_strLoginClass = "";

            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append($" SELECT user_id, user_name, class_id, AES_DECRYPT(user_password, SHA2('{sPassword}',512)) as blob_password,");
                strSQL.Append($"    (SELECT CAST( blob_password AS CHAR (10000) CHARACTER SET UTF8)) AS user_password");
                strSQL.Append(" FROM fms_v.tb_mst_user");
                //필수값
                strSQL.Append($" WHERE user_id = '{sLoginID}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonMstUserResponse result = rest.ConvertMstUser(jsonResult);

                    if (result != null && result.DATA.Count > 0 && result.DATA[0].USER_PASSWORD != null)
                    {
                        CDefine.m_strLoginID = result.DATA[0].USER_ID;
                        CDefine.m_strLoginPass = result.DATA[0].USER_PASSWORD;
                        CDefine.m_strLoginName = result.DATA[0].USER_NAME;
                        CDefine.m_strLoginClass = result.DATA[0].CLASS_ID;

                        if (bSaveLogin)
                        {
                            CDefine.m_strSaveLoginID = result.DATA[0].USER_ID;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }                

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### UserMainLogin Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return false;
            }
        }
        #endregion

        #region [UserID To Info Return]
  //      public static async Task<string> UserIdToInfoStr(string strUserID, string strFlag)
		//{
  //          CTaskJson tj = new CTaskJson();
  //          string strFilter = "";
  //          string strRetStr = "";

  //          try
  //          {
  //              strFilter = "userid ='" + strUserID + "'";

  //              JsonMstUserList list = await tj.Search(enDBTable.MST_USER, strFilter) as JsonMstUserList;

  //              if (list == null) new Exception("User Data Null");
  //              if (list.count < 1) new Exception(list.count.ToString());
  //              if (list.code < 0) new Exception(list.code.ToString());

  //              switch (strFlag)
  //              {
  //                  case "NAME":
  //                      strRetStr = list.MstUserList[0].Password;
  //                      break;
  //                  case "CLASS":
  //                      strRetStr = list.MstUserList[0].ClassID;
  //                      break;
  //              }
  //              // Return
  //              return strRetStr;
  //          }
  //          catch (Exception ex)
  //          {
  //              // System Debug
  //              System.Diagnostics.Debug.Print(string.Format("### User Save Login Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
  //              // Return
  //              return "";
  //          }
  //      }
        #endregion
    }
    #endregion
}
#endregion