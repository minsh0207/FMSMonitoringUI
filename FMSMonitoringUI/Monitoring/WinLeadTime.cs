using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinLeadTime : Form
    {
        private Point point = new Point();
        private string _EqpId = string.Empty;
        private string _EqpType = string.Empty;
        private int _Eqplevel = 0;

        private List<_win_lead_time> _AgingTrayInfo = new List<_win_lead_time>();

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinLeadTime(string eqpId, string eqpType, int eqpLevel)
        {
            InitializeComponent();

            _EqpId = eqpId;
            _EqpType = eqpType;
            _Eqplevel = eqpLevel;

            InitGridViewTray();

            //GetAgingTrayInfo(eqpType, eqpLevel);

            
            //InitChart();
        }

        #region WinLeadTime Event
        private void WinLeadTime_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridTrayInfo.MouseCellDoubleClick_Evnet += GridTrayInfo_MouseCellDoubleClick;
            #endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

        }
        private void WinLeadTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
        }
        #endregion

        //private void InitChart()
        //{
        //    chart1.Series[0].Points.Add(80);
        //    chart1.Series[0].Points.Add(50);
        //    chart1.Series[0].Points.Add(90);
        //    chart1.Series[0].Points.Add(40);
        //    chart1.Series[0].Points.Add(70);
        //    chart1.Series[0].Points.Add(60);
        //    chart1.Series[0].Points.Add(70);
        //    chart1.Series[0].Points.Add(80);
        //}

        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Location");
            lstTitle.Add("Rack ID");            
            lstTitle.Add("Tray ID L1");
            lstTitle.Add("Tray ID L2");
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Process Time");
            lstTitle.Add("Specs (MES)");
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            gridTrayInfo.AddRowsHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersHeight(30);
            gridTrayInfo.RowsHeight(26);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Tray Information");
            //TrayInfoView.ColumnMergeList(lstColumn, lstTitle);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 180);
            gridTrayInfo.ColumnHeadersWidth(1, 120);
            gridTrayInfo.ColumnHeadersWidth(7, 120);
        }

        #region SetData
        private void SetData(List<_win_lead_time> data)
        {
            if (data.Count == 0) return;

            gridTrayInfo.RowCount= data.Count;
            int row = 0;

            foreach (var item in data)
            {
                int col = 0;
                string location = string.Format($"{item.LINE}Line-{item.LANE}Lane-{item.BAY}Bay-{item.FLOOR}F");
                gridTrayInfo.SetValue(col, row, location); col++;
                gridTrayInfo.SetValue(col, row, item.RACK_ID); col++;
                gridTrayInfo.SetValue(col, row, item.TRAY_ID); col++;
                gridTrayInfo.SetValue(col, row, item.TRAY_ID_2); col++;
                gridTrayInfo.SetValue(col, row, item.START_TIME); col++;
                gridTrayInfo.SetValue(col, row, item.PLAN_TIME); col++;
                gridTrayInfo.SetValue(col, row, GetTimeSpan(item.START_TIME)); col++;
                gridTrayInfo.SetValue(col, row, "0000");
                row++;
            }

            gridTrayInfo.SetGridViewStyles();
        }
        private void SetData1(List<_win_lead_time> data)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Location");            
            dt.Columns.Add("Rack ID");
            dt.Columns.Add("Tray ID L1");
            dt.Columns.Add("Tray ID L2");
            dt.Columns.Add("Start Time");
            dt.Columns.Add("Plan Time");
            dt.Columns.Add("Process Time");
            dt.Columns.Add("Specs (MES)");

            foreach (var item in data)
            {
                DataRow rowEx1 = dt.NewRow();

                rowEx1["Location"] = item.LANE;
                rowEx1["Rack ID"] = item.RACK_ID;
                rowEx1["Tray ID L1"] = item.TRAY_ID;
                rowEx1["Tray ID L2"] = item.TRAY_ID_2;
                rowEx1["Start Time"] = item.START_TIME;
                rowEx1["Plan Time"] = item.PLAN_TIME;
                rowEx1["Process Time"] = GetTimeSpan(item.START_TIME);
                rowEx1["Specs (MES)"] = "0000";

                dt.Rows.Add(rowEx1);
            }

            gridTrayInfo.DataSource(dt);
        }
        #endregion
        //#region GetCellIDList
        private void GetAgingTrayInfo(string eqpType, int level)
        {
            RESTClient rest = new RESTClient();
            //// Set Query
            StringBuilder strSQL = new StringBuilder();
            // Tray Information
            strSQL.Append(" SELECT line, lane, bay, floor, tray_id, rack_id, rack_id_2, start_time, plan_time");
            strSQL.Append(" FROM fms_v.tb_mst_aging");
            //필수값
            strSQL.Append($" WHERE aging_type = '{eqpType.Substring(0, 1)}'");
            strSQL.Append($"    AND lane = {level * 2 - 1}");
            strSQL.Append($"    OR aging_type = '{eqpType.Substring(0, 1)}'");
            strSQL.Append($"    AND lane = {level * 2}");

            var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

            if (jsonResult != null)
            {
                _jsonWinLeadTimeResponse result = rest.ConvertWinLeadTime(jsonResult.Result);

                SetData(result.DATA);
            }
        }
        //#endregion

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                //while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    RESTClient rest = new RESTClient();
                    //// Set Query
                    StringBuilder strSQL = new StringBuilder();
                    // Tray Information
                    strSQL.Append(" SELECT line, lane, bay, floor, tray_id, tray_id_2, rack_id, start_time, plan_time");
                    strSQL.Append(" FROM fms_v.tb_mst_aging");
                    //필수값
                    strSQL.Append($" WHERE aging_type = '{_EqpType.Substring(0, 1)}'");
                    strSQL.Append($"    AND lane = {_Eqplevel * 2 - 1}");
                    strSQL.Append($"    OR aging_type = '{_EqpType.Substring(0, 1)}'");
                    strSQL.Append($"    AND lane = {_Eqplevel * 2}");

                    var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                    if (jsonResult != null)
                    {
                        _jsonWinLeadTimeResponse result = rest.ConvertWinLeadTime(jsonResult.Result);

                        this.BeginInvoke(new Action(() => SetData(result.DATA)));

                        _AgingTrayInfo = result.DATA;
                    }

                    //Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WinLeadTime ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        private string GetTimeSpan(DateTime StartDate)
        {
            DateTime CurrentTime = DateTime.Now;
            TimeSpan dateDiff = CurrentTime - StartDate;

            int diffDay = dateDiff.Days;
            int diffHour = dateDiff.Hours;
            int diffMinute = dateDiff.Minutes;
            int diffSecond = dateDiff.Seconds;

            string timeSpan = string.Format("{0:D2}day {1:D2}:{2:D2}:{3:D2}", diffDay, diffHour, diffMinute, diffSecond);
            return timeSpan;
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
        private void GridTrayInfo_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 2 && row > -1 || col == 3 && row > -1)
            {
                //WinTrayInfo form = new WinTrayInfo();
                //form.SetData(value.ToString());
                //form.ShowDialog();
                _win_lead_time data = _AgingTrayInfo[row];
                WinTrayInfo form = new WinTrayInfo(_EqpId, data.RACK_ID, value.ToString());
                form.ShowDialog();
            }
        }
        #endregion

        #region Button Click
        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        
    }
}
