using System;
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
    public partial class CtrlRackDescription : UserControlRoot
    {

        public CtrlRackDescription()
        {
            InitializeComponent();
        }

        #region Set Label Text (1~12)
        public void SetLableTextAt(int index, string labelText)
        {
            switch (index)
            {
                case 1:
                    label1.Text = labelText;
                    break;
                case 2:
                    label2.Text = labelText;
                    break;
                case 3:
                    label3.Text = labelText;
                    break;
                case 4:
                    label4.Text = labelText;
                    break;
                case 5:
                    label5.Text = labelText;
                    break;
                case 6:
                    label6.Text = labelText;
                    break;
                case 7:
                    label7.Text = labelText;
                    break;
                case 8:
                    label8.Text = labelText;
                    break;
                case 9:
                    label9.Text = labelText;
                    break;
                case 10:
                    label10.Text = labelText;
                    break;
                case 11:
                    label11.Text = labelText;
                    break;
                case 12:
                    label12.Text = labelText;
                    break;
                default:
                    break;

            }
        }
        #endregion
        #region Set Background Color (1~12)
        public void SetLableBGColorAt(int index, Color labelColor)
        {
            switch (index)
            {
                case 1:
                    label1.BackColor = labelColor;
                    break;
                case 2:
                    label2.BackColor = labelColor;
                    break;
                case 3:
                    label3.BackColor = labelColor;
                    break;
                case 4:
                    label4.BackColor = labelColor;
                    break;
                case 5:
                    label5.BackColor = labelColor;
                    break;
                case 6:
                    label6.BackColor = labelColor;
                    break;
                case 7:
                    label7.BackColor = labelColor;
                    break;
                case 8:
                    label8.BackColor = labelColor;
                    break;
                case 9:
                    label9.BackColor = labelColor;
                    break;
                case 10:
                    label10.BackColor = labelColor;
                    break;
                case 11:
                    label11.BackColor = labelColor;
                    break;
                case 12:
                    label12.BackColor = labelColor;
                    break;
                default:
                    break;

            }
        }
        #endregion

        #region SetBG
        public void SetControlBGColor(Color bgColor)
        {
            this.BackColor = bgColor;
            label1.BackColor = bgColor;
            label2.BackColor = bgColor;
            label3.BackColor = bgColor;
            label4.BackColor = bgColor;
            label5.BackColor = bgColor;
            label6.BackColor = bgColor;
            label7.BackColor = bgColor;
            label8.BackColor = bgColor;
            label9.BackColor = bgColor;
            label10.BackColor = bgColor;
            label11.BackColor = bgColor;
            label12.BackColor = bgColor;
        }
        #endregion

        #region ClearText
        public void ClearText()
        {

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";


            
        } 
        #endregion
    }

    
}
