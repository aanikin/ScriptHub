using ScriptHub.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptHub.Model
{
    public class Logger : ILogger
    {
        string _logsFolder;
        Object _loggerLock = new Object();

        public Logger(string logsFolder)
        {
            if (!Directory.Exists(logsFolder))
            {
                Directory.CreateDirectory(logsFolder);
            }
            _logsFolder = logsFolder;
        }

        public void LogToFile(string logName, string message)
        {
            WriteToLog(logName, message);
        }

      

        public void LogStart(string logName)
        {
            var message = "--------------------------------------------------------------------------------------------------\r\n";
            message += "--- EXECUTED by " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + " at " + DateTime.Now + "\r\n";

            WriteToLog(logName, message);
        }

        public void LogFinish(string logName, string Message)
        {
            var message = "--- " + Message.ToUpper() +"\r\n";

            WriteToLog(logName, message);
        }

        private void WriteToLog(string logName, string message)
        {
            lock (_loggerLock)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(_logsFolder + logName + ".log", true))
                {
                    file.WriteLine(message);
                }
            }
        }
    }
}
