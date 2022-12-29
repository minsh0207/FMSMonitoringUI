using MonitoringUI.Common;
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
    public partial class WinCraneInfo : Form
    {
        private Point point = new Point();

        public WinCraneInfo()
        {
            InitializeComponent();

            InitGridViewCraneStatus();
            InitGridViewCraneCmd();
        }

        private void WinCraneInfo_Load(object sender, EventArgs e)
        {
            InitLedStatus();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            //gridCraneCmd.MouseCellClick_Evnet += GridProcessFlow_MouseCellClick;
            #endregion
        }

        private void InitLedStatus()
        {
            ledIdle.LedStatus(0);
            ledRun.LedStatus(0);
            ledTrouble.LedStatus(0);
            ledIdle.LedStatus(1);

            ledForkPosC.LedOnOff(false);
            ledForkPosL1.LedOnOff(false);
            ledForkPosL2.LedOnOff(false);
            ledForkPosR1.LedOnOff(false);
            ledForkPosR2.LedOnOff(false);
            ledForkPosC.LedOnOff(true);

            ledJogTypeIn.LedOnOff(false);
            ledJogTypeOut.LedOnOff(false);
            ledJogTypeRtoR.LedOnOff(false);
            ledJogTypePass.LedOnOff(false);
            ledJogTypeMove.LedOnOff(false);
            ledJogTypeIn.LedOnOff(true);
        }

        private void InitGridViewCraneStatus()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Equipment Status");   //-1
            lstTitle.Add("");
            gridCraneStatus.AddColumnHeaderList(lstTitle);
            gridCraneStatus.ColumnHeadersVisible(true);

            lstTitle = new List<string>();
            lstTitle.Add("Power");
            lstTitle.Add("Mode");
            lstTitle.Add("Status");
            lstTitle.Add("Trouble ErrorNo");
            lstTitle.Add("Trouble ErrorLevel");

            lstTitle.Add("FMS Status");     // 5            
            lstTitle.Add("Trouble Status");
            lstTitle.Add("Trouble ErrorNo");
            lstTitle.Add("TimeSync");

            lstTitle.Add("Crane Information");       // 9
            lstTitle.Add("Carriage PosBay");
            lstTitle.Add("Carriage PosFloor");
            lstTitle.Add("Carriage FireSensor");
            gridCraneStatus.AddRowsHeaderList(lstTitle);

            gridCraneStatus.ColumnHeadersHeight(22);
            gridCraneStatus.RowsHeight(22);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstColumn.Add(5);
            lstColumn.Add(9);
            lstTitle = new List<string>();
            lstTitle.Add("Equipment Status");
            lstTitle.Add("FMS Status");
            lstTitle.Add("Crane Information");
            gridCraneStatus.ColumnMergeList(lstColumn, lstTitle);

            gridCraneStatus.SetGridViewStyles();
            gridCraneStatus.ColumnHeadersWidth(0, 180);
        }

        private void InitGridViewCraneCmd()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("From Location");   
            lstTitle.Add("To Location");
            gridCraneCmd.AddColumnHeaderList(lstTitle);
            gridCraneCmd.ColumnHeadersVisible(true);

            lstTitle = new List<string>();
            lstTitle.Add("Line");
            lstTitle.Add("Bay");
            lstTitle.Add("Floor");
            lstTitle.Add("Deep");
            lstTitle.Add("Station");
            lstTitle.Add("Forking Enable");
            gridCraneCmd.AddRowsHeaderList(lstTitle);

            gridCraneCmd.ColumnHeadersHeight(24);
            gridCraneCmd.RowsHeight(24);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Crane Command");
            //gridCraneCmd.ColumnMergeList(lstColumn, lstTitle);

            gridCraneCmd.SetGridViewStyles();
            gridCraneCmd.ColumnHeadersWidth(0, 100);
        }

        public void SetData(string trayid)
        {
            gridCraneStatus.SetValue(1, 1, trayid);
        }

        public void SetTitleName(string title)
        {
            ctrlTitleBar.TitleText = title;
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

        #region DataGridView Event
        //private void GridProcessFlow_MouseCellClick(int col, int row, object value)
        //{
        //    if (col == gridCraneCmd.ColumnCount -1 && row > -1)
        //    {
        //        WinCellDetailInfo form = new WinCellDetailInfo();
        //        form.SetData();
        //        form.ShowDialog();
        //    }
        //}
        #endregion

        //private void ctrlButton1_Click(object sender, EventArgs e)
        //{
        //    WinCellDetailInfo form = new WinCellDetailInfo();
        //    form.SetData();
        //    form.ShowDialog();
        //}

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
