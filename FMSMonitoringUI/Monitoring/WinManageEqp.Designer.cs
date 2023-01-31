namespace FMSMonitoringUI.Monitoring
{
    partial class WinManageEqp
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
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridTrayInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlGroupBox1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.EqpControlSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbForceUnload = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbResume = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbPause = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbRestart = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbStop = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridEqpInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlGroupBox3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.DataClearSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbClearTrouble = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbClearInfo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ctrlGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ctrlGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_Manage_EQP";
            this.titBar.Location = new System.Drawing.Point(2, 2);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(1049, 60);
            this.titBar.TabIndex = 1;
            this.titBar.TitleText = "Manage EQP";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridTrayInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel4);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(745, 387);
            this.splitContainer2.SplitterDistance = 406;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridTrayInfo
            // 
            this.gridTrayInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridTrayInfo.ColumnCount = -1;
            this.gridTrayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrayInfo.Location = new System.Drawing.Point(0, 0);
            this.gridTrayInfo.Name = "gridTrayInfo";
            this.gridTrayInfo.RowCount = -1;
            this.gridTrayInfo.Size = new System.Drawing.Size(404, 385);
            this.gridTrayInfo.TabIndex = 1;
            this.gridTrayInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.AutoSize = true;
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_Manual_Command";
            this.ctrlLabel4.Location = new System.Drawing.Point(8, 12);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(138, 15);
            this.ctrlLabel4.TabIndex = 69;
            this.ctrlLabel4.Text = "Manual Command";
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
            this.ctrlGroupBox1.Location = new System.Drawing.Point(11, 41);
            this.ctrlGroupBox1.Name = "ctrlGroupBox1";
            this.ctrlGroupBox1.Size = new System.Drawing.Size(313, 168);
            this.ctrlGroupBox1.TabIndex = 55;
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
            this.EqpControlSave.Location = new System.Drawing.Point(211, 22);
            this.EqpControlSave.Name = "EqpControlSave";
            this.EqpControlSave.Size = new System.Drawing.Size(89, 128);
            this.EqpControlSave.TabIndex = 60;
            this.EqpControlSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // rbForceUnload
            // 
            this.rbForceUnload.AutoSize = true;
            this.rbForceUnload.Font = new System.Drawing.Font("굴림", 9F);
            this.rbForceUnload.ForeColor = System.Drawing.Color.White;
            this.rbForceUnload.LanguageID = "DEF_Force_Tray_Unload";
            this.rbForceUnload.Location = new System.Drawing.Point(13, 134);
            this.rbForceUnload.Name = "rbForceUnload";
            this.rbForceUnload.Size = new System.Drawing.Size(128, 16);
            this.rbForceUnload.TabIndex = 59;
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
            this.rbResume.Location = new System.Drawing.Point(13, 107);
            this.rbResume.Name = "rbResume";
            this.rbResume.Size = new System.Drawing.Size(168, 16);
            this.rbResume.TabIndex = 58;
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
            this.rbPause.Location = new System.Drawing.Point(13, 80);
            this.rbPause.Name = "rbPause";
            this.rbPause.Size = new System.Drawing.Size(155, 16);
            this.rbPause.TabIndex = 57;
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
            this.rbRestart.Location = new System.Drawing.Point(13, 53);
            this.rbRestart.Name = "rbRestart";
            this.rbRestart.Size = new System.Drawing.Size(158, 16);
            this.rbRestart.TabIndex = 56;
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
            this.rbStop.Location = new System.Drawing.Point(13, 24);
            this.rbStop.Name = "rbStop";
            this.rbStop.Size = new System.Drawing.Size(144, 16);
            this.rbStop.TabIndex = 55;
            this.rbStop.TabStop = true;
            this.rbStop.Text = "Stop Current Process";
            this.rbStop.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(1049, 387);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 7;
            // 
            // gridEqpInfo
            // 
            this.gridEqpInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridEqpInfo.ColumnCount = -1;
            this.gridEqpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEqpInfo.Location = new System.Drawing.Point(0, 0);
            this.gridEqpInfo.Name = "gridEqpInfo";
            this.gridEqpInfo.RowCount = -1;
            this.gridEqpInfo.Size = new System.Drawing.Size(298, 385);
            this.gridEqpInfo.TabIndex = 1;
            this.gridEqpInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Exit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 449);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1049, 60);
            this.panel3.TabIndex = 8;
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
            this.Exit.TabIndex = 2;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ctrlGroupBox3
            // 
            this.ctrlGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox3.Controls.Add(this.DataClearSave);
            this.ctrlGroupBox3.Controls.Add(this.rbClearTrouble);
            this.ctrlGroupBox3.Controls.Add(this.rbClearInfo);
            this.ctrlGroupBox3.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox3.LanguageID = "DEF_Data_Clear";
            this.ctrlGroupBox3.Location = new System.Drawing.Point(11, 230);
            this.ctrlGroupBox3.Name = "ctrlGroupBox3";
            this.ctrlGroupBox3.Size = new System.Drawing.Size(313, 90);
            this.ctrlGroupBox3.TabIndex = 70;
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
            this.DataClearSave.Location = new System.Drawing.Point(211, 21);
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
            // WinManageEqp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1053, 531);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.titBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinManageEqp";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinManageEqp";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinManageEqp_FormClosed);
            this.Load += new System.EventHandler(this.WinManageEqp_Load);
            this.Controls.SetChildIndex(this.titBar, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ctrlGroupBox1.ResumeLayout(false);
            this.ctrlGroupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ctrlGroupBox3.ResumeLayout(false);
            this.ctrlGroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonitoringUI.Controlls.CtrlTitleBar titBar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox1;
        private MonitoringUI.Controlls.CButton.CtrlButton EqpControlSave;
        private Controlls.WindowsForms.CtrlRadioButton rbForceUnload;
        private Controlls.WindowsForms.CtrlRadioButton rbResume;
        private Controlls.WindowsForms.CtrlRadioButton rbPause;
        private Controlls.WindowsForms.CtrlRadioButton rbRestart;
        private Controlls.WindowsForms.CtrlRadioButton rbStop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.Panel panel3;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel4;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox3;
        private MonitoringUI.Controlls.CButton.CtrlButton DataClearSave;
        private Controlls.WindowsForms.CtrlRadioButton rbClearTrouble;
        private Controlls.WindowsForms.CtrlRadioButton rbClearInfo;
    }
}