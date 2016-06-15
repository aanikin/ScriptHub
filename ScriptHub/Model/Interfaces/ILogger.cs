using System;
namespace ScriptHub.Model.Interfaces
{
    public interface ILogger
    {
        void LogToFile(string logName, string message);

        void LogStart(string logName);
        void LogFinish(string logName, string Message);
    }
}
