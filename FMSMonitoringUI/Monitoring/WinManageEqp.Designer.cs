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
            this.ctrlGroupBox1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.EqpControlSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbForceTrayUnload = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbResumePaused = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbPauseCurrent = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbRestartCurrent = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbStopCurrent = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataClearSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbClearTrouble = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbDataClear = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridEqpInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ctrlGroupBox1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "";
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
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel1);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
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
            // ctrlGroupBox1
            // 
            this.ctrlGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox1.Controls.Add(this.EqpControlSave);
            this.ctrlGroupBox1.Controls.Add(this.rbForceTrayUnload);
            this.ctrlGroupBox1.Controls.Add(this.rbResumePaused);
            this.ctrlGroupBox1.Controls.Add(this.rbPauseCurrent);
            this.ctrlGroupBox1.Controls.Add(this.rbRestartCurrent);
            this.ctrlGroupBox1.Controls.Add(this.rbStopCurrent);
            this.ctrlGroupBox1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlGroupBox1.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox1.LanguageID = "DEF_Equipment_Control";
            this.ctrlGroupBox1.Location = new System.Drawing.Point(11, 35);
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
            // rbForceTrayUnload
            // 
            this.rbForceTrayUnload.AutoSize = true;
            this.rbForceTrayUnload.Font = new System.Drawing.Font("굴림", 9F);
            this.rbForceTrayUnload.ForeColor = System.Drawing.Color.White;
            this.rbForceTrayUnload.LanguageID = "DEF_Force_Tray_Unload";
            this.rbForceTrayUnload.Location = new System.Drawing.Point(13, 134);
            this.rbForceTrayUnload.Name = "rbForceTrayUnload";
            this.rbForceTrayUnload.Size = new System.Drawing.Size(128, 16);
            this.rbForceTrayUnload.TabIndex = 59;
            this.rbForceTrayUnload.TabStop = true;
            this.rbForceTrayUnload.Text = "Force Tray Unload";
            this.rbForceTrayUnload.UseVisualStyleBackColor = true;
            // 
            // rbResumePaused
            // 
            this.rbResumePaused.AutoSize = true;
            this.rbResumePaused.Font = new System.Drawing.Font("굴림", 9F);
            this.rbResumePaused.ForeColor = System.Drawing.Color.White;
            this.rbResumePaused.LanguageID = "DEF_Resume_Paused_Process";
            this.rbResumePaused.Location = new System.Drawing.Point(13, 107);
            this.rbResumePaused.Name = "rbResumePaused";
            this.rbResumePaused.Size = new System.Drawing.Size(168, 16);
            this.rbResumePaused.TabIndex = 58;
            this.rbResumePaused.TabStop = true;
            this.rbResumePaused.Text = "Resume Paused Process";
            this.rbResumePaused.UseVisualStyleBackColor = true;
            // 
            // rbPauseCurrent
            // 
            this.rbPauseCurrent.AutoSize = true;
            this.rbPauseCurrent.Font = new System.Drawing.Font("굴림", 9F);
            this.rbPauseCurrent.ForeColor = System.Drawing.Color.White;
            this.rbPauseCurrent.LanguageID = "DEF_Pause_Current_Process";
            this.rbPauseCurrent.Location = new System.Drawing.Point(13, 80);
            this.rbPauseCurrent.Name = "rbPauseCurrent";
            this.rbPauseCurrent.Size = new System.Drawing.Size(155, 16);
            this.rbPauseCurrent.TabIndex = 57;
            this.rbPauseCurrent.TabStop = true;
            this.rbPauseCurrent.Text = "Pause Current Process";
            this.rbPauseCurrent.UseVisualStyleBackColor = true;
            // 
            // rbRestartCurrent
            // 
            this.rbRestartCurrent.AutoSize = true;
            this.rbRestartCurrent.Font = new System.Drawing.Font("굴림", 9F);
            this.rbRestartCurrent.ForeColor = System.Drawing.Color.White;
            this.rbRestartCurrent.LanguageID = "DEF_Restart_Current_Process";
            this.rbRestartCurrent.Location = new System.Drawing.Point(13, 53);
            this.rbRestartCurrent.Name = "rbRestartCurrent";
            this.rbRestartCurrent.Size = new System.Drawing.Size(158, 16);
            this.rbRestartCurrent.TabIndex = 56;
            this.rbRestartCurrent.TabStop = true;
            this.rbRestartCurrent.Text = "Restart Current Process";
            this.rbRestartCurrent.UseVisualStyleBackColor = true;
            // 
            // rbStopCurrent
            // 
            this.rbStopCurrent.AutoSize = true;
            this.rbStopCurrent.Font = new System.Drawing.Font("굴림", 9F);
            this.rbStopCurrent.ForeColor = System.Drawing.Color.White;
            this.rbStopCurrent.LanguageID = "DEF_Stop_Current_Process";
            this.rbStopCurrent.Location = new System.Drawing.Point(13, 24);
            this.rbStopCurrent.Name = "rbStopCurrent";
            this.rbStopCurrent.Size = new System.Drawing.Size(144, 16);
            this.rbStopCurrent.TabIndex = 55;
            this.rbStopCurrent.TabStop = true;
            this.rbStopCurrent.Text = "Stop Current Process";
            this.rbStopCurrent.UseVisualStyleBackColor = true;
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.AutoSize = true;
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "DEF_Data_Clear";
            this.ctrlLabel1.Location = new System.Drawing.Point(17, 218);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(82, 13);
            this.ctrlLabel1.TabIndex = 27;
            this.ctrlLabel1.Text = "Data Clear";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataClearSave);
            this.groupBox1.Controls.Add(this.rbClearTrouble);
            this.groupBox1.Controls.Add(this.rbDataClear);
            this.groupBox1.Location = new System.Drawing.Point(11, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 91);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // DataClearSave
            // 
            this.DataClearSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.DataClearSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DataClearSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.DataClearSave.LabelText = "Save";
            this.DataClearSave.LanguageID = "DEF_Save";
            this.DataClearSave.Location = new System.Drawing.Point(211, 24);
            this.DataClearSave.Name = "DataClearSave";
            this.DataClearSave.Size = new System.Drawing.Size(89, 52);
            this.DataClearSave.TabIndex = 42;
            this.DataClearSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // rbClearTrouble
            // 
            this.rbClearTrouble.AutoSize = true;
            this.rbClearTrouble.ForeColor = System.Drawing.Color.White;
            this.rbClearTrouble.LanguageID = "DEF_Clear_Trouble";
            this.rbClearTrouble.Location = new System.Drawing.Point(13, 54);
            this.rbClearTrouble.Name = "rbClearTrouble";
            this.rbClearTrouble.Size = new System.Drawing.Size(101, 17);
            this.rbClearTrouble.TabIndex = 25;
            this.rbClearTrouble.TabStop = true;
            this.rbClearTrouble.Text = "Clear Trouble";
            this.rbClearTrouble.UseVisualStyleBackColor = true;
            // 
            // rbDataClear
            // 
            this.rbDataClear.AutoSize = true;
            this.rbDataClear.ForeColor = System.Drawing.Color.White;
            this.rbDataClear.LanguageID = "DEF_Clear_Information";
            this.rbDataClear.Location = new System.Drawing.Point(13, 26);
            this.rbDataClear.Name = "rbDataClear";
            this.rbDataClear.Size = new System.Drawing.Size(119, 17);
            this.rbDataClear.TabIndex = 24;
            this.rbDataClear.TabStop = true;
            this.rbDataClear.Text = "Clear Information";
            this.rbDataClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manual Command";
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
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.LanguageID = "DEF_Exit";
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(1047, 58);
            this.Exit.TabIndex = 2;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonitoringUI.Controlls.CtrlTitleBar titBar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox1;
        private MonitoringUI.Controlls.CButton.CtrlButton EqpControlSave;
        private Controlls.WindowsForms.CtrlRadioButton rbForceTrayUnload;
        private Controlls.WindowsForms.CtrlRadioButton rbResumePaused;
        private Controlls.WindowsForms.CtrlRadioButton rbPauseCurrent;
        private Controlls.WindowsForms.CtrlRadioButton rbRestartCurrent;
        private Controlls.WindowsForms.CtrlRadioButton rbStopCurrent;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MonitoringUI.Controlls.CButton.CtrlButton DataClearSave;
        private Controlls.WindowsForms.CtrlRadioButton rbClearTrouble;
        private Controlls.WindowsForms.CtrlRadioButton rbDataClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.Panel panel3;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
    }
}