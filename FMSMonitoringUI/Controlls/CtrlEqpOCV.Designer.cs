namespace FMSMonitoringUI.Controlls
{
    partial class CtrlEqpOCV
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
            this.lbOPStatus = new System.Windows.Forms.Label();
            this.lbEqpStatus = new System.Windows.Forms.Label();
            this.lbEqpType = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TrayInfoView = new FMSMonitoringUI.Controlls.CtrlTrayInfoView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbOPStatus
            // 
            this.lbOPStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbOPStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOPStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOPStatus.ForeColor = System.Drawing.Color.Black;
            this.lbOPStatus.Location = new System.Drawing.Point(35, 25);
            this.lbOPStatus.Name = "lbOPStatus";
            this.lbOPStatus.Size = new System.Drawing.Size(62, 25);
            this.lbOPStatus.TabIndex = 3;
            this.lbOPStatus.Text = "Running";
            this.lbOPStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbOPStatus.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbEqpType_MouseDoubleClick);
            // 
            // lbEqpStatus
            // 
            this.lbEqpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbEqpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEqpStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbEqpStatus.ForeColor = System.Drawing.Color.Black;
            this.lbEqpStatus.Location = new System.Drawing.Point(0, 25);
            this.lbEqpStatus.Name = "lbEqpStatus";
            this.lbEqpStatus.Size = new System.Drawing.Size(35, 25);
            this.lbEqpStatus.TabIndex = 2;
            this.lbEqpStatus.Text = "R";
            this.lbEqpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEqpStatus.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbEqpType_MouseDoubleClick);
            // 
            // lbEqpType
            // 
            this.lbEqpType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbEqpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbEqpType.ForeColor = System.Drawing.Color.White;
            this.lbEqpType.Location = new System.Drawing.Point(0, 0);
            this.lbEqpType.Name = "lbEqpType";
            this.lbEqpType.Size = new System.Drawing.Size(97, 25);
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
            this.splitContainer1.Panel1.Controls.Add(this.lbOPStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lbEqpStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lbEqpType);
            this.splitContainer1.Panel1MinSize = 20;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TrayInfoView);
            this.splitContainer1.Size = new System.Drawing.Size(99, 112);
            this.splitContainer1.SplitterDistance = 52;
            this.splitContainer1.TabIndex = 1;
            // 
            // TrayInfoView
            // 
            this.TrayInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrayInfoView.Location = new System.Drawing.Point(0, 0);
            this.TrayInfoView.Name = "TrayInfoView";
            this.TrayInfoView.Size = new System.Drawing.Size(97, 54);
            this.TrayInfoView.TabIndex = 0;
            // 
            // CtrlEqpOCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlEqpOCV";
            this.Size = new System.Drawing.Size(121, 128);
            this.Load += new System.EventHandler(this.CtrlEqpControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbOPStatus;
        private System.Windows.Forms.Label lbEqpStatus;
        private System.Windows.Forms.Label lbEqpType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CtrlTrayInfoView TrayInfoView;
    }
}
