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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinTrayInfo : Form
    {
        private Point point = new Point();
        private string _EqpID = string.Empty;
        private string _RackID = string.Empty;
        private string _TrayId = string.Empty;

        private List<_tray_process_flow> _TrayProcessInfo;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinTrayInfo(string eqpid, string rackid, string trayId)
        {
            InitializeComponent();

            _EqpID = eqpid;
            _RackID = rackid;
            _TrayId = trayId;

            InitGridViewTray();
            InitGridViewProcessFlow(1);
        }

        #region WinManageEqp Event
        private void WinTrayInfo_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridProcessFlow.MouseCellClick_Evnet += GridProcessFlow_MouseCellClick;
            #endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));
        }
        private void WinTrayInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
        }
        #endregion

        #region InitGridView
        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Model");
            lstTitle.Add("Tray ID");
            lstTitle.Add("Binding Time");
            lstTitle.Add("Tray Type");
            lstTitle.Add("Route");
            lstTitle.Add("Lot ID");
            lstTitle.Add("Current Process");
            lstTitle.Add("Current Equipment");
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Cell Count");
            

            gridTrayInfo.AddRowsHeaderList(lstTitle);

            //TrayInfoView.ColumnHeadersHeight(30);
            gridTrayInfo.RowsHeight(30);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Tray Information");
            //TrayInfoView.ColumnMergeList(lstColumn, lstTitle);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 140);
        }
        private void InitGridViewProcessFlow(int rowCount)
        {
            string[] columnName = { "No", "Process Name", "Equipment Name",
                                    "Start Time", "End Time", "Cell Count", "Recipe" };
            List<string> lstTitle = new List<string>();
            lstTitle = columnName.ToList();
            gridProcessFlow.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            for (int i = 0; i < rowCount; i++)
            {
                lstTitle.Add("");
            }

            gridProcessFlow.AddRowsHeaderList(lstTitle);

            gridProcessFlow.ColumnHeadersHeight(24);
            gridProcessFlow.RowsHeight(24);

            gridProcessFlow.SetGridViewStyles();
            gridProcessFlow.ColumnHeadersWidth(0, 50);
            gridProcessFlow.ColumnHeadersWidth(columnName.Length - 2, 120);
        }
        #endregion

        #region SetData
        public void SetData(List<_win_tray_info> data)
        {
            if (data.Count == 0) return;

            int row = 0;
            gridTrayInfo.SetValue(1, row, data[0].MODEL_ID); row++;
            gridTrayInfo.SetValue(1, row, data[0].TRAY_ID); row++;
            gridTrayInfo.SetValue(1, row, data[0].TRAY_INPUT_TIME); row++;
            gridTrayInfo.SetValue(1, row, data[0].TRAY_ZONE);
            gridTrayInfo.SetValue(1, row, data[0].ROUTE_ID); row++;
            gridTrayInfo.SetValue(1, row, data[0].LOT_ID); row++;
            gridTrayInfo.SetValue(1, row, data[0].PROCESS_NAME); row++;
            gridTrayInfo.SetValue(1, row, data[0].EQP_NAME); row++;
            gridTrayInfo.SetValue(1, row, data[0].START_TIME); row++;
            gridTrayInfo.SetValue(1, row, data[0].PLAN_TIME); row++;
            gridTrayInfo.SetValue(1, row, data[0].CURRENT_CELL_CNT); row++;
            
        }

        public void SetData(List<_tray_process_flow> data)
        {
            if (data.Count == 0) return;

            InitGridViewProcessFlow(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                int col = 0;
                gridProcessFlow.SetValue(col, i, i + 1); col++;
                gridProcessFlow.SetValue(col, i, data[i].PROCESS_NAME); col++;
                gridProcessFlow.SetValue(col, i, data[i].EQP_NAME); col++;
                gridProcessFlow.SetValue(col, i, data[i].START_TIME); col++;
                gridProcessFlow.SetValue(col, i, data[i].END_TIME); col++;
                gridProcessFlow.SetValue(col, i, data[i].CURRENT_CELL_CNT); col++;
                gridProcessFlow.SetStyleButton(col, i, data[i].RECIPE_ID);
            }
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

                    RESTClient rest = new RESTClient();
                    // Set Query
                    StringBuilder strSQL = new StringBuilder();
                    // Tray Information
                    if (_RackID == "")
                    {
                        strSQL.Append(" SELECT A.eqp_name,");
                        strSQL.Append("        B.model_id, B.tray_id, B.tray_input_time, B.route_id, B.lot_id, B.start_time, B.plan_time, B.current_cell_cnt, B.tray_zone,");
                        strSQL.Append("        C.process_name");
                        strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                        strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   B");
                        strSQL.Append("         ON B.tray_id IN (A.tray_id, A.tray_id_2)");
                        strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_route_order   C");
                        strSQL.Append("         ON B.route_order_no = C.route_order_no AND B.route_id = C.route_id");
                        //필수값
                        strSQL.Append($" WHERE B.eqp_id = '{_EqpID}' AND B.tray_id = '{_TrayId}'");
                    }
                    else
                    {
                        strSQL.Append(" SELECT A.rack_id,");
                        strSQL.Append("        B.model_id, B.tray_id, B.tray_input_time, B.route_id, B.lot_id, B.start_time, B.plan_time, B.current_cell_cnt, B.tray_zone,");
                        strSQL.Append("        C.process_name,");
                        strSQL.Append("        D.eqp_name");
                        strSQL.Append(" FROM fms_v.tb_mst_aging   A");
                        strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   B");
                        strSQL.Append("         ON B.tray_id IN (A.tray_id, A.tray_id_2)");
                        strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_route_order   C");
                        strSQL.Append("         ON B.route_order_no = C.route_order_no AND B.route_id = C.route_id");
                        strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_eqp   D");
                        strSQL.Append("         ON B.eqp_id = D.eqp_id");
                        //필수값
                        strSQL.Append($" WHERE B.unit_id = '{_RackID}' AND B.tray_id = '{_TrayId}' AND D.eqp_id = '{_EqpID}'");
                    }

                    string jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                    if (jsonResult != null)
                    {
                        _jsonWinTrayInfoResponse result = rest.ConvertWinTrayInfo(jsonResult);

                        this.BeginInvoke(new Action(() => SetData(result.DATA)));
                    }

                    Thread.Sleep(100);

                    strSQL = new StringBuilder();
                    // Process Flow
                    strSQL.Append(" SELECT A.start_time, A.end_time, A.current_cell_cnt, A.recipe_id, A.json_recipe,");
                    strSQL.Append("        B.process_name,");
                    strSQL.Append("        C.eqp_name");
                    strSQL.Append(" FROM fms_v.tb_dat_tray_proc     A");
                    strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_route_order    B");
                    strSQL.Append("         ON A.route_id = B.route_id");
                    strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_eqp    C");
                    strSQL.Append("         ON A.eqp_type = C.eqp_type AND A.unit_id = C.unit_id");
                    //필수값
                    _TrayId = "TEST00001";
                    strSQL.Append($" WHERE A.tray_id = '{_TrayId}'");
                    strSQL.Append("    AND A.model_id = B.model_id");
                    strSQL.Append("    AND A.process_type = B.process_type");
                    strSQL.Append("    AND A.process_no = B.process_no");
                    strSQL.Append("  ORDER BY A.start_time");

                    jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                    if (jsonResult != null)
                    {
                        _jsonTrayProcessFlowResponse result = rest.ConvertTrayPorcessFlow(jsonResult);

                        this.BeginInvoke(new Action(() => SetData(result.DATA)));

                        _TrayProcessInfo = result.DATA;
                    }

                    //Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
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
        private void GridProcessFlow_MouseCellClick(int col, int row, object value)
        {
            if (col == gridProcessFlow.ColumnCount -1 && row > -1)
            {
                WinRecipeInfo form = new WinRecipeInfo();
                form.SetData(_TrayProcessInfo[row], value.ToString());
                form.ShowDialog();

            }
        }
        #endregion

        #region Button Event
        private void CellInfo_Click(object sender, EventArgs e)
        {
            WinCellDetailInfo form = new WinCellDetailInfo(_TrayId);
            form.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
