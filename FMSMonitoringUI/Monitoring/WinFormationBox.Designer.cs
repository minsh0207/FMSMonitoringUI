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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridEqpInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.gridTrayInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlButton2 = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbNoIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlButton4 = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlRadioButton2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.ctrlGroupBox1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.ctrlButton1 = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlRadioButton8 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton7 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton6 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton5 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ctrlGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ctrlTitleBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 65);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Exit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 466);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(905, 64);
            this.panel3.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridEqpInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(905, 401);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer2.Size = new System.Drawing.Size(629, 401);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlButton2);
            this.groupBox2.Controls.Add(this.rbNoIn);
            this.groupBox2.Controls.Add(this.rbYesIn);
            this.groupBox2.Location = new System.Drawing.Point(12, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 80);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlButton4);
            this.groupBox1.Controls.Add(this.ctrlRadioButton2);
            this.groupBox1.Controls.Add(this.ctrlRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 84);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manual Command";
            // 
            // gridEqpInfo
            // 
            this.gridEqpInfo.ColumnCount = -1;
            this.gridEqpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEqpInfo.Location = new System.Drawing.Point(0, 0);
            this.gridEqpInfo.Name = "gridEqpInfo";
            this.gridEqpInfo.RowCount = -1;
            this.gridEqpInfo.Size = new System.Drawing.Size(270, 399);
            this.gridEqpInfo.TabIndex = 1;
            // 
            // gridTrayInfo
            // 
            this.gridTrayInfo.ColumnCount = -1;
            this.gridTrayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrayInfo.Location = new System.Drawing.Point(0, 0);
            this.gridTrayInfo.Name = "gridTrayInfo";
            this.gridTrayInfo.RowCount = -1;
            this.gridTrayInfo.Size = new System.Drawing.Size(270, 399);
            this.gridTrayInfo.TabIndex = 1;
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.AutoSize = true;
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "";
            this.ctrlLabel1.Location = new System.Drawing.Point(18, 292);
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
            this.ctrlLabel2.LanguageID = "";
            this.ctrlLabel2.Location = new System.Drawing.Point(18, 33);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(102, 13);
            this.ctrlLabel2.TabIndex = 43;
            this.ctrlLabel2.Text = "Configuration";
            // 
            // ctrlButton2
            // 
            this.ctrlButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlButton2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButton2.LabelText = "Save";
            this.ctrlButton2.LanguageID = "";
            this.ctrlButton2.Location = new System.Drawing.Point(233, 20);
            this.ctrlButton2.Name = "ctrlButton2";
            this.ctrlButton2.Size = new System.Drawing.Size(78, 48);
            this.ctrlButton2.TabIndex = 40;
            // 
            // rbNoIn
            // 
            this.rbNoIn.AutoSize = true;
            this.rbNoIn.ForeColor = System.Drawing.Color.White;
            this.rbNoIn.LanguageID = "";
            this.rbNoIn.Location = new System.Drawing.Point(14, 52);
            this.rbNoIn.Name = "rbNoIn";
            this.rbNoIn.Size = new System.Drawing.Size(127, 16);
            this.rbNoIn.TabIndex = 33;
            this.rbNoIn.TabStop = true;
            this.rbNoIn.Text = "Disable Tray Load";
            this.rbNoIn.UseVisualStyleBackColor = true;
            // 
            // rbYesIn
            // 
            this.rbYesIn.AutoSize = true;
            this.rbYesIn.ForeColor = System.Drawing.Color.White;
            this.rbYesIn.LanguageID = "";
            this.rbYesIn.Location = new System.Drawing.Point(14, 27);
            this.rbYesIn.Name = "rbYesIn";
            this.rbYesIn.Size = new System.Drawing.Size(124, 16);
            this.rbYesIn.TabIndex = 32;
            this.rbYesIn.TabStop = true;
            this.rbYesIn.Text = "Enable Tray Load";
            this.rbYesIn.UseVisualStyleBackColor = true;
            // 
            // ctrlButton4
            // 
            this.ctrlButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlButton4.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButton4.LabelText = "Save";
            this.ctrlButton4.LanguageID = "";
            this.ctrlButton4.Location = new System.Drawing.Point(233, 23);
            this.ctrlButton4.Name = "ctrlButton4";
            this.ctrlButton4.Size = new System.Drawing.Size(78, 48);
            this.ctrlButton4.TabIndex = 42;
            // 
            // ctrlRadioButton2
            // 
            this.ctrlRadioButton2.AutoSize = true;
            this.ctrlRadioButton2.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton2.LanguageID = "";
            this.ctrlRadioButton2.Location = new System.Drawing.Point(14, 51);
            this.ctrlRadioButton2.Name = "ctrlRadioButton2";
            this.ctrlRadioButton2.Size = new System.Drawing.Size(104, 16);
            this.ctrlRadioButton2.TabIndex = 25;
            this.ctrlRadioButton2.TabStop = true;
            this.ctrlRadioButton2.Text = " Clear Trouble";
            this.ctrlRadioButton2.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton1
            // 
            this.ctrlRadioButton1.AutoSize = true;
            this.ctrlRadioButton1.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton1.LanguageID = "";
            this.ctrlRadioButton1.Location = new System.Drawing.Point(14, 25);
            this.ctrlRadioButton1.Name = "ctrlRadioButton1";
            this.ctrlRadioButton1.Size = new System.Drawing.Size(123, 16);
            this.ctrlRadioButton1.TabIndex = 24;
            this.ctrlRadioButton1.TabStop = true;
            this.ctrlRadioButton1.Text = " Clear Information";
            this.ctrlRadioButton1.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.LanguageID = "DEF_EXIT";
            this.Exit.Location = new System.Drawing.Point(411, 11);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(131, 41);
            this.Exit.TabIndex = 1;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ctrlTitleBar
            // 
            this.ctrlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTitleBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar.Name = "ctrlTitleBar";
            this.ctrlTitleBar.Size = new System.Drawing.Size(903, 63);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "Formation Box";
            // 
            // ctrlGroupBox1
            // 
            this.ctrlGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox1.Controls.Add(this.ctrlButton1);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton8);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton7);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton6);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton5);
            this.ctrlGroupBox1.Controls.Add(this.ctrlRadioButton4);
            this.ctrlGroupBox1.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox1.LanguageID = "";
            this.ctrlGroupBox1.Location = new System.Drawing.Point(12, 128);
            this.ctrlGroupBox1.Name = "ctrlGroupBox1";
            this.ctrlGroupBox1.Size = new System.Drawing.Size(325, 151);
            this.ctrlGroupBox1.TabIndex = 62;
            this.ctrlGroupBox1.TabStop = false;
            this.ctrlGroupBox1.Text = "Equipment Control";
            this.ctrlGroupBox1.TitleText = "Equipment Control";
            // 
            // ctrlButton1
            // 
            this.ctrlButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlButton1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButton1.LabelText = "Save";
            this.ctrlButton1.LanguageID = "";
            this.ctrlButton1.Location = new System.Drawing.Point(233, 34);
            this.ctrlButton1.Name = "ctrlButton1";
            this.ctrlButton1.Size = new System.Drawing.Size(78, 91);
            this.ctrlButton1.TabIndex = 67;
            // 
            // ctrlRadioButton8
            // 
            this.ctrlRadioButton8.AutoSize = true;
            this.ctrlRadioButton8.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton8.LanguageID = "";
            this.ctrlRadioButton8.Location = new System.Drawing.Point(14, 121);
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
            this.ctrlRadioButton7.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton7.LanguageID = "";
            this.ctrlRadioButton7.Location = new System.Drawing.Point(14, 96);
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
            this.ctrlRadioButton6.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton6.LanguageID = "";
            this.ctrlRadioButton6.Location = new System.Drawing.Point(14, 71);
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
            this.ctrlRadioButton5.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton5.LanguageID = "";
            this.ctrlRadioButton5.Location = new System.Drawing.Point(14, 46);
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
            this.ctrlRadioButton4.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton4.LanguageID = "";
            this.ctrlRadioButton4.Location = new System.Drawing.Point(14, 24);
            this.ctrlRadioButton4.Name = "ctrlRadioButton4";
            this.ctrlRadioButton4.Size = new System.Drawing.Size(144, 16);
            this.ctrlRadioButton4.TabIndex = 62;
            this.ctrlRadioButton4.TabStop = true;
            this.ctrlRadioButton4.Text = "Stop Current Process";
            this.ctrlRadioButton4.UseVisualStyleBackColor = true;
            // 
            // WinFormationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(905, 530);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinFormationBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinFormationBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WinFormationBox_Load);
            this.panel2.ResumeLayout(false);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ctrlGroupBox1.ResumeLayout(false);
            this.ctrlGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
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
        private Controlls.WindowsForms.CtrlRadioButton rbNoIn;
        private Controlls.WindowsForms.CtrlRadioButton rbYesIn;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private MonitoringUI.Controlls.CButton.CtrlButton ctrlButton2;
        private MonitoringUI.Controlls.CButton.CtrlButton ctrlButton4;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox1;
        private MonitoringUI.Controlls.CButton.CtrlButton ctrlButton1;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton8;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton7;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton6;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton5;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton4;
    }
}