namespace MonitoringUI.Controlls.CComboBox
{
    partial class CtrlComboCellType
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
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(109, 2);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(150, 21);
            this.cbItems.TabIndex = 1;
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            // 
            // CtrlComboModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbItems);
            this.Name = "CtrlComboModel";
            this.TitleText = "Model ID";
            this.Load += new System.EventHandler(this.CtrlComboModel_Load);
            this.Resize += new System.EventHandler(this.CtrlCombo_Resize);
            this.Controls.SetChildIndex(this.cbItems, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbItems;
    }
}
