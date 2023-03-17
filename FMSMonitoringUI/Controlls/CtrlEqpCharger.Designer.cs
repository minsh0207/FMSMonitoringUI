namespace FMSMonitoringUI.Controlls
{
    partial class CtrlEqpCharger
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnLeadTime = new MonitoringUI.Controlls.CButton.CtrlButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.uiTlbEqpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlLine1 = new MonitoringUI.Controlls.CtrlLine();
            this.ctrlLine2 = new MonitoringUI.Controlls.CtrlLine();
            this.ctrlLine3 = new MonitoringUI.Controlls.CtrlLine();
            this.uiTlbEqpMode1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiTlbEqpMode2 = new System.Windows.Forms.TableLayoutPanel();
            this.uiTlbEqpMode3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnLeadTime);
            this.splitContainer1.Size = new System.Drawing.Size(163, 27);
            this.splitContainer1.SplitterDistance = 62;
            this.splitContainer1.TabIndex = 57;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(60, 25);
            this.lbTitle.TabIndex = 42;
            this.lbTitle.Text = "CHG";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbEqpType_MouseClick);
            this.lbTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbEqpType_MouseDoubleClick);
            // 
            // btnLeadTime
            // 
            this.btnLeadTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnLeadTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeadTime.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLeadTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnLeadTime.LabelText = "Lead Time";
            this.btnLeadTime.LanguageID = "DEF_Lead_Time";
            this.btnLeadTime.Location = new System.Drawing.Point(0, 0);
            this.btnLeadTime.Name = "btnLeadTime";
            this.btnLeadTime.Size = new System.Drawing.Size(95, 25);
            this.btnLeadTime.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 12);
            this.label12.TabIndex = 71;
            this.label12.Text = "1F";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(4, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 12);
            this.label13.TabIndex = 72;
            this.label13.Text = "2F";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(4, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 12);
            this.label14.TabIndex = 73;
            this.label14.Text = "3F";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(4, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 12);
            this.label15.TabIndex = 74;
            this.label15.Text = "4F";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(30, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 11);
            this.label16.TabIndex = 75;
            this.label16.Text = "1Bay";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(75, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 11);
            this.label17.TabIndex = 76;
            this.label17.Text = "2Bay";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(119, 119);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 11);
            this.label18.TabIndex = 77;
            this.label18.Text = "3Bay";
            // 
            // uiTlbEqpStatus
            // 
            this.uiTlbEqpStatus.ColumnCount = 3;
            this.uiTlbEqpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTlbEqpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTlbEqpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTlbEqpStatus.Location = new System.Drawing.Point(24, 37);
            this.uiTlbEqpStatus.Name = "uiTlbEqpStatus";
            this.uiTlbEqpStatus.RowCount = 4;
            this.uiTlbEqpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpStatus.Size = new System.Drawing.Size(134, 76);
            this.uiTlbEqpStatus.TabIndex = 78;
            // 
            // ctrlLine1
            // 
            this.ctrlLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLine1.Location = new System.Drawing.Point(24, 54);
            this.ctrlLine1.Name = "ctrlLine1";
            this.ctrlLine1.Size = new System.Drawing.Size(132, 3);
            this.ctrlLine1.TabIndex = 79;
            // 
            // ctrlLine2
            // 
            this.ctrlLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLine2.Location = new System.Drawing.Point(24, 74);
            this.ctrlLine2.Name = "ctrlLine2";
            this.ctrlLine2.Size = new System.Drawing.Size(132, 3);
            this.ctrlLine2.TabIndex = 80;
            // 
            // ctrlLine3
            // 
            this.ctrlLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ctrlLine3.Location = new System.Drawing.Point(24, 93);
            this.ctrlLine3.Name = "ctrlLine3";
            this.ctrlLine3.Size = new System.Drawing.Size(132, 3);
            this.ctrlLine3.TabIndex = 81;
            // 
            // uiTlbEqpMode1
            // 
            this.uiTlbEqpMode1.ColumnCount = 1;
            this.uiTlbEqpMode1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTlbEqpMode1.Location = new System.Drawing.Point(24, 37);
            this.uiTlbEqpMode1.Name = "uiTlbEqpMode1";
            this.uiTlbEqpMode1.RowCount = 4;
            this.uiTlbEqpMode1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode1.Size = new System.Drawing.Size(10, 76);
            this.uiTlbEqpMode1.TabIndex = 79;
            // 
            // uiTlbEqpMode2
            // 
            this.uiTlbEqpMode2.ColumnCount = 1;
            this.uiTlbEqpMode2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTlbEqpMode2.Location = new System.Drawing.Point(70, 37);
            this.uiTlbEqpMode2.Name = "uiTlbEqpMode2";
            this.uiTlbEqpMode2.RowCount = 4;
            this.uiTlbEqpMode2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode2.Size = new System.Drawing.Size(10, 76);
            this.uiTlbEqpMode2.TabIndex = 80;
            // 
            // uiTlbEqpMode3
            // 
            this.uiTlbEqpMode3.ColumnCount = 1;
            this.uiTlbEqpMode3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTlbEqpMode3.Location = new System.Drawing.Point(115, 37);
            this.uiTlbEqpMode3.Name = "uiTlbEqpMode3";
            this.uiTlbEqpMode3.RowCount = 4;
            this.uiTlbEqpMode3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTlbEqpMode3.Size = new System.Drawing.Size(10, 76);
            this.uiTlbEqpMode3.TabIndex = 82;
            // 
            // CtrlEqpCharger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ctrlLine3);
            this.Controls.Add(this.ctrlLine2);
            this.Controls.Add(this.ctrlLine1);
            this.Controls.Add(this.uiTlbEqpMode3);
            this.Controls.Add(this.uiTlbEqpMode2);
            this.Controls.Add(this.uiTlbEqpMode1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.uiTlbEqpStatus);
            this.Name = "CtrlEqpCharger";
            this.Size = new System.Drawing.Size(163, 134);
            this.Load += new System.EventHandler(this.CtrlEqpCharger_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbTitle;
        private MonitoringUI.Controlls.CButton.CtrlButton btnLeadTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TableLayoutPanel uiTlbEqpStatus;
        private MonitoringUI.Controlls.CtrlLine ctrlLine1;
        private MonitoringUI.Controlls.CtrlLine ctrlLine2;
        private MonitoringUI.Controlls.CtrlLine ctrlLine3;
        private System.Windows.Forms.TableLayoutPanel uiTlbEqpMode1;
        private System.Windows.Forms.TableLayoutPanel uiTlbEqpMode2;
        private System.Windows.Forms.TableLayoutPanel uiTlbEqpMode3;
    }
}
