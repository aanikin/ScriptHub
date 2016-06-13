using System;
using System.Diagnostics;

namespace ScriptHub.Model.Interfaces
{
    public interface IScriptRunner : IDisposable
    {
        event EventHandler Done;
        event EventHandler ErrorReceived;
        event DataReceivedEventHandler OutputDataReceived;
        void RunScript();
        void StopScript();
    }
}
