using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptHub
{
    public class ScriptRunnerFactory : IScriptRunnerFactory
    {

        public IScriptRunner CreateScriptRunner(Script script)
        {
            if (script.Type == ScriptType.PowershellScript)
            {
                return new PowerShellRunner(script);
            }

            return null;
        }
    }
}
