namespace FMSMonitoringUI.Monitoring
{
    partial class WinAgingRackSetting
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridEqpInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridTrayInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ctrlRadioButton4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.PlanTimeSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlDateTimeDT1 = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbNoIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesOut = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ConfigurationSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbNoOut = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataClearSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlRadioButton2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_Aging_Rack_Setting";
            this.titBar.Location = new System.Drawing.Point(2, 2);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(1126, 60);
            this.titBar.TabIndex = 1;
            this.titBar.TitleText = "Aging Rack Setting";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Exit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 453);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1126, 60);
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
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(1126, 391);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 2;
            // 
            // gridEqpInfo
            // 
            this.gridEqpInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridEqpInfo.ColumnCount = -1;
            this.gridEqpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEqpInfo.Location = new System.Drawing.Point(0, 0);
            this.gridEqpInfo.Name = "gridEqpInfo";
            this.gridEqpInfo.RowCount = -1;
            this.gridEqpInfo.Size = new System.Drawing.Size(312, 389);
            this.gridEqpInfo.TabIndex = 10;
            this.gridEqpInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridTrayInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel1);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel2);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(808, 391);
            this.splitContainer2.SplitterDistance = 439;
            this.splitContainer2.TabIndex = 3;
            // 
            // gridTrayInfo
            // 
            this.gridTrayInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridTrayInfo.ColumnCount = -1;
            this.gridTrayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrayInfo.Location = new System.Drawing.Point(0, 0);
            this.gridTrayInfo.Name = "gridTrayInfo";
            this.gridTrayInfo.RowCount = -1;
            this.gridTrayInfo.Size = new System.Drawing.Size(437, 389);
            this.gridTrayInfo.TabIndex = 1;
            this.gridTrayInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.AutoSize = true;
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "DEF_Data_Clear";
            this.ctrlLabel1.Location = new System.Drawing.Point(18, 250);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(82, 13);
            this.ctrlLabel1.TabIndex = 25;
            this.ctrlLabel1.Text = "Data Clear";
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.AutoSize = true;
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_Configuration";
            this.ctrlLabel2.Location = new System.Drawing.Point(18, 36);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(102, 13);
            this.ctrlLabel2.TabIndex = 43;
            this.ctrlLabel2.Text = "Configuration";
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.AutoSize = true;
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel3.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel3.LanguageID = "";
            this.ctrlLabel3.Location = new System.Drawing.Point(18, 139);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(78, 13);
            this.ctrlLabel3.TabIndex = 40;
            this.ctrlLabel3.Text = "Plan Time";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ctrlRadioButton4);
            this.groupBox3.Controls.Add(this.ctrlRadioButton3);
            this.groupBox3.Controls.Add(this.PlanTimeSave);
            this.groupBox3.Controls.Add(this.ctrlDateTimeDT1);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(12, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 87);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            // 
            // ctrlRadioButton4
            // 
            this.ctrlRadioButton4.AutoSize = true;
            this.ctrlRadioButton4.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton4.LanguageID = "DEF_Plan_Time";
            this.ctrlRadioButton4.Location = new System.Drawing.Point(14, 59);
            this.ctrlRadioButton4.Name = "ctrlRadioButton4";
            this.ctrlRadioButton4.Size = new System.Drawing.Size(80, 17);
            this.ctrlRadioButton4.TabIndex = 43;
            this.ctrlRadioButton4.TabStop = true;
            this.ctrlRadioButton4.Text = "Plan Time";
            this.ctrlRadioButton4.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton3
            // 
            this.ctrlRadioButton3.AutoSize = true;
            this.ctrlRadioButton3.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton3.LanguageID = "DEF_Force_Tray_Unload_now";
            this.ctrlRadioButton3.Location = new System.Drawing.Point(14, 30);
            this.ctrlRadioButton3.Name = "ctrlRadioButton3";
            this.ctrlRadioButton3.Size = new System.Drawing.Size(156, 17);
            this.ctrlRadioButton3.TabIndex = 42;
            this.ctrlRadioButton3.TabStop = true;
            this.ctrlRadioButton3.Text = "Force Tray Unload now";
            this.ctrlRadioButton3.UseVisualStyleBackColor = true;
            // 
            // PlanTimeSave
            // 
            this.PlanTimeSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.PlanTimeSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PlanTimeSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.PlanTimeSave.LabelText = "Save";
            this.PlanTimeSave.LanguageID = "DEF_Save";
            this.PlanTimeSave.Location = new System.Drawing.Point(249, 21);
            this.PlanTimeSave.Name = "PlanTimeSave";
            this.PlanTimeSave.Size = new System.Drawing.Size(78, 52);
            this.PlanTimeSave.TabIndex = 41;
            this.PlanTimeSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // ctrlDateTimeDT1
            // 
            this.ctrlDateTimeDT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlDateTimeDT1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlDateTimeDT1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ctrlDateTimeDT1.LanguageID = "DEF_CONTROL_001";
            this.ctrlDateTimeDT1.Location = new System.Drawing.Point(101, 52);
            this.ctrlDateTimeDT1.Name = "ctrlDateTimeDT1";
            this.ctrlDateTimeDT1.Size = new System.Drawing.Size(141, 29);
            this.ctrlDateTimeDT1.StartTime = new System.DateTime(2022, 12, 22, 18, 9, 29, 104);
            this.ctrlDateTimeDT1.TabIndex = 38;
            this.ctrlDateTimeDT1.TitleText = "";
            this.ctrlDateTimeDT1.TitleWidth = 140F;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbNoIn);
            this.groupBox2.Controls.Add(this.rbYesIn);
            this.groupBox2.Controls.Add(this.rbYesOut);
            this.groupBox2.Controls.Add(this.ConfigurationSave);
            this.groupBox2.Controls.Add(this.rbNoOut);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 87);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // rbNoIn
            // 
            this.rbNoIn.AutoSize = true;
            this.rbNoIn.ForeColor = System.Drawing.Color.White;
            this.rbNoIn.LanguageID = "DEF_Disable_Tray_Load";
            this.rbNoIn.Location = new System.Drawing.Point(14, 56);
            this.rbNoIn.Name = "rbNoIn";
            this.rbNoIn.Size = new System.Drawing.Size(127, 17);
            this.rbNoIn.TabIndex = 33;
            this.rbNoIn.TabStop = true;
            this.rbNoIn.Text = "Disable Tray Load";
            this.rbNoIn.UseVisualStyleBackColor = true;
            // 
            // rbYesIn
            // 
            this.rbYesIn.AutoSize = true;
            this.rbYesIn.ForeColor = System.Drawing.Color.White;
            this.rbYesIn.LanguageID = "DEF_Enable_Tray_Load";
            this.rbYesIn.Location = new System.Drawing.Point(14, 26);
            this.rbYesIn.Name = "rbYesIn";
            this.rbYesIn.Size = new System.Drawing.Size(124, 17);
            this.rbYesIn.TabIndex = 32;
            this.rbYesIn.TabStop = true;
            this.rbYesIn.Text = "Enable Tray Load";
            this.rbYesIn.UseVisualStyleBackColor = true;
            // 
            // rbYesOut
            // 
            this.rbYesOut.AutoSize = true;
            this.rbYesOut.ForeColor = System.Drawing.Color.White;
            this.rbYesOut.LanguageID = "DEF_Enable_Tray_Unload";
            this.rbYesOut.Location = new System.Drawing.Point(14, 26);
            this.rbYesOut.Name = "rbYesOut";
            this.rbYesOut.Size = new System.Drawing.Size(135, 17);
            this.rbYesOut.TabIndex = 34;
            this.rbYesOut.TabStop = true;
            this.rbYesOut.Text = "Enable Tray Unload";
            this.rbYesOut.UseVisualStyleBackColor = true;
            // 
            // ConfigurationSave
            // 
            this.ConfigurationSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ConfigurationSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConfigurationSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ConfigurationSave.LabelText = "Save";
            this.ConfigurationSave.LanguageID = "DEF_Save";
            this.ConfigurationSave.Location = new System.Drawing.Point(249, 22);
            this.ConfigurationSave.Name = "ConfigurationSave";
            this.ConfigurationSave.Size = new System.Drawing.Size(78, 52);
            this.ConfigurationSave.TabIndex = 40;
            this.ConfigurationSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // rbNoOut
            // 
            this.rbNoOut.AutoSize = true;
            this.rbNoOut.ForeColor = System.Drawing.Color.White;
            this.rbNoOut.LanguageID = "DEF_Disable_Tray_Unload";
            this.rbNoOut.Location = new System.Drawing.Point(14, 56);
            this.rbNoOut.Name = "rbNoOut";
            this.rbNoOut.Size = new System.Drawing.Size(138, 17);
            this.rbNoOut.TabIndex = 35;
            this.rbNoOut.TabStop = true;
            this.rbNoOut.Text = "Disable Tray Unload";
            this.rbNoOut.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataClearSave);
            this.groupBox1.Controls.Add(this.ctrlRadioButton2);
            this.groupBox1.Controls.Add(this.ctrlRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 87);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // DataClearSave
            // 
            this.DataClearSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.DataClearSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DataClearSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.DataClearSave.LabelText = "Save";
            this.DataClearSave.LanguageID = "DEF_Save";
            this.DataClearSave.Location = new System.Drawing.Point(249, 22);
            this.DataClearSave.Name = "DataClearSave";
            this.DataClearSave.Size = new System.Drawing.Size(78, 52);
            this.DataClearSave.TabIndex = 42;
            this.DataClearSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // ctrlRadioButton2
            // 
            this.ctrlRadioButton2.AutoSize = true;
            this.ctrlRadioButton2.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton2.LanguageID = "DEF_Clear_Trouble";
            this.ctrlRadioButton2.Location = new System.Drawing.Point(14, 55);
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
            this.ctrlRadioButton1.Location = new System.Drawing.Point(14, 27);
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
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manual Command";
            // 
            // WinAgingRackSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1130, 536);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.titBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinAgingRackSetting";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinAgingRackSetting";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinAgingRackSetting_FormClosed);
            this.Load += new System.EventHandler(this.WinAgingRackSetting_Load);
            this.Controls.SetChildIndex(this.titBar, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private System.Windows.Forms.Label label1;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton2;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controlls.WindowsForms.CtrlRadioButton rbNoOut;
        private Controlls.WindowsForms.CtrlRadioButton rbYesOut;
        private Controlls.WindowsForms.CtrlRadioButton rbNoIn;
        private Controlls.WindowsForms.CtrlRadioButton rbYesIn;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT ctrlDateTimeDT1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private MonitoringUI.Controlls.CButton.CtrlButton PlanTimeSave;
        private MonitoringUI.Controlls.CButton.CtrlButton ConfigurationSave;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton3;
        private MonitoringUI.Controlls.CButton.CtrlButton DataClearSave;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton4;
        private MonitoringUI.Controlls.CtrlTitleBar titBar;
    }
}