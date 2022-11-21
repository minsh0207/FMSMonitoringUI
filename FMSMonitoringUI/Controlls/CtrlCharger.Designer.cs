namespace FMSMonitoringUI.Controlls
{
    partial class CtrlCharger
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
            this.ractCHG = new System.Windows.Forms.GroupBox();
            this.opStatus = new System.Windows.Forms.Label();
            this.eqpStatus = new System.Windows.Forms.Label();
            this.formationCHG = new System.Windows.Forms.Integration.ElementHost();
            this.ctrlFormationBoxCHG = new FormationMonCtrl.CtrlFormationBoxCHG();
            this.ractCHG.SuspendLayout();
            this.SuspendLayout();
            // 
            // ractCHG
            // 
            this.ractCHG.Controls.Add(this.opStatus);
            this.ractCHG.Controls.Add(this.eqpStatus);
            this.ractCHG.Controls.Add(this.formationCHG);
            this.ractCHG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ractCHG.ForeColor = System.Drawing.Color.White;
            this.ractCHG.Location = new System.Drawing.Point(0, 0);
            this.ractCHG.Margin = new System.Windows.Forms.Padding(0);
            this.ractCHG.Name = "ractCHG";
            this.ractCHG.Padding = new System.Windows.Forms.Padding(0);
            this.ractCHG.Size = new System.Drawing.Size(454, 135);
            this.ractCHG.TabIndex = 0;
            this.ractCHG.TabStop = false;
            this.ractCHG.Text = "RackID";
            // 
            // opStatus
            // 
            this.opStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.opStatus.ForeColor = System.Drawing.Color.Black;
            this.opStatus.Location = new System.Drawing.Point(333, 23);
            this.opStatus.Margin = new System.Windows.Forms.Padding(1);
            this.opStatus.Name = "opStatus";
            this.opStatus.Size = new System.Drawing.Size(113, 22);
            this.opStatus.TabIndex = 3;
            this.opStatus.Text = "Charge";
            this.opStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eqpStatus
            // 
            this.eqpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.eqpStatus.ForeColor = System.Drawing.Color.Black;
            this.eqpStatus.Location = new System.Drawing.Point(289, 23);
            this.eqpStatus.Margin = new System.Windows.Forms.Padding(1);
            this.eqpStatus.Name = "eqpStatus";
            this.eqpStatus.Size = new System.Drawing.Size(41, 22);
            this.eqpStatus.TabIndex = 2;
            this.eqpStatus.Text = "R";
            this.eqpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formationCHG
            // 
            this.formationCHG.Location = new System.Drawing.Point(7, 49);
            this.formationCHG.Margin = new System.Windows.Forms.Padding(1);
            this.formationCHG.Name = "formationCHG";
            this.formationCHG.Size = new System.Drawing.Size(440, 78);
            this.formationCHG.TabIndex = 1;
            this.formationCHG.Text = "CHG";
            this.formationCHG.Child = this.ctrlFormationBoxCHG;
            // 
            // CtrlCharger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.ractCHG);
            this.Name = "CtrlCharger";
            this.Size = new System.Drawing.Size(455, 141);
            this.ractCHG.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ractCHG;
        private System.Windows.Forms.Integration.ElementHost formationCHG;
        private FormationMonCtrl.CtrlFormationBoxCHG ctrlFormationBoxCHG;
        private System.Windows.Forms.Label eqpStatus;
        private System.Windows.Forms.Label opStatus;
    }
}
