namespace MonitoringUI.Monitoring
{
    partial class WinAgingRackOutManage
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
            this.ctrlTitleBar1 = new MonitoringUI.Controlls.CtrlTitleBar();
            this.dtPlanTime = new MonitoringUI.Controlls.CDateTime.CtrlDateTimePlanTime();
            this.dtStartTime = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT();
            this.btOutNow = new System.Windows.Forms.Button();
            this.btConfirm = new MonitoringUI.Controlls.CButton.CtrlButtonConfirm();
            this.btExit = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.tbNextProcessName = new MonitoringUI.Controlls.TextBox.CtrlTextBoxNextProcess();
            this.tbCurrentProcessName = new MonitoringUI.Controlls.TextBox.CtrlTextBoxCurrProcess();
            this.tbTrayID = new MonitoringUI.Controlls.TextBox.CtrlTextBoxTrayID();
            this.tbRackID = new MonitoringUI.Controlls.TextBox.CtrlTextBoxRackID();
            this.SuspendLayout();
            // 
            // ctrlTitleBar1
            // 
            this.ctrlTitleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.ctrlTitleBar1.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar1.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar1.LanguageID = "";
            this.ctrlTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar1.Name = "ctrlTitleBar1";
            this.ctrlTitleBar1.Size = new System.Drawing.Size(592, 50);
            this.ctrlTitleBar1.TabIndex = 11;
            this.ctrlTitleBar1.TitleText = "출고시간 변경";
            // 
            // dtPlanTime
            // 
            this.dtPlanTime.BackColor = System.Drawing.Color.LightGray;
            this.dtPlanTime.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtPlanTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.dtPlanTime.Location = new System.Drawing.Point(278, 144);
            this.dtPlanTime.Name = "dtPlanTime";
            this.dtPlanTime.PlanTime = new System.DateTime(2019, 3, 18, 18, 13, 28, 458);
            this.dtPlanTime.Size = new System.Drawing.Size(251, 27);
            this.dtPlanTime.TabIndex = 17;
            // 
            // dtStartTime
            // 
            this.dtStartTime.BackColor = System.Drawing.Color.LightGray;
            this.dtStartTime.Enabled = false;
            this.dtStartTime.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.dtStartTime.LanguageID = "";
            this.dtStartTime.Location = new System.Drawing.Point(12, 144);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(251, 27);
            this.dtStartTime.StartTime = new System.DateTime(2019, 10, 30, 12, 29, 34, 592);
            this.dtStartTime.TabIndex = 23;
            this.dtStartTime.TitleText = "";
            this.dtStartTime.TitleWidth = 100F;
            // 
            // btOutNow
            // 
            this.btOutNow.Location = new System.Drawing.Point(390, 177);
            this.btOutNow.Name = "btOutNow";
            this.btOutNow.Size = new System.Drawing.Size(139, 23);
            this.btOutNow.TabIndex = 24;
            this.btOutNow.Text = "지금 출고";
            this.btOutNow.UseVisualStyleBackColor = true;
            this.btOutNow.Click += new System.EventHandler(this.btOutNow_Click);
            // 
            // btConfirm
            // 
            this.btConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btConfirm.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btConfirm.LabelText = "Confirm";
            this.btConfirm.Location = new System.Drawing.Point(164, 219);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(100, 38);
            this.btConfirm.TabIndex = 26;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btExit.LabelText = "ddd";
            this.btExit.Location = new System.Drawing.Point(285, 219);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(100, 38);
            this.btExit.TabIndex = 25;
            // 
            // tbNextProcessName
            // 
            this.tbNextProcessName.BackColor = System.Drawing.Color.LightGray;
            this.tbNextProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNextProcessName.Enabled = false;
            this.tbNextProcessName.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNextProcessName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbNextProcessName.Location = new System.Drawing.Point(278, 108);
            this.tbNextProcessName.MaxLength = 32767;
            this.tbNextProcessName.Name = "tbNextProcessName";
            this.tbNextProcessName.PasswordChar = '\0';
            this.tbNextProcessName.Size = new System.Drawing.Size(260, 27);
            this.tbNextProcessName.TabIndex = 29;
            this.tbNextProcessName.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbNextProcessName.TextBoxText = "";
            this.tbNextProcessName.TextData = "";
            this.tbNextProcessName.TitleText = "strNextProcessName";
            // 
            // tbCurrentProcessName
            // 
            this.tbCurrentProcessName.BackColor = System.Drawing.Color.LightGray;
            this.tbCurrentProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCurrentProcessName.Enabled = false;
            this.tbCurrentProcessName.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCurrentProcessName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbCurrentProcessName.Location = new System.Drawing.Point(12, 108);
            this.tbCurrentProcessName.MaxLength = 32767;
            this.tbCurrentProcessName.Name = "tbCurrentProcessName";
            this.tbCurrentProcessName.PasswordChar = '\0';
            this.tbCurrentProcessName.Size = new System.Drawing.Size(260, 27);
            this.tbCurrentProcessName.TabIndex = 28;
            this.tbCurrentProcessName.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbCurrentProcessName.TextBoxText = "";
            this.tbCurrentProcessName.TextData = "";
            this.tbCurrentProcessName.TitleText = "strCurrProcessName";
            // 
            // tbTrayID
            // 
            this.tbTrayID.BackColor = System.Drawing.Color.LightGray;
            this.tbTrayID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTrayID.Enabled = false;
            this.tbTrayID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTrayID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbTrayID.Location = new System.Drawing.Point(278, 75);
            this.tbTrayID.MaxLength = 32767;
            this.tbTrayID.Name = "tbTrayID";
            this.tbTrayID.PasswordChar = '\0';
            this.tbTrayID.Size = new System.Drawing.Size(260, 27);
            this.tbTrayID.TabIndex = 27;
            this.tbTrayID.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbTrayID.TextBoxText = "";
            this.tbTrayID.TextData = "";
            this.tbTrayID.TitleText = "strTrayID";
            // 
            // tbRackID
            // 
            this.tbRackID.BackColor = System.Drawing.Color.LightGray;
            this.tbRackID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRackID.Enabled = false;
            this.tbRackID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbRackID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbRackID.Location = new System.Drawing.Point(12, 75);
            this.tbRackID.MaxLength = 32767;
            this.tbRackID.Name = "tbRackID";
            this.tbRackID.PasswordChar = '\0';
            this.tbRackID.Size = new System.Drawing.Size(260, 27);
            this.tbRackID.TabIndex = 30;
            this.tbRackID.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbRackID.TextBoxText = "";
            this.tbRackID.TextData = "";
            this.tbRackID.TitleText = "strRackID";
            // 
            // WinAgingRackOutManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 306);
            this.Controls.Add(this.tbRackID);
            this.Controls.Add(this.tbNextProcessName);
            this.Controls.Add(this.tbCurrentProcessName);
            this.Controls.Add(this.tbTrayID);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btOutNow);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.dtPlanTime);
            this.Controls.Add(this.ctrlTitleBar1);
            this.Name = "WinAgingRackOutManage";
            this.Text = "WinAgingRackOutManage";
            this.Controls.SetChildIndex(this.ctrlTitleBar1, 0);
            this.Controls.SetChildIndex(this.dtPlanTime, 0);
            this.Controls.SetChildIndex(this.dtStartTime, 0);
            this.Controls.SetChildIndex(this.btOutNow, 0);
            this.Controls.SetChildIndex(this.btExit, 0);
            this.Controls.SetChildIndex(this.btConfirm, 0);
            this.Controls.SetChildIndex(this.tbTrayID, 0);
            this.Controls.SetChildIndex(this.tbCurrentProcessName, 0);
            this.Controls.SetChildIndex(this.tbNextProcessName, 0);
            this.Controls.SetChildIndex(this.tbRackID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controlls.CtrlTitleBar ctrlTitleBar1;
        private Controlls.CDateTime.CtrlDateTimePlanTime dtPlanTime;
        private Controlls.CDateTime.CtrlDateTimeDT dtStartTime;
        private System.Windows.Forms.Button btOutNow;
        private Controlls.CButton.CtrlButtonConfirm btConfirm;
        private Controlls.CButton.CtrlButtonExit btExit;
        private Controlls.TextBox.CtrlTextBoxNextProcess tbNextProcessName;
        private Controlls.TextBox.CtrlTextBoxCurrProcess tbCurrentProcessName;
        private Controlls.TextBox.CtrlTextBoxTrayID tbTrayID;
        private Controlls.TextBox.CtrlTextBoxRackID tbRackID;
    }
}