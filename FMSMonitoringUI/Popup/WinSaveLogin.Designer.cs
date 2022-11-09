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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbPassword = new MonitoringUI.Controlls.CComboBox.CtrlTextBoxPassword();
            this.tbLginID = new MonitoringUI.Controlls.CComboBox.CtrlTextBoxUserID();
            this.btExit = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.btConfirm = new MonitoringUI.Controlls.CButton.CtrlButtonConfirm();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(80)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(292, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 38;
            this.label2.Text = "/ Save Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("돋움", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(80)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(105, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Formation System";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(22, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(52, 52);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPassword.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbPassword.Location = new System.Drawing.Point(82, 110);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(260, 27);
            this.tbPassword.TabIndex = 43;
            this.tbPassword.TextBoxText = "";
            this.tbPassword.TextData = "";
            this.tbPassword.TitleText = "Password";
            // 
            // tbLginID
            // 
            this.tbLginID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbLginID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLginID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbLginID.Location = new System.Drawing.Point(82, 76);
            this.tbLginID.Name = "tbLginID";
            this.tbLginID.PasswordChar = '\0';
            this.tbLginID.Size = new System.Drawing.Size(260, 27);
            this.tbLginID.TabIndex = 42;
            this.tbLginID.TextBoxText = "";
            this.tbLginID.TextData = "";
            this.tbLginID.TitleText = "Login ID";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btExit.LabelText = "strExit";
            this.btExit.Location = new System.Drawing.Point(219, 166);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(100, 38);
            this.btExit.TabIndex = 45;
            // 
            // btConfirm
            // 
            this.btConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btConfirm.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btConfirm.LabelText = "strConfirm";
            this.btConfirm.Location = new System.Drawing.Point(113, 166);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(100, 38);
            this.btConfirm.TabIndex = 44;
            // 
            // WinSaveLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(439, 249);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLginID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinSaveLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinSaveLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Window_Closed);
            this.Load += new System.EventHandler(this.Window_Loaded);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbLginID, 0);
            this.Controls.SetChildIndex(this.tbPassword, 0);
            this.Controls.SetChildIndex(this.btConfirm, 0);
            this.Controls.SetChildIndex(this.btExit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Controlls.CComboBox.CtrlTextBoxPassword tbPassword;
        private Controlls.CComboBox.CtrlTextBoxUserID tbLginID;
        private Controlls.CButton.CtrlButtonExit btExit;
        private Controlls.CButton.CtrlButtonConfirm btConfirm;
    }
}