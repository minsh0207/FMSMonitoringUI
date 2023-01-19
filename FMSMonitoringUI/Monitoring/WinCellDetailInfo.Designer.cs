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
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridRecipeInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel4 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.gridProcessData = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel5 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridCellInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel2 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.gridProcessName = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel3 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridCellIDLIst = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.ctrlLabel1 = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 721);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1496, 60);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.Location = new System.Drawing.Point(919, 62);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridRecipeInfo);
            this.splitContainer2.Panel1.Controls.Add(this.ctrlLabel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridProcessData);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlLabel5);
            this.splitContainer2.Size = new System.Drawing.Size(579, 659);
            this.splitContainer2.SplitterDistance = 296;
            this.splitContainer2.TabIndex = 4;
            // 
            // gridRecipeInfo
            // 
            this.gridRecipeInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridRecipeInfo.ColumnCount = -1;
            this.gridRecipeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRecipeInfo.Location = new System.Drawing.Point(0, 44);
            this.gridRecipeInfo.Name = "gridRecipeInfo";
            this.gridRecipeInfo.RowCount = -1;
            this.gridRecipeInfo.Size = new System.Drawing.Size(294, 613);
            this.gridRecipeInfo.TabIndex = 7;
            this.gridRecipeInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlLabel4
            // 
            this.ctrlLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLabel4.ForeColor = System.Drawing.Color.DarkGray;
            this.ctrlLabel4.LanguageID = "DEF_Recipe_Info";
            this.ctrlLabel4.Location = new System.Drawing.Point(0, 0);
            this.ctrlLabel4.Name = "ctrlLabel4";
            this.ctrlLabel4.Size = new System.Drawing.Size(294, 44);
            this.ctrlLabel4.TabIndex = 9;
            this.ctrlLabel4.Text = "Recipe Info";
            this.ctrlLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridProcessData
            // 
            this.gridProcessData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridProcessData.ColumnCount = -1;
            this.gridProcessData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProcessData.Location = new System.Drawing.Point(0, 44);
            this.gridProcessData.Name = "gridProcessData";
            this.gridProcessData.RowCount = -1;
            this.gridProcessData.Size = new System.Drawing.Size(277, 613);
            this.gridProcessData.TabIndex = 8;
            this.gridProcessData.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlLabel5
            // 
            this.ctrlLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLabel5.ForeColor = System.Drawing.Color.DarkGray;
            this.ctrlLabel5.LanguageID = "DEF_Process_Data";
            this.ctrlLabel5.Location = new System.Drawing.Point(0, 0);
            this.ctrlLabel5.Name = "ctrlLabel5";
            this.ctrlLabel5.Size = new System.Drawing.Size(277, 44);
            this.ctrlLabel5.TabIndex = 10;
            this.ctrlLabel5.Text = "Process Data";
            this.ctrlLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.titBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1496, 60);
            this.panel1.TabIndex = 0;
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_Cell_Information";
            this.titBar.Location = new System.Drawing.Point(0, 0);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(1494, 58);
            this.titBar.TabIndex = 0;
            this.titBar.TitleText = "Cell Information";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(284, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridCellInfo);
            this.splitContainer1.Panel1.Controls.Add(this.ctrlLabel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridProcessName);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlLabel3);
            this.splitContainer1.Size = new System.Drawing.Size(632, 663);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 7;
            // 
            // gridCellInfo
            // 
            this.gridCellInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridCellInfo.ColumnCount = -1;
            this.gridCellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCellInfo.Location = new System.Drawing.Point(0, 44);
            this.gridCellInfo.Name = "gridCellInfo";
            this.gridCellInfo.RowCount = -1;
            this.gridCellInfo.Size = new System.Drawing.Size(378, 617);
            this.gridCellInfo.TabIndex = 3;
            this.gridCellInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlLabel2
            // 
            this.ctrlLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLabel2.ForeColor = System.Drawing.Color.DarkGray;
            this.ctrlLabel2.LanguageID = "DEF_Cell_Info";
            this.ctrlLabel2.Location = new System.Drawing.Point(0, 0);
            this.ctrlLabel2.Name = "ctrlLabel2";
            this.ctrlLabel2.Size = new System.Drawing.Size(378, 44);
            this.ctrlLabel2.TabIndex = 7;
            this.ctrlLabel2.Text = "Cell Info";
            this.ctrlLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridProcessName
            // 
            this.gridProcessName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridProcessName.ColumnCount = -1;
            this.gridProcessName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProcessName.Location = new System.Drawing.Point(0, 44);
            this.gridProcessName.Name = "gridProcessName";
            this.gridProcessName.RowCount = -1;
            this.gridProcessName.Size = new System.Drawing.Size(246, 617);
            this.gridProcessName.TabIndex = 0;
            this.gridProcessName.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlLabel3
            // 
            this.ctrlLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLabel3.ForeColor = System.Drawing.Color.DarkGray;
            this.ctrlLabel3.LanguageID = "DEF_Process_Name";
            this.ctrlLabel3.Location = new System.Drawing.Point(0, 0);
            this.ctrlLabel3.Name = "ctrlLabel3";
            this.ctrlLabel3.Size = new System.Drawing.Size(246, 44);
            this.ctrlLabel3.TabIndex = 8;
            this.ctrlLabel3.Text = "Process Name";
            this.ctrlLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gridCellIDLIst);
            this.panel3.Controls.Add(this.ctrlLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(2, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 659);
            this.panel3.TabIndex = 8;
            // 
            // gridCellIDLIst
            // 
            this.gridCellIDLIst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridCellIDLIst.ColumnCount = -1;
            this.gridCellIDLIst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCellIDLIst.Location = new System.Drawing.Point(0, 44);
            this.gridCellIDLIst.Name = "gridCellIDLIst";
            this.gridCellIDLIst.RowCount = -1;
            this.gridCellIDLIst.Size = new System.Drawing.Size(279, 613);
            this.gridCellIDLIst.TabIndex = 5;
            this.gridCellIDLIst.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLabel1.ForeColor = System.Drawing.Color.DarkGray;
            this.ctrlLabel1.LanguageID = "DEF_Cell_ID_List";
            this.ctrlLabel1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(279, 44);
            this.ctrlLabel1.TabIndex = 6;
            this.ctrlLabel1.Text = "Cell ID List";
            this.ctrlLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.LanguageID = "DEF_Exit";
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(1494, 58);
            this.Exit.TabIndex = 0;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // WinCellDetailInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1500, 805);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinCellDetailInfo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinCellDetailInfo";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinCellDetailInfo_FormClosed);
            this.Load += new System.EventHandler(this.WinCellDetailInfo_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.splitContainer2, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controlls.CtrlDataGridView gridRecipeInfo;
        private Controlls.CtrlDataGridView gridProcessData;
        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar titBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controlls.CtrlDataGridView gridCellInfo;
        private Controlls.CtrlDataGridView gridProcessName;
        private System.Windows.Forms.Panel panel3;
        private Controlls.CtrlDataGridView gridCellIDLIst;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel1;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel2;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel4;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel3;
        private Controlls.WindowsForms.CtrlLabel ctrlLabel5;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
    }
}