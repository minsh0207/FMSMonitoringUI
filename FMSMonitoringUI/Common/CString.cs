/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//	Class Name		: CString
//  Description		: String
//  Create Data		: 2015.08.31
//  Author			: 석보원
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//===================================================================
using System;
using System.Globalization;

/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationSystem
//===================================================================
namespace MonitoringUI.Common
{
    #region [Class CString]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CString
    //===================================================================
    public class CString
    {
        public enum unitChangeType
        {
            valueToUpper,
            valueToLower
        }

        #region [Data From Code]
        /////////////////////////////////////////////////////////////////////
        //	문자열 "내용" + Space(100) + "코드"에서 Code 반환
        //===================================================================
        public string DataFromCode(string strString)
        {
            string sCode = "";

            try
            {
                if (strString.Length < 100)
                {
                    // 예외 발생
                    throw new Exception();
                }

                sCode = strString.Substring(100, strString.ToString().Length - 100).Trim();

                // Retrun
                return sCode;
            }

            // 예외처리
            catch (Exception)
            {
                // Retrun
                return sCode;
            }
        }
        #endregion

        #region [Data From Descr]
        /////////////////////////////////////////////////////////////////////
        //	문자열 "내용" + Space(100) + "코드"에서 Descr 반환
        //===================================================================
        public string DataFromDescr(string strString)
        {
            string sDescr = "";
            try
            {
				if (strString.Length < 100) return strString;
               
                sDescr = strString.Substring(0, 100).Trim();

                // Return
                return sDescr;
            }

            // 예외처리
            catch (Exception)
            {
                // Retrun
                return sDescr;
            }
        }
        #endregion

		#region [String To Date]
		/////////////////////////////////////////////////////////////////////
		//	날짜 문자(숫자) 데이터를, 날짜 표준 형식으로 변환
		//===================================================================
		public string StringToDate(string strData)
		{
			string strDateTime = "";

			try
			{
				strDateTime = strDateTime + strData.Substring(0, 4) + "-";
				strDateTime = strDateTime + strData.Substring(4, 2) + "-";
				strDateTime = strDateTime + strData.Substring(6, 2) + " ";

				// Data Check
				if (strDateTime.Length < 10)
				{
					strDateTime = "";
				}

				// Return
				return strDateTime;
			}

			// 예외처리
			catch (Exception)
			{
				// Retrun
				return "";
			}
		}
		#endregion

		#region [String To Time]
		/////////////////////////////////////////////////////////////////////
		//	날짜 문자(숫자) 데이터를, 시간 표준 형식으로 변환
		//===================================================================
		public string StringToTime(string strData)
		{
			string strDateTime = "";

			try
			{
				strDateTime = strDateTime + strData.Substring(0, 2) + ":";
				strDateTime = strDateTime + strData.Substring(2, 2) + ":";
				strDateTime = strDateTime + strData.Substring(4, 2);

				// Data Check
				if (strDateTime.Length < 6)
				{
					strDateTime = "";
				}

				// Return
				return strDateTime;
			}

			// 예외처리
			catch (Exception)
			{
				// Retrun
				return "";
			}
		}
		#endregion

        #region [String To Date Time]
        /////////////////////////////////////////////////////////////////////
        //	날짜 문자(숫자) 데이터를, 날짜 표준 형식으로 변환
        //===================================================================
        public string StringToDateTime(string strData)
        {
            string strDateTime = "";

            if (strData == null) return "";

            if (strData.Length < 14) return ""; 

            try
            {
                strDateTime = strDateTime + strData.Substring(0, 4) + "-";
                strDateTime = strDateTime + strData.Substring(4, 2) + "-";
                strDateTime = strDateTime + strData.Substring(6, 2) + " ";
                strDateTime = strDateTime + strData.Substring(8, 2) + ":";
                strDateTime = strDateTime + strData.Substring(10, 2) + ":";
                strDateTime = strDateTime + strData.Substring(12, 2);

				// Data Check
				if (strDateTime.Length < 18)
				{
					strDateTime = "";
				}

                // Return
                return strDateTime;
            }

            // 예외처리
            catch (Exception)
            {
                // Retrun
                return "";
            }
        }
        #endregion

