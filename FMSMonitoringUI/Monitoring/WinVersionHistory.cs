using FMSMonitoringUI.Common;
using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinVersionHistory : WinFormRoot
    {
        private Point point = new Point();

        public WinVersionHistory()
        {
            InitializeComponent();
                        
            InitControl();
            InitLanguage();

            InitVersionHistory();

            Exit.Left = (this.panel2.Width - Exit.Width) / 2;
            Exit.Top = (this.panel2.Height - Exit.Height) / 2;
        }

        #region WinVersionHistory Event
        private void WinVersionHistory_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Name) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }
        private void WinVersionHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        #endregion

        //화면 깜빡임 방지
        #region CreateParams
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            Exit.Left = (this.panel2.Width - Exit.Width) / 2;             
            Exit.Top = (this.panel2.Height - Exit.Height) / 2;
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            titBar.CallLocalLanguage();            

            Exit.CallLocalLanguage();
        }
        #endregion

        private void InitVersionHistory()
        {
            versionHistory.View = View.Details;

            versionHistory.Columns.Add("No", 0);
            versionHistory.Columns.Add("Date", 200);
            versionHistory.Columns.Add("Version", 200);
            versionHistory.Columns.Add("History", 600);

            versionHistory.Font = new Font(versionHistory.Font, FontStyle.Bold);

            DataAddToList();
        }

        private void DataAddToList()
        {
            versionHistory.BeginUpdate();

            //ListViewItem lv1 = new ListViewItem();

            //lv1.SubItems.Add("2023/05/08");
            //lv1.SubItems.Add("v2023.05.08.001");
            //lv1.SubItems.Add("Version History Update");

            List<ListViewItem> itemList = CVersionHistory.GetLitViewItem();

            foreach (var item in itemList)
            {
                item.Font = new Font(item.Font, FontStyle.Regular);
                versionHistory.Items.Add(item);
            }

            versionHistory.EndUpdate();
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

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion        
    }
}
