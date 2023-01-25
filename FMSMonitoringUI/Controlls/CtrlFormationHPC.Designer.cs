namespace FMSMonitoringUI
{
    partial class CtrlFormationHPC
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ctrlHPC1 = new FMSMonitoringUI.Controlls.CtrlHPC();
            this.ctrlHPCTemp1 = new FMSMonitoringUI.Controlls.CtrlHPCTemp();
            this.ctrlHPC2 = new FMSMonitoringUI.Controlls.CtrlHPC();
            this.ctrlHPCTemp2 = new FMSMonitoringUI.Controlls.CtrlHPCTemp();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlTaggingName1 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlLabel12 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlTaggingName21 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlLabel3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.RestServer = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel15 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlTaggingName4 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlLabel14 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlTaggingName3 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName2 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlLabel13 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlTaggingName16 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName17 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName18 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName19 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName20 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingNameLong6 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong3 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong8 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong5 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong4 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong2 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong1 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 880);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 50);
            this.button1.TabIndex = 22;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.Location = new System.Drawing.Point(315, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ctrlHPC1);
            this.splitContainer1.Panel1.Controls.Add(this.ctrlHPCTemp1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlHPC2);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlHPCTemp2);
            this.splitContainer1.Size = new System.Drawing.Size(1604, 945);
            this.splitContainer1.SplitterDistance = 797;
            this.splitContainer1.TabIndex = 88;
            // 
            // ctrlHPC1
            // 
            this.ctrlHPC1.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPC1.EqpID = "F1HPC01";
            this.ctrlHPC1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPC1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPC1.LanguageID = "DEF_HPC_JIG#1";
            this.ctrlHPC1.Location = new System.Drawing.Point(21, 28);
            this.ctrlHPC1.Name = "ctrlHPC1";
            this.ctrlHPC1.Size = new System.Drawing.Size(307, 373);
            this.ctrlHPC1.TabIndex = 2;
            this.ctrlHPC1.TextBoxText = " HPC JIG#1";
            this.ctrlHPC1.UnitID = "HPC0100001";
            // 
            // ctrlHPCTemp1
            // 
            this.ctrlHPCTemp1.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPCTemp1.EqpID = "F1HPC01";
            this.ctrlHPCTemp1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPCTemp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPCTemp1.LanguageID = "DEF_JIG#1_Information";
            this.ctrlHPCTemp1.Location = new System.Drawing.Point(353, 28);
            this.ctrlHPCTemp1.MaxCellCount = 30;
            this.ctrlHPCTemp1.Name = "ctrlHPCTemp1";
            this.ctrlHPCTemp1.Size = new System.Drawing.Size(420, 882);
            this.ctrlHPCTemp1.TabIndex = 1;
            this.ctrlHPCTemp1.TitleName = "JIG#1 Information";
            this.ctrlHPCTemp1.UnitID = "HPC0100001";
            // 
            // ctrlHPC2
            // 
            this.ctrlHPC2.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPC2.EqpID = "F1HPC01";
            this.ctrlHPC2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPC2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPC2.LanguageID = "DEF_HPC_JIG#2";
            this.ctrlHPC2.Location = new System.Drawing.Point(21, 28);
            this.ctrlHPC2.Name = "ctrlHPC2";
            this.ctrlHPC2.Size = new System.Drawing.Size(307, 373);
            this.ctrlHPC2.TabIndex = 3;
            this.ctrlHPC2.TextBoxText = " HPC JIG#2";
            this.ctrlHPC2.UnitID = "HPC0100002";
            // 
            // ctrlHPCTemp2
            // 
            this.ctrlHPCTemp2.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPCTemp2.EqpID = "F1HPC01";
            this.ctrlHPCTemp2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPCTemp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPCTemp2.LanguageID = "DEF_JIG#2_Information";
            this.ctrlHPCTemp2.Location = new System.Drawing.Point(353, 28);
            this.ctrlHPCTemp2.MaxCellCount = 30;
            this.ctrlHPCTemp2.Name = "ctrlHPCTemp2";
            this.ctrlHPCTemp2.Size = new System.Drawing.Size(420, 882);
            this.ctrlHPCTemp2.TabIndex = 2;
            this.ctrlHPCTemp2.TitleName = "JIG#2 Information";
            this.ctrlHPCTemp2.UnitID = "HPC0100002";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlTaggingName1);
            this.panel1.Controls.Add(this.ctrlLabel12);
            this.panel1.Controls.Add(this.ctrlTaggingName21);
            this.panel1.Controls.Add(this.ctrlLabel3);
            this.panel1.Controls.Add(this.RestServer);
            this.panel1.Controls.Add(this.ctrlLabel4);
            this.panel1.Controls.Add(this.ctrlLabel15);
            this.panel1.Controls.Add(this.ctrlTaggingName4);
            this.panel1.Controls.Add(this.ctrlLabel14);
            this.panel1.Controls.Add(this.ctrlTaggingName3);
            this.panel1.Controls.Add(this.ctrlTaggingName2);
            this.panel1.Controls.Add(this.ctrlLabel13);
            this.panel1.Controls.Add(this.ctrlTaggingName16);
            this.panel1.Controls.Add(this.ctrlTaggingName17);
            this.panel1.Controls.Add(this.ctrlTaggingName18);
            this.panel1.Controls.Add(this.ctrlTaggingName19);
            this.panel1.Controls.Add(this.ctrlTaggingName20);
            this.panel1.Controls.Add(this.ctrlTaggingNameLong6);
            this.panel1.Controls.Add(this.ctrlTaggingNameLong3);
            this.panel1.Controls.Add(this.ctrlTaggingNameLong8);
            this.panel1.Controls.Add(this.ctrlTaggingNameLong5);
            this.panel1.Controls.Add(this.ctrlTaggingNameLong4);
            this.panel1.Controls.Add(this.ctrlTaggingNameLong2);
            this.panel1.Controls.Add(this.ctrlTaggingNameLong1);
            this.panel1.Controls.Add(this.ctrlLabel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 945);
            this.panel1.TabIndex = 131;
            // 
            // ctrlTaggingName1
            // 
            this.ctrlTaggingName1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName1.ColorText = "M";
            this.ctrlTaggingName1.Enabled = false;
            this.ctrlTaggingName1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName1.LanguageID = "DEF_Maintenance";
            this.ctrlTaggingName1.Location = new System.Drawing.Point(14, 696);
            this.ctrlTaggingName1.Name = "ctrlTaggingName1";
            this.ctrlTaggingName1.Size = new System.Drawing.Size(179, 23);
            this.ctrlTaggingName1.StatusCode = "M";
            this.ctrlTaggingName1.TabIndex = 171;
            this.ctrlTaggingName1.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(135)))), ((int)(((byte)(21)))));
            this.ctrlTaggingName1.TagText = "Maintenance";
            this.ctrlTaggingName1.TextColor = System.Drawing.Color.Black;
            this.ctrlTaggingName1.Visible = false;
            // 
            // ctrlLabel12
            // 
            this.ctrlLabel12.AutoSize = true;
            this.ctrlLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel12.Enabled = false;
            this.ctrlLabel12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel12.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel12.LanguageID = "DEF_Eqp_Mode";
            this.ctrlLabel12.Location = new System.Drawing.Point(13, 653);
            this.ctrlLabel12.Name = "ctrlLabel12";
            this.ctrlLabel12.Size = new System.Drawing.Size(70, 16);
            this.ctrlLabel12.TabIndex = 170;
            this.ctrlLabel12.Text = "Eqp Mode";
            this.ctrlLabel12.Visible = false;
            // 
            // ctrlTaggingName21
            // 
            this.ctrlTaggingName21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName21.ColorText = "C";
            this.ctrlTaggingName21.Enabled = false;
            this.ctrlTaggingName21.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName21.LanguageID = "DEF_Control";
            this.ctrlTaggingName21.Location = new System.Drawing.Point(14, 671);
            this.ctrlTaggingName21.Name = "ctrlTaggingName21";
            this.ctrlTaggingName21.Size = new System.Drawing.Size(179, 23);
            this.ctrlTaggingName21.StatusCode = "C";
            this.ctrlTaggingName21.TabIndex = 169;
            this.ctrlTaggingName21.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingName21.TagText = "Control";
            this.ctrlTaggingName21.TextColor = System.Drawing.Color.Black;
            this.ctrlTaggingName21.Visible = false;
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.AutoSize = true;
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel3.Font = new System.Drawing.Font("돋움", 9.75F);
            this.ctrlLabel3.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel3.LanguageID = "DEF_Rest_Server";
            this.ctrlLabel3.Location = new System.Drawing.Point(38, 41);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(72, 13);
            this.ctrlLabel3.TabIndex = 168;
            this.ctrlLabel3.Text = "Rest Server";
            // 
            // RestServer
            // 
            this.RestServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.RestServer.Location = new System.Drawing.Point(10, 40);
            this.RestServer.Name = "RestServer";
            this.RestServer.Size = new System.Drawing.Size(27, 16);
            this.RestServer.TabIndex = 167;
            this.RestServer.TitleText = "";
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.AutoSize = true;
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel4.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel4.LanguageID = "DEF_Control_Status";
            this.ctrlLabel4.Location = new System.Drawing.Point(10, 16);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(96, 16);
            this.ctrlLabel4.TabIndex = 166;
            this.ctrlLabel4.Text = "Control Status";
            // 
            // ctrlLabel15
            // 
            this.ctrlLabel15.AutoSize = true;
            this.ctrlLabel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel15.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel15.LanguageID = "DEF_Smoke_Only_or_Both";
            this.ctrlLabel15.Location = new System.Drawing.Point(21, 341);
            this.ctrlLabel15.Name = "ctrlLabel15";
            this.ctrlLabel15.Size = new System.Drawing.Size(142, 16);
            this.ctrlLabel15.TabIndex = 165;
            this.ctrlLabel15.Text = "(Smoke Only or Both)";
            // 
            // ctrlTaggingName4
            // 
            this.ctrlTaggingName4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName4.ColorText = "F2";
            this.ctrlTaggingName4.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName4.LanguageID = "DEF_Fire2";
            this.ctrlTaggingName4.Location = new System.Drawing.Point(14, 313);
            this.ctrlTaggingName4.Name = "ctrlTaggingName4";
            this.ctrlTaggingName4.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName4.StatusCode = "F2";
            this.ctrlTaggingName4.TabIndex = 164;
            this.ctrlTaggingName4.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlTaggingName4.TagText = "Fire2";
            this.ctrlTaggingName4.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlLabel14
            // 
            this.ctrlLabel14.AutoSize = true;
            this.ctrlLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel14.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel14.LanguageID = "DEF_Temperature_Alarm_Only";
            this.ctrlLabel14.Location = new System.Drawing.Point(21, 294);
            this.ctrlLabel14.Name = "ctrlLabel14";
            this.ctrlLabel14.Size = new System.Drawing.Size(171, 16);
            this.ctrlLabel14.TabIndex = 163;
            this.ctrlLabel14.Text = "(Temperature Alarm Only)";
            // 
            // ctrlTaggingName3
            // 
            this.ctrlTaggingName3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName3.ColorText = "S";
            this.ctrlTaggingName3.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName3.LanguageID = "DEF_Stop";
            this.ctrlTaggingName3.Location = new System.Drawing.Point(14, 216);
            this.ctrlTaggingName3.Name = "ctrlTaggingName3";
            this.ctrlTaggingName3.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName3.StatusCode = "S";
            this.ctrlTaggingName3.TabIndex = 162;
            this.ctrlTaggingName3.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ctrlTaggingName3.TagText = "Stop";
            this.ctrlTaggingName3.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName2
            // 
            this.ctrlTaggingName2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName2.ColorText = "T";
            this.ctrlTaggingName2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName2.LanguageID = "DEF_Machine_Trouble";
            this.ctrlTaggingName2.Location = new System.Drawing.Point(14, 166);
            this.ctrlTaggingName2.Name = "ctrlTaggingName2";
            this.ctrlTaggingName2.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName2.StatusCode = "T";
            this.ctrlTaggingName2.TabIndex = 161;
            this.ctrlTaggingName2.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlTaggingName2.TagText = "Machine Trouble";
            this.ctrlTaggingName2.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlLabel13
            // 
            this.ctrlLabel13.AutoSize = true;
            this.ctrlLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel13.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel13.LanguageID = "DEF_Eqp_Status";
            this.ctrlLabel13.Location = new System.Drawing.Point(10, 95);
            this.ctrlLabel13.Name = "ctrlLabel13";
            this.ctrlLabel13.Size = new System.Drawing.Size(74, 16);
            this.ctrlLabel13.TabIndex = 160;
            this.ctrlLabel13.Text = "Eqp Status";
            // 
            // ctrlTaggingName16
            // 
            this.ctrlTaggingName16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName16.ColorText = "F";
            this.ctrlTaggingName16.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName16.LanguageID = "DEF_Fire";
            this.ctrlTaggingName16.Location = new System.Drawing.Point(14, 266);
            this.ctrlTaggingName16.Name = "ctrlTaggingName16";
            this.ctrlTaggingName16.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName16.StatusCode = "F";
            this.ctrlTaggingName16.TabIndex = 159;
            this.ctrlTaggingName16.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlTaggingName16.TagText = "Fire";
            this.ctrlTaggingName16.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName17
            // 
            this.ctrlTaggingName17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName17.ColorText = "P";
            this.ctrlTaggingName17.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName17.LanguageID = "DEF_Pause";
            this.ctrlTaggingName17.Location = new System.Drawing.Point(14, 191);
            this.ctrlTaggingName17.Name = "ctrlTaggingName17";
            this.ctrlTaggingName17.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName17.StatusCode = "P";
            this.ctrlTaggingName17.TabIndex = 158;
            this.ctrlTaggingName17.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.ctrlTaggingName17.TagText = "Pause";
            this.ctrlTaggingName17.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName18
            // 
            this.ctrlTaggingName18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName18.ColorText = "I";
            this.ctrlTaggingName18.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName18.LanguageID = "DEF_Idle";
            this.ctrlTaggingName18.Location = new System.Drawing.Point(14, 116);
            this.ctrlTaggingName18.Name = "ctrlTaggingName18";
            this.ctrlTaggingName18.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName18.StatusCode = "I";
            this.ctrlTaggingName18.TabIndex = 157;
            this.ctrlTaggingName18.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingName18.TagText = "Idle";
            this.ctrlTaggingName18.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName19
            // 
            this.ctrlTaggingName19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName19.ColorText = "R";
            this.ctrlTaggingName19.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName19.LanguageID = "DEF_Running";
            this.ctrlTaggingName19.Location = new System.Drawing.Point(14, 141);
            this.ctrlTaggingName19.Name = "ctrlTaggingName19";
            this.ctrlTaggingName19.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName19.StatusCode = "R";
            this.ctrlTaggingName19.TabIndex = 156;
            this.ctrlTaggingName19.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingName19.TagText = "Running";
            this.ctrlTaggingName19.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName20
            // 
            this.ctrlTaggingName20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName20.ColorText = "L";
            this.ctrlTaggingName20.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName20.LanguageID = "DEF_Loading";
            this.ctrlTaggingName20.Location = new System.Drawing.Point(14, 241);
            this.ctrlTaggingName20.Name = "ctrlTaggingName20";
            this.ctrlTaggingName20.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName20.StatusCode = "L";
            this.ctrlTaggingName20.TabIndex = 155;
            this.ctrlTaggingName20.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(101)))), ((int)(((byte)(58)))));
            this.ctrlTaggingName20.TagText = "Loading";
            this.ctrlTaggingName20.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong6
            // 
            this.ctrlTaggingNameLong6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong6.ColorText = "CCCV";
            this.ctrlTaggingNameLong6.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong6.LanguageID = "DEF_Discharge";
            this.ctrlTaggingNameLong6.Location = new System.Drawing.Point(14, 498);
            this.ctrlTaggingNameLong6.Name = "ctrlTaggingNameLong6";
            this.ctrlTaggingNameLong6.Size = new System.Drawing.Size(253, 30);
            this.ctrlTaggingNameLong6.StatusCode = "16";
            this.ctrlTaggingNameLong6.TabIndex = 154;
            this.ctrlTaggingNameLong6.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong6.TagText = "Discharge";
            this.ctrlTaggingNameLong6.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong3
            // 
            this.ctrlTaggingNameLong3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong3.ColorText = "CCCV";
            this.ctrlTaggingNameLong3.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong3.LanguageID = "DEF_Charge";
            this.ctrlTaggingNameLong3.Location = new System.Drawing.Point(14, 445);
            this.ctrlTaggingNameLong3.Name = "ctrlTaggingNameLong3";
            this.ctrlTaggingNameLong3.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong3.StatusCode = "4";
            this.ctrlTaggingNameLong3.TabIndex = 153;
            this.ctrlTaggingNameLong3.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong3.TagText = "Charge";
            this.ctrlTaggingNameLong3.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong8
            // 
            this.ctrlTaggingNameLong8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong8.ColorText = "Data";
            this.ctrlTaggingNameLong8.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong8.LanguageID = "DEF_Data_Error";
            this.ctrlTaggingNameLong8.Location = new System.Drawing.Point(14, 578);
            this.ctrlTaggingNameLong8.Name = "ctrlTaggingNameLong8";
            this.ctrlTaggingNameLong8.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong8.StatusCode = "0";
            this.ctrlTaggingNameLong8.TabIndex = 152;
            this.ctrlTaggingNameLong8.TagColor = System.Drawing.Color.Red;
            this.ctrlTaggingNameLong8.TagText = "Data Error";
            this.ctrlTaggingNameLong8.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong5
            // 
            this.ctrlTaggingNameLong5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong5.ColorText = "RES";
            this.ctrlTaggingNameLong5.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong5.LanguageID = "DEF_REST";
            this.ctrlTaggingNameLong5.Location = new System.Drawing.Point(14, 552);
            this.ctrlTaggingNameLong5.Name = "ctrlTaggingNameLong5";
            this.ctrlTaggingNameLong5.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong5.StatusCode = "32";
            this.ctrlTaggingNameLong5.TabIndex = 151;
            this.ctrlTaggingNameLong5.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctrlTaggingNameLong5.TagText = "REST";
            this.ctrlTaggingNameLong5.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong4
            // 
            this.ctrlTaggingNameLong4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong4.ColorText = "OCV";
            this.ctrlTaggingNameLong4.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong4.LanguageID = "DEF_OCV";
            this.ctrlTaggingNameLong4.Location = new System.Drawing.Point(14, 525);
            this.ctrlTaggingNameLong4.Name = "ctrlTaggingNameLong4";
            this.ctrlTaggingNameLong4.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong4.StatusCode = "1";
            this.ctrlTaggingNameLong4.TabIndex = 150;
            this.ctrlTaggingNameLong4.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ctrlTaggingNameLong4.TagText = "OCV";
            this.ctrlTaggingNameLong4.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong2
            // 
            this.ctrlTaggingNameLong2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong2.ColorText = "CC";
            this.ctrlTaggingNameLong2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong2.LanguageID = "DEF_Discharge";
            this.ctrlTaggingNameLong2.Location = new System.Drawing.Point(14, 471);
            this.ctrlTaggingNameLong2.Name = "ctrlTaggingNameLong2";
            this.ctrlTaggingNameLong2.Size = new System.Drawing.Size(253, 30);
            this.ctrlTaggingNameLong2.StatusCode = "8";
            this.ctrlTaggingNameLong2.TabIndex = 149;
            this.ctrlTaggingNameLong2.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong2.TagText = "Discharge";
            this.ctrlTaggingNameLong2.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong1
            // 
            this.ctrlTaggingNameLong1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong1.ColorText = "CC";
            this.ctrlTaggingNameLong1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong1.LanguageID = "DEF_Charge";
            this.ctrlTaggingNameLong1.Location = new System.Drawing.Point(14, 419);
            this.ctrlTaggingNameLong1.Name = "ctrlTaggingNameLong1";
            this.ctrlTaggingNameLong1.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong1.StatusCode = "2";
            this.ctrlTaggingNameLong1.TabIndex = 148;
            this.ctrlTaggingNameLong1.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong1.TagText = "Charge";
            this.ctrlTaggingNameLong1.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.AutoSize = true;
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_Operation_Mode";
            this.ctrlLabel2.Location = new System.Drawing.Point(10, 399);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(109, 16);
            this.ctrlLabel2.TabIndex = 147;
            this.ctrlLabel2.Text = "Operation Mode";
            // 
            // CtrlFormationHPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.Name = "CtrlFormationHPC";
            this.Size = new System.Drawing.Size(1919, 945);
            this.Tag = "";
            this.Load += new System.EventHandler(this.CtrlFormationHPC_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlHPCTemp ctrlHPCTemp1;
        private Controlls.CtrlHPCTemp ctrlHPCTemp2;
        private Controlls.CtrlHPC ctrlHPC1;
        private Controlls.CtrlHPC ctrlHPC2;
        private System.Windows.Forms.Panel panel1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong6;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong3;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong8;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong5;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong4;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong2;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel15;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName4;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel14;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName3;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName2;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel13;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName16;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName17;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName18;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName19;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName20;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel3;
        private Controlls.WindowsForms.CtrlLED RestServer;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel4;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel12;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName21;
    }
}
