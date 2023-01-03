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
        private string _EQPID = string.Empty;

        public WinManageEqp(string eqpid)
        {
            InitializeComponent();

            _EQPID = eqpid;
        }

        private void WinManageEqp_Load(object sender, EventArgs e)
        {
            InitGridViewEqp();
            InitGridViewTray();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

        }

        #region InitGridView
        private void InitGridViewEqp()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Equipment Information");
            lstTitle.Add("");
            gridEqpInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Equipment ID");
            lstTitle.Add("Equipment Name");
            lstTitle.Add("Control Mode");       // Operation Mode
            lstTitle.Add("Equipment Status");                       
            lstTitle.Add("Trouble Code");
            lstTitle.Add("Trouble Name");
            gridEqpInfo.AddRowsHeaderList(lstTitle);

            gridEqpInfo.ColumnHeadersHeight(30);
            gridEqpInfo.RowsHeight(30);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);          // DataGridView Header 병합
            //lstColumn.Add(6);         // DataGridView 6번째 Column 병합
            lstTitle = new List<string>();
            lstTitle.Add("Equipment Information");
            //lstTitle.Add("Tray Information");
            gridEqpInfo.ColumnMergeList(lstColumn, lstTitle);

            gridEqpInfo.SetGridViewStyles();
            gridEqpInfo.ColumnHeadersWidth(0, 140);
        }
        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Tray Information");
            lstTitle.Add("");
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Tray ID");
            lstTitle.Add("Binding Time");           // tray_input_time      
            lstTitle.Add("Tray Type");              // tray_zone
            lstTitle.Add("Model");
            lstTitle.Add("Route ID");
            lstTitle.Add("Lot ID");
            lstTitle.Add("Current Process");        // Porcess_Name
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Cell Count");
            gridTrayInfo.AddRowsHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersHeight(30);
            gridTrayInfo.RowsHeight(30);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            //lstColumn.Add(6);       // DataGridView 6번째 Column 병합
            lstTitle = new List<string>();
            //lstTitle.Add("Equipment Information");
            lstTitle.Add("Tray Information");
            gridTrayInfo.ColumnMergeList(lstColumn, lstTitle);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 140);
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

        #region Exit_Click
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
