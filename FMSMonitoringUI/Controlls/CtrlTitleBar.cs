﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls
{
    public partial class CtrlTitleBar : UserControl
    {
        public delegate void EventHandler(string title);
        public event EventHandler Click_Evnet = null;

        #region Properties
        string _labelText = "";
        [DisplayName("TitleText"), Description("Title"), Category("TextBox Setting")]
        public string TitleText
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

        public CtrlTitleBar()
        {
            InitializeComponent();
        }

        public void LbTitle_Click(object sender, EventArgs e)
        {
            if (this.Click_Evnet != null)                
                Click_Evnet(TitleText);
        }

        private void LbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            lbTitle.ForeColor = Color.FromArgb(0,129,110);
        }

        private void LbTitle_MouseLeave(object sender, EventArgs e)
        {
            lbTitle.ForeColor = Color.White;
        }
    }
}
