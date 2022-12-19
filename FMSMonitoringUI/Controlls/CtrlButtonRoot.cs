using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls.CButton
{
    public partial class CtrlButtonRoot : UserControlRoot
    {
        #region Properties
        string _labelText = "Action";
        [DisplayName("LabelText"), Description("Label Name"), Category("Button Setting")]
        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
                lbTitle.Text = _labelText;
            }
        } 
        #endregion


        public CtrlButtonRoot()
        {
            InitializeComponent();
        }

        #region MouseEvent
        private void button_MouseLeave(object sender, EventArgs e)
        {
            lbTitle.BackColor = Color.FromArgb(27, 27, 27);
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            lbTitle.BackColor = Color.FromArgb(154, 160, 166);
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            lbTitle.BackColor = Color.FromArgb(27, 27, 27);
        }
        #endregion



        private void lbTitle_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }

        private void CtrlButtonRoot_Resize(object sender, EventArgs e)
        {
            lbTitle.Width = Width;
            lbTitle.Height = Height;
        }
    }
}

