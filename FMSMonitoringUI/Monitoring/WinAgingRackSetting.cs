using MonitoringUI.Common;
using MonitoringUI.Controlls;
using Novasoft.Logger;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinAgingRackSetting : Form
    {
        private Point point = new Point();
        private string _EQPID = string.Empty;
        private string _RackID = string.Empty;

        private Logger _Logger;

        Dictionary<string, KeyValuePair<string, Color>> _RackStatus;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinAgingRackSetting(string eqpid, string rackId, Dictionary<string, KeyValuePair<string, Color>> rackStatus)
        {
            InitializeComponent();

            _EQPID = eqpid;
            _RackID = rackId;

            _RackStatus = rackStatus;

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);

            InitGridViewEqp();
            InitGridViewTray();
        }

        #region WinAgingRackSetting Event
        private void WinAgingRackSetting_Load(object sender, EventArgs e)
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
        private void WinAgingRackSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
        }
        #endregion

        #region InitGridView
        private void InitGridViewEqp()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Rack Information");
            lstTitle.Add("");
            gridEqpInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Rack ID");
            lstTitle.Add("Rack Name");
            lstTitle.Add("Rack Status");
            lstTitle.Add("Use Flag");
            lstTitle.Add("Trouble Code");
            lstTitle.Add("Trouble Name");
            gridEqpInfo.AddRowsHeaderList(lstTitle);

            gridEqpInfo.ColumnHeadersHeight(31);
            gridEqpInfo.RowsHeight(31);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>();
            lstTitle.Add("Rack Information");
            gridEqpInfo.ColumnMergeList(lstColumn, lstTitle);

            gridEqpInfo.SetGridViewStyles();
            gridEqpInfo.ColumnHeadersWidth(0, 120);
        }

        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Tray Information");
            lstTitle.Add("");
            lstTitle.Add("");
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Tray ID");
            lstTitle.Add("Level");
            lstTitle.Add("Binding Time");           // tray_input_time      
            lstTitle.Add("Tray Type");
            lstTitle.Add("Model");
            lstTitle.Add("Route");
            lstTitle.Add("Recipe ID");
            lstTitle.Add("Cerrent Process");
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            gridTrayInfo.AddRowsHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersHeight(31);
            gridTrayInfo.RowsHeight(31);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>();
            lstTitle.Add("Tray Information");
            gridTrayInfo.ColumnMergeList(lstColumn, lstTitle, 0, 3);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 120);
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
                        LoadAgingRackSetting(_RackID).GetAwaiter().GetResult();
                    }));

                    //Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WinAgingRackSetting ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region LoadAgingRackSetting
        private async Task LoadAgingRackSetting(string rackid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT A.aging_type, A.rack_id, A.line, A.lane, A.bay, A.floor, A.status, A.use_flag, A.process_no,");
                strSQL.Append("        C.tray_id, IF(A.tray_id = C.tray_id, '1', '2') AS level,");
                strSQL.Append("        B.trouble_name,");
                strSQL.Append("        C.tray_zone, C.model_id, C.route_id, C.recipe_id, C.start_time, C.plan_time,");
                strSQL.Append("        D.process_name");
                strSQL.Append(" FROM fms_v.tb_mst_aging   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_trouble    B");
                strSQL.Append("         ON A.trouble_code = B.trouble_code AND A.in_eqp_type = B.eqp_type");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   C");
                strSQL.Append("         ON C.tray_id IN (A.tray_id, A.tray_id_2)");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_route_order    D");
                strSQL.Append("         ON A.route_order_no = D.route_order_no AND C.route_id = D.route_id");
                //필수값
                strSQL.Append($" WHERE A.rack_id = '{rackid}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonWinAgingRackSettingResponse result = rest.ConvertWinAgingRackSetting(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "WinAgingRackSetting : jsonResult is null";
                        _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                    }
                }
                else
                {
                    string log = "WinAgingRackSetting : jsonResult is null";
                    _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadAgingRackSetting] {0}", ex.ToString()));
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_win_aging_rack> data)
        {
            if (data == null && data.Count == 0) return;

            int row = 0;
            gridEqpInfo.SetValue(1, row, data[0].RACK_ID); row++;
            string rackName = string.Format($"{data[0].AGING_TYPE}T-{data[0].LINE}Line-{data[0].LANE}Lane-{data[0].BAY}Bay-{data[0].FLOOR}F");
            gridEqpInfo.SetValue(1, row, rackName); row++;

            string rackStatus = string.Empty;
            switch (data[0].STATUS)
            {
                case "F":
                    if (data[0].PROCESS_NO > 0)
                    {
                        rackStatus = _RackStatus[data[0].PROCESS_NO + "A"].Key;
                    }
                    else
                    {
                        rackStatus = _RackStatus[data[0].STATUS].Key;
                    }
                    break;

                default:
                    rackStatus = _RackStatus[data[0].STATUS].Key;
                    break;
            }

            gridEqpInfo.SetValue(1, row, rackStatus); row++;
            gridEqpInfo.SetValue(1, row, data[0].USE_FLAG == "Y" ? "Use" : "Not Use"); row++;
            gridEqpInfo.SetValue(1, row, data[0].TROUBLE_CODE); row++;
            gridEqpInfo.SetValue(1, row, data[0].TROUBLE_NAME);

            if (data[0].STATUS == "E") return;

            for (int i = 0; i < data.Count; i++)
            {
                row = 0;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].LEVEL); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_INPUT_TIME); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_ZONE); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].MODEL_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].ROUTE_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].RECIPE_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].PROCESS_NAME); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].START_TIME.Year == 1 ? "" : data[i].START_TIME.ToString()); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].PLAN_TIME.Year == 1 ? "" : data[i].PLAN_TIME.ToString());
            }
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
        private void GridTrayInfo_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col > 0 && row == 0)
            {
                WinTrayInfo form = new WinTrayInfo(_EQPID, _RackID, value.ToString());
                form.ShowDialog();
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
