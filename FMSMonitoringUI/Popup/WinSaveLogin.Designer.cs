namespace MonitoringUI.Popup
{
    partial class WinSaveLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinSaveLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btConfirm = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.btExit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.tbPassword = new FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox();
            this.tbLoginID = new FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.btConfirm);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.tbLoginID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 286);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(43, 27);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 54);
            this.pictureBox3.TabIndex = 68;
            this.pictureBox3.TabStop = false;
            // 
            // btConfirm
            // 
            this.btConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btConfirm.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btConfirm.LabelText = "Confirm";
            this.btConfirm.LanguageID = "DEF_Confirm";
            this.btConfirm.Location = new System.Drawing.Point(123, 217);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(115, 45);
            this.btConfirm.TabIndex = 67;
            this.btConfirm.Load += new System.EventHandler(this.btConfirm_Load);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btExit.LabelText = "Exit";
            this.btExit.LanguageID = "DEF_Exit";
            this.btExit.Location = new System.Drawing.Point(256, 217);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(115, 45);
            this.btExit.TabIndex = 66;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.LanguageID = "DEF_Password";
            this.tbPassword.Location = new System.Drawing.Point(119, 155);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(30, 44, 30, 44);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(260, 34);
            this.tbPassword.TabIndex = 65;
            this.tbPassword.TextData = "";
            this.tbPassword.TitleText = "Password";
            this.tbPassword.TitleWidth = 140F;
            // 
            // tbLoginID
            // 
            this.tbLoginID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.tbLoginID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLoginID.LanguageID = "DEF_Login_ID";
            this.tbLoginID.Location = new System.Drawing.Point(119, 109);
            this.tbLoginID.Margin = new System.Windows.Forms.Padding(30, 41, 30, 41);
            this.tbLoginID.Name = "tbLoginID";
            this.tbLoginID.PasswordChar = '\0';
            this.tbLoginID.Size = new System.Drawing.Size(260, 34);
            this.tbLoginID.TabIndex = 64;
            this.tbLoginID.TextData = "";
            this.tbLoginID.TitleText = "Login ID";
            this.tbLoginID.TitleWidth = 140F;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(312, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 63;
            this.label2.Text = "/ Save Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(125, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 62;
            this.label1.Text = "Formation System";
            // 
            // WinSaveLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(477, 312);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinSaveLogin";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinSaveLogin";
            this.WindowID = "WinSaveLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Window_Closed);
            this.Load += new System.EventHandler(this.Window_Loaded);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controlls.CButton.CtrlButton btConfirm;
        private Controlls.CButton.CtrlButton btExit;
         private FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox tbPassword;
        private FMSMonitoringUI.Controlls.WindowsForms.CtrlTextBox tbLoginID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}