﻿namespace FMSMonitoringUI
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbUserName = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.barFormationHPC = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.lbCurrentTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.barMain = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.barAging = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.barFormationCHG = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).BeginInit();
            this.scMainPanel.Panel1.SuspendLayout();
            this.scMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.scMainPanel.Panel1.Controls.Add(this.pictureBox2);
            this.scMainPanel.Panel1.Controls.Add(this.lbUserName);
            this.scMainPanel.Panel1.Controls.Add(this.barFormationHPC);
            this.scMainPanel.Panel1.Controls.Add(this.lbCurrentTime);
            this.scMainPanel.Panel1.Controls.Add(this.pictureBox1);
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
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1730, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 24);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbUserName.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbUserName.ForeColor = System.Drawing.Color.White;
            this.lbUserName.LanguageID = "DEF_User";
            this.lbUserName.Location = new System.Drawing.Point(1760, 28);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(41, 13);
            this.lbUserName.TabIndex = 6;
            this.lbUserName.Text = "User";
            // 
            // barFormationHPC
            // 
            this.barFormationHPC.AccessibleName = "";
            this.barFormationHPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barFormationHPC.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barFormationHPC.ForeColor = System.Drawing.Color.White;
            this.barFormationHPC.LanguageID = "DEF_Formation(HPC)";
            this.barFormationHPC.Location = new System.Drawing.Point(641, 10);
            this.barFormationHPC.Margin = new System.Windows.Forms.Padding(4);
            this.barFormationHPC.Name = "barFormationHPC";
            this.barFormationHPC.Size = new System.Drawing.Size(141, 50);
            this.barFormationHPC.TabIndex = 5;
            this.barFormationHPC.TitleText = "Formation(HPC)";
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.AutoSize = true;
            this.lbCurrentTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lbCurrentTime.Location = new System.Drawing.Point(1569, 28);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(125, 16);
            this.lbCurrentTime.TabIndex = 4;
            this.lbCurrentTime.Text = "2022-12-20 09:12:30";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FMSMonitoringUI.Properties.Resources.VerkorIcon;
            this.pictureBox1.Location = new System.Drawing.Point(37, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // barMain
            // 
            this.barMain.AccessibleName = "";
            this.barMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barMain.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barMain.ForeColor = System.Drawing.Color.White;
            this.barMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.barMain.LanguageID = "DEF_Main";
            this.barMain.Location = new System.Drawing.Point(212, 10);
            this.barMain.Margin = new System.Windows.Forms.Padding(4);
            this.barMain.Name = "barMain";
            this.barMain.Size = new System.Drawing.Size(112, 50);
            this.barMain.TabIndex = 1;
            this.barMain.TitleText = "Main";
            // 
            // barAging
            // 
            this.barAging.AccessibleName = "";
            this.barAging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barAging.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barAging.ForeColor = System.Drawing.Color.White;
            this.barAging.LanguageID = "DEF_Aging";
            this.barAging.Location = new System.Drawing.Point(334, 10);
            this.barAging.Margin = new System.Windows.Forms.Padding(4);
            this.barAging.Name = "barAging";
            this.barAging.Size = new System.Drawing.Size(112, 50);
            this.barAging.TabIndex = 2;
            this.barAging.TitleText = "Aging";
            // 
            // barFormationCHG
            // 
            this.barFormationCHG.AccessibleName = "";
            this.barFormationCHG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barFormationCHG.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barFormationCHG.ForeColor = System.Drawing.Color.White;
            this.barFormationCHG.LanguageID = "DEF_Formation(CHG)";
            this.barFormationCHG.Location = new System.Drawing.Point(457, 10);
            this.barFormationCHG.Margin = new System.Windows.Forms.Padding(4);
            this.barFormationCHG.Name = "barFormationCHG";
            this.barFormationCHG.Size = new System.Drawing.Size(154, 50);
            this.barFormationCHG.TabIndex = 3;
            this.barFormationCHG.TitleText = "Formation(CHG)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1904, 979);
            this.Controls.Add(this.scMainPanel);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "MonitoringUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.scMainPanel.Panel1.ResumeLayout(false);
            this.scMainPanel.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).EndInit();
            this.scMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barFormationCHG;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barAging;
        public MonitoringUI.Controlls.CtrlTitleBarLabel barMain;
        private System.Windows.Forms.Label lbCurrentTime;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barFormationHPC;
        private Controlls.WindowsForms.CtrlLabel lbUserName;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

