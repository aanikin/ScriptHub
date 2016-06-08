namespace ScriptHub
{
    partial class ScriptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pathlabel = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ArgumentsBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DetailsBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(278, 170);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(90, 24);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(375, 170);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 24);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(119, 24);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(346, 20);
            this.NameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // Pathlabel
            // 
            this.Pathlabel.AutoSize = true;
            this.Pathlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pathlabel.Location = new System.Drawing.Point(12, 62);
            this.Pathlabel.Name = "Pathlabel";
            this.Pathlabel.Size = new System.Drawing.Size(33, 13);
            this.Pathlabel.TabIndex = 5;
            this.Pathlabel.Text = "Path";
            // 
            // PathBox
            // 
            this.PathBox.Enabled = false;
            this.PathBox.Location = new System.Drawing.Point(119, 59);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(283, 20);
            this.PathBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Arguments";
            // 
            // ArgumentsBox
            // 
            this.ArgumentsBox.Location = new System.Drawing.Point(119, 96);
            this.ArgumentsBox.Name = "ArgumentsBox";
            this.ArgumentsBox.Size = new System.Drawing.Size(346, 20);
            this.ArgumentsBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Details";
            // 
            // DetailsBox
            // 
            this.DetailsBox.Location = new System.Drawing.Point(119, 131);
            this.DetailsBox.Name = "DetailsBox";
            this.DetailsBox.Size = new System.Drawing.Size(346, 20);
            this.DetailsBox.TabIndex = 5;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(408, 59);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(57, 20);
            this.OpenFileButton.TabIndex = 3;
            this.OpenFileButton.Text = "Browse...";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ps1";
            this.openFileDialog.Filter = "PowerShell Scripts (*.ps1)|*.ps1";
            this.openFileDialog.Title = "Open Powershell Script";
            // 
            // ScriptForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 206);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DetailsBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArgumentsBox);
            this.Controls.Add(this.Pathlabel);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScriptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Pathlabel;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ArgumentsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DetailsBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}