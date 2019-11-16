namespace SoundCardECG
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoscalemiddleclickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panleftclickdragToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomrightclickdragToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beatDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scottPlotUC1 = new ScottPlot.FormsPlot();
            this.timerRenderGraph = new System.Windows.Forms.Timer(this.components);
            this.scottPlotUC2 = new ScottPlot.FormsPlot();
            this.lblBmp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAutoscale = new System.Windows.Forms.CheckBox();
            this.invertSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.soundCardToolStripMenuItem,
            this.graphToolStripMenuItem,
            this.beatDetectionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // soundCardToolStripMenuItem
            // 
            this.soundCardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.toolStripSeparator4,
            this.invertSignalToolStripMenuItem,
            this.toolStripSeparator1,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.soundCardToolStripMenuItem.Name = "soundCardToolStripMenuItem";
            this.soundCardToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.soundCardToolStripMenuItem.Text = "Control";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectToolStripMenuItem.Text = "Select Audio Device";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScaleToolStripMenuItem,
            this.autoscalemiddleclickToolStripMenuItem,
            this.panleftclickdragToolStripMenuItem,
            this.zoomrightclickdragToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveImageToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // fullScaleToolStripMenuItem
            // 
            this.fullScaleToolStripMenuItem.Name = "fullScaleToolStripMenuItem";
            this.fullScaleToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.fullScaleToolStripMenuItem.Text = "Full Scale";
            this.fullScaleToolStripMenuItem.Click += new System.EventHandler(this.fullScaleToolStripMenuItem_Click);
            // 
            // autoscalemiddleclickToolStripMenuItem
            // 
            this.autoscalemiddleclickToolStripMenuItem.Name = "autoscalemiddleclickToolStripMenuItem";
            this.autoscalemiddleclickToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.autoscalemiddleclickToolStripMenuItem.Text = "Auto-scale (middle-click)";
            this.autoscalemiddleclickToolStripMenuItem.Click += new System.EventHandler(this.autoscalemiddleclickToolStripMenuItem_Click);
            // 
            // panleftclickdragToolStripMenuItem
            // 
            this.panleftclickdragToolStripMenuItem.Enabled = false;
            this.panleftclickdragToolStripMenuItem.Name = "panleftclickdragToolStripMenuItem";
            this.panleftclickdragToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.panleftclickdragToolStripMenuItem.Text = "Pan (left-click-drag)";
            // 
            // zoomrightclickdragToolStripMenuItem
            // 
            this.zoomrightclickdragToolStripMenuItem.Enabled = false;
            this.zoomrightclickdragToolStripMenuItem.Name = "zoomrightclickdragToolStripMenuItem";
            this.zoomrightclickdragToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.zoomrightclickdragToolStripMenuItem.Text = "Zoom (right-click-drag)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // beatDetectionToolStripMenuItem
            // 
            this.beatDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearToolStripMenuItem,
            this.saveCSVToolStripMenuItem});
            this.beatDetectionToolStripMenuItem.Name = "beatDetectionToolStripMenuItem";
            this.beatDetectionToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.beatDetectionToolStripMenuItem.Text = "Heartbeat Detection";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.CheckOnClick = true;
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.enabledToolStripMenuItem.Text = "Display";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // saveCSVToolStripMenuItem
            // 
            this.saveCSVToolStripMenuItem.Name = "saveCSVToolStripMenuItem";
            this.saveCSVToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveCSVToolStripMenuItem.Text = "Save CSV";
            this.saveCSVToolStripMenuItem.Click += new System.EventHandler(this.saveCSVToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // scottPlotUC1
            // 
            this.scottPlotUC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scottPlotUC1.Location = new System.Drawing.Point(12, 27);
            this.scottPlotUC1.Name = "scottPlotUC1";
            this.scottPlotUC1.Size = new System.Drawing.Size(776, 361);
            this.scottPlotUC1.TabIndex = 1;
            // 
            // timerRenderGraph
            // 
            this.timerRenderGraph.Interval = 10;
            this.timerRenderGraph.Tick += new System.EventHandler(this.timerRenderGraph_Tick);
            // 
            // scottPlotUC2
            // 
            this.scottPlotUC2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scottPlotUC2.Location = new System.Drawing.Point(12, 394);
            this.scottPlotUC2.Name = "scottPlotUC2";
            this.scottPlotUC2.Size = new System.Drawing.Size(556, 321);
            this.scottPlotUC2.TabIndex = 2;
            // 
            // lblBmp
            // 
            this.lblBmp.AutoSize = true;
            this.lblBmp.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBmp.Location = new System.Drawing.Point(607, 427);
            this.lblBmp.Name = "lblBmp";
            this.lblBmp.Size = new System.Drawing.Size(154, 40);
            this.lblBmp.TabIndex = 3;
            this.lblBmp.Text = "543.2 BPM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(574, 702);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "autoscale: middle-click";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(574, 689);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "pan: left-click-drag";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(574, 676);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "zoom: right-click-drag";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(574, 663);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Graph Controls:";
            // 
            // nudThreshold
            // 
            this.nudThreshold.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudThreshold.Location = new System.Drawing.Point(671, 496);
            this.nudThreshold.Maximum = new decimal(new int[] {
            33000,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(67, 20);
            this.nudThreshold.TabIndex = 8;
            this.nudThreshold.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudThreshold.ValueChanged += new System.EventHandler(this.nudThreshold_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 498);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Threshold:";
            // 
            // cbAutoscale
            // 
            this.cbAutoscale.AutoSize = true;
            this.cbAutoscale.Checked = true;
            this.cbAutoscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoscale.Location = new System.Drawing.Point(574, 643);
            this.cbAutoscale.Name = "cbAutoscale";
            this.cbAutoscale.Size = new System.Drawing.Size(72, 17);
            this.cbAutoscale.TabIndex = 10;
            this.cbAutoscale.Text = "autoscale";
            this.cbAutoscale.UseVisualStyleBackColor = true;
            // 
            // invertSignalToolStripMenuItem
            // 
            this.invertSignalToolStripMenuItem.CheckOnClick = true;
            this.invertSignalToolStripMenuItem.Name = "invertSignalToolStripMenuItem";
            this.invertSignalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.invertSignalToolStripMenuItem.Text = "Invert Signal";
            this.invertSignalToolStripMenuItem.Click += new System.EventHandler(this.invertSignalToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 727);
            this.Controls.Add(this.cbAutoscale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudThreshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBmp);
            this.Controls.Add(this.scottPlotUC2);
            this.Controls.Add(this.scottPlotUC1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Sound Card ECG";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private ScottPlot.FormsPlot scottPlotUC1;
        private System.Windows.Forms.Timer timerRenderGraph;
        private ScottPlot.FormsPlot scottPlotUC2;
        private System.Windows.Forms.Label lblBmp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beatDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoscalemiddleclickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panleftclickdragToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomrightclickdragToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fullScaleToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbAutoscale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem invertSignalToolStripMenuItem;
    }
}

