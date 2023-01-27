namespace MonitoringUI.Popup
{
    partial class WinTroubleAlarm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panBack = new System.Windows.Forms.Panel();
            this.panText = new System.Windows.Forms.Panel();
            this.lblTroubleUnitName = new System.Windows.Forms.Label();
            this.lblTroubleName = new System.Windows.Forms.Label();
            this.panBack.SuspendLayout();
            this.panText.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBack
            // 
            this.panBack.BackColor = System.Drawing.Color.Black;
            this.panBack.Controls.Add(this.panText);
            this.panBack.Location = new System.Drawing.Point(37, 36);
            this.panBack.Name = "panBack";
            this.panBack.Size = new System.Drawing.Size(1611, 217);
            this.panBack.TabIndex = 4;
            this.panBack.Click += new System.EventHandler(this.lblTrouble_MouseDown);
            // 
            // panText
            // 
            this.panText.BackColor = System.Drawing.Color.Yellow;
            this.panText.Controls.Add(this.lblTroubleUnitName);
            this.panText.Controls.Add(this.lblTroubleName);
            this.panText.Location = new System.Drawing.Point(12, 13);
            this.panText.Name = "panText";
            this.panText.Size = new System.Drawing.Size(1582, 190);
            this.panText.TabIndex = 4;
            this.panText.Click += new System.EventHandler(this.lblTrouble_MouseDown);
            // 
            // lblTroubleUnitName
            // 
            this.lblTroubleUnitName.BackColor = System.Drawing.Color.Yellow;
            this.lblTroubleUnitName.Font = new System.Drawing.Font("굴림", 54.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTroubleUnitName.Location = new System.Drawing.Point(3, 117);
            this.lblTroubleUnitName.Name = "lblTroubleUnitName";
            this.lblTroubleUnitName.Size = new System.Drawing.Size(1579, 73);
            this.lblTroubleUnitName.TabIndex = 4;
            this.lblTroubleUnitName.Text = "Unit Name";
            this.lblTroubleUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTroubleUnitName.Click += new System.EventHandler(this.lblTrouble_MouseDown);
            // 
            // lblTroubleName
            // 
            this.lblTroubleName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTroubleName.BackColor = System.Drawing.Color.Yellow;
            this.lblTroubleName.Font = new System.Drawing.Font("굴림", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTroubleName.Location = new System.Drawing.Point(3, 2);
            this.lblTroubleName.Name = "lblTroubleName";
            this.lblTroubleName.Size = new System.Drawing.Size(1579, 96);
            this.lblTroubleName.TabIndex = 3;
            this.lblTroubleName.Text = "Warning FIRE!!";
            this.lblTroubleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTroubleName.Click += new System.EventHandler(this.lblTrouble_MouseDown);
            // 
            // WinTroubleAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1681, 288);
            this.Controls.Add(this.panBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinTroubleAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinTroubleAlarm";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.lblTrouble_MouseDown);
            this.panBack.ResumeLayout(false);
            this.panText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBack;
        private System.Windows.Forms.Panel panText;
        public System.Windows.Forms.Label lblTroubleName;
        public System.Windows.Forms.Label lblTroubleUnitName;
    }
}