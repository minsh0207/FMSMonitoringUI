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
    public partial class CtrlSCraneV : CtrlSCrane
    {
        public CtrlSCraneV()
        {
            InitializeComponent();

            //
            this.CraneDirection = EnumCraneDirection.Up;
        }
    }
}
