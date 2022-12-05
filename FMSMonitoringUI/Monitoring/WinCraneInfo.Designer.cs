namespace FMSMonitoringUI.Monitoring
{
    partial class WinCraneInfo
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
            this._TrayType = new FMSMonitoringUI.Controlls.CTextBox.CtrlTextBox();
            this.ctrlButtonExit1 = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this._TrayCount = new FMSMonitoringUI.Controlls.CTextBox.CtrlTextBox();
            this._TrayExist = new FMSMonitoringUI.Controlls.CTextBox.CtrlTextBox();
            this._TrayIdL2 = new FMSMonitoringUI.Controlls.CTextBox.CtrlTextBox();
            this._TrayIdL1 = new FMSMonitoringUI.Controlls.CTextBox.CtrlTextBox();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.SuspendLayout();
            // 
            // _TrayType
            // 
            this._TrayType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this._TrayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._TrayType.LanguageID = "";
            this._TrayType.Location = new System.Drawing.Point(6, 186);
            this._TrayType.Margin = new System.Windows.Forms.Padding(30);
            this._TrayType.Name = "_TrayType";
            this._TrayType.Size = new System.Drawing.Size(337, 37);
            this._TrayType.TabIndex = 11;
            this._TrayType.TextData = "";
            this._TrayType.TitleText = "Tray Type ";
            this._TrayType.TitleWidth = 180F;
            // 
            // ctrlButtonExit1
            // 
            this.ctrlButtonExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonExit1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonExit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonExit1.LabelText = "Exit";
            this.ctrlButtonExit1.Location = new System.Drawing.Point(167, 232);
            this.ctrlButtonExit1.Name = "ctrlButtonExit1";
            this.ctrlButtonExit1.Size = new System.Drawing.Size(164, 38);
            this.ctrlButtonExit1.TabIndex = 10;
            this.ctrlButtonExit1.Click += new System.EventHandler(this.ctrlButtonExit1_Click);
            // 
            // _TrayCount
            // 
            this._TrayCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this._TrayCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._TrayCount.LanguageID = "";
            this._TrayCount.Location = new System.Drawing.Point(6, 152);
            this._TrayCount.Margin = new System.Windows.Forms.Padding(30);
            this._TrayCount.Name = "_TrayCount";
            this._TrayCount.Size = new System.Drawing.Size(337, 37);
            this._TrayCount.TabIndex = 9;
            this._TrayCount.TextData = "";
            this._TrayCount.TitleText = "Tray Count ";
            this._TrayCount.TitleWidth = 180F;
            // 
            // _TrayExist
            // 
            this._TrayExist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this._TrayExist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._TrayExist.LanguageID = "";
            this._TrayExist.Location = new System.Drawing.Point(6, 122);
            this._TrayExist.Margin = new System.Windows.Forms.Padding(30);
            this._TrayExist.Name = "_TrayExist";
            this._TrayExist.Size = new System.Drawing.Size(337, 33);
            this._TrayExist.TabIndex = 7;
            this._TrayExist.TextData = "";
            this._TrayExist.TitleText = "Tray Exist ";
            this._TrayExist.TitleWidth = 180F;
            // 
            // _TrayIdL2
            // 
            this._TrayIdL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this._TrayIdL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._TrayIdL2.LanguageID = "";
            this._TrayIdL2.Location = new System.Drawing.Point(6, 92);
            this._TrayIdL2.Margin = new System.Windows.Forms.Padding(30);
            this._TrayIdL2.Name = "_TrayIdL2";
            this._TrayIdL2.Size = new System.Drawing.Size(337, 33);
            this._TrayIdL2.TabIndex = 3;
            this._TrayIdL2.TextData = "";
            this._TrayIdL2.TitleText = "Tray ID L2 ";
            this._TrayIdL2.TitleWidth = 180F;
            // 
            // _TrayIdL1
            // 
            this._TrayIdL1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this._TrayIdL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._TrayIdL1.LanguageID = "";
            this._TrayIdL1.Location = new System.Drawing.Point(6, 62);
            this._TrayIdL1.Margin = new System.Windows.Forms.Padding(30);
            this._TrayIdL1.Name = "_TrayIdL1";
            this._TrayIdL1.Size = new System.Drawing.Size(337, 33);
            this._TrayIdL1.TabIndex = 3;
            this._TrayIdL1.TextData = "";
            this._TrayIdL1.TitleText = "Tray ID L1 ";
            this._TrayIdL1.TitleWidth = 180F;
            // 
            // ctrlTitleBar
            // 
            this.ctrlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.ctrlTitleBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar.Location = new System.Drawing.Point(8, 7);
            this.ctrlTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar.Name = "ctrlTitleBar";
            this.ctrlTitleBar.Size = new System.Drawing.Size(334, 50);
            this.ctrlTitleBar.TabIndex = 1;
            this.ctrlTitleBar.TitleText = "Crane Infomation";
            // 
            // WinCraneInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(349, 281);
            this.Controls.Add(this._TrayType);
            this.Controls.Add(this.ctrlButtonExit1);
            this.Controls.Add(this._TrayCount);
            this.Controls.Add(this._TrayExist);
            this.Controls.Add(this._TrayIdL2);
            this.Controls.Add(this._TrayIdL1);
            this.Controls.Add(this.ctrlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinCraneInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinTrayInfo";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private Controlls.CTextBox.CtrlTextBox _TrayIdL1;
        private Controlls.CTextBox.CtrlTextBox _TrayIdL2;
        private Controlls.CTextBox.CtrlTextBox _TrayExist;
        private Controlls.CTextBox.CtrlTextBox _TrayCount;
        private MonitoringUI.Controlls.CButton.CtrlButtonExit ctrlButtonExit1;
        private Controlls.CTextBox.CtrlTextBox _TrayType;
    }
}