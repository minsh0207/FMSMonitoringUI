namespace FMSMonitoringUI.Controlls
{
    partial class CtrlRackStatus
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
            this.lbEqpMode = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.lbPorcessStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbEqpMode
            // 
            this.lbEqpMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbEqpMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbEqpMode.LanguageID = "";
            this.lbEqpMode.Location = new System.Drawing.Point(0, 0);
            this.lbEqpMode.Name = "lbEqpMode";
            this.lbEqpMode.Size = new System.Drawing.Size(5, 20);
            this.lbEqpMode.TabIndex = 0;
            this.lbEqpMode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbRackStatus_Click);
            // 
            // lbPorcessStatus
            // 
            this.lbPorcessStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbPorcessStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbPorcessStatus.Location = new System.Drawing.Point(7, 0);
            this.lbPorcessStatus.Name = "lbPorcessStatus";
            this.lbPorcessStatus.Size = new System.Drawing.Size(30, 20);
            this.lbPorcessStatus.TabIndex = 1;
            this.lbPorcessStatus.Text = "R";
            this.lbPorcessStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPorcessStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbRackStatus_Click);
            // 
            // CtrlRackStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.lbPorcessStatus);
            this.Controls.Add(this.lbEqpMode);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CtrlRackStatus";
            this.Size = new System.Drawing.Size(37, 20);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbRackStatus_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsForms.CtrlLabel lbEqpMode;
        private System.Windows.Forms.Label lbPorcessStatus;
    }
}
