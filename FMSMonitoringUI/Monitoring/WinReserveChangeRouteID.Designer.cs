namespace MonitoringUI.Monitoring
{
    partial class WinReserveChangeRouteID
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
            this.cbRoute = new MonitoringUI.Controlls.CComboBox.CtrlComboRouteID();
            this.ctrlTitleBar1 = new MonitoringUI.Controlls.CtrlTitleBar();
            this.cboProc = new MonitoringUI.Controlls.CComboBox.CtrlComboProcessName();
            this.btModify = new MonitoringUI.Controlls.CButton.CtrlButtonModify();
            this.btCancel = new MonitoringUI.Controlls.CButton.CtrlButtonCancel();
            this.cbProdModel = new MonitoringUI.Controlls.TextBox.CtrlTextBoxInputModelID();
            this.SuspendLayout();
            // 
            // cbRoute
            // 
            this.cbRoute.BackColor = System.Drawing.Color.LightGray;
            this.cbRoute.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cbRoute.Location = new System.Drawing.Point(28, 116);
            this.cbRoute.Name = "cbRoute";
            this.cbRoute.SelectedIndex = -1;
            this.cbRoute.SelectedItem = null;
            this.cbRoute.SelectedKeyString = "";
            this.cbRoute.Size = new System.Drawing.Size(260, 27);
            this.cbRoute.TabIndex = 16;
            this.cbRoute.TitleText = "DEF_CONTROL_093";
            // 
            // ctrlTitleBar1
            // 
            this.ctrlTitleBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTitleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.ctrlTitleBar1.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar1.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar1.Location = new System.Drawing.Point(0, -1);
            this.ctrlTitleBar1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar1.Name = "ctrlTitleBar1";
            this.ctrlTitleBar1.Size = new System.Drawing.Size(319, 50);
            this.ctrlTitleBar1.TabIndex = 17;
            this.ctrlTitleBar1.TitleText = "Change RouteID";
            // 
            // cboProc
            // 
            this.cboProc.BackColor = System.Drawing.Color.LightGray;
            this.cboProc.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboProc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cboProc.Location = new System.Drawing.Point(28, 149);
            this.cboProc.Name = "cboProc";
            this.cboProc.SelectedIndex = -1;
            this.cboProc.SelectedItem = null;
            this.cboProc.SelectedKeyString = "";
            this.cboProc.Size = new System.Drawing.Size(260, 27);
            this.cboProc.TabIndex = 18;
            this.cboProc.TitleText = "DEF_CONTROL_095";
            // 
            // btModify
            // 
            this.btModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btModify.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btModify.LabelText = "strModify";
            this.btModify.Location = new System.Drawing.Point(55, 207);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(100, 38);
            this.btModify.TabIndex = 19;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btCancel.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btCancel.LabelText = "strCancel";
            this.btCancel.Location = new System.Drawing.Point(162, 207);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 38);
            this.btCancel.TabIndex = 20;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cbProdModel
            // 
            this.cbProdModel.BackColor = System.Drawing.Color.LightGray;
            this.cbProdModel.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbProdModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.cbProdModel.Location = new System.Drawing.Point(28, 76);
            this.cbProdModel.MaxLength = 32767;
            this.cbProdModel.Name = "cbProdModel";
            this.cbProdModel.PasswordChar = '\0';
            this.cbProdModel.ReadOnly = true;
            this.cbProdModel.Size = new System.Drawing.Size(260, 27);
            this.cbProdModel.TabIndex = 21;
            this.cbProdModel.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.cbProdModel.TextBoxText = "";
            this.cbProdModel.TextData = "";
            this.cbProdModel.TitleText = "DEF_CONTROL_097";
            // 
            // WinReserveChangeRouteID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 309);
            this.Controls.Add(this.cbProdModel);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btModify);
            this.Controls.Add(this.cboProc);
            this.Controls.Add(this.ctrlTitleBar1);
            this.Controls.Add(this.cbRoute);
            this.Name = "WinReserveChangeRouteID";
            this.Text = "WinReserveChangeRouteID";
            this.Controls.SetChildIndex(this.cbRoute, 0);
            this.Controls.SetChildIndex(this.ctrlTitleBar1, 0);
            this.Controls.SetChildIndex(this.cboProc, 0);
            this.Controls.SetChildIndex(this.btModify, 0);
            this.Controls.SetChildIndex(this.btCancel, 0);
            this.Controls.SetChildIndex(this.cbProdModel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controlls.CComboBox.CtrlComboRouteID cbRoute;
        private Controlls.CtrlTitleBar ctrlTitleBar1;
        private Controlls.CComboBox.CtrlComboProcessName cboProc;
        private Controlls.CButton.CtrlButtonModify btModify;
        private Controlls.CButton.CtrlButtonCancel btCancel;
        private Controlls.TextBox.CtrlTextBoxInputModelID cbProdModel;
    }
}