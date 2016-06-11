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

namespace ScriptHub
{
    public partial class ScriptForm : Form
    {
        Script _scriptToEdit;
        IScriptHubModel _model;
       
        int _scriptIndex;
        
        const int ADD_NEW = -1;


        public Script CurrentScript { 
            get { 
                return _scriptToEdit; 
            }
        }
        public ScriptForm(IScriptHubModel model, int index = ADD_NEW)
        {
            InitializeComponent();
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            _model = model;
            _scriptIndex = index;
            if (_scriptIndex == ADD_NEW)
            {
                _scriptToEdit = new Script();
                InitializeToAddNewScript();
            }
            else
            {
                _scriptToEdit = _model.GetScript(index);
                InitializeToEditScript();
            }

            FillForm();
        }

        private void FillForm()
        {
            NameBox.Text = _scriptToEdit.Name;
            PathBox.Text = _scriptToEdit.Path;
            ArgumentsBox.Text = _scriptToEdit.Arguments;
            DetailsBox.Text = _scriptToEdit.Details;

            if (!string.IsNullOrEmpty(_scriptToEdit.Path))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_scriptToEdit.Path);
            }
        }

        private void InitializeToEditScript()
        {
            Text = "Edit \"" + _scriptToEdit.Name + "\"";
        }

        private void InitializeToAddNewScript()
        {
            Text = "Add new script";

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(PathBox.Text))
            {
                MessageBox.Show("Script file doesn't exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _scriptToEdit = new Script {
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
