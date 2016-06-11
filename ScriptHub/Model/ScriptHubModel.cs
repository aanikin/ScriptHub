using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using ScriptHub.Model.Interfaces;

namespace ScriptHub.Model
{
    public class ScriptHubModel : IScriptHubModel
    {
        
        ILogger _logger;
        IScriptStore _scriptStore;
        List<string> _errors;
        Script _currentScript;
        IScriptRunnerFactory _scriptRunner;
        IScriptRunner _psr;

        public event EventHandler ScriptFinished;
        public event EventHandler ErrorReceived;
        public event DataReceivedEventHandler OutputDataReceived;

        public ScriptHubModel(IScriptStore settings, ILogger logger, IScriptRunnerFactory scriptRunner)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            _scriptStore = settings;

            _errors = new List<string>();

            _logger = logger;

            _scriptRunner = scriptRunner;
        }

        public List<Script> GetScripts()
        {
            return _scriptStore.GetScripts();    
        }

        public Script GetScript(int index)
        {
            return _scriptStore.GetScript(index);
        }

        public bool AddScript(Script script)
        {
            return _scriptStore.AddScript(script);
        }

        public bool UpdateScript(int index, Script script)
        {
            return _scriptStore.UpdateScript(index, script);
        }

        public void DeleteScript(int index)
        {
            _scriptStore.DeleteScript(index);
        }

        public void AddError(string newError)
        {
            _errors.Add(newError);
        }

        public void ClearErrors()
        {
            _errors.Clear();
        }

        public int ErrorsCount
        {
            get
            {
                return _errors.Count;
            }
        }

        public string GetError(int index)
        {
            return _errors[index];
        }

        public void StopScript()
        {
            _psr.Kill();
        }

        public void StartScript(int scriptIndex)
        {
            ClearErrors();

            _currentScript = _scriptStore.GetScript(scriptIndex);

            _logger.LogStamp(_currentScript.Name);

            _psr = _scriptRunner.CreateScriptRunner(_currentScript);

            _psr.OutputDataReceived += WriteOutput;
            _psr.ErrorReceived += WriteErrorOutput;
            _psr.Done += Done;

            _psr.RunScript();
        }

        public void OpenInISE(int scriptIndex)
        {
            var script = _scriptStore.GetScript(scriptIndex);

            var ise = new Process();
            ise.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "PowerShell_ISE.exe",
                Arguments = " -file " + script.Path,
                WorkingDirectory = Path.GetDirectoryName(script.Path)
            };
            ise.Start();
        }

        private void Done(object sender, EventArgs e)
        {
            ScriptFinished.Invoke(sender, e);
        }

        private void WriteErrorOutput(object sender, EventArgs e)
        {
            var eventArgs = e as ScriptHubDataReceivedEventArgs;
            _errors.Add(eventArgs.Data);
            _logger.LogToFile(_currentScript.Name, eventArgs.Data);

            ErrorReceived.Invoke(sender, new ScriptHubDataReceivedEventArgs(eventArgs.Data));
 	        
        }

        private void WriteOutput(object sender, DataReceivedEventArgs e)
        {
            _logger.LogToFile(_currentScript.Name, e.Data);

            OutputDataReceived.Invoke(sender, e);
        }

       
    }

  
    
}
