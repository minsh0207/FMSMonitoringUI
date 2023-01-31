namespace FMSMonitoringUI.Controlls
{
    partial class CtrlRackTemp
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TrayInfoView = new FMSMonitoringUI.Controlls.CtrlTrayInfoView();
            this.lbLower = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.lbUpper = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TrayInfoView);
            this.splitContainer1.Size = new System.Drawing.Size(1437, 347);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbLower);
            this.splitContainer2.Panel1.ForeColor = System.Drawing.Color.White;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbUpper);
            this.splitContainer2.Size = new System.Drawing.Size(1437, 25);
            this.splitContainer2.SplitterDistance = 765;
            this.splitContainer2.TabIndex = 0;
            // 
            // TrayInfoView
            // 
            this.TrayInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayInfoView.Location = new System.Drawing.Point(0, 0);
            this.TrayInfoView.Name = "TrayInfoView";
            this.TrayInfoView.Size = new System.Drawing.Size(1435, 316);
            this.TrayInfoView.TabIndex = 0;
            // 
            // lbLower
            // 
            this.lbLower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLower.LanguageID = "DEF_LOWER";
            this.lbLower.Location = new System.Drawing.Point(0, 0);
            this.lbLower.Name = "lbLower";
            this.lbLower.Size = new System.Drawing.Size(763, 23);
            this.lbLower.TabIndex = 1;
            this.lbLower.Text = "LOWER";
            this.lbLower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbUpper
            // 
            this.lbUpper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUpper.ForeColor = System.Drawing.Color.White;
            this.lbUpper.LanguageID = "DEF_UPPER";
            this.lbUpper.Location = new System.Drawing.Point(0, 0);
            this.lbUpper.Name = "lbUpper";
            this.lbUpper.Size = new System.Drawing.Size(666, 23);
            this.lbUpper.TabIndex = 2;
            this.lbUpper.Text = "UPPER";
            this.lbUpper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlRackTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlRackTemp";
            this.Size = new System.Drawing.Size(1440, 375);
            this.Load += new System.EventHandler(this.CtrlRackTemp_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CtrlTrayInfoView TrayInfoView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private WindowsForms.CtrlLabel lbLower;
        private WindowsForms.CtrlLabel lbUpper;
    }
}
