namespace FMSMonitoringUI.Monitoring
{
    partial class WinPackingInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbTrayPosition = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.gridTrayPosition = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.gridCellIDLIst = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.lbCellIDList = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridPalletInfo = new FMSMonitoringUI.Controlls.CtrlDataGridView();
            this.lbPalletInfo = new FMSMonitoringUI.Controlls.WindowsForms.CtrlLabel();
            this.panel2.SuspendLayout();
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
            this.panel2.Location = new System.Drawing.Point(2, 674);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 60);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.titBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 60);
            this.panel1.TabIndex = 0;
            // 
            // titBar
            // 
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.titBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.LanguageID = "DEF_Pallet_Information";
            this.titBar.Location = new System.Drawing.Point(0, 0);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(756, 58);
            this.titBar.TabIndex = 0;
            this.titBar.TitleText = "Pallet Information";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(306, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbTrayPosition);
            this.splitContainer1.Panel1.Controls.Add(this.gridTrayPosition);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridCellIDLIst);
            this.splitContainer1.Panel2.Controls.Add(this.lbCellIDList);
            this.splitContainer1.Size = new System.Drawing.Size(453, 611);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 7;
            // 
            // lbTrayPosition
            // 
            this.lbTrayPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbTrayPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTrayPosition.ForeColor = System.Drawing.Color.DarkGray;
            this.lbTrayPosition.LanguageID = "DEF_Tray_Position";
            this.lbTrayPosition.Location = new System.Drawing.Point(0, 0);
            this.lbTrayPosition.Name = "lbTrayPosition";
            this.lbTrayPosition.Size = new System.Drawing.Size(181, 34);
            this.lbTrayPosition.TabIndex = 9;
            this.lbTrayPosition.Text = "Tray Position";
            this.lbTrayPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridTrayPosition
            // 
            this.gridTrayPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridTrayPosition.ColumnCount = 1;
            this.gridTrayPosition.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gridTrayPosition.Location = new System.Drawing.Point(0, 34);
            this.gridTrayPosition.Name = "gridTrayPosition";
            this.gridTrayPosition.RowCount = 1;
            this.gridTrayPosition.Size = new System.Drawing.Size(182, 576);
            this.gridTrayPosition.TabIndex = 8;
            this.gridTrayPosition.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // gridCellIDLIst
            // 
            this.gridCellIDLIst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridCellIDLIst.ColumnCount = 1;
            this.gridCellIDLIst.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gridCellIDLIst.Location = new System.Drawing.Point(0, 34);
            this.gridCellIDLIst.Name = "gridCellIDLIst";
            this.gridCellIDLIst.RowCount = 1;
            this.gridCellIDLIst.Size = new System.Drawing.Size(265, 576);
            this.gridCellIDLIst.TabIndex = 9;
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
            this.lbCellIDList.Size = new System.Drawing.Size(265, 34);
            this.lbCellIDList.TabIndex = 8;
            this.lbCellIDList.Text = "Cell ID List";
            this.lbCellIDList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gridPalletInfo);
            this.panel3.Controls.Add(this.lbPalletInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(2, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 612);
            this.panel3.TabIndex = 8;
            // 
            // gridPalletInfo
            // 
            this.gridPalletInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.gridPalletInfo.ColumnCount = 1;
            this.gridPalletInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPalletInfo.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gridPalletInfo.Location = new System.Drawing.Point(0, 34);
            this.gridPalletInfo.Name = "gridPalletInfo";
            this.gridPalletInfo.RowCount = 1;
            this.gridPalletInfo.Size = new System.Drawing.Size(300, 576);
            this.gridPalletInfo.TabIndex = 7;
            this.gridPalletInfo.TagColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            // 
            // lbPalletInfo
            // 
            this.lbPalletInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lbPalletInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPalletInfo.ForeColor = System.Drawing.Color.DarkGray;
            this.lbPalletInfo.LanguageID = "DEF_Pallet_Info";
            this.lbPalletInfo.Location = new System.Drawing.Point(0, 0);
            this.lbPalletInfo.Name = "lbPalletInfo";
            this.lbPalletInfo.Size = new System.Drawing.Size(300, 34);
            this.lbPalletInfo.TabIndex = 6;
            this.lbPalletInfo.Text = "Pallet Info";
            this.lbPalletInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WinPackingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(762, 758);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinPackingInfo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinPackingInfo";
            this.TopMost = true;
            this.WindowID = "WinPackingInfo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinPackingInfo_FormClosed);
            this.Load += new System.EventHandler(this.WinPackingInfo_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private MonitoringUI.Controlls.CtrlTitleBar titBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private Controlls.WindowsForms.CtrlLabel lbPalletInfo;
        private Controlls.WindowsForms.CtrlLabel lbCellIDList;
        private MonitoringUI.Controlls.CButton.CtrlButton Exit;
        private Controlls.CtrlDataGridView gridTrayPosition;
        private Controlls.CtrlDataGridView gridCellIDLIst;
        private Controlls.CtrlDataGridView gridPalletInfo;
        private Controlls.WindowsForms.CtrlLabel lbTrayPosition;
    }
}