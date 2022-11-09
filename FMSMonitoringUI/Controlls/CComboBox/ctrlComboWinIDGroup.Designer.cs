namespace MonitoringUI.Controlls.CComboBox
{
    partial class ctrlComboWinIDGroup
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
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(107, 3);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(150, 21);
            this.cbItems.TabIndex = 3;
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            // 
            // ctrlComboWinIDGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbItems);
            this.Name = "ctrlComboWinIDGroup";
            this.Load += new System.EventHandler(this.CtrlCombo_Load);
            this.Resize += new System.EventHandler(this.CtrlCombo_Resize);
            this.Controls.SetChildIndex(this.cbItems, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbItems;
    }
}