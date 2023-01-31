namespace FMSMonitoringUI.Controlls
{
    partial class CtrlEqpHTAging
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnLeadTime = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.ctrlLabel3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
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
            this.lbRatio.Location = new System.Drawing.Point(87, 65);
            this.lbRatio.Name = "lbRatio";
            this.lbRatio.Size = new System.Drawing.Size(39, 15);
            this.lbRatio.TabIndex = 48;
            this.lbRatio.Text = "100%";
            // 
            // lbInAging
            // 
            this.lbInAging.AutoSize = true;
            this.lbInAging.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInAging.ForeColor = System.Drawing.Color.White;
            this.lbInAging.Location = new System.Drawing.Point(89, 48);
            this.lbInAging.Name = "lbInAging";
            this.lbInAging.Size = new System.Drawing.Size(28, 15);
            this.lbInAging.TabIndex = 47;
            this.lbInAging.Text = "100";
            // 
            // lbTotalRack
            // 
            this.lbTotalRack.AutoSize = true;
            this.lbTotalRack.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRack.ForeColor = System.Drawing.Color.White;
            this.lbTotalRack.Location = new System.Drawing.Point(90, 31);
            this.lbTotalRack.Name = "lbTotalRack";
            this.lbTotalRack.Size = new System.Drawing.Size(27, 15);
            this.lbTotalRack.TabIndex = 46;
            this.lbTotalRack.Text = "110";
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
            this.splitContainer1.Panel2.Controls.Add(this.btnLeadTime);
            this.splitContainer1.Size = new System.Drawing.Size(129, 27);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 54;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(43, 25);
            this.lbTitle.TabIndex = 42;
            this.lbTitle.Text = "HTA";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLeadTime
            // 
            this.btnLeadTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnLeadTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeadTime.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLeadTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnLeadTime.LabelText = "Lead Time";
            this.btnLeadTime.LanguageID = "DEF_Lead_Time";
            this.btnLeadTime.Location = new System.Drawing.Point(0, 0);
            this.btnLeadTime.Name = "btnLeadTime";
            this.btnLeadTime.Size = new System.Drawing.Size(78, 25);
            this.btnLeadTime.TabIndex = 0;
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.AutoSize = true;
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.ctrlLabel1.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel1.LanguageID = "DEF_Total_Rack";
            this.ctrlLabel1.Location = new System.Drawing.Point(19, 31);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(70, 15);
            this.ctrlLabel1.TabIndex = 55;
            this.ctrlLabel1.Text = "Total Rack :";
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.AutoSize = true;
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.ctrlLabel2.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel2.LanguageID = "DEF_In_Aging";
            this.ctrlLabel2.Location = new System.Drawing.Point(33, 48);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(56, 15);
            this.ctrlLabel2.TabIndex = 56;
            this.ctrlLabel2.Text = "In Aging :";
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.AutoSize = true;
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.ctrlLabel3.ForeColor = System.Drawing.Color.White;
            this.ctrlLabel3.LanguageID = "DEF_Ratio";
            this.ctrlLabel3.Location = new System.Drawing.Point(32, 65);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(42, 15);
            this.ctrlLabel3.TabIndex = 57;
            this.ctrlLabel3.Text = "Ratio :";
            // 
            // CtrlEqpHTAging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ctrlLabel3);
            this.Controls.Add(this.ctrlLabel2);
            this.Controls.Add(this.ctrlLabel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbRatio);
            this.Controls.Add(this.lbInAging);
            this.Controls.Add(this.lbTotalRack);
            this.Name = "CtrlEqpHTAging";
            this.Size = new System.Drawing.Size(129, 85);
            this.Load += new System.EventHandler(this.CtrlEqpHTAging_Load);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbTitle;
        private MonitoringUI.Controlls.CButton.CtrlButton btnLeadTime;
        private WindowsForms.CtrlLabel ctrlLabel1;
        private WindowsForms.CtrlLabel ctrlLabel2;
        private WindowsForms.CtrlLabel ctrlLabel3;
    }
}
