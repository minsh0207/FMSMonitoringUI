using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MySqlX.XDevAPI.Common;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinConveyorInfo : WinFormRoot
    {
        private Point point = new Point();
        private string _cvTitle = null;

        OPCUAClient _OPCUAClient = null;
        int _ConveyorNo = 0;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinConveyorInfo(string barTitle, OPCUAClient opcua, int conveyorNo)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _ConveyorNo = conveyorNo;

            // Timer 
            //m_timer.Tick += new EventHandler(OnTimer);
            //m_timer.Stop();

            _cvTitle = barTitle;

            titBar.TitleText = string.Format("{0} Information", barTitle);
        }

        #region WinCVTrayInfo Event
        private void WinCVTrayInfo_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Text) == false)
            {
                Exit_Click(null, null);
                return;
            }

            InitControl();
            InitGridView();

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridCVInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

            this.WindowID = CAuthority.GetWindowsText(this.Text);
        }

        private void WinCVTrayInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //m_timer.Stop();

            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
        }
        #endregion

        #region MonitoringTimer
        public void ShowForm()
        {
            // Timer
            m_timer.Start();

            this.Show();
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            Exit.Left = (this.panel2.Width - Exit.Width) / 2;             
            Exit.Top = (this.panel2.Height - Exit.Height) / 2;
        }
        #endregion

        #region InitGridView
        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            gridCVInfo.AddColumnHeaderList(lstTitle);
            gridCVInfo.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Conveyor No");
            lstTitle.Add("Conveyor Type");
            lstTitle.Add("Station Status");
            lstTitle.Add("Tray Exist");
            lstTitle.Add("Tray Type");
            lstTitle.Add("Tray Count");
            lstTitle.Add("Tray ID 1");
            lstTitle.Add("Tray ID 2");
            lstTitle.Add("Carriage Pos");
            lstTitle.Add("Destination");
            gridCVInfo.AddRowsHeaderList(lstTitle);

            gridCVInfo.ColumnHeadersHeight(30);
            gridCVInfo.RowsHeight(30);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Tray Information");
            //TrayInfoView.ColumnMergeList(lstColumn, lstTitle);

            gridCVInfo.SetGridViewStyles();
            gridCVInfo.ColumnHeadersWidth(0, 200);            
        }
        #endregion

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];
                    List<DataValue> data = _OPCUAClient.ReadNodeID(cvInfo);
                    this.BeginInvoke(new Action(() => SetData(data)));

                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WinConveyorInfo ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region SetData
        //public void SetData(SiteTagInfo siteInfo)
        //{
        //    int row = 0;
        //    gridCVInfo.SetValue(1, row, siteInfo.ConveyorNo); row++;

        //    if (CheckConveyorType(siteInfo.ConveyorType)) gridCVInfo.RowsVisible(row, true);
        //    else gridCVInfo.RowsVisible(row, false);

        //    gridCVInfo.SetValue(1, row, GetConveyorType(siteInfo.ConveyorType)); row++;
        //    gridCVInfo.SetValue(1, row, GetStationStatus(siteInfo.StationStatus)); row++;
        //    gridCVInfo.SetValue(1, row, (siteInfo.TrayExist == true ? "Exist" : "Not Exist")); row++;
        //    gridCVInfo.SetValue(1, row, GetTrayType(siteInfo.TrayType)); row++;
        //    gridCVInfo.SetValue(1, row, siteInfo.TrayCount); row++;
        //    gridCVInfo.SetValue(1, row, siteInfo.TrayIdL1); row++;
        //    gridCVInfo.SetValue(1, row, siteInfo.TrayIdL2); row++;

        //    if (_cvTitle == "RTV") gridCVInfo.RowsVisible(row, true);
        //    else gridCVInfo.RowsVisible(row, false);

        //    gridCVInfo.SetValue(1, row, siteInfo.CarriagePos); row++;
        //    gridCVInfo.SetValue(1, row, siteInfo.Destination);
        //}
        public void SetData(List<DataValue> data)
        {
            if (data == null || data.Count == 0) return;

            int row = 0;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.ConveyorNo].Value); row++;
            gridCVInfo.SetValue(1, row, GetConveyorType(data[(int)enCVTagList.ConveyorType].Value)); row++;

            if (CheckStationStatus(data[(int)enCVTagList.ConveyorType].Value)) 
                gridCVInfo.RowsVisible(row, true);
            else gridCVInfo.RowsVisible(row, false);
            gridCVInfo.SetValue(1, row, GetStationStatus(data[(int)enCVTagList.StationStatus].Value)); row++;

            bool trayExist = Convert.ToBoolean(data[(int)enCVTagList.TrayExist].Value);
            gridCVInfo.SetValue(1, row, (trayExist == true ? "Exist" : "Not Exist")); row++;
            gridCVInfo.SetValue(1, row, GetTrayType(data[(int)enCVTagList.TrayType].Value)); row++;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.TrayCount].Value); row++;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.TrayIdL1].Value); row++;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.TrayIdL2].Value); row++;

            if (_cvTitle == "RTV") gridCVInfo.RowsVisible(row, true);
            else gridCVInfo.RowsVisible(row, false);
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.CarriagePos].Value); row++;

            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.Destination].Value);
        }
        #endregion

        #region SetTitleName
        public void SetTitleName(string title)
        {
            titBar.TitleText = title;
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

        #region DataGridView Event
        private void GridCellInfo_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 1 && row > -1)
            {
                //MessageBox.Show($"TrayInfoView DoubleClick CellID = {value}");

                //WinCellDetailInfo form = new WinCellDetailInfo();
                //form.SetData();
                //form.ShowDialog();

                //Refresh();
            }
        }
        #endregion

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region OnTimer
        //private void OnTimer(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        m_timer.Stop();

        //        List<DataValue> data = _OPCUAClient.ReadNodeID(_ConveyorNodeID);
        //        SetData(data);

        //        if (m_timer.Interval != 1000)
        //            m_timer.Interval = 1000;
        //        m_timer.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.Print(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
        //    }
        //}
        #endregion

        

        #region Tray Tag Value
        private string GetConveyorType(object idx)
        {
            string ret = string.Empty;

            int cvType = Convert.ToInt32(idx);

            switch (cvType)
            {
                case 1:
                    ret = "Conveyor Unit";
                    break;
                case 2:
                    ret = "InStation";
                    break;
                case 4:
                    ret = "OutStation";
                    break;
                case 8:
                    ret = "InOutStation";
                    break;
                case 16:
                    ret = "BufferStation";
                    break;
                case 32:
                    ret = "Diverter";
                    break;
                case 64:
                    ret = "Magazine";
                    break;
                case 128:
                    ret = "Dispenser";
                    break;
                case 256:
                    ret = "MZ / DP";
                    break;
            }

            return ret;
        }

        private string GetStationStatus(object idx)
        {
            string ret = string.Empty;

            int cvStatus = Convert.ToInt32(idx);

            switch (cvStatus)
            {
                case 0:
                    ret = "Not Used";
                    break;
                case 1:
                    ret = "Station Down";
                    break;
                case 2:
                    ret = "Station Up";
                    break;
            }

            return ret;
        }

        private string GetTrayType(object idx)
        {
            string ret = string.Empty;

            int trayType = Convert.ToInt32(idx);

            switch (trayType)
            {
                case 1:
                    ret = "BD - Before Degas Long Tray";
                    break;
                case 2:
                    ret = "AD - After Degas Short Tray";
                    break;
            }

            return ret;
        }
        #endregion

        #region CheckStationStatus
        /// <summary>
        /// Conveyor Type이 2,4,8,32 일때만 StationStatus Tag을 Enable
        /// </summary>
        private bool CheckStationStatus(object idx)
        {
            int cvType = Convert.ToInt32(idx);

            if (cvType == 2 || cvType == 4 || cvType == 8 || cvType == 32)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
