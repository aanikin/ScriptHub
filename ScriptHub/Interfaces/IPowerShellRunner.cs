using System;
namespace ScriptHub
{
    public interface IScriptRunner
    {
        event EventHandler Done;
        event EventHandler ErrorReceived;
        event System.Diagnostics.DataReceivedEventHandler OutputDataReceived;
        int PID { get; }
        void RunScript();
        void Kill();
    }
}
