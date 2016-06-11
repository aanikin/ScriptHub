
namespace ScriptHub.Model.Interfaces
{
    public interface IScriptRunnerFactory
    {
        Runners GetRunners();

        IScriptRunner CreateScriptRunner(Script script);
    }
}
