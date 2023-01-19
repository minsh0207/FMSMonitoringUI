namespace MonitoringUI.Popup
{
    partial class WinLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbLanguage = new MonitoringUI.Controlls.CComboBox.CtrlComboBox();
            this.btConfirm = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.btExit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.tbPassword = new FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox();
            this.tbLoginID = new FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel1.Controls.Add(this.cbLanguage);
            this.panel1.Controls.Add(this.btConfirm);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.tbLoginID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 349);
            this.panel1.TabIndex = 1;
            // 
            // cbLanguage
            // 
            this.cbLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.cbLanguage.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cbLanguage.LanguageID = "DEF_Language";
            this.cbLanguage.Location = new System.Drawing.Point(104, 110);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.SelectedIndex = -1;
            this.cbLanguage.SelectedItem = null;
            this.cbLanguage.SelectedKeyString = "";
            this.cbLanguage.Size = new System.Drawing.Size(260, 27);
            this.cbLanguage.TabIndex = 57;
            this.cbLanguage.TitleText = "Language";
            // 
            // btConfirm
            // 
            this.btConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btConfirm.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btConfirm.LabelText = "Confirm";
            this.btConfirm.LanguageID = "DEF_Confirm";
            this.btConfirm.Location = new System.Drawing.Point(108, 279);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(115, 45);
            this.btConfirm.TabIndex = 56;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btExit.LabelText = "Exit";
            this.btExit.LanguageID = "DEF_Exit";
            this.btExit.Location = new System.Drawing.Point(241, 279);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(115, 45);
            this.btExit.TabIndex = 55;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.LanguageID = "DEF_Password";
            this.tbPassword.Location = new System.Drawing.Point(104, 217);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(30, 38, 30, 38);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(260, 37);
            this.tbPassword.TabIndex = 54;
            this.tbPassword.TextData = "";
            this.tbPassword.TitleText = "Password";
            this.tbPassword.TitleWidth = 150F;
            // 
            // tbLoginID
            // 
            this.tbLoginID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.tbLoginID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLoginID.LanguageID = "DEF_Login_ID";
            this.tbLoginID.Location = new System.Drawing.Point(104, 172);
            this.tbLoginID.Margin = new System.Windows.Forms.Padding(30, 35, 30, 35);
            this.tbLoginID.Name = "tbLoginID";
            this.tbLoginID.PasswordChar = '\0';
            this.tbLoginID.Size = new System.Drawing.Size(260, 37);
            this.tbLoginID.TabIndex = 53;
            this.tbLoginID.TextData = "";
            this.tbLoginID.TitleText = "Login ID";
            this.tbLoginID.TitleWidth = 150F;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(324, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 49;
            this.label2.Text = "/ Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(143, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "FMS Monitoring";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(61, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 44);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 47;
            this.pictureBox3.TabStop = false;
            // 
            // WinLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(467, 375);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinLogin";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "WinLogin";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WinLogin_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox tbPassword;
        private FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox tbLoginID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Controlls.CButton.CtrlButton btConfirm;
        private Controlls.CButton.CtrlButton btExit;
        private Controlls.CComboBox.CtrlComboBox cbLanguage;
    }
}