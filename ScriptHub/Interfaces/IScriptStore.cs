using System;
using System.Collections.Generic;

namespace ScriptHub
{
    public interface IScriptStore
    {
        List<Script> GetScripts();
        Script GetScript(int index);

        void AddScript(Script script);

        void UpdateScript(int index, Script script);

        void DeleteScript(int index);
    }
}
