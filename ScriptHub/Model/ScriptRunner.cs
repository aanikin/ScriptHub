﻿using ScriptHub.Model.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ScriptHub.Model
{
    class ScriptRunner :  IScriptRunner
    {

        Script _script;
        Runner _runner;

        Process _runnerProcess;

        string _currentError;
       
        public event DataReceivedEventHandler OutputDataReceived;
        public event EventHandler ErrorReceived;
        public event EventHandler Done;


        public ScriptRunner(Runner runner, Script script)
        {
            _script = script;
            _runner = runner;
    
            SetupProcess();
        }

        public void RunScript()
        {
            Task.Run(() =>
            {
                _runnerProcess.Start();
                _runnerProcess.BeginOutputReadLine();
                _runnerProcess.BeginErrorReadLine();
            });
        }

        public void Kill()
        {
            if (!_runnerProcess.HasExited)
            {
                _runnerProcess.Kill();
                _runnerProcess.Dispose();
            }
            
        }

        private void SetupProcess()
        {
            _runnerProcess = new System.Diagnostics.Process();

            _runnerProcess.EnableRaisingEvents = true;

            _runnerProcess.OutputDataReceived += WriteOutput;
            _runnerProcess.ErrorDataReceived += ErrorOutput;
            _runnerProcess.Exited += Exited;

            var str = string.Format(_runner.CommandLine, _script.Path, _script.Arguments);

            _runnerProcess.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = _runner.Executable,
                Arguments = string.Format(_runner.CommandLine, _script.Path, _script.Arguments),
                CreateNoWindow = true,
                RedirectStandardOutput = true,
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