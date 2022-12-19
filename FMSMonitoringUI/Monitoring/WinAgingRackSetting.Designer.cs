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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridRackInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.cboRouteID = new MonitoringUI.Controlls.CComboBox.CtrlComboBox();
            this.cboModelID = new MonitoringUI.Controlls.CComboBox.CtrlComboBox();
            this.ctrlRadioButton3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlRadioButton1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlDateTimeDT1 = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT();
            this.rbNoOut = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesOut = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbNoIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlLavel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLavel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlButtonSave1 = new MonitoringUI.Controlls.CButton.CtrlButtonSave();
            this.ctrlButtonExit1 = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.ctrlButton1 = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ctrlTitleBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 65);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ctrlButton1);
            this.panel3.Controls.Add(this.ctrlButtonSave1);
            this.panel3.Controls.Add(this.ctrlButtonExit1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 479);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(929, 64);
            this.panel3.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.gridRackInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlLabel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlDateTimeDT1);
            this.splitContainer1.Panel2.Controls.Add(this.rbNoOut);
            this.splitContainer1.Panel2.Controls.Add(this.rbYesOut);
            this.splitContainer1.Panel2.Controls.Add(this.rbNoIn);
            this.splitContainer1.Panel2.Controls.Add(this.rbYesIn);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlLavel2);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlLavel1);
            this.splitContainer1.Size = new System.Drawing.Size(929, 414);
            this.splitContainer1.SplitterDistance = 342;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rack Info";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboRouteID);
            this.groupBox2.Controls.Add(this.cboModelID);
            this.groupBox2.Location = new System.Drawing.Point(66, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 53);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlRadioButton3);
            this.groupBox1.Controls.Add(this.ctrlRadioButton2);
            this.groupBox1.Controls.Add(this.ctrlRadioButton1);
            this.groupBox1.Controls.Add(this.ctrlLabel2);
            this.groupBox1.Location = new System.Drawing.Point(34, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 64);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // gridRackInfo
            // 
            this.gridRackInfo.ColumnCount = -1;
            this.gridRackInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridRackInfo.Location = new System.Drawing.Point(0, 45);
            this.gridRackInfo.Name = "gridRackInfo";
            this.gridRackInfo.RowCount = -1;
            this.gridRackInfo.Size = new System.Drawing.Size(340, 367);
            this.gridRackInfo.TabIndex = 1;
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "";
            this.ctrlLabel1.Location = new System.Drawing.Point(72, 129);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(88, 12);
            this.ctrlLabel1.TabIndex = 32;
            this.ctrlLabel1.Text = "Load Available";
            // 
            // cboRouteID
            // 
            this.cboRouteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.cboRouteID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboRouteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboRouteID.LanguageID = "";
            this.cboRouteID.Location = new System.Drawing.Point(263, 19);
            this.cboRouteID.Name = "cboRouteID";
            this.cboRouteID.SelectedIndex = -1;
            this.cboRouteID.SelectedItem = null;
            this.cboRouteID.SelectedKeyString = "";
            this.cboRouteID.Size = new System.Drawing.Size(189, 27);
            this.cboRouteID.TabIndex = 37;
            this.cboRouteID.TitleText = "Route ID";
            // 
            // cboModelID
            // 
            this.cboModelID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.cboModelID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboModelID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboModelID.LanguageID = "";
            this.cboModelID.Location = new System.Drawing.Point(20, 19);
            this.cboModelID.Name = "cboModelID";
            this.cboModelID.SelectedIndex = -1;
            this.cboModelID.SelectedItem = null;
            this.cboModelID.SelectedKeyString = "";
            this.cboModelID.Size = new System.Drawing.Size(189, 27);
            this.cboModelID.TabIndex = 36;
            this.cboModelID.TitleText = "Model ID";
            // 
            // ctrlRadioButton3
            // 
            this.ctrlRadioButton3.AutoSize = true;
            this.ctrlRadioButton3.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton3.LanguageID = "";
            this.ctrlRadioButton3.Location = new System.Drawing.Point(356, 28);
            this.ctrlRadioButton3.Name = "ctrlRadioButton3";
            this.ctrlRadioButton3.Size = new System.Drawing.Size(115, 16);
            this.ctrlRadioButton3.TabIndex = 47;
            this.ctrlRadioButton3.TabStop = true;
            this.ctrlRadioButton3.Text = "Clear Fire Alarm";
            this.ctrlRadioButton3.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton2
            // 
            this.ctrlRadioButton2.AutoSize = true;
            this.ctrlRadioButton2.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton2.LanguageID = "";
            this.ctrlRadioButton2.Location = new System.Drawing.Point(174, 28);
            this.ctrlRadioButton2.Name = "ctrlRadioButton2";
            this.ctrlRadioButton2.Size = new System.Drawing.Size(137, 16);
            this.ctrlRadioButton2.TabIndex = 46;
            this.ctrlRadioButton2.TabStop = true;
            this.ctrlRadioButton2.Text = "Clear Trouble Alarm";
            this.ctrlRadioButton2.UseVisualStyleBackColor = true;
            // 
            // ctrlRadioButton1
            // 
            this.ctrlRadioButton1.AutoSize = true;
            this.ctrlRadioButton1.ForeColor = System.Drawing.Color.White;
            this.ctrlRadioButton1.LanguageID = "";
            this.ctrlRadioButton1.Location = new System.Drawing.Point(11, 28);
            this.ctrlRadioButton1.Name = "ctrlRadioButton1";
            this.ctrlRadioButton1.Size = new System.Drawing.Size(109, 16);
            this.ctrlRadioButton1.TabIndex = 45;
            this.ctrlRadioButton1.TabStop = true;
            this.ctrlRadioButton1.Text = "Clear Rack Info";
            this.ctrlRadioButton1.UseVisualStyleBackColor = true;
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "";
            this.ctrlLabel2.Location = new System.Drawing.Point(8, 2);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(111, 13);
            this.ctrlLabel2.TabIndex = 37;
            this.ctrlLabel2.Text = "Clear Command";
            // 
            // ctrlDateTimeDT1
            // 
            this.ctrlDateTimeDT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlDateTimeDT1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlDateTimeDT1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ctrlDateTimeDT1.LanguageID = "DEF_CONTROL_001";
            this.ctrlDateTimeDT1.Location = new System.Drawing.Point(30, 194);
            this.ctrlDateTimeDT1.Name = "ctrlDateTimeDT1";
            this.ctrlDateTimeDT1.Size = new System.Drawing.Size(253, 27);
            this.ctrlDateTimeDT1.StartTime = new System.DateTime(2022, 12, 22, 18, 9, 29, 104);
            this.ctrlDateTimeDT1.TabIndex = 36;
            this.ctrlDateTimeDT1.TitleText = "Plan Time";
            // 
            // rbNoOut
            // 
            this.rbNoOut.AutoSize = true;
            this.rbNoOut.ForeColor = System.Drawing.Color.White;
            this.rbNoOut.LanguageID = "";
            this.rbNoOut.Location = new System.Drawing.Point(222, 96);
            this.rbNoOut.Name = "rbNoOut";
            this.rbNoOut.Size = new System.Drawing.Size(108, 16);
            this.rbNoOut.TabIndex = 31;
            this.rbNoOut.TabStop = true;
            this.rbNoOut.Text = "Unload Prohibit";
            this.rbNoOut.UseVisualStyleBackColor = true;
            // 
            // rbYesOut
            // 
            this.rbYesOut.AutoSize = true;
            this.rbYesOut.ForeColor = System.Drawing.Color.White;
            this.rbYesOut.LanguageID = "";
            this.rbYesOut.Location = new System.Drawing.Point(59, 96);
            this.rbYesOut.Name = "rbYesOut";
            this.rbYesOut.Size = new System.Drawing.Size(117, 16);
            this.rbYesOut.TabIndex = 30;
            this.rbYesOut.TabStop = true;
            this.rbYesOut.Text = "Unload Available";
            this.rbYesOut.UseVisualStyleBackColor = true;
            // 
            // rbNoIn
            // 
            this.rbNoIn.AutoSize = true;
            this.rbNoIn.ForeColor = System.Drawing.Color.White;
            this.rbNoIn.LanguageID = "";
            this.rbNoIn.Location = new System.Drawing.Point(222, 71);
            this.rbNoIn.Name = "rbNoIn";
            this.rbNoIn.Size = new System.Drawing.Size(97, 16);
            this.rbNoIn.TabIndex = 29;
            this.rbNoIn.TabStop = true;
            this.rbNoIn.Text = "Load Prohibit";
            this.rbNoIn.UseVisualStyleBackColor = true;
            // 
            // rbYesIn
            // 
            this.rbYesIn.AutoSize = true;
            this.rbYesIn.ForeColor = System.Drawing.Color.White;
            this.rbYesIn.LanguageID = "";
            this.rbYesIn.Location = new System.Drawing.Point(59, 71);
            this.rbYesIn.Name = "rbYesIn";
            this.rbYesIn.Size = new System.Drawing.Size(106, 16);
            this.rbYesIn.TabIndex = 28;
            this.rbYesIn.TabStop = true;
            this.rbYesIn.Text = "Load Available";
            this.rbYesIn.UseVisualStyleBackColor = true;
            // 
            // ctrlLavel2
            // 
            this.ctrlLavel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLavel2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLavel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLavel2.LanguageID = "";
            this.ctrlLavel2.Location = new System.Drawing.Point(32, 45);
            this.ctrlLavel2.Name = "ctrlLavel2";
            this.ctrlLavel2.Size = new System.Drawing.Size(160, 23);
            this.ctrlLavel2.TabIndex = 27;
            this.ctrlLavel2.Text = "Rack Use Command";
            // 
            // ctrlLavel1
            // 
            this.ctrlLavel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLavel1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLavel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLavel1.LanguageID = "";
            this.ctrlLavel1.Location = new System.Drawing.Point(13, 13);
            this.ctrlLavel1.Name = "ctrlLavel1";
            this.ctrlLavel1.Size = new System.Drawing.Size(236, 23);
            this.ctrlLavel1.TabIndex = 26;
            this.ctrlLavel1.Text = "Configuration";
            // 
            // ctrlButtonSave1
            // 
            this.ctrlButtonSave1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonSave1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonSave1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonSave1.LabelText = "strSave";
            this.ctrlButtonSave1.Location = new System.Drawing.Point(333, 9);
            this.ctrlButtonSave1.Name = "ctrlButtonSave1";
            this.ctrlButtonSave1.Size = new System.Drawing.Size(127, 42);
            this.ctrlButtonSave1.TabIndex = 3;
            // 
            // ctrlButtonExit1
            // 
            this.ctrlButtonExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonExit1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonExit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonExit1.LabelText = "Exit";
            this.ctrlButtonExit1.Location = new System.Drawing.Point(482, 9);
            this.ctrlButtonExit1.Name = "ctrlButtonExit1";
            this.ctrlButtonExit1.Size = new System.Drawing.Size(127, 42);
            this.ctrlButtonExit1.TabIndex = 2;
            this.ctrlButtonExit1.Click += new System.EventHandler(this.ctrlButtonExit1_Click);
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
            this.ctrlTitleBar.Size = new System.Drawing.Size(927, 63);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "Aging Rack Setting";
            // 
            // ctrlButton1
            // 
            this.ctrlButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlButton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlButton1.Enabled = false;
            this.ctrlButton1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButton1.LabelText = "Exit";
            this.ctrlButton1.LanguageID = "";
            this.ctrlButton1.Location = new System.Drawing.Point(675, 9);
            this.ctrlButton1.Name = "ctrlButton1";
            this.ctrlButton1.Size = new System.Drawing.Size(127, 42);
            this.ctrlButton1.TabIndex = 4;
            this.ctrlButton1.Visible = false;
            // 
            // WinAgingRackSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(929, 543);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinAgingRackSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinAgingRackSetting";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WinAgingRackSetting_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel3;
        private MonitoringUI.Controlls.CButton.CtrlButtonSave ctrlButtonSave1;
        private MonitoringUI.Controlls.CButton.CtrlButtonExit ctrlButtonExit1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridRackInfo;
        private Controlls.WindowsForms.CtrlLabel ctrlLavel1;
        private Controlls.WindowsForms.CtrlLabel ctrlLavel2;
        private Controlls.WindowsForms.CtrlRadioButton rbYesIn;
        private Controlls.WindowsForms.CtrlRadioButton rbNoOut;
        private Controlls.WindowsForms.CtrlRadioButton rbYesOut;
        private Controlls.WindowsForms.CtrlRadioButton rbNoIn;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT ctrlDateTimeDT1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton3;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton2;
        private Controlls.WindowsForms.CtrlRadioButton ctrlRadioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MonitoringUI.Controlls.CComboBox.CtrlComboBox cboRouteID;
        private MonitoringUI.Controlls.CComboBox.CtrlComboBox cboModelID;
        private System.Windows.Forms.Label label1;
        private MonitoringUI.Controlls.CButton.CtrlButton ctrlButton1;
    }
}