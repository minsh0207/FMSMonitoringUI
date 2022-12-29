namespace FMSMonitoringUI.Controlls.WindowsForms
{
    partial class CtrlLED
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlLED));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ledLamp = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledLamp)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ledLamp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbTitle);
            this.splitContainer1.Size = new System.Drawing.Size(144, 18);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            // 
            // ledLamp
            // 
            this.ledLamp.Dock = System.Windows.Forms.DockStyle.Right;
            this.ledLamp.Image = ((System.Drawing.Image)(resources.GetObject("ledLamp.Image")));
            this.ledLamp.Location = new System.Drawing.Point(9, 0);
            this.ledLamp.Name = "ledLamp";
            this.ledLamp.Size = new System.Drawing.Size(16, 18);
            this.ledLamp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ledLamp.TabIndex = 1;
            this.ledLamp.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(115, 18);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "On";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlLED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlLED";
            this.Size = new System.Drawing.Size(144, 18);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ledLamp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox ledLamp;
        private System.Windows.Forms.Label lbTitle;
    }
}
