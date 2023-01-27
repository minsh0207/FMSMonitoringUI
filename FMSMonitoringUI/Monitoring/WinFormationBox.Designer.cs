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
            this.ctrlRadioButton8 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton7 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton6 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton5 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConfigurationSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbNoIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataClearSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlRadioButton2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ctrlGroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel1);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel2);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
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
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton8);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton7);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton6);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton5);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton4);
            this.ctrlGroupBox1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold);
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
            // ctrlRadioButton8
            // 
            this.ctrlRadioButton8.AutoSize = true;
            this.ctrlRadioButton8.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlRadioButton8.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton8.LanguageID = "DEF_Force_Tray_Unload";
            this.ctrlRadioButton8.Location = new System.Drawing.Point(14, 131);
            this.ctrlRadioButton8.Name = "ctrlRadioButton8";
            this.ctrlRadioButton8.Size = new System.Drawing.Size(128, 16);
            this.ctrlRadioButton8.TabIndex = 66;
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
            this.ctrlRadioButton7.Location = new System.Drawing.Point(14, 104);
            this.ctrlRadioButton7.Name = "ctrlRadioButton7";
            this.ctrlRadioButton7.Size = new System.Drawing.Size(168, 16);
            this.ctrlRadioButton7.TabIndex = 65;
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
            this.ctrlRadioButton6.Location = new System.Drawing.Point(14, 77);
            this.ctrlRadioButton6.Name = "ctrlRadioButton6";
            this.ctrlRadioButton6.Size = new System.Drawing.Size(155, 16);
            this.ctrlRadioButton6.TabIndex = 64;
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
            this.ctrlRadioButton5.Location = new System.Drawing.Point(14, 50);
            this.ctrlRadioButton5.Name = "ctrlRadioButton5";
            this.ctrlRadioButton5.Size = new System.Drawing.Size(158, 16);
            this.ctrlRadioButton5.TabIndex = 63;
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
            this.ctrlRadioButton4.Location = new System.Drawing.Point(14, 26);
            this.ctrlRadioButton4.Name = "ctrlRadioButton4";
            this.ctrlRadioButton4.Size = new System.Drawing.Size(144, 16);
            this.ctrlRadioButton4.TabIndex = 62;
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
            this.ctrlLabel1.Location = new System.Drawing.Point(18, 316);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConfigurationSave);
            this.groupBox2.Controls.Add(this.rbNoIn);
            this.groupBox2.Controls.Add(this.rbYesIn);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 87);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // ConfigurationSave
            // 
            this.ConfigurationSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ConfigurationSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConfigurationSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ConfigurationSave.LabelText = "Save";
            this.ConfigurationSave.LanguageID = "DEF_Save";
            this.ConfigurationSave.Location = new System.Drawing.Point(223, 20);
            this.ConfigurationSave.Name = "ConfigurationSave";
            this.ConfigurationSave.Size = new System.Drawing.Size(89, 54);
            this.ConfigurationSave.TabIndex = 40;
            this.ConfigurationSave.Click += new System.EventHandler(this.Save_Click);
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
            this.rbYesIn.Location = new System.Drawing.Point(14, 29);
            this.rbYesIn.Name = "rbYesIn";
            this.rbYesIn.Size = new System.Drawing.Size(124, 17);
            this.rbYesIn.TabIndex = 32;
            this.rbYesIn.TabStop = true;
            this.rbYesIn.Text = "Enable Tray Load";
            this.rbYesIn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataClearSave);
            this.groupBox1.Controls.Add(this.ctrlRadioButton2);
            this.groupBox1.Controls.Add(this.ctrlRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 91);
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
            this.DataClearSave.Location = new System.Drawing.Point(223, 22);
            this.DataClearSave.Name = "DataClearSave";
            this.DataClearSave.Size = new System.Drawing.Size(89, 54);
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
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ctrlTitleBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 60);
            this.panel2.TabIndex = 4;
            // 
            // ctrlTitleBar
            // 
            this.ctrlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTitleBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar.LanguageID = "DEF_Formation_Box";
            this.ctrlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlTitleBar.Name = "ctrlTitleBar";
            this.ctrlTitleBar.Size = new System.Drawing.Size(1109, 58);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "Formation Box";
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton2;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controlls.WindowsForms.CtrlRadioButton rbNoIn;
        private Controlls.WindowsForms.CtrlRadioButton rbYesIn;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private MonitoringUI.Controlls.CButton.CtrlButton ConfigurationSave;
        private MonitoringUI.Controlls.CButton.CtrlButton DataClearSave;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox1;
        private MonitoringUI.Controlls.CButton.CtrlButton EqpControlSave;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton8;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton7;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton6;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton5;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton4;
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel3;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
    }
}