		#region [Date To String]
		/////////////////////////////////////////////////////////////////////
		//	날짜 표준 형식을, 날짜 문자 데이터로 변환
		//===================================================================
		public string DateToString(string strData)
		{
			string strDateTime = "";

			try
			{
				strDateTime = strData.Replace("-", "").Trim();
				strDateTime = strDateTime.Replace(":", "").Trim();
				strDateTime = strDateTime.Replace(" ", "").Trim();

				// Return
				return strDateTime;
			}

			// 예외처리
			catch (Exception)
			{
				// Retrun
				return "";
			}
		}
		#endregion

		#region [Date Start Time]
		/////////////////////////////////////////////////////////////////////
		//	Date Start Time
		//===================================================================
		public string DateStartTime(DateTime dtpDate, int nFlag)
		{
			string strDateTime = "";

			try
			{
				switch (nFlag)
				{
					case 0:
						strDateTime = dtpDate.ToString("yyyy-MM-dd") + " 00:00:00";
						break;
					case 1:
						strDateTime = dtpDate.ToString("yyyyMMdd") + "000000";
						break;
                    case 2:
                        strDateTime = dtpDate.ToString("yyyyMMdd");
                        break;
                    case 3:
                        strDateTime = dtpDate.ToString("yyyyMMddHHmmss");
                        break;
                    case 4:
                        strDateTime = dtpDate.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }

				// Return
				return strDateTime;
			}

			// 예외처리
			catch (Exception)
			{
				// Retrun
				return "";
			}
		}
		#endregion

		#region [Date End Time]
		/////////////////////////////////////////////////////////////////////
		//	Date End Time
		//===================================================================
		public string DateEndTime(DateTime dtpDate, int nFlag)
		{
			string strDateTime = "";

			try
			{
				switch (nFlag)
				{
					case 0:
						strDateTime = dtpDate.ToString("yyyy-MM-dd").PadRight(1) + " 23:59:59";
						break;
					case 1:
						strDateTime = dtpDate.ToString("yyyyMMdd") + "235959";
						break;
                    case 2:
                        strDateTime = dtpDate.ToString("yyyyMMdd");
                        break;
                    case 3:
                        strDateTime = dtpDate.ToString("yyyyMMddHHmmss");
                        break;
                }

				// Return
				return strDateTime;
			}

			// 예외처리
			catch (Exception)
			{
				// Retrun
				return "";
			}
		}
        #endregion

        #region [Filter String ADD]
        /// <summary>
        /// Query ADD
        /// enTableWhere : WHERE, AND, LIKE, RLIKE, LLIKE, OR
        /// Query 문법 오류 를 최소하 하기 위해서..  
        /// </summary>
        /// <param name="strFilter"></param>
        /// <param name="strColumn"></param>
        /// <param name="strValue"></param>
        /// <param name="bAnd"></param>
        public string FilterStringADD(string strColumn, string strValue, enTableWhere enWhere, enTableWhereState enState)
        {
            string strFilter = "";

            try
            {
                switch (enWhere)
                {
                    case enTableWhere.WHERE:
                        strFilter += strColumn;
                        break;
                    //AND
                    case enTableWhere.AND:
                        strFilter += "AND " + strColumn;
                        break;
                    case enTableWhere.OR:
                        strFilter += "OR " + strColumn;
                        break;
                }

                switch (enState)
                {
                    case enTableWhereState.EQUALS:
                        strFilter += " = " + "'" + strValue + "'";
                        break;
                    case enTableWhereState.DIFF:
                        strFilter += " <> " + " '" + strValue + "' ";
                        break;
                    case enTableWhereState.LIKE:
                        strFilter += " LIKE '%" + strValue + "%' ";
                        break;
                    case enTableWhereState.LLIKE:
                        strFilter += " LIKE '%" + strValue + "' ";
                        break;
                    case enTableWhereState.RLIKE:
                        strFilter += " LIKE '" + strValue + "%' ";
                        break;
                    case enTableWhereState.GREATER://크다
                        strFilter += " > " + " '" + strValue + "' ";
                        break;
                    case enTableWhereState.LESS://작다
                        strFilter += " < " + " '" + strValue + "' ";
                        break;
                    case enTableWhereState.GREATER_EQUALS://크거나 같다
                        strFilter += " >= " + " '" + strValue + "' ";
                        break;
                    case enTableWhereState.LESS_EQUALS://작거나 같다
                        strFilter += " <= " + " '" + strValue + "' ";
                        break;
                    case enTableWhereState.IN:
                        strFilter += " in " + " (" + strValue + ") ";
                        break;
                    case enTableWhereState.BT:
                        strFilter += " BETWEEN " + " '" + strValue + "' ";
                        break;
                    case enTableWhereState.BT_AND:
                        strFilter = "AND '" + strValue + "' ";
                        break;
                    case enTableWhereState.IS_NULL:
                        strFilter += " IS NULL ";
                        break;
                    case enTableWhereState.IS_NOT_NULL:
                        strFilter += " IS NOT NULL ";
                        break;
                }

                return strFilter;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### Filter String ADD, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return "";
            }
        }
        #endregion

