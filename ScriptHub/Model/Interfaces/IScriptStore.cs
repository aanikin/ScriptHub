using System;
using System.Collections.Generic;

namespace ScriptHub.Model.Interfaces
{
    public interface IScriptStore
    {
        List<Script> Scripts { get; }
        Script GetScript(int index);

        int GetScriptIndexByName(string name);

        bool AddScript(Script script);

        bool UpdateScript(int index, Script script);

        void DeleteScript(int index);


    }
}
