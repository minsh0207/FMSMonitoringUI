using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novasoft.Logger
{
    internal class LogData
    {
        private string _text;

        public string _LogFileName;

        public DateTime Time;
        public LogLevel Level;

        #region Constructor
        public LogData(LogLevel level, string logText)
        {
            this._text = logText;

            this.Time = DateTime.Now;
            this.Level = level;
        }

        public LogData(LogLevel level, string logText, string LogFileName)
        {
            this._text = logText;
            this._LogFileName = LogFileName;

            this.Time = DateTime.Now;
            this.Level = level;
        }

        public LogData(Exception ex)
        {
            this._text = string.Format("{0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);

            this.Time = DateTime.Now;
            this.Level = LogLevel.Error;
        }
        #endregion

        // Public Method
        #region GetLogText
        public string GetLogText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Time.ToString("[yyyy-MM-dd HH:mm:ss.fff] "));

            switch (this.Level)
            {
                case LogLevel.Information:
                    sb.Append("[INFO] ");
                    break;
                case LogLevel.Send:
                    sb.Append("[SEND] ");
                    break;
                case LogLevel.Write:
                    sb.Append("[WRIT] ");
                    break;
                case LogLevel.Receive:
                    sb.Append("[RECV] ");
                    break;
                case LogLevel.Read:
                    sb.Append("[READ] ");
                    break;
                case LogLevel.Warning:
                    sb.Append("[WARN] ");
                    break;
                case LogLevel.Error:
                    sb.Append("[EXCP] ");
                    break;
            }

                sb.AppendLine(this._text);
            
            return sb.ToString();
        }
        #endregion

        // Method
    }
}