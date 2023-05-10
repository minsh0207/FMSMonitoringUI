namespace FMSMonitoringUI
{
    partial class MainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scMainPanel = new System.Windows.Forms.SplitContainer();
            this.lbVersionInfo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.AlarmOccur = new System.Windows.Forms.PictureBox();
            this.cbUsePopUp = new FMSMonitoringUI.Controlls.WindowsForms.CtrlCheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbUserName = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.barFormationHPC = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.lbCurrentTime = new System.Windows.Forms.Label();
            this.barMain = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.barAging = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.barFormationCHG = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).BeginInit();
            this.scMainPanel.Panel1.SuspendLayout();
            this.scMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmOccur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // scMainPanel
            // 
            this.scMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.scMainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainPanel.IsSplitterFixed = true;
            this.scMainPanel.Location = new System.Drawing.Point(2, 2);
            this.scMainPanel.Name = "scMainPanel";
            this.scMainPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainPanel.Panel1
            // 
            this.scMainPanel.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.scMainPanel.Panel1.Controls.Add(this.lbVersionInfo);
            this.scMainPanel.Panel1.Controls.Add(this.AlarmOccur);
            this.scMainPanel.Panel1.Controls.Add(this.cbUsePopUp);
            this.scMainPanel.Panel1.Controls.Add(this.pictureBox1);
            this.scMainPanel.Panel1.Controls.Add(this.pictureBox2);
            this.scMainPanel.Panel1.Controls.Add(this.lbUserName);
            this.scMainPanel.Panel1.Controls.Add(this.barFormationHPC);
            this.scMainPanel.Panel1.Controls.Add(this.lbCurrentTime);
            this.scMainPanel.Panel1.Controls.Add(this.barMain);
            this.scMainPanel.Panel1.Controls.Add(this.barAging);
            this.scMainPanel.Panel1.Controls.Add(this.barFormationCHG);
            // 
            // scMainPanel.Panel2
            // 
            this.scMainPanel.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.scMainPanel.Size = new System.Drawing.Size(1900, 975);
            this.scMainPanel.SplitterDistance = 62;
            this.scMainPanel.TabIndex = 0;
            // 
            // lbVersionInfo
            // 
            this.lbVersionInfo.AutoSize = true;
            this.lbVersionInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbVersionInfo.ForeColor = System.Drawing.Color.White;
            this.lbVersionInfo.LanguageID = "";
            this.lbVersionInfo.Location = new System.Drawing.Point(1776, 45);
            this.lbVersionInfo.Name = "lbVersionInfo";
            this.lbVersionInfo.Size = new System.Drawing.Size(58, 12);
            this.lbVersionInfo.TabIndex = 114;
            this.lbVersionInfo.Text = "lbVersion";
            this.lbVersionInfo.Click += new System.EventHandler(this.lbVersionInfo_Click);
            // 
            // AlarmOccur
            // 
            this.AlarmOccur.Image = ((System.Drawing.Image)(resources.GetObject("AlarmOccur.Image")));
            this.AlarmOccur.Location = new System.Drawing.Point(1194, 9);
            this.AlarmOccur.Name = "AlarmOccur";
            this.AlarmOccur.Size = new System.Drawing.Size(50, 45);
            this.AlarmOccur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlarmOccur.TabIndex = 113;
            this.AlarmOccur.TabStop = false;
            // 
            // cbUsePopUp
            // 
            this.cbUsePopUp.AutoSize = true;
            this.cbUsePopUp.ForeColor = System.Drawing.Color.White;
            this.cbUsePopUp.LanguageID = "DEF_Use_Trouble_Alarm_Popup";
            this.cbUsePopUp.Location = new System.Drawing.Point(1269, 27);
            this.cbUsePopUp.Name = "cbUsePopUp";
            this.cbUsePopUp.Size = new System.Drawing.Size(171, 16);
            this.cbUsePopUp.TabIndex = 112;
            this.cbUsePopUp.Text = "Use Trouble Alarm PopUp";
            this.cbUsePopUp.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FMSMonitoringUI.Properties.Resources.VerkorIcon;
            this.pictureBox1.Location = new System.Drawing.Point(20, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1657, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(157)))), ((int)(((byte)(206)))));
            this.lbUserName.LanguageID = "DEF_User";
            this.lbUserName.Location = new System.Drawing.Point(1697, 21);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(45, 19);
            this.lbUserName.TabIndex = 6;
            this.lbUserName.Text = "User";
            // 
            // barFormationHPC
            // 
            this.barFormationHPC.AccessibleName = "";
            this.barFormationHPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barFormationHPC.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barFormationHPC.ForeColor = System.Drawing.Color.White;
            this.barFormationHPC.LanguageID = "DEF_HPC";
            this.barFormationHPC.Location = new System.Drawing.Point(696, 10);
            this.barFormationHPC.Margin = new System.Windows.Forms.Padding(4);
            this.barFormationHPC.Name = "barFormationHPC";
            this.barFormationHPC.Size = new System.Drawing.Size(147, 50);
            this.barFormationHPC.TabIndex = 5;
            this.barFormationHPC.TitleText = "HPC";
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.AutoSize = true;
            this.lbCurrentTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lbCurrentTime.Location = new System.Drawing.Point(1472, 26);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(161, 19);
            this.lbCurrentTime.TabIndex = 4;
            this.lbCurrentTime.Text = "2022-12-20 09:12:30";
            // 
            // barMain
            // 
            this.barMain.AccessibleName = "";
            this.barMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barMain.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barMain.ForeColor = System.Drawing.Color.White;
            this.barMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.barMain.LanguageID = "DEF_Entire_Formation_Line";
            this.barMain.Location = new System.Drawing.Point(200, 10);
            this.barMain.Margin = new System.Windows.Forms.Padding(4);
            this.barMain.Name = "barMain";
            this.barMain.Size = new System.Drawing.Size(234, 50);
            this.barMain.TabIndex = 1;
            this.barMain.TitleText = "Entire Formation Line";
            // 
            // barAging
            // 
            this.barAging.AccessibleName = "";
            this.barAging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barAging.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barAging.ForeColor = System.Drawing.Color.White;
            this.barAging.LanguageID = "DEF_Aging";
            this.barAging.Location = new System.Drawing.Point(426, 10);
            this.barAging.Margin = new System.Windows.Forms.Padding(4);
            this.barAging.Name = "barAging";
            this.barAging.Size = new System.Drawing.Size(147, 50);
            this.barAging.TabIndex = 2;
            this.barAging.TitleText = "Aging";
            // 
            // barFormationCHG
            // 
            this.barFormationCHG.AccessibleName = "";
            this.barFormationCHG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barFormationCHG.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barFormationCHG.ForeColor = System.Drawing.Color.White;
            this.barFormationCHG.LanguageID = "DEF_Formation";
            this.barFormationCHG.Location = new System.Drawing.Point(565, 10);
            this.barFormationCHG.Margin = new System.Windows.Forms.Padding(4);
            this.barFormationCHG.Name = "barFormationCHG";
            this.barFormationCHG.Size = new System.Drawing.Size(147, 50);
            this.barFormationCHG.TabIndex = 3;
            this.barFormationCHG.TitleText = "Formation";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1904, 979);
            this.Controls.Add(this.scMainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "FMS Monitoring System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.scMainPanel.Panel1.ResumeLayout(false);
            this.scMainPanel.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).EndInit();
            this.scMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlarmOccur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMainPanel;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barFormationCHG;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barAging;
        public MonitoringUI.Controlls.CtrlTitleBarLabel barMain;
        private System.Windows.Forms.Label lbCurrentTime;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barFormationHPC;
        private Controlls.WindowsForms.CtrlLabel lbUserName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controlls.WindowsForms.CtrlCheckBox cbUsePopUp;
        private System.Windows.Forms.PictureBox AlarmOccur;
        private Controlls.WindowsForms.CtrlLabel lbVersionInfo;
    }
}

