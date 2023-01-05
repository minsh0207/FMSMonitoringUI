﻿using MonitoringUI.Common;
using MonitoringUI.Controlls;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinConveyorInfo : Form
    {
        private Point point = new Point();
        private string _cvTitle = null;

        OPCUAClient _OPCUAClient = null;
        List<ReadValueId> _ConveyorNodeID = null;

        public WinConveyorInfo(string cvTitle, OPCUAClient opcua, List<ReadValueId> conveyorNodeID)
        {
            InitializeComponent();

            _OPCUAClient = opcua;
            _ConveyorNodeID = conveyorNodeID;

            // Timer 
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Stop();

            _cvTitle = cvTitle;

            ctrlTitleBar.TitleText = string.Format("{0} Information", cvTitle);
        }

        #region WinCVTrayInfo Event
        private void WinCVTrayInfo_Load(object sender, EventArgs e)
        {
            
            InitsplitContainer();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridCVInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion
        }

        private void WinCVTrayInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_timer.Stop();
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

        private void InitsplitContainer()
        {
            //splitContainer1.BackColor = Color.LightGray;            // Color.FromArgb(53, 53, 53);
            //splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            //splitContainer2.Panel2.BackColor = Color.LightGray;     //Color.FromArgb(53, 53, 53);
            //splitContainer2.BorderStyle = BorderStyle.FixedSingle;

            //splitContainer3.BorderStyle = BorderStyle.FixedSingle;
            //splitContainer3.Panel2.BackColor = Color.FromArgb(27, 27, 27);
        }

        private void InitGridView(string cvTitle, object cvType)
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            gridCVInfo.AddColumnHeaderList(lstTitle);
            gridCVInfo.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Conveyor No");
            lstTitle.Add("Conveyor Type");

            if (CheckConveyorType(cvType))
            {
                lstTitle.Add("Station Status");
            }                

            lstTitle.Add("Tray Exist");
            lstTitle.Add("Tray Type");
            lstTitle.Add("Tray Count");
            lstTitle.Add("Tray ID 1");
            lstTitle.Add("Tray ID 2");

            if (cvTitle == "RTV")
            {
                lstTitle.Add("Carriage Pos");
            }    
            
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

        #region SetData
        public void SetData(SiteTagInfo siteInfo)
        {
            InitGridView(_cvTitle, siteInfo.ConveyorType);

            int row = 0;
            gridCVInfo.SetValue(1, row, siteInfo.ConveyorNo); row++;

            if (CheckConveyorType(siteInfo.ConveyorType))
            {
                gridCVInfo.SetValue(1, row, GetConveyorType(siteInfo.ConveyorType)); row++;
            }                

            gridCVInfo.SetValue(1, row, GetStationStatus(siteInfo.StationStatus)); row++;
            gridCVInfo.SetValue(1, row, (siteInfo.TrayExist == true ? "Exist" : "Not Exist")); row++;
            gridCVInfo.SetValue(1, row, GetTrayType(siteInfo.TrayType)); row++;
            gridCVInfo.SetValue(1, row, siteInfo.TrayCount); row++;
            gridCVInfo.SetValue(1, row, siteInfo.TrayIdL1); row++;
            gridCVInfo.SetValue(1, row, siteInfo.TrayIdL2); row++;

            if (_cvTitle == "RTV")
            {
                gridCVInfo.SetValue(1, row, siteInfo.CarriagePos); row++;
            }            

            gridCVInfo.SetValue(1, row, siteInfo.Destination);
        }
        public void SetData(List<DataValue> data)
        {
            if (data.Count == 0) return;

            InitGridView(_cvTitle, data[(int)enCVTagList.ConveyorType].Value);

            int row = 0;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.ConveyorNo].Value); row++;
            gridCVInfo.SetValue(1, row, GetConveyorType(data[(int)enCVTagList.ConveyorType].Value)); row++;

            if (CheckConveyorType(data[(int)enCVTagList.ConveyorType].Value))
            {
                gridCVInfo.SetValue(1, row, GetStationStatus(data[(int)enCVTagList.StationStatus].Value)); row++;
            }

            bool trayExist = Convert.ToBoolean(data[(int)enCVTagList.TrayExist].Value);
            gridCVInfo.SetValue(1, row, (trayExist == true ? "Exist" : "Not Exist")); row++;
            gridCVInfo.SetValue(1, row, GetTrayType(data[(int)enCVTagList.TrayType].Value)); row++;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.TrayCount].Value); row++;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.TrayIdL1].Value); row++;
            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.TrayIdL2].Value); row++;

            if (_cvTitle == "RTV")
            {
                gridCVInfo.SetValue(1, row, data[(int)enCVTagList.CarriagePos].Value); row++;
            }

            gridCVInfo.SetValue(1, row, data[(int)enCVTagList.Destination].Value);
        }
        #endregion

        #region SetTitleName
        public void SetTitleName(string title)
        {
            ctrlTitleBar.TitleText = title;
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
        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region OnTimer
        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                m_timer.Stop();

                List<DataValue> data = _OPCUAClient.ReadNodeID(_ConveyorNodeID);
                SetData(data);

                if (m_timer.Interval != 1000)
                    m_timer.Interval = 1000;
                m_timer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
            }
        }
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

        /// <summary>
        /// Conveyor Type이 2,4,8,32 일때만 StationStatus Tag을 Enable
        /// </summary>
        private bool CheckConveyorType(object idx)
        {
            int cvType = Convert.ToInt32(idx);

            if (cvType == 2 || cvType == 4 || cvType == 8 || cvType == 32)
            {
                return true;
            }

            return false;
        }
    }
}
