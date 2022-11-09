using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlGallery
{
    public partial class BubbleText : Label
    {

        Timer _timeout_timer;

        public BubbleText()
        {
            this.AutoSize = true;
            this.BorderStyle = BorderStyle.FixedSingle;

            _timeout_timer = new Timer();
            _timeout_timer.Interval = 3000;
            _timeout_timer.Tick += _timeout_timer_Tick;
        }

        private void _timeout_timer_Tick(object sender, EventArgs e)
        {
            _timeout_timer.Enabled = false;
            this.Visible = false;
        }

        public void DisplayText(string text, Color bgColor)
        {
            this.BringToFront();
            this.BackColor = bgColor;
            this.Text = text;
            this.Visible = true;
            _timeout_timer.Enabled = true;
        }

    }
}
