using System;
namespace ScriptHub
{
    public interface ILogger
    {
        void LogToFile(string logName, string message);

        void LogStamp(string logName);
    }
}
