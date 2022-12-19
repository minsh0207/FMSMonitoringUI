using MonitoringUI.Controlls;
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
    public partial class WinManageEqp : Form
    {
        private Point point = new Point();

        public WinManageEqp()
        {
            InitializeComponent();
        }

        private void WinManageEqp_Load(object sender, EventArgs e)
        {
            InitGridView();
            InitsplitContainer();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

        }

        private void InitsplitContainer()
        {
            splitContainer1.BackColor = Color.LightGray;            // Color.FromArgb(53, 53, 53);
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer2.Panel2.BackColor = Color.LightGray;     //Color.FromArgb(53, 53, 53);
            splitContainer2.BorderStyle = BorderStyle.FixedSingle;

            splitContainer3.BorderStyle = BorderStyle.FixedSingle;
            //splitContainer3.Panel2.BackColor = Color.FromArgb(27, 27, 27);
        }

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Equipment Infomation");
            lstTitle.Add("");
            EqpInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Equipment ID");
            lstTitle.Add("Equipment Name");
            lstTitle.Add("Op Mode");
            lstTitle.Add("Eqp Status");
            lstTitle.Add("Trouble Code");
            lstTitle.Add("Trouble Name");
            lstTitle.Add("Tray Infomation");
            lstTitle.Add("Tray ID");
            lstTitle.Add("Model");
            lstTitle.Add("Lot ID");
            lstTitle.Add("Route ID");
            lstTitle.Add("Process Type");
            lstTitle.Add("Process Name");
            lstTitle.Add("Input Time");
            lstTitle.Add("Plan Time");
            EqpInfo.AddRowsHeaderList(lstTitle);

            EqpInfo.ColumnHeadersHeight(24);
            EqpInfo.RowsHeight(24);

            EqpInfo.SetGridViewStyles();
            EqpInfo.ColumnHeadersWidth(0, 140);
        }

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

        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
