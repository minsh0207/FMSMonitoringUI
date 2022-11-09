namespace MonitoringUI.Monitoring
{
    partial class WinAgingInfo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctrlLine1 = new MonitoringUI.Controlls.CtrlLine();
            this.btnExit = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            //this.btnExcel = new MonitoringUI.Controlls.CButton.CtrlButtonExcel();
            this.btnSearch = new MonitoringUI.Controlls.CButton.CtrlButtonSearch();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.cboModel = new MonitoringUI.Controlls.CComboBox.CtrlComboModel();
            this.ctrlBarSearchCondition1 = new MonitoringUI.Controlls.CtrlBarSearchCondition();
            this.cboRoute = new MonitoringUI.Controlls.CComboBox.CtrlComboRouteID();
            this.cboProc = new MonitoringUI.Controlls.CComboBox.CtrlComboProcessName();
            this.cboLotID = new MonitoringUI.Controlls.CComboBox.CtrlComboLotID();
            this.cboLine = new MonitoringUI.Controlls.CComboBox.CtrlComboLineID();
            this.gridList = new MonitoringUI.Controlls.NormalDataGridView(this.components);
            this.txtTrayID = new MonitoringUI.Controlls.CComboBox.CtrlTextBoxRoot();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbRTAging = new System.Windows.Forms.CheckBox();
            this.cbHTAging = new System.Windows.Forms.CheckBox();
            this.dtpDate = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT2DT();
            this.lbDateRange = new System.Windows.Forms.Label();
            this.btModify = new MonitoringUI.Controlls.CButton.CtrlButtonModify();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbReserved = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLine1
            // 
            this.ctrlLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.ctrlLine1.Location = new System.Drawing.Point(0, 135);
            this.ctrlLine1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlLine1.Name = "ctrlLine1";
            this.ctrlLine1.Size = new System.Drawing.Size(1889, 5);
            this.ctrlLine1.TabIndex = 11;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btnExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnExit.LabelText = "Exit";
            this.btnExit.Location = new System.Drawing.Point(1429, 76);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 38);
            this.btnExit.TabIndex = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExcel
            // 
            //this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            //this.btnExcel.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //this.btnExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            //this.btnExcel.LabelText = "strExcel";
            //this.btnExcel.Location = new System.Drawing.Point(1323, 76);
            //this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            //this.btnExcel.Name = "btnExcel";
            //this.btnExcel.Size = new System.Drawing.Size(100, 38);
            //this.btnExcel.TabIndex = 9;
            //this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btnSearch.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnSearch.LabelText = "strSearch";
            this.btnSearch.Location = new System.Drawing.Point(1216, 76);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 38);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // titBar
            // 
            this.titBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.Location = new System.Drawing.Point(0, -3);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(1884, 50);
            this.titBar.TabIndex = 18;
            this.titBar.TitleText = "Aging Infomation";
            // 
            // cboModel
            // 
            this.cboModel.BackColor = System.Drawing.Color.LightGray;
            this.cboModel.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboModel.Location = new System.Drawing.Point(164, 55);
            this.cboModel.Margin = new System.Windows.Forms.Padding(4);
            this.cboModel.Name = "cboModel";
            this.cboModel.SelectedIndex = -1;
            this.cboModel.SelectedItem = null;
            this.cboModel.SelectedKeyString = "";
            this.cboModel.Size = new System.Drawing.Size(260, 27);
            this.cboModel.TabIndex = 20;
            this.cboModel.TitleText = "DEF_SPREAD_102";
            // 
            // ctrlBarSearchCondition1
            // 
            this.ctrlBarSearchCondition1.BackColor = System.Drawing.Color.LightGray;
            this.ctrlBarSearchCondition1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlBarSearchCondition1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlBarSearchCondition1.Location = new System.Drawing.Point(0, 55);
            this.ctrlBarSearchCondition1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlBarSearchCondition1.Name = "ctrlBarSearchCondition1";
            this.ctrlBarSearchCondition1.Size = new System.Drawing.Size(150, 70);
            this.ctrlBarSearchCondition1.TabIndex = 21;
            // 
            // cboRoute
            // 
            this.cboRoute.BackColor = System.Drawing.Color.LightGray;
            this.cboRoute.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboRoute.Location = new System.Drawing.Point(432, 54);
            this.cboRoute.Margin = new System.Windows.Forms.Padding(4);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.SelectedIndex = -1;
            this.cboRoute.SelectedItem = null;
            this.cboRoute.SelectedKeyString = "";
            this.cboRoute.Size = new System.Drawing.Size(260, 27);
            this.cboRoute.TabIndex = 22;
            this.cboRoute.TitleText = "DEF_CONTROL_093";
            // 
            // cboProc
            // 
            this.cboProc.BackColor = System.Drawing.Color.LightGray;
            this.cboProc.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboProc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboProc.Location = new System.Drawing.Point(707, 55);
            this.cboProc.Margin = new System.Windows.Forms.Padding(4);
            this.cboProc.Name = "cboProc";
            this.cboProc.SelectedIndex = -1;
            this.cboProc.SelectedItem = null;
            this.cboProc.SelectedKeyString = "";
            this.cboProc.Size = new System.Drawing.Size(260, 27);
            this.cboProc.TabIndex = 23;
            this.cboProc.TitleText = "DEF_CONTROL_095";
            // 
            // cboLotID
            // 
            this.cboLotID.BackColor = System.Drawing.Color.LightGray;
            this.cboLotID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboLotID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboLotID.Location = new System.Drawing.Point(164, 93);
            this.cboLotID.Margin = new System.Windows.Forms.Padding(4);
            this.cboLotID.Name = "cboLotID";
            this.cboLotID.SelectedIndex = -1;
            this.cboLotID.SelectedItem = null;
            this.cboLotID.SelectedKeyString = "";
            this.cboLotID.Size = new System.Drawing.Size(260, 27);
            this.cboLotID.TabIndex = 24;
            this.cboLotID.TitleText = "DEF_SPREAD_086";
            // 
            // cboLine
            // 
            this.cboLine.BackColor = System.Drawing.Color.LightGray;
            this.cboLine.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboLine.Location = new System.Drawing.Point(1055, 122);
            this.cboLine.Margin = new System.Windows.Forms.Padding(4);
            this.cboLine.Name = "cboLine";
            this.cboLine.SelectedItem = null;
            this.cboLine.SelectedKeyString = "";
            this.cboLine.Size = new System.Drawing.Size(260, 27);
            this.cboLine.TabIndex = 25;
            this.cboLine.TitleText = "DEF_SPREAD_005";
            this.cboLine.Visible = false;
            // 
            // gridList
            // 
            this.gridList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("돋움", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("돋움", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridList.HeaderColumnRowCount = 0;
            this.gridList.Location = new System.Drawing.Point(0, 147);
            this.gridList.Name = "gridList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("돋움", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridList.RowTemplate.Height = 23;
            this.gridList.Size = new System.Drawing.Size(1884, 568);
            this.gridList.TabIndex = 27;
            this.gridList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridList_CellMouseDoubleClick);
            // 
            // txtTrayID
            // 
            this.txtTrayID.BackColor = System.Drawing.Color.LightGray;
            this.txtTrayID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTrayID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtTrayID.Location = new System.Drawing.Point(707, 93);
            this.txtTrayID.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrayID.MaxLength = 32767;
            this.txtTrayID.Name = "txtTrayID";
            this.txtTrayID.PasswordChar = '\0';
            this.txtTrayID.Size = new System.Drawing.Size(260, 27);
            this.txtTrayID.TabIndex = 28;
            this.txtTrayID.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTrayID.TextData = "";
            this.txtTrayID.TitleText = "TrayID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbRTAging);
            this.groupBox1.Controls.Add(this.cbHTAging);
            this.groupBox1.Location = new System.Drawing.Point(432, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 39);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // cbRTAging
            // 
            this.cbRTAging.AutoSize = true;
            this.cbRTAging.Checked = true;
            this.cbRTAging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRTAging.Location = new System.Drawing.Point(159, 16);
            this.cbRTAging.Name = "cbRTAging";
            this.cbRTAging.Size = new System.Drawing.Size(78, 17);
            this.cbRTAging.TabIndex = 1;
            this.cbRTAging.Text = "常温老化";
            this.cbRTAging.UseVisualStyleBackColor = true;
            // 
            // cbHTAging
            // 
            this.cbHTAging.AutoSize = true;
            this.cbHTAging.Checked = true;
            this.cbHTAging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHTAging.Location = new System.Drawing.Point(34, 16);
            this.cbHTAging.Name = "cbHTAging";
            this.cbHTAging.Size = new System.Drawing.Size(78, 17);
            this.cbHTAging.TabIndex = 0;
            this.cbHTAging.Text = "高温老化";
            this.cbHTAging.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.BackColor = System.Drawing.Color.LightGray;
            this.dtpDate.EndDate = new System.DateTime(2019, 3, 12, 13, 46, 35, 847);
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.dtpDate.Location = new System.Drawing.Point(424, 123);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(413, 26);
            this.dtpDate.StartDate = new System.DateTime(2019, 3, 12, 13, 46, 35, 847);
            this.dtpDate.TabIndex = 32;
            this.dtpDate.Visible = false;
            // 
            // lbDateRange
            // 
            this.lbDateRange.AutoSize = true;
            this.lbDateRange.Location = new System.Drawing.Point(1119, 117);
            this.lbDateRange.Name = "lbDateRange";
            this.lbDateRange.Size = new System.Drawing.Size(40, 13);
            this.lbDateRange.TabIndex = 33;
            this.lbDateRange.Text = "label1";
            this.lbDateRange.Visible = false;
            // 
            // btModify
            // 
            this.btModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btModify.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btModify.LabelText = "strModify";
            this.btModify.Location = new System.Drawing.Point(27, 21);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(100, 38);
            this.btModify.TabIndex = 34;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btModify);
            this.groupBox2.Location = new System.Drawing.Point(1720, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 70);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbReserved);
            this.groupBox3.Location = new System.Drawing.Point(988, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 40);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            // 
            // cbReserved
            // 
            this.cbReserved.AutoSize = true;
            this.cbReserved.Location = new System.Drawing.Point(19, 13);
            this.cbReserved.Name = "cbReserved";
            this.cbReserved.Size = new System.Drawing.Size(170, 17);
            this.cbReserved.TabIndex = 0;
            this.cbReserved.Text = "RouteID 변경 예약 Tray만";
            this.cbReserved.UseVisualStyleBackColor = true;
            // 
            // WinAgingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 740);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbDateRange);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridList);
            this.Controls.Add(this.cboLotID);
            this.Controls.Add(this.cboProc);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.ctrlBarSearchCondition1);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.titBar);
            this.Controls.Add(this.ctrlLine1);
            this.Controls.Add(this.btnExit);
            //this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTrayID);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cboLine);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WinAgingInfo";
            this.Text = "WinAgingInfo";
            this.Load += new System.EventHandler(this.UserControl_Loaded);
            this.Controls.SetChildIndex(this.cboLine, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.txtTrayID, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            //this.Controls.SetChildIndex(this.btnExcel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.ctrlLine1, 0);
            this.Controls.SetChildIndex(this.titBar, 0);
            this.Controls.SetChildIndex(this.cboModel, 0);
            this.Controls.SetChildIndex(this.ctrlBarSearchCondition1, 0);
            this.Controls.SetChildIndex(this.cboRoute, 0);
            this.Controls.SetChildIndex(this.cboProc, 0);
            this.Controls.SetChildIndex(this.cboLotID, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbDateRange, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controlls.CButton.CtrlButtonSearch btnSearch;
        //private Controlls.CButton.CtrlButtonExcel btnExcel;
        private Controlls.CButton.CtrlButtonExit btnExit;
        private Controlls.CtrlLine ctrlLine1;
        private Controlls.CtrlTitleBar titBar;
        private Controlls.CComboBox.CtrlComboModel cboModel;
        private Controlls.CtrlBarSearchCondition ctrlBarSearchCondition1;
        private Controlls.CComboBox.CtrlComboRouteID cboRoute;
        private Controlls.CComboBox.CtrlComboProcessName cboProc;
        private Controlls.CComboBox.CtrlComboLotID cboLotID;
        private Controlls.CComboBox.CtrlComboLineID cboLine;
        private Controlls.NormalDataGridView gridList;
        private Controlls.CComboBox.CtrlTextBoxRoot txtTrayID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbRTAging;
        private System.Windows.Forms.CheckBox cbHTAging;
        private Controlls.CDateTime.CtrlDateTimeDT2DT dtpDate;
        private System.Windows.Forms.Label lbDateRange;
        private Controlls.CButton.CtrlButtonModify btModify;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbReserved;
    }
}