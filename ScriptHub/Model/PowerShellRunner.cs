using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ScriptHub
{
    class PowerShellRunner :  IScriptRunner
    {

        Script _script;
        Process _runnerProcess;

        string _currentError;
       
        public event DataReceivedEventHandler OutputDataReceived;
        public event EventHandler ErrorReceived;
        public event EventHandler Done;

       

        public PowerShellRunner(Script script)
        {
            _script = script;
        }

        public int PID
        {
            get{
                Thread.Sleep(300);
                return _runnerProcess.Id; 
            }
        }
        public void RunScript()
        {
            
            SetupProcess();
            
            Run();

        }

        public void Kill()
        {
            if (!_runnerProcess.HasExited)
            {
                _runnerProcess.Kill();
            }
            
        }

        private void SetupProcess()
        {
            _runnerProcess = new System.Diagnostics.Process();

            _runnerProcess.EnableRaisingEvents = true;

            _runnerProcess.OutputDataReceived += WriteOutput;
            _runnerProcess.ErrorDataReceived += ErrorOutput;
            _runnerProcess.Exited += Exited;

            _runnerProcess.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                FileName = "powershell.exe",
                Arguments = "-ExecutionPolicy RemoteSigned" + " -file " + _script.Path + " " + _script.Arguments, 
                WorkingDirectory = Path.GetDirectoryName(_script.Path),
                UseShellExecute = false,
                RedirectStandardError = true
            };
        }

        private void ErrorOutput(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == " ")
            {
                if (!string.IsNullOrEmpty(_currentError))
                {
                    ErrorReceived.Invoke(sender, new ScriptHubDataReceivedEventArgs(_currentError));
                }
                _currentError = string.Empty;
            }
            else
            {
                 _currentError += e.Data;
            }

        }

        private async Task Run()
        {
            Task.Run(() =>
            {
                _runnerProcess.Start();
                _runnerProcess.BeginOutputReadLine();
                _runnerProcess.BeginErrorReadLine();
            });

        }

        private void WriteOutput(object sender, DataReceivedEventArgs e)
        {
            OutputDataReceived.Invoke(sender, e);
        }

        private void Exited(object sender, EventArgs e)
        {
            Done.Invoke(sender, e);
            _runnerProcess.Dispose();
        }


       
    }
}
