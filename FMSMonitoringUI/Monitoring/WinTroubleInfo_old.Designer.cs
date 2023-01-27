namespace MonitoringUI.Monitoring
{
    partial class WinTroubleInfo_old
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
            this.ctrlButtonExit = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            //this.btnSaveExcel = new MonitoringUI.Controlls.CButton.CtrlButtonExcel();
            this.ctrlButtonSearch1 = new MonitoringUI.Controlls.CButton.CtrlButtonSearch();
            this.titBar = new MonitoringUI.Controlls.CtrlTitleBar();
            this.ctrlDateTimeDT2DT1 = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT2DT();
            this.ctrlBarSearchCondition1 = new MonitoringUI.Controlls.CtrlBarSearchCondition();
            this.ctrlTextBoxEqpName1 = new MonitoringUI.Controlls.TextBox.CtrlTextBoxEqpName();
            this.gridView = new MonitoringUI.Controlls.NormalDataGridView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlLine1
            // 
            this.ctrlLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.ctrlLine1.Location = new System.Drawing.Point(-3, 115);
            this.ctrlLine1.Name = "ctrlLine1";
            this.ctrlLine1.Size = new System.Drawing.Size(1300, 5);
            this.ctrlLine1.TabIndex = 5;
            // 
            // ctrlButtonExit
            // 
            this.ctrlButtonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonExit.LabelText = "Exit";
            this.ctrlButtonExit.Location = new System.Drawing.Point(1111, 60);
            this.ctrlButtonExit.Name = "ctrlButtonExit";
            this.ctrlButtonExit.Size = new System.Drawing.Size(100, 38);
            this.ctrlButtonExit.TabIndex = 4;
            this.ctrlButtonExit.Click += new System.EventHandler(this.ctrlButtonExit_Click);
            // 
            // btnSaveExcel
            // 
            //this.btnSaveExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            //this.btnSaveExcel.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //this.btnSaveExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            //this.btnSaveExcel.LabelText = "strExcel";
            //this.btnSaveExcel.Location = new System.Drawing.Point(1004, 61);
            //this.btnSaveExcel.Name = "btnSaveExcel";
            //this.btnSaveExcel.Size = new System.Drawing.Size(100, 38);
            //this.btnSaveExcel.TabIndex = 3;
            //this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // ctrlButtonSearch1
            // 
            this.ctrlButtonSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.ctrlButtonSearch1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlButtonSearch1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlButtonSearch1.LabelText = "strSearch";
            this.ctrlButtonSearch1.Location = new System.Drawing.Point(898, 61);
            this.ctrlButtonSearch1.Name = "ctrlButtonSearch1";
            this.ctrlButtonSearch1.Size = new System.Drawing.Size(100, 38);
            this.ctrlButtonSearch1.TabIndex = 2;
            this.ctrlButtonSearch1.Click += new System.EventHandler(this.ctrlButtonSearch1_Click);
            this.ctrlButtonSearch1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrlButtonSearch_MouseClick);
            // 
            // titBar
            // 
            this.titBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.titBar.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titBar.ForeColor = System.Drawing.Color.White;
            this.titBar.Location = new System.Drawing.Point(0, -2);
            this.titBar.Margin = new System.Windows.Forms.Padding(4);
            this.titBar.Name = "titBar";
            this.titBar.Size = new System.Drawing.Size(1288, 50);
            this.titBar.TabIndex = 20;
            this.titBar.TitleText = "Trouble Information";
            // 
            // ctrlDateTimeDT2DT1
            // 
            this.ctrlDateTimeDT2DT1.BackColor = System.Drawing.Color.LightGray;
            this.ctrlDateTimeDT2DT1.EndDate = new System.DateTime(2019, 1, 25, 17, 2, 57, 472);
            this.ctrlDateTimeDT2DT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctrlDateTimeDT2DT1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ctrlDateTimeDT2DT1.Location = new System.Drawing.Point(156, 66);
            this.ctrlDateTimeDT2DT1.Name = "ctrlDateTimeDT2DT1";
            this.ctrlDateTimeDT2DT1.Size = new System.Drawing.Size(407, 27);
            this.ctrlDateTimeDT2DT1.StartDate = new System.DateTime(2019, 1, 25, 17, 2, 57, 487);
            this.ctrlDateTimeDT2DT1.TabIndex = 21;
            // 
            // ctrlBarSearchCondition1
            // 
            this.ctrlBarSearchCondition1.BackColor = System.Drawing.Color.LightGray;
            this.ctrlBarSearchCondition1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlBarSearchCondition1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlBarSearchCondition1.Location = new System.Drawing.Point(0, 55);
            this.ctrlBarSearchCondition1.Name = "ctrlBarSearchCondition1";
            this.ctrlBarSearchCondition1.Size = new System.Drawing.Size(150, 49);
            this.ctrlBarSearchCondition1.TabIndex = 22;
            // 
            // ctrlTextBoxEqpName1
            // 
            this.ctrlTextBoxEqpName1.BackColor = System.Drawing.Color.LightGray;
            this.ctrlTextBoxEqpName1.Enabled = false;
            this.ctrlTextBoxEqpName1.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTextBoxEqpName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ctrlTextBoxEqpName1.Location = new System.Drawing.Point(570, 66);
            this.ctrlTextBoxEqpName1.MaxLength = 32767;
            this.ctrlTextBoxEqpName1.Name = "ctrlTextBoxEqpName1";
            this.ctrlTextBoxEqpName1.PasswordChar = '\0';
            this.ctrlTextBoxEqpName1.Size = new System.Drawing.Size(260, 27);
            this.ctrlTextBoxEqpName1.TabIndex = 23;
            this.ctrlTextBoxEqpName1.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctrlTextBoxEqpName1.TextBoxText = "";
            this.ctrlTextBoxEqpName1.TextData = "";
            this.ctrlTextBoxEqpName1.TitleText = "DEF_CONTROL_152";
            // 
            // gridView
            // 
            this.gridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("돋움", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("돋움", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridView.HeaderColumnRowCount = 0;
            this.gridView.Location = new System.Drawing.Point(0, 126);
            this.gridView.Name = "gridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("돋움", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.Size = new System.Drawing.Size(1288, 377);
            this.gridView.TabIndex = 24;
            // 
            // WinTroubleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 528);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.ctrlTextBoxEqpName1);
            this.Controls.Add(this.ctrlBarSearchCondition1);
            this.Controls.Add(this.ctrlDateTimeDT2DT1);
            this.Controls.Add(this.titBar);
            this.Controls.Add(this.ctrlLine1);
            this.Controls.Add(this.ctrlButtonExit);
            //this.Controls.Add(this.btnSaveExcel);
            this.Controls.Add(this.ctrlButtonSearch1);
            this.Name = "WinTroubleInfo";
            this.Text = "WinTroubleInfo";
            this.Load += new System.EventHandler(this.WinTroubleInfo_Load);
            this.Controls.SetChildIndex(this.ctrlButtonSearch1, 0);
            //this.Controls.SetChildIndex(this.btnSaveExcel, 0);
            this.Controls.SetChildIndex(this.ctrlButtonExit, 0);
            this.Controls.SetChildIndex(this.ctrlLine1, 0);
            this.Controls.SetChildIndex(this.titBar, 0);
            this.Controls.SetChildIndex(this.ctrlDateTimeDT2DT1, 0);
            this.Controls.SetChildIndex(this.ctrlBarSearchCondition1, 0);
            this.Controls.SetChildIndex(this.ctrlTextBoxEqpName1, 0);
            this.Controls.SetChildIndex(this.gridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controlls.CButton.CtrlButtonSearch ctrlButtonSearch1;
        //private Controlls.CButton.CtrlButtonExcel btnSaveExcel;
        private Controlls.CButton.CtrlButtonExit ctrlButtonExit;
        private Controlls.CtrlLine ctrlLine1;
        private Controlls.CtrlTitleBar titBar;
        private Controlls.CDateTime.CtrlDateTimeDT2DT ctrlDateTimeDT2DT1;
        private Controlls.CtrlBarSearchCondition ctrlBarSearchCondition1;
        private Controlls.TextBox.CtrlTextBoxEqpName ctrlTextBoxEqpName1;
        private Controlls.NormalDataGridView gridView;
    }
}