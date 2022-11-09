namespace MonitoringUI.Controlls.CComboBox
{
    partial class CtrlTextBoxTopRoot
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
            this.TextBoxData = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxData
            // 
            this.TextBoxData.BackColor = System.Drawing.Color.White;
            this.TextBoxData.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxData.Location = new System.Drawing.Point(3, 37);
            this.TextBoxData.Name = "TextBoxData";
            this.TextBoxData.Size = new System.Drawing.Size(150, 22);
            this.TextBoxData.TabIndex = 6;
            this.TextBoxData.TextChanged += new System.EventHandler(this.TextBoxData_TextChanged);
            this.TextBoxData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxData_KeyDown);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbTitle.Location = new System.Drawing.Point(3, 4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(150, 27);
            this.lbTitle.TabIndex = 5;
            this.lbTitle.Text = "Title";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlTextBoxTopRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxData);
            this.Controls.Add(this.lbTitle);
            this.Name = "CtrlTextBoxTopRoot";
            this.Size = new System.Drawing.Size(156, 63);
            this.Resize += new System.EventHandler(this.Ctrl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxData;
        private System.Windows.Forms.Label lbTitle;
    }
}