﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace MonitoringUI.Controlls.CButton
{
    public partial class CtrlButtonExcel : CtrlButtonRoot
    {
        public CtrlButtonExcel()
        {
            InitializeComponent();
        }

        private void CtrlButtonExcel_Load(object sender, EventArgs e)
        {
            LabelText = LocalLanguage.GetItemString("strExcel");
        }
    }
}
