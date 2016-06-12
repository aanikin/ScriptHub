using System;
using System.Diagnostics;

namespace ScriptHub.Model.Interfaces
{
    public interface IScriptRunner
    {
        event EventHandler Done;
        event EventHandler ErrorReceived;
        event DataReceivedEventHandler OutputDataReceived;
        void Run();
        void Stop();
    }
}
