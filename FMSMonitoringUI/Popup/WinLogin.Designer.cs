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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbLine1 = new System.Windows.Forms.RadioButton();
            this.rbLine2 = new System.Windows.Forms.RadioButton();
            this.tbLoginID = new MonitoringUI.Controlls.CComboBox.CtrlTextBoxUserID();
            this.cbLanguage = new MonitoringUI.Controlls.CComboBox.CtrlComboLanguage();
            this.tbPassword = new MonitoringUI.Controlls.CComboBox.CtrlTextBoxPassword();
            this.btConfirm = new MonitoringUI.Controlls.CButton.CtrlButtonConfirm();
            this.btExit = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(29, 27);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(52, 52);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 33;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(80)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(112, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 34;
            this.label1.Text = "Formation System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(80)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(299, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "/ Login";
            // 
            // rbLine1
            // 
            this.rbLine1.AutoSize = true;
            this.rbLine1.Checked = true;
            this.rbLine1.Location = new System.Drawing.Point(149, 82);
            this.rbLine1.Name = "rbLine1";
            this.rbLine1.Size = new System.Drawing.Size(78, 17);
            this.rbLine1.TabIndex = 37;
            this.rbLine1.TabStop = true;
            this.rbLine1.Text = "化成 1 区";
            this.rbLine1.UseVisualStyleBackColor = true;
            // 
            // rbLine2
            // 
            this.rbLine2.AutoSize = true;
            this.rbLine2.Location = new System.Drawing.Point(245, 82);
            this.rbLine2.Name = "rbLine2";
            this.rbLine2.Size = new System.Drawing.Size(78, 17);
            this.rbLine2.TabIndex = 38;
            this.rbLine2.Text = "化成 2 区";
            this.rbLine2.UseVisualStyleBackColor = true;
            // 
            // tbLoginID
            // 
            this.tbLoginID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLoginID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLoginID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbLoginID.Location = new System.Drawing.Point(76, 168);
            this.tbLoginID.MaxLength = 32767;
            this.tbLoginID.Name = "tbLoginID";
            this.tbLoginID.PasswordChar = '\0';
            this.tbLoginID.Size = new System.Drawing.Size(260, 27);
            this.tbLoginID.TabIndex = 40;
            this.tbLoginID.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbLoginID.TextBoxText = "";
            this.tbLoginID.TextData = "";
            this.tbLoginID.TitleText = "Login ID";
            // 
            // cbLanguage
            // 
            this.cbLanguage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbLanguage.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cbLanguage.Location = new System.Drawing.Point(76, 131);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.SelectedIndex = 0;
            this.cbLanguage.SelectedItem = "CHINESE";
            this.cbLanguage.SelectedKeyString = "CHINESE";
            this.cbLanguage.Size = new System.Drawing.Size(260, 27);
            this.cbLanguage.TabIndex = 39;
            this.cbLanguage.TitleText = "Language";
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPassword.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbPassword.Location = new System.Drawing.Point(76, 202);
            this.tbPassword.MaxLength = 32767;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(260, 27);
            this.tbPassword.TabIndex = 41;
            this.tbPassword.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbPassword.TextBoxText = "";
            this.tbPassword.TextData = "";
            this.tbPassword.TitleText = "Password";
            // 
            // btConfirm
            // 
            this.btConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btConfirm.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btConfirm.LabelText = "Confirm";
            this.btConfirm.Location = new System.Drawing.Point(126, 266);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(100, 38);
            this.btConfirm.TabIndex = 42;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btExit.LabelText = "Exit";
            this.btExit.Location = new System.Drawing.Point(232, 266);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(100, 38);
            this.btExit.TabIndex = 43;
            // 
            // WinLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(441, 342);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.tbLoginID);
            this.Controls.Add(this.rbLine2);
            this.Controls.Add(this.rbLine1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Name = "WinLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Popup001";
            this.Text = "WinLogin";
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rbLine1, 0);
            this.Controls.SetChildIndex(this.rbLine2, 0);
            this.Controls.SetChildIndex(this.tbLoginID, 0);
            this.Controls.SetChildIndex(this.cbLanguage, 0);
            this.Controls.SetChildIndex(this.tbPassword, 0);
            this.Controls.SetChildIndex(this.btConfirm, 0);
            this.Controls.SetChildIndex(this.btExit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbLine1;
        private System.Windows.Forms.RadioButton rbLine2;
        private Controlls.CComboBox.CtrlTextBoxUserID tbLoginID;
        private Controlls.CComboBox.CtrlComboLanguage cbLanguage;
        private Controlls.CComboBox.CtrlTextBoxPassword tbPassword;
        private Controlls.CButton.CtrlButtonConfirm btConfirm;
        private Controlls.CButton.CtrlButtonExit btExit;
    }
}