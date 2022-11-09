/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : CDataBaseQuery
//  Create Date	    : 
//  Author			: 
//  Remark			: Rest Query 이전까진 여기서 쿼리를 관리.
//                      JSon Format, \n \t 등 안됨
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [Using]
using System.Collections.Generic;
using System.Text;
#endregion

#region [Name Space]
namespace MonitoringUI.Common
{
    #region [Class]
    public class CDataBaseQuery
    {
        #region [QueryToSql]
        public string QueryToSql(enDBTable enTable, List<string> lstVar, string CellID = null,  bool bNGCellFlag=false, string SelectedProc = "")
        {
            string strReturn = "";

            switch (enTable)
            {
                case enDBTable.CTRL_LOG_INFO:
                    strReturn = QueryToCtrlLogInfo(lstVar);
                    break;
                case enDBTable.CTRL_FIRE_RECORD:
                    // 세번째 인자는 "," 로 구분
                    strReturn = QueryToCtrlFireRecord(lstVar);
                    break;
                case enDBTable.MST_TROUBLE:
                     strReturn = QueryToMstTrouble(lstVar);
                    break;
                case enDBTable.CTRL_TROUBLE_INPUT:
                    strReturn = QueryToTroubleInput(lstVar);
                    break;
                case enDBTable.CTRL_TROUBLE_INFO:
                    strReturn = QueryToTroubleInfo(lstVar);
                    break;
                case enDBTable.CTRL_TROUBLE_ANALYSIS:
                    strReturn = QueryToTroubleAnalysis(lstVar);
                    break;
                case enDBTable.TRAY_CURR:
                    //TrayID 조회
                    if (lstVar.Count == 4) strReturn = QueryToTrayHistoryInfoCurrTray(lstVar);
                    else strReturn = QueryToTrayHistoryInfoCurr(lstVar);
                    break;
                case enDBTable.WIN_PROC_CHANGE:
                    strReturn = QueryToWinProcChange(lstVar);
                    break;
                case enDBTable.WIN_TRAY_INFO:           //Curr
                    strReturn = QueryToWinTrayInfo(lstVar);
                    break;
                case enDBTable.HIST_DB_WIN_TRAY_INFO:   //Hist
                    strReturn = QueryToWinTrayInfoHist(lstVar);
                    break;
                case enDBTable.WIN_TRAY_MANUAL_EQP_CHK:
                    strReturn = QueryToWinTrayManualEQPCheck(lstVar[0], lstVar[1], lstVar[2], lstVar[3]);
                    break;
                //중문 명칭 때문에 필요.
                case enDBTable.ROUTE_OPER:
                    strReturn = QueryToRouteOper(lstVar);
                    break;
                case enDBTable.CTRL_TEMPERATURE:
                    strReturn = QueryToTemperature(lstVar);
                    break;
                case enDBTable.CTRL_TEMPERATURE_HPC:
                    strReturn = QueryToTemperatureHPC(lstVar);                    
                    break;
                case enDBTable.WIN_EQP_STATUS:
                    strReturn = QueryToEqpStatusHis(lstVar[0], lstVar[1], lstVar[2], lstVar[3], lstVar[4], lstVar[5]);
                    break;
                case enDBTable.CTRL_AGING_MARGINAL:
                    strReturn = QueryToAgingMarginal(lstVar[0]);
                    break;
                case enDBTable.MST_EQUIPMENT:
                    strReturn = QueryToMstEquipment(lstVar);
                    break;
                case enDBTable.CTRL_PROC_MONI:
                    strReturn = QueryToProcMoni(lstVar[0], lstVar[1], lstVar[2], lstVar[3]);
                    break;
                case enDBTable.CTRL_LOT_MONI:
                    strReturn = QueryToLotMoni(lstVar[0], lstVar[1], lstVar[2], lstVar[3], lstVar[4], lstVar[5], lstVar[6]);
                    break;
                case enDBTable.CELL_PRO_DATA:
                    if (lstVar.Count == 2)
                    {
                        //CellID 조회
                        strReturn = QueryToCellHisInfo(lstVar[0], lstVar[1], lstVar[2]);
                    }
                    else
                    {
                        strReturn = QueryToCellHisInfo(lstVar[0], lstVar[1], lstVar[2], lstVar[3], lstVar[4], lstVar[5], lstVar[6], lstVar[7], lstVar[8]);
                    }

                    break;
                case enDBTable.CTRL_GRIPPER:
                    strReturn = QueryToGripper(lstVar);
                    break;
                case enDBTable.CTRL_EQP_REPAIR:
                    strReturn = QueryToEqpRepair(lstVar);
                    break;
                case enDBTable.CTRL_EQP_STATUS_REPORT:
                    strReturn = QueryToEqpStatusReport(lstVar[0], lstVar[1], lstVar[2], lstVar[3], lstVar[4]);
                    break;
                case enDBTable.HIST_DB_TRAY_CELL_HIST:
                    strReturn = QueryToHistTray(lstVar);
                    break;
                case enDBTable.GRID_CELL_PRO_STEP_DATA:
                    //strReturn = QueryToCellProcStepData(lstVar, CellID, bNGCellFlag);
                    //strReturn = QueryToCellProcStepDataFromView(lstVar, CellID, bNGCellFlag, SelectedProc);
                    // 20191129 KJY - Query 수정
                    strReturn = QueryToCellProcStepDataNoDuplication(lstVar, CellID, bNGCellFlag, SelectedProc);
                    break;
                case enDBTable.HIST_DB_GRID_CELL_PRO_STEP_DATA:
                    strReturn = QueryToHistCellProcStepData(lstVar);
                    break;
                case enDBTable.UNIT_STATE:
                    strReturn = QueryToUnitState(lstVar);
                    break;
                case enDBTable.TRAYCURR_PROC:
                    strReturn = QueryTrayCurrWithProc(lstVar);
                    break;
                case enDBTable.TRAYCURR_PROCID:     // QueryTrayCurrWithProc() 사용하는 곳이 있어서 함수 새로 만듬.
                    strReturn = QueryTrayCurrByProStepWithProcID(lstVar);
                    break;
            }

            strReturn = strReturn.Replace("\r", " ");
            strReturn = strReturn.Replace("\n", " ");
            strReturn = strReturn.Replace("\t", " ");

            return strReturn;
        }
        #endregion

