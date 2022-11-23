using OPCUAClientClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinCraneInfo : Form
    {
        private Point point = new Point();

        public WinCraneInfo()
        {
            InitializeComponent();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion
        }

        public void SetTrayInfo(CraneTagInfo tagInfo)
        {
            _TrayIdL1.TextData = tagInfo.TrayIdL1;
            _TrayIdL2.TextData = tagInfo.TrayIdL2;
            _TrayExist.TextData = (tagInfo.TrayExist == true? "Exist" : "Not Exist");
            _TrayCount.TextData = tagInfo.TrayCount.ToString();
            _TrayType.TextData = GetJobType(tagInfo.JobType);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle clientRectangle = e.ClipRectangle;

            clientRectangle.Y += 0;
            clientRectangle.Height -= 0;

            ControlPaint.DrawBorder(e.Graphics, clientRectangle, Color.White, ButtonBorderStyle.Solid);

            Rectangle textRectangle = e.ClipRectangle;

            textRectangle.X += 0;
            textRectangle.Width = 0;
            textRectangle.Height = 0;

            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRectangle);
            e.Graphics.DrawString("", Font, new SolidBrush(ForeColor), textRectangle);
        }

        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Tray Tag Value
        private string GetJobType(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "Input";
                    break;
                case 2:
                    ret = "OutPut";
                    break;
                case 3:
                    ret = "Move";
                    break;
                case 4:
                    ret = "Pass";
                    break;
                case 5:
                    ret = "Position";
                    break;
            }

            return ret;
        }
        #endregion

        #region Titel Mouse Event
        private void Title_MouseDownEvnet(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void Title_MouseMoveEvnet(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }
        #endregion
    }
}
