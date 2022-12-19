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
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlTaggingNameLong1 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong2 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong4 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong5 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong8 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ctrlHPCTemp1 = new FMSMonitoringUI.Controlls.CtrlHPCTemp();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlHPC1 = new FMSMonitoringUI.Controlls.CtrlHPC();
            this.ctrlHPCTemp2 = new FMSMonitoringUI.Controlls.CtrlHPCTemp();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlHPC2 = new FMSMonitoringUI.Controlls.CtrlHPC();
            this.ctrlTaggingName15 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName14 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName13 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName12 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName11 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName10 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName9 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName8 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName7 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName5 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlTaggingName3 = new MonitoringUI.Controlls.CtrlTaggingName();
            this.ctrlTaggingName4 = new MonitoringUI.Controlls.CtrlTaggingName();
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 435);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 16);
            this.label9.TabIndex = 76;
            this.label9.Text = "Operation Status";
            // 
            // ctrlTaggingNameLong1
            // 
            this.ctrlTaggingNameLong1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong1.ColorText = "CHG";
            this.ctrlTaggingNameLong1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong1.Location = new System.Drawing.Point(14, 458);
            this.ctrlTaggingNameLong1.Name = "ctrlTaggingNameLong1";
            this.ctrlTaggingNameLong1.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong1.TabIndex = 77;
            this.ctrlTaggingNameLong1.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong1.TagText = "Charge";
            this.ctrlTaggingNameLong1.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong2
            // 
            this.ctrlTaggingNameLong2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong2.ColorText = "DIS";
            this.ctrlTaggingNameLong2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong2.Location = new System.Drawing.Point(14, 488);
            this.ctrlTaggingNameLong2.Name = "ctrlTaggingNameLong2";
            this.ctrlTaggingNameLong2.Size = new System.Drawing.Size(253, 30);
            this.ctrlTaggingNameLong2.TabIndex = 78;
            this.ctrlTaggingNameLong2.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong2.TagText = "Discharge";
            this.ctrlTaggingNameLong2.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong4
            // 
            this.ctrlTaggingNameLong4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong4.ColorText = "OCV";
            this.ctrlTaggingNameLong4.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong4.Location = new System.Drawing.Point(14, 519);
            this.ctrlTaggingNameLong4.Name = "ctrlTaggingNameLong4";
            this.ctrlTaggingNameLong4.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong4.TabIndex = 80;
            this.ctrlTaggingNameLong4.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ctrlTaggingNameLong4.TagText = "OCV";
            this.ctrlTaggingNameLong4.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong5
            // 
            this.ctrlTaggingNameLong5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong5.ColorText = "RES";
            this.ctrlTaggingNameLong5.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong5.Location = new System.Drawing.Point(14, 550);
            this.ctrlTaggingNameLong5.Name = "ctrlTaggingNameLong5";
            this.ctrlTaggingNameLong5.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong5.TabIndex = 81;
            this.ctrlTaggingNameLong5.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctrlTaggingNameLong5.TagText = "REST";
            this.ctrlTaggingNameLong5.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingNameLong8
            // 
            this.ctrlTaggingNameLong8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong8.ColorText = "Data";
            this.ctrlTaggingNameLong8.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong8.Location = new System.Drawing.Point(14, 581);
            this.ctrlTaggingNameLong8.Name = "ctrlTaggingNameLong8";
            this.ctrlTaggingNameLong8.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong8.TabIndex = 84;
            this.ctrlTaggingNameLong8.TagColor = System.Drawing.Color.Red;
            this.ctrlTaggingNameLong8.TagText = "Data Error";
            this.ctrlTaggingNameLong8.TextColor = System.Drawing.Color.Black;
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
            this.splitContainer1.Location = new System.Drawing.Point(316, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ctrlHPCTemp1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ctrlHPC1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlHPCTemp2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlHPC2);
            this.splitContainer1.Size = new System.Drawing.Size(1604, 945);
            this.splitContainer1.SplitterDistance = 470;
            this.splitContainer1.TabIndex = 88;
            // 
            // ctrlHPCTemp1
            // 
            this.ctrlHPCTemp1.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPCTemp1.EqpID = "";
            this.ctrlHPCTemp1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPCTemp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPCTemp1.Location = new System.Drawing.Point(374, 75);
            this.ctrlHPCTemp1.Name = "ctrlHPCTemp1";
            this.ctrlHPCTemp1.Size = new System.Drawing.Size(1134, 161);
            this.ctrlHPCTemp1.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 57);
            this.label1.TabIndex = 92;
            this.label1.Text = "HPC #1";
            // 
            // ctrlHPC1
            // 
            this.ctrlHPC1.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPC1.EqpID = "";
            this.ctrlHPC1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPC1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPC1.HpcID = " HPC #1";
            this.ctrlHPC1.Location = new System.Drawing.Point(97, 74);
            this.ctrlHPC1.Name = "ctrlHPC1";
            this.ctrlHPC1.Size = new System.Drawing.Size(249, 222);
            this.ctrlHPC1.TabIndex = 91;
            // 
            // ctrlHPCTemp2
            // 
            this.ctrlHPCTemp2.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPCTemp2.EqpID = "";
            this.ctrlHPCTemp2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPCTemp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPCTemp2.Location = new System.Drawing.Point(374, 76);
            this.ctrlHPCTemp2.Name = "ctrlHPCTemp2";
            this.ctrlHPCTemp2.Size = new System.Drawing.Size(1136, 161);
            this.ctrlHPCTemp2.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 57);
            this.label2.TabIndex = 94;
            this.label2.Text = "HPC #2";
            // 
            // ctrlHPC2
            // 
            this.ctrlHPC2.BackColor = System.Drawing.Color.DimGray;
            this.ctrlHPC2.EqpID = "";
            this.ctrlHPC2.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlHPC2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlHPC2.HpcID = " HPC #2";
            this.ctrlHPC2.Location = new System.Drawing.Point(97, 76);
            this.ctrlHPC2.Name = "ctrlHPC2";
            this.ctrlHPC2.Size = new System.Drawing.Size(249, 222);
            this.ctrlHPC2.TabIndex = 93;
            // 
            // ctrlTaggingName15
            // 
            this.ctrlTaggingName15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName15.ColorText = "U";
            this.ctrlTaggingName15.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName15.LanguageID = "";
            this.ctrlTaggingName15.Location = new System.Drawing.Point(14, 209);
            this.ctrlTaggingName15.Name = "ctrlTaggingName15";
            this.ctrlTaggingName15.Size = new System.Drawing.Size(168, 30);
            this.ctrlTaggingName15.TabIndex = 101;
            this.ctrlTaggingName15.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(77)))), ((int)(((byte)(89)))));
            this.ctrlTaggingName15.TagText = "Unloading";
            this.ctrlTaggingName15.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName14
            // 
            this.ctrlTaggingName14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName14.ColorText = "L";
            this.ctrlTaggingName14.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName14.LanguageID = "";
            this.ctrlTaggingName14.Location = new System.Drawing.Point(14, 89);
            this.ctrlTaggingName14.Name = "ctrlTaggingName14";
            this.ctrlTaggingName14.Size = new System.Drawing.Size(162, 30);
            this.ctrlTaggingName14.TabIndex = 100;
            this.ctrlTaggingName14.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(49)))), ((int)(((byte)(208)))));
            this.ctrlTaggingName14.TagText = "Loading";
            this.ctrlTaggingName14.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName13
            // 
            this.ctrlTaggingName13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName13.ColorText = "S";
            this.ctrlTaggingName13.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName13.LanguageID = "";
            this.ctrlTaggingName13.Location = new System.Drawing.Point(14, 269);
            this.ctrlTaggingName13.Name = "ctrlTaggingName13";
            this.ctrlTaggingName13.Size = new System.Drawing.Size(168, 30);
            this.ctrlTaggingName13.TabIndex = 99;
            this.ctrlTaggingName13.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ctrlTaggingName13.TagText = "Stop";
            this.ctrlTaggingName13.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName12
            // 
            this.ctrlTaggingName12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName12.ColorText = "N";
            this.ctrlTaggingName12.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName12.LanguageID = "";
            this.ctrlTaggingName12.Location = new System.Drawing.Point(14, 359);
            this.ctrlTaggingName12.Name = "ctrlTaggingName12";
            this.ctrlTaggingName12.Size = new System.Drawing.Size(168, 30);
            this.ctrlTaggingName12.TabIndex = 98;
            this.ctrlTaggingName12.TagColor = System.Drawing.Color.DarkGray;
            this.ctrlTaggingName12.TagText = "Not Use";
            this.ctrlTaggingName12.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName11
            // 
            this.ctrlTaggingName11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName11.ColorText = "F";
            this.ctrlTaggingName11.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName11.LanguageID = "";
            this.ctrlTaggingName11.Location = new System.Drawing.Point(14, 329);
            this.ctrlTaggingName11.Name = "ctrlTaggingName11";
            this.ctrlTaggingName11.Size = new System.Drawing.Size(168, 30);
            this.ctrlTaggingName11.TabIndex = 97;
            this.ctrlTaggingName11.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlTaggingName11.TagText = "Fire";
            this.ctrlTaggingName11.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName10
            // 
            this.ctrlTaggingName10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName10.ColorText = "T";
            this.ctrlTaggingName10.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName10.LanguageID = "";
            this.ctrlTaggingName10.Location = new System.Drawing.Point(14, 299);
            this.ctrlTaggingName10.Name = "ctrlTaggingName10";
            this.ctrlTaggingName10.Size = new System.Drawing.Size(168, 30);
            this.ctrlTaggingName10.TabIndex = 96;
            this.ctrlTaggingName10.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlTaggingName10.TagText = "Trouble";
            this.ctrlTaggingName10.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName9
            // 
            this.ctrlTaggingName9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName9.ColorText = "P";
            this.ctrlTaggingName9.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName9.LanguageID = "";
            this.ctrlTaggingName9.Location = new System.Drawing.Point(14, 239);
            this.ctrlTaggingName9.Name = "ctrlTaggingName9";
            this.ctrlTaggingName9.Size = new System.Drawing.Size(168, 30);
            this.ctrlTaggingName9.TabIndex = 95;
            this.ctrlTaggingName9.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.ctrlTaggingName9.TagText = "Pause";
            this.ctrlTaggingName9.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName8
            // 
            this.ctrlTaggingName8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName8.ColorText = "U";
            this.ctrlTaggingName8.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName8.LanguageID = "";
            this.ctrlTaggingName8.Location = new System.Drawing.Point(14, 179);
            this.ctrlTaggingName8.Name = "ctrlTaggingName8";
            this.ctrlTaggingName8.Size = new System.Drawing.Size(168, 30);
            this.ctrlTaggingName8.TabIndex = 94;
            this.ctrlTaggingName8.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(138)))));
            this.ctrlTaggingName8.TagText = "Unload Request";
            this.ctrlTaggingName8.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName7
            // 
            this.ctrlTaggingName7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName7.ColorText = "R";
            this.ctrlTaggingName7.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName7.LanguageID = "";
            this.ctrlTaggingName7.Location = new System.Drawing.Point(14, 149);
            this.ctrlTaggingName7.Name = "ctrlTaggingName7";
            this.ctrlTaggingName7.Size = new System.Drawing.Size(163, 30);
            this.ctrlTaggingName7.TabIndex = 93;
            this.ctrlTaggingName7.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingName7.TagText = "Running";
            this.ctrlTaggingName7.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName5
            // 
            this.ctrlTaggingName5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName5.ColorText = "A";
            this.ctrlTaggingName5.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName5.LanguageID = "";
            this.ctrlTaggingName5.Location = new System.Drawing.Point(14, 119);
            this.ctrlTaggingName5.Name = "ctrlTaggingName5";
            this.ctrlTaggingName5.Size = new System.Drawing.Size(163, 30);
            this.ctrlTaggingName5.TabIndex = 92;
            this.ctrlTaggingName5.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ctrlTaggingName5.TagText = "Tray Arrived";
            this.ctrlTaggingName5.TextColor = System.Drawing.Color.Black;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 91;
            this.label3.Text = "Process Status";
            // 
            // ctrlTaggingName3
            // 
            this.ctrlTaggingName3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName3.ColorText = "I";
            this.ctrlTaggingName3.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName3.LanguageID = "";
            this.ctrlTaggingName3.Location = new System.Drawing.Point(14, 29);
            this.ctrlTaggingName3.Name = "ctrlTaggingName3";
            this.ctrlTaggingName3.Size = new System.Drawing.Size(129, 30);
            this.ctrlTaggingName3.TabIndex = 90;
            this.ctrlTaggingName3.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingName3.TagText = "Idle";
            this.ctrlTaggingName3.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlTaggingName4
            // 
            this.ctrlTaggingName4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingName4.ColorText = "L";
            this.ctrlTaggingName4.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingName4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingName4.LanguageID = "";
            this.ctrlTaggingName4.Location = new System.Drawing.Point(14, 59);
            this.ctrlTaggingName4.Name = "ctrlTaggingName4";
            this.ctrlTaggingName4.Size = new System.Drawing.Size(162, 30);
            this.ctrlTaggingName4.TabIndex = 89;
            this.ctrlTaggingName4.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.ctrlTaggingName4.TagText = "Load Request";
            this.ctrlTaggingName4.TextColor = System.Drawing.Color.Black;
            // 
            // CtrlFormationHPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ctrlTaggingName15);
            this.Controls.Add(this.ctrlTaggingName14);
            this.Controls.Add(this.ctrlTaggingName13);
            this.Controls.Add(this.ctrlTaggingName12);
            this.Controls.Add(this.ctrlTaggingName11);
            this.Controls.Add(this.ctrlTaggingName10);
            this.Controls.Add(this.ctrlTaggingName9);
            this.Controls.Add(this.ctrlTaggingName8);
            this.Controls.Add(this.ctrlTaggingName7);
            this.Controls.Add(this.ctrlTaggingName5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlTaggingName3);
            this.Controls.Add(this.ctrlTaggingName4);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ctrlTaggingNameLong8);
            this.Controls.Add(this.ctrlTaggingNameLong5);
            this.Controls.Add(this.ctrlTaggingNameLong4);
            this.Controls.Add(this.ctrlTaggingNameLong2);
            this.Controls.Add(this.ctrlTaggingNameLong1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitter1);
            this.Name = "CtrlFormationHPC";
            this.Size = new System.Drawing.Size(1920, 945);
            this.Tag = "";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.Label label9;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong1;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong2;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong4;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong5;
        private MonitoringUI.Controlls.CtrlTaggingNameLong ctrlTaggingNameLong8;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlHPC ctrlHPC1;
        private System.Windows.Forms.Label label1;
        private Controlls.CtrlHPC ctrlHPC2;
        private System.Windows.Forms.Label label2;
        private Controlls.CtrlHPCTemp ctrlHPCTemp1;
        private Controlls.CtrlHPCTemp ctrlHPCTemp2;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName15;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName14;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName13;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName12;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName11;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName10;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName9;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName8;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName7;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName5;
        private System.Windows.Forms.Label label3;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName3;
        private MonitoringUI.Controlls.CtrlTaggingName ctrlTaggingName4;
    }
}
