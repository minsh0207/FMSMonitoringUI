using ControlGallery;
using FormationMonCtrl;
using MonitoringUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FMSMonitoringUI
{
    public partial class CtrlFormation : UserControlRoot
    {
        public CtrlFormation()
        {
            InitializeComponent();

            InitFormationBox();
        }
        
        private void CtrlFormationBox1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void InitFormationBox()
        {
            ctrlFormationBox1_01.Name = "F101";
            ctrlFormationBox1_02.Name = "F102";
            ctrlFormationBox1_03.Name = "F103";
            ctrlFormationBox1_04.Name = "F104";


            ctrlFormationBox1_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;


        }

        public static FormationMonCtrl.CtrlFormationBox FindByName(Control root, string strName)
        {
            for (int i = 0; i < root.Controls.Count; i++)
            {
                if (root.Controls[i] is ElementHost)
                {
                    if (((ElementHost)root.Controls[i]).Child is FormationMonCtrl.CtrlFormationBox)
                    {
                        FormationMonCtrl.CtrlFormationBox eh = (FormationMonCtrl.CtrlFormationBox)((ElementHost)root.Controls[i]).Child;
                        if ((string)eh.Name == strName)
                            return eh;
                    }
                }
            }

            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CtrlFormationBox formationCell = null;

            formationCell = FindByName(panelB01, "F101");


        }
    }
}
