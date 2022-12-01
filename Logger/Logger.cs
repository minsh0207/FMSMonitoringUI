using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novasoft.Logger
{
    public enum LogLevel
    {
        Info,
        Send,
        Write,
        Receive,
        Read,
        Warning,
        OPCUA,
        Error
    }

    public enum LogMode
    {
        None,
        Hour,
        Day
    }

    public class LogFileName
    {
        public const string Operation = "Operation";            //일반적 Operation 기록 파일..
        public const string ButtonClick = "ButtonClick";        //ButtonClick Log 기록 파일
        public const string TestLog = "TestLog";                //Test Log 파일...
        public const string DataException = "DBException";      //DB Exception 관련 기록 파일
        public const string AllLog = "AllLog";                  //모든 Log 기록 파일
        public const string OPCUA = "OPCUA";                    // OPCUA에 대한 기록 파일
        public const string ErrorLog = "ErrorLog";              //Error에 대한 모든 기록 파일
        public const string SqlLog = "SQL_LOG";                  //SQL 실행시 Log 기록
    }

    public class Logger : IDisposable
    {
        #region [Variables]
        private LogWriter _logger;
        #endregion

        public Logger(string logPath, LogMode logMode, LogLevel level = LogLevel.Info)
        {
            this._logger = new LogWriter(logPath, logMode, level);
        }

        public void Dispose()
        {
            this._logger.Dispose();
        }

        #region Write
        public void Write(string className, string methodName, Exception ex)
        {
            this._logger.Add(ex);
        }
        public void Write(Exception ex)
        {
            this._logger.Add(ex);
        }

        public void Write(LogLevel level, string logText, string strLogFileName)
        {
            //Operation FIle이 아닐 경우 Operation 파일에 추가
            if (strLogFileName == LogFileName.OPCUA)
            {
                this._logger.Add(level, logText, LogFileName.OPCUA);
                return;
            }

            if (strLogFileName != LogFileName.AllLog)
            {
                this._logger.Add(level, logText, LogFileName.AllLog);
            }

            //error 일 경우 error 로그에 쓰자
            if (level == LogLevel.Error)
            {
                this._logger.Add(level, logText, LogFileName.ErrorLog);
            }

            this._logger.Add(level, logText, strLogFileName);
        }
        #endregion

    }
}