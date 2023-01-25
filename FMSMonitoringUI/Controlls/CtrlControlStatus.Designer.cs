namespace FMSMonitoringUI.Controlls
{
    partial class CtrlControlStatus
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
            this.PLCServer4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.PLCServer3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.PLCServer2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.PLCServer1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.RestServer = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLED();
            this.SuspendLayout();
            // 
            // PLCServer4
            // 
            this.PLCServer4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.PLCServer4.Location = new System.Drawing.Point(-6, 95);
            this.PLCServer4.Name = "PLCServer4";
            this.PLCServer4.Size = new System.Drawing.Size(144, 14);
            this.PLCServer4.TabIndex = 118;
            this.PLCServer4.TitleText = "PLC Server #4";
            // 
            // PLCServer3
            // 
            this.PLCServer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.PLCServer3.Location = new System.Drawing.Point(-6, 72);
            this.PLCServer3.Name = "PLCServer3";
            this.PLCServer3.Size = new System.Drawing.Size(144, 14);
            this.PLCServer3.TabIndex = 117;
            this.PLCServer3.TitleText = "PLC Server #3";
            // 
            // PLCServer2
            // 
            this.PLCServer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.PLCServer2.Location = new System.Drawing.Point(-6, 49);
            this.PLCServer2.Name = "PLCServer2";
            this.PLCServer2.Size = new System.Drawing.Size(144, 14);
            this.PLCServer2.TabIndex = 116;
            this.PLCServer2.TitleText = "PLC Server #2";
            // 
            // PLCServer1
            // 
            this.PLCServer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.PLCServer1.Location = new System.Drawing.Point(-6, 26);
            this.PLCServer1.Name = "PLCServer1";
            this.PLCServer1.Size = new System.Drawing.Size(144, 14);
            this.PLCServer1.TabIndex = 115;
            this.PLCServer1.TitleText = "PLC Server #1";
            // 
            // RestServer
            // 
            this.RestServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.RestServer.Location = new System.Drawing.Point(-6, 3);
            this.RestServer.Name = "RestServer";
            this.RestServer.Size = new System.Drawing.Size(144, 14);
            this.RestServer.TabIndex = 114;
            this.RestServer.TitleText = "Rest Server";
            // 
            // ControlStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.PLCServer4);
            this.Controls.Add(this.PLCServer3);
            this.Controls.Add(this.PLCServer2);
            this.Controls.Add(this.PLCServer1);
            this.Controls.Add(this.RestServer);
            this.Name = "ControlStatus";
            this.Size = new System.Drawing.Size(150, 114);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsForms.CtrlLED PLCServer4;
        private WindowsForms.CtrlLED PLCServer3;
        private WindowsForms.CtrlLED PLCServer2;
        private WindowsForms.CtrlLED PLCServer1;
        private WindowsForms.CtrlLED RestServer;
    }
}
