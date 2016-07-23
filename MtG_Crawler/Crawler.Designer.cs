namespace MtG_Crawler
{
    partial class Crawler
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonExecute = new System.Windows.Forms.Button();
            this.textBoxScriptPath = new System.Windows.Forms.TextBox();
            this.groupBoxScripting = new System.Windows.Forms.GroupBox();
            this.checkBoxShowLog = new System.Windows.Forms.CheckBox();
            this.labelSets = new System.Windows.Forms.Label();
            this.textBoxSets = new System.Windows.Forms.TextBox();
            this.labelScriptFile = new System.Windows.Forms.Label();
            this.buttonScriptFile = new System.Windows.Forms.Button();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatusMessage = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBoxScripting.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExecute.Location = new System.Drawing.Point(341, 84);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 23);
            this.buttonExecute.TabIndex = 1;
            this.buttonExecute.Text = "Ausführen";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // textBoxScriptPath
            // 
            this.textBoxScriptPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScriptPath.Location = new System.Drawing.Point(46, 28);
            this.textBoxScriptPath.Name = "textBoxScriptPath";
            this.textBoxScriptPath.Size = new System.Drawing.Size(327, 20);
            this.textBoxScriptPath.TabIndex = 2;
            // 
            // groupBoxScripting
            // 
            this.groupBoxScripting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScripting.Controls.Add(this.checkBoxShowLog);
            this.groupBoxScripting.Controls.Add(this.labelSets);
            this.groupBoxScripting.Controls.Add(this.textBoxSets);
            this.groupBoxScripting.Controls.Add(this.labelScriptFile);
            this.groupBoxScripting.Controls.Add(this.buttonScriptFile);
            this.groupBoxScripting.Controls.Add(this.textBoxScriptPath);
            this.groupBoxScripting.Controls.Add(this.buttonExecute);
            this.groupBoxScripting.Location = new System.Drawing.Point(3, 3);
            this.groupBoxScripting.Name = "groupBoxScripting";
            this.groupBoxScripting.Size = new System.Drawing.Size(425, 111);
            this.groupBoxScripting.TabIndex = 3;
            this.groupBoxScripting.TabStop = false;
            this.groupBoxScripting.Text = "Scripting";
            // 
            // checkBoxShowLog
            // 
            this.checkBoxShowLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowLog.AutoSize = true;
            this.checkBoxShowLog.Location = new System.Drawing.Point(236, 88);
            this.checkBoxShowLog.Name = "checkBoxShowLog";
            this.checkBoxShowLog.Size = new System.Drawing.Size(90, 17);
            this.checkBoxShowLog.TabIndex = 7;
            this.checkBoxShowLog.Text = "Log anzeigen";
            this.checkBoxShowLog.UseVisualStyleBackColor = true;
            this.checkBoxShowLog.CheckedChanged += new System.EventHandler(this.checkBoxShowLog_CheckedChanged);
            // 
            // labelSets
            // 
            this.labelSets.AutoSize = true;
            this.labelSets.Location = new System.Drawing.Point(6, 57);
            this.labelSets.Name = "labelSets";
            this.labelSets.Size = new System.Drawing.Size(28, 13);
            this.labelSets.TabIndex = 6;
            this.labelSets.Text = "Sets";
            // 
            // textBoxSets
            // 
            this.textBoxSets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSets.Location = new System.Drawing.Point(46, 54);
            this.textBoxSets.Name = "textBoxSets";
            this.textBoxSets.Size = new System.Drawing.Size(327, 20);
            this.textBoxSets.TabIndex = 5;
            // 
            // labelScriptFile
            // 
            this.labelScriptFile.AutoSize = true;
            this.labelScriptFile.Location = new System.Drawing.Point(6, 31);
            this.labelScriptFile.Name = "labelScriptFile";
            this.labelScriptFile.Size = new System.Drawing.Size(34, 13);
            this.labelScriptFile.TabIndex = 4;
            this.labelScriptFile.Text = "Script";
            // 
            // buttonScriptFile
            // 
            this.buttonScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonScriptFile.Location = new System.Drawing.Point(379, 28);
            this.buttonScriptFile.Name = "buttonScriptFile";
            this.buttonScriptFile.Size = new System.Drawing.Size(37, 23);
            this.buttonScriptFile.TabIndex = 3;
            this.buttonScriptFile.Text = "...";
            this.buttonScriptFile.UseVisualStyleBackColor = true;
            this.buttonScriptFile.Click += new System.EventHandler(this.buttonScriptFile_Click);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLog.Controls.Add(this.buttonClearLog);
            this.groupBoxLog.Controls.Add(this.textBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(0, 3);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(346, 355);
            this.groupBoxLog.TabIndex = 0;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearLog.Location = new System.Drawing.Point(264, 326);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 1;
            this.buttonClearLog.Text = "Log löschen";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(6, 19);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(333, 301);
            this.textBoxLog.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(419, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 4;
            // 
            // labelStatusMessage
            // 
            this.labelStatusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatusMessage.Location = new System.Drawing.Point(3, 34);
            this.labelStatusMessage.Name = "labelStatusMessage";
            this.labelStatusMessage.Size = new System.Drawing.Size(419, 201);
            this.labelStatusMessage.TabIndex = 5;
            this.labelStatusMessage.Text = "Statusmessage";
            this.labelStatusMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.Controls.Add(this.labelStatusMessage);
            this.panelStatus.Controls.Add(this.progressBar);
            this.panelStatus.Location = new System.Drawing.Point(3, 120);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(425, 238);
            this.panelStatus.TabIndex = 4;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxLog);
            this.splitContainer.Panel1MinSize = 180;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBoxScripting);
            this.splitContainer.Panel2.Controls.Add(this.panelStatus);
            this.splitContainer.Panel2MinSize = 230;
            this.splitContainer.Size = new System.Drawing.Size(784, 361);
            this.splitContainer.SplitterDistance = 349;
            this.splitContainer.TabIndex = 8;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "Crawler";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MtG Crawler";
            this.Load += new System.EventHandler(this.Crawler_Load);
            this.groupBoxScripting.ResumeLayout(false);
            this.groupBoxScripting.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.TextBox textBoxScriptPath;
        private System.Windows.Forms.GroupBox groupBoxScripting;
        private System.Windows.Forms.Label labelScriptFile;
        private System.Windows.Forms.Button buttonScriptFile;
        private System.Windows.Forms.Label labelSets;
        private System.Windows.Forms.TextBox textBoxSets;
        private System.Windows.Forms.CheckBox checkBoxShowLog;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelStatusMessage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

