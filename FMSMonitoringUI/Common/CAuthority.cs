/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: 
//  Create Data		: 
//  Author			: 
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [USing]
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
    public static class CAuthority
    {

        #region [DB Load WindowID]
        public static string WindowsNameToWindowID(string strWindowName)
        {
            string strWindowID = "";
            string[] strData = strWindowName.Split('.');
            string strName = strData[strData.Length - 1];

            #region [Switch]
            switch (strName)
            {
                case "CtrlAgingMarginalShare":
                    strWindowID = CDefine.DEF_WINDOW_MST_AGING_MARGINAL_SHARE;
                    break;
                case "CtrlMstTrouble":
                    strWindowID = CDefine.DEF_WINDOW_MST_TROUBLE;
                    break;
                case "CtrlProdcutionModel":
                    strWindowID = CDefine.DEF_WINDOW_MST_PROD_MODEL;
                    break;
                case "CtrlEquipment":
                    strWindowID = CDefine.DEF_WINDOW_MST_EQUIPMENT;
                    break;
                case "CtrlRouteInput":
                    strWindowID = CDefine.DEF_WINDOW_MST_ROUTE_INPUT;
                    break;
                case "CtrlTempCompensation":
                    strWindowID = CDefine.DEF_WINDOW_MST_TEMP_COMPENSATION;
                    break;
                case "CtrlUserManagement":
                    strWindowID = CDefine.DEF_WINDOW_MST_USER_MANAGEMENT;
                    break;
                case "CtrlWindow":
                    strWindowID = CDefine.DEF_WINDOW_MST_WINDOWS;
                    break;
                case "WinDefaultRouteInput":
                    strWindowID = CDefine.DEF_WINDOW_MST_WIN_DEFAULT_ROUTE_INPUT;
                    break;
                case "CtrlRecipe":
                    strWindowID = CDefine.DEF_WINDOW_MST_RECIPE;
                    break;
                case "CtrlRecipeData":
                    strWindowID = CDefine.DEF_WINDOW_MST_RECIPE_DATA;
                    break;
                case "CtrlRecipeTime":
                    strWindowID = CDefine.DEF_WINDOW_MST_RECIPE_TIME;
                    break;
                case "CtrlUserWindowAuth":
                    strWindowID = CDefine.DEF_WINDOW_MST_USER_WINDOW_AUTH;
                    break;
                case "CtrlFormation":
                    strWindowID = CDefine.DEF_WINDOW_MONI_FORMATION;
                    break;
                case "CtrlFormationHPC":
                    strWindowID = CDefine.DEF_WINDOW_MONI_FORMATION_HPC;
                    break;
                case "CtrlHTAging":
                case "WinHTAgingForDual":
                    strWindowID = CDefine.DEF_WINDOW_MONI_HP_AGING;
                    break;
                case "CtrlRTAging":
                    strWindowID = CDefine.DEF_WINDOW_MONI_RT_AGING;
                    break;
                case "CtrlTotalMonitoring":
                    strWindowID = CDefine.DEF_WINDOW_MONI_TOTAL_MONITORING;
                    break;
                case "WinAgingInfo":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_AGING_INFO;
                    break;
                case "WinAgingRackSetting":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_AGING_RACK_SETTING;
                    break;
                case "WinEqpManualJob":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_EQP_MANUAL_JOB;
                    break;
                //case "WinFormationManualJob":
                //    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_FORMATION_MANUAL_JOB;
                //    break;
                //case "WinHTAgingForDual":
                //    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_HP_AGING_FOR_DUAL;
                    //break;

                case "WinModelChange":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_MODEL_CHANGE;
                    break;
                case "WinTroubleInfo":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_TROUBLE_INFO;
                    break;
                case "CtrlAgingMarginal":
                    strWindowID = CDefine.DEF_WINDOW_RTP_AGING_MARGINAL;
                    break;
                case "CtrlCellHistoryInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_CELL_HISTORY_INFO;
                    break;
                case "CtrlDailyProcessInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_DAILY_PROCESS_INFO;
                    break;
                case "CtrlEqpRepair": 
                    strWindowID = CDefine.DEF_WINDOW_RTP_EQP_REPAIR;
                    break;
                case "CtrlEqpStatusInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_EQP_STATUS_INFO;
                    break;
                case "CtrlEqpStatusReport":
                    strWindowID = CDefine.DEF_WINDOW_RTP_EQP_STATUS_REPORT;
                    break;
                case "CtrlFireRecord":
                    strWindowID = CDefine.DEF_WINDOW_RTP_FIRE_RECORD;
                    break;
                case "CtrlGripper":
                    strWindowID = CDefine.DEF_WINDOW_RTP_GRIPPER;
                    break;
                case "CtrlJudgeReport":
                    strWindowID = CDefine.DEF_WINDOW_RTP_JUDGE_REPORT;
                    break;
                case "CtrlJudgeResultData":
                    strWindowID = CDefine.DEF_WINDOW_RTP_JUDGE_RESULT_DATA;
                    break;
                case "CtrlLogInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_LOG_INFO;
                    break;
                case "CtrlLotMonitoring":
                    strWindowID = CDefine.DEF_WINDOW_RTP_LOT_MONITORING;
                    break;
                case "CtrlProcessMonitoring":
                    strWindowID = CDefine.DEF_WINDOW_RTP_PROCESS_MONITORING;
                    break;
                case "CtrlTemperature":
                    strWindowID = CDefine.DEF_WINDOW_RTP_TEMPERATURE;
                    break;
                case "CtrlTemperatureHPC":
                    strWindowID = CDefine.DEF_WINDOW_RTP_TEMPERATURE_HPC;
                    break;
                case "CtrlTrayCellHistoryInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_TRAY_CELL_HISTORY_INFO;
                    break;
                case "CtrlTrayHistoryInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_TRAY_HISTORY_INFO;
                    break;
                case "CtrlTrayProStepHist":
                    strWindowID = CDefine.DEF_WINDOW_RTP_TRAY_PRO_STEP_HIST;
                    break;
                case "CtrlTroubleAnalysis":
                    strWindowID = CDefine.DEF_WINDOW_RTP_TROUBLE_ANALYSIS;
                    break;
                case "CtrlTroubleInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_TROUBLE_INFO;
                    break;
                case "WinCellMeasurements":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_CELL_MEASUREMENTS;
                    break;
                case "WinEqpRepair":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_EQP_REPAIR;
                    break;
                case "WinEqpStatusHis":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_EQP_STATUS_HIS;
                    break;
                case "WinGradeJudge":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_GRADE_JUDGE;
                    break;
                case "WinManualOutCell":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_MANUAL_OUT_CELL;
                    break;
                case "WinProcChange":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_PROC_CHANGE;
                    break;
                case "WinRouteChange":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_ROUTE_CHANGE;
                    break;
                case "WinTemperatureChart":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_TEMPERATURE_CHART;
                    break;
                case "WinTrayInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_TRAY_INFO;
                    break;
                case "WinTrayManual":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_TRAY_MANUAL;
                    break;
                case "WinTrayManualInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_TRAY_MANUAL_INFO;
                    break;
                case "WinTroubleInput":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_TROUBLE_INPUT;
                    break;
                case "WinTrayStatus":
                    strWindowID = CDefine.DEF_WINDOW_RTP_WIN_TRAY_STATUS_CHANGE;
                    break;
                case "CtrlReWorkUI":
                    strWindowID = CDefine.DEF_WINDOW_RTP_RE_WORK;
                    break;
                case "WinTrayCreate":
                    strWindowID = CDefine.DEF_WINDOW_RTP_RE_WORK_CREATE;
                    break;
                case "WinCellInfo":
                    strWindowID = CDefine.DEF_WINDOW_RTP_CELL_INFO;
                    break;
                case "WinGradeOutSlotSetting":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_OUT_GRADE_SETTING;
                    break;
                case "WinGradeNameEdit":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_GRADE_EDIT;
                    break;
                case "CtrlGradeMonitoring":
                    strWindowID = CDefine.DEF_WINDOW_RTP_JUDGE_DAILY_REPORT;
                    break;
                case "WinCellProcDataInsert":
                    strWindowID = CDefine.DEF_WINDOW_RTP_INSERT_CELL_DATA;
                    break;
                case "WinMainLoopTraffic":
                    strWindowID = CDefine.DEF_WINDOW_MON_MODIFY_MAIN_LOOP_TRAFFIC;
                    break;
                //20200414 KJY for 공트레이 TrayZone 변경
                case "WinChangeTrayZone":
                    strWindowID = CDefine.DEF_WINDOW_RTP_CHANGE_TRAY_ZONE;
                    break;
                //20200611 KJY for AgingRack 안의 Tray의 RouteID변경
                case "WinReserveChangeRouteID":
                    strWindowID = CDefine.DEF_WINDOW_MON_CHANGE_ROUTEID;
                    break;
                //20201215 KJY for 조립설비로 가는 공트레이 제한
                case "WinModifyASMLimit":
                    strWindowID = CDefine.DEF_WINDOW_MON_ASM_LIMIT;
                    break;
                //20201231 KJY for Route 복제 생성
                case "WinCopyRouteID":
                    strWindowID = CDefine.DEF_WINDOW_MST_COPY_ROUTEID;
                    break;

                case "CtrlCellType":
                    strWindowID = CDefine.DEF_WINDOW_MST_CELL_TYPE;
                    break;
                //20211111 KJY - 에이징랙 출고 화면 분리 (계정관리)
                //DEF_WINDOW_MONI_WIN_AGING_RACK_OUT_MANAGE 
                case "WinAgingRackOutManage":
                    strWindowID = CDefine.DEF_WINDOW_MONI_WIN_AGING_RACK_OUT_MANAGE;
                    break;
                default:
                    break;
            }
            #endregion

            return strWindowID;
        }
        #endregion
        
        #region [Authority]
        public static void GetAuthority(string strUserID, string strWindowID, ref bool bAuth_View, ref bool bAuth_Save)
        {
            if (strUserID.Length < 0) return;
            if (strWindowID.Length < 0) return;

            string strFilter = "";

            strFilter += "UserID   = " + "'" + strUserID + "'";
            strFilter += "AND WindowID = " + "'" + strWindowID + "'";

            try
            {
                JsonMstWindowUserList jsonMstWindowUserList = CDatabaseRest.SelectData(Common.enDBTable.MST_WINDOW_USER, strFilter) as JsonMstWindowUserList;

                if (jsonMstWindowUserList == null) return;
                if (jsonMstWindowUserList.code != 0) return;

                bAuth_View = jsonMstWindowUserList.MstWindowUserList[0].Auth_View == "Y" ? true : false;
                bAuth_Save = jsonMstWindowUserList.MstWindowUserList[0].Auth_Save == "Y" ? true : false;
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