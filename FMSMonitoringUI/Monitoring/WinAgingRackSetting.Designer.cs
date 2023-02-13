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
            this.ctrlGroupBox3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.DataClearSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbClearTrouble = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbClearInfo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlGroupBox2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.rbPlanTime = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbForceUnload = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.PlanTimeSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.dtPlanTime = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT();
            this.ctrlGroupBox1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.rbNoIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesIn = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.rbYesOut = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ConfigurationSave = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.rbNoOut = new FMSMonitoringUI.Controlls.WindowsForms.CtrlRadioButton();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ctrlGroupBox3.SuspendLayout();
            this.ctrlGroupBox2.SuspendLayout();
            this.ctrlGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_Aging_Rack_Information";
            this.titBar.Location = new System.Drawing.Point(2, 2);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(1126, 60);
            this.titBar.TabIndex = 1;
            this.titBar.TitleText = "Aging Rack Information";
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
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlGroupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel4);
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
            // ctrlGroupBox3
            // 
            this.ctrlGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox3.Controls.Add(this.DataClearSave);
            this.ctrlGroupBox3.Controls.Add(this.rbClearTrouble);
            this.ctrlGroupBox3.Controls.Add(this.rbClearInfo);
            this.ctrlGroupBox3.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox3.LanguageID = "DEF_Data_Clear";
            this.ctrlGroupBox3.Location = new System.Drawing.Point(12, 279);
            this.ctrlGroupBox3.Name = "ctrlGroupBox3";
            this.ctrlGroupBox3.Size = new System.Drawing.Size(338, 90);
            this.ctrlGroupBox3.TabIndex = 47;
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
            this.DataClearSave.Location = new System.Drawing.Point(248, 22);
            this.DataClearSave.Name = "DataClearSave";
            this.DataClearSave.Size = new System.Drawing.Size(78, 52);
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
            this.ctrlGroupBox2.Controls.Add(this.rbPlanTime);
            this.ctrlGroupBox2.Controls.Add(this.rbForceUnload);
            this.ctrlGroupBox2.Controls.Add(this.PlanTimeSave);
            this.ctrlGroupBox2.Controls.Add(this.dtPlanTime);
            this.ctrlGroupBox2.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox2.LanguageID = "DEF_Plan_Time";
            this.ctrlGroupBox2.Location = new System.Drawing.Point(12, 159);
            this.ctrlGroupBox2.Name = "ctrlGroupBox2";
            this.ctrlGroupBox2.Size = new System.Drawing.Size(338, 91);
            this.ctrlGroupBox2.TabIndex = 46;
            this.ctrlGroupBox2.TabStop = false;
            this.ctrlGroupBox2.Text = "Plan Time";
            this.ctrlGroupBox2.TitleText = "Plan Time";
            // 
            // rbPlanTime
            // 
            this.rbPlanTime.AutoSize = true;
            this.rbPlanTime.ForeColor = System.Drawing.Color.White;
            this.rbPlanTime.LanguageID = "DEF_Plan_Time";
            this.rbPlanTime.Location = new System.Drawing.Point(13, 54);
            this.rbPlanTime.Name = "rbPlanTime";
            this.rbPlanTime.Size = new System.Drawing.Size(80, 17);
            this.rbPlanTime.TabIndex = 47;
            this.rbPlanTime.TabStop = true;
            this.rbPlanTime.Text = "Plan Time";
            this.rbPlanTime.UseVisualStyleBackColor = true;
            // 
            // rbForceUnload
            // 
            this.rbForceUnload.AutoSize = true;
            this.rbForceUnload.ForeColor = System.Drawing.Color.White;
            this.rbForceUnload.LanguageID = "DEF_Force_Tray_Unload_now";
            this.rbForceUnload.Location = new System.Drawing.Point(13, 25);
            this.rbForceUnload.Name = "rbForceUnload";
            this.rbForceUnload.Size = new System.Drawing.Size(156, 17);
            this.rbForceUnload.TabIndex = 46;
            this.rbForceUnload.TabStop = true;
            this.rbForceUnload.Text = "Force Tray Unload now";
            this.rbForceUnload.UseVisualStyleBackColor = true;
            // 
            // PlanTimeSave
            // 
            this.PlanTimeSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.PlanTimeSave.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PlanTimeSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.PlanTimeSave.LabelText = "Save";
            this.PlanTimeSave.LanguageID = "DEF_Save";
            this.PlanTimeSave.Location = new System.Drawing.Point(248, 24);
            this.PlanTimeSave.Name = "PlanTimeSave";
            this.PlanTimeSave.Size = new System.Drawing.Size(78, 52);
            this.PlanTimeSave.TabIndex = 45;
            this.PlanTimeSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // dtPlanTime
            // 
            this.dtPlanTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.dtPlanTime.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtPlanTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.dtPlanTime.LanguageID = "DEF_CONTROL_001";
            this.dtPlanTime.Location = new System.Drawing.Point(100, 47);
            this.dtPlanTime.Name = "dtPlanTime";
            this.dtPlanTime.Size = new System.Drawing.Size(141, 29);
            this.dtPlanTime.StartTime = new System.DateTime(2022, 12, 22, 18, 9, 29, 104);
            this.dtPlanTime.TabIndex = 44;
            this.dtPlanTime.TitleText = "";
            this.dtPlanTime.TitleWidth = 140F;
            // 
            // ctrlGroupBox1
            // 
            this.ctrlGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox1.Controls.Add(this.rbNoIn);
            this.ctrlGroupBox1.Controls.Add(this.rbYesIn);
            this.ctrlGroupBox1.Controls.Add(this.rbYesOut);
            this.ctrlGroupBox1.Controls.Add(this.ConfigurationSave);
            this.ctrlGroupBox1.Controls.Add(this.rbNoOut);
            this.ctrlGroupBox1.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox1.LanguageID = "DEF_Configuration";
            this.ctrlGroupBox1.Location = new System.Drawing.Point(12, 49);
            this.ctrlGroupBox1.Name = "ctrlGroupBox1";
            this.ctrlGroupBox1.Size = new System.Drawing.Size(338, 85);
            this.ctrlGroupBox1.TabIndex = 45;
            this.ctrlGroupBox1.TabStop = false;
            this.ctrlGroupBox1.Text = "Configuration";
            this.ctrlGroupBox1.TitleText = "Configuration";
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
            // rbYesOut
            // 
            this.rbYesOut.AutoSize = true;
            this.rbYesOut.ForeColor = System.Drawing.Color.White;
            this.rbYesOut.LanguageID = "DEF_Enable_Tray_Unload";
            this.rbYesOut.Location = new System.Drawing.Point(13, 24);
            this.rbYesOut.Name = "rbYesOut";
            this.rbYesOut.Size = new System.Drawing.Size(135, 17);
            this.rbYesOut.TabIndex = 43;
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
            this.ConfigurationSave.Location = new System.Drawing.Point(248, 20);
            this.ConfigurationSave.Name = "ConfigurationSave";
            this.ConfigurationSave.Size = new System.Drawing.Size(78, 52);
            this.ConfigurationSave.TabIndex = 45;
            this.ConfigurationSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // rbNoOut
            // 
            this.rbNoOut.AutoSize = true;
            this.rbNoOut.ForeColor = System.Drawing.Color.White;
            this.rbNoOut.LanguageID = "DEF_Disable_Tray_Unload";
            this.rbNoOut.Location = new System.Drawing.Point(13, 54);
            this.rbNoOut.Name = "rbNoOut";
            this.rbNoOut.Size = new System.Drawing.Size(138, 17);
            this.rbNoOut.TabIndex = 44;
            this.rbNoOut.TabStop = true;
            this.rbNoOut.Text = "Disable Tray Unload";
            this.rbNoOut.UseVisualStyleBackColor = true;
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.AutoSize = true;
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_Manual_Command";
            this.ctrlLabel4.Location = new System.Drawing.Point(9, 10);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(138, 15);
            this.ctrlLabel4.TabIndex = 44;
            this.ctrlLabel4.Text = "Manual Command";
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinAgingRackSetting";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinAgingRackSetting";
            this.TopMost = true;
            this.WindowID = "WinAgingRackSetting";
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
            this.ctrlGroupBox3.ResumeLayout(false);
            this.ctrlGroupBox3.PerformLayout();
            this.ctrlGroupBox2.ResumeLayout(false);
            this.ctrlGroupBox2.PerformLayout();
            this.ctrlGroupBox1.ResumeLayout(false);
            this.ctrlGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
        private MonitoringUI.Controlls.CtrlTitleBar titBar;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel4;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox3;
        private MonitoringUI.Controlls.CButton.CtrlButton DataClearSave;
        private Controlls.WindowsForms.CtrlRadioButton rbClearTrouble;
        private Controlls.WindowsForms.CtrlRadioButton rbClearInfo;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox2;
        private Controlls.WindowsForms.CtrlRadioButton rbPlanTime;
        private Controlls.WindowsForms.CtrlRadioButton rbForceUnload;
        private MonitoringUI.Controlls.CButton.CtrlButton PlanTimeSave;
        private MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT dtPlanTime;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox1;
        private Controlls.WindowsForms.CtrlRadioButton rbNoIn;
        private Controlls.WindowsForms.CtrlRadioButton rbYesIn;
        private Controlls.WindowsForms.CtrlRadioButton rbYesOut;
        private MonitoringUI.Controlls.CButton.CtrlButton ConfigurationSave;
        private Controlls.WindowsForms.CtrlRadioButton rbNoOut;
    }
}