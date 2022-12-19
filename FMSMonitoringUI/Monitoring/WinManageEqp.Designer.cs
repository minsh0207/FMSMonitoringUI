namespace FMSMonitoringUI.Monitoring
{
    partial class WinManageEqp
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlButtonSave1 = new MonitoringUI.Controlls.CButton.CtrlButtonSave();
            this.ctrlButtonExit1 = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridEqpInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridTrayInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ctrlTitleBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(883, 65);
            this.panel2.TabIndex = 1;
            // 
            // ctrlTitleBar
            // 
            this.ctrlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTitleBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar.Name = "ctrlTitleBar";
            this.ctrlTitleBar.Size = new System.Drawing.Size(881, 63);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "Manage EQP";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ctrlButtonSave1);
            this.panel3.Controls.Add(this.ctrlButtonExit1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 510);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 64);
            this.panel3.TabIndex = 2;
            // 
            // ctrlButtonSave1
            // 
            this.ctrlButtonSave1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonSave1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonSave1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonSave1.LabelText = "strSave";
            this.ctrlButtonSave1.Location = new System.Drawing.Point(303, 9);
            this.ctrlButtonSave1.Name = "ctrlButtonSave1";
            this.ctrlButtonSave1.Size = new System.Drawing.Size(127, 42);
            this.ctrlButtonSave1.TabIndex = 3;
            // 
            // ctrlButtonExit1
            // 
            this.ctrlButtonExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonExit1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonExit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonExit1.LabelText = "Exit";
            this.ctrlButtonExit1.Location = new System.Drawing.Point(452, 9);
            this.ctrlButtonExit1.Name = "ctrlButtonExit1";
            this.ctrlButtonExit1.Size = new System.Drawing.Size(127, 42);
            this.ctrlButtonExit1.TabIndex = 2;
            this.ctrlButtonExit1.Click += new System.EventHandler(this.ctrlButtonExit1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.gridEqpInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(883, 445);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 3;
            // 
            // gridEqpInfo
            // 
            this.gridEqpInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridEqpInfo.Location = new System.Drawing.Point(0, 44);
            this.gridEqpInfo.Name = "gridEqpInfo";
            this.gridEqpInfo.Size = new System.Drawing.Size(292, 399);
            this.gridEqpInfo.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.gridTrayInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.radioButton10);
            this.splitContainer2.Panel2.Controls.Add(this.radioButton9);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(585, 445);
            this.splitContainer2.SplitterDistance = 292;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridTrayInfo
            // 
            this.gridTrayInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridTrayInfo.Location = new System.Drawing.Point(0, 44);
            this.gridTrayInfo.Name = "gridTrayInfo";
            this.gridTrayInfo.Size = new System.Drawing.Size(290, 399);
            this.gridTrayInfo.TabIndex = 1;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.ForeColor = System.Drawing.Color.White;
            this.radioButton10.Location = new System.Drawing.Point(44, 88);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(104, 16);
            this.radioButton10.TabIndex = 20;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = " Clear Trouble";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.ForeColor = System.Drawing.Color.White;
            this.radioButton9.Location = new System.Drawing.Point(44, 64);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(123, 16);
            this.radioButton9.TabIndex = 19;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = " Clear Information";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Clear Command";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manual Command";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Eqp Info";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tray Info";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WinManageEqp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(883, 574);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinManageEqp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinManageEqp";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WinTrayInformation_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel3;
        private MonitoringUI.Controlls.CButton.CtrlButtonSave ctrlButtonSave1;
        private MonitoringUI.Controlls.CButton.CtrlButtonExit ctrlButtonExit1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridEqpInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}