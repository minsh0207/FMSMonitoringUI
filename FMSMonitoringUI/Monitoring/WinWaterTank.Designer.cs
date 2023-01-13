namespace FMSMonitoringUI.Monitoring
{
    partial class WinWaterTank
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbFMS = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.lbTrayID2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.lbTrayID1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.lbTrayCount = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.gridWaterTank = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.gbWaterTank = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.ledRestockPressed = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ledFireSensor = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ledStationSink = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlLabel3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ledTrayExist = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlLabel6 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ledInputEnable = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlLabel5 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.uiTlbMode = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbFMS.SuspendLayout();
            this.gbWaterTank.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ctrlTitleBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 60);
            this.panel1.TabIndex = 0;
            // 
            // ctrlTitleBar
            // 
            this.ctrlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ctrlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTitleBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar.LanguageID = "DEF_WaterTank_Information";
            this.ctrlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar.Name = "ctrlTitleBar";
            this.ctrlTitleBar.Size = new System.Drawing.Size(657, 60);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "WaterTank Information";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 60);
            this.panel2.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.Location = new System.Drawing.Point(260, 9);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(160, 40);
            this.Exit.TabIndex = 0;
            this.Exit.Click += new System.EventHandler(this.ctrlButtonExit1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gbFMS);
            this.panel3.Controls.Add(this.gbWaterTank);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(657, 329);
            this.panel3.TabIndex = 2;
            // 
            // gbFMS
            // 
            this.gbFMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.gbFMS.Controls.Add(this.lbTrayID2);
            this.gbFMS.Controls.Add(this.lbTrayID1);
            this.gbFMS.Controls.Add(this.lbTrayCount);
            this.gbFMS.Controls.Add(this.gridWaterTank);
            this.gbFMS.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbFMS.ForeColor = System.Drawing.Color.White;
            this.gbFMS.LanguageID = "DEF_FMS";
            this.gbFMS.Location = new System.Drawing.Point(373, 16);
            this.gbFMS.Name = "gbFMS";
            this.gbFMS.Size = new System.Drawing.Size(257, 290);
            this.gbFMS.TabIndex = 3;
            this.gbFMS.TabStop = false;
            this.gbFMS.Text = "FMS";
            this.gbFMS.TitleText = "FMS";
            // 
            // lbTrayID2
            // 
            this.lbTrayID2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.lbTrayID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrayID2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTrayID2.LanguageID = "DEF_Tray_ID_2";
            this.lbTrayID2.Location = new System.Drawing.Point(12, 85);
            this.lbTrayID2.Margin = new System.Windows.Forms.Padding(39, 32, 39, 32);
            this.lbTrayID2.Name = "lbTrayID2";
            this.lbTrayID2.Size = new System.Drawing.Size(232, 28);
            this.lbTrayID2.TabIndex = 60;
            this.lbTrayID2.Tag = "WaterTank.TrayIdL2";
            this.lbTrayID2.TextData = "";
            this.lbTrayID2.TitleText = "Tray ID 2 ";
            this.lbTrayID2.TitleWidth = 110F;
            // 
            // lbTrayID1
            // 
            this.lbTrayID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.lbTrayID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrayID1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTrayID1.LanguageID = "DEF_Tray_ID_1";
            this.lbTrayID1.Location = new System.Drawing.Point(12, 54);
            this.lbTrayID1.Margin = new System.Windows.Forms.Padding(39, 32, 39, 32);
            this.lbTrayID1.Name = "lbTrayID1";
            this.lbTrayID1.Size = new System.Drawing.Size(232, 28);
            this.lbTrayID1.TabIndex = 59;
            this.lbTrayID1.Tag = "WaterTank.TrayIdL1";
            this.lbTrayID1.TextData = "";
            this.lbTrayID1.TitleText = "Tray ID 1 ";
            this.lbTrayID1.TitleWidth = 110F;
            // 
            // lbTrayCount
            // 
            this.lbTrayCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.lbTrayCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrayCount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTrayCount.LanguageID = "DEF_Tray_Count";
            this.lbTrayCount.Location = new System.Drawing.Point(12, 23);
            this.lbTrayCount.Margin = new System.Windows.Forms.Padding(39, 32, 39, 32);
            this.lbTrayCount.Name = "lbTrayCount";
            this.lbTrayCount.Size = new System.Drawing.Size(232, 28);
            this.lbTrayCount.TabIndex = 58;
            this.lbTrayCount.Tag = "WaterTank.TrayCount";
            this.lbTrayCount.TextData = "";
            this.lbTrayCount.TitleText = "Tray Count ";
            this.lbTrayCount.TitleWidth = 110F;
            // 
            // gridWaterTank
            // 
            this.gridWaterTank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.gridWaterTank.ColumnCount = -1;
            this.gridWaterTank.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gridWaterTank.Location = new System.Drawing.Point(12, 124);
            this.gridWaterTank.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridWaterTank.Name = "gridWaterTank";
            this.gridWaterTank.RowCount = -1;
            this.gridWaterTank.Size = new System.Drawing.Size(232, 150);
            this.gridWaterTank.TabIndex = 57;
            this.gridWaterTank.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            // 
            // gbWaterTank
            // 
            this.gbWaterTank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.gbWaterTank.Controls.Add(this.ledRestockPressed);
            this.gbWaterTank.Controls.Add(this.ctrlLabel1);
            this.gbWaterTank.Controls.Add(this.ledFireSensor);
            this.gbWaterTank.Controls.Add(this.ctrlLabel2);
            this.gbWaterTank.Controls.Add(this.ledStationSink);
            this.gbWaterTank.Controls.Add(this.ctrlLabel3);
            this.gbWaterTank.Controls.Add(this.ledTrayExist);
            this.gbWaterTank.Controls.Add(this.ctrlLabel6);
            this.gbWaterTank.Controls.Add(this.ledInputEnable);
            this.gbWaterTank.Controls.Add(this.ctrlLabel5);
            this.gbWaterTank.Controls.Add(this.ctrlLabel4);
            this.gbWaterTank.Controls.Add(this.uiTlbMode);
            this.gbWaterTank.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbWaterTank.ForeColor = System.Drawing.Color.White;
            this.gbWaterTank.LanguageID = "DEF_Water_Tank";
            this.gbWaterTank.Location = new System.Drawing.Point(24, 16);
            this.gbWaterTank.Name = "gbWaterTank";
            this.gbWaterTank.Size = new System.Drawing.Size(321, 290);
            this.gbWaterTank.TabIndex = 2;
            this.gbWaterTank.TabStop = false;
            this.gbWaterTank.Text = "Water Tank";
            this.gbWaterTank.TitleText = "Water Tank";
            // 
            // ledRestockPressed
            // 
            this.ledRestockPressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ledRestockPressed.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledRestockPressed.Location = new System.Drawing.Point(156, 244);
            this.ledRestockPressed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledRestockPressed.Name = "ledRestockPressed";
            this.ledRestockPressed.Size = new System.Drawing.Size(104, 14);
            this.ledRestockPressed.TabIndex = 80;
            this.ledRestockPressed.Tag = "WaterTank.RestockButtonPressed";
            this.ledRestockPressed.TitleText = "";
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ctrlLabel1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "DEF_RestockButtonPressed";
            this.ctrlLabel1.Location = new System.Drawing.Point(16, 241);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(140, 22);
            this.ctrlLabel1.TabIndex = 79;
            this.ctrlLabel1.Text = "RestockButtonPressed :";
            this.ctrlLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledFireSensor
            // 
            this.ledFireSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ledFireSensor.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledFireSensor.Location = new System.Drawing.Point(156, 220);
            this.ledFireSensor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledFireSensor.Name = "ledFireSensor";
            this.ledFireSensor.Size = new System.Drawing.Size(104, 14);
            this.ledFireSensor.TabIndex = 78;
            this.ledFireSensor.Tag = "WaterTank.FireSensor";
            this.ledFireSensor.TitleText = "";
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ctrlLabel2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_Fire_Sensor";
            this.ctrlLabel2.Location = new System.Drawing.Point(16, 217);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(140, 22);
            this.ctrlLabel2.TabIndex = 77;
            this.ctrlLabel2.Text = "Fire Sensor :";
            this.ctrlLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledStationSink
            // 
            this.ledStationSink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ledStationSink.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledStationSink.Location = new System.Drawing.Point(156, 196);
            this.ledStationSink.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledStationSink.Name = "ledStationSink";
            this.ledStationSink.Size = new System.Drawing.Size(104, 14);
            this.ledStationSink.TabIndex = 76;
            this.ledStationSink.Tag = "WaterTank.StationSink";
            this.ledStationSink.TitleText = "";
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ctrlLabel3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel3.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel3.LanguageID = "DEF_Station_Sink";
            this.ctrlLabel3.Location = new System.Drawing.Point(16, 193);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(140, 22);
            this.ctrlLabel3.TabIndex = 75;
            this.ctrlLabel3.Text = "Station Sink :";
            this.ctrlLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledTrayExist
            // 
            this.ledTrayExist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ledTrayExist.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledTrayExist.Location = new System.Drawing.Point(156, 151);
            this.ledTrayExist.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledTrayExist.Name = "ledTrayExist";
            this.ledTrayExist.Size = new System.Drawing.Size(104, 14);
            this.ledTrayExist.TabIndex = 74;
            this.ledTrayExist.Tag = "WaterTank.TrayExist";
            this.ledTrayExist.TitleText = "";
            // 
            // ctrlLabel6
            // 
            this.ctrlLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ctrlLabel6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel6.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel6.LanguageID = "DEF_Tray_Exist";
            this.ctrlLabel6.Location = new System.Drawing.Point(16, 147);
            this.ctrlLabel6.Name = "ctrlLabel6";
            this.ctrlLabel6.Size = new System.Drawing.Size(140, 22);
            this.ctrlLabel6.TabIndex = 73;
            this.ctrlLabel6.Text = "Tray Exist :";
            this.ctrlLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledInputEnable
            // 
            this.ledInputEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ledInputEnable.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledInputEnable.Location = new System.Drawing.Point(156, 126);
            this.ledInputEnable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledInputEnable.Name = "ledInputEnable";
            this.ledInputEnable.Size = new System.Drawing.Size(104, 14);
            this.ledInputEnable.TabIndex = 72;
            this.ledInputEnable.Tag = "WaterTank.InputEnable";
            this.ledInputEnable.TitleText = "";
            // 
            // ctrlLabel5
            // 
            this.ctrlLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ctrlLabel5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel5.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel5.LanguageID = "DEF_Input_Enable";
            this.ctrlLabel5.Location = new System.Drawing.Point(16, 123);
            this.ctrlLabel5.Name = "ctrlLabel5";
            this.ctrlLabel5.Size = new System.Drawing.Size(140, 22);
            this.ctrlLabel5.TabIndex = 71;
            this.ctrlLabel5.Text = "Input Enable :";
            this.ctrlLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ctrlLabel4.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_Control_Mode";
            this.ctrlLabel4.Location = new System.Drawing.Point(16, 23);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(140, 22);
            this.ctrlLabel4.TabIndex = 70;
            this.ctrlLabel4.Text = "Control Mode :";
            this.ctrlLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiTlbMode
            // 
            this.uiTlbMode.AutoSize = true;
            this.uiTlbMode.ColumnCount = 1;
            this.uiTlbMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.uiTlbMode.Font = new System.Drawing.Font("굴림", 9F);
            this.uiTlbMode.Location = new System.Drawing.Point(153, 22);
            this.uiTlbMode.Name = "uiTlbMode";
            this.uiTlbMode.RowCount = 3;
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.uiTlbMode.Size = new System.Drawing.Size(163, 66);
            this.uiTlbMode.TabIndex = 69;
            // 
            // WinWaterTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(657, 449);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinWaterTank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinWaterTank_FormClosed);
            this.Load += new System.EventHandler(this.WinWaterTank_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gbFMS.ResumeLayout(false);
            this.gbWaterTank.ResumeLayout(false);
            this.gbWaterTank.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CButton.CtrlButtonExit Exit;
        private System.Windows.Forms.Panel panel3;
        private Controlls.WindowsForms.CtrlGroupBox gbWaterTank;
        private Controlls.WindowsForms.CtrlGroupBox gbFMS;
        private System.Windows.Forms.TableLayoutPanel uiTlbMode;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel4;
        private Controlls.WindowsForms.CtrlLED ledRestockPressed;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private Controlls.WindowsForms.CtrlLED ledFireSensor;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private Controlls.WindowsForms.CtrlLED ledStationSink;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel3;
        private Controlls.WindowsForms.CtrlLED ledTrayExist;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel6;
        private Controlls.WindowsForms.CtrlLED ledInputEnable;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel5;
        private Controlls.WindowsForms.CtrlLabelBox lbTrayID2;
        private Controlls.WindowsForms.CtrlLabelBox lbTrayID1;
        private Controlls.WindowsForms.CtrlLabelBox lbTrayCount;
        private Controlls.CtrlDataGridView gridWaterTank;
    }
}