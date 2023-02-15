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
    public partial class WinTroubleInfo : WinFormRoot
    {
        private Point point = new Point();
        private string _EqpName = string.Empty;
        private string _EqpType = string.Empty;
        private string _EqpID = string.Empty;
        private string _UnitID = string.Empty;
        private int _AgingIdx = 0;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinTroubleInfo(string eqpName, string eqpType, string eqpID, string unitID, int agingIdx=0)
        {
            InitializeComponent();

            _EqpName = eqpName;
            _EqpType = eqpType;
            _EqpID = eqpID;
            _UnitID = unitID;
            _AgingIdx = agingIdx;

            InitControl(_EqpID, _EqpName);
            InitGridViewTray();
            InitLanguage();
            //InitChart();
        }

        #region WinTroubleInfo Event
        private void WinTroubleInfo_Load(object sender, EventArgs e)
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

            //#region DataGridView Event
            //gridTrayInfo.MouseCellDoubleClick_Evnet += GridTrayInfo_MouseCellDoubleClick;
            //#endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }
        private void WinTroubleInfo_FormClosed(object sender, FormClosedEventArgs e)
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
        private void InitControl(string eqpID, string eqpName)
        {
            Exit.Left = (this.panel2.Width - Exit.Width) / 2;             
            Exit.Top = (this.panel2.Height - Exit.Height) / 2;

            dtSearchPriod.InitControl(dtSearchPriod.Height);

            dtSearchPriod.StartDate = DateTime.Now.AddDays(-5);
            dtSearchPriod.EndDate = DateTime.Now.AddDays(1);

            //if (eqpID == "")
            //{
            //    string titleName = $"{_UnitID.Substring(3, 2)}Line-{_UnitID.Substring(5, 1)}Lane-{_UnitID.Substring(6, 2)}Bay-{_UnitID.Substring(8, 2)}F";
            //    lbRackID.TextData = titleName;
            //    lbRackID.LanguageID = "DEF_Rack_ID";
            //}
            //else
            {
                lbRackID.TextData = eqpName;
                lbRackID.LanguageID = "DEF_Equipment_Name";
            }
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            titBar.CallLocalLanguage();
            lbRackID.CallLocalLanguage();
            Search.CallLocalLanguage();
            dtSearchPriod.CallLocalLanguage();
            Exit.CallLocalLanguage();
        }
        #endregion

        #region InitGridViewTray
        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Equipment_Name"),
                LocalLanguage.GetItemString("DEF_Unit_ID"),
                LocalLanguage.GetItemString("DEF_Trouble_Category"),
                LocalLanguage.GetItemString("DEF_Trouble_Code"),
                LocalLanguage.GetItemString("DEF_Trouble_Name"),
                LocalLanguage.GetItemString("DEF_Event_Time")
            };
            gridTrayInfo.AddColumnHeaderList(lstTitle, true);

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
            gridTrayInfo.ColumnHeadersWidth(0, 120);
            gridTrayInfo.ColumnHeadersWidth(1, 120);
            gridTrayInfo.ColumnHeadersWidth(2, 120);
            gridTrayInfo.ColumnHeadersWidth(3, 120);
            gridTrayInfo.ColumnHeadersWidth(5, 220);
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
                        LoadTroubleInfo(_EqpType, _EqpID, _UnitID).GetAwaiter().GetResult();
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

        #region LoadTroubleInfo
        private async Task LoadTroubleInfo(string eqpType, string eqpID, string unitID)
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();
                // Tray Information
                strSQL.Append(" SELECT A.*,");
                strSQL.Append("        B.trouble_name, B.trouble_name_local");
                strSQL.Append(" FROM fms_v.tb_dat_trouble   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_trouble    B");
                strSQL.Append("           ON A.trouble_code = B.trouble_code AND A.eqp_type = B.eqp_type");
                //필수값
                strSQL.Append($" WHERE A.eqp_type = '{eqpType}'");

                if (_AgingIdx > 0 && (eqpType == "HTA") || (eqpType == "LTA1") || (eqpType == "LTA2"))
                {
                    string lane = (eqpType == "LTA2" ? "02" : "01");

                    strSQL.Append($"    AND (A.unit_id LIKE '{eqpType.Substring(0, 1)}{lane}{_AgingIdx * 2 - 1}%'");
                    strSQL.Append($"      OR A.unit_id LIKE '{eqpType.Substring(0, 1)}{lane}{_AgingIdx * 2}%')");
                }
                else
                {
                    if (eqpID == "")
                        strSQL.Append($"    AND A.unit_id = '{unitID}'");
                    else
                        strSQL.Append($"    AND A.eqp_id = '{eqpID}'");
                }   

                //strSQL.Append($"    AND A.event_time     BETWEEN concat({ ctrlDateTimeDT2DT1.StartDate:yyyyMMdd}, {ctrlDateTimeDT2DT1.StartDate:HHmmss})");
                //strSQL.Append($"    AND concat({ ctrlDateTimeDT2DT1.EndDate:yyyyMMdd}, {ctrlDateTimeDT2DT1.EndDate:HHmmss})");
                strSQL.Append($"    AND A.event_time     BETWEEN '{dtSearchPriod.StartDate:yyyyMMddHHmmss}'");
                strSQL.Append($"    AND '{dtSearchPriod.EndDate:yyyyMMddHHmmss}'");
                strSQL.Append("  ORDER BY A.event_time DESC");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonWinTroubleInfoResponse result = rest.ConvertTroubleInfo(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertTroubleInfo : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertTroubleInfo : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadTroubleInfo Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadTroubleInfo Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region SetData
        private void SetData(List<_trouble_info> data)
        {
            if (data == null || data.Count == 0) return;

            gridTrayInfo.RowCount = data.Count;
            int row = 0;

            foreach (var item in data)
            {
                int col = 0;

                if (_EqpName == "Charge/Discharge")
                {
                    string unitName = $"{item.UNIT_ID.Substring(5, 1)}Lane-{item.UNIT_ID.Substring(6, 2)}Bay-{item.UNIT_ID.Substring(8, 2)}F";
                    gridTrayInfo.SetValue(col, row, unitName); col++;
                }
                else
                {
                    gridTrayInfo.SetValue(col, row, _EqpName); col++;
                }

                gridTrayInfo.SetValue(col, row, item.UNIT_ID); col++;
                gridTrayInfo.SetValue(col, row, item.TROUBLE_CATEGORY); col++;
                gridTrayInfo.SetValue(col, row, item.TROUBLE_CODE); col++;
                string troubleName = (CDefine.m_enLanguage == enLoginLanguage.English ? item.TROUBLE_NAME : item.TROUBLE_NAME_LOCAL);
                gridTrayInfo.SetValue(col, row, troubleName); col++;
                gridTrayInfo.SetValue(col, row, item.EVENT_TIME.Year == 1 ? "" : item.EVENT_TIME.ToString());
                row++;
            }

            gridTrayInfo.SetGridViewStyles();
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
        //private void GridTrayInfo_MouseCellDoubleClick(int col, int row, object value)
        //{
        //    if (col == 2 && row > -1 || col == 3 && row > -1)
        //    {
        //        WinTrayInfo form;

        //        if (_Eqplevel > 0)
        //        {
        //            _win_lead_time data = _AgingTrayInfo[row];
        //            form = new WinTrayInfo(_EqpId, data.RACK_ID, value.ToString());
        //        }
        //        else
        //        {
        //            //_lead_time_chg data = _ChargerTrayInfo[row];
        //            form = new WinTrayInfo(_EqpId, "", value.ToString());
        //        }
                
        //        form.ShowDialog();
        //    }
        //}
        #endregion

        #region Button Click
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            string log = $"Search : Unit ID = {_UnitID}, Start Period = {dtSearchPriod.StartDate} ~ End Period = {dtSearchPriod.EndDate}";
            CLogger.WriteLog(enLogLevel.Search, this.WindowID, log);

            LoadTroubleInfo(_EqpType, _EqpID, _UnitID).GetAwaiter().GetResult();
        }
        #endregion
    }
}
