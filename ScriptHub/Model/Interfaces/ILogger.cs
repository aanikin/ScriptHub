using System;
namespace ScriptHub.Model.Interfaces
{
    public interface ILogger
    {
        void LogToFile(string logName, string message);

        void LogStamp(string logName);
    }
}