        #region [QueryToMstEquipment]
        //Table
        //tMstEquipment A
        //tMstEqpGroup  B
        //Form
        //CtrlEqpStatusInfo
        //CtrlEqpStatusReport
        private string QueryToMstEquipment(List<string>lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strEqpTypeID = null;
            string strUnitID = null;
            string strUnitStatus = null;
            string strAbnormalBox = null;

            if (lstVar.Count != 5) return "";

            strLineID = lstVar[0];
            strEqpTypeID = lstVar[1];
            strUnitID = lstVar[2];
            strUnitStatus = lstVar[3];
            strAbnormalBox = lstVar[4];

            // Set Query
            strSQL.Append(" SELECT A.* , B.EqpTypeName");
            strSQL.Append("   FROM tMstEquipment         A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstEqpGroup B WITH (NOLOCK)");
            strSQL.Append("          ON B.EqpTypeID	    = A.EqpTypeID");
            //필수값
            strSQL.Append($" WHERE A.LineID	            = '{strLineID}'");
            //조회조건
            if(strEqpTypeID.Length > 0) strSQL.Append($"   AND A.EqpTypeID	    = '{strEqpTypeID}'");
            if (strUnitID.Length > 0) strSQL.Append($"   AND A.UnitID	        = '{strUnitID}'");

            //조건
            //1. 전체보기
            //2. 장비 상태에 따른 조회
            //3. 부동박스-특정상태 조회
            //부동박스보기
            if (strAbnormalBox == "Y")
            {
                strSQL.Append("   AND A.UnitStatus	IN '('O', 'N', 'T', 'A' ,'S' )'");
            }
            else
            {
                if (strUnitStatus.Length > 0) strSQL.Append($"   AND A.UnitStatus	    LIKE '{strUnitStatus + "%"}'");
            }
            
            strSQL.Append("ORDER BY A.EqpTypeID ASC, A.UnitID ASC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToCtrlLogInfo]
        //Table
        //tUserEvent  A
        //tMstWindow  B
        //tMstUser    C
        //Form
        //CtrlLogInfo
        private string QueryToCtrlLogInfo(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartDate = null;
            string strEndDate = null;
            string strUserEvent = null;

            if (lstVar.Count != 4) return "";

            strLineID = lstVar[0];
            strStartDate = lstVar[1];
            strEndDate = lstVar[2];
            strUserEvent = lstVar[3];

            // Set Query
            strSQL.Append(" SELECT A.WindowID,		A.EqpTypeID,		A.UnitID,       A.CmdID");
            strSQL.Append("       , A.UserID,		    A.UserEvent");
            strSQL.Append("       , (CASE ISNULL(A.UpdateTime, '') WHEN '' THEN A.UpdateTime ELSE CONVERT(VARCHAR(30), A.UpdateTime, 120) END) UpdateTime");
            strSQL.Append("       , B.WindowName_kr,	B.WindowName_cn,	B.WindowName_en");
            strSQL.Append("       , C.UserName");
            strSQL.Append("   FROM tUserEvent         A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstWindow B WITH (NOLOCK)");
            strSQL.Append("          ON B.WindowID	    = A.WindowID");
            strSQL.Append("        LEFT OUTER JOIN tMstUser C WITH (NOLOCK)");
            strSQL.Append("          ON C.UserID	    = A.UserID");
            //필수조건
            strSQL.Append($" WHERE A.LineID		          = '{strLineID}'");
            strSQL.Append($"   AND A.UpdateTime		BETWEEN '{strStartDate}'");
            strSQL.Append($" 							AND '{strEndDate}'");
            //LIKE
            if (strUserEvent.Length > 0) strSQL.Append($"  AND A.UserEvent		   LIKE '{ "%" + strUserEvent + "%"}'");

            strSQL.Append("ORDER BY A.UpdateTime DESC ");

            return strSQL.ToString();
        }
        #endregion

        #region [Trouble]
        #region [QueryToCtrlFireRecord]
        // Trouble 정보중 화재 정보만을 보기위한 쿼리
        //Table
        //tTroubleEventTM           A
        //tMstEquipment             B
        //tMstTrouble               C
        //tMstAgingRack             D
        //tMstEqpGroup              E
        //Form
        //CtrlFireRecord
        private string QueryToCtrlFireRecord(List<string>lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strLineID = null;
            string strStartDate = null;
            string strEndDate = null;
            string strTroubleCode = null;

            if (lstVar.Count != 4) return "";

            strLineID = lstVar[0];
            strStartDate = lstVar[1];
            strEndDate = lstVar[2];
            strTroubleCode = lstVar[3]; //20191223 KJY - TroubleCode아니구 EqpTypeID
            
            // Set Query
            strSQL.Append("SELECT A.EqpTypeID,		A.UnitID,			A.TroubleCode,		A.TroubleLevel");
            strSQL.Append("     , (CASE ISNULL(A.EventTime, '') WHEN '' THEN A.EventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventTime");
            strSQL.Append("     , A.UserAction,		A.UnitStatus Status");
            strSQL.Append("     , (CASE ISNULL(A.UserEventTime, '') WHEN '' THEN A.UserEventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.UserEventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS UserEventTime");
            strSQL.Append("     , (CASE WHEN A.UserAction IS NULL THEN 'N' ELSE 'Y' END) ActionFlag");
            strSQL.Append("     , B.UnitName,			B.unitStatus");
            strSQL.Append("     , (CASE WHEN B.TrayID IS NULL THEN 'N' ELSE 'Y' END) TrayID");
            strSQL.Append("     , C.TroubleName_kr,		C.TroubleName_cn,	C.TroubleName_en, C.UserAction_kr, C.UserAction_cn, C.UserAction_en");
            strSQL.Append("     , D.RackID");
            strSQL.Append("     , E.EqpTypeName");
            strSQL.Append("     , SUBSTRING(D.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(D.RackID, 2, 2))) + '-' + SUBSTRING(D.RackID, 4, 1) + 'Line-' + SUBSTRING(D.RackID, 5, 2) + 'Bay-' + SUBSTRING(D.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append("  FROM tTroubleEventTM A WITH (NOLOCK)");
            strSQL.Append("       LEFT OUTER JOIN tMstEquipment B WITH (NOLOCK)");
            strSQL.Append("         ON B.EqpTypeID	= A.EqpTypeID");
            strSQL.Append("        AND B.UnitID		= A.UnitID");
            strSQL.Append("       LEFT OUTER JOIN tMstTrouble	C WITH (NOLOCK)");
            strSQL.Append("         ON C.TroubleCode	= A.TroubleCode");
            //20191223 KJY
            strSQL.Append("        AND C.EqpTypeID		= A.EqpTypeID");
            strSQL.Append("       LEFT OUTER JOIN tMstAgingRack D WITH (NOLOCK)");
            strSQL.Append("         ON D.RackID		= A.UnitID");
            strSQL.Append("       LEFT OUTER JOIN tMstEqpGroup	E WITH (NOLOCK)");
            strSQL.Append("         ON E.EqptypeID	= A.EqptypeID");

            //필수
            strSQL.Append($" WHERE A.LineID  			      = '{strLineID}'");
            strSQL.Append($"   AND A.EventTime			BETWEEN '{strStartDate}'");
            strSQL.Append($"                                AND '{strEndDate}'");

            //조건
            //if (strTroubleCode.Contains(",") == true)
            //{
            //    strSQL.Append($"    AND A.TroubleCode		IN ('{strTroubleCode }')");
            //}
            //else
            //{
            //    strSQL.Append($"    AND (A.TroubleCode		= '{strTroubleCode }'");
            //}
            strSQL.Append($"                                AND  A.TroubleCode = '102' ");
            if (strTroubleCode.Contains(",") == true)
            {
                strSQL.Append($"    AND A.EqpTypeID		IN ('{strTroubleCode }')");
            }
            else
            {
                strSQL.Append($"    AND  A.EqpTypeID		= '{strTroubleCode }'");
            }



                //Group By
            strSQL.Append(" GROUP BY A.EqpTypeID,		A.UnitID,			A.EventTime,		A.TroubleCode,		A.TroubleLevel");
            strSQL.Append("    , A.UserEventTime,	A.UserAction,		A.UnitStatus");
            strSQL.Append("    , (CASE WHEN A.UserAction IS NULL THEN 'N' ELSE 'Y' END)");
            strSQL.Append("    , B.UnitName,			B.unitStatus");
            strSQL.Append("    , (CASE WHEN B.TrayID IS NULL THEN 'N' ELSE 'Y' END)");
            strSQL.Append("    , C.TroubleName_kr,		C.TroubleName_cn,	C.TroubleName_en, C.UserAction_kr, C.UserAction_cn, C.UserAction_en");
            strSQL.Append("    , D.RackID");
            strSQL.Append("    , E.EqpTypeName");
            strSQL.Append("  ORDER BY A.EventTime DESC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToMstTrouble]
        // Mster Trouble Input
        //Table
        //tMstTrouble              A
        //tMstEqpGroup             B
        //Form
        //CtrlMstTrouble
        private string QueryToMstTrouble(List<string>lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strEqpTypeID = null;

            if (lstVar.Count != 1) return "";

            strEqpTypeID = lstVar[0];
           
            strSQL.Append(" SELECT B.EqpTypeName,	    A.EqpTypeID,		A.TroubleCode");
            strSQL.Append("      , A.TroubleName_kr,	A.TroubleName_cn,	A.TroubleName_en");
            strSQL.Append("      , A.UserAction_kr,	    A.UserAction_en,	A.UserAction_cn");
            strSQL.Append("      , A.ErrLevel");
            strSQL.Append("   FROM tMstTrouble A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstEqpGroup B WITH (NOLOCK)");
            strSQL.Append("          ON B.EqpTypeID	= A.EqpTypeID");
            //조건
            strSQL.Append($" WHERE A.EqpTypeID	    LIKE '{strEqpTypeID + "%"}'");
            strSQL.Append("  ORDER BY A.EqpTypeID ASC, A.TroubleCode ASC ");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToTroubleInput]
        // Trouble Input, 장애조치방법 입력
        //Table
        //tTroubleEventTM   A
        //tMstTrouble       B
        //Form
        //WinTroubleInput
        private string QueryToTroubleInput(List<string>lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strLineID = null;
            string strEqpTypeID = null;
            string strUnitID = null;
            string strEventTime = null;

            if (lstVar.Count != 4) return "";

            strLineID = lstVar[0];
            strEqpTypeID = lstVar[1];
            strUnitID = lstVar[2];
            strEventTime = lstVar[3];

            // Set Query
            strSQL.Append(" SELECT A.EqpTypeID,		A.UnitID,			A.EventTime,		A.TroubleCode,		A.TroubleLevel");
            strSQL.Append("      , A.UserEventTime,	A.UserAction");
            strSQL.Append("      , B.TroubleName_kr");
            strSQL.Append("      , B.TroubleName_cn");
            strSQL.Append("      , B.TroubleName_en");
            strSQL.Append("      , B.UserAction_kr");
            strSQL.Append("      , B.UserAction_cn");
            strSQL.Append("      , B.UserAction_en");

            strSQL.Append("   FROM tTroubleEventTM A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstTrouble	B WITH (NOLOCK)");
            strSQL.Append("          ON B.TroubleCode	        = A.TroubleCode");
            strSQL.Append("         AND B.EqpTypeID	            = A.EqpTypeID");
            //필수
            strSQL.Append($" WHERE A.LineID			    = '{strLineID}'");
            strSQL.Append($"   AND A.EqpTypeID			= '{strEqpTypeID}'");
            strSQL.Append($"   AND A.UnitID			    = '{strUnitID}'");
            strSQL.Append($"   AND A.EventTime			= '{strEventTime}'");

            strSQL.Append(" ORDER BY A.EventTime DESC ");
            return strSQL.ToString();
        }
        #endregion

        #region [QueryToTroubleInfo]
        //Table
        //tTroubleEventTm   A
        //tMstTrouble       B
        //tMstEqpGroup      C
        //tMstEquipment     D
        //tMstAgingRack     E
        //Form
        //CtrlTroubleInfo
        private string QueryToTroubleInfo(List<string>lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strLineID = null;
            string strProc = null;
            string strMachine = null;
            string strTroubleName = null;
            string strStartDate = null;
            string strEndDate = null;

            if (lstVar.Count != 6) return "";

            strLineID = lstVar[0];
            strStartDate = lstVar[1];
            strEndDate = lstVar[2];
            strProc = lstVar[3];
            strMachine = lstVar[4];
            strTroubleName = lstVar[5];
           
            // Set Query
            strSQL.Append(" SELECT A.EqpTypeID,		A.UnitID");
            strSQL.Append("       , (CASE ISNULL(A.EventTime, '') WHEN '' THEN A.EventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventTime");
            strSQL.Append("       , A.UserAction,		A.TroubleCode,      A.UnitStatus");
            strSQL.Append("       , (CASE ISNULL(A.UserEventTime, '') WHEN '' THEN A.UserEventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.UserEventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS UserEventTime");
            strSQL.Append("       , B.TroubleName_kr,	B.TroubleName_cn,	B.TroubleName_en");
            strSQL.Append("       , C.EqpTypeName,	D.UnitName");
            strSQL.Append("       , (CASE WHEN A.UserAction IS NULL THEN 'N' ELSE 'Y' END) ActionFlag");
            strSQL.Append("       , SUBSTRING(E.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(E.RackID, 2, 2))) + '-' + SUBSTRING(E.RackID, 4, 1) + 'Line-' + SUBSTRING(E.RackID, 5, 2) + 'Bay-' + SUBSTRING(E.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append("   FROM tTroubleEventTm A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstTrouble B WITH (NOLOCK)");
            strSQL.Append("          ON B.EqpTypeID	= A.EqpTypeID");
            strSQL.Append("         AND B.TroubleCode	= A.TroubleCode");
            strSQL.Append("        LEFT OUTER JOIN tMstEqpGroup C WITH (NOLOCK)");
            strSQL.Append("          ON C.EqpTypeID	= A.EqpTypeID");
            strSQL.Append("        LEFT OUTER JOIN tMstEquipment D WITH (NOLOCK)");
            strSQL.Append("          ON D.EqpTypeID	= A.EqpTypeID");
            strSQL.Append("         AND D.UnitID   	= A.UnitID");
            strSQL.Append("        LEFT OUTER JOIN tMstAgingRack E WITH (NOLOCK)");
            strSQL.Append("          ON E.RackID			= A.UnitID");
            //필수
            strSQL.Append($" WHERE A.LineID			          = '{strLineID}'");
            strSQL.Append($"   AND A.EventTime			BETWEEN '{strStartDate}'");
            strSQL.Append($" 							    AND '{strEndDate}'");
            //조건
            if(strProc.Length > 0)strSQL.Append($"   AND A.EqpTypeID			   = '{strProc}'");
            if (strMachine.Length > 0) strSQL.Append($"   AND A.UnitID			       = '{strMachine}'");
            if (strTroubleName.Length > 0) strSQL.Append($"   AND A.TroubleCode		   = '{strTroubleName}'");

            strSQL.Append("   ORDER BY A.EventTime DESC ");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToTroubleAnalysis]
        //Table
        //tTroubleEventTm   A
        //tMstTrouble       B
        //tMstEqpGroup      C
        //tMstEquipment     D
        //tMstAgingRack     E
        //Form
        //CtrlTroubleAnalysis
        private string QueryToTroubleAnalysis(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strLineID = null;
            string strProc = null;
            string strMachine = null;
            string strStartDate = null;
            string strEndDate = null;

            if (lstVar.Count != 5) return "";

            strLineID = lstVar[0];
            strStartDate = lstVar[1];
            strEndDate = lstVar[2];
            strProc = lstVar[3];
            strMachine = lstVar[4];
           
            // Set Query
            strSQL.Append(" SELECT A.EqpTypeID, A.TroubleCnt, A.TroubleCode, A.UnitID");
            strSQL.Append("      , B.TroubleName_kr,	B.TroubleName_cn,	B.TroubleName_en");
            strSQL.Append("      , C.EqpTypeName,  D.UnitName");
            strSQL.Append("      , SUBSTRING(E.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(E.RackID, 2, 2))) + '-' + SUBSTRING(E.RackID, 4, 1) + 'Line-' + SUBSTRING(E.RackID, 5, 2) + 'Bay-' + SUBSTRING(E.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append("   FROM ");
            strSQL.Append("      (");
            strSQL.Append("        SELECT EqpTypeID , UnitID, TroubleCode, COUNT(EventTime)TroubleCnt");
            strSQL.Append("          FROM tTroubleEventTm WITH (NOLOCK)");
            //필수
            strSQL.Append($"        WHERE LineID			       = '{strLineID}'");
            strSQL.Append($"          AND EventTime			BETWEEN '{strStartDate}'");
            strSQL.Append($" 		        					AND '{strEndDate}'");
            //조건
            if(strProc.Length > 0) strSQL.Append($"          AND EqpTypeID			    = '{strProc}'");
            if (strMachine.Length > 0) strSQL.Append($"          AND UnitID			    = '{strMachine}'");

            strSQL.Append("        GROUP BY EqpTypeID, UnitID, TroubleCode");
            strSQL.Append("      )A");
            strSQL.Append("       LEFT OUTER JOIN tMstTrouble B WITH (NOLOCK)");
            strSQL.Append("         ON B.EqpTypeID	    = A.EqpTypeID");
            strSQL.Append("        AND B.TroubleCode	= A.TroubleCode");
            strSQL.Append("       LEFT OUTER JOIN tMstEqpGroup C WITH (NOLOCK)");
            strSQL.Append("         ON C.EqpTypeID	    = A.EqpTypeID");
            strSQL.Append("       LEFT OUTER JOIN tMstEquipment D WITH (NOLOCK)");
            strSQL.Append("         ON D.EqpTypeID	    = A.EqpTypeID");
            strSQL.Append("        AND D.UnitID   	    = A.UnitID");
            strSQL.Append("       LEFT OUTER JOIN tMstAgingRack E WITH (NOLOCK)");
            strSQL.Append("         ON E.RackID			= A.UnitID");
            strSQL.Append(" ORDER BY A.EqpTypeID ASC, A.UnitID ASC, A.TroubleCode ASC");
            return strSQL.ToString();
        }
        #endregion
        #endregion

        #region [QueryToTrayHistoryInfoCurr]
        //Table
        //tTrayCurr         A
        //tMstOperation     B
        //tMstEquipment     C
        //tMstAgingRack     D
        //Form
        //CtrlTrayHistoryInfo
        //CtrlDailyProcessInfo
        //QueryToTrayHistoryInfoCurrTray
        private string QueryToTrayHistoryInfoCurr(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartTime = null;
            string strEndTime = null;
            string strModelID = null;
            string strRouteID = null;
            string strLotID = null;
            string strEqpTypeID = null;
            string strOperGroupID = null;
            string strOperID = null;

            if (lstVar.Count != 9) return "";

            strLineID = lstVar[0];
            strStartTime = lstVar[1];
            strEndTime = lstVar[2];
            strModelID = lstVar[3];
            strRouteID = lstVar[4];
            strLotID = lstVar[5];
            strEqpTypeID = lstVar[6];
            strOperGroupID = lstVar[7];
            strOperID = lstVar[8];

            strSQL.Append("SELECT A.LotID, A.TrayID");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputDate, '') WHEN '' THEN A.TrayInputDate ELSE CONVERT(VARCHAR(10), CONVERT(DATE, A.TrayInputDate), 120) END) AS TrayInputDate");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputTime, '') WHEN '' THEN A.TrayInputTime ELSE CONVERT(VARCHAR(8), CONVERT(TIME, stuff(stuff(A.TrayInputTime, 3, 0, ':'), 6, 0, ':')), 108) END) AS TrayInputTime");
            strSQL.Append("     , A.ProdModel, A.RouteID, A.Status");
            strSQL.Append("     , A.BarObjectID");
            strSQL.Append("     , (CASE ISNULL(A.BarReadTime, '') WHEN '' THEN A.BarReadTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(A.BarReadTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS BarReadTime");
            strSQL.Append("     , A.EqpTypeID, A.OperGroupID, A.OperID");
            strSQL.Append("     , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime");
            strSQL.Append("     , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime");
            strSQL.Append("     , ISNULL(A.CurrCellCnt, 0) CurrCellCnt");
            strSQL.Append("     , ISNULL(A.InputCellCnt, 0) InputCellCnt");
            strSQL.Append("     , ISNULL(A.InputCellCnt, 0) - ISNULL(A.CurrCellCnt, 0) NgCellCnt");
            strSQL.Append("     , B.OperName CurrOperName");
            strSQL.Append("     , F.OperName NextOperName");
            strSQL.Append("     , D.UnitName");
            strSQL.Append("     , E.RackID");
            strSQL.Append("     , SUBSTRING(E.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(E.RackID, 2, 2))) + '-' + SUBSTRING(E.RackID, 4, 1) + 'Line-' + SUBSTRING(E.RackID, 5, 2) + 'Bay-' + SUBSTRING(E.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append("  FROM tTrayCurr A WITH(NOLOCK)");
            strSQL.Append("      LEFT OUTER JOIN tMstOperation B WITH(NOLOCK)");
            strSQL.Append("        ON B.EqpTypeID   = A.EqpTypeID");
            strSQL.Append("       AND B.OperGroupID = A.OperGroupID");
            strSQL.Append("       AND B.OperID      = A.OperID");
            strSQL.Append("      LEFT OUTER JOIN tMstEquipment D WITH(NOLOCK)");
            strSQL.Append("        ON D.EqpTypeID   = B.EqpTypeID");
            strSQL.Append("       AND D.TrayID      = A.TrayID");
            strSQL.Append("      LEFT OUTER JOIN tMstAgingRack E WITH(NOLOCK)");
            strSQL.Append("        ON E.LineID      = A.LineID");
            strSQL.Append("       AND E.TrayID      = A.TrayID");
            strSQL.Append("      LEFT OUTER JOIN tMstOperation F WITH(NOLOCK)");
            strSQL.Append("        ON F.EqpTypeID   = A.NextEqpTypeID");
            strSQL.Append("       AND F.OperGroupID = A.NextOperGroupID");
            strSQL.Append("       AND F.OperID      = A.NextOperID");

            //필수
            strSQL.Append($" WHERE A.LineID                                  = '{strLineID}'");
            strSQL.Append($"   AND A.StartTime                         BETWEEN '{strStartTime}'");
            strSQL.Append($"                                               AND '{strEndTime}'");
            strSQL.Append($"   AND A.ProdModel				                 = '{strModelID}'");
            strSQL.Append($"   AND A.RouteID				                 = '{strRouteID}'");
            //조건
            if (strLotID.Length > 0) strSQL.Append($"   AND A.LotID					 = '{strLotID}'");
            if (strEqpTypeID.Length > 0) strSQL.Append($"   AND B.EqpTypeID                    = '{strEqpTypeID}'");
            if (strOperGroupID.Length > 0) strSQL.Append($"   AND B.OperGroupID                  = '{strOperGroupID}'");
            if (strOperID.Length > 0) strSQL.Append($"   AND B.OperID                       =  '{strOperID}'");

            strSQL.Append(" ORDER BY A.StartTime DESC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToTrayHistoryInfoCurrTray, Outer Join]
        //Table
        //tTrayCurr         A
        //tMstOperation     B
        //tMstEquipment     C
        //tMstAgingRack     D
        //Form
        //CtrlTrayHistoryInfo
        //CtrlDailyProcessInfo
        private string QueryToTrayHistoryInfoCurrTray(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartTime = null;
            string strEndTime = null;
            string strTrayID = null;

            if (lstVar.Count != 4) return "";

            strLineID = lstVar[0];
            strTrayID = lstVar[1];
            strStartTime = lstVar[2];
            strEndTime = lstVar[3];

            strSQL.Append("SELECT A.LotID, A.TrayID");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputDate, '') WHEN '' THEN A.TrayInputDate ELSE CONVERT(VARCHAR(10), CONVERT(DATE, A.TrayInputDate), 120) END) AS TrayInputDate");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputTime, '') WHEN '' THEN A.TrayInputTime ELSE CONVERT(VARCHAR(8), CONVERT(TIME, stuff(stuff(A.TrayInputTime, 3, 0, ':'), 6, 0, ':')), 108) END) AS TrayInputTime");
            strSQL.Append("     , A.ProdModel, A.RouteID, A.Status");
            strSQL.Append("     , A.BarObjectID");
            strSQL.Append("     , (CASE ISNULL(A.BarReadTime, '') WHEN '' THEN A.BarReadTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(A.BarReadTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS BarReadTime");
            strSQL.Append("     , A.EqpTypeID, A.OperGroupID, A.OperID");
            strSQL.Append("     , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime");
            strSQL.Append("     , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime");
            strSQL.Append("     , ISNULL(A.CurrCellCnt, 0) CurrCellCnt");
            strSQL.Append("     , ISNULL(A.InputCellCnt, 0) InputCellCnt");
            strSQL.Append("     , ISNULL(A.InputCellCnt, 0) - ISNULL(A.CurrCellCnt, 0) NgCellCnt");
            strSQL.Append("     , B.OperName CurrOperName");
            strSQL.Append("     , F.OperName NextOperName");
            strSQL.Append("     , D.UnitName");
            strSQL.Append("     , E.RackID");
            strSQL.Append("     , SUBSTRING(E.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(E.RackID, 2, 2))) + '-' + SUBSTRING(E.RackID, 4, 1) + 'Line-' + SUBSTRING(E.RackID, 5, 2) + 'Bay-' + SUBSTRING(E.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append("  FROM tTrayCurr A WITH(NOLOCK)");
            strSQL.Append("      LEFT OUTER JOIN tMstOperation B WITH(NOLOCK)");
            strSQL.Append("        ON B.EqpTypeID   = A.EqpTypeID");
            strSQL.Append("       AND B.OperGroupID = A.OperGroupID");
            strSQL.Append("       AND B.OperID      = A.OperID");
            strSQL.Append("      LEFT OUTER JOIN tMstEquipment D WITH(NOLOCK)");
            strSQL.Append("        ON D.EqpTypeID   = B.EqpTypeID");
            strSQL.Append("       AND D.TrayID      = A.TrayID");
            strSQL.Append("      LEFT OUTER JOIN tMstAgingRack E WITH(NOLOCK)");
            strSQL.Append("        ON E.LineID      = A.LineID");
            strSQL.Append("       AND E.TrayID      = A.TrayID");
            strSQL.Append("      LEFT OUTER JOIN tMstOperation F WITH(NOLOCK)");
            strSQL.Append("        ON F.EqpTypeID   = A.NextEqpTypeID");
            strSQL.Append("       AND F.OperGroupID = A.NextOperGroupID");
            strSQL.Append("       AND F.OperID      = A.NextOperID");
            //필수
            strSQL.Append($" WHERE A.LineID                                  = '{strLineID}'");
            strSQL.Append($"   AND A.StartTime                         BETWEEN '{strStartTime}'");
            strSQL.Append($"                                               AND '{strEndTime}'");
            strSQL.Append($"   AND A.TrayID				                     = '{strTrayID}'");

            strSQL.Append(" ORDER BY A.StartTime DESC");

            return strSQL.ToString();
        }
        #endregion

        // 20190531 KJY - Proc을 탔었던 Tray검색
        private string QueryTrayCurrWithProc(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartTime = null;
            string strEndTime = null;
            string strTrayID = null;
            string strModelID = string.Empty;
            string strRouteID = string.Empty;
            string strLotID = string.Empty;
            string strRowNumber = string.Empty;

            string strObjectID = string.Empty;

            strLineID = lstVar[1];
            strTrayID = lstVar[0];
            strStartTime = lstVar[2];
            strEndTime = lstVar[3];

            strModelID = lstVar[4];
            strRouteID = lstVar[5];
            strLotID = lstVar[6];

            strRowNumber = lstVar[7];

            if (lstVar.Count > 8)
                strObjectID = lstVar[8];


            strSQL.Append("SELECT A.* , B.RowNumber as RowNumber");
            strSQL.Append("  FROM tTrayCurr A WITH(NOLOCK)");
            strSQL.Append("      LEFT OUTER JOIN tMstRouteOper B WITH(NOLOCK)");
            strSQL.Append("        ON B.EqpTypeID   = A.EqpTypeID");
            strSQL.Append("       AND B.OperGroupID = A.OperGroupID");
            strSQL.Append("       AND B.OperID      = A.OperID");

            strSQL.Append("       AND B.ProdModel      = A.ProdModel");
            strSQL.Append("       AND B.RouteID      = A.RouteID");

            // 해당공정 시작시간으로 검색하기 위해 
            strSQL.Append("      LEFT OUTER JOIN tTrayProStep C WITH(NOLOCK)");
            strSQL.Append("        ON C.TrayID = A.TrayID AND C.TrayInputDate = A.TrayInputDate AND C.TrayInputTime = A.TrayInputTime AND  C.EqpTypeID = A.EqpTypeID AND C.OperGroupID = A.OperGroupID AND C.OperID = A.OperID");

            //필수
            strSQL.Append($" WHERE A.LineID                                  = '{strLineID}'");
            
            if (strModelID.Length > 0)
                strSQL.Append($"   AND A.ProdModel                              = '{strModelID}'");
            if (strRouteID.Length > 0)
                strSQL.Append($"   AND A.RouteID                              = '{strRouteID}'");
            if(strLotID.Length > 0)
                strSQL.Append($"   AND A.LotID                              = '{strLotID}'");
            if (strRowNumber.Length > 0)
                strSQL.Append($"   AND RowNumber				               >=   {strRowNumber}");
            //strSQL.Append($"   AND RowNumber				               =   {strRowNumber}");

            strSQL.Append($"   AND C.StartTime                         BETWEEN '{strStartTime}'");
            strSQL.Append($"                                               AND '{strEndTime}'");
            strSQL.Append($"   AND C.ProcWorkIndex				            =   0");

            if (strObjectID.Length > 0)
            {
                strSQL.Append($"   AND A.ObjectID                              = '{strObjectID}'");
            }



            strSQL.Append(" ORDER BY A.StartTime DESC");

            return strSQL.ToString();
        }

        /// <summary>
        /// 지난공정 ID(procID)로 조회할 경우 사용
        /// </summary>
        /// <param name="lstVar"></param>
        /// <returns></returns>
        private string QueryTrayCurrByProStepWithProcID(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartTime = null;
            string strEndTime = null;
            string strTrayID = null;
            string strModelID = string.Empty;
            string strRouteID = string.Empty;
            string strLotID = string.Empty;
            string strProcID = string.Empty;
            CMapProcID proc = new CMapProcID();

            string strObjectID = string.Empty;

            strLineID = lstVar[1];
            strTrayID = lstVar[0];
            strStartTime = lstVar[2];
            strEndTime = lstVar[3];

            strModelID = lstVar[4];
            strRouteID = lstVar[5];
            strLotID = lstVar[6];

            strProcID = lstVar[7];
            if (!string.IsNullOrEmpty(strProcID))
            {
                proc = CUserFunction.SplitProcID(strProcID);
            }

            if (lstVar.Count > 8)
                strObjectID = lstVar[8];

            strSQL.Append("SELECT A.* FROM tTrayCurr A WITH(NOLOCK) ");
            strSQL.Append(" INNER JOIN(");
            strSQL.Append("     SELECT LineID, TrayID, TrayInputDate, TrayInputTime FROM tTrayProStep WITH(NOLOCK) ");
            strSQL.Append($"    WHERE StartTime BETWEEN  '{strStartTime}' AND '{strEndTime}' ");
            strSQL.Append($"     AND LineID = '{strLineID}' ");
            if (strModelID.Length > 0)
                strSQL.Append($" AND ProdModel = '{strModelID}' ");
            if (strRouteID.Length > 0)
                strSQL.Append($" AND RouteID = '{strRouteID}' ");
            if (strLotID.Length > 0)
                strSQL.Append($" AND LotID = '{strLotID}' ");
            strSQL.Append($"      AND EqpTypeID = '{proc.EqpTypeID}' AND OperGroupID = '{proc.OperGroupID}' AND OperID = '{proc.OperID}'");
            strSQL.Append("      And ProcWorkIndex = 0 ");
            if (strObjectID.Length > 0)
                strSQL.Append($" AND ObjectID = '{strObjectID}'");
            strSQL.Append("     ) B");
            strSQL.Append(" ON A.LineID = B.LineID AND A.TrayID = B.TrayID AND A.TrayInputDate = B.TrayInputDate AND A.TrayInputTime = B.TrayInputTime");
            strSQL.Append(" WHERE Flag <> 'E' AND Flag is not null");
            strSQL.Append(" ORDER BY A.StartTime DESC");

            return strSQL.ToString();
        }




        #region [QueryToWinProcChange]
        //Table
        //tMstAgingRack     A
        //tTrayCurr         B
        //tMstRouteOper     C
        //tMstRouteOper     D Next
        //tMstOperation     E
        //tMstOperation     F Next
        //Form
        //WinProcChange
        //Moniter -> WinAgingInfo
        //# tTrayCurr와 tMstAgingRack 정보가 꼬이는 경우가 생긴다.
        private string QueryToWinProcChange(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = "";
            string strModel = "";
            string strRouteID = "";
            string strLotID = "";
            string strEqpTypeID = "";
            string strOperGroupID = "";
            string strOperID = "";
            string strTrayID = "";
            string strAgingType = "";

            string strSearchPlanTimeStart = "";
            string strSearchPlanTimeEnd = "";

            //20200622 KJY lsVar 제일뒤에 하나 추가. "1"이면 RouteID변경 예약된 Rack - Tray
            bool bReserveChangeRouteID = false;
            //string strREqpTypeID = string.Empty;
            //string strROperGroupID = string.Empty;
            //string strROperID = string.Empty;

            //if (lstVar.Count == 2)
            if (lstVar.Count == 3)
                {
                //필수
                strLineID = lstVar[0];
                strTrayID = lstVar[1];

                if (lstVar[2] == "1") bReserveChangeRouteID = true;
            }
            //else if (lstVar.Count == 8)
            else if (lstVar.Count == 9)
            {
                //필수
                strLineID = lstVar[0];
                //조건
                strModel = lstVar[1];
                strRouteID = lstVar[2];
                strLotID = lstVar[3];
                strEqpTypeID = lstVar[4];
                strOperGroupID = lstVar[5];
                strOperID = lstVar[6];
                strAgingType = lstVar[7];

                if (lstVar[8] == "1") bReserveChangeRouteID = true;
            }
            //else if (lstVar.Count == 10)
            else if (lstVar.Count == 11)
            {
                //필수
                strLineID = lstVar[0];
                //조건
                strModel = lstVar[1];
                strRouteID = lstVar[2];
                strLotID = lstVar[3];
                strEqpTypeID = lstVar[4];
                strOperGroupID = lstVar[5];
                strOperID = lstVar[6];
                strAgingType = lstVar[7];

                // 19/08/28 날짜 검색
                strSearchPlanTimeStart = lstVar[8];
                strSearchPlanTimeEnd = lstVar[9];

                if (lstVar[10] == "1") bReserveChangeRouteID = true;

            }
            else
            { return ""; }

            // Set Query
            //strSQL.Append("SELECT A.RackID,		    A.TrayCnt,		A.EndTime,	    A.Status");
            strSQL.Append("SELECT A.RackID,		    A.TrayCnt,		A.StartTime,  A.EndTime,	    A.Status"); //20190923 KJY StartTime추가
            strSQL.Append("     , B.ProdModel,	    B.RouteID,		B.LotID,		B.TrayId");
            strSQL.Append("     , B.TrayInputDate,	B.TrayInputTime");
            strSQL.Append("     , C.OperName NowOperName");
            strSQL.Append("     , D.OperName NextOperName");
            strSQL.Append("     , E.OperName DefNowOperName");
            strSQL.Append("     , F.OperName DefNextOperName");
            strSQL.Append("     , B.CurrCellCnt");


            //20200619 KJY - RouteID변경예약
            strSQL.Append("     , A.ReserveRouteIDChageFlag, A.ReservedRouteID, A.ReservedProcID");
            strSQL.Append("     , G.OperName DefReservedOperName");



            strSQL.Append("  FROM tMstAgingRack A WITH (NOLOCK)");
            strSQL.Append("       LEFT OUTER JOIN tTrayCurr B WITH (NOLOCK)");
            strSQL.Append("         ON B.LineID         = A.LineID");
            strSQL.Append("        AND B.TrayID         = A.TrayID");

            //if (strTrayID.Length > 0)
            //{
                //strSQL.Append($"        AND B.TrayID		 = '{strTrayID}'");
            //}

            strSQL.Append("       LEFT OUTER JOIN tMstRouteOper C WITH(NOLOCK)");
            strSQL.Append("         ON C.ProdModel	    = B.ProdModel");
            strSQL.Append("        AND C.RouteID		= B.RouteID");
            //strSQL.Append("        AND C.EqpTypeID + C.OperGroupID + C.OperID = B.EqpTypeID + B.OperGroupID + B.OperID");
            strSQL.Append("        AND C.EqpTypeID = B.EqpTypeID AND C.OperGroupID = B.OperGroupID AND C.OperID = B.OperID");
            strSQL.Append("       LEFT OUTER JOIN tMstRouteOper D WITH(NOLOCK)");
            strSQL.Append("         ON D.ProdModel	    = B.ProdModel");
            strSQL.Append("        AND D.RouteID		= B.RouteID");
            //strSQL.Append("        AND D.EqpTypeID + D.OperGroupID + D.OperID = B.NextEqpTypeID + B.NextOperGroupID + B.NextOperID");
            strSQL.Append("        AND D.EqpTypeID = B.NextEqpTypeID AND D.OperGroupID = B.NextOperGroupID AND D.OperID = B.NextOperID AND D.EqpTypeID <> '0' ");
            strSQL.Append("       LEFT OUTER JOIN tMstRouteOper E WITH(NOLOCK)");
            strSQL.Append("         ON E.ProdModel	    = B.ProdModel");
            strSQL.Append("        AND E.RouteID		= B.RouteID");
            //strSQL.Append("        AND E.EqpTypeID + E.OperGroupID + E.OperID = B.EqpTypeID + B.OperGroupID + B.OperID");
            strSQL.Append("        AND E.EqpTypeID = B.EqpTypeID AND E.OperGroupID = B.OperGroupID  AND E.OperID = B.OperID");
            strSQL.Append("       LEFT OUTER JOIN tMstRouteOper F WITH(NOLOCK)");
            strSQL.Append("         ON F.ProdModel	    = B.ProdModel");
            strSQL.Append("        AND F.RouteID		= B.RouteID");
            //strSQL.Append("        AND F.EqpTypeID + F.OperGroupID + F.OperID = B.NextEqpTypeID + B.NextOperGroupID + B.NextOperID");
            strSQL.Append("        AND F.EqpTypeID = B.NextEqpTypeID AND F.OperGroupID = B.NextOperGroupID AND F.OperID = B.NextOperID AND F.EqpTypeID <> '0' ");

            // 20200622 KJY - 예약 공정명 가져오기 위해서
            strSQL.Append("       LEFT OUTER JOIN tMstRouteOper G WITH(NOLOCK)");
            strSQL.Append("         ON G.ProdModel	    = B.ProdModel");
            strSQL.Append("        AND G.RouteID		= A.ReservedRouteID");
            strSQL.Append("        AND G.EqpTypeID + G.OperGroupID + G.OperID = A.ReservedProcID");


            strSQL.Append($" WHERE A.LineID             = '{strLineID}'");
           
            if (strTrayID.Length > 0)
            {
                if(strTrayID.Length >= CDefine.DEF_MAX_TRAYID_LENGTH)
                    strSQL.Append($"        AND A.TrayID = '{strTrayID}'");
                else
                    strSQL.Append($"        AND A.TrayID Like  '%{strTrayID}%'");

                if(bReserveChangeRouteID == true) strSQL.Append($"        AND A.ReserveRouteIDChageFlag = '1'");
            }
            else
            {
                strSQL.Append("    AND A.EndTime IS NOT NULL");

                //PlanTime 검색 추가 PYG
                if (!string.IsNullOrEmpty(strSearchPlanTimeStart) && !string.IsNullOrEmpty(strSearchPlanTimeEnd))
                {
                    strSQL.Append($"    AND A.EndTime BETWEEN '{strSearchPlanTimeStart}' AND '{strSearchPlanTimeEnd}' ");
                }

                if (strAgingType.Length > 0)
                {
                    strSQL.Append($"   AND A.AgingType			= '{strAgingType}'");
                }

                if (strModel.Length > 0) strSQL.Append($"   AND B.ProdModel			= '{strModel}'");
                if (strRouteID.Length > 0) strSQL.Append($"   AND B.RouteID			    = '{strRouteID}'");
                //if (strLotID.Length > 0) strSQL.Append($"   AND B.LotID				LIKE '{"%" + strLotID + "%"}'");
                if (strLotID.Length > 0) strSQL.Append($"   AND B.LotID				= '{strLotID}'");

                if (strEqpTypeID.Length > 0 && strOperGroupID.Length > 0 && strOperID.Length > 0)
                {
                    strSQL.Append($"   AND B.EqpTypeID			= '{strEqpTypeID}'");
                    strSQL.Append($"   AND B.OperGroupID		= '{strOperGroupID}'");
                    strSQL.Append($"   AND B.OperID			    = '{strOperID}'");
                }

                if (bReserveChangeRouteID == true) strSQL.Append($"        AND A.ReserveRouteIDChageFlag = '1'");
            }
            strSQL.Append(" ORDER BY A.EndTime ASC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToRouteOper]
        //# Model / Route를 사용, 공정명(중문) 을 얻기 위한 Query
        //Table
        //tMstRouteOper     A
        //tMstOperation     B
        //Form
        //CtrlCellHistoryInfo
        //CtrlTrayCellHistoryInfo
        //WinCellMeasurements
        private string QueryToRouteOper(List<string> lstVar)
        {
            if (lstVar.Count != 2) return "";

            StringBuilder strSQL = new StringBuilder();
            string strModel = null;
            string strRouteID = null;

            strModel = lstVar[0];
            strRouteID = lstVar[1];

            strSQL.Append("SELECT A.ProdModel,			         A.RouteID");
            strSQL.Append("     , A.EqpTypeID,          A.OperGroupID,   A.OperID");
            strSQL.Append("     , C.OperName,			C.OperName_cn");
            strSQL.Append("   FROM tMstRouteOper A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstOperation C WITH (NOLOCK)");
            strSQL.Append("          ON C.EqpTypeID		= A.EqpTypeID");
            strSQL.Append("         AND C.OperGroupID	= A.OperGroupID");
            strSQL.Append("         AND C.OperID		= A.OperID");
            strSQL.Append("  WHERE A.EqpTypeID      <> '0'");
            strSQL.Append("    AND A.OperGroupID    <> '0'");
            strSQL.Append("    AND A.OperID         <> '0'");
            //필수
            strSQL.Append($"    AND A.ProdModel		= '{strModel}'");
            strSQL.Append($"    AND A.RouteID		= '{strRouteID}'");
            strSQL.Append("  ORDER BY A.RowNumber ASC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToGripper]
        //Table
        //tMstEquipmentCh     A
        //tMstEqpGroup        B
        //tMstEquipment       C
        //Form
        //CtrlGripper
        private string QueryToGripper(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            if (lstVar.Count != 3) return "";

            string strLineID = null;
            string strEqpTypeID = null;
            string strUnitID = null;

            strLineID = lstVar[0];
            strEqpTypeID = lstVar[1];
            strUnitID = lstVar[2];

            strSQL.Append(" SELECT A.LineID,		A.EqpTypeID,        A.UnitID");
            strSQL.Append("      , A.CH,            A.SpecCnt,          A.CurrCnt");
            strSQL.Append("   	 , B.EqpTypeName,   C.UnitName");
            strSQL.Append("   FROM tMstEquipmentCh A WITH(NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstEqpGroup B WITH (NOLOCK)");
            strSQL.Append("          ON B.EqpTypeID = A.EqpTypeID");
            strSQL.Append("        LEFT OUTER JOIN tMstEquipment C WITH (NOLOCK)");
            strSQL.Append("          ON C.LineID    = A.LineID");
            strSQL.Append("         AND C.EqpTypeID = A.EqpTypeID");
            strSQL.Append("         AND C.UnitID    = A.UnitID");
            //필수
            strSQL.Append($" WHERE A.LineID	    = '{strLineID}'");
            //조건
            if (strEqpTypeID.Length > 0) strSQL.Append($"   AND A.EqpTypeID	    = '{strEqpTypeID}'");
            if (strUnitID.Length > 0) strSQL.Append($"   AND A.UnitID	    = '{strUnitID}'");

            strSQL.Append("ORDER BY A.EqpTypeID ASC, A.UnitID ASC, A.CH");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToEqpRepair]
        //Table
        //tTroublePin         A
        //tMstEqpGroup        B
        //tMstEquipment       C
        //Form
        //CtrlEqpRepair
        private string QueryToEqpRepair(List<string>lstVar)
        {
            if (lstVar.Count != 5) return "";

            StringBuilder strSQL = new StringBuilder();
            string strLineID = null;
            string strEqpTypeID = null;
            string strUnitID = null;
            string strStartTime = null;
            string strEndTime = null;

            strLineID = lstVar[0];
            strEqpTypeID = lstVar[1];
            strUnitID = lstVar[2];
            strStartTime = lstVar[3];
            strEndTime = lstVar[4];

            strSQL.Append(" SELECT A.LineID,		A.EqpTypeID,               A.UnitID,              A.EventTime");
            strSQL.Append("      , A.CH,            A.EqpTroubleFlag,          A.UserEventTime");
            strSQL.Append("      , A.UserID,        A.UserAction,              A.UpdateUser,          A.UpdateTime");
            strSQL.Append("   	 , B.EqpTypeName,   C.UnitName");
            strSQL.Append("   FROM tTroublePin A WITH(NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstEqpGroup B WITH (NOLOCK)");
            strSQL.Append("          ON B.EqpTypeID = A.EqpTypeID");
            strSQL.Append("        LEFT OUTER JOIN tMstEquipment C WITH (NOLOCK)");
            strSQL.Append("          ON C.LineID = A.LineID");
            strSQL.Append("         AND C.EqpTypeID = A.EqpTypeID");
            strSQL.Append("         AND C.UnitID = A.UnitID");
            //필수
            strSQL.Append($" WHERE A.LineID	         = '{strLineID}'");
            strSQL.Append($"   AND A.EventTime BETWEEN '{strStartTime}'");
            strSQL.Append($"                       AND '{strEndTime}'");
            //조건
            if (strEqpTypeID.Length > 0) strSQL.Append($"   AND A.EqpTypeID	    = '{strEqpTypeID}'");
            if (strUnitID.Length > 0) strSQL.Append($"   AND A.UnitID	    = '{strUnitID}'");

            strSQL.Append("ORDER BY EventTime DESC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToUnitState]
        //#시간 계산 이 필요함.
        //Table
        //tEqpStatus         A
        //Form
        //CtrlEqpStatusReport
        private string QueryToUnitState(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strLineID = "";
            string strTroubleFlag = "";

            strLineID = lstVar[0];
            strTroubleFlag = lstVar[1];

            strSQL.Append(" SELECT A.EqpTypeID, A.UnitStatus, A.FireStatus, A.UnitID, A.UnitName, A.TroubleCode");
            strSQL.Append("   FROM tMstEquipment  A WITH (NOLOCK)");
            strSQL.Append($"  WHERE A.LineID = '{lstVar[0]}' ");

            //OR CHECK
            strSQL.Append($"    AND (A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION}' ");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_FORMATION_STACKER}' ");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_AGING}'");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_SELECTOR}'");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_IROCV}'");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_GRADER}'");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_DCIR}'");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_HPC}'");
            strSQL.Append($"    OR A.EqpTypeID = '{CDefine.DEF_EQP_TYPE_ID_DEGAS}') ");

            if (strTroubleFlag == "Y")
            {//OR CHECK
                strSQL.Append($"    AND (A.UnitStatus = '{CDefine.DEF_STATUS_TROUBLE}' ");
                strSQL.Append($"     OR A.FireStatus = '{CDefine.DEF_STATUS_FIRE}') ");
            }

            strSQL.Append(" UNION ALL");
            strSQL.Append(" SELECT B.EqpTypeID, B.UnitStatus, NULL FireStatus, B.UnitID, B.UnitName, B.TroubleCode ");
            strSQL.Append("   FROM tMstEquipmentBcr B WITH (NOLOCK)");
            strSQL.Append($"  WHERE B.LineID = '{lstVar[0]}' ");

            if (strTroubleFlag == "Y")
            {
                strSQL.Append($"    AND B.UnitStatus = '{CDefine.DEF_STATUS_TROUBLE}' ");
            }

            strSQL.Append(" UNION ALL");
            strSQL.Append(" SELECT '3' EqpTypeID, C.Status UnitStatus, C.FireStatus, C.RackID UnitID");
            strSQL.Append("      , SUBSTRING(C.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(C.RackID, 2, 2))) + '-' + SUBSTRING(C.RackID, 4, 1) + 'Line-' + SUBSTRING(C.RackID, 5, 2) + 'Bay-' + SUBSTRING(C.RackID, 7, 2) + 'Rack' AS UnitName");
            strSQL.Append("      , '' TroubleCode");
            strSQL.Append("   FROM tMstAgingRack C WITH (NOLOCK)");
            strSQL.Append($"  WHERE C.LineID = '{lstVar[0]}' ");
            strSQL.Append($"    AND SUBSTRING(C.RackID, 4, 1) != '{CDefine.DEF_STATUS_WATER}'");

            if (strTroubleFlag == "Y")
            {
                //OR
                strSQL.Append($"    AND ( C.FireStatus = '{CDefine.DEF_STATUS_FIRE}'");
                strSQL.Append($"     OR  C.FireStatus = '{CDefine.DEF_STATUS_WATER}' ) ");
            }

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToEqpStatusReport]
        //#시간 계산 이 필요함.
        //Table
        //tEqpStatus         A
        //Form
        //CtrlEqpStatusReport
        private string QueryToEqpStatusReport(string strLineID, string strStartDate, string strEndDate, string strEqpType, string strUnitID)
        {
            StringBuilder strSQL = new StringBuilder();

            //20190101
            string strStartPartKey = strStartDate.Substring(0,8);
            string strEndPartKey = strEndDate.Substring(0, 8);

            strSQL.Append(" SELECT EqpTypeID, UnitID, StatusFlag, SUM(DATEDIFF(ss, A.EventTime, A.EventEndTime))Status_Cnt");
            strSQL.Append("   FROM (");
            strSQL.Append("         SELECT EqpTypeID, UnitID, StatusFlag");
            strSQL.Append("              , (CASE ISNULL(EventTime, '') WHEN '' THEN EventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(EventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventTime");
            strSQL.Append("              , (CASE ISNULL(EventEndTime, '') WHEN '' THEN EventEndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(EventEndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventEndTime");
            strSQL.Append("           FROM tEqpStatus WITH(NOLOCK)");
            strSQL.Append($"         WHERE PartKey   BETWEEN '{strStartPartKey}'");
            strSQL.Append($"                             AND '{strEndPartKey}'");
            strSQL.Append($"           AND LineID          = '{strLineID}'");
            strSQL.Append($"           AND EventTime BETWEEN '{strStartDate}'");
            strSQL.Append($"                             AND '{strEndDate}'");

            if (strEqpType.Length > 0) strSQL.Append($"   AND EqpTypeID           = '{strEqpType}'");
            if (strUnitID.Length > 0) strSQL.Append($"   AND UnitID              = '{strUnitID}'");
            strSQL.Append("         )A");

            strSQL.Append(" GROUP BY EqpTypeID, UnitID, StatusFlag");
            strSQL.Append(" ORDER BY EqpTypeID ASC, UnitID ASC, StatusFlag ASC");
            return strSQL.ToString();
        }
        #endregion

        #region [Eqp Repair, Outer Join]
        private string QueryToHistTray(List<string>lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            if (lstVar.Count != 9) return "";

            string strLineID = null;
            string strStartPartKey = null;
            string strEndPartKey = null;
            string strInputTrayStartDate = null;
            string strInputTrayEndDate = null;
            string strInputTrayStartTime = null;
            string strInputTrayEndTime = null;
            string strModelID = null;
            string strRouteID = null;
            string strLotID = null;
            string strFlag = null;

            strLineID = lstVar[0];
            strStartPartKey = lstVar[1];
            strEndPartKey = lstVar[2];
            strInputTrayStartDate = lstVar[1];
            strInputTrayEndDate = lstVar[2];
            strInputTrayStartTime = lstVar[3];
            strInputTrayEndTime = lstVar[4];
            strModelID = lstVar[5];
            strRouteID = lstVar[6];
            strLotID = lstVar[7];
            strFlag = lstVar[8];

            strSQL.Append(" SELECT A.TrayID, A.TrayInputDate, A.TrayInputTime");
            strSQL.Append("   FROM tHistTrayProStep A WITH(NOLOCK)");
            strSQL.Append($"  WHERE A.PartKey             BETWEEN '{strStartPartKey}' AND '{strEndPartKey}'");
            strSQL.Append($"    AND A.LineID                   = '{strLineID}'");
            strSQL.Append($"    AND A.TrayInputDate       BETWEEN '{strInputTrayStartDate}' AND {strInputTrayEndDate}");
            strSQL.Append($"    AND A.TrayInputTime       BETWEEN '{strInputTrayStartTime}' AND '{strInputTrayEndTime}'");

            if(strModelID.Length > 0) strSQL.Append($"    AND ProdModel                     = '{strModelID}'");
            if(strRouteID.Length > 0) strSQL.Append($"    AND RouteID                     = '{strRouteID}'");
            if (strLotID.Length > 0) strSQL.Append($"    AND LotID                     = '{strLotID}'");

            strSQL.Append($"    AND A.Flag                     = '{strFlag}'");
            strSQL.Append($"    AND A.ProcWorkIndex            = '0'");
            strSQL.Append("    AND A.StartTime                = (");
            strSQL.Append("                                    SELECT MAX(StartTime)");
            strSQL.Append("                                      FROM tHistTrayProStep WITH(NOLOCK)");
            strSQL.Append("                                     WHERE PartKey       = A.PartKey");
            strSQL.Append("                                       AND TrayID        = A.TrayID");
            strSQL.Append("                                       AND TrayInputDate = A.TrayInputDate");
            strSQL.Append("                                       AND TrayInputTime = A.TrayInputTime");
            strSQL.Append("                                    )");

            strSQL.Append(" ORDER BY A.TrayID ASC, A.TrayInputDate ASC, A.TrayInputTime ASC");
            return strSQL.ToString();
        }
        #endregion

        #region [QueryToCellProcStepData]
        private string QueryToCellProcStepData(List<string> lstVar, string CellID = null, bool bNGCellFlag=false)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartTime = null;
            string strEndTime = null;
            string strModelID = null;
            string strRouteID = null;
            string strLotID = null;
            string strCellID = null;
            string strTrayID = null;
            string strTrayInputData = null;
            string strTrayInputTime = null;

            //20190515 KJY 생산차수추가
            string strProductOrder = string.Empty;

            //20190603
            string strCellList = null;

            //조회 조건
            //1. 시간, 모델, 라우터, LOT
            //2. CellID
            //3. TrayID, TrayInputDate

            //공통
            strLineID = lstVar[1];

            switch (lstVar[0])
            {
                case "0": //기본조건

                    //if (lstVar.Count != 7) return "";

                    strStartTime = lstVar[2];
                    strEndTime = lstVar[3];
                    strModelID = lstVar[4];
                    strRouteID = lstVar[5];
                    strLotID = lstVar[6];
                    if (lstVar.Count > 7)
                        strProductOrder = lstVar[7];
                    
                    if (lstVar.Count > 8)
                        strCellList = lstVar[8];

                    break;
                case "1"://CellID 조회
                    //if (lstVar.Count != 5) return "";
                    strStartTime = lstVar[2];
                    strEndTime = lstVar[3];
                    strCellID = lstVar[4];
                    if (lstVar.Count > 5)
                        strProductOrder = lstVar[5];
                    break;
                case "2"://Tray별 Cell 조회
                    if (lstVar.Count != 6) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strTrayID = lstVar[4];
                    //PartKey Hist..변경시 사용..
                    strStartTime = lstVar[5];
                    strEndTime = lstVar[5];
                    break;
            }

            if (CellID != null)
                strCellID = CellID;



            strSQL.Append("SELECT A.CellID,                   A.LineID,                   A.EqpTypeID");
            strSQL.Append("     , A.OperGroupID,              A.OperID,                   A.ProcWorkIndex");
            strSQL.Append("     , A.ProcWorkCnt,              A.ProdModel,                A.LotID");
            strSQL.Append("     , A.RouteID,                  A.CellType");
            // 20190430 KJY - InputDate, InputTime을 tCellCurr의 TrayInputDate, TrayInputTime 으로.... 아 잘 모르겠다.
            //strSQL.Append("     , A.InputDate,                A.InputTime");
            strSQL.Append("     , F.TrayInputDate InputDate,            F.TrayInputTime InputTime");

            strSQL.Append("     , A.InputObjectID,            A.InputLineID");
            strSQL.Append("     , A.InputFlag,                A.ManualInputFlag,          A.FormInputLineID");
            strSQL.Append("     , A.FormInputDate,            A.FormInputTime,            A.FormInputFlag");
            strSQL.Append("     , A.StartDate,                A.EndDate");
            strSQL.Append("     , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime");
            strSQL.Append("     , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime");
            strSQL.Append("     , A.ReworkFlag,               A.ReworkProc,               A.ReworkCnt");
            // 현재 CellNo는 tCellCurr에서 가져와야 정확하다.
            // NG Cell일 경우 tCellProStep에서 가져와야 한다.
            //if(bNGCellFlag == true)
            //    strSQL.Append("     , A.TrayID,                   A.CellNo");
            //else
                strSQL.Append("     , F.TrayID,                   F.CellNo");
            //

            //20190425 KJY - 작업당시의 CellNo와 ObjectID를 받아온다.
            strSQL.Append("     , A.CellNo Channel,                   A.ObjectID");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputDate, '') WHEN '' THEN A.TrayInputDate ELSE CONVERT(VARCHAR(10), CONVERT(DATE, A.TrayInputDate), 120) END) AS TrayInputDate");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputTime, '') WHEN '' THEN A.TrayInputTime ELSE CONVERT(VARCHAR(8), CONVERT(TIME, stuff(stuff(A.TrayInputTime, 3, 0, ':'), 6, 0, ':')), 108) END) AS TrayInputTime");
            //strSQL.Append("     , A.Grade");
            //20190420 KJY - Grade는 tCellCurr에서 가져와라... 
            strSQL.Append("     , F.Grade");
            //20190515 KJY GradeProc, GradeObjectID 추가
            strSQL.Append("     , F.GradeProc, F.GradeObjectID, F.GradeCode");

            strSQL.Append("     , B.Capacity,                   B.AvgVoltage");
            //20190425 - tCellProStep에서 Temp를 가져온다.
            //strSQL.Append("     , B.Temp,                       B.TempValue,           B.CapacityTemp");
            strSQL.Append("     , A.BoxTempEnd Temp");    
            strSQL.Append("     , C.Ocv,                        C.DeltaOCV,             C.DeltaK");
            strSQL.Append("     , D.DeltaIR");
            strSQL.Append("     , E.StartVoltage");
            //겹치는 항목, Data 는 겹칠 수 없다.
            strSQL.Append("     , ISNULL(ISNULL(E.Step, B.Step), '1')Step");
            strSQL.Append("     , ISNULL(D.IR, E.IR)IR");
            strSQL.Append("     , ISNULL(B.EndVoltage, E.EndVoltage)EndVoltage");
            strSQL.Append("     , ISNULL(B.EndCurrent, E.EndCurrent)EndCurrent");

            //Degas Data
            strSQL.Append("     , G.DegasChamberNo, G.DegasChamberPos, G.DegasFinalVacuum, G.FinalWeight, G.RollingPos, G.Rolling1_Pressure, G.Rolling2_Pressure, G.FinalSealingPressure, G.FinalSealingTempUpper, G.FinalSealingTempLower, G.FinalSealingPos, G.Dimension1, G.Dimension2, G.Dimension3, G.Dimension4, G.Dimension5, G.Dimension6, G.Dimension7, G.Dimension8, G.Dimension9, G.Dimension10, G.Dimension11, G.Dimension12, G.Dimension13, G.Dimension14, G.Dimension15, G.HipotVolt, G.HipotTime, G.HipotResistant, G.HipotPos, G.CellThicknessPressure, G.CellThicknessPos, G.CellThicknessDataCH1, G.CellThicknessDataCH2, G.CellThicknessDataCH3, G.CellThicknessDataCH4, G.CellThicknessDataCH5, G.FilledWeight, G.PostFillWeight, G.LossWeight, G.RetentionWeight, G.CalcConstant, G.CellThicknessDataAVG");

            //20190509 KJY - Assembly Data
            // AForeFillWeight : 주액전 중량 AFilledWeight: 주액량 APostFillWeight : 주액후 중량
            strSQL.Append("     , H.ForeFillWeight AForeFillWeight, H.FilledWeight AFilledWeight, H.PostFillWeight APostFillWeight");  

            strSQL.Append("  FROM tCellProStep A WITH(NOLOCK)");
            strSQL.Append("    LEFT OUTER JOIN tCellProChg B WITH(NOLOCK)");
            strSQL.Append("      ON B.LineID            = A.LineID");
            strSQL.Append("     AND B.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND B.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND B.OperID            = A.OperID");
            strSQL.Append("     AND B.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND B.TrayID            = A.TrayID");
            //strSQL.Append("     AND B.CellNo            = A.CellNo");
            strSQL.Append("     AND B.CellID            = A.CellID");
            //strSQL.Append("     AND B.TrayInputDate     = A.TrayInputDate");
            //strSQL.Append("     AND B.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tCellProOcv C WITH(NOLOCK)");
            strSQL.Append("      ON C.LineID            = A.LineID");
            strSQL.Append("     AND C.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND C.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND C.OperID            = A.OperID");
            strSQL.Append("     AND C.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND C.TrayID            = A.TrayID");
            //strSQL.Append("     AND C.CellNo            = A.CellNo");
            strSQL.Append("     AND C.CellID            = A.CellID");
            //strSQL.Append("     AND C.TrayInputDate     = A.TrayInputDate");
            //strSQL.Append("     AND C.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tCellProIR D WITH(NOLOCK)");
            strSQL.Append("      ON D.LineID            = A.LineID");
            strSQL.Append("     AND D.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND D.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND D.OperID            = A.OperID");
            strSQL.Append("     AND D.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND D.TrayID            = A.TrayID");
            //strSQL.Append("     AND D.CellNo            = A.CellNo");
            strSQL.Append("     AND D.CellID            = A.CellID");
            //strSQL.Append("     AND D.TrayInputDate     = A.TrayInputDate");
            //strSQL.Append("     AND D.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tCellProDCIR E WITH(NOLOCK)");
            strSQL.Append("      ON E.LineID            = A.LineID");
            strSQL.Append("     AND E.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND E.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND E.OperID            = A.OperID");
            strSQL.Append("     AND E.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND E.TrayID            = A.TrayID");
            //strSQL.Append("     AND E.CellNo            = A.CellNo");
            strSQL.Append("     AND E.CellID            = A.CellID");
            //strSQL.Append("     AND E.TrayInputDate     = A.TrayInputDate");
            //strSQL.Append("     AND E.TrayInputTime     = A.TrayInputTime");


            //20190417 KJY - Degas 데이터도 필요하다.
            strSQL.Append("    LEFT OUTER JOIN tCellProDegas G WITH(NOLOCK)");
            strSQL.Append("      ON G.LineID            = A.LineID");
            strSQL.Append("     AND G.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND G.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND G.OperID            = A.OperID");
            strSQL.Append("     AND G.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND G.TrayID            = A.TrayID");
            //strSQL.Append("     AND G.CellNo            = A.CellNo");
            strSQL.Append("     AND G.CellID            = A.CellID");


            //20190509 KJY - Assembly Data
            strSQL.Append("    LEFT OUTER JOIN tCellProAssembly H WITH(NOLOCK)");
            strSQL.Append("      ON H.LineID            = A.LineID");
            strSQL.Append("     AND H.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND H.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND H.OperID            = A.OperID");
            strSQL.Append("     AND H.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND H.TrayID            = A.TrayID");
            //strSQL.Append("     AND H.CellNo            = A.CellNo");
            strSQL.Append("     AND H.CellID            = A.CellID");


            //LEFT OUTER JOIN tCellCurr F WITH(NOLOCK)
            //ON A.CellID = F.CellID
            strSQL.Append("    LEFT OUTER JOIN tCellCurr F WITH(NOLOCK)");
            strSQL.Append("      ON A.CellID = F.CellID");

            strSQL.Append($"  WHERE A.LineID              = '{strLineID}'");
            //strSQL.Append($"    AND A.EqpTypeID          IN ('{CDefine.DEF_EQP_TYPE_ID_FORMATION}', '{CDefine.DEF_EQP_TYPE_ID_IROCV}', '{CDefine.DEF_EQP_TYPE_ID_DCIR}')");
            strSQL.Append($"    AND A.ProcWorkIndex       = '0'");

            



            switch (lstVar[0])
            {
                case "0": //기본조건
                    if (CellID != null)
                    {
                        strSQL.Append($"    AND A.CellID                     = '{CellID}'");
                    }
                    else
                    {
                        if (strCellList != null)
                        {
                            strSQL.Append($" AND A.CellID IN ({strCellList})");

                        }
                        else
                        {

                            //strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND '{strEndTime}'");
                            // 20190420 KJY - InputDate InputTime으로 가는게 맞을것 같다. 
                            strSQL.Append($"    AND (A.InputDate+A.InputTime > '{strStartTime}' AND A.InputDate+A.InputTime < '{strEndTime}') ");

                            if (strModelID.Length > 0) strSQL.Append($"    AND A.ProdModel                     = '{strModelID}'");
                            if (strRouteID.Length > 0) strSQL.Append($"    AND A.RouteID                     = '{strRouteID}'");
                            if (strLotID.Length > 0) strSQL.Append($"    AND A.LotID                     = '{strLotID}'");

                            //20190420 KJY - NGCell검색을 위해
                            if (bNGCellFlag) strSQL.Append($"    AND F.Grade in ('1','2','3','4','N','M','T','K')");
                            else strSQL.Append($"    AND (F.Grade not in ('1','2','3','4','N','M','T','K') or F.Grade is null )");
                            //20190515 KJY - 생산차수 추가
                            if (strProductOrder.Length > 0) strSQL.Append($"    AND SUBSTRING(F.CellID, 8, 4) = '{strProductOrder}'");
                        }

                    } 
                    
                    break;
                case "1": //CellID 조회
                    //strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND {strEndTime}");
                    // 20190420 KJY - InputDate InputTime으로 가는게 맞을것 같다. 
                    //strSQL.Append($"    AND (A.InputDate+A.InputTime > '{strStartTime}' AND A.InputDate+A.InputTime < '{strEndTime}') ");

                    strSQL.Append($"    AND A.CellID                     = '{strCellID}'");
                    //if (bNGCellFlag) strSQL.Append($"    AND F.Grade in ('1','2','3','4','N','M','T','K')");
                    //20190515 KJY - 생산차수 추가
                    //if (strProductOrder.Length > 0) strSQL.Append($"    AND SUBSTRING(F.CellID, 8, 4) = '{strProductOrder}'");
                    break;
                case "2": //Tray별 Cell 조회
                    //strSQL.Append($"    AND A.TrayID                = '{strTrayID}'");
                    //strSQL.Append($"    AND A.TrayInputDate         = '{strTrayInputData}'");
                    //strSQL.Append($"    AND A.TrayInputTime         = '{strTrayInputTime}'");
                    // 20190409 KJY - Tray에 담겨있는 CellID를 기준으로 가져와야 한다.
                    //strSQL.Append($" AND A.CellID IN (SELECT CellID FROM tCellCurr WHERE TrayID = '{strTrayID}')");
                    strSQL.Append($" AND A.CellID IN (SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '{strTrayID}')");
                    if (bNGCellFlag) strSQL.Append($"    AND F.Grade in ('1','2','3','4','N','M','T','K')");

                    break;
            }

            //strSQL.Append(" ORDER BY A.TrayInputDate ASC, A.TrayInputTime ASC, A.TrayID ASC, A.CellNo ASC, A.StartTime");
            //strSQL.Append(" ORDER BY A.TrayID ASC, A.CellNo ASC, A.StartTime");
            strSQL.Append(" ORDER BY F.TrayID ASC, F.CellNo ASC, A.StartTime");
            //strSQL.Append(" ORDER BY F.TrayID ASC, F.CellNo ASC, A.StartTime DESC");
            return strSQL.ToString();
        }
        private string QueryToCellProcStepDataFromView(List<string> lstVar, string CellID = null, bool bNGCellFlag = false, string SelectedProc="")
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = string.Empty;
            string strStartTime = string.Empty;
            string strEndTime = string.Empty;
            string strModelID = string.Empty;
            string strRouteID = string.Empty;
            string strLotID = string.Empty;
            string strCellID = string.Empty;
            string strTrayID = string.Empty;
            string strTrayInputData = string.Empty;
            string strTrayInputTime = string.Empty;
            string strProcWorkIndex = "0";

            //20190515 KJY 생산차수추가
            string strProductOrder = string.Empty;

            //20190603
            string strCellList = null;

            //조회 조건
            //1. 시간, 모델, 라우터, LOT
            //2. CellID
            //3. TrayID, TrayInputDate

            //공통
            strLineID = lstVar[1];

            switch (lstVar[0])
            {
                case "0": //기본조건

                    //if (lstVar.Count != 7) return "";

                    strStartTime = lstVar[2];
                    strEndTime = lstVar[3];
                    strModelID = lstVar[4];
                    strRouteID = lstVar[5];
                    strLotID = lstVar[6];
                    if (lstVar.Count > 7)
                        strProductOrder = lstVar[7];

                    if (lstVar.Count > 8)
                        strCellList = lstVar[8];

                    break;
                case "1"://CellID 조회
                    //if (lstVar.Count != 5) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strCellID = lstVar[4];
                    if (lstVar.Count > 5)
                        strProductOrder = lstVar[5];
                    if (lstVar.Count > 6)
                        if(lstVar[6].Length ==1)
                            strProcWorkIndex = lstVar[6]; //ProcWorkIndex

                    break;
                case "2"://Tray별 Cell 조회
                    //if (lstVar.Count != 6) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strTrayID = lstVar[4];
                    //PartKey Hist..변경시 사용..
                    strStartTime = lstVar[5];
                    //strEndTime = lstVar[6];

                    //20190926 KJY - 3종세트 추가
                    strModelID = lstVar[6];
                    strRouteID = lstVar[7];
                    strLotID = lstVar[8];
                    break;
            }
            /* 셀 검색
            * [0]  0:기본조건   1:CellID로 조회   2: Tray별Cell조회
            *  0: 기본조건일때
            *      [1] : LineID, [2] : StartTime, [3] : EndTime, [4] : ModelID, [5] RouteID, [6] : LotID, [7?] : ProductOrder (미사용) [8] : Cell List
            *  1: Cell ID로 조회
            *      [1] : LineID, [2] : TrayInputDate, [3] : TrayInputTime, [4] : Cell ID, [5] : for PartKey? , [6] : ProcWorkIndex
            *  2: Tray별 Cell 조회
            *      [1] : LineID, [2] : TrayInputDate, [3] : TrayInputTime, [4] : TrayID, [5???] : StartTime
            *      ==> 여기서도 ModelID, RouteID, LotID 포함시켜야 한다.  [6]: ModelID, [7]:RouteID, [8]: LotID
            */

            string strColumns = "CellID, LineID, EqpTypeID , OperGroupID, OperID, ProcWorkIndex , ProcWorkCnt, ProdModel, LotID , RouteID, CellType , InputDate, InputTime, InputObjectID, InputLineID , "
                +" InputFlag, ManualInputFlag, FormInputLineID , FormInputDate, FormInputTime, FormInputFlag , StartDate, EndDate, StartTime, EndTime, ReworkFlag, ReworkProc, ReworkCnt , TrayID, CellNo , "
                +" Channel, ObjectID, TrayInputDate, TrayInputTime, Grade , GradeProc, GradeObjectID, GradeCode ,  "
                +" Format(Capacity, '0.00') Capacity, Format(AvgVoltage, '0.00') AvgVoltage, Temp , Format(Ocv, '0.00') Ocv, DeltaOCV, DeltaK , DeltaIR , "
                +" Format(StartVoltage, '0.00') StartVoltage, Step, Format(IR, '0.000') IR, Format(EndVoltage, '0.00') EndVoltage, Format(EndCurrent, '0.00') EndCurrent, "
                + " DegasChamberNo, DegasChamberPos, Format(DegasFinalVacuum, '0.0') DegasFinalVacuum, Format(FinalWeight, '0.00') FinalWeight, RollingPos, Rolling1_Pressure, Rolling2_Pressure, FinalSealingPressure, FinalSealingTempUpper, "
                + " FinalSealingTempLower, FinalSealingPos, "
                + " Format(Dimension1, '0.000') Dimension1, Format(Dimension2, '0.000') Dimension2, Format(Dimension3, '0.000') Dimension3, Format(Dimension4, '0.000') Dimension4, Format(Dimension5, '0.000') Dimension5, "
                + " Format(Dimension6, '0.000') Dimension6, Format(Dimension7, '0.000') Dimension7, Format(Dimension8, '0.000') Dimension8, "
                + " Format(Dimension9, '0.000') Dimension9, Format(Dimension10, '0.000') Dimension10, Format(Dimension11, '0.000') Dimension11, "
                + " Format(Dimension12, '0.000') Dimension12, Format(Dimension13, '0.000') Dimension13, Format(Dimension14, '0.000') Dimension14, Format(Dimension15, '0.000') Dimension15, "
                + " HipotVolt, Format(HipotTime, '0.0') HipotTime, Format(HipotResistant, '0.00') HipotResistant, HipotPos, CellThicknessPressure, CellThicknessPos, "
                + " Format(CellThicknessDataCH1, '0.00') CellThicknessDataCH1, Format(CellThicknessDataCH2, '0.00') CellThicknessDataCH2, Format(CellThicknessDataCH3, '0.00') CellThicknessDataCH3, Format(CellThicknessDataCH4, '0.00') CellThicknessDataCH4, Format(CellThicknessDataCH5, '0.00') CellThicknessDataCH5, "
                + " Format(FilledWeight, '0.00') FilledWeight, Format(PostFillWeight, '0.00') PostFillWeight, Format(LossWeight, '0.00') LossWeight, Format(RetentionWeight, '0.00') RetentionWeight, Format(CalcConstant, '0.00') CalcConstant, "
                + " Format(CellThicknessDataAVG, '0.00') CellThicknessDataAVG, Format(AForeFillWeight, '0.00') AForeFillWeight, Format(AFilledWeight, '0.00') AFilledWeight, Format(APostFillWeight, '0.00') APostFillWeight ";
            // 20191101 KJY tCellProcCHG 컬럼추가 (StartVoltage CHG_StartVoltage, Pressure_01, Pressure_02, StepStartTime, StepEndTime, Temp CHG_Temp)
            strColumns += " , Format(CHG_StartVoltage, '0.00') CHG_StartVoltage, Pressure_01, Pressure_02, StepStartTime, StepEndTime, CHG_Temp";

            if (CellID != null)
                strCellID = CellID;


            if (lstVar[0] == "2")
            {
                string tmpViewQuery = string.Empty;
                tmpViewQuery = QueryToCellProcStepDataFromManualQuery(strTrayID);
                strSQL.Append($" SELECT {strColumns} FROM ({tmpViewQuery}) ViewCellHistInfo ");
                
                //strSQL.Append($" SELECT {strColumns} FROM viCellHistInfo WITH (NOLOCK) ");
            }
            else
            {
                strSQL.Append($" SELECT {strColumns} FROM viCellHistInfo WITH (NOLOCK) ");
                //strSQL.Append($" SELECT {strColumns} FROM viCellHistInfo2 WITH (NOLOCK) ");

            }

            


            strSQL.Append($" WHERE LineID = '{strLineID}'");
            strSQL.Append($" AND ProcWorkIndex = '{strProcWorkIndex}'");

            // 3종세트 기본 Query로 추가
            if (strModelID.Length > 0) strSQL.Append($" AND ProdModel = '{strModelID}'");
            if (strRouteID.Length > 0) strSQL.Append($" AND RouteID = '{strRouteID}'");
            //if (strLotID.Length > 0) strSQL.Append($" AND LotID = '{strLotID}'");

            switch (lstVar[0])
            {
                case "0": //기본조건
                    if (CellID != null)
                    {
                        strSQL.Append($"    AND CellID = '{CellID}'");
                    }
                    else
                    {
                        if (strCellList != null)
                        {
                            strSQL.Append($" AND CellID IN ({strCellList})");

                        }
                        else
                        {

                            //strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND '{strEndTime}'");
                            // 20190420 KJY - InputDate InputTime으로 가는게 맞을것 같다. 
                            strSQL.Append($"    AND (InputDate+InputTime > '{strStartTime}' AND InputDate+InputTime < '{strEndTime}') ");

                            //if (strModelID.Length > 0) strSQL.Append($"    AND ProdModel                     = '{strModelID}'");
                            //if (strRouteID.Length > 0) strSQL.Append($"    AND RouteID                     = '{strRouteID}'");
                            //if (strLotID.Length > 0) strSQL.Append($"    AND LotID                     = '{strLotID}'");

                            //20190420 KJY - NGCell검색을 위해
                            if (bNGCellFlag) strSQL.Append($"    AND Grade in ('1','2','3','4','N','M','T','K')");
                            else strSQL.Append($"    AND (Grade not in ('1','2','3','4','N','M','T','K') or F.Grade is null )");
                        }

                    }

                    break;
                case "1": //CellID 조회
                    //strSQL.Append($"    AND CellID                     = '{strCellID}'");
                    //strSQL.Append($"    AND CellID                     like '%{strCellID}'");
                    //20191009 KJY - 여기서 CellID의 Length 체크해서 = 로 할지 like로 할지 결정하자.
                    if(strCellID.Length >= CDefine.DEF_MAX_CELLID_LENGTH)
                    {
                        strSQL.Append($"    AND CellID = '{strCellID}'");
                    } else
                    {
                        strSQL.Append($"    AND CellID like '%{strCellID}'");
                    }


                    break;
                case "2": //Tray별 Cell 조회
                    // 20190409 KJY - Tray에 담겨있는 CellID를 기준으로 가져와야 한다.
                    //strSQL.Append($" AND CellID IN (SELECT CellID FROM tCellCurr WHERE TrayID = '{strTrayID}')");
                    strSQL.Append($" AND CellID IN (SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '{strTrayID}')");
                    if (bNGCellFlag) strSQL.Append($"    AND Grade in ('1','2','3','4','N','M','T','K')");

                    break;
            }

            //20191011 - KJY 선택한 공정의 값만 가져오도록
            if(SelectedProc.Length==3)
            {
                strSQL.Append($" AND EqpTypeID+OperGroupID+OperID = '{SelectedProc}' ");
            }

            //strSQL.Append(" ORDER BY TrayID ASC, CellNo ASC, StartTime ASC");
            // 20191108 KJY order by에 부하가 크다... 빼도 되지 않을까?
            strSQL.Append(" ORDER BY TrayID ASC, CellNo ASC");
            return strSQL.ToString();
        }

        // 20191129 KJY - Cell 검색 속도 향상을 위해서 View말고 Query로 풀어서 가져온다.
        // 여기서는 CellID별로 Row가 중복되지 않는다.
        private string QueryToCellProcStepDataNoDuplication(List<string> lstVar, string CellID = null, bool bNGCellFlag = false, string SelectedProc = "")
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = string.Empty;
            string strStartTime = string.Empty;
            string strEndTime = string.Empty;
            string strModelID = string.Empty;
            string strRouteID = string.Empty;
            string strLotID = string.Empty;
            string strCellID = string.Empty;
            string strTrayID = string.Empty;
            string strTrayInputData = string.Empty;
            string strTrayInputTime = string.Empty;
            string strProcWorkIndex = "0";

            //20190515 KJY 생산차수추가
            string strProductOrder = string.Empty;

            //20190603
            string strCellList = null;

            //조회 조건
            //1. 시간, 모델, 라우터, LOT
            //2. CellID
            //3. TrayID, TrayInputDate

            //공통
            strLineID = lstVar[1];

            switch (lstVar[0])
            {
                case "0": //기본조건

                    //if (lstVar.Count != 7) return "";

                    strStartTime = lstVar[2];
                    strEndTime = lstVar[3];
                    strModelID = lstVar[4];
                    strRouteID = lstVar[5];
                    strLotID = lstVar[6];
                    if (lstVar.Count > 7)
                        strProductOrder = lstVar[7];

                    if (lstVar.Count > 8)
                        strCellList = lstVar[8];

                    break;
                case "1"://CellID 조회
                    //if (lstVar.Count != 5) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strCellID = lstVar[4];
                    if (lstVar.Count > 5)
                        strProductOrder = lstVar[5];
                    if (lstVar.Count > 6)
                        if (lstVar[6].Length == 1)
                            strProcWorkIndex = lstVar[6]; //ProcWorkIndex

                    break;
                case "2"://Tray별 Cell 조회
                    //if (lstVar.Count != 6) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strTrayID = lstVar[4];
                    //PartKey Hist..변경시 사용..
                    strStartTime = lstVar[5];
                    //strEndTime = lstVar[6];

                    //20190926 KJY - 3종세트 추가
                    strModelID = lstVar[6];
                    strRouteID = lstVar[7];
                    strLotID = lstVar[8];
                    break;
            }
            /* 셀 검색
            * [0]  0:기본조건   1:CellID로 조회   2: Tray별Cell조회
            *  0: 기본조건일때
            *      [1] : LineID, [2] : StartTime, [3] : EndTime, [4] : ModelID, [5] RouteID, [6] : LotID, [7?] : ProductOrder (미사용) [8] : Cell List
            *  1: Cell ID로 조회
            *      [1] : LineID, [2] : TrayInputDate, [3] : TrayInputTime, [4] : Cell ID, [5] : for PartKey? , [6] : ProcWorkIndex
            *  2: Tray별 Cell 조회
            *      [1] : LineID, [2] : TrayInputDate, [3] : TrayInputTime, [4] : TrayID, [5???] : StartTime
            *      ==> 여기서도 ModelID, RouteID, LotID 포함시켜야 한다.  [6]: ModelID, [7]:RouteID, [8]: LotID
            */

            // 01. 




            string strColumns = "CellID, LineID, EqpTypeID , OperGroupID, OperID, ProcWorkIndex , ProcWorkCnt, ProdModel, LotID , RouteID, CellType , InputDate, InputTime, InputObjectID, InputLineID , "
                + " InputFlag, ManualInputFlag, FormInputLineID , FormInputDate, FormInputTime, FormInputFlag , StartDate, EndDate, StartTime, EndTime, ReworkFlag, ReworkProc, ReworkCnt , TrayID, CellNo , "
                + " Channel, ObjectID, TrayInputDate, TrayInputTime, Grade , GradeProc, GradeObjectID, GradeCode ,  "
                + " Format(Capacity, '0.00') Capacity, Format(AvgVoltage, '0.00') AvgVoltage, Temp , Format(Ocv, '0.00') Ocv, DeltaOCV, DeltaK , DeltaIR , "
                + " Format(StartVoltage, '0.00') StartVoltage, Step, Format(IR, '0.000') IR, Format(EndVoltage, '0.00') EndVoltage, Format(EndCurrent, '0.00') EndCurrent, "
                + " DegasChamberNo, DegasChamberPos, Format(DegasFinalVacuum, '0.0') DegasFinalVacuum, Format(FinalWeight, '0.00') FinalWeight, RollingPos, Rolling1_Pressure, Rolling2_Pressure, FinalSealingPressure, FinalSealingTempUpper, "
                + " FinalSealingTempLower, FinalSealingPos, "
                + " Format(Dimension1, '0.000') Dimension1, Format(Dimension2, '0.000') Dimension2, Format(Dimension3, '0.000') Dimension3, Format(Dimension4, '0.000') Dimension4, Format(Dimension5, '0.000') Dimension5, "
                + " Format(Dimension6, '0.000') Dimension6, Format(Dimension7, '0.000') Dimension7, Format(Dimension8, '0.000') Dimension8, "
                + " Format(Dimension9, '0.000') Dimension9, Format(Dimension10, '0.000') Dimension10, Format(Dimension11, '0.000') Dimension11, "
                + " Format(Dimension12, '0.000') Dimension12, Format(Dimension13, '0.000') Dimension13, Format(Dimension14, '0.000') Dimension14, Format(Dimension15, '0.000') Dimension15, "
                + " HipotVolt, Format(HipotTime, '0.0') HipotTime, Format(HipotResistant, '0.00') HipotResistant, HipotPos, CellThicknessPressure, CellThicknessPos, "
                + " Format(CellThicknessDataCH1, '0.00') CellThicknessDataCH1, Format(CellThicknessDataCH2, '0.00') CellThicknessDataCH2, Format(CellThicknessDataCH3, '0.00') CellThicknessDataCH3, Format(CellThicknessDataCH4, '0.00') CellThicknessDataCH4, Format(CellThicknessDataCH5, '0.00') CellThicknessDataCH5, "
                + " Format(FilledWeight, '0.00') FilledWeight, Format(PostFillWeight, '0.00') PostFillWeight, Format(LossWeight, '0.00') LossWeight, Format(RetentionWeight, '0.00') RetentionWeight, Format(CalcConstant, '0.00') CalcConstant, "
                + " Format(CellThicknessDataAVG, '0.00') CellThicknessDataAVG, Format(AForeFillWeight, '0.00') AForeFillWeight, Format(AFilledWeight, '0.00') AFilledWeight, Format(APostFillWeight, '0.00') APostFillWeight ";
            // 20191101 KJY tCellProcCHG 컬럼추가 (StartVoltage CHG_StartVoltage, Pressure_01, Pressure_02, StepStartTime, StepEndTime, Temp CHG_Temp)
            strColumns += " , Format(CHG_StartVoltage, '0.00') CHG_StartVoltage, Pressure_01, Pressure_02, StepStartTime, StepEndTime, CHG_Temp";

            if (CellID != null)
                strCellID = CellID;


            if (lstVar[0] == "2")
            {
                string tmpViewQuery = string.Empty;
                tmpViewQuery = QueryToCellProcStepDataFromManualQuery(strTrayID);
                strSQL.Append($" SELECT {strColumns} FROM ({tmpViewQuery}) ViewCellHistInfo ");
                //strSQL.Append($" SELECT * FROM ({tmpViewQuery}) ViewCellHistInfoTest ");
                //strSQL.Append($" SELECT {strColumns} FROM viCellHistInfo WITH (NOLOCK) ");
            }
            else
            {
                //strSQL.Append($" SELECT {strColumns} FROM viCellHistInfo WITH (NOLOCK) ");
                strSQL.Append($" SELECT {strColumns} FROM viCellHistInfo2 WITH (NOLOCK) ");
                
            }




            strSQL.Append($" WHERE LineID = '{strLineID}'");
            strSQL.Append($" AND ProcWorkIndex = '{strProcWorkIndex}'");

            // 3종세트 기본 Query로 추가
            if (strModelID.Length > 0) strSQL.Append($" AND ProdModel = '{strModelID}'");
            if (strRouteID.Length > 0) strSQL.Append($" AND RouteID = '{strRouteID}'");
            //if (strLotID.Length > 0) strSQL.Append($" AND LotID = '{strLotID}'");

            switch (lstVar[0])
            {
                case "0": //기본조건
                    if (CellID != null)
                    {
                        strSQL.Append($"    AND CellID = '{CellID}'");
                    }
                    else
                    {
                        if (strCellList != null)
                        {
                            strSQL.Append($" AND CellID IN ({strCellList})");

                        }
                        else
                        {

                            //strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND '{strEndTime}'");
                            // 20190420 KJY - InputDate InputTime으로 가는게 맞을것 같다. 
                            strSQL.Append($"    AND (InputDate+InputTime > '{strStartTime}' AND InputDate+InputTime < '{strEndTime}') ");

                            //if (strModelID.Length > 0) strSQL.Append($"    AND ProdModel                     = '{strModelID}'");
                            //if (strRouteID.Length > 0) strSQL.Append($"    AND RouteID                     = '{strRouteID}'");
                            //if (strLotID.Length > 0) strSQL.Append($"    AND LotID                     = '{strLotID}'");

                            //20190420 KJY - NGCell검색을 위해
                            if (bNGCellFlag) strSQL.Append($"    AND Grade in ('1','2','3','4','N','M','T','K')");
                            else strSQL.Append($"    AND (Grade not in ('1','2','3','4','N','M','T','K') or F.Grade is null )");
                        }

                    }

                    break;
                case "1": //CellID 조회
                    //strSQL.Append($"    AND CellID                     = '{strCellID}'");
                    //strSQL.Append($"    AND CellID                     like '%{strCellID}'");
                    //20191009 KJY - 여기서 CellID의 Length 체크해서 = 로 할지 like로 할지 결정하자.
                    if (strCellID.Length >= CDefine.DEF_MAX_CELLID_LENGTH)
                    {
                        strSQL.Append($"    AND CellID = '{strCellID}'");
                    }
                    else
                    {
                        strSQL.Append($"    AND CellID like '%{strCellID}'");
                    }


                    break;
                case "2": //Tray별 Cell 조회
                    // 20190409 KJY - Tray에 담겨있는 CellID를 기준으로 가져와야 한다.
                    //strSQL.Append($" AND CellID IN (SELECT CellID FROM tCellCurr WHERE TrayID = '{strTrayID}')");
                    strSQL.Append($" AND CellID IN (SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '{strTrayID}')");
                    if (bNGCellFlag) strSQL.Append($"    AND Grade in ('1','2','3','4','N','M','T','K')");

                    break;
            }

            //20191011 - KJY 선택한 공정의 값만 가져오도록
            if (SelectedProc.Length == 3)
            {
                strSQL.Append($" AND EqpTypeID+OperGroupID+OperID = '{SelectedProc}' ");
            }

            //strSQL.Append(" ORDER BY TrayID ASC, CellNo ASC, StartTime ASC");
            // 20191108 KJY order by에 부하가 크다... 빼도 되지 않을까?
            strSQL.Append(" ORDER BY TrayID ASC, CellNo ASC");
            return strSQL.ToString();
        }

