using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ScriptHub.Model;
using ScriptHub.Model.Interfaces;

namespace ScriptHub
{
    public partial class ScriptForm : Form
    {
        Script _scriptToEdit;
        IScriptHubModel _model;
       
        int _scriptIndex;
        
        const int ADD_NEW = -1;


        public Script CurrentScript { 
            get 
            { 
                return _scriptToEdit; 
            }
        }

        public ScriptForm(IScriptHubModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            InitializeComponent();

            _model = model;

            _scriptToEdit = new Script();
            Text = "Add new script";

            _scriptIndex = ADD_NEW;
        }
        public ScriptForm(IScriptHubModel model, int index) : this(model)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("index");
            }

            _scriptIndex = index;

            _scriptToEdit = _model.Scripts[index];

            Text = "Edit \"" + _scriptToEdit.Name + "\"";
            
            FillForm();
        }

        private void FillForm()
        {
            runnersComboBox.Items.Clear();
            foreach (var runner in _model.Runners)
            {
                runnersComboBox.Items.Add(runner.Type);
            }
            if (!string.IsNullOrEmpty(_scriptToEdit.Type))
            {
                runnersComboBox.Text = _scriptToEdit.Type;
            }
            else
            {
                runnersComboBox.SelectedIndex = 0;
            }

            NameBox.Text = _scriptToEdit.Name;
            PathBox.Text = _scriptToEdit.Path;
            ArgumentsBox.Text = _scriptToEdit.Arguments;
            DetailsBox.Text = _scriptToEdit.Details;

            if (!string.IsNullOrEmpty(_scriptToEdit.Path))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_scriptToEdit.Path);
            }
        }


        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(PathBox.Text) || string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Wrong script data. Possible some fields empty or wrong path to script file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _scriptToEdit = new Script {
                Type = runnersComboBox.Text,
                Name = NameBox.Text,
                Path = PathBox.Text,
                Arguments = ArgumentsBox.Text,
                Details = DetailsBox.Text
            };

            bool result = false;
            if (_scriptIndex == ADD_NEW) 
            {
                result = _model.AddScript(_scriptToEdit);
            } else
            {
                result = _model.UpdateScript(_scriptIndex, _scriptToEdit);
            }

            if (result)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            } 
            else
            {
                MessageBox.Show("Script with this name already exists. Please choose another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathBox.Text = openFileDialog.FileName;
            }
        }


       
    }
}
