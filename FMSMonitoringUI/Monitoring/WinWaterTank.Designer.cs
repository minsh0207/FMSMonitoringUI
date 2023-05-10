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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinWaterTank));
            this.panel1 = new System.Windows.Forms.Panel();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbFMS.SuspendLayout();
            this.gbWaterTank.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.titBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 60);
            this.panel1.TabIndex = 0;
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_WaterTank_Information";
            this.titBar.Location = new System.Drawing.Point(0, 0);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(653, 60);
            this.titBar.TabIndex = 0;
            this.titBar.TitleText = "WaterTank Information";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gbFMS);
            this.panel3.Controls.Add(this.gbWaterTank);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(653, 358);
            this.panel3.TabIndex = 2;
            // 
            // gbFMS
            // 
            this.gbFMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gbFMS.Controls.Add(this.lbTrayID2);
            this.gbFMS.Controls.Add(this.lbTrayID1);
            this.gbFMS.Controls.Add(this.lbTrayCount);
            this.gbFMS.Controls.Add(this.gridWaterTank);
            this.gbFMS.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbFMS.ForeColor = System.Drawing.Color.White;
            this.gbFMS.LanguageID = "DEF_FMS";
            this.gbFMS.Location = new System.Drawing.Point(373, 17);
            this.gbFMS.Name = "gbFMS";
            this.gbFMS.Size = new System.Drawing.Size(257, 314);
            this.gbFMS.TabIndex = 3;
            this.gbFMS.TabStop = false;
            this.gbFMS.Text = "FMS";
            this.gbFMS.TitleText = "FMS";
            // 
            // lbTrayID2
            // 
            this.lbTrayID2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbTrayID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrayID2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTrayID2.LanguageID = "DEF_Tray_ID_2";
            this.lbTrayID2.Location = new System.Drawing.Point(12, 92);
            this.lbTrayID2.Margin = new System.Windows.Forms.Padding(39, 35, 39, 35);
            this.lbTrayID2.Name = "lbTrayID2";
            this.lbTrayID2.Size = new System.Drawing.Size(232, 30);
            this.lbTrayID2.TabIndex = 60;
            this.lbTrayID2.Tag = "TrayIdL2";
            this.lbTrayID2.TextData = "";
            this.lbTrayID2.TitleText = "Tray ID 2 ";
            this.lbTrayID2.TitleWidth = 110F;
            // 
            // lbTrayID1
            // 
            this.lbTrayID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbTrayID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrayID1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTrayID1.LanguageID = "DEF_Tray_ID_1";
            this.lbTrayID1.Location = new System.Drawing.Point(12, 59);
            this.lbTrayID1.Margin = new System.Windows.Forms.Padding(39, 35, 39, 35);
            this.lbTrayID1.Name = "lbTrayID1";
            this.lbTrayID1.Size = new System.Drawing.Size(232, 30);
            this.lbTrayID1.TabIndex = 59;
            this.lbTrayID1.Tag = "TrayIdL1";
            this.lbTrayID1.TextData = "";
            this.lbTrayID1.TitleText = "Tray ID 1 ";
            this.lbTrayID1.TitleWidth = 110F;
            // 
            // lbTrayCount
            // 
            this.lbTrayCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbTrayCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrayCount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTrayCount.LanguageID = "DEF_Tray_Count";
            this.lbTrayCount.Location = new System.Drawing.Point(12, 25);
            this.lbTrayCount.Margin = new System.Windows.Forms.Padding(39, 35, 39, 35);
            this.lbTrayCount.Name = "lbTrayCount";
            this.lbTrayCount.Size = new System.Drawing.Size(232, 30);
            this.lbTrayCount.TabIndex = 58;
            this.lbTrayCount.Tag = "TrayCount";
            this.lbTrayCount.TextData = "";
            this.lbTrayCount.TitleText = "Tray Count ";
            this.lbTrayCount.TitleWidth = 110F;
            // 
            // gridWaterTank
            // 
            this.gridWaterTank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridWaterTank.ColumnCount = 1;
            this.gridWaterTank.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gridWaterTank.Location = new System.Drawing.Point(12, 146);
            this.gridWaterTank.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridWaterTank.Name = "gridWaterTank";
            this.gridWaterTank.RowCount = 1;
            this.gridWaterTank.Size = new System.Drawing.Size(232, 142);
            this.gridWaterTank.TabIndex = 57;
            this.gridWaterTank.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // gbWaterTank
            // 
            this.gbWaterTank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
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
            this.gbWaterTank.Location = new System.Drawing.Point(24, 17);
            this.gbWaterTank.Name = "gbWaterTank";
            this.gbWaterTank.Size = new System.Drawing.Size(321, 314);
            this.gbWaterTank.TabIndex = 2;
            this.gbWaterTank.TabStop = false;
            this.gbWaterTank.Text = "Water Tank";
            this.gbWaterTank.TitleText = "Water Tank";
            // 
            // ledRestockPressed
            // 
            this.ledRestockPressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledRestockPressed.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledRestockPressed.Location = new System.Drawing.Point(156, 251);
            this.ledRestockPressed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledRestockPressed.Name = "ledRestockPressed";
            this.ledRestockPressed.Size = new System.Drawing.Size(104, 15);
            this.ledRestockPressed.TabIndex = 80;
            this.ledRestockPressed.Tag = "RestockButtonPressed";
            this.ledRestockPressed.TitleText = "";
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "DEF_RestockButtonPressed";
            this.ctrlLabel1.Location = new System.Drawing.Point(16, 248);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(140, 24);
            this.ctrlLabel1.TabIndex = 79;
            this.ctrlLabel1.Text = "RestockButtonPressed :";
            this.ctrlLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledFireSensor
            // 
            this.ledFireSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledFireSensor.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledFireSensor.Location = new System.Drawing.Point(156, 225);
            this.ledFireSensor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledFireSensor.Name = "ledFireSensor";
            this.ledFireSensor.Size = new System.Drawing.Size(104, 15);
            this.ledFireSensor.TabIndex = 78;
            this.ledFireSensor.Tag = "FireSensor";
            this.ledFireSensor.TitleText = "";
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_Fire_Sensor";
            this.ctrlLabel2.Location = new System.Drawing.Point(16, 222);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(140, 24);
            this.ctrlLabel2.TabIndex = 77;
            this.ctrlLabel2.Text = "Fire Sensor :";
            this.ctrlLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledStationSink
            // 
            this.ledStationSink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledStationSink.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledStationSink.Location = new System.Drawing.Point(156, 199);
            this.ledStationSink.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledStationSink.Name = "ledStationSink";
            this.ledStationSink.Size = new System.Drawing.Size(104, 15);
            this.ledStationSink.TabIndex = 76;
            this.ledStationSink.Tag = "StationSink";
            this.ledStationSink.TitleText = "";
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel3.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel3.LanguageID = "DEF_Station_Sink";
            this.ctrlLabel3.Location = new System.Drawing.Point(16, 196);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(140, 24);
            this.ctrlLabel3.TabIndex = 75;
            this.ctrlLabel3.Text = "Station Sink :";
            this.ctrlLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledTrayExist
            // 
            this.ledTrayExist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledTrayExist.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledTrayExist.Location = new System.Drawing.Point(156, 159);
            this.ledTrayExist.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledTrayExist.Name = "ledTrayExist";
            this.ledTrayExist.Size = new System.Drawing.Size(104, 15);
            this.ledTrayExist.TabIndex = 74;
            this.ledTrayExist.Tag = "TrayExist";
            this.ledTrayExist.TitleText = "";
            // 
            // ctrlLabel6
            // 
            this.ctrlLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel6.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel6.LanguageID = "DEF_Tray_Exist";
            this.ctrlLabel6.Location = new System.Drawing.Point(16, 154);
            this.ctrlLabel6.Name = "ctrlLabel6";
            this.ctrlLabel6.Size = new System.Drawing.Size(140, 24);
            this.ctrlLabel6.TabIndex = 73;
            this.ctrlLabel6.Text = "Tray Exist :";
            this.ctrlLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ledInputEnable
            // 
            this.ledInputEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledInputEnable.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ledInputEnable.Location = new System.Drawing.Point(156, 131);
            this.ledInputEnable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledInputEnable.Name = "ledInputEnable";
            this.ledInputEnable.Size = new System.Drawing.Size(104, 15);
            this.ledInputEnable.TabIndex = 72;
            this.ledInputEnable.Tag = "InputEnable";
            this.ledInputEnable.TitleText = "";
            // 
            // ctrlLabel5
            // 
            this.ctrlLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlLabel5.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel5.LanguageID = "DEF_Input_Enable";
            this.ctrlLabel5.Location = new System.Drawing.Point(16, 128);
            this.ctrlLabel5.Name = "ctrlLabel5";
            this.ctrlLabel5.Size = new System.Drawing.Size(140, 24);
            this.ctrlLabel5.TabIndex = 71;
            this.ctrlLabel5.Text = "Input Enable :";
            this.ctrlLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.Font = new System.Drawing.Font("굴림", 9F);
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_Control_Mode";
            this.ctrlLabel4.Location = new System.Drawing.Point(16, 25);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(140, 24);
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
            this.uiTlbMode.Location = new System.Drawing.Point(152, 25);
            this.uiTlbMode.Name = "uiTlbMode";
            this.uiTlbMode.RowCount = 3;
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.uiTlbMode.Size = new System.Drawing.Size(163, 72);
            this.uiTlbMode.TabIndex = 69;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 420);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(653, 60);
            this.panel2.TabIndex = 3;
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.LanguageID = "DEF_Exit";
            this.Exit.Location = new System.Drawing.Point(2, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(170, 40);
            this.Exit.TabIndex = 0;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // WinWaterTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(657, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinWaterTank";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinWaterTank";
            this.WindowID = "WinWaterTank";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinWaterTank_FormClosed);
            this.Load += new System.EventHandler(this.WinWaterTank_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gbFMS.ResumeLayout(false);
            this.gbWaterTank.ResumeLayout(false);
            this.gbWaterTank.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar titBar;
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
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
    }
}