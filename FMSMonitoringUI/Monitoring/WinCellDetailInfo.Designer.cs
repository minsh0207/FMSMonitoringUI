namespace FMSMonitoringUI.Monitoring
{
    partial class WinCellDetailInfo
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
            this.ctrlButtonExit1 = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.gridCellInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.gridProcessName = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridRecipeInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.gridProcessData = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ctrlTitleBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 66);
            this.panel1.TabIndex = 0;
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
            this.ctrlTitleBar.Size = new System.Drawing.Size(1498, 64);
            this.ctrlTitleBar.TabIndex = 0;
            this.ctrlTitleBar.TitleText = "Cell Details";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ctrlButtonExit1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 671);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1500, 65);
            this.panel2.TabIndex = 1;
            // 
            // ctrlButtonExit1
            // 
            this.ctrlButtonExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonExit1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonExit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonExit1.LabelText = "Exit";
            this.ctrlButtonExit1.Location = new System.Drawing.Point(670, 9);
            this.ctrlButtonExit1.Name = "ctrlButtonExit1";
            this.ctrlButtonExit1.Size = new System.Drawing.Size(161, 45);
            this.ctrlButtonExit1.TabIndex = 0;
            this.ctrlButtonExit1.Click += new System.EventHandler(this.ctrlButtonExit1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.gridCellInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.gridProcessName);
            this.splitContainer1.Size = new System.Drawing.Size(718, 605);
            this.splitContainer1.SplitterDistance = 422;
            this.splitContainer1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tray Info";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridCellInfo
            // 
            this.gridCellInfo.ColumnCount = -1;
            this.gridCellInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridCellInfo.Location = new System.Drawing.Point(0, 44);
            this.gridCellInfo.Name = "gridCellInfo";
            this.gridCellInfo.RowCount = -1;
            this.gridCellInfo.Size = new System.Drawing.Size(420, 559);
            this.gridCellInfo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Process Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridProcessName
            // 
            this.gridProcessName.ColumnCount = -1;
            this.gridProcessName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridProcessName.Location = new System.Drawing.Point(0, 44);
            this.gridProcessName.Name = "gridProcessName";
            this.gridProcessName.RowCount = -1;
            this.gridProcessName.Size = new System.Drawing.Size(290, 559);
            this.gridProcessName.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(718, 66);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridRecipeInfo);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridProcessData);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Size = new System.Drawing.Size(782, 605);
            this.splitContainer2.SplitterDistance = 389;
            this.splitContainer2.TabIndex = 4;
            // 
            // gridRecipeInfo
            // 
            this.gridRecipeInfo.ColumnCount = -1;
            this.gridRecipeInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridRecipeInfo.Location = new System.Drawing.Point(0, 44);
            this.gridRecipeInfo.Name = "gridRecipeInfo";
            this.gridRecipeInfo.RowCount = -1;
            this.gridRecipeInfo.Size = new System.Drawing.Size(387, 559);
            this.gridRecipeInfo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Recipe Info";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridProcessData
            // 
            this.gridProcessData.ColumnCount = -1;
            this.gridProcessData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridProcessData.Location = new System.Drawing.Point(0, 44);
            this.gridProcessData.Name = "gridProcessData";
            this.gridProcessData.RowCount = -1;
            this.gridProcessData.Size = new System.Drawing.Size(387, 559);
            this.gridProcessData.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Process Data";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WinCellDetailInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 736);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinCellDetailInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WinCellDetailInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel2;
        private MonitoringUI.Controlls.CButton.CtrlButtonExit ctrlButtonExit1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridCellInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controlls.CtrlDataGridView gridRecipeInfo;
        private Controlls.CtrlDataGridView gridProcessData;
    }
}