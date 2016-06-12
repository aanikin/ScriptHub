
using System.Collections.Generic;

namespace ScriptHub.Model.Interfaces
{
    public interface IScriptRunnerFactory
    {
        List<Runner> GetRunners();

        IScriptRunner CreateScriptRunner(Script script);
    }
}
