using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinLeadTime : WinFormRoot
    {
        private Point point = new Point();
        private string _EqpId = string.Empty;
        private string _EqpType = string.Empty;
        private int _Eqplevel = 0;

        private List<_win_lead_time> _AgingTrayInfo = new List<_win_lead_time>();
        private List<_lead_time_chg> _ChargerTrayInfo = new List<_lead_time_chg>();

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

            InitControl();
            InitGridViewTray();
            InitLanguage();

            //InitChart();
        }

        #region WinLeadTime Event
        private void WinLeadTime_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Text) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
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

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
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

        #region InitGridViewTray
        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Location"),
                LocalLanguage.GetItemString("DEF_Rack_ID"),
                LocalLanguage.GetItemString("DEF_Tray_ID_1"),
                LocalLanguage.GetItemString("DEF_Tray_ID_2"),
                LocalLanguage.GetItemString("DEF_Start_Time"),
                LocalLanguage.GetItemString("DEF_Plan_Time"),
                LocalLanguage.GetItemString("DEF_Process_Time"),
                LocalLanguage.GetItemString("DEF_Specs_(MES)")
            };
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
        #endregion

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                //while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (_Eqplevel > 0)
                        {
                            LoadLeadTime(_EqpType, _Eqplevel).GetAwaiter().GetResult();
                        }
                        else
                        {
                            LoadLeadTimeCHG(_EqpType).GetAwaiter().GetResult();
                        }
                    }));

                    //Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region LoadLeadTime
        private async Task LoadLeadTime(string eqptype, int eqplevel)
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();
                // Tray Information
                strSQL.Append(" SELECT line, lane, bay, floor, tray_id, tray_id_2, rack_id, start_time, plan_time, aging_time");
                strSQL.Append(" FROM fms_v.tb_mst_aging");
                //필수값
                strSQL.Append($" WHERE aging_type = '{eqptype.Substring(0, 1)}'");
                strSQL.Append($"    AND lane = {eqplevel * 2 - 1}");
                strSQL.Append($"    OR aging_type = '{eqptype.Substring(0, 1)}'");
                strSQL.Append($"    AND lane = {eqplevel * 2}");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonWinLeadTimeResponse result = rest.ConvertWinLeadTime(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertWinLeadTime : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }

                    _AgingTrayInfo = result.DATA;
                }
                else
                {
                    string log = "ConvertWinLeadTime : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadLeadTime Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadLeadTime Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region LoadLeadTimeCHG
        private async Task LoadLeadTimeCHG(string eqptype)
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();
                // Tray Information
                strSQL.Append(" SELECT eqp_name, tray_id, tray_id_2, unit_id, start_time, plan_time");
                strSQL.Append(" FROM fms_v.tb_mst_eqp");
                //필수값
                strSQL.Append($" WHERE eqp_type = '{eqptype}'");
                strSQL.Append($"     AND (eqp_type = '{eqptype}' AND unit_id IS NOT NULL)");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonLeadTimeCHGResponse result = rest.ConvertLeadTimeCHG(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertLeadTimeCHG : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }

                    _ChargerTrayInfo = result.DATA;
                }
                else
                {
                    string log = "ConvertLeadTimeCHG : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadLeadTimeCHG Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadLeadTimeCHG Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region SetData
        private void SetData(List<_win_lead_time> data)
        {
            if (data == null || data.Count == 0) return;

            gridTrayInfo.RowCount = data.Count;
            int row = 0;

            foreach (var item in data)
            {
                int col = 0;
                string location = string.Format($"{item.LINE}Line-{item.LANE}Lane-{item.BAY}Bay-{item.FLOOR}F");
                gridTrayInfo.SetValue(col, row, location); col++;
                gridTrayInfo.SetValue(col, row, item.RACK_ID); col++;
                gridTrayInfo.SetValue(col, row, item.TRAY_ID); col++;
                gridTrayInfo.SetValue(col, row, item.TRAY_ID_2); col++;
                gridTrayInfo.SetValue(col, row, item.START_TIME.Year == 1 ? "" : item.START_TIME.ToString()); col++;
                gridTrayInfo.SetValue(col, row, item.PLAN_TIME.Year == 1 ? "" : item.PLAN_TIME.ToString()); col++;
                gridTrayInfo.SetValue(col, row, GetTimeSpan(item.START_TIME)); col++;
                gridTrayInfo.SetValue(col, row, string.Format($"{item.AGING_TIME} (min)"));
                row++;
            }

            gridTrayInfo.SetGridViewStyles();
        }
        private void SetData(List<_lead_time_chg> data)
        {
            if (data == null || data.Count == 0) return;

            gridTrayInfo.RowCount = data.Count;
            int row = 0;

            foreach (var item in data)
            {
                int col = 0;
                gridTrayInfo.SetValue(col, row, item.EQP_NAME); col++;
                gridTrayInfo.SetValue(col, row, item.UNIT_ID); col++;
                gridTrayInfo.SetValue(col, row, item.TRAY_ID); col++;
                gridTrayInfo.SetValue(col, row, item.TRAY_ID_2); col++;
                gridTrayInfo.SetValue(col, row, item.START_TIME.Year == 1 ? "" : item.START_TIME.ToString()); col++;
                gridTrayInfo.SetValue(col, row, item.PLAN_TIME.Year == 1 ? "" : item.PLAN_TIME.ToString()); col++;
                gridTrayInfo.SetValue(col, row, GetTimeSpan(item.START_TIME)); col++;
                gridTrayInfo.SetValue(col, row, string.Format($"0 (min)"));
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
                WinTrayInfo form;

                if (_Eqplevel > 0)
                {
                    _win_lead_time data = _AgingTrayInfo[row];
                    form = new WinTrayInfo(_EqpId, data.RACK_ID, value.ToString());

                    CLogger.WriteLog(enLogLevel.ButtonClick, this.WindowID, $"WinTrayInfo : Eqp ID = {_EqpId}, Unit ID = {data.RACK_ID}, Tray ID = {value}");
                }
                else
                {
                    //_lead_time_chg data = _ChargerTrayInfo[row];
                    form = new WinTrayInfo(_EqpId, "", value.ToString());

                    CLogger.WriteLog(enLogLevel.ButtonClick, this.WindowID, $"WinTrayInfo : Eqp ID = {_EqpId}, Tray ID = {value}");
                }
                
                form.ShowDialog();
            }
        }
        #endregion

        #region Button Click
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        
    }
}
