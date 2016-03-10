namespace KS5.GUI
{
    partial class Form1
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.topRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bottomRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.voiceCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speechSynthesisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer1)).BeginInit();
            this.leftRaftingContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topRaftingContainer)).BeginInit();
            this.topRaftingContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRaftingContainer)).BeginInit();
            this.SuspendLayout();
// 
// leftRaftingContainer
// 
            this.leftRaftingContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftRaftingContainer.Name = "leftRaftingContainer";
// 
// leftRaftingContainer1
// 
            this.leftRaftingContainer1.Controls.Add(this.toolStrip1);
            this.leftRaftingContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftRaftingContainer1.Name = "leftRaftingContainer1";
// 
// toolStrip1
// 
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Raft = System.Windows.Forms.RaftingSides.Left;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
// 
// topRaftingContainer
// 
            this.topRaftingContainer.Controls.Add(this.menuStrip1);
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
// bottomRaftingContainer
// 
            this.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomRaftingContainer.Name = "bottomRaftingContainer";
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
// 
// optionsToolStripMenuItem
// 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.SettingsKey = "Form1.optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Text = "&Options";
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
// Form1
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(450, 314);
            this.Controls.Add(this.leftRaftingContainer);
            this.Controls.Add(this.leftRaftingContainer1);
            this.Controls.Add(this.topRaftingContainer);
            this.Controls.Add(this.bottomRaftingContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer1)).EndInit();
            this.leftRaftingContainer1.ResumeLayout(false);
            this.leftRaftingContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topRaftingContainer)).EndInit();
            this.topRaftingContainer.ResumeLayout(false);
            this.topRaftingContainer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bottomRaftingContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RaftingContainer leftRaftingContainer;
        private System.Windows.Forms.RaftingContainer leftRaftingContainer1;
        private System.Windows.Forms.RaftingContainer topRaftingContainer;
        private System.Windows.Forms.RaftingContainer bottomRaftingContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
    }
}

