namespace MonitoringUI.Controlls
{
    partial class CtrlTaggingNameLong
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
            this.lbTag = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTag
            // 
            this.lbTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbTag.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTag.ForeColor = System.Drawing.Color.White;
            this.lbTag.Location = new System.Drawing.Point(97, 5);
            this.lbTag.Name = "lbTag";
            this.lbTag.Size = new System.Drawing.Size(135, 20);
            this.lbTag.TabIndex = 1;
            this.lbTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbColor
            // 
            this.lbColor.BackColor = System.Drawing.Color.Red;
            this.lbColor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.lbColor.Location = new System.Drawing.Point(5, 5);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(88, 20);
            this.lbColor.TabIndex = 0;
            this.lbColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlTaggingNameLong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.lbTag);
            this.Controls.Add(this.lbColor);
            this.Name = "CtrlTaggingNameLong";
            this.Size = new System.Drawing.Size(232, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbTag;
    }
}
