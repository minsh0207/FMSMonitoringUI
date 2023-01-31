namespace FMSMonitoringUI.Monitoring
{
    partial class WinFormationBox
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridEqpInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridTrayInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlGroupBox1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.EqpControlSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbForceUnload = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbResume = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbPause = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbRestart = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbStop = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlGroupBox3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.DataClearSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbClearTrouble = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbClearInfo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlGroupBox2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.rbNoIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ConfigurationSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ctrlGroupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ctrlGroupBox3.SuspendLayout();
            this.ctrlGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridEqpInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1111, 444);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 3;
            // 
            // gridEqpInfo
            // 
            this.gridEqpInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridEqpInfo.ColumnCount = -1;
            this.gridEqpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEqpInfo.Location = new System.Drawing.Point(0, 0);
            this.gridEqpInfo.Name = "gridEqpInfo";
            this.gridEqpInfo.RowCount = -1;
            this.gridEqpInfo.Size = new System.Drawing.Size(272, 442);
            this.gridEqpInfo.TabIndex = 1;
            this.gridEqpInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridTrayInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel4);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(833, 444);
            this.splitContainer2.SplitterDistance = 476;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridTrayInfo
            // 
            this.gridTrayInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridTrayInfo.ColumnCount = -1;
            this.gridTrayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrayInfo.Location = new System.Drawing.Point(0, 0);
            this.gridTrayInfo.Margin = new System.Windows.Forms.Padding(0);
            this.gridTrayInfo.Name = "gridTrayInfo";
            this.gridTrayInfo.RowCount = -1;
            this.gridTrayInfo.Size = new System.Drawing.Size(474, 442);
            this.gridTrayInfo.TabIndex = 1;
            this.gridTrayInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlGroupBox1
            // 
            this.ctrlGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox1.Controls.Add(this.EqpControlSave);
            this.ctrlGroupBox1.Controls.Add(this.rbForceUnload);
            this.ctrlGroupBox1.Controls.Add(this.rbResume);
            this.ctrlGroupBox1.Controls.Add(this.rbPause);
            this.ctrlGroupBox1.Controls.Add(this.rbRestart);
            this.ctrlGroupBox1.Controls.Add(this.rbStop);
            this.ctrlGroupBox1.Font = new System.Drawing.Font("돋움", 9.75F);
            this.ctrlGroupBox1.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox1.LanguageID = "DEF_Equipment_Control";
            this.ctrlGroupBox1.Location = new System.Drawing.Point(12, 139);
            this.ctrlGroupBox1.Name = "ctrlGroupBox1";
            this.ctrlGroupBox1.Size = new System.Drawing.Size(325, 164);
            this.ctrlGroupBox1.TabIndex = 62;
            this.ctrlGroupBox1.TabStop = false;
            this.ctrlGroupBox1.Text = "Equipment Control";
            this.ctrlGroupBox1.TitleText = "Equipment Control";
            // 
            // EqpControlSave
            // 
            this.EqpControlSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.EqpControlSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EqpControlSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.EqpControlSave.LabelText = "Save";
            this.EqpControlSave.LanguageID = "DEF_Save";
            this.EqpControlSave.Location = new System.Drawing.Point(223, 21);
            this.EqpControlSave.Name = "EqpControlSave";
            this.EqpControlSave.Size = new System.Drawing.Size(89, 128);
            this.EqpControlSave.TabIndex = 67;
            this.EqpControlSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // rbForceUnload
            // 
            this.rbForceUnload.AutoSize = true;
            this.rbForceUnload.Font = new System.Drawing.Font("굴림", 9F);
            this.rbForceUnload.ForeColor = System.Drawing.Color.White;
            this.rbForceUnload.LanguageID = "DEF_Force_Tray_Unload";
            this.rbForceUnload.Location = new System.Drawing.Point(14, 131);
            this.rbForceUnload.Name = "rbForceUnload";
            this.rbForceUnload.Size = new System.Drawing.Size(128, 16);
            this.rbForceUnload.TabIndex = 66;
            this.rbForceUnload.TabStop = true;
            this.rbForceUnload.Text = "Force Tray Unload";
            this.rbForceUnload.UseVisualStyleBackColor = true;
            // 
            // rbResume
            // 
            this.rbResume.AutoSize = true;
            this.rbResume.Font = new System.Drawing.Font("굴림", 9F);
            this.rbResume.ForeColor = System.Drawing.Color.White;
            this.rbResume.LanguageID = "DEF_Resume_Paused_Process";
            this.rbResume.Location = new System.Drawing.Point(14, 104);
            this.rbResume.Name = "rbResume";
            this.rbResume.Size = new System.Drawing.Size(168, 16);
            this.rbResume.TabIndex = 65;
            this.rbResume.TabStop = true;
            this.rbResume.Text = "Resume Paused Process";
            this.rbResume.UseVisualStyleBackColor = true;
            // 
            // rbPause
            // 
            this.rbPause.AutoSize = true;
            this.rbPause.Font = new System.Drawing.Font("굴림", 9F);
            this.rbPause.ForeColor = System.Drawing.Color.White;
            this.rbPause.LanguageID = "DEF_Pause_Current_Process";
            this.rbPause.Location = new System.Drawing.Point(14, 77);
            this.rbPause.Name = "rbPause";
            this.rbPause.Size = new System.Drawing.Size(155, 16);
            this.rbPause.TabIndex = 64;
            this.rbPause.TabStop = true;
            this.rbPause.Text = "Pause Current Process";
            this.rbPause.UseVisualStyleBackColor = true;
            // 
            // rbRestart
            // 
            this.rbRestart.AutoSize = true;
            this.rbRestart.Font = new System.Drawing.Font("굴림", 9F);
            this.rbRestart.ForeColor = System.Drawing.Color.White;
            this.rbRestart.LanguageID = "DEF_Restart_Current_Process";
            this.rbRestart.Location = new System.Drawing.Point(14, 50);
            this.rbRestart.Name = "rbRestart";
            this.rbRestart.Size = new System.Drawing.Size(158, 16);
            this.rbRestart.TabIndex = 63;
            this.rbRestart.TabStop = true;
            this.rbRestart.Text = "Restart Current Process";
            this.rbRestart.UseVisualStyleBackColor = true;
            // 
            // rbStop
            // 
            this.rbStop.AutoSize = true;
            this.rbStop.Font = new System.Drawing.Font("굴림", 9F);
            this.rbStop.ForeColor = System.Drawing.Color.White;
            this.rbStop.LanguageID = "DEF_Stop_Current_Process";
            this.rbStop.Location = new System.Drawing.Point(14, 26);
            this.rbStop.Name = "rbStop";
            this.rbStop.Size = new System.Drawing.Size(144, 16);
            this.rbStop.TabIndex = 62;
            this.rbStop.TabStop = true;
            this.rbStop.Text = "Stop Current Process";
            this.rbStop.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.titBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 60);
            this.panel2.TabIndex = 4;
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_Formation_Box";
            this.titBar.Location = new System.Drawing.Point(0, 0);
            this.titBar.Margin = new System.Windows.Forms.Padding(0);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(1109, 58);
            this.titBar.TabIndex = 0;
            this.titBar.TitleText = "Formation Box";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Exit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1111, 60);
            this.panel3.TabIndex = 5;
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.LanguageID = "DEF_Exit";
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(170, 40);
            this.Exit.TabIndex = 1;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.AutoSize = true;
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_Manual_Command";
            this.ctrlLabel4.Location = new System.Drawing.Point(9, 9);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(138, 15);
            this.ctrlLabel4.TabIndex = 68;
            this.ctrlLabel4.Text = "Manual Command";
            // 
            // ctrlGroupBox3
            // 
            this.ctrlGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox3.Controls.Add(this.DataClearSave);
            this.ctrlGroupBox3.Controls.Add(this.rbClearTrouble);
            this.ctrlGroupBox3.Controls.Add(this.rbClearInfo);
            this.ctrlGroupBox3.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox3.LanguageID = "DEF_Data_Clear";
            this.ctrlGroupBox3.Location = new System.Drawing.Point(12, 324);
            this.ctrlGroupBox3.Name = "ctrlGroupBox3";
            this.ctrlGroupBox3.Size = new System.Drawing.Size(325, 90);
            this.ctrlGroupBox3.TabIndex = 69;
            this.ctrlGroupBox3.TabStop = false;
            this.ctrlGroupBox3.Text = "Data Clear";
            this.ctrlGroupBox3.TitleText = "Data Clear";
            // 
            // DataClearSave
            // 
            this.DataClearSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.DataClearSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DataClearSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.DataClearSave.LabelText = "Save";
            this.DataClearSave.LanguageID = "DEF_Save";
            this.DataClearSave.Location = new System.Drawing.Point(223, 21);
            this.DataClearSave.Name = "DataClearSave";
            this.DataClearSave.Size = new System.Drawing.Size(89, 52);
            this.DataClearSave.TabIndex = 45;
            this.DataClearSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // rbClearTrouble
            // 
            this.rbClearTrouble.AutoSize = true;
            this.rbClearTrouble.ForeColor = System.Drawing.Color.White;
            this.rbClearTrouble.LanguageID = "DEF_Clear_Trouble";
            this.rbClearTrouble.Location = new System.Drawing.Point(13, 55);
            this.rbClearTrouble.Name = "rbClearTrouble";
            this.rbClearTrouble.Size = new System.Drawing.Size(101, 17);
            this.rbClearTrouble.TabIndex = 44;
            this.rbClearTrouble.TabStop = true;
            this.rbClearTrouble.Text = "Clear Trouble";
            this.rbClearTrouble.UseVisualStyleBackColor = true;
            // 
            // rbClearInfo
            // 
            this.rbClearInfo.AutoSize = true;
            this.rbClearInfo.ForeColor = System.Drawing.Color.White;
            this.rbClearInfo.LanguageID = "DEF_Clear_Information";
            this.rbClearInfo.Location = new System.Drawing.Point(13, 27);
            this.rbClearInfo.Name = "rbClearInfo";
            this.rbClearInfo.Size = new System.Drawing.Size(119, 17);
            this.rbClearInfo.TabIndex = 43;
            this.rbClearInfo.TabStop = true;
            this.rbClearInfo.Text = "Clear Information";
            this.rbClearInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlGroupBox2
            // 
            this.ctrlGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox2.Controls.Add(this.rbNoIn);
            this.ctrlGroupBox2.Controls.Add(this.rbYesIn);
            this.ctrlGroupBox2.Controls.Add(this.ConfigurationSave);
            this.ctrlGroupBox2.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox2.LanguageID = "DEF_Configuration";
            this.ctrlGroupBox2.Location = new System.Drawing.Point(12, 38);
            this.ctrlGroupBox2.Name = "ctrlGroupBox2";
            this.ctrlGroupBox2.Size = new System.Drawing.Size(325, 85);
            this.ctrlGroupBox2.TabIndex = 70;
            this.ctrlGroupBox2.TabStop = false;
            this.ctrlGroupBox2.Text = "Configuration";
            this.ctrlGroupBox2.TitleText = "Configuration";
            // 
            // rbNoIn
            // 
            this.rbNoIn.AutoSize = true;
            this.rbNoIn.ForeColor = System.Drawing.Color.White;
            this.rbNoIn.LanguageID = "DEF_Disable_Tray_Load";
            this.rbNoIn.Location = new System.Drawing.Point(13, 54);
            this.rbNoIn.Name = "rbNoIn";
            this.rbNoIn.Size = new System.Drawing.Size(127, 17);
            this.rbNoIn.TabIndex = 42;
            this.rbNoIn.TabStop = true;
            this.rbNoIn.Text = "Disable Tray Load";
            this.rbNoIn.UseVisualStyleBackColor = true;
            // 
            // rbYesIn
            // 
            this.rbYesIn.AutoSize = true;
            this.rbYesIn.ForeColor = System.Drawing.Color.White;
            this.rbYesIn.LanguageID = "DEF_Enable_Tray_Load";
            this.rbYesIn.Location = new System.Drawing.Point(13, 24);
            this.rbYesIn.Name = "rbYesIn";
            this.rbYesIn.Size = new System.Drawing.Size(124, 17);
            this.rbYesIn.TabIndex = 41;
            this.rbYesIn.TabStop = true;
            this.rbYesIn.Text = "Enable Tray Load";
            this.rbYesIn.UseVisualStyleBackColor = true;
            // 
            // ConfigurationSave
            // 
            this.ConfigurationSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ConfigurationSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConfigurationSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ConfigurationSave.LabelText = "Save";
            this.ConfigurationSave.LanguageID = "DEF_Save";
            this.ConfigurationSave.Location = new System.Drawing.Point(223, 19);
            this.ConfigurationSave.Name = "ConfigurationSave";
            this.ConfigurationSave.Size = new System.Drawing.Size(89, 52);
            this.ConfigurationSave.TabIndex = 45;
            this.ConfigurationSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // WinFormationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1115, 589);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinFormationBox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinFormationBox";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinFormationBox_FormClosed);
            this.Load += new System.EventHandler(this.WinFormationBox_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ctrlGroupBox1.ResumeLayout(false);
            this.ctrlGroupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ctrlGroupBox3.ResumeLayout(false);
            this.ctrlGroupBox3.PerformLayout();
            this.ctrlGroupBox2.ResumeLayout(false);
            this.ctrlGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox1;
        private MonitoringUI.Controlls.CButton.CtrlButton EqpControlSave;
        private Controlls.WindowsForms.CtrlRadioButton rbForceUnload;
        private Controlls.WindowsForms.CtrlRadioButton rbResume;
        private Controlls.WindowsForms.CtrlRadioButton rbPause;
        private Controlls.WindowsForms.CtrlRadioButton rbRestart;
        private Controlls.WindowsForms.CtrlRadioButton rbStop;
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CtrlTitleBar titBar;
        private System.Windows.Forms.Panel panel3;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel4;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox3;
        private MonitoringUI.Controlls.CButton.CtrlButton DataClearSave;
        private Controlls.WindowsForms.CtrlRadioButton rbClearTrouble;
        private Controlls.WindowsForms.CtrlRadioButton rbClearInfo;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox2;
        private Controlls.WindowsForms.CtrlRadioButton rbNoIn;
        private Controlls.WindowsForms.CtrlRadioButton rbYesIn;
        private MonitoringUI.Controlls.CButton.CtrlButton ConfigurationSave;
    }
}