using Icons=Dolphin.GUI.Icons;

namespace Dolphin.GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openDataSet = new System.Windows.Forms.ToolStripButton();
            this.start = new System.Windows.Forms.ToolStripButton();
            this.rrTest = new System.Windows.Forms.ToolStripButton();
            this.about = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.regressionCombo = new System.Windows.Forms.ComboBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.eventLog = new System.Diagnostics.EventLog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogEntry = new System.Windows.Forms.Label();
            this.logEntries = new System.Windows.Forms.ListView();
            this.Time = new System.Windows.Forms.ColumnHeader();
            this.Message = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDataSet,
            this.start,
            this.rrTest,
            this.about});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(568, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openDataSet
            // 
            this.openDataSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openDataSet.Image = global::Dolphin.GUI.Icons.document_open;
            this.openDataSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openDataSet.Name = "openDataSet";
            this.openDataSet.Size = new System.Drawing.Size(23, 22);
            this.openDataSet.Text = "openDataFile";
            this.openDataSet.Click += new System.EventHandler(this.openDataSet_Click);
            // 
            // start
            // 
            this.start.Image = global::Dolphin.GUI.Icons.run;
            this.start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(51, 22);
            this.start.Text = "Start";
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // rrTest
            // 
            this.rrTest.Image = ((System.Drawing.Image)(resources.GetObject("rrTest.Image")));
            this.rrTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rrTest.Name = "rrTest";
            this.rrTest.Size = new System.Drawing.Size(77, 22);
            this.rrTest.Text = "RR A Test";
            this.rrTest.Click += new System.EventHandler(this.rrTest_Click);
            // 
            // about
            // 
            this.about.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.about.Image = global::Dolphin.GUI.Icons.help_browser;
            this.about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(23, 22);
            this.about.Text = "toolStripButton1";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "DATA|*.data|All files|*.*";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // regressionCombo
            // 
            this.regressionCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regressionCombo.FormattingEnabled = true;
            this.regressionCombo.Items.AddRange(new object[] {
            "Ridge Regression",
            "KAAR",
            "KAARCh"});
            this.regressionCombo.Location = new System.Drawing.Point(3, 3);
            this.regressionCombo.Name = "regressionCombo";
            this.regressionCombo.Size = new System.Drawing.Size(267, 21);
            this.regressionCombo.TabIndex = 1;
            this.regressionCombo.SelectedIndexChanged += new System.EventHandler(this.regressionCombo_SelectedIndexChanged);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(3, 43);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(267, 324);
            this.propertyGrid.TabIndex = 21;
            this.propertyGrid.Click += new System.EventHandler(this.propertyGrid_Click);
            // 
            // eventLog
            // 
            this.eventLog.Log = "GNNS";
            this.eventLog.Source = "GNNS_SOURCE";
            this.eventLog.SynchronizingObject = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(568, 370);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblLogEntry, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.logEntries, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(291, 370);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblLogEntry
            // 
            this.lblLogEntry.AutoSize = true;
            this.lblLogEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogEntry.Location = new System.Drawing.Point(3, 296);
            this.lblLogEntry.Name = "lblLogEntry";
            this.lblLogEntry.Size = new System.Drawing.Size(285, 74);
            this.lblLogEntry.TabIndex = 1;
            // 
            // logEntries
            // 
            this.logEntries.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.logEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.Message});
            this.logEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logEntries.FullRowSelect = true;
            this.logEntries.GridLines = true;
            this.logEntries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.logEntries.Location = new System.Drawing.Point(3, 3);
            this.logEntries.MultiSelect = false;
            this.logEntries.Name = "logEntries";
            this.logEntries.Size = new System.Drawing.Size(285, 290);
            this.logEntries.TabIndex = 2;
            this.logEntries.UseCompatibleStateImageBehavior = false;
            this.logEntries.View = System.Windows.Forms.View.Details;
            this.logEntries.SelectedIndexChanged += new System.EventHandler(this.logEntries_SelectedIndexChanged);
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 120;
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 150;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.regressionCombo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 370);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 417);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Regression Testing";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton start;
        private System.Windows.Forms.ToolStripButton openDataSet;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ComboBox regressionCombo;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ToolStripButton rrTest;
        private System.Diagnostics.EventLog eventLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLogEntry;
        private System.Windows.Forms.ListView logEntries;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.ToolStripButton about;

    }
}