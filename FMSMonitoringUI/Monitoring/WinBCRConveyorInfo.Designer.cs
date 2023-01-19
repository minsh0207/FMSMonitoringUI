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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlLabel3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.uiTlbStatus = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.uiTlbMode = new System.Windows.Forms.TableLayoutPanel();
            this.MagazineCommand = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.Destination = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.FMSTroubleErrNo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayID2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayID1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayCount = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayType = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TrayExist = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.CommandReady = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.TroubleErrLevel = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.CVTroubleErrNo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.ledTroubleStatus = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ledPower = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlGroupBox2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.ctrlGroupBox1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlGroupBox();
            this.StationStatus = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.ConveyorType = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.ConveyorNo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabelBox();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ctrlGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 639);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 60);
            this.panel2.TabIndex = 1;
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
            this.Exit.Size = new System.Drawing.Size(716, 58);
            this.Exit.TabIndex = 1;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
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
            this.panel3.Controls.Add(this.CommandReady);
            this.panel3.Controls.Add(this.TroubleErrLevel);
            this.panel3.Controls.Add(this.CVTroubleErrNo);
            this.panel3.Controls.Add(this.ledTroubleStatus);
            this.panel3.Controls.Add(this.ledPower);
            this.panel3.Controls.Add(this.ctrlGroupBox2);
            this.panel3.Controls.Add(this.ctrlGroupBox1);
            this.panel3.Controls.Add(this.ConveyorType);
            this.panel3.Controls.Add(this.ConveyorNo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 62);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(718, 577);
            this.panel3.TabIndex = 2;
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel3.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel3.LanguageID = "DEF_Status";
            this.ctrlLabel3.Location = new System.Drawing.Point(27, 220);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(97, 24);
            this.ctrlLabel3.TabIndex = 12;
            this.ctrlLabel3.Text = "Status :";
            this.ctrlLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiTlbStatus
            // 
            this.uiTlbStatus.ColumnCount = 3;
            this.uiTlbStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.uiTlbStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.uiTlbStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.uiTlbStatus.Location = new System.Drawing.Point(119, 220);
            this.uiTlbStatus.Name = "uiTlbStatus";
            this.uiTlbStatus.RowCount = 1;
            this.uiTlbStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTlbStatus.Size = new System.Drawing.Size(231, 24);
            this.uiTlbStatus.TabIndex = 68;
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_Control_Mode";
            this.ctrlLabel2.Location = new System.Drawing.Point(27, 143);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(97, 24);
            this.ctrlLabel2.TabIndex = 10;
            this.ctrlLabel2.Text = "Control Mode :";
            this.ctrlLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_Trouble_Status";
            this.ctrlLabel4.Location = new System.Drawing.Point(384, 220);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(97, 24);
            this.ctrlLabel4.TabIndex = 14;
            this.ctrlLabel4.Text = "Trouble Status :";
            this.ctrlLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "DEF_Power";
            this.ctrlLabel1.Location = new System.Drawing.Point(27, 115);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(97, 24);
            this.ctrlLabel1.TabIndex = 8;
            this.ctrlLabel1.Text = "Power :";
            this.ctrlLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiTlbMode
            // 
            this.uiTlbMode.AutoSize = true;
            this.uiTlbMode.ColumnCount = 1;
            this.uiTlbMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.uiTlbMode.Location = new System.Drawing.Point(119, 143);
            this.uiTlbMode.Name = "uiTlbMode";
            this.uiTlbMode.RowCount = 3;
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.uiTlbMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.uiTlbMode.Size = new System.Drawing.Size(200, 72);
            this.uiTlbMode.TabIndex = 67;
            // 
            // MagazineCommand
            // 
            this.MagazineCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.MagazineCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MagazineCommand.LanguageID = "DEF_Magazine_Command";
            this.MagazineCommand.Location = new System.Drawing.Point(386, 320);
            this.MagazineCommand.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.MagazineCommand.Name = "MagazineCommand";
            this.MagazineCommand.Size = new System.Drawing.Size(303, 31);
            this.MagazineCommand.TabIndex = 27;
            this.MagazineCommand.TextData = "";
            this.MagazineCommand.TitleText = "Magazine Command ";
            this.MagazineCommand.TitleWidth = 140F;
            // 
            // Destination
            // 
            this.Destination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Destination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Destination.LanguageID = "DEF_Destination";
            this.Destination.Location = new System.Drawing.Point(386, 286);
            this.Destination.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(303, 31);
            this.Destination.TabIndex = 26;
            this.Destination.TextData = "";
            this.Destination.TitleText = "Destination ";
            this.Destination.TitleWidth = 140F;
            // 
            // FMSTroubleErrNo
            // 
            this.FMSTroubleErrNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.FMSTroubleErrNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FMSTroubleErrNo.LanguageID = "DEF_Trouble_ErrorNo";
            this.FMSTroubleErrNo.Location = new System.Drawing.Point(386, 252);
            this.FMSTroubleErrNo.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.FMSTroubleErrNo.Name = "FMSTroubleErrNo";
            this.FMSTroubleErrNo.Size = new System.Drawing.Size(303, 31);
            this.FMSTroubleErrNo.TabIndex = 25;
            this.FMSTroubleErrNo.TextData = "";
            this.FMSTroubleErrNo.TitleText = "Trouble ErrorNo ";
            this.FMSTroubleErrNo.TitleWidth = 140F;
            // 
            // TrayID2
            // 
            this.TrayID2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayID2.LanguageID = "DEF_Tray_ID_2";
            this.TrayID2.Location = new System.Drawing.Point(37, 491);
            this.TrayID2.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.TrayID2.Name = "TrayID2";
            this.TrayID2.Size = new System.Drawing.Size(303, 31);
            this.TrayID2.TabIndex = 24;
            this.TrayID2.TextData = "";
            this.TrayID2.TitleText = "Tray ID 2 ";
            this.TrayID2.TitleWidth = 140F;
            // 
            // TrayID1
            // 
            this.TrayID1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayID1.LanguageID = "DEF_Tray_ID_1";
            this.TrayID1.Location = new System.Drawing.Point(37, 456);
            this.TrayID1.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.TrayID1.Name = "TrayID1";
            this.TrayID1.Size = new System.Drawing.Size(303, 31);
            this.TrayID1.TabIndex = 23;
            this.TrayID1.TextData = "";
            this.TrayID1.TitleText = "Tray ID 1 ";
            this.TrayID1.TitleWidth = 140F;
            // 
            // TrayCount
            // 
            this.TrayCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayCount.LanguageID = "DEF_Tray_Count";
            this.TrayCount.Location = new System.Drawing.Point(37, 423);
            this.TrayCount.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.TrayCount.Name = "TrayCount";
            this.TrayCount.Size = new System.Drawing.Size(303, 31);
            this.TrayCount.TabIndex = 22;
            this.TrayCount.TextData = "";
            this.TrayCount.TitleText = "Tray Count ";
            this.TrayCount.TitleWidth = 140F;
            // 
            // TrayType
            // 
            this.TrayType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayType.LanguageID = "DEF_Tray_Type";
            this.TrayType.Location = new System.Drawing.Point(37, 388);
            this.TrayType.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.TrayType.Name = "TrayType";
            this.TrayType.Size = new System.Drawing.Size(303, 31);
            this.TrayType.TabIndex = 21;
            this.TrayType.TextData = "";
            this.TrayType.TitleText = "Tray Type ";
            this.TrayType.TitleWidth = 140F;
            // 
            // TrayExist
            // 
            this.TrayExist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TrayExist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayExist.LanguageID = "DEF_Tray_Exist";
            this.TrayExist.Location = new System.Drawing.Point(37, 353);
            this.TrayExist.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.TrayExist.Name = "TrayExist";
            this.TrayExist.Size = new System.Drawing.Size(303, 31);
            this.TrayExist.TabIndex = 20;
            this.TrayExist.TextData = "";
            this.TrayExist.TitleText = "Tray Exist ";
            this.TrayExist.TitleWidth = 140F;
            // 
            // CommandReady
            // 
            this.CommandReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.CommandReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandReady.LanguageID = "DEF_Command_Ready";
            this.CommandReady.Location = new System.Drawing.Point(37, 320);
            this.CommandReady.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.CommandReady.Name = "CommandReady";
            this.CommandReady.Size = new System.Drawing.Size(303, 31);
            this.CommandReady.TabIndex = 18;
            this.CommandReady.TextData = "";
            this.CommandReady.TitleText = "Command Ready ";
            this.CommandReady.TitleWidth = 140F;
            // 
            // TroubleErrLevel
            // 
            this.TroubleErrLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.TroubleErrLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TroubleErrLevel.LanguageID = "DEF_Trouble_ErrorLevel";
            this.TroubleErrLevel.Location = new System.Drawing.Point(37, 286);
            this.TroubleErrLevel.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.TroubleErrLevel.Name = "TroubleErrLevel";
            this.TroubleErrLevel.Size = new System.Drawing.Size(303, 31);
            this.TroubleErrLevel.TabIndex = 17;
            this.TroubleErrLevel.TextData = "";
            this.TroubleErrLevel.TitleText = "Trouble ErrorLevel ";
            this.TroubleErrLevel.TitleWidth = 140F;
            // 
            // CVTroubleErrNo
            // 
            this.CVTroubleErrNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.CVTroubleErrNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CVTroubleErrNo.LanguageID = "DEF_Trouble_ErrorNo";
            this.CVTroubleErrNo.Location = new System.Drawing.Point(37, 252);
            this.CVTroubleErrNo.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.CVTroubleErrNo.Name = "CVTroubleErrNo";
            this.CVTroubleErrNo.Size = new System.Drawing.Size(303, 31);
            this.CVTroubleErrNo.TabIndex = 16;
            this.CVTroubleErrNo.TextData = "";
            this.CVTroubleErrNo.TitleText = "Trouble ErrorNo ";
            this.CVTroubleErrNo.TitleWidth = 140F;
            // 
            // ledTroubleStatus
            // 
            this.ledTroubleStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledTroubleStatus.Location = new System.Drawing.Point(478, 223);
            this.ledTroubleStatus.Name = "ledTroubleStatus";
            this.ledTroubleStatus.Size = new System.Drawing.Size(81, 18);
            this.ledTroubleStatus.TabIndex = 15;
            this.ledTroubleStatus.TitleText = "";
            // 
            // ledPower
            // 
            this.ledPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ledPower.Location = new System.Drawing.Point(122, 118);
            this.ledPower.Name = "ledPower";
            this.ledPower.Size = new System.Drawing.Size(81, 18);
            this.ledPower.TabIndex = 9;
            this.ledPower.TitleText = "";
            // 
            // ctrlGroupBox2
            // 
            this.ctrlGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox2.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox2.LanguageID = "DEF_FMS";
            this.ctrlGroupBox2.Location = new System.Drawing.Point(371, 89);
            this.ctrlGroupBox2.Name = "ctrlGroupBox2";
            this.ctrlGroupBox2.Size = new System.Drawing.Size(330, 478);
            this.ctrlGroupBox2.TabIndex = 6;
            this.ctrlGroupBox2.TabStop = false;
            this.ctrlGroupBox2.Text = "FMS";
            this.ctrlGroupBox2.TitleText = "FMS";
            // 
            // ctrlGroupBox1
            // 
            this.ctrlGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlGroupBox1.Controls.Add(this.StationStatus);
            this.ctrlGroupBox1.ForeColor = System.Drawing.Color.White;
            this.ctrlGroupBox1.LanguageID = "DEF_Conveyor";
            this.ctrlGroupBox1.Location = new System.Drawing.Point(14, 89);
            this.ctrlGroupBox1.Name = "ctrlGroupBox1";
            this.ctrlGroupBox1.Size = new System.Drawing.Size(341, 478);
            this.ctrlGroupBox1.TabIndex = 5;
            this.ctrlGroupBox1.TabStop = false;
            this.ctrlGroupBox1.Text = "Conveyor";
            this.ctrlGroupBox1.TitleText = "Conveyor";
            // 
            // StationStatus
            // 
            this.StationStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.StationStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StationStatus.LanguageID = "DEF_Station_Status";
            this.StationStatus.Location = new System.Drawing.Point(23, 437);
            this.StationStatus.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.StationStatus.Name = "StationStatus";
            this.StationStatus.Size = new System.Drawing.Size(303, 31);
            this.StationStatus.TabIndex = 19;
            this.StationStatus.TextData = "";
            this.StationStatus.TitleText = "Station Status ";
            this.StationStatus.TitleWidth = 140F;
            // 
            // ConveyorType
            // 
            this.ConveyorType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ConveyorType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConveyorType.LanguageID = "DEF_Conveyor_Type";
            this.ConveyorType.Location = new System.Drawing.Point(37, 50);
            this.ConveyorType.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.ConveyorType.Name = "ConveyorType";
            this.ConveyorType.Size = new System.Drawing.Size(303, 31);
            this.ConveyorType.TabIndex = 4;
            this.ConveyorType.TextData = "InOutStation";
            this.ConveyorType.TitleText = "Conveyor Type";
            this.ConveyorType.TitleWidth = 130F;
            // 
            // ConveyorNo
            // 
            this.ConveyorNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ConveyorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConveyorNo.LanguageID = "DEF_Conveyor_No";
            this.ConveyorNo.Location = new System.Drawing.Point(37, 15);
            this.ConveyorNo.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.ConveyorNo.Name = "ConveyorNo";
            this.ConveyorNo.Size = new System.Drawing.Size(303, 31);
            this.ConveyorNo.TabIndex = 3;
            this.ConveyorNo.TextData = "100";
            this.ConveyorNo.TitleText = "Conveyor No";
            this.ConveyorNo.TitleWidth = 130F;
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_Conveyor_Information";
            this.titBar.Location = new System.Drawing.Point(2, 2);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(718, 60);
            this.titBar.TabIndex = 3;
            this.titBar.TitleText = "Conveyor Information";
            // 
            // WinBCRConveyorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(722, 722);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.titBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinBCRConveyorInfo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinBCRConveyorInfo";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinBCRConveyorInfo_FormClosed);
            this.Load += new System.EventHandler(this.WinBCRConveyorInfo_Load);
            this.Controls.SetChildIndex(this.titBar, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ctrlGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private MonitoringUI.Controlls.CtrlTitleBar titBar;
    }
}