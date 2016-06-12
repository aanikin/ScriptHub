using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using ScriptHub.Model;
using ScriptHub.Model.Interfaces;

namespace ScriptHub
{
    public partial class MainForm : Form
    {
        ScriptHubModel _model;
        
        Color _defaultColor = Color.White;
        Color _errorColor = Color.Red;

        public MainForm(IScriptHubModel model)
        {
           
            InitializeComponent();
           
            Control.CheckForIllegalCrossThreadCalls = false;

            _model = model as ScriptHubModel;

            Initialize();
        }

        private void Initialize()
        {
            SubscribeForEvents();
            
            ResizeStatusBar();

            LoadScripts();
           
        }

       
       private void SubscribeForEvents()
        {
            _model.ErrorReceived += WriteErrorOutput;
            _model.OutputDataReceived += WriteOutput;
            _model.ScriptFinished += Done;
        }

        private void LoadScripts()
        {
            var scripts = _model.GetScripts();
            ScriptsBox.Items.Clear();
            foreach (var s in scripts)
            {
                ScriptsBox.Items.Add(s.Name);
            }
            ScriptsBox.SelectedIndex = 0;
        }


        void Done(object sender, EventArgs e)
        {
            var scriptEventArgs = e as ScriptHubDataReceivedEventArgs;

            UpdateControlsOnStop(scriptEventArgs.Data);
        }

        private void WriteOutput(object sender, DataReceivedEventArgs e)
        {
            WriteToOutput(e.Data);
        }

        private void WriteErrorOutput(object sender, EventArgs e)
        {
            var scriptEventArgs = e as ScriptHubDataReceivedEventArgs;

            WriteToOutput(scriptEventArgs.Data, true, false);

            ErrorOutput.Items.Add(scriptEventArgs.Data);

            ErrorsCount.Text = "Errors: " + _model.ErrorsCount;
                    
        }


        private void StopButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = false;

            _model.StopScript();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            
            _model.StartScript(ScriptsBox.SelectedIndex);
            
            UpdateControlsOnRun();
        }

        private void UpdateControlsOnRun()
        {
            ClearErrors();
           
            RunButton.Enabled = false;
            StopButton.Enabled = true;
           
            CurrentState.Text = "Running...";
            
            var script = _model.GetScript(ScriptsBox.SelectedIndex);
           
            AppendText(Output, "### SCRIPT STARTED: " + script.Name + " (" + script.Path + script.Arguments + ")", Color.LawnGreen, true);
        }

        private void ClearErrors()
        {
            ErrorOutput.Items.Clear();
            ErrorsCount.Text = "No errors";
        }

        private void UpdateControlsOnStop(string message)
        {   
            RunButton.Enabled = true;
            StopButton.Enabled = false;

            AppendText(Output, "### " + message.ToUpper(), Color.LawnGreen, true);
            CurrentState.Text = message;
        }

        private void WriteToOutput (string text, bool Error = false, bool withCleanup = false)
        {
            if (withCleanup)
            {
                Output.Text = "";
            }

            var color = _defaultColor;
            if (Error)
            {
                color = _errorColor;
            }
            AppendText(Output, text, color, true);
            
        }

        private void AppendText(RichTextBox box, string text, Color color, bool AddNewLine = false)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            
            if (AddNewLine)
            {
                text += Environment.NewLine;
            }

            box.AppendText(text);

            box.SelectionColor = _defaultColor;
            box.ScrollToCaret();

        }

        private void ErrorOutput_DoubleClick(object sender, EventArgs e)
        {
             MessageBox.Show(_model.GetError(ErrorOutput.SelectedIndex));
        }

        
        private void AddButton_Click(object sender, EventArgs e)
        {
             ScriptForm editScript = new ScriptForm(_model);
             if (editScript.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 LoadScripts();
             }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

            ScriptForm editScript = new ScriptForm(_model, ScriptsBox.SelectedIndex);
            if (editScript.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadScripts();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var script = _model.GetScript(ScriptsBox.SelectedIndex);
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete script " + script.Name + "?", "Delete script", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _model.DeleteScript(ScriptsBox.SelectedIndex);
                LoadScripts();
            }
            
        }

        private void EditinISE_Click_1(object sender, EventArgs e)
        {
            _model.OpenInISE(ScriptsBox.SelectedIndex);
        }

        private void ScriptsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var script = _model.GetScript(ScriptsBox.SelectedIndex);
            StatusText.Text = script.Path + " " + script.Arguments;

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeStatusBar();
        }

        private void ResizeStatusBar()
        {
            int len = 0;
            foreach (ToolStripItem item in statusBar.Items)
            {
                if (item != StatusText)
                {
                    len += item.Width + 10;
                }
            }
            StatusText.Width = statusBar.Width - len;
        }

    }

   
}
