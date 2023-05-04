/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: 
//  Create Data		: 
//  Author			: 
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [USing]
using RestClientLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region [Name Space]
namespace MonitoringUI.Common
{
    #region [Class]
    public class CWindowAuthority
    {
        public bool View { get; set; }
        public bool Save { get; set; }
        public string WindowID { get; set; }
        public string WindowName { get; set; }
        public int DefaultClassID { get; set; }
    }

    public class CAuthority
    {
        private static Dictionary<string, CWindowAuthority> _WindowIDList = new Dictionary<string, CWindowAuthority>();

        public static string GetWindowsText(string windowName)
        {
            string windowid = WindowsNameToWindowID(windowName);

            return $"[{_WindowIDList[windowid].WindowID}] {_WindowIDList[windowid].WindowName}";
        }
        #region CheckAuthority
        public static bool CheckAuthority(enAuthority auth, string loginID, string windowName)
        {
            LoadWindowUser(loginID).GetAwaiter().GetResult();

            bool bView = false;
            bool bSave = false;
            bool bAuth = false;

            GetAuthority(windowName, ref bView, ref bSave);

            switch (auth)
            {
                case enAuthority.View:
                    bAuth = bView;
                    break;
                case enAuthority.Save:
                    bAuth = bSave;
                    break;
            }

            if (!bAuth)
            {
                CMessage.MsgInformation("You don't have user permissions.");
            }

            return bAuth;
        }
        #endregion

        #region LoadWindowUser
        private static async Task LoadWindowUser(string strUserID)
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                //strSQL.Append(" SELECT A.user_id, A.window_id, A.auth_view, A.auth_save,");
                //strSQL.Append("        B.window_name, B.window_name_local, B.default_class_id");
                //strSQL.Append("   FROM fms_v.tb_mst_window_user A");
                //strSQL.Append("         LEFT OUTER JOIN fms_v.tb_mst_window B");
                //strSQL.Append("                 ON A.window_id = B.window_id");
                ////필수값
                //strSQL.Append($" WHERE A.user_id = '{strUserID}' AND A.window_id LIKE 'MON-%'");

