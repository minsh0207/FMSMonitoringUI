namespace FMSMonitoringUI.Controlls
{
    partial class CtrlEqpDCIR
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.ctrlMainTrayLevel1 = new FormationMonCtrl.CtrlMainTrayLevel1();
            this.lbTitle = new System.Windows.Forms.Label();
            this.opStatus = new System.Windows.Forms.Label();
            this.eqpStatus = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.groupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox.Controls.Add(this.elementHost1);
            this.groupBox.Controls.Add(this.lbTitle);
            this.groupBox.Controls.Add(this.opStatus);
            this.groupBox.Controls.Add(this.eqpStatus);
            this.groupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.ForeColor = System.Drawing.Color.White;
            this.groupBox.Location = new System.Drawing.Point(4, -3);
            this.groupBox.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox.Size = new System.Drawing.Size(115, 108);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(5, 58);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(106, 43);
            this.elementHost1.TabIndex = 5;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.ctrlMainTrayLevel1;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(4, 11);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(31, 15);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "DCR";
            // 
            // opStatus
            // 
            this.opStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.opStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opStatus.ForeColor = System.Drawing.Color.Black;
            this.opStatus.Location = new System.Drawing.Point(35, 35);
            this.opStatus.Margin = new System.Windows.Forms.Padding(1);
            this.opStatus.Name = "opStatus";
            this.opStatus.Size = new System.Drawing.Size(75, 19);
            this.opStatus.TabIndex = 3;
            this.opStatus.Text = "Processing";
            this.opStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eqpStatus
            // 
            this.eqpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.eqpStatus.ForeColor = System.Drawing.Color.Black;
            this.eqpStatus.Location = new System.Drawing.Point(6, 35);
            this.eqpStatus.Margin = new System.Windows.Forms.Padding(1);
            this.eqpStatus.Name = "eqpStatus";
            this.eqpStatus.Size = new System.Drawing.Size(26, 19);
            this.eqpStatus.TabIndex = 2;
            this.eqpStatus.Text = "R";
            this.eqpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlEqpDCIR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.groupBox);
            this.Name = "CtrlEqpDCIR";
            this.Size = new System.Drawing.Size(124, 107);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label eqpStatus;
        private System.Windows.Forms.Label opStatus;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private FormationMonCtrl.CtrlMainTrayLevel1 ctrlMainTrayLevel1;
    }
}
