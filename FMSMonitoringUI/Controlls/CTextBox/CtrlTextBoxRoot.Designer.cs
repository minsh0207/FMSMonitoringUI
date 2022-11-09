namespace MonitoringUI.Controlls.CComboBox
{
    partial class CtrlTextBoxRoot
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
            this.TextBoxData = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxData
            // 
            this.TextBoxData.AcceptsReturn = true;
            this.TextBoxData.BackColor = System.Drawing.Color.White;
            this.TextBoxData.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxData.HideSelection = false;
            this.TextBoxData.Location = new System.Drawing.Point(109, 2);
            this.TextBoxData.Name = "TextBoxData";
            this.TextBoxData.Size = new System.Drawing.Size(150, 22);
            this.TextBoxData.TabIndex = 4;
            this.TextBoxData.WordWrap = false;
            this.TextBoxData.TextChanged += new System.EventHandler(this.TextBoxData_TextChanged);
            this.TextBoxData.DoubleClick += new System.EventHandler(this.TextBoxData_DoubleClick);
            this.TextBoxData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxData_KeyDown);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbTitle.Location = new System.Drawing.Point(1, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(100, 25);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Title";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CtrlTextBoxRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.TextBoxData);
            this.Controls.Add(this.lbTitle);
            this.Name = "CtrlTextBoxRoot";
            this.Size = new System.Drawing.Size(260, 27);
            this.Resize += new System.EventHandler(this.CtrlTextBoxRoot_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox TextBoxData;
    }
}
