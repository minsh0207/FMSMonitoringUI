namespace ControlGallery
{
    partial class CtrlSCrane
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
            this.components = new System.ComponentModel.Container();
            this.lbRail = new System.Windows.Forms.Label();
            this.cranebox = new ControlGallery.CraneCarriageSmall(this.components);
            this.SuspendLayout();
            // 
            // lbRail
            // 
            this.lbRail.BackColor = System.Drawing.Color.DimGray;
            this.lbRail.Location = new System.Drawing.Point(12, 17);
            this.lbRail.Name = "lbRail";
            this.lbRail.Size = new System.Drawing.Size(8, 256);
            this.lbRail.TabIndex = 2;
            // 
            // cranebox
            // 
            this.cranebox.BackColor = System.Drawing.Color.Black;
            this.cranebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cranebox.Location = new System.Drawing.Point(4, 3);
            this.cranebox.Name = "cranebox";
            this.cranebox.Size = new System.Drawing.Size(24, 24);
            this.cranebox.TabIndex = 3;
            this.cranebox.Text = "C";
            this.cranebox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlSCrane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cranebox);
            this.Controls.Add(this.lbRail);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "CtrlSCrane";
            this.Size = new System.Drawing.Size(32, 280);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label lbRail;
        protected CraneCarriageSmall cranebox;
    }
}
