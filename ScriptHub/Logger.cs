using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptHub
{
    public class Logger : ILogger
    {
        string _logsFolder;

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

      

        public void LogStamp(string logName)
        {
            var message = "--------------------------------------------------------------------------------------------------\r\n";
            message += "EXECUTED by " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + " at " + DateTime.Now + "---\r\n";

            WriteToLog(logName, message);
        }

        private void WriteToLog(string logName, string message)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(_logsFolder + logName + ".log", true))
            {
                file.WriteLine(message);
            }
        }
    }
}
