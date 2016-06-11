using System;
using System.Collections.Generic;

namespace ScriptHub
{
    public interface IScriptStore
    {
        List<Script> GetScripts();
        Script GetScript(int index);

        bool AddScript(Script script);

        bool UpdateScript(int index, Script script);

        void DeleteScript(int index);


    }
}
