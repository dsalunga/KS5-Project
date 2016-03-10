namespace KS5.Main
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.leftRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.leftRaftingContainer1 = new System.Windows.Forms.RaftingContainer();
            this.topRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.voiceCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speechSynthesisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bWKS5Handler = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topRaftingContainer)).BeginInit();
            this.topRaftingContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRaftingContainer)).BeginInit();
            this.bottomRaftingContainer.SuspendLayout();
            this.SuspendLayout();
// 
// leftRaftingContainer
// 
            this.leftRaftingContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftRaftingContainer.Name = "leftRaftingContainer";
// 
// leftRaftingContainer1
// 
            this.leftRaftingContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftRaftingContainer1.Name = "leftRaftingContainer1";
// 
// topRaftingContainer
// 
            this.topRaftingContainer.Controls.Add(this.menuStrip1);
            this.topRaftingContainer.Controls.Add(this.toolStrip1);
            this.topRaftingContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topRaftingContainer.Name = "topRaftingContainer";
// 
// menuStrip1
// 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Raft = System.Windows.Forms.RaftingSides.Top;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
// 
// fileToolStripMenuItem
// 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.SettingsKey = "Form1.fileToolStripMenuItem";
            this.fileToolStripMenuItem.Text = "&File";
// 
// newToolStripMenuItem
// 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.SettingsKey = "Form1.newToolStripMenuItem";
            this.newToolStripMenuItem.Text = "&New";
// 
// openToolStripMenuItem
// 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.SettingsKey = "Form1.openToolStripMenuItem";
            this.openToolStripMenuItem.Text = "&Open";
// 
// saveToolStripMenuItem
// 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.SettingsKey = "Form1.saveToolStripMenuItem";
            this.saveToolStripMenuItem.Text = "&Save";
// 
// toolStripMenuItem1
// 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.SettingsKey = "Form1.toolStripMenuItem1";
// 
// exitToolStripMenuItem
// 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.SettingsKey = "Form1.exitToolStripMenuItem";
            this.exitToolStripMenuItem.Text = "E&xit";
// 
// toolsToolStripMenuItem
// 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.voiceCommandToolStripMenuItem,
            this.speechSynthesisToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.SettingsKey = "Form1.toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Text = "&Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
// 
// optionsToolStripMenuItem
// 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.SettingsKey = "Form1.optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Text = "&Options";
// 
// toolStripMenuItem2
// 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.SettingsKey = "Form1.toolStripMenuItem2";
// 
// voiceCommandToolStripMenuItem
// 
            this.voiceCommandToolStripMenuItem.Checked = true;
            this.voiceCommandToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.voiceCommandToolStripMenuItem.Name = "voiceCommandToolStripMenuItem";
            this.voiceCommandToolStripMenuItem.SettingsKey = "Form1.voiceCommandToolStripMenuItem";
            this.voiceCommandToolStripMenuItem.Text = "&Voice Command";
// 
// speechSynthesisToolStripMenuItem
// 
            this.speechSynthesisToolStripMenuItem.Checked = true;
            this.speechSynthesisToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.speechSynthesisToolStripMenuItem.Name = "speechSynthesisToolStripMenuItem";
            this.speechSynthesisToolStripMenuItem.SettingsKey = "Form1.speechSynthesisToolStripMenuItem";
            this.speechSynthesisToolStripMenuItem.Text = "&Speech Synthesis";
// 
// helpToolStripMenuItem
// 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.aboutToolStripMenuItem
            });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.SettingsKey = "Form1.helpToolStripMenuItem";
            this.helpToolStripMenuItem.Text = "&Help";
// 
// aboutToolStripMenuItem
// 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.SettingsKey = "Form1.aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Text = "&About...";
// 
// bottomRaftingContainer
// 
            this.bottomRaftingContainer.Controls.Add(this.statusStrip1);
            this.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomRaftingContainer.Name = "bottomRaftingContainer";
// 
// statusStrip1
// 
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statusStrip1.Raft = System.Windows.Forms.RaftingSides.Bottom;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
// 
// bWKS5Handler
// 
            this.bWKS5Handler.WorkerReportsProgress = false;
            this.bWKS5Handler.WorkerSupportsCancellation = false;
            this.bWKS5Handler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWKS5Handler_DoWork);
            this.bWKS5Handler.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWKS5Handler_RunWorkerCompleted);
// 
// button1
// 
            this.button1.Location = new System.Drawing.Point(174, 208);
            this.button1.Name = "button1";
            this.button1.TabIndex = 4;
            this.button1.Text = "Move Piece";
            this.button1.Click += new System.EventHandler(this.button1_Click);
// 
// textBox1
// 
            this.textBox1.Location = new System.Drawing.Point(174, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 9;
// 
// button2
// 
            this.button2.Location = new System.Drawing.Point(323, 284);
            this.button2.Name = "button2";
            this.button2.TabIndex = 14;
            this.button2.Text = "isPresent";
            this.button2.Click += new System.EventHandler(this.button2_Click);
// 
// textBox2
// 
            this.textBox2.Location = new System.Drawing.Point(323, 257);
            this.textBox2.Name = "textBox2";
            this.textBox2.TabIndex = 19;
// 
// button3
// 
            this.button3.Location = new System.Drawing.Point(35, 181);
            this.button3.Name = "button3";
            this.button3.TabIndex = 24;
            this.button3.Text = "Start Game";
            this.button3.Click += new System.EventHandler(this.button3_Click);
// 
// button4
// 
            this.button4.Location = new System.Drawing.Point(323, 208);
            this.button4.Name = "button4";
            this.button4.TabIndex = 29;
            this.button4.Text = "Point Square";
            this.button4.Click += new System.EventHandler(this.button4_Click);
// 
// textBox3
// 
            this.textBox3.Location = new System.Drawing.Point(323, 181);
            this.textBox3.Name = "textBox3";
            this.textBox3.TabIndex = 30;
// 
// toolStrip1
// 
            this.toolStrip1.Location = new System.Drawing.Point(0, 21);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Raft = System.Windows.Forms.RaftingSides.Top;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
// 
// GUI
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(596, 426);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leftRaftingContainer);
            this.Controls.Add(this.leftRaftingContainer1);
            this.Controls.Add(this.topRaftingContainer);
            this.Controls.Add(this.bottomRaftingContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topRaftingContainer)).EndInit();
            this.topRaftingContainer.ResumeLayout(false);
            this.topRaftingContainer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bottomRaftingContainer)).EndInit();
            this.bottomRaftingContainer.ResumeLayout(false);
            this.bottomRaftingContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RaftingContainer leftRaftingContainer;
        private System.Windows.Forms.RaftingContainer leftRaftingContainer1;
        private System.Windows.Forms.RaftingContainer topRaftingContainer;
        private System.Windows.Forms.RaftingContainer bottomRaftingContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem voiceCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speechSynthesisToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker bWKS5Handler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

