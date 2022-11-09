using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Novasoft.Logger
{
    public sealed class LogWriter : IDisposable
    {
        private const int THREAD_SLEEP_INTERVAL_START = 500;
        private const int THREAD_SLEEP_INTERVAL_WRITE = 10;

        private Queue<LogData> _que;
        private LogMode _logMode;
        private LogLevel _level;
        private string _rootPath;

        private bool _threadFlag;

        #region Constructor
        public LogWriter(string logPath, LogMode logMode, LogLevel level = LogLevel.Information)
        {
            this._que = new Queue<LogData>();

            this._rootPath = logPath;
            this._level = level;
            this._logMode = logMode;

            if (this._logMode != LogMode.None)
            {
                System.Threading.Thread th = new System.Threading.Thread(Run);
                th.IsBackground = true;

                th.Name = "LogWriter";
                th.Priority = System.Threading.ThreadPriority.BelowNormal;

                this._threadFlag = true;

                th.Start();
            }
        }
        #endregion

        // Public Method
        #region Add
        public void Add(LogLevel level, string logText, string LogFIleName)
        {
            lock (this._que)
            {
                if (this._logMode != LogMode.None && this._level <= level)
                    this._que.Enqueue(new LogData(level, logText, LogFIleName));
            }
        }

        public void Add(Exception ex)
        {
            lock (this._que)
            {
                if (this._logMode != LogMode.None && this._level <= LogLevel.Error)
                    this._que.Enqueue(new LogData(ex));
            }
        }
        #endregion
        #region Dispose
        public void Dispose()
        {
#if DEBUG_TRACE
            DateTime startTime = DateTime.Now;
#endif
            try
            {
                this._threadFlag = false;

                lock (this._que)
                {
                    this._que.Clear();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
            }
#if DEBUG_TRACE
            DebugFunctions.PrintMethodInfo(this, startTime, new System.Diagnostics.StackFrame());
#endif
        }
        #endregion

        // Method
        #region Run
        private void Run()
        {
            System.Threading.Thread.Sleep(THREAD_SLEEP_INTERVAL_START);
            LogData logData;

            while (this._threadFlag)
            {
                try
                {
                    if (this._que.Count > 0)
                    {
                        lock (this._que)
                        {
                            logData = this._que.Dequeue();
                        }

                        if (logData.Level >= this._level)
                        {
                            Write(logData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print(string.Format("### Log Write Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                }
                finally
                {
                    System.Threading.Thread.Sleep(THREAD_SLEEP_INTERVAL_WRITE);
                }
            }
        }
        #endregion
        #region GetFileName
        private string GetFileName(LogData logData)
        {
            if (this._logMode == LogMode.Hour)
            {
//                 return string.Format("{0}({1:00}).log", logData.Time.ToString("yyyy-MM-dd"), logData.Time.Hour);
                return string.Format("{2}({0})({1:00}).log", logData.Time.ToString("yyyy-MM-dd"), logData.Time.Hour,logData._LogFileName);    //Log 파일명 변경

            }
            else
            {
//                 return string.Format("{0}.log", logData.Time.ToString("yyyy-MM-dd"));
                return string.Format("{1}({0}).log", logData.Time.ToString("yyyy-MM-dd"), logData._LogFileName);                               //Log 파일명 변경

            }
        }
        #endregion
        #region Write
        private void Write(LogData logData)
        {
            string directory;
            string fileName;
            string logText;

            try
            {
                directory = string.Format(@"{0}\{1}", this._rootPath, logData.Time.ToString("yyyy-MM-dd"));

                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                fileName = GetFileName(logData);

                if (File.Exists(string.Format(@"{0}\{1}", directory, fileName)) == false)
                {
                }

                logText = logData.GetLogText();

                using (StreamWriter sw = new StreamWriter(string.Format(@"{0}\{1}", directory, fileName), true, Encoding.Default))
                {
                    sw.Write(logText);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### Log Write Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion
    }
}