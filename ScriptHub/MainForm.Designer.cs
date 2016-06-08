namespace ScriptHub
{
    partial class MainForm
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ScriptsTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.EditinISE = new System.Windows.Forms.Button();
            this.ScriptsBox = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DetailsLabel = new System.Windows.Forms.Label();
            this.PathLabel = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.ErrorOutput = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.RunButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentState = new System.Windows.Forms.ToolStripStatusLabel();
            this.ErrorsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainTabControl.SuspendLayout();
            this.ScriptsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.ScriptsTab);
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1052, 691);
            this.MainTabControl.TabIndex = 0;
            // 
            // ScriptsTab
            // 
            this.ScriptsTab.Controls.Add(this.splitContainer1);
            this.ScriptsTab.Controls.Add(this.flowLayoutPanel1);
            this.ScriptsTab.Location = new System.Drawing.Point(4, 22);
            this.ScriptsTab.Name = "ScriptsTab";
            this.ScriptsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScriptsTab.Size = new System.Drawing.Size(1044, 665);
            this.ScriptsTab.TabIndex = 0;
            this.ScriptsTab.Text = "Scripts";
            this.ScriptsTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 32);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(276, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.ScriptsBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 630);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel2.Controls.Add(this.AddButton);
            this.flowLayoutPanel2.Controls.Add(this.DeleteButton);
            this.flowLayoutPanel2.Controls.Add(this.EditButton);
            this.flowLayoutPanel2.Controls.Add(this.EditinISE);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 600);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(280, 30);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(26, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "+";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(35, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(26, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "-";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(67, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(42, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // EditinISE
            // 
            this.EditinISE.Location = new System.Drawing.Point(115, 3);
            this.EditinISE.Name = "EditinISE";
            this.EditinISE.Size = new System.Drawing.Size(83, 23);
            this.EditinISE.TabIndex = 6;
            this.EditinISE.Text = "Open in ISE";
            this.EditinISE.UseVisualStyleBackColor = true;
            this.EditinISE.Click += new System.EventHandler(this.EditinISE_Click_1);
            // 
            // ScriptsBox
            // 
            this.ScriptsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScriptsBox.FormattingEnabled = true;
            this.ScriptsBox.ItemHeight = 15;
            this.ScriptsBox.Location = new System.Drawing.Point(0, 0);
            this.ScriptsBox.Name = "ScriptsBox";
            this.ScriptsBox.Size = new System.Drawing.Size(280, 630);
            this.ScriptsBox.TabIndex = 0;
            this.ScriptsBox.DoubleClick += new System.EventHandler(this.EditButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.Output);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ErrorOutput);
            this.splitContainer2.Size = new System.Drawing.Size(754, 630);
            this.splitContainer2.SplitterDistance = 527;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DetailsLabel);
            this.panel1.Controls.Add(this.PathLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 35);
            this.panel1.TabIndex = 1;
            // 
            // DetailsLabel
            // 
            this.DetailsLabel.AutoSize = true;
            this.DetailsLabel.Location = new System.Drawing.Point(4, 15);
            this.DetailsLabel.Name = "DetailsLabel";
            this.DetailsLabel.Size = new System.Drawing.Size(0, 13);
            this.DetailsLabel.TabIndex = 2;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(4, 2);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(0, 13);
            this.PathLabel.TabIndex = 0;
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.Color.Navy;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Output.ForeColor = System.Drawing.Color.White;
            this.Output.Location = new System.Drawing.Point(0, 0);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(754, 527);
            this.Output.TabIndex = 0;
            this.Output.Text = "";
            // 
            // ErrorOutput
            // 
            this.ErrorOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ErrorOutput.FormattingEnabled = true;
            this.ErrorOutput.Location = new System.Drawing.Point(0, 0);
            this.ErrorOutput.Name = "ErrorOutput";
            this.ErrorOutput.Size = new System.Drawing.Size(754, 99);
            this.ErrorOutput.TabIndex = 0;
            this.ErrorOutput.DoubleClick += new System.EventHandler(this.ErrorOutput_DoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.RunButton);
            this.flowLayoutPanel1.Controls.Add(this.StopButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1038, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // RunButton
            // 
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RunButton.Location = new System.Drawing.Point(3, 3);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(106, 23);
            this.RunButton.TabIndex = 3;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopButton.Location = new System.Drawing.Point(115, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(83, 23);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1044, 665);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Monitors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText,
            this.CurrentState,
            this.ErrorsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1050, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(0, 17);
            // 
            // CurrentState
            // 
            this.CurrentState.Name = "CurrentState";
            this.CurrentState.Size = new System.Drawing.Size(0, 17);
            // 
            // ErrorsCount
            // 
            this.ErrorsCount.ForeColor = System.Drawing.Color.Red;
            this.ErrorsCount.Name = "ErrorsCount";
            this.ErrorsCount.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 716);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainTabControl);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "MainForm";
            this.Text = "ScriptHub";
            this.MainTabControl.ResumeLayout(false);
            this.ScriptsTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ScriptsTab;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox ScriptsBox;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox ErrorOutput;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripStatusLabel ErrorsCount;
        private System.Windows.Forms.ToolStripStatusLabel CurrentState;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button EditinISE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DetailsLabel;
        private System.Windows.Forms.Label PathLabel;
    }
}

