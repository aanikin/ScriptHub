
using System.Collections.Generic;

namespace ScriptHub.Model.Interfaces
{
    public interface IScriptRunnerFactory
    {
        List<Runner> Runners { get; }

        IScriptRunner CreateScriptRunner(Script script);
    }
}
