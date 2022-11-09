using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlGallery
{
    public partial class CtrlSCraneH : CtrlSCrane
    {
        public CtrlSCraneH()
        {
            InitializeComponent();

            //
            this.CraneDirection = EnumCraneDirection.Right;
        }
    }
}
