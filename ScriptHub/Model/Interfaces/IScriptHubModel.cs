using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ScriptHub.Model.Interfaces
{
    public interface IScriptHubModel
    {
        List<Script> GetScripts();
        Script GetScript(int index);
        bool AddScript(Script script);
        bool UpdateScript(int index, Script script);


        void AddError(string newError);
        void ClearErrors();
        int ErrorsCount { get; }
        string GetError(int index);

        void StopScript();
        void StartScript(int scriptIndex);

        event EventHandler ScriptFinished;
        event EventHandler ErrorReceived;
        event DataReceivedEventHandler OutputDataReceived;

        void OpenInISE(int scriptIndex);
    }
}
