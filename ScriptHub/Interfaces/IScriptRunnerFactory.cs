using System;
namespace ScriptHub
{
    public interface IScriptRunnerFactory
    {
        IScriptRunner CreateScriptRunner(Script script);
    }
}
