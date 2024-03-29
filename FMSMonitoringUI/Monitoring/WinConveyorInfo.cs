﻿using Google.Protobuf.WellKnownTypes;
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
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinConveyorInfo : WinFormRoot
    {
        private Point point = new Point();
        private string _cvTitle = null;

        private string _trayID1 = string.Empty;
        private string _trayID2 = string.Empty;

        OPCUAClient _OPCUAClient = null;
        private int _ConveyorNo = 0;
        private string _ConveyorType = string.Empty;

        //#region Working Thread
        //private Thread _ProcessThread;
        //private bool _TheadVisiable;
        //#endregion

        // Timer
        DispatcherTimer m_timer;

        public WinConveyorInfo(string barTitle, OPCUAClient opcua, int conveyorNo, string conveyorType)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _ConveyorNo = conveyorNo;
            _ConveyorType = conveyorType;

            _cvTitle = barTitle;

            titBar.TitleText = string.Format("{0} {1}", barTitle, LocalLanguage.GetItemString("DEF_Information"));
            Invalidate();
        }

        #region WinCVTrayInfo Event
        private void WinCVTrayInfo_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Name) == false)
            {
                Exit_Click(null, null);
                return;
            }

            InitControl();
            InitGridView();
            InitLanguage();

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            //#region DataGridView Event
            //gridCVInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            //#endregion

            // Init Timer
            m_timer = new DispatcherTimer();

            //m_timer.Interval = TimeSpan.FromSeconds(2);
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Start();

            //_TheadVisiable = true;

            //this.BeginInvoke(new MethodInvoker(delegate ()
            //{
            //    _ProcessThread = new Thread(() => ProcessThreadCallback());
            //    _ProcessThread.IsBackground = true; _ProcessThread.Start();
            //}));

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }

        private void WinCVTrayInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this._ProcessThread.IsAlive)
            //    this._TheadVisiable = false;

            //this._ProcessThread.Abort();

            m_timer.Stop();
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

        #region InitGridView
        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            gridCVInfo.AddColumnHeaderList(lstTitle);
            gridCVInfo.ColumnHeadersVisible(false);

            if (_cvTitle == "RTV")
            {
                lstTitle = new List<string>
                {
                    LocalLanguage.GetItemString("DEF_Track_No"),
                    LocalLanguage.GetItemString("DEF_Conveyor_Trye"),
                    LocalLanguage.GetItemString("DEF_Direction"),
                    LocalLanguage.GetItemString("DEF_Tray_Exist").Replace(" :", ""),
                    LocalLanguage.GetItemString("DEF_Tray_Type"),
                    LocalLanguage.GetItemString("DEF_Tray_Count"),
                    LocalLanguage.GetItemString("DEF_Tray_ID_1"),
                    LocalLanguage.GetItemString("DEF_Tray_ID_2"),
                    LocalLanguage.GetItemString("DEF_Station_Status"),
                    LocalLanguage.GetItemString("DEF_Tacking_Destination"),
                    LocalLanguage.GetItemString("DEF_Carriage_Position"),
                    LocalLanguage.GetItemString("DEF_RTV_From"),
                    LocalLanguage.GetItemString("DEF_RTV_To")
                };
            }
            else
            {
                lstTitle = new List<string>
                {
                    LocalLanguage.GetItemString("DEF_Track_No"),
                    LocalLanguage.GetItemString("DEF_Conveyor_Trye"),
                    LocalLanguage.GetItemString("DEF_Direction"),
                    LocalLanguage.GetItemString("DEF_Tray_Exist").Replace(" :", ""),
                    LocalLanguage.GetItemString("DEF_Tray_Type"),
                    LocalLanguage.GetItemString("DEF_Tray_Count"),
                    LocalLanguage.GetItemString("DEF_Tray_ID_1"),
                    LocalLanguage.GetItemString("DEF_Tray_ID_2"),
                    LocalLanguage.GetItemString("DEF_Station_Status"),
                    LocalLanguage.GetItemString("DEF_Tacking_Destination")
                };
            }

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

        #region [Timer Event]
        /////////////////////////////////////////////////////////////////////
        //	Timer Event
        //===================================================================
        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                //timer Stop And Start
                m_timer.Stop();

                List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];
                List<DataValue> data = _OPCUAClient.ReadNodeID(cvInfo);
                this.BeginInvoke(new Action(() => SetData(data, cvInfo)));

                //Set Time interval
                if (m_timer.Interval.Seconds.ToString() != "2")
                    m_timer.Interval = TimeSpan.FromSeconds(2);

                //timer Stop And Start
                m_timer.Start();

            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WinConveyorInfo Timer Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.Error, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "OnTimer Error Exception : " + ex.Message);
            }
        }
        #endregion

        #region ProcessThreadCallback
        //private void ProcessThreadCallback()
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //        {
        //            //while (this._TheadVisiable == true)
        //            {
        //                GC.Collect();

        //                List<ReadValueId> cvInfo = _OPCUAClient.ConveyorNodeID[_ConveyorNo];
        //                List<DataValue> data = _OPCUAClient.ReadNodeID(cvInfo);
        //                this.BeginInvoke(new Action(() => SetData(data, cvInfo)));

        //                //Thread.Sleep(2000);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // System Debug
        //        System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

        //        string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
        //        CLogger.WriteLog(enLogLevel.Error, this.Name, log);
        //    }
        //}
        #endregion

        #region SetData
        public void SetData(List<DataValue> data, List<ReadValueId> cvInfo)
        {
            if (data == null || data.Count == 0) return;

            int row = 0;
            int trackNo;

            string tagValue = GetTagValuetoString("ConveyorInformation.TrackNo", data, cvInfo);
            if (tagValue == "0")
                trackNo = _ConveyorNo;
            else
                trackNo = Convert.ToInt16(tagValue);
            gridCVInfo.SetValue(1, row, trackNo == (int)enEqpType.RTV01 ? 1 : trackNo); row++;

            int cvTypeIdx = GetTagValuetoInt("ConveyorInformation.ConveyorType", data, cvInfo);
            gridCVInfo.SetValue(1, row, GetConveyorType(data[cvTypeIdx].Value)); row++;

            tagValue = GetTagValuetoString("ConveyorInformation.Direction", data, cvInfo);
            gridCVInfo.SetValue(1, row, GetDirection(tagValue)); row++;

            bool trayExist = GetTagValuetoBool("ConveyorInformation.TrayExist", data, cvInfo);
            //gridCVInfo.SetValue(1, row, (trayExist == true ? "Exist" : "Not Exist")); row++;
            ledTrayExist.LedOnOff(trayExist); row++;

            tagValue = GetTagValuetoString("ConveyorInformation.TrayType", data, cvInfo);
            gridCVInfo.SetValue(1, row, GetTrayType(tagValue)); row++;

            tagValue = GetTagValuetoString("ConveyorInformation.TrayCount", data, cvInfo);
            gridCVInfo.SetValue(1, row, tagValue); row++;

            tagValue = GetTagValuetoString("ConveyorInformation.TrayIdL1", data, cvInfo);
            gridCVInfo.SetValue(1, row, tagValue); row++;
            _trayID1 = tagValue;

            tagValue = GetTagValuetoString("ConveyorInformation.TrayIdL2", data, cvInfo);
            //if (Convert.ToString(data[tagIdx].Value) == "")
            //    gridCVInfo.RowsVisible(row, false);
            //else
            //    gridCVInfo.RowsVisible(row, true);

            gridCVInfo.SetValue(1, row, tagValue); row++;
            _trayID2 = tagValue;            

            if (CheckStationStatus(data[cvTypeIdx].Value))
            {
                gridCVInfo.RowsVisible(row, true);
            }
            else
                gridCVInfo.RowsVisible(row, false);

            tagValue = GetTagValuetoString("ConveyorInformation.StationStatus", data, cvInfo);
            gridCVInfo.SetValue(1, row, GetStationStatus(tagValue)); row++;

            if (_cvTitle == "RTV")
            {
                tagValue = GetTagValuetoString("ConveyorInformation.TrackingDestination", data, cvInfo);
                gridCVInfo.SetValue(1, row, tagValue); row++;

                tagValue = GetTagValuetoString("ConveyorInformation.CarriagePos", data, cvInfo);
                gridCVInfo.SetValue(1, row, tagValue); row++;

                tagValue = GetTagValuetoString("ConveyorCommand.RTVFrom", data, cvInfo);
                gridCVInfo.SetValue(1, row, tagValue); row++;

                tagValue = GetTagValuetoString("ConveyorCommand.RTVTo", data, cvInfo);
                gridCVInfo.SetValue(1, row, tagValue);
            }
            else
            {
                tagValue = GetTagValuetoString("ConveyorInformation.TrackingDestination", data, cvInfo);
                gridCVInfo.SetValue(1, row, tagValue);
            }
        }
        #endregion

        #region SetTitleName
        public void SetTitleName(string title)
        {
            titBar.TitleText = title;
        }
        #endregion

        #region GetTrayID
        public void GetTrayID(ref string trayID1, ref string trayID2)
        {
            trayID1 = _trayID1;
            trayID2 = _trayID2; ;
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
        //private void GridCellInfo_MouseCellDoubleClick(int col, int row, object value)
        //{
        //    if (col == 1 && row > -1)
        //    {
        //        //MessageBox.Show($"TrayInfoView DoubleClick CellID = {value}");

        //        //WinCellDetailInfo form = new WinCellDetailInfo();
        //        //form.SetData();
        //        //form.Show();

        //        //Refresh();
        //    }
        //}
        #endregion

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Tray Tag Value
        private string GetConveyorType(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

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
                case 512:
                    ret = "RTV";
                    break;
            }

            return ret;
        }

        private string GetStationStatus(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

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
            if (idx == null || idx.ToString() == "") return "";

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

        private string GetDirection(object idx)
        {
            if (idx == null || idx.ToString() == "") return "";

            string ret;

            bool mzCmd = Convert.ToBoolean(idx);

            if (mzCmd == true)
            {
                ret = _ConveyorType == "Conveyor" ? "Backward (Unloading)" : "Dispenser";
            }
            else
            {
                ret = _ConveyorType == "Conveyor" ? "Forward (Loading)" : "Magazine";
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
            if (idx == null || idx.ToString() == "") return false;

            int cvType = Convert.ToInt32(idx);

            if (cvType == 2 || cvType == 4 || cvType == 8 || cvType == 32)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region GetTagIndex
        private int GetTagIndex(string tagPath, List<ReadValueId> cvInfo)
        {
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            return idx < 0 ? 0 : idx;
        }
        #endregion

        #region GetTagValue
        private string GetTagValuetoString(string tagPath, List<DataValue> data, List<ReadValueId> cvInfo)
        {
            string val = string.Empty;
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            if (idx > -1)
                val = Convert.ToString(data[idx].Value);

            return val;
        }

        private bool GetTagValuetoBool(string tagPath, List<DataValue> data, List<ReadValueId> cvInfo)
        {
            bool val = false;
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            if (idx > -1)
                val = Convert.ToBoolean(data[idx].Value);

            return val;
        }

        private int GetTagValuetoInt(string tagPath, List<DataValue> data, List<ReadValueId> cvInfo)
        {
            int val = 0;
            int idx = cvInfo.FindIndex(x => x.UserData.ToString().EndsWith(tagPath));

            if (idx > -1)
                val = Convert.ToInt16(data[idx].Value);

            return val;
        }
        #endregion
    }
}
