namespace FMSMonitoringUI.Monitoring
{
    partial class WinBCRConveyorInfo
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiTlbStatus = new System.Windows.Forms.TableLayoutPanel();
            this.uiTlbMode = new System.Windows.Forms.TableLayoutPanel();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.ctrlLabel3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.MagazineCommand = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.Destination = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.FMSTroubleErrNo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayID2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayID1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayCount = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayType = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayExist = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.StationStatus = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.CommandReady = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TroubleErrLevel = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.CVTroubleErrNo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.ledTroubleStatus = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ledPower = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlGroupBox2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.ctrlGroupBox1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.ConveyorType = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.ConveyorNo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ctrlTitleBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 66);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 602);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(706, 65);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ctrlLabel3);
            this.panel3.Controls.Add(this.uiTlbStatus);
            this.panel3.Controls.Add(this.ctrlLabel2);
            this.panel3.Controls.Add(this.ctrlLabel4);
            this.panel3.Controls.Add(this.ctrlLabel1);
            this.panel3.Controls.Add(this.uiTlbMode);
            this.panel3.Controls.Add(this.MagazineCommand);
            this.panel3.Controls.Add(this.Destination);
            this.panel3.Controls.Add(this.FMSTroubleErrNo);
            this.panel3.Controls.Add(this.TrayID2);
            this.panel3.Controls.Add(this.TrayID1);
            this.panel3.Controls.Add(this.TrayCount);
            this.panel3.Controls.Add(this.TrayType);
            this.panel3.Controls.Add(this.TrayExist);
            this.panel3.Controls.Add(this.StationStatus);
            this.panel3.Controls.Add(this.CommandReady);
            this.panel3.Controls.Add(this.TroubleErrLevel);
            this.panel3.Controls.Add(this.CVTroubleErrNo);
            this.panel3.Controls.Add(this.ledTroubleStatus);
            this.panel3.Controls.Add(this.ledPower);
            this.panel3.Controls.Add(this.ctrlGroupBox2);
            this.panel3.Controls.Add(this.ctrlGroupBox1);
            this.panel3.Controls.Add(this.ConveyorType);
            this.panel3.Controls.Add(this.ConveyorNo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 536);
            this.panel3.TabIndex = 2;
            // 
            // uiTlbStatus
            // 
            this.uiTlbStatus.ColumnCount = 3;
            this.uiTlbStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.4F));
            this.uiTlbStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.6F));
            this.uiTlbStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.uiTlbStatus.Location = new System.Drawing.Point(119, 203);
            this.uiTlbStatus.Name = "uiTlbStatus";
            this.uiTlbStatus.RowCount = 1;
            this.uiTlbStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTlbStatus.Size = new System.Drawing.Size(208, 22);
            this.uiTlbStatus.TabIndex = 68;
            // 
            // uiTlbMode
            // 
            this.uiTlbMode.AutoSize = true;
            this.uiTlbMode.ColumnCount = 1;
            this.uiTlbMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.uiTlbMode.Location = new System.Drawing.Point(119, 132);
            this.uiTlbMode.Name = "uiTlbMode";
            this.uiTlbMode.RowCount = 3;
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.uiTlbMode.Size = new System.Drawing.Size(200, 65);
            this.uiTlbMode.TabIndex = 67;
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel3.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel3.LanguageID = "DEF_STATUS";
            this.ctrlLabel3.Location = new System.Drawing.Point(27, 203);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(97, 22);
            this.ctrlLabel3.TabIndex = 12;
            this.ctrlLabel3.Text = "Status :";
            this.ctrlLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_CONTROL_MODE";
            this.ctrlLabel2.Location = new System.Drawing.Point(27, 132);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(97, 22);
            this.ctrlLabel2.TabIndex = 10;
            this.ctrlLabel2.Text = "Control Mode :";
            this.ctrlLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_TROUBLE_STATUS";
            this.ctrlLabel4.Location = new System.Drawing.Point(373, 203);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(97, 22);
            this.ctrlLabel4.TabIndex = 14;
            this.ctrlLabel4.Text = "Trouble Status :";
            this.ctrlLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "DEF_POWER";
            this.ctrlLabel1.Location = new System.Drawing.Point(27, 106);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(97, 22);
            this.ctrlLabel1.TabIndex = 8;
            this.ctrlLabel1.Text = "Power :";
            this.ctrlLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MagazineCommand
            // 
            this.MagazineCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.MagazineCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MagazineCommand.LanguageID = "DEF_MAGAZINE_COMMAND";
            this.MagazineCommand.Location = new System.Drawing.Point(375, 295);
            this.MagazineCommand.Margin = new System.Windows.Forms.Padding(30);
            this.MagazineCommand.Name = "MagazineCommand";
            this.MagazineCommand.Size = new System.Drawing.Size(303, 29);
            this.MagazineCommand.TabIndex = 27;
            this.MagazineCommand.TextData = "";
            this.MagazineCommand.TitleText = "Magazine Command ";
            this.MagazineCommand.TitleWidth = 140F;
            // 
            // Destination
            // 
            this.Destination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Destination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Destination.LanguageID = "DEF_DESTINATION";
            this.Destination.Location = new System.Drawing.Point(375, 264);
            this.Destination.Margin = new System.Windows.Forms.Padding(30);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(303, 29);
            this.Destination.TabIndex = 26;
            this.Destination.TextData = "";
            this.Destination.TitleText = "Destination ";
            this.Destination.TitleWidth = 140F;
            // 
            // FMSTroubleErrNo
            // 
            this.FMSTroubleErrNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.FMSTroubleErrNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FMSTroubleErrNo.LanguageID = "DEF_TROUBLE_ERRORNO";
            this.FMSTroubleErrNo.Location = new System.Drawing.Point(375, 233);
            this.FMSTroubleErrNo.Margin = new System.Windows.Forms.Padding(30);
            this.FMSTroubleErrNo.Name = "FMSTroubleErrNo";
            this.FMSTroubleErrNo.Size = new System.Drawing.Size(303, 29);
            this.FMSTroubleErrNo.TabIndex = 25;
            this.FMSTroubleErrNo.TextData = "";
            this.FMSTroubleErrNo.TitleText = "Trouble ErrorNo ";
            this.FMSTroubleErrNo.TitleWidth = 140F;
            // 
            // TrayID2
            // 
            this.TrayID2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayID2.LanguageID = "DEF_TRAY_ID2";
            this.TrayID2.Location = new System.Drawing.Point(29, 485);
            this.TrayID2.Margin = new System.Windows.Forms.Padding(30);
            this.TrayID2.Name = "TrayID2";
            this.TrayID2.Size = new System.Drawing.Size(303, 29);
            this.TrayID2.TabIndex = 24;
            this.TrayID2.TextData = "";
            this.TrayID2.TitleText = "Tray ID 2 ";
            this.TrayID2.TitleWidth = 140F;
            // 
            // TrayID1
            // 
            this.TrayID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayID1.LanguageID = "DEF_TRAY_ID1";
            this.TrayID1.Location = new System.Drawing.Point(29, 453);
            this.TrayID1.Margin = new System.Windows.Forms.Padding(30);
            this.TrayID1.Name = "TrayID1";
            this.TrayID1.Size = new System.Drawing.Size(303, 29);
            this.TrayID1.TabIndex = 23;
            this.TrayID1.TextData = "";
            this.TrayID1.TitleText = "Tray ID 1 ";
            this.TrayID1.TitleWidth = 140F;
            // 
            // TrayCount
            // 
            this.TrayCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayCount.LanguageID = "DEF_TRAY_COUNT";
            this.TrayCount.Location = new System.Drawing.Point(29, 422);
            this.TrayCount.Margin = new System.Windows.Forms.Padding(30);
            this.TrayCount.Name = "TrayCount";
            this.TrayCount.Size = new System.Drawing.Size(303, 29);
            this.TrayCount.TabIndex = 22;
            this.TrayCount.TextData = "";
            this.TrayCount.TitleText = "Tray Count ";
            this.TrayCount.TitleWidth = 140F;
            // 
            // TrayType
            // 
            this.TrayType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayType.LanguageID = "DEF_TRAY_TYPE";
            this.TrayType.Location = new System.Drawing.Point(29, 390);
            this.TrayType.Margin = new System.Windows.Forms.Padding(30);
            this.TrayType.Name = "TrayType";
            this.TrayType.Size = new System.Drawing.Size(303, 29);
            this.TrayType.TabIndex = 21;
            this.TrayType.TextData = "";
            this.TrayType.TitleText = "Tray Type ";
            this.TrayType.TitleWidth = 140F;
            // 
            // TrayExist
            // 
            this.TrayExist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayExist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayExist.LanguageID = "DEF_TRAY_EXIST";
            this.TrayExist.Location = new System.Drawing.Point(29, 358);
            this.TrayExist.Margin = new System.Windows.Forms.Padding(30);
            this.TrayExist.Name = "TrayExist";
            this.TrayExist.Size = new System.Drawing.Size(303, 29);
            this.TrayExist.TabIndex = 20;
            this.TrayExist.TextData = "";
            this.TrayExist.TitleText = "Tray Exist ";
            this.TrayExist.TitleWidth = 140F;
            // 
            // StationStatus
            // 
            this.StationStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.StationStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StationStatus.LanguageID = "DEF_STATION_STATUS";
            this.StationStatus.Location = new System.Drawing.Point(29, 326);
            this.StationStatus.Margin = new System.Windows.Forms.Padding(30);
            this.StationStatus.Name = "StationStatus";
            this.StationStatus.Size = new System.Drawing.Size(303, 29);
            this.StationStatus.TabIndex = 19;
            this.StationStatus.TextData = "";
            this.StationStatus.TitleText = "Station Status ";
            this.StationStatus.TitleWidth = 140F;
            // 
            // CommandReady
            // 
            this.CommandReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.CommandReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandReady.LanguageID = "DEF_COMMAND_READY";
            this.CommandReady.Location = new System.Drawing.Point(29, 295);
            this.CommandReady.Margin = new System.Windows.Forms.Padding(30);
            this.CommandReady.Name = "CommandReady";
            this.CommandReady.Size = new System.Drawing.Size(303, 29);
            this.CommandReady.TabIndex = 18;
            this.CommandReady.TextData = "";
            this.CommandReady.TitleText = "Command Ready ";
            this.CommandReady.TitleWidth = 140F;
            // 
            // TroubleErrLevel
            // 
            this.TroubleErrLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TroubleErrLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TroubleErrLevel.LanguageID = "DEF_TROUBLE_ERRORLEVEL";
            this.TroubleErrLevel.Location = new System.Drawing.Point(29, 264);
            this.TroubleErrLevel.Margin = new System.Windows.Forms.Padding(30);
            this.TroubleErrLevel.Name = "TroubleErrLevel";
            this.TroubleErrLevel.Size = new System.Drawing.Size(303, 29);
            this.TroubleErrLevel.TabIndex = 17;
            this.TroubleErrLevel.TextData = "";
            this.TroubleErrLevel.TitleText = "Trouble ErrorLevel ";
            this.TroubleErrLevel.TitleWidth = 140F;
            // 
            // CVTroubleErrNo
            // 
            this.CVTroubleErrNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.CVTroubleErrNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CVTroubleErrNo.LanguageID = "DEF_TROUBLE_ERRORNO";
            this.CVTroubleErrNo.Location = new System.Drawing.Point(29, 233);
            this.CVTroubleErrNo.Margin = new System.Windows.Forms.Padding(30);
            this.CVTroubleErrNo.Name = "CVTroubleErrNo";
            this.CVTroubleErrNo.Size = new System.Drawing.Size(303, 29);
            this.CVTroubleErrNo.TabIndex = 16;
            this.CVTroubleErrNo.TextData = "";
            this.CVTroubleErrNo.TitleText = "Trouble ErrorNo ";
            this.CVTroubleErrNo.TitleWidth = 140F;
            // 
            // ledTroubleStatus
            // 
            this.ledTroubleStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledTroubleStatus.Location = new System.Drawing.Point(467, 206);
            this.ledTroubleStatus.Name = "ledTroubleStatus";
            this.ledTroubleStatus.Size = new System.Drawing.Size(81, 17);
            this.ledTroubleStatus.TabIndex = 15;
            this.ledTroubleStatus.TitleText = "";
            // 
            // ledPower
            // 
            this.ledPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledPower.Location = new System.Drawing.Point(122, 109);
            this.ledPower.Name = "ledPower";
            this.ledPower.Size = new System.Drawing.Size(81, 17);
            this.ledPower.TabIndex = 9;
            this.ledPower.TitleText = "";
            // 
            // ctrlGroupBox2
            // 
            this.ctrlGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox2.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox2.LanguageID = "DEF_FMS";
            this.ctrlGroupBox2.Location = new System.Drawing.Point(361, 82);
            this.ctrlGroupBox2.Name = "ctrlGroupBox2";
            this.ctrlGroupBox2.Size = new System.Drawing.Size(330, 441);
            this.ctrlGroupBox2.TabIndex = 6;
            this.ctrlGroupBox2.TabStop = false;
            this.ctrlGroupBox2.Text = "FMS";
            this.ctrlGroupBox2.TitleText = "FMS";
            // 
            // ctrlGroupBox1
            // 
            this.ctrlGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox1.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox1.LanguageID = "DEF_CONVEYOR";
            this.ctrlGroupBox1.Location = new System.Drawing.Point(14, 82);
            this.ctrlGroupBox1.Name = "ctrlGroupBox1";
            this.ctrlGroupBox1.Size = new System.Drawing.Size(330, 441);
            this.ctrlGroupBox1.TabIndex = 5;
            this.ctrlGroupBox1.TabStop = false;
            this.ctrlGroupBox1.Text = "Conveyor";
            this.ctrlGroupBox1.TitleText = "Conveyor";
            // 
            // ConveyorType
            // 
            this.ConveyorType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ConveyorType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConveyorType.LanguageID = "DEF_CONVEYOR_TYPE";
            this.ConveyorType.Location = new System.Drawing.Point(29, 46);
            this.ConveyorType.Margin = new System.Windows.Forms.Padding(30);
            this.ConveyorType.Name = "ConveyorType";
            this.ConveyorType.Size = new System.Drawing.Size(303, 29);
            this.ConveyorType.TabIndex = 4;
            this.ConveyorType.TextData = "InOutStation";
            this.ConveyorType.TitleText = "Conveyor Type";
            this.ConveyorType.TitleWidth = 130F;
            // 
            // ConveyorNo
            // 
            this.ConveyorNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ConveyorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConveyorNo.LanguageID = "DEF_CONVEYOR_NO";
            this.ConveyorNo.Location = new System.Drawing.Point(29, 14);
            this.ConveyorNo.Margin = new System.Windows.Forms.Padding(30);
            this.ConveyorNo.Name = "ConveyorNo";
            this.ConveyorNo.Size = new System.Drawing.Size(303, 29);
            this.ConveyorNo.TabIndex = 3;
            this.ConveyorNo.TextData = "100";
            this.ConveyorNo.TitleText = "Conveyor No";
            this.ConveyorNo.TitleWidth = 130F;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.LanguageID = "DEF_EXIT";
            this.Exit.Location = new System.Drawing.Point(283, 11);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(139, 41);
            this.Exit.TabIndex = 0;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ctrlTitleBar
            // 
            this.ctrlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTitleBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar.LanguageID = "DEF_CONVEYOR_INFORMATION";
            this.ctrlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar.Name = "ctrlTitleBar";
            this.ctrlTitleBar.Size = new System.Drawing.Size(704, 64);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "Conveyor Information";
            // 
            // WinBCRConveyorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 667);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinBCRConveyorInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinBCRConveyorInfo_FormClosed);
            this.Load += new System.EventHandler(this.WinBCRConveyorInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Controlls.WindowsForms.CtrlLabelBox ConveyorNo;
        private Controlls.WindowsForms.CtrlLabelBox ConveyorType;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox1;
        private Controlls.WindowsForms.CtrlGroupBox ctrlGroupBox2;
        private Controlls.WindowsForms.CtrlLED ledPower;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel3;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private Controlls.WindowsForms.CtrlLED ledTroubleStatus;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel4;
        private Controlls.WindowsForms.CtrlLabelBox TrayID2;
        private Controlls.WindowsForms.CtrlLabelBox TrayID1;
        private Controlls.WindowsForms.CtrlLabelBox TrayCount;
        private Controlls.WindowsForms.CtrlLabelBox TrayType;
        private Controlls.WindowsForms.CtrlLabelBox TrayExist;
        private Controlls.WindowsForms.CtrlLabelBox StationStatus;
        private Controlls.WindowsForms.CtrlLabelBox CommandReady;
        private Controlls.WindowsForms.CtrlLabelBox TroubleErrLevel;
        private Controlls.WindowsForms.CtrlLabelBox CVTroubleErrNo;
        private Controlls.WindowsForms.CtrlLabelBox MagazineCommand;
        private Controlls.WindowsForms.CtrlLabelBox Destination;
        private Controlls.WindowsForms.CtrlLabelBox FMSTroubleErrNo;
        private System.Windows.Forms.TableLayoutPanel uiTlbMode;
        private System.Windows.Forms.TableLayoutPanel uiTlbStatus;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
        private System.Windows.Forms.Timer m_timer;
    }
}