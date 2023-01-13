namespace FMSMonitoringUI.Controlls
{
    partial class CtrlEqpLTAging
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
            this.lbRatio = new System.Windows.Forms.Label();
            this.lbInAging = new System.Windows.Forms.Label();
            this.lbTotalRack = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbTitle = new System.Windows.Forms.Label();
            this.ctrlButton1 = new MonitoringUI.Controlls.CButton.CtrlButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRatio
            // 
            this.lbRatio.AutoSize = true;
            this.lbRatio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRatio.ForeColor = System.Drawing.Color.White;
            this.lbRatio.Location = new System.Drawing.Point(78, 64);
            this.lbRatio.Name = "lbRatio";
            this.lbRatio.Size = new System.Drawing.Size(39, 15);
            this.lbRatio.TabIndex = 31;
            this.lbRatio.Text = "100%";
            // 
            // lbInAging
            // 
            this.lbInAging.AutoSize = true;
            this.lbInAging.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInAging.ForeColor = System.Drawing.Color.White;
            this.lbInAging.Location = new System.Drawing.Point(78, 47);
            this.lbInAging.Name = "lbInAging";
            this.lbInAging.Size = new System.Drawing.Size(28, 15);
            this.lbInAging.TabIndex = 30;
            this.lbInAging.Text = "100";
            // 
            // lbTotalRack
            // 
            this.lbTotalRack.AutoSize = true;
            this.lbTotalRack.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRack.ForeColor = System.Drawing.Color.White;
            this.lbTotalRack.Location = new System.Drawing.Point(78, 31);
            this.lbTotalRack.Name = "lbTotalRack";
            this.lbTotalRack.Size = new System.Drawing.Size(28, 15);
            this.lbTotalRack.TabIndex = 29;
            this.lbTotalRack.Text = "164";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Ratio :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "In Aging :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Total Rack :";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlButton1);
            this.splitContainer1.Size = new System.Drawing.Size(129, 27);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 55;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(45, 25);
            this.lbTitle.TabIndex = 42;
            this.lbTitle.Text = "LTA";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlButton1
            // 
            this.ctrlButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlButton1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButton1.LabelText = "Lead Time";
            this.ctrlButton1.LanguageID = "";
            this.ctrlButton1.Location = new System.Drawing.Point(0, 0);
            this.ctrlButton1.Name = "ctrlButton1";
            this.ctrlButton1.Size = new System.Drawing.Size(76, 25);
            this.ctrlButton1.TabIndex = 0;
            // 
            // CtrlEqpLTAging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbRatio);
            this.Controls.Add(this.lbInAging);
            this.Controls.Add(this.lbTotalRack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CtrlEqpLTAging";
            this.Size = new System.Drawing.Size(129, 81);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRatio;
        private System.Windows.Forms.Label lbInAging;
        private System.Windows.Forms.Label lbTotalRack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbTitle;
        private MonitoringUI.Controlls.CButton.CtrlButton ctrlButton1;
    }
}
