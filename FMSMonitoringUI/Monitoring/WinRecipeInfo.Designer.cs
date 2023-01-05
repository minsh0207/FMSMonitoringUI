namespace FMSMonitoringUI.Monitoring
{
    partial class WinRecipeInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlButton1 = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridRecipeInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ctrlTitleBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 66);
            this.panel1.TabIndex = 0;
            // 
            // ctrlTitleBar
            // 
            this.ctrlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTitleBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar.LanguageID = "DEF_Recipe_Information";
            this.ctrlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar.Name = "ctrlTitleBar";
            this.ctrlTitleBar.Size = new System.Drawing.Size(392, 64);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "Recipe Information";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ctrlButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 671);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 65);
            this.panel2.TabIndex = 1;
            // 
            // ctrlButton1
            // 
            this.ctrlButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlButton1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButton1.LabelText = "Exit";
            this.ctrlButton1.LanguageID = "DEF_Exit";
            this.ctrlButton1.Location = new System.Drawing.Point(118, 13);
            this.ctrlButton1.Name = "ctrlButton1";
            this.ctrlButton1.Size = new System.Drawing.Size(156, 39);
            this.ctrlButton1.TabIndex = 0;
            this.ctrlButton1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ctrlLabel1);
            this.panel3.Controls.Add(this.gridRecipeInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 605);
            this.panel3.TabIndex = 2;
            // 
            // gridRecipeInfo
            // 
            this.gridRecipeInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridRecipeInfo.ColumnCount = -1;
            this.gridRecipeInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridRecipeInfo.Location = new System.Drawing.Point(0, 44);
            this.gridRecipeInfo.Name = "gridRecipeInfo";
            this.gridRecipeInfo.RowCount = -1;
            this.gridRecipeInfo.Size = new System.Drawing.Size(392, 559);
            this.gridRecipeInfo.TabIndex = 1;
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.ForeColor = System.Drawing.Color.DarkGray;
            this.ctrlLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ctrlLabel1.LanguageID = "DEF_Parameter";
            this.ctrlLabel1.Location = new System.Drawing.Point(6, 9);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(100, 23);
            this.ctrlLabel1.TabIndex = 2;
            this.ctrlLabel1.Text = "Parameter";
            this.ctrlLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WinRecipeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 736);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinRecipeInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WinRecipeInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Controlls.CtrlDataGridView gridRecipeInfo;
        private MonitoringUI.Controlls.CButton.CtrlButton ctrlButton1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
    }
}