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
            this.ctrlRadioButton8 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton7 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton6 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton5 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataClearSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlRadioButton2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
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
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton8);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton7);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton6);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton5);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton4);
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
            // ctrlRadioButton8
            // 
            this.ctrlRadioButton8.AutoSize = true;
            this.ctrlRadioButton8.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlRadioButton8.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton8.LanguageID = "DEF_Force_Tray_Unload";
            this.ctrlRadioButton8.Location = new System.Drawing.Point(13, 134);
            this.ctrlRadioButton8.Name = "ctrlRadioButton8";
            this.ctrlRadioButton8.Size = new System.Drawing.Size(128, 16);
            this.ctrlRadioButton8.TabIndex = 59;
            this.ctrlRadioButton8.TabStop = true;
            this.ctrlRadioButton8.Text = "Force Tray Unload";
            this.ctrlRadioButton8.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton7
            // 
            this.ctrlRadioButton7.AutoSize = true;
            this.ctrlRadioButton7.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlRadioButton7.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton7.LanguageID = "DEF_Resume_Paused_Process";
            this.ctrlRadioButton7.Location = new System.Drawing.Point(13, 107);
            this.ctrlRadioButton7.Name = "ctrlRadioButton7";
            this.ctrlRadioButton7.Size = new System.Drawing.Size(168, 16);
            this.ctrlRadioButton7.TabIndex = 58;
            this.ctrlRadioButton7.TabStop = true;
            this.ctrlRadioButton7.Text = "Resume Paused Process";
            this.ctrlRadioButton7.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton6
            // 
            this.ctrlRadioButton6.AutoSize = true;
            this.ctrlRadioButton6.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlRadioButton6.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton6.LanguageID = "DEF_Pause_Current_Process";
            this.ctrlRadioButton6.Location = new System.Drawing.Point(13, 80);
            this.ctrlRadioButton6.Name = "ctrlRadioButton6";
            this.ctrlRadioButton6.Size = new System.Drawing.Size(155, 16);
            this.ctrlRadioButton6.TabIndex = 57;
            this.ctrlRadioButton6.TabStop = true;
            this.ctrlRadioButton6.Text = "Pause Current Process";
            this.ctrlRadioButton6.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton5
            // 
            this.ctrlRadioButton5.AutoSize = true;
            this.ctrlRadioButton5.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlRadioButton5.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton5.LanguageID = "DEF_Restart_Current_Process";
            this.ctrlRadioButton5.Location = new System.Drawing.Point(13, 53);
            this.ctrlRadioButton5.Name = "ctrlRadioButton5";
            this.ctrlRadioButton5.Size = new System.Drawing.Size(158, 16);
            this.ctrlRadioButton5.TabIndex = 56;
            this.ctrlRadioButton5.TabStop = true;
            this.ctrlRadioButton5.Text = "Restart Current Process";
            this.ctrlRadioButton5.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton4
            // 
            this.ctrlRadioButton4.AutoSize = true;
            this.ctrlRadioButton4.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlRadioButton4.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton4.LanguageID = "DEF_Stop_Current_Process";
            this.ctrlRadioButton4.Location = new System.Drawing.Point(13, 24);
            this.ctrlRadioButton4.Name = "ctrlRadioButton4";
            this.ctrlRadioButton4.Size = new System.Drawing.Size(144, 16);
            this.ctrlRadioButton4.TabIndex = 55;
            this.ctrlRadioButton4.TabStop = true;
            this.ctrlRadioButton4.Text = "Stop Current Process";
            this.ctrlRadioButton4.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.ctrlRadioButton2);
            this.groupBox1.Controls.Add(this.ctrlRadioButton1);
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
            // ctrlRadioButton2
            // 
            this.ctrlRadioButton2.AutoSize = true;
            this.ctrlRadioButton2.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton2.LanguageID = "DEF_Clear_Trouble";
            this.ctrlRadioButton2.Location = new System.Drawing.Point(13, 54);
            this.ctrlRadioButton2.Name = "ctrlRadioButton2";
            this.ctrlRadioButton2.Size = new System.Drawing.Size(101, 17);
            this.ctrlRadioButton2.TabIndex = 25;
            this.ctrlRadioButton2.TabStop = true;
            this.ctrlRadioButton2.Text = "Clear Trouble";
            this.ctrlRadioButton2.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton1
            // 
            this.ctrlRadioButton1.AutoSize = true;
            this.ctrlRadioButton1.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton1.LanguageID = "DEF_Clear_Information";
            this.ctrlRadioButton1.Location = new System.Drawing.Point(13, 26);
            this.ctrlRadioButton1.Name = "ctrlRadioButton1";
            this.ctrlRadioButton1.Size = new System.Drawing.Size(119, 17);
            this.ctrlRadioButton1.TabIndex = 24;
            this.ctrlRadioButton1.TabStop = true;
            this.ctrlRadioButton1.Text = "Clear Information";
            this.ctrlRadioButton1.UseVisualStyleBackColor = true;
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
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton8;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton7;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton6;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton5;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton4;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MonitoringUI.Controlls.CButton.CtrlButton DataClearSave;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton2;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.Panel panel3;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
    }
}