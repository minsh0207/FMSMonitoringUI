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
            this.scMainPanel = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.barMain = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.barAging = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.barFormation = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).BeginInit();
            this.scMainPanel.Panel1.SuspendLayout();
            this.scMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scMainPanel
            // 
            this.scMainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainPanel.Location = new System.Drawing.Point(0, 0);
            this.scMainPanel.Name = "scMainPanel";
            this.scMainPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainPanel.Panel1
            // 
            this.scMainPanel.Panel1.Controls.Add(this.pictureBox1);
            this.scMainPanel.Panel1.Controls.Add(this.barMain);
            this.scMainPanel.Panel1.Controls.Add(this.barAging);
            this.scMainPanel.Panel1.Controls.Add(this.barFormation);
            this.scMainPanel.Size = new System.Drawing.Size(1904, 1041);
            this.scMainPanel.SplitterDistance = 68;
            this.scMainPanel.TabIndex = 0;
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
            this.barMain.Location = new System.Drawing.Point(212, 10);
            this.barMain.Margin = new System.Windows.Forms.Padding(4);
            this.barMain.Name = "barMain";
            this.barMain.Size = new System.Drawing.Size(134, 50);
            this.barMain.TabIndex = 1;
            this.barMain.TitleText = "Main";
            // 
            // barAging
            // 
            this.barAging.AccessibleName = "";
            this.barAging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barAging.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barAging.ForeColor = System.Drawing.Color.White;
            this.barAging.Location = new System.Drawing.Point(346, 10);
            this.barAging.Margin = new System.Windows.Forms.Padding(4);
            this.barAging.Name = "barAging";
            this.barAging.Size = new System.Drawing.Size(134, 50);
            this.barAging.TabIndex = 2;
            this.barAging.TitleText = "Aging";
            // 
            // barFormation
            // 
            this.barFormation.AccessibleName = "";
            this.barFormation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.barFormation.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.barFormation.ForeColor = System.Drawing.Color.White;
            this.barFormation.Location = new System.Drawing.Point(480, 10);
            this.barFormation.Margin = new System.Windows.Forms.Padding(4);
            this.barFormation.Name = "barFormation";
            this.barFormation.Size = new System.Drawing.Size(134, 50);
            this.barFormation.TabIndex = 3;
            this.barFormation.TitleText = "Formation";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.scMainPanel);
            this.Name = "MainForm";
            this.Text = "MonitoringUI";
            this.scMainPanel.Panel1.ResumeLayout(false);
            this.scMainPanel.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).EndInit();
            this.scMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barFormation;
        private MonitoringUI.Controlls.CtrlTitleBarLabel barAging;
        public MonitoringUI.Controlls.CtrlTitleBarLabel barMain;
    }
}