        #region [PartFilterADD]
        public string PartFilterADD(string strStart, string strEnd)
        {
            string strFilter = null;
            //문자열변경
            strStart = DateToString(strStart);
            strEnd = DateToString(strEnd);

            //Filter
            if (strStart.Substring(0, 8) == strEnd.Substring(0, 8))
            {
                strFilter += FilterStringADD("PartKey", strStart.Substring(0, 8), enTableWhere.WHERE, enTableWhereState.EQUALS);
            }
            else
            {
                strFilter += FilterStringADD("PartKey", strStart.Substring(0, 8), enTableWhere.WHERE, enTableWhereState.BT);
                strFilter += FilterStringADD("", strEnd.Substring(0, 8), enTableWhere.AND, enTableWhereState.BT_AND);
            }

            return strFilter;
        }
        #endregion

        #region [UP Date String]
        /// <summary>
        /// Column Name, Value (NVARCHAR 처리 완료)
        /// </summary>
        /// <param name="strColumn"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public string UPDateString(string strColumn, string strValue)
        {
            string strReturn = "";

            //NVarChar 의 경우 N 을 붙여야 한다.
            switch (strColumn.ToUpper())
            {
                case "PRODMODELDESC":
                case "EQPTYPENAME":
                case "OPERGROUPNAME":
                case "OPERNAME":
                case "OPERNAME_CN":
                case "ROUTENAME":
                case "UPDATEUSER":
                case "RECIPENAME":
                case "TROUBLENAME_KR":
                case "TROUBLENAME_EN":
                case "TROUBLENAME_CN":
                case "USERACTION_KR":
                case "USERACTION_EN":
                case "USERACTION_CN":
                case "CLASSNAME":
                case "USERID":
                case "USERNAME":
                case "PASSWORD":
                case "WINDOWNAME_KR":
                case "WINDOWNAME_EN":
                case "WINDOWNAME_CN":
                case "DESCR":
                case "UNITNAME":
                case "REMARK":
                case "DATAPATH":
                case "USERACTION":
                case "CMDID":
                case "USEREVENT":
                    strReturn = strColumn + " = " + "N'" + strValue + "',";
                    break;
                default:
                    strReturn = strColumn + " = " + "'" + strValue + "',";
                    break;
            }

            return strReturn;
        }
        #endregion

        #region [Null Ref ERROR, Return String]
        /// <summary>
        /// nullreferenceexception Check
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="strStr"></param>
        /// <returns></returns>
        public string NullToString(object obj, string strStr = "")
        {
            if(obj == null)
                return strStr;
            else if(obj.ToString().Length < 1)
                return strStr;
            else
                return obj.ToString();
        }
        #endregion

        #region [Get Aging Rack Status Name]
        /////////////////////////////////////////////////////////////////////
        //	Get Unit Statis Name
        //===================================================================
        public string GetAgingRackStatusName(string strStatusCode)
        {
            // Variable
            string strStatusName = "";

            try
            {
                // Status Name Setting
                switch (strStatusCode)
                {
                    case "E":
                        strStatusName = "Empty";
                        break;
                    case "B":
                        strStatusName = "Rack Bad";
                        break;
                    case "R":
                        strStatusName = "Reserve";
                        break;
                    case "F":
                        strStatusName = "Full";
                        break;
                    case "U":
                        strStatusName = "Unload Request";
                        break;
                    case "X":
                        strStatusName = "Prohibit Wearing";
                        break;
                    case "T":
                        strStatusName = "Trouble";
                        break;
                    case "W":
                        strStatusName = "Fire Water";
                        break;
                    case "D":
                        strStatusName = "Duplication";
                        break;
                    case "N":
                        strStatusName = "Empty Be Release";
                        break;
                    case "1":
                        strStatusName = "Loading";
                        break;
                    case "2":
                        strStatusName = "Unloading";
                        break;
                    default:
                        strStatusName = strStatusCode;
                        break;
                }

                // Return
                return strStatusName;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Aging Rack Status Name Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "GetAgingRackStatusName Error Exception : " + ex.Message);

                // Return
                return "";
            }
        }
        #endregion

