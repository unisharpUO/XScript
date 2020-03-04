namespace App.RebirthUO.Scripts.UIThreadTest
{
    /// <summary>
    /// NEVER EVER CHANGE ANYTHING HERE!!!!!!!!!
    /// </summary>
    partial class UITester
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UITester));
            this.cmslogger = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stbopen = new System.Windows.Forms.ToolStripButton();
            this.tsbsave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbplay = new System.Windows.Forms.ToolStripButton();
            this.tsbstop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbinfo = new System.Windows.Forms.ToolStripButton();
            this.ScriptThread = new System.ComponentModel.BackgroundWorker();
            this.lblogger = new System.Windows.Forms.ListBox();
            this.cmslogger.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmslogger
            // 
            this.cmslogger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.cmslogger.Name = "cmslogger";
            this.cmslogger.Size = new System.Drawing.Size(108, 48);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 280);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(342, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbopen,
            this.tsbsave,
            this.toolStripSeparator1,
            this.tsbplay,
            this.tsbstop,
            this.toolStripSeparator2,
            this.tsbinfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(342, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stbopen
            // 
            this.stbopen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stbopen.Image = ((System.Drawing.Image)(resources.GetObject("stbopen.Image")));
            this.stbopen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbopen.Name = "stbopen";
            this.stbopen.Size = new System.Drawing.Size(23, 22);
            this.stbopen.Text = "Open";
            // 
            // tsbsave
            // 
            this.tsbsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbsave.Image = ((System.Drawing.Image)(resources.GetObject("tsbsave.Image")));
            this.tsbsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbsave.Name = "tsbsave";
            this.tsbsave.Size = new System.Drawing.Size(23, 22);
            this.tsbsave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbplay
            // 
            this.tsbplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbplay.Image = ((System.Drawing.Image)(resources.GetObject("tsbplay.Image")));
            this.tsbplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbplay.Name = "tsbplay";
            this.tsbplay.Size = new System.Drawing.Size(23, 22);
            this.tsbplay.Text = "Play";
            this.tsbplay.Click += new System.EventHandler(this.tsbplay_Click);
            // 
            // tsbstop
            // 
            this.tsbstop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbstop.Enabled = false;
            this.tsbstop.Image = ((System.Drawing.Image)(resources.GetObject("tsbstop.Image")));
            this.tsbstop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbstop.Name = "tsbstop";
            this.tsbstop.Size = new System.Drawing.Size(23, 22);
            this.tsbstop.Text = "Stop";
            this.tsbstop.Click += new System.EventHandler(this.tsbstop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbinfo
            // 
            this.tsbinfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbinfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbinfo.Image")));
            this.tsbinfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbinfo.Name = "tsbinfo";
            this.tsbinfo.Size = new System.Drawing.Size(23, 22);
            this.tsbinfo.Text = "Info";
            // 
            // ScriptThread
            // 
            this.ScriptThread.WorkerSupportsCancellation = true;
            this.ScriptThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ScriptThread_DoWork);
            // 
            // lblogger
            // 
            this.lblogger.ContextMenuStrip = this.cmslogger;
            this.lblogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblogger.FormattingEnabled = true;
            this.lblogger.Location = new System.Drawing.Point(0, 25);
            this.lblogger.Name = "lblogger";
            this.lblogger.Size = new System.Drawing.Size(342, 255);
            this.lblogger.TabIndex = 4;
            // 
            // UITester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 302);
            this.Controls.Add(this.lblogger);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "UITester";
            this.Text = "UI-TestForm";
            this.cmslogger.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton stbopen;
        private System.Windows.Forms.ToolStripButton tsbsave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbplay;
        private System.Windows.Forms.ToolStripButton tsbstop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbinfo;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.ComponentModel.BackgroundWorker ScriptThread;
        private System.Windows.Forms.ContextMenuStrip cmslogger;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ListBox lblogger;
    }
}