                strSQL.Append(" SELECT A.user_id, A.class_id,");
                strSQL.Append("        B.window_id , B.window_name, B.default_class_id,");
                strSQL.Append("        IF (C.auth_view IS NULL, 'Y', C.auth_view) AS auth_view,");
                strSQL.Append("        IF (C.auth_save IS NULL, 'Y', C.auth_save) AS auth_save");
                strSQL.Append("   FROM fms_v.tb_mst_user A ");
                strSQL.Append("         LEFT OUTER JOIN fms_v.tb_mst_window B");
                strSQL.Append("                 ON 1=1");
                strSQL.Append("         LEFT OUTER JOIN fms_v.tb_mst_window_user C");
                strSQL.Append("                 ON A.user_id = C.user_id AND B.window_id = C.window_id");
                //필수값
                strSQL.Append($" WHERE A.user_id = '{strUserID}'");
                //strSQL.Append("  GROUP BY B.window_id");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonUserAuthorityResponse result = rest.ConvertUserAuthority(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "UserAuthority : result is null";
                        System.Diagnostics.Debug.Print(string.Format("### LoadWindowUser, {0}", log));
                    }
                }
                else
                {
                    string log = "UserAuthority : jsonResult is null";
                    System.Diagnostics.Debug.Print(string.Format("### LoadWindowUser, {0}", log));
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### LoadWindowUser,  Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region SetData
        private static void SetData(List<_user_authority> data)
        {
            _WindowIDList.Clear();

            foreach (var item in data)
            {
                CWindowAuthority auth = new CWindowAuthority
                {
                    View = (item.AUTH_VIEW == "Y"),
                    Save = (item.AUTH_SAVE == "Y"),
                    WindowID = item.WINDOW_ID,
                    WindowName = (CDefine.m_enLanguage == enLoginLanguage.English ? item.WINDOW_NAME : item.WINDOW_NAME_LOCAL),
                    DefaultClassID = Convert.ToInt16(item.DEFAULT_CLASS_ID)
                };

                _WindowIDList.Add(item.WINDOW_ID, auth);
            }
        }
        #endregion

        #region [DB Load WindowID]
        public static string WindowsNameToWindowID(string strWindowName)
        {
            string strWindowID = "";
            string[] strData = strWindowName.Split('.');
            string strName = strData[strData.Length - 1];

            #region [Switch]
            switch (strName)
            {
                case "CtrlMonitoring":
                    strWindowID = CDefine.DEF_MON_CTRL_MONITORING;
                    break;
                case "CtrlAging":
                    strWindowID = CDefine.DEF_MON_CTRL_AGING;
                    break;
                case "CtrlFormationCHG":
                    strWindowID = CDefine.DEF_MON_CTRL_FORMATION_CHG;
                    break;
                case "CtrlFormationHPC":
                    strWindowID = CDefine.DEF_MON_CTRL_FORMATION_HPC;
                    break;
                case "WinManageEqp":
                    strWindowID = CDefine.DEF_MON_WIN_MANAGE_EQP;
                    break;
                case "WinAgingRackSetting":
                    strWindowID = CDefine.DEF_MON_WIN_AGING_RACK_SETTING;
                    break;
                case "WinBCRConveyorInfo":
                    strWindowID = CDefine.DEF_MON_WIN_BCR_CONVEYOR_INFO;
                    break;
                case "WinConveyorInfo":
                    strWindowID = CDefine.DEF_MON_WIN_CONVEYOR_INFO;
                    break;
                case "WinCellDetailInfo":
                    strWindowID = CDefine.DEF_MON_WIN_CELL_DETAILS;
                    break;
                case "WinCraneInfo":
                    strWindowID = CDefine.DEF_MON_WIN_CRANE_INFO;
                    break;
                case "WinFormationBox":
                    strWindowID = CDefine.DEF_MON_WIN_FORMATION_BOX;
                    break;
                case "WinFormationHPC":
                    strWindowID = CDefine.DEF_MON_WIN_FORMATION_HPC;
                    break;
                case "WinLeadTime":
                    strWindowID = CDefine.DEF_MON_WIN_LEAD_TIME;
                    break;
                case "WinRecipeInfo":
                    strWindowID = CDefine.DEF_MON_WIN_RECIPE_INFO;
                    break;
                case "WinTrayDetails":
                    strWindowID = CDefine.DEF_MON_WIN_TRAY_DETAILS;
                    break;
                case "WinTrayInfo":
                    strWindowID = CDefine.DEF_MON_WIN_TRAY_INFO;
                    break;
                case "WinWaterTank":
                    strWindowID = CDefine.DEF_MON_WIN_WATER_TANK;
                    break;
                case "WinTroubleInfo":
                    strWindowID = CDefine.DEF_MON_WIN_TROUBLE_INFO;
                    break;
                case "WinPackingInfo":
                    strWindowID = CDefine.DEF_MON_WIN_PACKING_INFO;
                    break;
                default:
                    break;
            }
            #endregion

            return strWindowID;
        }
        #endregion

        #region [Authority]
        private static void GetAuthority(string strWindowName, ref bool bAuth_View, ref bool bAuth_Save)
        {
            if (strWindowName.Length < 0) return;

            try
            {
                //string name = string.Empty;
                //string[] title = strWindowName.Split(']');

                //if (title.Length < 2)
                //    name = title[0];
                //else
                //    name = title[1].Substring(1);

                string windowid = WindowsNameToWindowID(strWindowName);

                if (windowid != "" && CDefine.UserClassID >= _WindowIDList[windowid].DefaultClassID)
                {
                    bAuth_View = _WindowIDList[windowid].View;
                    bAuth_Save = _WindowIDList[windowid].Save;
                }               
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Authority Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion
    }
    #endregion
}
#endregion