        private string QueryToCellProcStepDataFromManualQuery(string strTrayID)
        {
            string returnViewQuery = string.Empty;
            
//            FORMAT(B.Capacity, '0.00'), FORMAT(B.AvgVoltage, '0.00') , A.BoxTempEnd Temp, FORMAT(C.Ocv, '0.00'), C.DeltaOCV, C.DeltaK , D.DeltaIR , FORMAT(E.StartVoltage, '0.00')
//, ISNULL(ISNULL(E.Step, B.Step), '1')Step , FORMAT(ISNULL(D.IR, E.IR)IR, '0.00') , FORMAT(ISNULL(B.EndVoltage, E.EndVoltage)EndVoltage, '0.00') , FORMAT(ISNULL(B.EndCurrent, E.EndCurrent)EndCurrent, '0.00') , 
            // 기본 정수 단위
            string strViCellHistInfo = @"SELECT A.CellID, A.LineID, A.EqpTypeID , A.OperGroupID, A.OperID, A.ProcWorkIndex , A.ProcWorkCnt, A.ProdModel, A.LotID , A.RouteID, A.CellType , F.TrayInputDate InputDate, F.TrayInputTime InputTime
                                    , A.InputObjectID, A.InputLineID , A.InputFlag, A.ManualInputFlag, A.FormInputLineID , A.FormInputDate, A.FormInputTime, A.FormInputFlag , A.StartDate, A.EndDate
                                    , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime
                                    , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime
                                    , A.ReworkFlag, A.ReworkProc, A.ReworkCnt , F.TrayID, F.CellNo , A.CellNo Channel, A.ObjectID
                                    , (CASE ISNULL(A.TrayInputDate, '') WHEN '' THEN A.TrayInputDate ELSE CONVERT(VARCHAR(10), CONVERT(DATE, A.TrayInputDate), 120) END) AS TrayInputDate
                                    , (CASE ISNULL(A.TrayInputTime, '') WHEN '' THEN A.TrayInputTime ELSE CONVERT(VARCHAR(8), CONVERT(TIME, stuff(stuff(A.TrayInputTime, 3, 0, ':'), 6, 0, ':')), 108) END) AS TrayInputTime
                                    , F.Grade , F.GradeProc, F.GradeObjectID, F.GradeCode , 

B.Capacity, B.AvgVoltage , A.BoxTempEnd Temp , C.Ocv, C.DeltaOCV, C.DeltaK , D.DeltaIR , E.StartVoltage
, ISNULL(ISNULL(E.Step, B.Step), '1')Step , ISNULL(D.IR, E.IR)IR , ISNULL(B.EndVoltage, E.EndVoltage)EndVoltage , ISNULL(B.EndCurrent, E.EndCurrent)EndCurrent , 

                                    G.DegasChamberNo, G.DegasChamberPos, G.DegasFinalVacuum, G.FinalWeight, G.RollingPos, G.Rolling1_Pressure, G.Rolling2_Pressure, G.FinalSealingPressure, G.FinalSealingTempUpper, G.FinalSealingTempLower, G.FinalSealingPos, G.Dimension1, G.Dimension2, G.Dimension3, G.Dimension4, G.Dimension5, G.Dimension6, G.Dimension7, G.Dimension8, G.Dimension9, G.Dimension10, G.Dimension11, G.Dimension12, G.Dimension13, G.Dimension14, G.Dimension15, G.HipotVolt, G.HipotTime, G.HipotResistant, G.HipotPos, G.CellThicknessPressure, G.CellThicknessPos, G.CellThicknessDataCH1, G.CellThicknessDataCH2, G.CellThicknessDataCH3, G.CellThicknessDataCH4, G.CellThicknessDataCH5, G.FilledWeight, G.PostFillWeight, G.LossWeight, G.RetentionWeight, G.CalcConstant, G.CellThicknessDataAVG
                                    , H.ForeFillWeight AForeFillWeight, H.FilledWeight AFilledWeight, H.PostFillWeight APostFillWeight  

, B.StartVoltage CHG_StartVoltage, B.Pressure_01, B.Pressure_02
, (CASE ISNULL(B.StepStartTime, '') WHEN '' THEN B.StepStartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(B.StepStartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StepStartTime
, (CASE ISNULL(B.StepEndTime, '') WHEN '' THEN B.StepEndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(B.StepEndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StepEndTime
, B.Temp CHG_Temp


                                    FROM tCellProStep A WITH(NOLOCK)
                                    LEFT OUTER JOIN tCellProChg B WITH(NOLOCK)
                                    ON B.LineID = A.LineID AND B.EqpTypeID = A.EqpTypeID AND B.OperGroupID = A.OperGroupID AND B.OperID = A.OperID AND B.ProcWorkIndex = A.ProcWorkIndex AND B.CellID = A.CellID
                                    AND B.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProOcv C WITH(NOLOCK)
                                    ON C.LineID = A.LineID AND C.EqpTypeID = A.EqpTypeID AND C.OperGroupID = A.OperGroupID AND C.OperID = A.OperID AND C.ProcWorkIndex = A.ProcWorkIndex AND C.CellID = A.CellID
                                    AND C.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProIR D WITH(NOLOCK)
                                    ON D.LineID = A.LineID AND D.EqpTypeID = A.EqpTypeID AND D.OperGroupID = A.OperGroupID AND D.OperID = A.OperID AND D.ProcWorkIndex = A.ProcWorkIndex AND D.CellID = A.CellID
                                    AND D.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProDCIR E WITH(NOLOCK)
                                    ON E.LineID = A.LineID AND E.EqpTypeID = A.EqpTypeID AND E.OperGroupID = A.OperGroupID AND E.OperID = A.OperID AND E.ProcWorkIndex = A.ProcWorkIndex AND E.CellID = A.CellID
                                    AND E.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProDegas G WITH(NOLOCK)
                                    ON G.LineID = A.LineID AND G.EqpTypeID = A.EqpTypeID AND G.OperGroupID = A.OperGroupID AND G.OperID = A.OperID AND G.ProcWorkIndex = A.ProcWorkIndex AND G.CellID = A.CellID
                                    AND G.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProAssembly H WITH(NOLOCK)
                                    ON H.LineID = A.LineID AND H.EqpTypeID = A.EqpTypeID AND H.OperGroupID = A.OperGroupID AND H.OperID = A.OperID AND H.ProcWorkIndex = A.ProcWorkIndex AND H.CellID = A.CellID
                                    AND H.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellCurr F WITH(NOLOCK)
                                    ON A.CellID = F.CellID  AND F.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    WHERE  A.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##') 
                                    ";
            // mA, mV 단위 변환 PYG 19.09.17
            /*
            strViCellHistInfo = @"SELECT A.CellID, A.LineID, A.EqpTypeID , A.OperGroupID, A.OperID, A.ProcWorkIndex , A.ProcWorkCnt, A.ProdModel, A.LotID , A.RouteID, A.CellType , F.TrayInputDate InputDate, F.TrayInputTime InputTime
                                    , A.InputObjectID, A.InputLineID , A.InputFlag, A.ManualInputFlag, A.FormInputLineID , A.FormInputDate, A.FormInputTime, A.FormInputFlag , A.StartDate, A.EndDate
                                    , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime
                                    , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime
                                    , A.ReworkFlag, A.ReworkProc, A.ReworkCnt , F.TrayID, F.CellNo , A.CellNo Channel, A.ObjectID
                                    , (CASE ISNULL(A.TrayInputDate, '') WHEN '' THEN A.TrayInputDate ELSE CONVERT(VARCHAR(10), CONVERT(DATE, A.TrayInputDate), 120) END) AS TrayInputDate
                                    , (CASE ISNULL(A.TrayInputTime, '') WHEN '' THEN A.TrayInputTime ELSE CONVERT(VARCHAR(8), CONVERT(TIME, stuff(stuff(A.TrayInputTime, 3, 0, ':'), 6, 0, ':')), 108) END) AS TrayInputTime
                                    , F.Grade , F.GradeProc, F.GradeObjectID, F.GradeCode , B.Capacity, B.AvgVoltage , A.BoxTempEnd Temp , C.Ocv, C.DeltaOCV, C.DeltaK , D.DeltaIR , E.StartVoltage
                                    , ISNULL(ISNULL(E.Step, B.Step), '1')Step , ISNULL(D.IR, E.IR)IR , ISNULL(B.EndVoltage, E.EndVoltage)EndVoltage , ISNULL(B.EndCurrent, E.EndCurrent)EndCurrent , 
                                    G.DegasChamberNo, G.DegasChamberPos, G.DegasFinalVacuum, G.FinalWeight, G.RollingPos, G.Rolling1_Pressure, G.Rolling2_Pressure, G.FinalSealingPressure, G.FinalSealingTempUpper, G.FinalSealingTempLower, G.FinalSealingPos, G.Dimension1, G.Dimension2, G.Dimension3, G.Dimension4, G.Dimension5, G.Dimension6, G.Dimension7, G.Dimension8, G.Dimension9, G.Dimension10, G.Dimension11, G.Dimension12, G.Dimension13, G.Dimension14, G.Dimension15, G.HipotVolt, G.HipotTime, G.HipotResistant, G.HipotPos, G.CellThicknessPressure, G.CellThicknessPos, G.CellThicknessDataCH1, G.CellThicknessDataCH2, G.CellThicknessDataCH3, G.CellThicknessDataCH4, G.CellThicknessDataCH5, G.FilledWeight, G.PostFillWeight, G.LossWeight, G.RetentionWeight, G.CalcConstant, G.CellThicknessDataAVG
                                    , H.ForeFillWeight AForeFillWeight, H.FilledWeight AFilledWeight, H.PostFillWeight APostFillWeight  
                                    FROM tCellProStep A WITH(NOLOCK)
                                    LEFT OUTER JOIN tCellProChg B WITH(NOLOCK)
                                    ON B.LineID = A.LineID AND B.EqpTypeID = A.EqpTypeID AND B.OperGroupID = A.OperGroupID AND B.OperID = A.OperID AND B.ProcWorkIndex = A.ProcWorkIndex AND B.CellID = A.CellID
                                    AND B.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProOcv C WITH(NOLOCK)
                                    ON C.LineID = A.LineID AND C.EqpTypeID = A.EqpTypeID AND C.OperGroupID = A.OperGroupID AND C.OperID = A.OperID AND C.ProcWorkIndex = A.ProcWorkIndex AND C.CellID = A.CellID
                                    AND C.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProIR D WITH(NOLOCK)
                                    ON D.LineID = A.LineID AND D.EqpTypeID = A.EqpTypeID AND D.OperGroupID = A.OperGroupID AND D.OperID = A.OperID AND D.ProcWorkIndex = A.ProcWorkIndex AND D.CellID = A.CellID
                                    AND D.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProDCIR E WITH(NOLOCK)
                                    ON E.LineID = A.LineID AND E.EqpTypeID = A.EqpTypeID AND E.OperGroupID = A.OperGroupID AND E.OperID = A.OperID AND E.ProcWorkIndex = A.ProcWorkIndex AND E.CellID = A.CellID
                                    AND E.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProDegas G WITH(NOLOCK)
                                    ON G.LineID = A.LineID AND G.EqpTypeID = A.EqpTypeID AND G.OperGroupID = A.OperGroupID AND G.OperID = A.OperID AND G.ProcWorkIndex = A.ProcWorkIndex AND G.CellID = A.CellID
                                    AND G.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellProAssembly H WITH(NOLOCK)
                                    ON H.LineID = A.LineID AND H.EqpTypeID = A.EqpTypeID AND H.OperGroupID = A.OperGroupID AND H.OperID = A.OperID AND H.ProcWorkIndex = A.ProcWorkIndex AND H.CellID = A.CellID
                                    AND H.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    LEFT OUTER JOIN tCellCurr F WITH(NOLOCK)
                                    ON A.CellID = F.CellID  AND F.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##')
                                    WHERE  A.CellID IN(SELECT CellID FROM tCellCurr WITH(NOLOCK) WHERE TrayID = '##TRAYID##') 
                                    ";
                */
            returnViewQuery = strViCellHistInfo.Replace("##TRAYID##", strTrayID);

            return returnViewQuery;
        }

        #endregion

        #region [QueryToHistCellProcStepData]
        private string QueryToHistCellProcStepData(List<string> lstVar, bool bNGCellFlag = false)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = string.Empty;
            string strStartTime = string.Empty;
            string strEndTime = string.Empty;
            string strModelID = string.Empty;
            string strRouteID = string.Empty;
            string strLotID = string.Empty;
            string strCellID = string.Empty;
            string strTrayID = string.Empty;
            string strTrayInputData = string.Empty;
            string strTrayInputTime = string.Empty;

            //20200727 KJY - 생산완료 셀 데이터 검색시 ProcWorkIndex 조건을 넣는부분이 빠졌다.
            string strProcWorkIndex = "0";

            //20170614 KJY - for CellID List
            string strProductOrder = string.Empty;
            string strCellList = string.Empty;

            //조회 조건
            //1. 시간, 모델, 라우터, LOT
            //2. CellID
            //3. TrayID, TrayInputDate

            //공통
            strLineID = lstVar[1];

            switch (lstVar[0])
            {
                case "0": //기본조건

                    //if (lstVar.Count < 7) return "";

                    strStartTime = lstVar[2];
                    strEndTime = lstVar[3];
                    strModelID = lstVar[4];
                    strRouteID = lstVar[5];
                    strLotID = lstVar[6];

                    if (lstVar.Count > 7)
                        strProductOrder = lstVar[7];

                    if (lstVar.Count > 8)
                        strCellList = lstVar[8];

                    break;
                case "1"://CellID 조회
                    //if (lstVar.Count != 7) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strCellID = lstVar[4];

                    //20191108 KJY 추가
                    strRouteID = lstVar[5];

                    //20200727 KJY - for ProcWorkIndex
                    strProcWorkIndex = lstVar[6];

                    break;
                case "2"://Tray별 Cell 조회
                    //if (lstVar.Count != 6) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strTrayID = lstVar[4];
                    //PartKey Hist..변경시 사용..
                    strStartTime = lstVar[5];
                    //strEndTime = lstVar[5];

                    //20190926 KJY - 3종세트 추가
                    strModelID = lstVar[6];
                    strRouteID = lstVar[7];
                    strLotID = lstVar[8];
                    break;
            }


            /* 셀 검색
            * [0]  0:기본조건   1:CellID로 조회   2: Tray별Cell조회
            *  0: 기본조건일때
            *      [1] : LineID, [2] : StartTime, [3] : EndTime, [4] : ModelID, [5] RouteID, [6] : LotID, [7?] : ProductOrder (미사용) [8] : Cell List
            *  1: Cell ID로 조회
            *      [1] : LineID, [2] : TrayInputDate, [3] : TrayInputTime, [4] : Cell ID, [5] : for PartKey? , [6] : ProcWorkIndex
            *  2: Tray별 Cell 조회
            *      [1] : LineID, [2] : TrayInputDate, [3] : TrayInputTime, [4] : TrayID, [5???] : StartTime
            *      ==> 여기서도 ModelID, RouteID, LotID 포함시켜야 한다.  [6]: ModelID, [7]:RouteID, [8]: LotID
            */

            strSQL.Append("SELECT A.CellID,                   A.LineID,                   A.EqpTypeID");
            strSQL.Append("     , A.OperGroupID,              A.OperID,                   A.ProcWorkIndex");
            strSQL.Append("     , A.ProcWorkCnt,              A.ProdModel,                A.LotID");
            strSQL.Append("     , A.RouteID,                  A.CellType");
            // 20190430 KJY - InputDate, InputTime을 tCellCurr의 TrayInputDate, TrayInputTime 으로.... 아 잘 모르겠다.
            //strSQL.Append("     , A.InputDate,                A.InputTime");
            strSQL.Append("     , F.TrayInputDate InputDate,            F.TrayInputTime InputTime");

            strSQL.Append("     , A.InputObjectID,            A.InputLineID");
            strSQL.Append("     , A.InputFlag,                A.ManualInputFlag,          A.FormInputLineID");
            strSQL.Append("     , A.FormInputDate,            A.FormInputTime,            A.FormInputFlag");
            strSQL.Append("     , A.StartDate,                A.EndDate");
            strSQL.Append("     , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime");
            strSQL.Append("     , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime");
            strSQL.Append("     , A.ReworkFlag,               A.ReworkProc,               A.ReworkCnt");
            // 현재 CellNo는 tCellCurr에서 가져와야 정확하다.
            //strSQL.Append("     , A.TrayID,                   A.CellNo");
            strSQL.Append("     , F.TrayID,                   F.CellNo");
            //20190425 KJY - 작업당시의 CellNo와 ObjectID를 받아온다.
            strSQL.Append("     , A.CellNo Channel,                   A.ObjectID");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputDate, '') WHEN '' THEN A.TrayInputDate ELSE CONVERT(VARCHAR(10), CONVERT(DATE, A.TrayInputDate), 120) END) AS TrayInputDate");
            strSQL.Append("     , (CASE ISNULL(A.TrayInputTime, '') WHEN '' THEN A.TrayInputTime ELSE CONVERT(VARCHAR(8), CONVERT(TIME, stuff(stuff(A.TrayInputTime, 3, 0, ':'), 6, 0, ':')), 108) END) AS TrayInputTime");
            //strSQL.Append("     , A.Grade");
            //20190420 KJY - Grade는 tCellCurr에서 가져와라... 
            strSQL.Append("     , F.Grade");
            strSQL.Append("     , B.Capacity,                   B.AvgVoltage");
            //20190425 - tCellProStep에서 Temp를 가져온다.
            //strSQL.Append("     , B.Temp,                       B.TempValue,           B.CapacityTemp");
            strSQL.Append("     , A.BoxTempEnd Temp");
            strSQL.Append("     , C.Ocv,                        C.DeltaOCV,             C.DeltaK");
            strSQL.Append("     , D.DeltaIR");
            strSQL.Append("     , E.StartVoltage");
            //겹치는 항목, Data 는 겹칠 수 없다.
            strSQL.Append("     , ISNULL(ISNULL(E.Step, B.Step), '1')Step");
            strSQL.Append("     , ISNULL(D.IR, E.IR)IR");
            strSQL.Append("     , ISNULL(B.EndVoltage, E.EndVoltage)EndVoltage");
            strSQL.Append("     , ISNULL(B.EndCurrent, E.EndCurrent)EndCurrent");

            //Degas Data
            //strSQL.Append("     , G.DegasChamberNo, G.DegasChamberPos, G.DegasFinalVacuum, G.FinalWeight, G.RollingPos, G.Rolling1_Pressure, G.Rolling2_Pressure, G.FinalSealingPressure, G.FinalSealingTempUpper, G.FinalSealingTempLower, G.FinalSealingPos, G.Dimension1, G.Dimension2, G.Dimension3, G.Dimension4, G.Dimension5, G.Dimension6, G.Dimension7, G.Dimension8, G.Dimension9, G.Dimension10, G.Dimension11, G.Dimension12, G.Dimension13, G.Dimension14, G.Dimension15, G.HipotVolt, G.HipotTime, G.HipotResistant, G.HipotPos, G.CellThicknessPressure, G.CellThicknessPos, G.CellThicknessDataCH1, G.CellThicknessDataCH2, G.CellThicknessDataCH3, G.CellThicknessDataCH4, G.CellThicknessDataCH5, G.FilledWeight, G.PostFillWeight, G.LossWeight, G.RetentionWeight, G.CalcConstant");
            strSQL.Append("     , G.DegasChamberNo, G.DegasChamberPos, G.DegasFinalVacuum, G.FinalWeight, G.RollingPos, G.Rolling1_Pressure, G.Rolling2_Pressure, G.FinalSealingPressure, G.FinalSealingTempUpper, G.FinalSealingTempLower, G.FinalSealingPos, G.Dimension1, G.Dimension2, G.Dimension3, G.Dimension4, G.Dimension5, G.Dimension6, G.Dimension7, G.Dimension8, G.Dimension9, G.Dimension10, G.Dimension11, G.Dimension12, G.Dimension13, G.Dimension14, G.Dimension15, G.HipotVolt, G.HipotTime, G.HipotResistant, G.HipotPos, G.CellThicknessPressure, G.CellThicknessPos, G.CellThicknessDataCH1, G.CellThicknessDataCH2, G.CellThicknessDataCH3, G.CellThicknessDataCH4, G.CellThicknessDataCH5, G.CellThicknessDataAVG, G.FilledWeight, G.PostFillWeight, G.LossWeight, G.RetentionWeight, G.CalcConstant");

            //20190509 KJY - Assembly Data
            // AForeFillWeight : 주액전 중량 AFilledWeight: 주액량 APostFillWeight : 주액후 중량
            strSQL.Append("     , H.ForeFillWeight AForeFillWeight, H.FilledWeight AFilledWeight, H.PostFillWeight APostFillWeight");

            //20191101 KJY tCellProcCHG 컬럼추가 (StartVoltage, Pressure_01, Pressure_02, StepStartTime, StepEndTime, Temp)
            //strSQL.Append("     , B.StartVoltage CHG_StartVoltage, B.Pressure_01, B.Pressure_02, B.StepStartTime, B.StepEndTime, B.Temp CHG_Temp");

            strSQL.Append(", B.StartVoltage CHG_StartVoltage, B.Pressure_01, B.Pressure_02 ");
            strSQL.Append(", (CASE ISNULL(B.StepStartTime, '') WHEN '' THEN B.StepStartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(B.StepStartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StepStartTime ");
            strSQL.Append(", (CASE ISNULL(B.StepEndTime, '') WHEN '' THEN B.StepEndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME, stuff(stuff(stuff(B.StepEndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StepEndTime ");
            strSQL.Append(", B.Temp CHG_Temp ");



            strSQL.Append("  FROM tHistCellProStep A WITH(NOLOCK)");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProChg B WITH(NOLOCK)");
            strSQL.Append("      ON B.LineID            = A.LineID");
            strSQL.Append("     AND B.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND B.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND B.OperID            = A.OperID");
            strSQL.Append("     AND B.ProcWorkIndex     = A.ProcWorkIndex");
            strSQL.Append("     AND B.TrayID            = A.TrayID");
            strSQL.Append("     AND B.CellNo            = A.CellNo");
            strSQL.Append("     AND B.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND B.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProOcv C WITH(NOLOCK)");
            strSQL.Append("      ON C.LineID            = A.LineID");
            strSQL.Append("     AND C.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND C.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND C.OperID            = A.OperID");
            strSQL.Append("     AND C.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND C.TrayID            = A.TrayID");
            //strSQL.Append("     AND C.CellNo            = A.CellNo");
            strSQL.Append("     AND C.CellID            = A.CellID");
            strSQL.Append("     AND C.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND C.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProIR D WITH(NOLOCK)");
            strSQL.Append("      ON D.LineID            = A.LineID");
            strSQL.Append("     AND D.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND D.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND D.OperID            = A.OperID");
            strSQL.Append("     AND D.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND D.TrayID            = A.TrayID");
            //strSQL.Append("     AND D.CellNo            = A.CellNo");
            strSQL.Append("     AND D.CellID            = A.CellID");
            strSQL.Append("     AND D.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND D.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProDCIR E WITH(NOLOCK)");
            strSQL.Append("      ON E.LineID            = A.LineID");
            strSQL.Append("     AND E.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND E.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND E.OperID            = A.OperID");
            strSQL.Append("     AND E.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND E.TrayID            = A.TrayID");
            //strSQL.Append("     AND E.CellNo            = A.CellNo");
            strSQL.Append("     AND E.CellID            = A.CellID");
            strSQL.Append("     AND E.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND E.TrayInputTime     = A.TrayInputTime");


            //20190417 KJY - Degas 데이터도 필요하다.
            strSQL.Append("    LEFT OUTER JOIN tHistCellProDegas G WITH(NOLOCK)");
            strSQL.Append("      ON G.LineID            = A.LineID");
            strSQL.Append("     AND G.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND G.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND G.OperID            = A.OperID");
            strSQL.Append("     AND G.ProcWorkIndex     = A.ProcWorkIndex");
            strSQL.Append("     AND G.TrayID            = A.TrayID");
            //strSQL.Append("     AND G.CellNo            = A.CellNo");
            strSQL.Append("     AND G.CellID            = A.CellID");
            //strSQL.Append("     AND G.TrayInputDate     = A.TrayInputDate");
            //strSQL.Append("     AND G.TrayInputTime     = A.TrayInputTime");


            //20190509 KJY - Assembly Data
            strSQL.Append("    LEFT OUTER JOIN tHistCellProAssembly H WITH(NOLOCK)");
            strSQL.Append("      ON H.LineID            = A.LineID");
            strSQL.Append("     AND H.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND H.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND H.OperID            = A.OperID");
            strSQL.Append("     AND H.ProcWorkIndex     = A.ProcWorkIndex");
            //strSQL.Append("     AND H.TrayID            = A.TrayID");
            //strSQL.Append("     AND H.CellNo            = A.CellNo");
            strSQL.Append("     AND H.CellID            = A.CellID");
            strSQL.Append("     AND H.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND H.TrayInputTime     = A.TrayInputTime");


            //LEFT OUTER JOIN tCellCurr F WITH(NOLOCK)
            //ON A.CellID = F.CellID
            strSQL.Append("    LEFT OUTER JOIN tHistCellCurr F WITH(NOLOCK)");
            strSQL.Append("      ON A.CellID = F.CellID");
            //20191108 KJY RouteID도 보자
            //strSQL.Append("      ON A.CellID = F.CellID AND A.RouteID = F.RouteID");

            strSQL.Append($"  WHERE A.LineID              = '{strLineID}'");
            //strSQL.Append($"    AND A.EqpTypeID          IN ('{CDefine.DEF_EQP_TYPE_ID_FORMATION}', '{CDefine.DEF_EQP_TYPE_ID_IROCV}', '{CDefine.DEF_EQP_TYPE_ID_DCIR}')");

            //strSQL.Append($"    AND A.ProcWorkIndex       = '0'");
            //20200727 KJY for ProcWorkIndex
            strSQL.Append($"    AND A.ProcWorkIndex       = '{strProcWorkIndex}'");


            //20190926 KJY 여기에 기본조건 들어가야 하나? 흠...
            if (strModelID.Length > 0) strSQL.Append($"    AND A.ProdModel = '{strModelID}'");
            if (strRouteID.Length > 0) strSQL.Append($"    AND A.RouteID = '{strRouteID}'");
            if (strLotID.Length > 0) strSQL.Append($"    AND A.LotID = '{strLotID}'");



            switch (lstVar[0])
            {
                case "0": //기본조건
                    if (strCellList.Length > 0)
                    {
                        strSQL.Append($" AND A.CellID IN ({strCellList})");
                    }
                    else
                    {
                        //strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND '{strEndTime}'");
                        // 20190420 KJY - InputDate InputTime으로 가는게 맞을것 같다. 
                        strSQL.Append($"    AND (A.InputDate+A.InputTime > '{strStartTime}' AND A.InputDate+A.InputTime < '{strEndTime}') ");

                        //if (strModelID.Length > 0) strSQL.Append($"    AND A.ProdModel                     = '{strModelID}'");
                        //if (strRouteID.Length > 0) strSQL.Append($"    AND A.RouteID                     = '{strRouteID}'");
                        //if (strLotID.Length > 0) strSQL.Append($"    AND A.LotID                     = '{strLotID}'");
                        //20190420 KJY - NGCell검색을 위해
                        if (bNGCellFlag) strSQL.Append($" AND F.Grade in ('1','2','3','4','N','M','T','K')");
                    }
                    break;
                case "1": //CellID 조회
                    //strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND {strEndTime}");
                    // 20190420 KJY - InputDate InputTime으로 가는게 맞을것 같다. 
                    // 20190614 Cell ID 넣었으면 날자는 보지 말자.
                    //strSQL.Append($"    AND (A.InputDate+A.InputTime > '{strStartTime}' AND A.InputDate+A.InputTime < '{strEndTime}') ");

                    //strSQL.Append($"    AND A.CellID                     = '{strCellID}'");

                    //20190926 KJY - TrayIputDate,, InputTime으로 찾자
                    //strSQL.Append($"    AND A.TrayInputDate         = '{strTrayInputData}'");
                    //strSQL.Append($"    AND A.TrayInputTime         = '{strTrayInputTime}'");

                    if(strCellID.Length>=CDefine.DEF_MAX_CELLID_LENGTH)
                        strSQL.Append($"    AND A.CellID = '{strCellID}'");
                    else
                        strSQL.Append($"    AND A.CellID                     like '%{strCellID}'");



                    if (bNGCellFlag) strSQL.Append($" AND F.Grade in ('1','2','3','4','N','M','T','K')");
                    break;
                case "2": //Tray별 Cell 조회
                    //strSQL.Append($"    AND A.TrayID                = '{strTrayID}'");
                    //strSQL.Append($"    AND A.TrayInputDate         = '{strTrayInputData}'");
                    //strSQL.Append($"    AND A.TrayInputTime         = '{strTrayInputTime}'");
                    // 20190409 KJY - Tray에 담겨있는 CellID를 기준으로 가져와야 한다.
                    strSQL.Append($" AND A.CellID IN (SELECT CellID FROM tHistCellCurr WITH (NOLOCK) WHERE TrayID = '{strTrayID}' AND TrayInputDate = '{strTrayInputData}' AND TrayInputTime = '{strTrayInputTime}')");
                    if (bNGCellFlag) strSQL.Append($"    AND F.Grade in ('1','2','3','4','N','M','T','K')");

                    break;
            }

            //strSQL.Append(" ORDER BY A.TrayInputDate ASC, A.TrayInputTime ASC, A.TrayID ASC, A.CellNo ASC, A.StartTime");
            //strSQL.Append(" ORDER BY A.TrayID ASC, A.CellNo ASC, A.StartTime");
            strSQL.Append(" ORDER BY F.TrayID ASC, F.CellNo ASC, A.StartTime");
            return strSQL.ToString();
        }
        #endregion

        #region [QueryToCellProcStepData, Hist]
        private string QueryToCellProcStepDataHist(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartTime = null;
            string strEndTime = null;
            string strModelID = null;
            string strRouteID = null;
            string strLotID = null;
            string strCellID = null;
            string strTrayID = null;
            string strTrayInputData = null;
            string strTrayInputTime = null;

            //조회 조건
            //1. 시간, 모델, 라우터, LOT
            //2. CellID
            //3. TrayID, TrayInputDate

            //공통
            strLineID = lstVar[1];

            switch (lstVar[0])
            {
                case "0": //기본조건

                    if (lstVar.Count != 7) return "";

                    strStartTime = lstVar[2];
                    strEndTime = lstVar[3];
                    strModelID = lstVar[4];
                    strRouteID = lstVar[5];
                    strLotID = lstVar[6];
                    break;
                case "1"://CellID 조회
                    if (lstVar.Count != 5) return "";
                    strStartTime = lstVar[2];
                    strEndTime = lstVar[3];
                    strCellID = lstVar[4];
                    break;
                case "2"://Tray별 Cell 조회
                    if (lstVar.Count != 6) return "";
                    strTrayInputData = lstVar[2];
                    strTrayInputTime = lstVar[3];
                    strTrayID = lstVar[4];
                    //ParyKey 설정
                    strStartTime = lstVar[5];
                    strEndTime = lstVar[5];
                    break;
            }

            strSQL.Append("SELECT A.CellID,                   A.LineID,                   A.EqpTypeID");
            strSQL.Append("     , A.OperGroupID,              A.OperID,                   A.ProcWorkIndex");
            strSQL.Append("     , A.ProcWorkCnt,              A.ProdModel,                A.LotID");
            strSQL.Append("     , A.RouteID,                  A.CellType,                 A.InputDate");
            strSQL.Append("     , A.InputTime,                A.InputObjectID,            A.InputLineID");
            strSQL.Append("     , A.InputFlag,                A.ManualInputFlag,          A.FormInputLineID");
            strSQL.Append("     , A.FormInputDate,            A.FormInputTime,            A.FormInputFlag");
            strSQL.Append("     , A.TrayInputDate,            A.TrayInputTime,            A.Grade");
            strSQL.Append("     , A.StartDate,                A.EndDate");
            strSQL.Append("     , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime");
            strSQL.Append("     , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime");
            strSQL.Append("     , A.ReworkFlag,               A.ReworkProc,               A.ReworkCnt");
            strSQL.Append("     , A.TrayID,                   A.CellNo");

            strSQL.Append("     , B.Capacity,                   B.AvgVoltage");
            strSQL.Append("     , B.Temp,                       B.TempValue,           B.CapacityTemp");
            strSQL.Append("     , C.Ocv,                        C.DeltaOCV");
            strSQL.Append("     , D.DeltaIR");
            strSQL.Append("     , E.StartVoltage");
            //겹치는 항목, Data 는 겹칠 수 없다.
            strSQL.Append("     , ISNULL(ISNULL(ISNULL(E.Step, D.Step), C.Step), B.Step)Step");
            strSQL.Append("     , ISNULL(D.IR, E.IR)IR");
            strSQL.Append("     , ISNULL(B.EndVoltage, E.EndVoltage)EndVoltage");
            strSQL.Append("     , ISNULL(B.EndCurrent, E.EndCurrent)EndCurrent");

            strSQL.Append("  FROM tHistCellProStep A WITH(NOLOCK)");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProChg B WITH(NOLOCK)");
            strSQL.Append("      ON B.PartKey           = A.PartKey");
            strSQL.Append("     AND B.LineID            = A.LineID");
            strSQL.Append("     AND B.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND B.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND B.OperID            = A.OperID");
            strSQL.Append("     AND B.ProcWorkIndex     = A.ProcWorkIndex");
            strSQL.Append("     AND B.TrayID            = A.TrayID");
            strSQL.Append("     AND B.CellNo            = A.CellNo");
            strSQL.Append("     AND B.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND B.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProOcv C WITH(NOLOCK)");
            strSQL.Append("      ON B.PartKey           = A.PartKey");
            strSQL.Append("     AND B.LineID            = A.LineID");
            strSQL.Append("     AND C.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND C.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND C.OperID            = A.OperID");
            strSQL.Append("     AND C.ProcWorkIndex     = A.ProcWorkIndex");
            strSQL.Append("     AND C.TrayID            = A.TrayID");
            strSQL.Append("     AND C.CellNo            = A.CellNo");
            strSQL.Append("     AND C.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND C.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProIR D WITH(NOLOCK)");
            strSQL.Append("      ON B.PartKey           = A.PartKey");
            strSQL.Append("     AND B.LineID            = A.LineID");
            strSQL.Append("     AND D.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND D.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND D.OperID            = A.OperID");
            strSQL.Append("     AND D.ProcWorkIndex     = A.ProcWorkIndex");
            strSQL.Append("     AND D.TrayID            = A.TrayID");
            strSQL.Append("     AND D.CellNo            = A.CellNo");
            strSQL.Append("     AND D.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND D.TrayInputTime     = A.TrayInputTime");
            strSQL.Append("    LEFT OUTER JOIN tHistCellProDCIR E WITH(NOLOCK)");
            strSQL.Append("      ON B.PartKey           = A.PartKey");
            strSQL.Append("     AND B.LineID            = A.LineID");
            strSQL.Append("     AND E.EqpTypeID         = A.EqpTypeID");
            strSQL.Append("     AND E.OperGroupID       = A.OperGroupID");
            strSQL.Append("     AND E.OperID            = A.OperID");
            strSQL.Append("     AND E.ProcWorkIndex     = A.ProcWorkIndex");
            strSQL.Append("     AND E.TrayID            = A.TrayID");
            strSQL.Append("     AND E.CellNo            = A.CellNo");
            strSQL.Append("     AND E.TrayInputDate     = A.TrayInputDate");
            strSQL.Append("     AND E.TrayInputTime     = A.TrayInputTime");

            if (strStartTime.Substring(0, 6) == strEndTime.Substring(0, 6))
            {
                strSQL.Append($"  WHERE A.PartKey              = '{strLineID}'");
            }
            else
            {
                strSQL.Append($"  WHERE A.PartKey       BETWEEN '{strStartTime.Substring(0, 8)}' AND '{strEndTime.Substring(0, 8)}'");
            }

            strSQL.Append($"    AND A.LineID              = '{strLineID}'");
            //strSQL.Append($"    AND A.EqpTypeID          IN ('{CDefine.DEF_EQP_TYPE_ID_FORMATION}', '{CDefine.DEF_EQP_TYPE_ID_IROCV}', '{CDefine.DEF_EQP_TYPE_ID_DCIR}')");
            strSQL.Append($"    AND A.ProcWorkIndex       = '0'");

            switch (lstVar[0])
            {
                case "0": //기본조건
                    strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND '{strEndTime}'");
                    if (strModelID.Length > 0) strSQL.Append($"    AND A.ProdModel                     = '{strModelID}'");
                    if (strRouteID.Length > 0) strSQL.Append($"    AND A.RouteID                     = '{strRouteID}'");
                    if (strLotID.Length > 0) strSQL.Append($"    AND A.LotID                     = '{strLotID}'");
                    break;
                case "1": //CellID 조회
                    strSQL.Append($"    AND A.StartTime       BETWEEN '{strStartTime}' AND {strEndTime}");
                    strSQL.Append($"    AND A.CellID                     = '{strCellID}'");
                    break;
                case "2": //Tray별 Cell 조회
                    strSQL.Append($"    AND A.TrayID                = '{strTrayID}'");
                    strSQL.Append($"    AND A.TrayInputDate         = '{strTrayInputData}'");
                    strSQL.Append($"    AND A.TrayInputTime         = '{strTrayInputTime}'");
                    break;
            }

            strSQL.Append(" ORDER BY A.TrayInputDate ASC, A.TrayInputTime ASC, A.TrayID ASC, A.CellNo ASC, A.StartTime");
            return strSQL.ToString();
        }
        #endregion

        #region [QueryToWinTrayInfo : 사용안함]
        //Rest 변경으로 인한 히스토리 조인방법문제로 소스에서 처리함.
        //Table
        //tTrayProStep      A
        //tTrayCurr         B
        //tMstRouteOper     C
        //tMstOperation     D
        //Form
        //WinTrayInfo
        private string QueryToWinTrayInfo(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strLineID = null;
            string strLotID = null;
            string strModel = null;
            string strRouteID = null;
            string strTrayID = null;
            string strTrayInputDate = null;
            string strTrayInputTime = null;
            string strProcWorkIndex = null;

            //Data Check
            if (lstVar.Count != 8) return "";

            //필수
            strLineID = lstVar[0];
            strTrayID = lstVar[1];
            strTrayInputDate = lstVar[2];
            strTrayInputTime = lstVar[3];
            //조건
            strLotID = lstVar[4];
            strModel = lstVar[5];
            strRouteID = lstVar[6];
            strProcWorkIndex = lstVar[7];

            // Set Query
            strSQL.Append("SELECT A.ObjectID, A.ProdModel, A.RouteID, A.LotID");
            strSQL.Append("     , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime");
            strSQL.Append("     , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime");
            strSQL.Append("     , A.InputCellCnt,	A.CurrCellCnt");
            strSQL.Append("     , B.OperName,		B.EqpTypeID + B.OperGroupID + B.OperID as ProcID");
            strSQL.Append("     , D.UnitName");
            strSQL.Append("     , E.RackID");
            strSQL.Append("     , SUBSTRING(E.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(E.RackID, 2, 2))) + '-' + SUBSTRING(E.RackID, 4, 1) + 'Line-' + SUBSTRING(E.RackID, 5, 2) + 'Bay-' + SUBSTRING(E.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append(" FROM tTrayProStep		A WITH (NOLOCK)");
            strSQL.Append("      LEFT OUTER JOIN tMstOperation B WITH (NOLOCK)");
            strSQL.Append("        ON B.EqpTypeID	= A.EqpTypeID");
            strSQL.Append("       AND B.OperGroupID	= A.OperGroupID");
            strSQL.Append("       AND B.OperID		= A.OperID");
            strSQL.Append("      LEFT OUTER JOIN tMstEquipment D WITH (NOLOCK)");
            strSQL.Append("        ON D.LineID		    = A.LineID");
            strSQL.Append("       AND D.EqpTypeID	    = A.EqpTypeID");
            strSQL.Append("       AND D.UnitID   	    = SUBSTRING(A.ObjectID,4, 5)");
            strSQL.Append("      LEFT OUTER JOIN tMstAgingRack E WITH (NOLOCK)");
            strSQL.Append("        ON E.LineID		    = A.LineID");
            strSQL.Append("       AND E.RackID			= SUBSTRING(A.ObjectID,4, 5)");
            strSQL.Append($" WHERE A.LineID			    = '{strLineID}'");
            strSQL.Append($"   AND A.TrayID			    = '{strTrayID}'");
            strSQL.Append($"   AND A.TrayInputDate		= '{strTrayInputDate}'");
            strSQL.Append($"   AND A.TrayInputTime		= '{strTrayInputTime}'");

            if (strLotID != null && strLotID.Length > 0) strSQL.Append($"   AND A.LotID				= '{strLotID}'");
            if (strModel != null && strModel.Length > 0) strSQL.Append($"   AND A.ProdModel			= '{strModel}'");
            //공정별 Work Index (현재는 항상 0)
            if (strProcWorkIndex != null && strProcWorkIndex.Length > 0) strSQL.Append($"   AND A.ProcWorkIndex			= '{strProcWorkIndex}'");
            if (strRouteID != null && strRouteID.Length > 0) strSQL.Append($"   AND A.RouteID			= '{strRouteID}'");

            strSQL.Append($" ORDER BY A.StartTime DESC");

            return strSQL.ToString();
        }
        #endregion

        #region [WinTrayInfoHist : 사용안함]
        private string QueryToWinTrayInfoHist(List<string> lstVar)
        {
            StringBuilder strSQL = new StringBuilder();
            string strLineID = null;
            string strLotID = null;
            string strModel = null;
            string strRouteID = null;
            string strTrayID = null;
            string strTrayInputDate = null;
            string strTrayInputTime = null;
            string strProcWorkIndex = null;

            //Data Check
            if (lstVar.Count != 8) return "";

            strLineID = lstVar[0];
            strLotID = lstVar[1];
            strModel = lstVar[2];
            strRouteID = lstVar[3];
            strTrayID = lstVar[4];
            strTrayInputDate = lstVar[5];
            strTrayInputTime = lstVar[6];
            strProcWorkIndex = lstVar[7];

            // Set Query
            strSQL.Append(" SELECT A.UnitID,		A.RouteID");
            strSQL.Append("      , (CASE ISNULL(A.StartTime, '') WHEN '' THEN A.StartTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.StartTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS StartTime");
            strSQL.Append("      , (CASE ISNULL(A.EndTime, '') WHEN '' THEN A.EndTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EndTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EndTime");
            strSQL.Append("      , B.OperName,		B.EqpTypeID + B.OperGroupID + B.OperID as ProcID");
            strSQL.Append("      , A.InputCellCnt,	A.CurrCellCnt");//C->A 변경 Curr 히스토리 없음.
            strSQL.Append("      , D.UnitName");
            strSQL.Append("      , E.RackID");
            strSQL.Append("      , SUBSTRING(E.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(E.RackID, 2, 2))) + '-' + SUBSTRING(E.RackID, 4, 1) + 'Line-' + SUBSTRING(E.RackID, 5, 2) + 'Bay-' + SUBSTRING(E.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append("  FROM tHistTrayProStep	A WITH (NOLOCK)");
            strSQL.Append("       LEFT OUTER JOIN tMstOperation B WITH (NOLOCK)");
            strSQL.Append("         ON B.EqpTypeID	    = A.EqpTypeID");
            strSQL.Append("        AND B.OperGroupID	= A.OperGroupID");
            strSQL.Append("        AND B.OperID		    = A.OperID");
            //strSQL.Append("       LEFT OUTER JOIN viHistTrayCurr C WITH (NOLOCK)");
            //strSQL.Append("         ON C.LotID		= A.LotID");
            //strSQL.Append("        AND C.TrayID		= A.TrayID");
            //strSQL.Append("        AND C.TrayInputDate	= A.TrayInputDate");
            //strSQL.Append("        AND C.TrayInputTime	= A.TrayInputTime");
            strSQL.Append("       LEFT OUTER JOIN tMstEquipment D WITH (NOLOCK)");
            strSQL.Append("         ON D.EqpTypeID	    = A.EqpTypeID");
            strSQL.Append("        AND D.UnitID   	    = SUBSTRING(A.ObjectID,4, 5)");
            strSQL.Append("       LEFT OUTER JOIN tMstAgingRack E WITH (NOLOCK)");
            strSQL.Append("         ON E.RackID			= SUBSTRING(A.ObjectID,4, 5)");
            strSQL.Append($" WHERE A.LineID			    = '{strLineID}'");
            strSQL.Append($"   AND A.TrayID			    = '{strTrayID}'");
            strSQL.Append($"   AND A.TrayInputDate		= '{strTrayInputDate}'");
            strSQL.Append($"   AND A.TrayInputTime		= '{strTrayInputTime}'");

            if (strLotID.Length > 0) strSQL.Append($"   AND A.LotID				= '{strLotID}'");
            if (strModel.Length > 0) strSQL.Append($"   AND A.ProdModel			= '{strModel}'");
            //공정별 Work Index (현재는 항상 0)
            if (strProcWorkIndex.Length > 0) strSQL.Append($"   AND A.ProcWorkIndex			= '{strProcWorkIndex}'");

#if (DEBUG == FALSE)
					            if (strRouteID.Length > 0) strSQL.Append($"   AND A.RouteID			= '{strRouteID}'");
#endif

            strSQL.Append($" ORDER BY A.StartTime DESC");

            return strSQL.ToString();
        }
        #endregion

        #region [WinTrayManual EQP Check : 사용안함 Rest 대체]
        // 공정 변경 전 장비에 변경정보가 있는지 확인한다.
        private string QueryToWinTrayManualEQPCheck(string strTrayID, string strEqpTypeID, string strOperGroupID, string strOperID)
        {
            StringBuilder strSQL = new StringBuilder();
            // Set Query
            strSQL.Append(" SELECT A.trayid RetString");
            strSQL.Append("   FROM tMstEquipment      A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tTrayCurr B WITH (NOLOCK)");
            strSQL.Append("          ON A.TrayID      = A.TrayID");
            strSQL.Append("         AND B.eqptypeid   = A.eqptypeid");
            strSQL.Append($"  WHERE A.TrayID		   =  '{strTrayID}'");
            strSQL.Append($"    AND B.EqpTypeID        =  '{strEqpTypeID}'");
            strSQL.Append($"    AND B.OperGroupID      =  '{strOperGroupID}'");
            strSQL.Append($"    AND B.OperID           =  '{strOperID}'");
            strSQL.Append("    AND B.StartTime		IS NOT NULL");
            strSQL.Append("    AND B.EndTime			IS NULL");
            strSQL.Append("  ORDER BY A.eqptypeid ASC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToTemperature, 사용안함 Rest 대체]
        private string QueryToTemperature(List<string> lstVar)
        {
            if (lstVar.Count != 4) return "";

            StringBuilder strSQL = new StringBuilder();

            string strLineID = null;
            string strStartDate = null;
            string strEndDate = null;
            string strUnitID = null;
            string strPartStart = null;
            string strEndStart = null;
            string strOrderby = null;

            strLineID = lstVar[0];
            strStartDate = lstVar[1];
            strEndDate = lstVar[2];
            strUnitID = lstVar[3];
            strPartStart = strStartDate.Substring(3, 3);
            strEndStart = strEndDate.Substring(3, 3);
            strOrderby = lstVar[4];

            // Set Query
            strSQL.Append("SELECT B.UnitName, A.UnitID, A.TrayID ");
            strSQL.Append("     , (CASE ISNULL(A.EventTime, '') WHEN '' THEN A.EventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventTime ");
            strSQL.Append("     , A.JigTemp1, A.JigTemp2, A.JigTemp3, A.JigTemp4 ");
            strSQL.Append("     , A.JigTemp5, A.JigTemp6, A.JigTemp7, A.JigTemp8 ");
            strSQL.Append("     , A.JigTempAvg ");
            strSQL.Append("     , A.PowerTemp1, A.PowerTemp2, A.PowerTemp3, A.PowerTemp4 ");
            strSQL.Append("     , A.PowerTemp5, A.PowerTemp6, A.PowerTemp7, A.PowerTemp8 ");
            strSQL.Append("     , A.PowerTempAvg ");
            strSQL.Append("  FROM tUnitTemp A WITH (NOLOCK) ");
            strSQL.Append("      LEFT OUTER JOIN tmstEquipment B WITH (NOLOCK) ");
            strSQL.Append("        ON B.EqpTypeID	= A.EqpTypeID ");
            strSQL.Append("       AND B.UnitID    = A.UnitID ");
            strSQL.Append($" WHERE A.PartKey        BETWEEN '{strPartStart}' ");
            strSQL.Append($"                            AND '{strEndStart}' ");
            strSQL.Append($"   AND A.LineID               = '{strLineID}' ");
            strSQL.Append($"   AND A.EventTime      BETWEEN '{strStartDate}' ");
            strSQL.Append($"                            AND '{strEndDate}' ");

            if (strUnitID.Length > 0) strSQL.Append($"  AND A.UnitID             = '{strUnitID}' ");

            if (strOrderby == "ASC")
            {
                strSQL.Append(" ORDER BY A.EventTime ASC");
            }
            else
            {
                strSQL.Append(" ORDER BY A.EventTime DESC");
            }

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToTemperatureHPC, 사용안함 Rest 대체]
        private string QueryToTemperatureHPC(List<string> lstVar)
        {
            if (lstVar.Count != 5) return "";

            StringBuilder strSQL = new StringBuilder();
            string strLineID = lstVar[0];
            string strStartDate = lstVar[1];
            string strEndDate = lstVar[2];
            string strUnitID = lstVar[3];
            string strPartStart = strStartDate.Substring(3, 3);
            string strEndStart = strEndDate.Substring(3, 3);
            string strOrderby = lstVar[4];

            // Set Query
            strSQL.Append("SELECT B.UnitName, A.UnitID, A.TrayID ");
            strSQL.Append("     , (CASE ISNULL(A.EventTime, '') WHEN '' THEN A.EventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventTime ");
            strSQL.Append("     , A.JigTemp1,  A.JigTemp2,  A.JigTemp3,  A.JigTemp4,  A.JigTemp5");
            strSQL.Append("     , A.JigTemp6,  A.JigTemp7,  A.JigTemp8,  A.JigTemp9,  A.JigTemp10");
            strSQL.Append("     , A.JigTemp11, A.JigTemp12, A.JigTemp13, A.JigTemp14, A.JigTemp15");
            strSQL.Append("     , A.JigTemp16, A.JigTemp17, A.JigTemp18, A.JigTemp19, A.JigTemp20");
            strSQL.Append("     , A.JigTemp21, A.JigTemp22, A.JigTemp23, A.JigTemp24, A.JigTemp25");
            strSQL.Append("     , A.JigTemp26, A.JigTemp27, A.JigTemp28, A.JigTemp29, A.JigTemp30");
            strSQL.Append("     , A.JigTemp31, A.JigTemp32, A.JigTemp33, A.JigTemp34, A.JigTemp35");
            strSQL.Append("     , A.JigTemp36, A.JigTemp37, A.JigTemp38, A.JigTemp39, A.JigTemp40");
            strSQL.Append("     , A.JigTemp41, A.JigTemp42, A.JigTemp43, A.JigTemp44, A.JigTemp45");
            strSQL.Append("     , A.JigTemp46, A.JigTemp47, A.JigTemp48, A.JigTemp49, A.JigTemp50");
            strSQL.Append("     , A.JigTemp51, A.JigTemp52, A.JigTemp53, A.JigTemp54, A.JigTemp55");
            strSQL.Append("     , A.JigTemp56, A.Pressure");
            strSQL.Append("  FROM tUnitTempHPC A WITH (NOLOCK) ");
            strSQL.Append("      LEFT OUTER JOIN tmstEquipment B WITH (NOLOCK) ");
            strSQL.Append("        ON B.EqpTypeID	= A.EqpTypeID ");
            strSQL.Append("       AND B.UnitID    = A.UnitID ");
            strSQL.Append($" WHERE A.PartKey        BETWEEN '{strPartStart}' ");
            strSQL.Append($"                            AND '{strEndStart}' ");
            strSQL.Append($"   AND A.LineID               = '{strLineID}' ");
            strSQL.Append($"   AND A.EventTime      BETWEEN '{strStartDate}' ");
            strSQL.Append($"                            AND '{strEndDate}' ");

            if (strUnitID.Length > 0) strSQL.Append($"  AND A.UnitID             LIKE '{strUnitID + "%"}' ");

            if (strOrderby == "ASC")
            {
                strSQL.Append(" ORDER BY EventTime ASC");
            }
            else
            {
                strSQL.Append(" ORDER BY EventTime DESC");
            }

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToEqpStatusHis, 사용안함 Rest 대체]
        //Table
        //tEqpStatus     A
        //tMstOperation     B
        //Form
        //CtrlCellHistoryInfo
        //CtrlTrayCellHistoryInfo
        //WinCellMeasurements
        private string QueryToEqpStatusHis(string strLineID, string strEqpType
            , string strUnitID, string strEqpStatus, string strStartDate, string strEndDate)
        {
            StringBuilder strSQL = new StringBuilder();
            // Set Query
            strSQL.Append(" SELECT A.EqpTypeID,		A.UnitID,        A.StatusFlag,      A.Remark");
            strSQL.Append("      , (CASE ISNULL(A.EventTime, '') WHEN '' THEN A.EventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventTime");
            strSQL.Append("      , C.EqpTypeName,	D.UnitName");
            strSQL.Append("      , SUBSTRING(E.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(E.RackID, 2, 2))) + '-' + SUBSTRING(E.RackID, 4, 1) + 'Line-' + SUBSTRING(E.RackID, 5, 2) + 'Bay-' + SUBSTRING(E.RackID, 7, 2) + 'Rack' AS AgingUnitName");
            strSQL.Append("   FROM tEqpStatus A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tMstEqpGroup C WITH (NOLOCK)");
            strSQL.Append("          ON C.EqpTypeID  = A.EqpTypeID");
            strSQL.Append("        LEFT OUTER JOIN tMstEquipment D WITH (NOLOCK)");
            strSQL.Append("          ON D.EqpTypeID  = A.EqpTypeID");
            strSQL.Append("         AND D.UnitID   	= A.UnitID");
            strSQL.Append("        LEFT OUTER JOIN tMstAgingRack E WITH (NOLOCK)");
            strSQL.Append("          ON E.RackID     = A.UnitID");
            strSQL.Append($"  WHERE A.LineID	           = '{strLineID}'");
            strSQL.Append($"    AND A.EqpTypeID	           = '{strEqpType}'");

            if (strUnitID.Length > 0)
            {
                strSQL.Append($"    AND A.UnitID			= '{strUnitID}'");
            }

            if (strUnitID.Length > 0)
            {
                strSQL.Append($"    AND A.StatusFlag			LIKE '{strEqpStatus + "%"}'");
            }

            strSQL.Append($"    AND A.EventTime      BETWEEN '{strStartDate}'");
            strSQL.Append($"                             AND '{strEndDate}'");

            //strSQL.Append($"    AND C.EqpTypeName in ('Formation', 'OCV', 'Selector', 'IR/OCV', 'Grader')");
            strSQL.Append(" ORDER BY A.EventTime DESC ");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToAgingMarginal, 사용안함 Rest 대체]
        //Table
        //tMstAgingRack         A
        //tMstAgingRackSpec     B
        //Form
        //CtrlAgingMarginal
        private string QueryToAgingMarginal(string strLineID)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append(" SELECT A.AgingType, A.Hogi, SUM(CASE WHEN A.Status = 'F' THEN 1 ELSE 0 END) RackTrayCnt");
            strSQL.Append("      , B.Spec,      B.RackCnt");
            strSQL.Append("   FROM tMstAgingRack A WITH (NOLOCK)");
            strSQL.Append("     LEFT OUTER JOIN tMstAgingRackSpec B WITH (NOLOCK)");
            strSQL.Append("       ON B.LineID         = A.LineID");
            strSQL.Append("      AND B.AgingType      = A.AgingType");
            strSQL.Append("      AND B.Hogi           = A.Hogi");
            strSQL.Append($" WHERE A.LineID = {strLineID}");
            strSQL.Append("  GROUP BY A.AgingType, A.Hogi, B.Spec, B.RackCnt");
            strSQL.Append("  ORDER BY A.AgingType ASC, A.Hogi ASC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToProcMoni, 사용안함 Rest 대체]
        //Table
        //tMstRouteOper     A
        //tTrayCurr         B
        //Form
        //CtrlProcessMonitoring
        private string QueryToProcMoni(string strLineID, string strModel, string strRoute, string strLotID)
        {
            StringBuilder strSQL = new StringBuilder();
            // Set Query
            strSQL.Append("  SELECT A.EqpTypeID, A.OperGroupID, A.OperID");
            strSQL.Append("        , A.OperName, A.RowNumber, B.EndTime");
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='W' AND B.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_W");
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='W' AND B.NormalFlag IS NULL THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_W");
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='R' AND B.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_R");
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='R' AND B.NormalFlag IS NULL THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_R");

            //종료 대기?
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='E' AND B.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_E");
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='E' AND B.NormalFlag IS NULL THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_E");

            strSQL.Append(" 	    , SUM (CASE WHEN B.NormalFlag='T' THEN 1 ELSE 0 END) Status_T");
            strSQL.Append(" 	    , SUM (CASE WHEN B.NormalFlag='T' THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_T");
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='B' AND B.NormalFlag='N' THEN 1 ELSE 0 END) Status_B");
            strSQL.Append(" 	    , SUM (CASE WHEN B.Status='B' AND B.NormalFlag='N' THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_B");
            strSQL.Append("        , COUNT (TrayID) AS TotalTray");
            strSQL.Append("        , SUM (CASE WHEN CurrCellCnt > 0 THEN CurrCellCnt ELSE 0 END) AS TotalCell");
            strSQL.Append("     FROM tMstRouteOper AS A WITH(NOLOCK)");
            strSQL.Append("          LEFT OUTER JOIN tTrayCurr B WITH(NOLOCK)");
            strSQL.Append("            ON B.ProdModel		= A.ProdModel ");
            strSQL.Append("           AND B.EqpTypeID		= A.EqpTypeID ");
            strSQL.Append("           AND B.OperGroupID	    = A.OperGroupID ");
            strSQL.Append("           AND B.OperID			= A.OperID");
            strSQL.Append("           AND B.RouteID		    = A.RouteID");
            strSQL.Append("           AND B.Status			= 'R'");
            strSQL.Append($"          AND B.LineID			= '{strLineID}'");

            if (strLotID.Length > 0) strSQL.Append($"          AND B.LotID			= '{strLotID}'");

            strSQL.Append($"    WHERE A.ProdModel			= '{strModel}'");
            strSQL.Append($"      AND A.RouteID				= '{strRoute}'");
            strSQL.Append("      AND (A.EqpTypeID <> '0' AND A.OperGroupID <> '0' AND A.OperID <> '0')");
            //strSQL.Append("      AND B.EndTime				IS NULL");
            strSQL.Append("    GROUP BY A.EqpTypeID, A.OperGroupID, A.OperID, A.OperName, A.RowNumber, B.EndTime");
            strSQL.Append("    ORDER BY A.RowNumber ASC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToProcMoni, 사용안함 Rest 대체]
        private string QueryToLotMoni(string strLineID, string strStartTime, string strEndTime, string strStartDate, string strEndDate, string strModel, string strRoute)
        {
            StringBuilder strSQL = new StringBuilder();
            // Set Query
            strSQL.Append(" SELECT A.LotID, A.ProdModel, A.RouteID");
            strSQL.Append("      , SUM(CASE WHEN A.Status = 'W' AND A.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_W");
            strSQL.Append("      , SUM(CASE WHEN A.Status = 'W' AND A.NormalFlag IS NULL THEN A.CurrCellCnt ELSE 0 END) CurrCellCnt_W");
            strSQL.Append("      , SUM(CASE WHEN A.Status = 'R' AND A.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_R");
            strSQL.Append("      , SUM(CASE WHEN A.Status = 'R' AND A.NormalFlag IS NULL THEN A.CurrCellCnt ELSE 0 END) CurrCellCnt_R");
            strSQL.Append("      , SUM(CASE WHEN A.NormalFlag = 'T' THEN 1 ELSE 0 END) Status_T");
            strSQL.Append("      , SUM(CASE WHEN A.NormalFlag = 'T' THEN A.CurrCellCnt ELSE 0 END) CurrCellCnt_T");
            strSQL.Append("      , SUM(CASE WHEN A.Status = 'B' AND A.NormalFlag = 'N' THEN 1 ELSE 0 END) Status_B");
            strSQL.Append("      , SUM(CASE WHEN A.Status = 'B' AND A.NormalFlag = 'N' THEN A.CurrCellCnt ELSE 0 END) CurrCellCnt_B");
            strSQL.Append("      , COUNT(TrayID) AS TotalTray");
            strSQL.Append("      , SUM (CASE WHEN CurrCellCnt > 0 THEN CurrCellCnt ELSE 0 END) AS TotalCell");
            strSQL.Append("   FROM tTrayCurr A WITH(NOLOCK)");
            strSQL.Append("  WHERE LineID = '001'");
            strSQL.Append("    AND ProdModel = 'POUCH24'");
            strSQL.Append("  GROUP BY LotID, A.ProdModel, A.RouteID");
            strSQL.Append("  ORDER BY LotID ASC");
            return strSQL.ToString();

            //  SELECT A.LotID, A.ProdModel, A.RouteID
            //   , SUM(CASE WHEN B.Status = 'W' AND B.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_W
            //, SUM(CASE WHEN B.Status = 'W' AND B.NormalFlag IS NULL THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_W
            //, SUM(CASE WHEN B.Status = 'R' AND B.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_R
            //, SUM(CASE WHEN B.Status = 'R' AND B.NormalFlag IS NULL THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_R
            //, SUM(CASE WHEN B.Status = 'E' AND B.NormalFlag IS NULL THEN 1 ELSE 0 END) Status_E
            //, SUM(CASE WHEN B.Status = 'E' AND B.NormalFlag IS NULL THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_E
            //, SUM(CASE WHEN B.NormalFlag = 'T' THEN 1 ELSE 0 END) Status_T
            //, SUM(CASE WHEN B.NormalFlag = 'T' THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_T
            //, SUM(CASE WHEN B.Status = 'B' AND B.NormalFlag = 'N' THEN 1 ELSE 0 END) Status_B
            //, SUM(CASE WHEN B.Status = 'B' AND B.NormalFlag = 'N' THEN B.CurrCellCnt ELSE 0 END) CurrCellCnt_B
            //   FROM tTrayCurr A
            //    LEFT OUTER JOIN tTrayCurr B
            //    ON B.TrayID = A.TrayID
            //WHERE A.LineID = '001'
            //  AND A.ProdModel = 'POUCH24'
            //  AND A.RouteID = 'P101'
            //  AND(A.TrayInputDate       BETWEEN '20190100' AND '20190101'

            //  AND A.TrayInputTime       BETWEEN '000000'   AND '010000')
            //GROUP BY  A.LotID, A.ProdModel, A.RouteID;

        }
        #endregion

        #region [QueryToCellHisInfo, 사용안함]
        private string QueryToCellHisInfo(string strLineID, string strProcWorkIndex, string strCellID)
        {
            StringBuilder strSQL = new StringBuilder();
            // Set Query
            // Set Query
            strSQL.Append("");
            strSQL.Append(" SELECT A.CellID,		A.LineID,		 A.EqpTypeID");
            strSQL.Append("      , A.OperGroupID,   A.OperID,        A.ProcWorkIndex");
            strSQL.Append("      , A.Step,          A.Capacity,      A.AvgVoltage");
            strSQL.Append("      , A.EndVoltage,    A.EndCurrent,    A.ElectricEnergy");
            strSQL.Append("      , A.Temp,          A.TempValue,     A.CapacityTemp");
            strSQL.Append("      , A.Ocv,           A.DeltaOCV,      A.IR");
            strSQL.Append("      , A.DeltaIR,       A.StartVoltage,  A.ErrCode");
            strSQL.Append("      , A.BadCell,       A.TrayID,        A.CellNo");
            strSQL.Append("      , A.TrayInputDate, A.TrayInputTime, A.ObjectID");
            strSQL.Append("      , A.DataPath,      A.UpdateTime");
            strSQL.Append("      , B.ProdModel,     B.RouteID,       B.LotID");
            strSQL.Append("   FROM tCellProData A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tCellCurr B WITH (NOLOCK)");
            strSQL.Append("          ON B.CellID = A.CellID");

            strSQL.Append($" WHERE A.LineID          = '{strLineID}'");
            strSQL.Append($"   AND A.ProcWorkIndex   = '{strProcWorkIndex}'");
            strSQL.Append($"   AND A.CellID          = '{strCellID}'");
            strSQL.Append("ORDER BY A.TrayID ASC, A.CellID ASC, A.TrayInputDate ASC, A.TrayInputTime ASC");

            return strSQL.ToString();
        }
        #endregion

        #region [QueryToCellHisInfo, 사용안함]
        // 공정 별 작업 현황.
        private string QueryToCellHisInfo(string strLineID, string strProcWorkIndex, string strStartTime, string strStartDate
            , string strEndTime, string strEndDate
            , string strModel, string strRouteID, string strLotID)
        {
            StringBuilder strSQL = new StringBuilder();
            // Set Query
            // Set Query
            strSQL.Append("");
            strSQL.Append(" SELECT A.CellID,		A.LineID,		 A.EqpTypeID");
            strSQL.Append("      , A.OperGroupID,   A.OperID,        A.ProcWorkIndex");
            strSQL.Append("      , A.Step,          A.Capacity,      A.AvgVoltage");
            strSQL.Append("      , A.EndVoltage,    A.EndCurrent,    A.ElectricEnergy");
            strSQL.Append("      , A.Temp,          A.TempValue,     A.CapacityTemp");
            strSQL.Append("      , A.Ocv,           A.DeltaOCV,      A.IR");
            strSQL.Append("      , A.DeltaIR,       A.StartVoltage,  A.ErrCode");
            strSQL.Append("      , A.BadCell,       A.TrayID,        A.CellNo");
            strSQL.Append("      , A.TrayInputDate, A.TrayInputTime, A.ObjectID");
            strSQL.Append("      , A.DataPath,      A.UpdateTime");
            strSQL.Append("      , B.ProdModel,     B.RouteID,       B.LotID");
            strSQL.Append("   FROM tCellProData A WITH (NOLOCK)");
            strSQL.Append("        LEFT OUTER JOIN tCellCurr B WITH (NOLOCK)");
            strSQL.Append("          ON B.CellID = A.CellID");
            strSQL.Append($" WHERE A.LineID             = '{strLineID}'");
            strSQL.Append($"   AND A.ProcWorkIndex      = '{strProcWorkIndex}'");
            strSQL.Append($"   AND A.TrayInputDate BETWEEN '{strStartTime}'");
            strSQL.Append($"                           AND '{strEndTime}'");
            strSQL.Append($"   AND A.TrayInputTime BETWEEN '{strStartDate}'");
            strSQL.Append($"                           AND '{strEndDate}'");

            if (strModel.Length > 0) strSQL.Append($"   AND B.ProdModel           = '{strModel}'");
            if (strRouteID.Length > 0) strSQL.Append($"   AND B.RouteID           = '{strRouteID}'");
            if (strLotID.Length > 0) strSQL.Append($"   AND B.LotID           = '{strLotID}'");

            strSQL.Append("ORDER BY A.TrayID ASC, A.CellID ASC, A.TrayInputDate ASC, A.TrayInputTime ASC");

            return strSQL.ToString();
        }
        #endregion
    }
    #endregion
}
#endregion
