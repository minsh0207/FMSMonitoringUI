namespace ControlGallery
{
    partial class CtrlSCraneH
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // lbRail
            // 
            this.lbRail.Location = new System.Drawing.Point(3, 13);
            this.lbRail.Size = new System.Drawing.Size(231, 8);
            // 
            // cranebox
            // 
            this.cranebox.Location = new System.Drawing.Point(3, 4);
            // 
            // CtrlSCraneH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CraneDirection = ControlGallery.EnumCraneDirection.Right;
            this.Name = "CtrlSCraneH";
            this.Size = new System.Drawing.Size(250, 32);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
