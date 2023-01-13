namespace FMSMonitoringUI.Controlls
{
    partial class CtrlEqpLeakCheck
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
            this.lbEqpMode = new System.Windows.Forms.Label();
            this.lbEqpType = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbEqpStatus = new System.Windows.Forms.Label();
            this.TrayInfoView = new FMSMonitoringUI.Controlls.CtrlTrayInfoView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEqpMode
            // 
            this.lbEqpMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbEqpMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEqpMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbEqpMode.ForeColor = System.Drawing.Color.Black;
            this.lbEqpMode.Location = new System.Drawing.Point(87, 0);
            this.lbEqpMode.Name = "lbEqpMode";
            this.lbEqpMode.Size = new System.Drawing.Size(35, 25);
            this.lbEqpMode.TabIndex = 2;
            this.lbEqpMode.Text = "R";
            this.lbEqpMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEqpMode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbEqpType_MouseDoubleClick);
            // 
            // lbEqpType
            // 
            this.lbEqpType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbEqpType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbEqpType.ForeColor = System.Drawing.Color.White;
            this.lbEqpType.Location = new System.Drawing.Point(0, 0);
            this.lbEqpType.Name = "lbEqpType";
            this.lbEqpType.Size = new System.Drawing.Size(87, 25);
            this.lbEqpType.TabIndex = 1;
            this.lbEqpType.Text = "  EQP";
            this.lbEqpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbEqpType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbEqpType_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbEqpStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lbEqpMode);
            this.splitContainer1.Panel1.Controls.Add(this.lbEqpType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TrayInfoView);
            this.splitContainer1.Size = new System.Drawing.Size(200, 80);
            this.splitContainer1.SplitterDistance = 27;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbEqpStatus
            // 
            this.lbEqpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbEqpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEqpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEqpStatus.ForeColor = System.Drawing.Color.Black;
            this.lbEqpStatus.Location = new System.Drawing.Point(122, 0);
            this.lbEqpStatus.Name = "lbEqpStatus";
            this.lbEqpStatus.Size = new System.Drawing.Size(76, 25);
            this.lbEqpStatus.TabIndex = 4;
            this.lbEqpStatus.Text = "Running";
            this.lbEqpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrayInfoView
            // 
            this.TrayInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayInfoView.Location = new System.Drawing.Point(0, 0);
            this.TrayInfoView.Name = "TrayInfoView";
            this.TrayInfoView.Size = new System.Drawing.Size(198, 47);
            this.TrayInfoView.TabIndex = 0;
            // 
            // CtrlEqpLeakCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlEqpLeakCheck";
            this.Size = new System.Drawing.Size(220, 88);
            this.Load += new System.EventHandler(this.CtrlEqpControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbEqpMode;
        private System.Windows.Forms.Label lbEqpType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CtrlTrayInfoView TrayInfoView;
        private System.Windows.Forms.Label lbEqpStatus;
    }
}
