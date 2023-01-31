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
            this.Exit = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridRecipeInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.lbRecipeInfo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.gridProcessData = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.lbProcessData = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridCellInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.lbCellInfo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.gridProcessName = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.lbProcessName = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridCellIDLIst = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.lbCellIDList = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
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
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.Exit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.Exit.LabelText = "Exit";
            this.Exit.LanguageID = "DEF_Exit";
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(170, 40);
            this.Exit.TabIndex = 0;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.Location = new System.Drawing.Point(919, 62);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridRecipeInfo);
            this.splitContainer2.Panel1.Controls.Add(this.lbRecipeInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridProcessData);
            this.splitContainer2.Panel2.Controls.Add(this.lbProcessData);
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
            // lbRecipeInfo
            // 
            this.lbRecipeInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbRecipeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbRecipeInfo.ForeColor = System.Drawing.Color.DarkGray;
            this.lbRecipeInfo.LanguageID = "DEF_Recipe_Info";
            this.lbRecipeInfo.Location = new System.Drawing.Point(0, 0);
            this.lbRecipeInfo.Name = "lbRecipeInfo";
            this.lbRecipeInfo.Size = new System.Drawing.Size(294, 44);
            this.lbRecipeInfo.TabIndex = 9;
            this.lbRecipeInfo.Text = "Recipe Info";
            this.lbRecipeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lbProcessData
            // 
            this.lbProcessData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbProcessData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbProcessData.ForeColor = System.Drawing.Color.DarkGray;
            this.lbProcessData.LanguageID = "DEF_Process_Data";
            this.lbProcessData.Location = new System.Drawing.Point(0, 0);
            this.lbProcessData.Name = "lbProcessData";
            this.lbProcessData.Size = new System.Drawing.Size(277, 44);
            this.lbProcessData.TabIndex = 10;
            this.lbProcessData.Text = "Process Data";
            this.lbProcessData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.splitContainer1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(284, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridCellInfo);
            this.splitContainer1.Panel1.Controls.Add(this.lbCellInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridProcessName);
            this.splitContainer1.Panel2.Controls.Add(this.lbProcessName);
            this.splitContainer1.Size = new System.Drawing.Size(631, 663);
            this.splitContainer1.SplitterDistance = 379;
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
            this.gridCellInfo.Size = new System.Drawing.Size(377, 617);
            this.gridCellInfo.TabIndex = 3;
            this.gridCellInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // lbCellInfo
            // 
            this.lbCellInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbCellInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCellInfo.ForeColor = System.Drawing.Color.DarkGray;
            this.lbCellInfo.LanguageID = "DEF_Cell_Info";
            this.lbCellInfo.Location = new System.Drawing.Point(0, 0);
            this.lbCellInfo.Name = "lbCellInfo";
            this.lbCellInfo.Size = new System.Drawing.Size(377, 44);
            this.lbCellInfo.TabIndex = 7;
            this.lbCellInfo.Text = "Cell Info";
            this.lbCellInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lbProcessName
            // 
            this.lbProcessName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbProcessName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbProcessName.ForeColor = System.Drawing.Color.DarkGray;
            this.lbProcessName.LanguageID = "DEF_Process_Name";
            this.lbProcessName.Location = new System.Drawing.Point(0, 0);
            this.lbProcessName.Name = "lbProcessName";
            this.lbProcessName.Size = new System.Drawing.Size(246, 44);
            this.lbProcessName.TabIndex = 8;
            this.lbProcessName.Text = "Process Name";
            this.lbProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gridCellIDLIst);
            this.panel3.Controls.Add(this.lbCellIDList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(2, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 659);
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
            this.gridCellIDLIst.Size = new System.Drawing.Size(276, 613);
            this.gridCellIDLIst.TabIndex = 5;
            this.gridCellIDLIst.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // lbCellIDList
            // 
            this.lbCellIDList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbCellIDList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCellIDList.ForeColor = System.Drawing.Color.DarkGray;
            this.lbCellIDList.LanguageID = "DEF_Cell_ID_List";
            this.lbCellIDList.Location = new System.Drawing.Point(0, 0);
            this.lbCellIDList.Name = "lbCellIDList";
            this.lbCellIDList.Size = new System.Drawing.Size(276, 44);
            this.lbCellIDList.TabIndex = 6;
            this.lbCellIDList.Text = "Cell ID List";
            this.lbCellIDList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
        private Controlls.WindowsForms.CtrlLabel lbCellIDList;
        private Controlls.WindowsForms.CtrlLabel lbCellInfo;
        private Controlls.WindowsForms.CtrlLabel lbRecipeInfo;
        private Controlls.WindowsForms.CtrlLabel lbProcessName;
        private Controlls.WindowsForms.CtrlLabel lbProcessData;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
    }
}