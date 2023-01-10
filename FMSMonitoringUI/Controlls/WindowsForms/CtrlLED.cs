using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FMSMonitoringUI.Controlls.WindowsForms
{
    public partial class CtrlLED : UserControl
    {
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

        public CtrlLED()
        {
            InitializeComponent();
        }

        public void LedOnOff(bool onoff)
        {            
            if (onoff)
            {
                ledLamp.Image = Properties.Resources.LedGreen.ToBitmap();
                lbTitle.Text = (_labelText == "" ? "On" : _labelText);
            }
            else
            {
                ledLamp.Image = Properties.Resources.LedNone.ToBitmap();
                lbTitle.Text = (_labelText == "" ? "Off" : _labelText);
            }
        }
        public void LedOnOff(int value)
        {
            if (value > 0)
            {
                ledLamp.Image = Properties.Resources.LedGreen.ToBitmap();
            }
            else
            {
                ledLamp.Image = Properties.Resources.LedNone.ToBitmap();
            }
        }

        /// <summary>
        /// 1=Idle, 2=Run, 4=Trouble, 0=None
        /// </summary>
        /// <param name="status"></param>
        public void LedStatus(int status)
        {
            //string path = Application.StartupPath;
            //string ledIdle = @"D:\0000.GIT\FMSMonitoringUI\FMSMonitoringUI\res\LedYellow.ico";
            //string ledRun = @"D:\0000.GIT\FMSMonitoringUI\FMSMonitoringUI\res\LedGreen.ico";
            //string ledError = @"D:\0000.GIT\FMSMonitoringUI\FMSMonitoringUI\res\LedRed.ico";

            //Image img = null;

            switch (status)
            {
                case 1:
                    //img = Image.FromFile(ledIdle);
                    ledLamp.Image = Properties.Resources.LedYellow.ToBitmap();
                    break;
                case 2:
                    //img = Image.FromFile(ledRun);
                    ledLamp.Image = Properties.Resources.LedGreen.ToBitmap();
                    break;
                case 4:
                    //img = Image.FromFile(ledError);
                    ledLamp.Image = Properties.Resources.LedRed.ToBitmap();
                    break;
                default:
                    ledLamp.Image = Properties.Resources.LedNone.ToBitmap();
                    break;
            }

            lbTitle.Text = _labelText;
            //ledLamp.Image = img.GetThumbnailImage(16, 16, null, IntPtr.Zero);
        }
    }
}
