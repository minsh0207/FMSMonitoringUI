﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCUAClientClassLib;


namespace MonitoringUI
{
    public partial class UserControlEqp : UserControl
    {
        #region Properties
        string _EqpID = "";
        [DisplayName("EQP ID"), Description("Equipment ID"), Category("GroupBox Setting")]
        public string EqpID
        {
            get
            {
                return _EqpID;
            }
            set
            {
                _EqpID = value;
            }
        }
        #endregion

        public UserControlEqp()
        {
            InitializeComponent();
        }

        public virtual void SetData(DataRow row)
        {
            ;
        }

        
    }
}
