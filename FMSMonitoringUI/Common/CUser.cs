/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CUser
//  Create Data		: 2018.10.25
//  Author			: LSY
//  Remark			: 
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Threading.Tasks;
//using Monitoring.Popup;
#endregion

#region [Name Space]
namespace MonitoringUI.Common
{
    #region [Class CUser]
    public static class CUser
	{
        #region [User Save Login]
        public static async Task<bool> UserSaveLogin(string sLoginID, string sPassword)
        {
            CTaskJson tj = new CTaskJson();
            string strFilter = "";

            try
            { 
                strFilter = " userid        = '" + sLoginID + "'";
                strFilter += " AND password = '" + sPassword + "'";
                
                JsonMstUserList list = await tj.Search(enDBTable.MST_USER, strFilter) as JsonMstUserList;

                if (list == null) return false;
                if (list.count < 1) return false;

                CDefine.m_strLoginID = list.MstUserList[0].UserID;
                CDefine.m_strLoginPass = list.MstUserList[0].Password;
                CDefine.m_strLoginName = list.MstUserList[0].UserName;
                CDefine.m_strLoginClass = list.MstUserList[0].ClassID;
                CDefine.m_strSaveLoginID = list.MstUserList[0].UserID;
                return true;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### User Save Login Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return false;
            }
        }
        #endregion

        #region [User Main Login]
        public static async Task<bool> UserMainLogin(string sLoginID, string sPassword)
        {
            CTaskJson tj = new CTaskJson();
            string strFilter = "";

            CDefine.m_strLoginID = "";
            CDefine.m_strLoginPass = "";
            CDefine.m_strLoginName = "";
            CDefine.m_strLoginClass = "";

            try
            {
                strFilter = " userid        = '" + sLoginID + "'";
                strFilter += " AND password = '" + sPassword + "'";

                JsonMstUserList list = await tj.Search(enDBTable.MST_USER, strFilter) as JsonMstUserList;

                if (list == null) return false;
                if (list.count < 1) return false;

                CDefine.m_strLoginID = list.MstUserList[0].UserID;
                CDefine.m_strLoginPass = list.MstUserList[0].Password;
                CDefine.m_strLoginName = list.MstUserList[0].UserName;
                CDefine.m_strLoginClass = list.MstUserList[0].ClassID;

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### User Save Login Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return false;
            }
        }
        #endregion

        #region [UserID To Info Return]
        public static async Task<string> UserIdToInfoStr(string strUserID, string strFlag)
		{
            CTaskJson tj = new CTaskJson();
            string strFilter = "";
            string strRetStr = "";

            try
            {
                strFilter = "userid ='" + strUserID + "'";

                JsonMstUserList list = await tj.Search(enDBTable.MST_USER, strFilter) as JsonMstUserList;

                if (list == null) new Exception("User Data Null");
                if (list.count < 1) new Exception(list.count.ToString());
                if (list.code < 0) new Exception(list.code.ToString());

                switch (strFlag)
                {
                    case "NAME":
                        strRetStr = list.MstUserList[0].Password;
                        break;
                    case "CLASS":
                        strRetStr = list.MstUserList[0].ClassID;
                        break;
                }
                // Return
                return strRetStr;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### User Save Login Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                // Return
                return "";
            }
        }
        #endregion

        #region [MsgSaveUserLoginForm]
        /// <summary>
        /// Msg Question, UserLogIN
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static enDBMsgState MsgSaveUserLoginForm(string strName, bool bMsg = true)
        {
            if(bMsg)
            { 
                // 저장 / 삭제 확인 Message
                //if (CMessage.MsgQuestionYN("데이터를 삭제하시겠습니까?").ToString().ToUpper() != "YES") return;
                if (CMessage.MsgQuestionYN(LocalLanguage.GetItemString(strName)).ToString().ToUpper() != "YES") return enDBMsgState.CANCEL;
            }

            //=======================================================================
            //  저장/삭제 사번 입력
            //-----------------------------------------------------------------------
            //WinSaveLogin saveLogin = new WinSaveLogin();
            //saveLogin.ShowDialog();
            // 저장 권한 Check
            //if (CDefine.m_strSaveLoginID.Length < 1) return enDBMsgState.ERROR;

            return enDBMsgState.TRUE;
        }
        #endregion
    }
    #endregion
}
#endregion