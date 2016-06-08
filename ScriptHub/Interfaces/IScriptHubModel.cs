using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ScriptHub
{
    public interface IScriptHubModel
    {
        List<Script> GetScripts();
        Script GetScript(int index);
        void AddScript(Script script);
        void UpdateScript(int index, Script script);


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
