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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ctrlHPC1 = new FMSMonitoringUI.Controlls.CtrlHPC();
            this.ctrlHPCTemp1 = new FMSMonitoringUI.Controlls.CtrlHPCTemp();
            this.ctrlHPC2 = new FMSMonitoringUI.Controlls.CtrlHPC();
            this.ctrlHPCTemp2 = new FMSMonitoringUI.Controlls.CtrlHPCTemp();
            this.ctrlTaggingName16 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName17 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName18 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName19 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName20 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName21 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.label18 = new System.Windows.Forms.Label();
            this.ctrlTaggingNameLong6 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong3 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong8 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong5 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong4 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong2 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong1 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(310, 945);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
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
            this.ctrlHPC1.EqpID = "";
            this.ctrlHPC1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPC1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPC1.HpcID = " HPC JIG#1";
            this.ctrlHPC1.Location = new System.Drawing.Point(21, 28);
            this.ctrlHPC1.Name = "ctrlHPC1";
            this.ctrlHPC1.Size = new System.Drawing.Size(307, 343);
            this.ctrlHPC1.TabIndex = 2;
            // 
            // ctrlHPCTemp1
            // 
            this.ctrlHPCTemp1.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPCTemp1.EqpID = "";
            this.ctrlHPCTemp1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPCTemp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPCTemp1.Location = new System.Drawing.Point(353, 28);
            this.ctrlHPCTemp1.MaxCellCount = 30;
            this.ctrlHPCTemp1.Name = "ctrlHPCTemp1";
            this.ctrlHPCTemp1.Size = new System.Drawing.Size(420, 882);
            this.ctrlHPCTemp1.TabIndex = 1;
            this.ctrlHPCTemp1.TitleName = "JIG#1 Information";
            // 
            // ctrlHPC2
            // 
            this.ctrlHPC2.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPC2.EqpID = "";
            this.ctrlHPC2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPC2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPC2.HpcID = " HPC JIG#2";
            this.ctrlHPC2.Location = new System.Drawing.Point(21, 28);
            this.ctrlHPC2.Name = "ctrlHPC2";
            this.ctrlHPC2.Size = new System.Drawing.Size(307, 343);
            this.ctrlHPC2.TabIndex = 3;
            // 
            // ctrlHPCTemp2
            // 
            this.ctrlHPCTemp2.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPCTemp2.EqpID = "";
            this.ctrlHPCTemp2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPCTemp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPCTemp2.Location = new System.Drawing.Point(353, 28);
            this.ctrlHPCTemp2.MaxCellCount = 30;
            this.ctrlHPCTemp2.Name = "ctrlHPCTemp2";
            this.ctrlHPCTemp2.Size = new System.Drawing.Size(420, 882);
            this.ctrlHPCTemp2.TabIndex = 2;
            this.ctrlHPCTemp2.TitleName = "JIG#2 Information";
            // 
            // ctrlTaggingName16
            // 
            this.ctrlTaggingName16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName16.ColorText = "F";
            this.ctrlTaggingName16.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName16.LanguageID = "";
            this.ctrlTaggingName16.Location = new System.Drawing.Point(14, 185);
            this.ctrlTaggingName16.Name = "ctrlTaggingName16";
            this.ctrlTaggingName16.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName16.TabIndex = 95;
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
            this.ctrlTaggingName17.LanguageID = "";
            this.ctrlTaggingName17.Location = new System.Drawing.Point(14, 154);
            this.ctrlTaggingName17.Name = "ctrlTaggingName17";
            this.ctrlTaggingName17.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName17.TabIndex = 94;
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
            this.ctrlTaggingName18.LanguageID = "";
            this.ctrlTaggingName18.Location = new System.Drawing.Point(14, 92);
            this.ctrlTaggingName18.Name = "ctrlTaggingName18";
            this.ctrlTaggingName18.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName18.TabIndex = 93;
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
            this.ctrlTaggingName19.LanguageID = "";
            this.ctrlTaggingName19.Location = new System.Drawing.Point(14, 123);
            this.ctrlTaggingName19.Name = "ctrlTaggingName19";
            this.ctrlTaggingName19.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName19.TabIndex = 92;
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
            this.ctrlTaggingName20.LanguageID = "";
            this.ctrlTaggingName20.Location = new System.Drawing.Point(14, 62);
            this.ctrlTaggingName20.Name = "ctrlTaggingName20";
            this.ctrlTaggingName20.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName20.TabIndex = 91;
            this.ctrlTaggingName20.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ctrlTaggingName20.TagText = "Tray On";
            this.ctrlTaggingName20.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName21
            // 
            this.ctrlTaggingName21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName21.ColorText = "M";
            this.ctrlTaggingName21.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName21.LanguageID = "";
            this.ctrlTaggingName21.Location = new System.Drawing.Point(14, 32);
            this.ctrlTaggingName21.Name = "ctrlTaggingName21";
            this.ctrlTaggingName21.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName21.TabIndex = 90;
            this.ctrlTaggingName21.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(135)))), ((int)(((byte)(21)))));
            this.ctrlTaggingName21.TagText = "Maintenance";
            this.ctrlTaggingName21.TextColor = System.Drawing.Color.Black;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(15, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 16);
            this.label18.TabIndex = 89;
            this.label18.Text = "Eqp Status";
            // 
            // ctrlTaggingNameLong6
            // 
            this.ctrlTaggingNameLong6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong6.ColorText = "CCCV";
            this.ctrlTaggingNameLong6.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong6.Location = new System.Drawing.Point(14, 362);
            this.ctrlTaggingNameLong6.Name = "ctrlTaggingNameLong6";
            this.ctrlTaggingNameLong6.Size = new System.Drawing.Size(253, 30);
            this.ctrlTaggingNameLong6.TabIndex = 130;
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
            this.ctrlTaggingNameLong3.Location = new System.Drawing.Point(14, 303);
            this.ctrlTaggingNameLong3.Name = "ctrlTaggingNameLong3";
            this.ctrlTaggingNameLong3.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong3.TabIndex = 129;
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
            this.ctrlTaggingNameLong8.Location = new System.Drawing.Point(14, 454);
            this.ctrlTaggingNameLong8.Name = "ctrlTaggingNameLong8";
            this.ctrlTaggingNameLong8.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong8.TabIndex = 128;
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
            this.ctrlTaggingNameLong5.Location = new System.Drawing.Point(14, 423);
            this.ctrlTaggingNameLong5.Name = "ctrlTaggingNameLong5";
            this.ctrlTaggingNameLong5.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong5.TabIndex = 127;
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
            this.ctrlTaggingNameLong4.Location = new System.Drawing.Point(14, 392);
            this.ctrlTaggingNameLong4.Name = "ctrlTaggingNameLong4";
            this.ctrlTaggingNameLong4.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong4.TabIndex = 126;
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
            this.ctrlTaggingNameLong2.Location = new System.Drawing.Point(14, 332);
            this.ctrlTaggingNameLong2.Name = "ctrlTaggingNameLong2";
            this.ctrlTaggingNameLong2.Size = new System.Drawing.Size(253, 30);
            this.ctrlTaggingNameLong2.TabIndex = 125;
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
            this.ctrlTaggingNameLong1.Location = new System.Drawing.Point(14, 273);
            this.ctrlTaggingNameLong1.Name = "ctrlTaggingNameLong1";
            this.ctrlTaggingNameLong1.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong1.TabIndex = 124;
            this.ctrlTaggingNameLong1.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong1.TagText = "Charge";
            this.ctrlTaggingNameLong1.TextColor = System.Drawing.Color.Black;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 16);
            this.label9.TabIndex = 123;
            this.label9.Text = "Operation Mode";
            // 
            // CtrlFormationHPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ctrlTaggingNameLong6);
            this.Controls.Add(this.ctrlTaggingNameLong3);
            this.Controls.Add(this.ctrlTaggingNameLong8);
            this.Controls.Add(this.ctrlTaggingNameLong5);
            this.Controls.Add(this.ctrlTaggingNameLong4);
            this.Controls.Add(this.ctrlTaggingNameLong2);
            this.Controls.Add(this.ctrlTaggingNameLong1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ctrlTaggingName16);
            this.Controls.Add(this.ctrlTaggingName17);
            this.Controls.Add(this.ctrlTaggingName18);
            this.Controls.Add(this.ctrlTaggingName19);
            this.Controls.Add(this.ctrlTaggingName20);
            this.Controls.Add(this.ctrlTaggingName21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitter1);
            this.Name = "CtrlFormationHPC";
            this.Size = new System.Drawing.Size(1919, 945);
            this.Tag = "";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlHPCTemp ctrlHPCTemp1;
        private Controlls.CtrlHPCTemp ctrlHPCTemp2;
        private Controlls.CtrlHPC ctrlHPC1;
        private Controlls.CtrlHPC ctrlHPC2;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName16;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName17;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName18;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName19;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName20;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName21;
        private System.Windows.Forms.Label label18;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong6;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong3;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong8;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong5;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong4;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong2;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong1;
        private System.Windows.Forms.Label label9;
    }
}
