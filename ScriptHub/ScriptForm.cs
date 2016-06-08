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

        public Script CurrentScript { 
            get { 
                return _scriptToEdit; 
            }
        }
        public ScriptForm(Script scriptToEdit = null)
        {
            InitializeComponent();

            if (scriptToEdit == null)
            {
                _scriptToEdit = new Script();
                InitializeToAddNewScript();
            }
            else
            {
                _scriptToEdit = scriptToEdit;
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
            _scriptToEdit.Name = NameBox.Text;
            _scriptToEdit.Path = PathBox.Text;
            _scriptToEdit.Arguments = ArgumentsBox.Text;
            _scriptToEdit.Details = DetailsBox.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            
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