        #region [Get Unit Status Name]
        /////////////////////////////////////////////////////////////////////
        //	Get Unit Status Name
        //===================================================================
        public string GetUnitStatusName(string strStatusCode)
        {
            // Variable
            string strStatusName = "";

            try
            {
                // Status Name Setting
                switch (strStatusCode)
                {
                    case "P":
                        strStatusName = "Power On";
                        break;
                    case "O":
                        strStatusName = "Power Off";
                        break;
                    case "M":
                        strStatusName = "Maintrance";
                        break;
                    case "R":
                        strStatusName = "Run";
                        break;
                    case "I":
                        strStatusName = "Idle";
                        break;
                    case "T":
                        strStatusName = "Trouble";
                        break;
                    case "S":
                        strStatusName = "Pause";
                        break;
                    case "N":
                        strStatusName = "Manual";
                        break;
                    case "A":
                        strStatusName = "Abnomal";
                        break;
                    case "D":
                        strStatusName = "Disconnect";
                        break;
                    case "F":
                        strStatusName = "Fire";
                        break;
                    case "W":
                        strStatusName = "Fire Water";
                        break;
                    default:
                        strStatusName = strStatusCode;
                        break;
                }

                // Return
                return strStatusName;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Unit Status Name Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "GetUnitStatusName Error Exception : " + ex.Message);

                // Return
                return "";
            }
        }
        #endregion

        #region [Recipe OVC String Format]
        public string GetRecipeFormat(string strData)
        {
            if (strData.Length < 1) return "";

            return strData.Substring(0, strData.Length - 1) + "." + strData.Substring(strData.Length - 1, 1); ;
        }
        #endregion

        #region [MeasTypeeNumToType]
        /// <summary>
        /// 측정 nNum 에 따른 Type String 반환
        /// </summary>
        /// <param name="eNum"></param>
        /// <returns></returns>
        public string MeasTypeeNumToType(enMeasType eNum)
        {
            string strType = "";

            switch (eNum)
            {
                case enMeasType.Voltage:
                    strType = "V";
                    break;
                case enMeasType.Current:
                    strType = "I";
                    break;
                case enMeasType.Capacity:
                    strType = "C";
                    break;
                case enMeasType.End_Voltage:
                    strType = "E";
                    break;
                case enMeasType.Electric_Energy:
                    strType = "W";
                    break;
                case enMeasType.IR:
                    strType = "R";
                    break;
                case enMeasType.OCV:
                    strType = "O";
                    break;
                case enMeasType.ΔOCV:
                    strType = "K";
                    break;
                case enMeasType.ΔAVG:
                    strType = "A";
                    break;
                case enMeasType.ΔMED:
                    strType = "M";
                    break;
                case enMeasType.ΔIRAVG:
                    strType = "G";
                    break;
            }
            return strType;
        }
        #endregion

        #region [MeasTypeNumToString]
        /// <summary>
        /// 측정 nNum 에 따른 측정 String 반환
        /// </summary>
        /// <param name="eNum"></param>
        /// <param name="bUnit"></param>
        /// <returns></returns>
        public string MeasTypeNumToString(enMeasType eNum, bool bUnit = true)
        {
            string strType = "";

            switch (eNum)
            {
                case enMeasType.Voltage:
                    if (bUnit) strType = enMeasType.Voltage.ToString() + "(mV)";
                    //if (bUnit) strType = enMeasType.Voltage.ToString() + "(V)";
                    else strType = enMeasType.Voltage.ToString();
                    break;
                case enMeasType.Start_Voltage:
                    if (bUnit) strType = enMeasType.Start_Voltage.ToString().Replace("_", " ") + "(mV)";
                    //if (bUnit) strType = enMeasType.Start_Voltage.ToString().Replace("_", " ") + "(V)";
                    else strType = enMeasType.Start_Voltage.ToString().Replace("_", " ");
                    break;
                case enMeasType.Avg_Voltage:
                    if (bUnit) strType = enMeasType.Avg_Voltage.ToString().Replace("_", " ") + "(mV)";
                    //if (bUnit) strType = enMeasType.Avg_Voltage.ToString().Replace("_", " ") + "(V)";
                    else strType = enMeasType.Avg_Voltage.ToString().Replace("_", " ");
                    break;
                case enMeasType.Current:
                    if (bUnit) strType = enMeasType.Current.ToString() + "(mA)";
                    //if (bUnit) strType = enMeasType.Current.ToString() + "(A)";
                    else strType = enMeasType.Current.ToString();
                    break;
                case enMeasType.End_Current:
                    if (bUnit) strType = enMeasType.End_Current.ToString() + "(mA)";
                    //if (bUnit) strType = enMeasType.End_Current.ToString().Replace("_", " ") + "(A)";
                    else strType = enMeasType.End_Current.ToString().Replace("_", " ");
                    break;
                case enMeasType.Capacity:
                    if (bUnit) strType = enMeasType.Capacity.ToString() + "(mAH)";
                    //if (bUnit) strType = enMeasType.Capacity.ToString() + "(Ah)";
                    else strType = enMeasType.Capacity.ToString();
                    break;
                case enMeasType.End_Voltage:
                    if (bUnit) strType = enMeasType.End_Voltage.ToString().Replace("_", " ") + "(mV)";
                    //if (bUnit) strType = enMeasType.End_Voltage.ToString().Replace("_", " ") + "(V)";
                    else strType = enMeasType.End_Voltage.ToString().Replace("_", " ");
                    break;
                case enMeasType.Electric_Energy:
                    if (bUnit) strType = enMeasType.Electric_Energy.ToString().Replace("_", " ") + "(mWh)";
                    //if (bUnit) strType = enMeasType.Electric_Energy.ToString().Replace("_", " ") + "(Wh)";
                    else strType = enMeasType.Electric_Energy.ToString().Replace("_", " ");
                    break;
                case enMeasType.IR:
                    if (bUnit) strType = enMeasType.IR.ToString() + "(mΩ)";
                    //if (bUnit) strType = enMeasType.IR.ToString() + "(Ω)";
                    else strType = enMeasType.IR.ToString();
                    break;
                case enMeasType.ΔIR:
                    if (bUnit) strType = enMeasType.ΔIR.ToString() + "(mΩ)";
                    //if (bUnit) strType = enMeasType.ΔIR.ToString() + "(Ω)";
                    else strType = enMeasType.ΔIR.ToString();
                    break;
                case enMeasType.OCV:
                    if (bUnit) strType = enMeasType.OCV.ToString() + "(mV)";
                    //if (bUnit) strType = enMeasType.OCV.ToString() + "(V)";
                    else strType = enMeasType.OCV.ToString();
                    break;
                case enMeasType.ΔOCV:
                    if (bUnit) strType = enMeasType.ΔOCV.ToString() + "(mV)";
                    else strType = "K";
                    break;

                case enMeasType.ΔK:
                    if (bUnit) strType = enMeasType.ΔK.ToString() + "(mV/h)";
                    else strType = "K";
                    break;

                case enMeasType.ΔAVG:
                    if (bUnit) strType = enMeasType.ΔAVG.ToString();
                    else strType = "A";
                    break;
                case enMeasType.ΔMED:
                    if (bUnit) strType = enMeasType.ΔMED.ToString();
                    else strType = "M";
                    break;
                case enMeasType.ΔIRAVG:
                    if (bUnit) strType = enMeasType.ΔIRAVG.ToString();
                    else strType = "G";
                    break;
            }
            return strType;
        }
        #endregion

        #region [Get Grade Description Data]
        /////////////////////////////////////////////////////////////////////
        //	Get Grade Description Data
        //===================================================================
        public string GetGradeDescrData(string strGrade, ref string strJudgeGrade)
        {
            // Variable
            string strData = "";

            try
            {
                // 측정 유형
                switch (strGrade)
                {
                    case "1":
                        strData = "Selector #1 NG"; strJudgeGrade = "H";
                        break;
                    case "2":
                        strData = "Selector #2 NG"; strJudgeGrade = "H";
                        break;
                    case "T":
                        strData = "Bad Cell"; strJudgeGrade = "H";
                        break;
                    case "K":
                        strData = "ΔOCV NG"; strJudgeGrade = "H";
                        break;
                    case "N":
                        strData = "None Cell"; strJudgeGrade = "H";
                        break;
                    case "X":
                        strData = "No Input Cell"; strJudgeGrade = "H";
                        break;
                    case "M":
                        strData = "Manual Out Cell"; strJudgeGrade = "H";
                        break;
                    default:
                        strData = "";
                        break;
                }

                // Return
                return strData;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Meas Type Data Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "GetMeasTypeData Error Exception : " + ex.Message);

                // Return
                return "";
            }
        }
        #endregion

        #region [GetAgingString]
        public string GetAgingString(string strRackID)
        {
            //H01 1 01 01 H1-1Line - 01Bay - 01Rack
            //고온/상온(1:R/H) + Hogi(2) + Line(1:1~4) + Bay(2) + Rack(2)

            // Variable
            string strData = "";
            int nHogi = -1;

            

            if (strRackID.Length < 8) return "";

            // LineID는 붙는것으로 고려해야 한다.
            if (strRackID.Length == 11)
                strRackID = strRackID.Substring(3);

                ////고온/상온(1:R/H)
            strData += strRackID.Substring(0, 1);

            //Hogi(2)
            if (int.TryParse(strRackID.Substring(1, 2), out nHogi) == true)
            {
                strData += nHogi.ToString();
            }
            else
            {
                return "";
            }

            strData += "-";

            //Line(1:1~4)
            strData += strRackID.Substring(3, 1);
            strData += "Line-";

            //Bay(2)
            strData += strRackID.Substring(4, 2);
            strData += "Bay-";

            //Rack(2)
            strData += strRackID.Substring(6, 2);
            strData += "Rack";

            return strData;
        }
        #endregion

        #region [GetData, Cell 측정정보 확인.]
        // 해당 Eqp Type ID 추가시
        // CtrlCellHistoryInfo
        // CtrlTrayCellHistoryInfo
        // WinCellMeasurements
        public bool GetCellDataFlag(string strEqpType)
        {
            bool bData = false;

            switch (strEqpType)
            {
                //20190327 KJY - StartTray/Packing

                case "A":   // Assembly 20190509 추가
                case "1":  // Formation
                case "7":  // IR/OCV
                case "R":  // DCIR
                case "H":  // HPC
                case "4":  // Degas
                //20200428 KJY Aging 추가
                case "3":  // RT/HT Aging
                    bData = true;
                    break;

                //20190327 KJY - StartTray/Packing 포함해서 나머지 다.
                default:
                    bData = false;
                    break;
            }

            return bData;
        }
        #endregion


        #region [Change Unit]
        /// <summary>
        /// 숫자타입의 Sring 변수의 단위 변환
        /// </summary>
        /// <param name="strData">숫자타입의 string</param>
        /// <param name="changeType">변환 방향:ToLower(V -> mV), ToUpper(mV -> V)</param>
        /// <param name="decimalPoint">소수 표기 자리수</param>
        /// <returns></returns>
        public string SetChangeUnit(string strData, unitChangeType changeType, int decimalPoint = 0)
        {
            string strReturnValue = "";     
            decimal decimalValue = 0.000m;
            NumberFormatInfo setPrecision = new NumberFormatInfo();
            setPrecision.NumberDecimalDigits = decimalPoint;

            if (!string.IsNullOrEmpty(strData))
            {
                try
                {
                    switch (changeType)
                    {
                        case unitChangeType.valueToLower:   // 큰단위에서 작은단위로 변경 : ex) V -> mV, A -> mA
                            decimalValue = Convert.ToDecimal(strData) * 1000.0m;
                            break;
                        case unitChangeType.valueToUpper:   // 작은단위에서 큰단위로 변경 : ex) mV -> V, mA -> A
                            decimalValue = Convert.ToDecimal(strData) / 1000.0m;
                            break;
                    }
                    
                }
                catch (Exception ex)
                {
                    CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, $"SetChangeUnit Error Exception : value[{strData}], ErrMsg[{ex.Message}]");
                }
            }

            strReturnValue = decimalValue.ToString("F", setPrecision);

            return strReturnValue;
        }
        #endregion

        public string GetTemperatureValue(string strTemp, int pointPos) // 소숫점이 어디 붙느냐.... 오른쪽에서 시작   12.3 이면 pointPos는 1
        {
            float TempValue = (float)(float.Parse(strTemp)/(10*pointPos));
            //string strFloatStr = TempValue.ToString("F");
            string strFloatStr = TempValue.ToString();

            return strFloatStr;
        }



        //20191205 KJY - for 실처리 Formating
        public string GetDecimalStr(string strValue, int RoundPoint)
        {
            if (strValue.Length < 1) return strValue;
            if (RoundPoint < 0 || RoundPoint > 28) return strValue;

            // 입력값이 Decimal인지 확인
            decimal dValue = 0;
            if (decimal.TryParse(strValue, out dValue) == false)
            {
                return strValue;
            }

            return decimal.Round(dValue, RoundPoint).ToString();
        }

    }
    #endregion
}
