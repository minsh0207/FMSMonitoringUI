/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//	Class Name		: CLogger
//  Description		: Logger
//  Create Data		: 2016.04.20
//  Author			: 석보원
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//===================================================================
using System;
using System.Text;
using System.IO;


/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationSchPC
//===================================================================
namespace MonitoringUI.Common
{
	#region [Class Logger]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CLogger
	//===================================================================
	public static class CLogger
	{
        #region [Write Log]
        /////////////////////////////////////////////////////////////////////
        //	Write Log
        //===================================================================
        public static void WriteLog(enLogLevel enLevel, string strWindowName, string strLogDescr)
        {
            // Variable
            string strDirectory;
            string strFilePath;
            string strFileName;
            DateTime logTime = DateTime.Now;

            try
            {
                // File Name
                strWindowName = strWindowName.Replace("FMSMonitoringUI.", "").Trim();
                //strFileName = string.Format("{0}{1}{2}", strWindowName, DateTime.Now.ToString("yyyy-MM-dd hh"), "H");
                strFileName = string.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd"), strWindowName);

                // Directory Check
                //strDirectory = CDefine.DEF_LOG_PATH + string.Format(@"{0}\{1}\{2}\{3}",
                //    CDefine.DEF_LOG_FILENAME, logTime.Date.ToString("yyyy"), logTime.Date.ToString("MM"), logTime.Date.ToString("dd"));

                strDirectory = CDefine.DEF_LOG_PATH + string.Format(@"{0}-{1}-{2}",
                    logTime.Date.ToString("yyyy"), logTime.Date.ToString("MM"), logTime.Date.ToString("dd"));

                if (Directory.Exists(strDirectory) == false)
                {
                    // 디렉토리 생성
                    Directory.CreateDirectory(strDirectory);
                }

                // File Check
                strFilePath = string.Format(@"{0}\{1}", strDirectory, logTime.ToString("[yyyy-MM-dd] ") + CDefine.DEF_LOG_FILENAME + ".csv");
                if (File.Exists(strFilePath) == false)
                {
                    //File.Create(sFilePath);
                }

                // Log Write
                // 두번째 인자 True = 파일 이어쓰기, False = 파일 덮어쓰기
                using (StreamWriter sw = new StreamWriter(strFilePath, true, Encoding.Unicode))
                {
                    string log;

                    if (strLogDescr == "")
                        log = "\r\n";
                    else
                        log = string.Format("{0}\t[{1}]\t{2}\t{3}", logTime.ToString("[yyyy-MM-dd HH:mm:ss.fff]"), enLevel.ToString(), strWindowName, strLogDescr);
                        //log = $"{enLevel},[{logTime:[yyyy-MM-dd HH:mm:ss.fff]}],{strWindowName},{strLogDescr}";

                    sw.WriteLine(log);

                    sw.Close();
                }

                // Log Delete
                LogDelete(strWindowName, logTime);
            }
            catch (Exception ex)
            {
                // System Degug
                System.Diagnostics.Debug.Print(string.Format("### Log Write Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }

        }
        public static void WriteLog(enLogLevel enLevel, DateTime dtLogTime, string strWindowName, string strLoginID, string strLogDescr)
		{
			// Variable
			string strDirectory = "";
			string strFilePath = "";
            string strFileName = "";

			try
			{
				// File Name
				strWindowName = strWindowName.Replace("FormationSystem.", "").Trim();
                strFileName = "[" + string.Format("{0}{1}{2}", dtLogTime.Date.ToString("yyyy"), dtLogTime.Date.ToString("MM"), dtLogTime.Date.ToString("dd")) + "] " + strWindowName;

				// Directory Check
				//strDirectory = CDefine.DEF_LOG_PATH + @"\" + strFileName + @"\" + string.Format(@"{0}\{1}\{2}", dtLogTime.Date.ToString("yyyy"), dtLogTime.Date.ToString("MM"), dtLogTime.Date.ToString("dd"));
                strDirectory = CDefine.DEF_LOG_PATH + string.Format(@"{0}\{1}\{2}\{3}", CDefine.DEF_LOG_FILENAME, dtLogTime.Date.ToString("yyyy"), dtLogTime.Date.ToString("MM"), dtLogTime.Date.ToString("dd"));
				if (Directory.Exists(strDirectory) == false)
				{
					// 디렉토리 생성
					Directory.CreateDirectory(strDirectory);
				}

				// File Check
                strFilePath = string.Format(@"{0}\{1}", strDirectory, dtLogTime.ToString("[yyyyMMdd] ") + CDefine.DEF_LOG_FILENAME + ".csv");
				if (File.Exists(strFilePath) == false)
				{
					//File.Create(sFilePath);
				}

				// Log Write
				// 두번째 인자 True = 파일 이어쓰기, False = 파일 덮어쓰기
				using (StreamWriter sw = new StreamWriter(strFilePath, true, Encoding.Unicode))
				{
                    //sw.WriteLine(dtLogTime.ToString("[HH:mm:ss.fff] ") + "\t" + "[" + enLevel.ToString() + "]" + "\t" + strWindowName + "\t" + strLoginID + "\t" + strLogDescr, "\t");
                    sw.WriteLine(dtLogTime.ToString("[HH:mm:ss.fff] ") + "\t" + "[" + enLevel.ToString() + "]" + "\t" + strWindowName + "\t" + strLoginID + "\t" + strLogDescr + "\t");
                    sw.Close();
				}

				// Log Delete
				LogDelete(strWindowName, dtLogTime);
			}
			catch (Exception ex)
			{
				// System Degug
				System.Diagnostics.Debug.Print(string.Format("### Log Write Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

				// Log Write
				//WriteLog(enLogLevel.ERROR, DateTime.Now, strFileName, "LOGGER", "[Log Write Error] " + strLogDescr + ex.Message);
			}

		}
		#endregion

        #region [Log Delete]
        /////////////////////////////////////////////////////////////////////
        //	Log Delete
        //===================================================================
        public static void LogDelete(string strFileName, DateTime dtLogTime)
        {
            try
            {
                // 1개월 이전 Date 설정
                int nCnt = 0;
                DateTime dtTime = dtLogTime.AddMonths(-1);
                string sYear = dtTime.Date.ToString("yyyy");
                string sMonth = dtTime.Date.ToString("MM");
                //string sDirPath = CDefine.DEF_LOG_PATH + CDefine.m_strMainWindowName + @"\" + strFileName + @"\" + sYear + @"\" + sMonth;
                string sDirPath = CDefine.DEF_LOG_PATH + CDefine.DEF_LOG_FILENAME + @"\" + sYear + @"\" + sMonth;
                int nLastDay = DateTime.DaysInMonth(dtLogTime.AddMonths(-1).Year, dtLogTime.AddMonths(-1).Month);
                //string sDirPath = CDefine.DEF_LOG_PATH + strFileName + @"\" + sYear;

                // 디렉토리 체크
                if (Directory.Exists(sDirPath) == false) return;

                // 1개월 이전 데이터 삭제
                DirectoryInfo dirInfo = new DirectoryInfo(sDirPath);
                foreach (DirectoryInfo dt in dirInfo.GetDirectories())
                {
                    // Cnt 
                    nCnt++;

                    if (dt.CreationTime.Day <= dtLogTime.AddDays(-nLastDay).Day)
                    {
                        dt.Delete(true);
                    }
                }

                // 폴더삭제
                if (Directory.Exists(sDirPath) == true)
                {
                    if (nCnt < 1)
                    {
                        Directory.Delete(sDirPath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                // System Degug
                System.Diagnostics.Debug.Print(string.Format("### Log Delete Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Log Write
                WriteLog(enLogLevel.Error, DateTime.Now, strFileName, "LOGGER", "[Log Delete Error] " + dtLogTime.ToString("[yyyy-MM-dd HH:mm:ss]"));
            }
        }
        #endregion

        public static void Info(Enum type, string msg)
        {
            //log.Info(type.ToString().Trim().ToUpper() + "," + msg);
        }

        public static void Warn(Enum type, string msg)
        {
            //log.Warn(type.ToString().ToUpper() + "," + msg);

        }

        public static void Debug(Enum type, string msg)
        {
            //log.Debug(type.ToString().ToUpper() + "," + msg);
        }

        public static void Error(Enum type, string msg)
        {
            //log.Error(type.ToString().ToUpper() + "," + msg);
        }
    }
	#endregion
}
