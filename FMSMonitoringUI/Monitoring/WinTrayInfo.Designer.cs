namespace FMSMonitoringUI.Monitoring
{
    partial class WinTrayInfo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCellInfo = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.gridTrayInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.gridProcessFlow = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlButtonExit1 = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.ctrlTitleBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.ctrlDateTimeDT2DT1 = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT2DT();
            this.btnSearch = new MonitoringUI.Controlls.CtrlTitleBarLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1500, 605);
            this.panel3.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCellInfo);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.gridTrayInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlDateTimeDT2DT1);
            this.splitContainer1.Panel2.Controls.Add(this.gridProcessFlow);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1498, 603);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tray Info";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Process Flow";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCellInfo
            // 
            this.btnCellInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnCellInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCellInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCellInfo.ForeColor = System.Drawing.Color.White;
            this.btnCellInfo.LanguageID = "";
            this.btnCellInfo.Location = new System.Drawing.Point(163, 6);
            this.btnCellInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCellInfo.Name = "btnCellInfo";
            this.btnCellInfo.Size = new System.Drawing.Size(156, 32);
            this.btnCellInfo.TabIndex = 3;
            this.btnCellInfo.TitleText = "Call Information";
            // 
            // gridTrayInfo
            // 
            this.gridTrayInfo.ColumnCount = -1;
            this.gridTrayInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridTrayInfo.Location = new System.Drawing.Point(0, 44);
            this.gridTrayInfo.Name = "gridTrayInfo";
            this.gridTrayInfo.RowCount = -1;
            this.gridTrayInfo.Size = new System.Drawing.Size(326, 557);
            this.gridTrayInfo.TabIndex = 0;
            // 
            // gridProcessFlow
            // 
            this.gridProcessFlow.ColumnCount = -1;
            this.gridProcessFlow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridProcessFlow.Location = new System.Drawing.Point(0, 44);
            this.gridProcessFlow.Name = "gridProcessFlow";
            this.gridProcessFlow.RowCount = -1;
            this.gridProcessFlow.Size = new System.Drawing.Size(1164, 557);
            this.gridProcessFlow.TabIndex = 1;
            // 
            // ctrlButtonExit1
            // 
            this.ctrlButtonExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonExit1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonExit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonExit1.LabelText = "Exit";
            this.ctrlButtonExit1.Location = new System.Drawing.Point(669, 9);
            this.ctrlButtonExit1.Name = "ctrlButtonExit1";
            this.ctrlButtonExit1.Size = new System.Drawing.Size(161, 45);
            this.ctrlButtonExit1.TabIndex = 0;
            this.ctrlButtonExit1.Click += new System.EventHandler(this.ctrlButtonExit1_Click);
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
            this.ctrlTitleBar.TitleText = "Tray Information";
            // 
            // ctrlDateTimeDT2DT1
            // 
            this.ctrlDateTimeDT2DT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlDateTimeDT2DT1.EndDate = new System.DateTime(2022, 12, 23, 9, 50, 45, 867);
            this.ctrlDateTimeDT2DT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlDateTimeDT2DT1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ctrlDateTimeDT2DT1.LanguageID = "";
            this.ctrlDateTimeDT2DT1.Location = new System.Drawing.Point(595, 11);
            this.ctrlDateTimeDT2DT1.Name = "ctrlDateTimeDT2DT1";
            this.ctrlDateTimeDT2DT1.Size = new System.Drawing.Size(407, 27);
            this.ctrlDateTimeDT2DT1.StartDate = new System.DateTime(2022, 12, 23, 9, 50, 45, 867);
            this.ctrlDateTimeDT2DT1.TabIndex = 2;
            this.ctrlDateTimeDT2DT1.TitleText = "Date Period";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.LanguageID = "";
            this.btnSearch.Location = new System.Drawing.Point(1022, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.TitleText = "Search";
            // 
            // WinTrayInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 736);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinTrayInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WinTrayInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar ctrlTitleBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridTrayInfo;
        private MonitoringUI.Controlls.CButton.CtrlButtonExit ctrlButtonExit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controlls.CtrlDataGridView gridProcessFlow;
        private MonitoringUI.Controlls.CtrlTitleBarLabel btnCellInfo;
        private MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT2DT ctrlDateTimeDT2DT1;
        private MonitoringUI.Controlls.CtrlTitleBarLabel btnSearch;
    }
}