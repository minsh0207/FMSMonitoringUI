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
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlTaggingNameLong6 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong3 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong8 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong5 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong4 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong2 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
            this.ctrlTaggingNameLong1 = new MonitoringUI.Controlls.CtrlTaggingNameLong();
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
            // ctrlLabel2
            // 
            this.ctrlLabel2.AutoSize = true;
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_Operation_Mode";
            this.ctrlLabel2.Location = new System.Drawing.Point(15, 334);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(109, 16);
            this.ctrlLabel2.TabIndex = 147;
            this.ctrlLabel2.Text = "Operation Mode";
            // 
            // ctrlTaggingNameLong6
            // 
            this.ctrlTaggingNameLong6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTaggingNameLong6.ColorText = "CCCV";
            this.ctrlTaggingNameLong6.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTaggingNameLong6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTaggingNameLong6.LanguageID = "DEF_Discharge";
            this.ctrlTaggingNameLong6.Location = new System.Drawing.Point(14, 443);
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
            this.ctrlTaggingNameLong3.Location = new System.Drawing.Point(14, 384);
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
            this.ctrlTaggingNameLong8.Location = new System.Drawing.Point(14, 535);
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
            this.ctrlTaggingNameLong5.Location = new System.Drawing.Point(14, 504);
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
            this.ctrlTaggingNameLong4.Location = new System.Drawing.Point(14, 473);
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
            this.ctrlTaggingNameLong2.Location = new System.Drawing.Point(14, 413);
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
            this.ctrlTaggingNameLong1.Location = new System.Drawing.Point(14, 354);
            this.ctrlTaggingNameLong1.Name = "ctrlTaggingNameLong1";
            this.ctrlTaggingNameLong1.Size = new System.Drawing.Size(232, 30);
            this.ctrlTaggingNameLong1.StatusCode = "2";
            this.ctrlTaggingNameLong1.TabIndex = 148;
            this.ctrlTaggingNameLong1.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ctrlTaggingNameLong1.TagText = "Charge";
            this.ctrlTaggingNameLong1.TextColor = System.Drawing.Color.Black;
            // 
            // ctrlLabel15
            // 
            this.ctrlLabel15.AutoSize = true;
            this.ctrlLabel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.ctrlLabel15.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel15.LanguageID = "DEF_Smoke_Only_or_Both";
            this.ctrlLabel15.Location = new System.Drawing.Point(21, 269);
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
            this.ctrlTaggingName4.Location = new System.Drawing.Point(14, 241);
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
            this.ctrlLabel14.Location = new System.Drawing.Point(21, 222);
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
            this.ctrlTaggingName3.Location = new System.Drawing.Point(14, 140);
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
            this.ctrlTaggingName2.Location = new System.Drawing.Point(14, 86);
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
            this.ctrlLabel13.Location = new System.Drawing.Point(15, 13);
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
            this.ctrlTaggingName16.Location = new System.Drawing.Point(14, 194);
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
            this.ctrlTaggingName17.Location = new System.Drawing.Point(14, 113);
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
            this.ctrlTaggingName18.Location = new System.Drawing.Point(14, 32);
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
            this.ctrlTaggingName19.Location = new System.Drawing.Point(14, 59);
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
            this.ctrlTaggingName20.Location = new System.Drawing.Point(14, 167);
            this.ctrlTaggingName20.Name = "ctrlTaggingName20";
            this.ctrlTaggingName20.Size = new System.Drawing.Size(179, 30);
            this.ctrlTaggingName20.StatusCode = "L";
            this.ctrlTaggingName20.TabIndex = 155;
            this.ctrlTaggingName20.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(101)))), ((int)(((byte)(58)))));
            this.ctrlTaggingName20.TagText = "Loading";
            this.ctrlTaggingName20.TextColor = System.Drawing.Color.Black;
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
    }
}
