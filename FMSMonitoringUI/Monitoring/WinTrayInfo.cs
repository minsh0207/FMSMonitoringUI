using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinTrayInfo : WinFormRoot
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

            InitControl();
            InitGridViewTray();
            InitGridViewProcessFlow(1);
            InitLanguage();
        }

        #region WinManageEqp Event
        private void WinTrayInfo_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Name) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
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

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }
        private void WinTrayInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
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

            foreach (var ctl in splitContainer1.Panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel tagName = ctl as CtrlLabel;
                    tagName.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlButton))
                {
                    CtrlButton tagName = ctl as CtrlButton;
                    tagName.CallLocalLanguage();
                }
            }

            foreach (var ctl in splitContainer1.Panel2.Controls)
            {
                if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel tagName = ctl as CtrlLabel;
                    tagName.CallLocalLanguage();
                }
            }

            Exit.CallLocalLanguage();
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

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Model_ID"),
                LocalLanguage.GetItemString("DEF_Tray_ID"),
                LocalLanguage.GetItemString("DEF_Binding_Time"),
                LocalLanguage.GetItemString("DEF_Tray_Type"),
                LocalLanguage.GetItemString("DEF_Route_ID"),
                LocalLanguage.GetItemString("DEF_Lot_ID"),
                LocalLanguage.GetItemString("DEF_Current_Process"),
                LocalLanguage.GetItemString("DEF_Current_Equipment"),
                LocalLanguage.GetItemString("DEF_Start_Time"),
                LocalLanguage.GetItemString("DEF_Plan_Time"),
                LocalLanguage.GetItemString("DEF_Cell_Count")
            };

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
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_No"),
                LocalLanguage.GetItemString("DEF_Process_Name"),
                LocalLanguage.GetItemString("DEF_Equipment_Name"),
                LocalLanguage.GetItemString("DEF_Start_Time"),
                LocalLanguage.GetItemString("DEF_End_Time"),
                LocalLanguage.GetItemString("DEF_Cell_Count"),
                LocalLanguage.GetItemString("DEF_Recipe_ID")
            };

            gridProcessFlow.AddColumnHeaderList(lstTitle);
            int nColCount = lstTitle.Count;

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
            gridProcessFlow.ColumnHeadersWidth(nColCount - 2, 120);
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
                        LoadTrayData(_EqpID, _RackID, _TrayId).GetAwaiter().GetResult();
                        LoadTrayPorcessFlow(_TrayId).GetAwaiter().GetResult();
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

        #region LoadTrayData
        private async Task LoadTrayData(string eqpid, string rackid, string trayid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();
                // Tray Information
                if (rackid == "")
                {
                    strSQL.Append(" SELECT A.eqp_name,");
                    strSQL.Append("        B.model_id, B.tray_id, B.tray_input_time, B.route_id, B.lot_id, B.start_time, B.plan_time, B.current_cell_cnt, B.tray_zone,");
                    strSQL.Append("        (SELECT sf_get_process_name(B.model_id, B.route_id, B.eqp_type, B.process_type, B.process_no)) AS process_name");
                    strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                    strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   B");
                    strSQL.Append("         ON B.tray_id IN (A.tray_id, A.tray_id_2)");
                    //필수값
                    strSQL.Append($" WHERE A.eqp_id = '{eqpid}' AND B.tray_id = '{trayid}'");
                }
                else
                {
                    strSQL.Append(" SELECT A.rack_id,");
                    strSQL.Append("        B.model_id, B.tray_id, B.tray_input_time, B.route_id, B.lot_id, B.start_time, B.plan_time, B.current_cell_cnt, B.tray_zone,");
                    strSQL.Append("        (SELECT sf_get_process_name(B.model_id, B.route_id, B.eqp_type, B.process_type, B.process_no)) AS process_name,");
                    strSQL.Append("        C.eqp_name");
                    strSQL.Append(" FROM fms_v.tb_mst_aging   A");
                    strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   B");
                    strSQL.Append("         ON B.tray_id IN (A.tray_id, A.tray_id_2)");
                    strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_eqp   C");
                    strSQL.Append("         ON B.eqp_id = C.eqp_id");
                    //필수값
                    strSQL.Append($" WHERE A.rack_id = '{rackid}' AND B.tray_id = '{trayid}' AND B.eqp_id = '{eqpid}'");
                }

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonWinTrayInfoResponse result = rest.ConvertWinTrayInfo(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertWinTrayInfo : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertWinTrayInfo : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadTrayData Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadTrayData Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region LoadTrayPorcessFlow
        private async Task LoadTrayPorcessFlow(string trayid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();
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
                strSQL.Append($" WHERE A.tray_id = '{trayid}'");
                strSQL.Append("    AND A.model_id = B.model_id");
                strSQL.Append("    AND A.process_type = B.process_type");
                strSQL.Append("    AND A.process_no = B.process_no");
                strSQL.Append("  ORDER BY A.start_time");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonTrayProcessFlowResponse result = rest.ConvertTrayPorcessFlow(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertTrayPorcessFlow : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                    _TrayProcessInfo = result.DATA;
                }
                else
                {
                    string log = "ConvertTrayPorcessFlow : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadTrayPorcessFlow Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadTrayPorcessFlow Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_win_tray_info> data)
        {
            if (data == null || data.Count == 0) return;

            int row = 0;
            gridTrayInfo.SetValue(1, row, data[0].MODEL_ID); row++;
            gridTrayInfo.SetValue(1, row, data[0].TRAY_ID); row++;
            string time = data[0].TRAY_INPUT_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridTrayInfo.SetValue(1, row, data[0].TRAY_INPUT_TIME.Year == 1 ? "" : time); row++;
            gridTrayInfo.SetValue(1, row, GetTrayType(data[0].TRAY_ZONE)); row++;
            gridTrayInfo.SetValue(1, row, data[0].ROUTE_ID); row++;
            gridTrayInfo.SetValue(1, row, data[0].LOT_ID); row++;
            gridTrayInfo.SetValue(1, row, data[0].PROCESS_NAME); row++;
            gridTrayInfo.SetValue(1, row, data[0].EQP_NAME); row++;
            time = data[0].START_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridTrayInfo.SetValue(1, row, data[0].START_TIME.Year == 1 ? "" : time); row++;
            time = data[0].PLAN_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridTrayInfo.SetValue(1, row, data[0].PLAN_TIME.Year == 1 ? "" : time); row++;
            gridTrayInfo.SetValue(1, row, data[0].CURRENT_CELL_CNT);

        }

        public void SetData(List<_tray_process_flow> data)
        {
            if (data == null || data.Count == 0) return;

            InitGridViewProcessFlow(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                int col = 0;
                gridProcessFlow.SetValue(col, i, i + 1); col++;
                gridProcessFlow.SetValue(col, i, data[i].PROCESS_NAME); col++;
                gridProcessFlow.SetValue(col, i, data[i].EQP_NAME); col++;
                string time = data[i].START_TIME.ToString("dd-MM-yyyy HH:mm:ss");
                gridProcessFlow.SetValue(col, i, data[i].START_TIME.Year == 1 ? "" : time); col++;
                time = data[i].END_TIME.ToString("dd-MM-yyyy HH:mm:ss");
                gridProcessFlow.SetValue(col, i, data[i].END_TIME.Year == 1 ? "" : time); col++;
                gridProcessFlow.SetValue(col, i, data[i].CURRENT_CELL_CNT); col++;
                gridProcessFlow.SetStyleButton(col, i, data[i].RECIPE_ID);
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
                CLogger.WriteLog(enLogLevel.ButtonClick, this.WindowID, $"Recipe ID : {value}");

                WinRecipeInfo form = new WinRecipeInfo(value.ToString());
                form.SetData(_TrayProcessInfo[row]);
                form.ShowDialog();

            }
        }
        #endregion

        #region Button Event
        private void CellInfo_Click(object sender, EventArgs e)
        {
            Point parentPoint = this.Location;

            WinCellDetailInfo form = new WinCellDetailInfo(_TrayId, "");
            form.StartPosition = FormStartPosition.Manual;  // 폼의 위치가 Location 의 속성에 의해서 결정
            form.Location = new Point(parentPoint.X, parentPoint.Y);
            form.ShowDialog();


            //Point parentPoint = this.Location;
            //Form2 frm2 = new Form2();
            //frm2.StartPosition = FormStartPosition.Manual;  // 폼의 위치가 Location 의 속성에 의해서 결정
            //frm2.Location = new Point(parentPoint.X + 100, parentPoint.Y + 100);
            //frm2.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region GetTrayType
        private string GetTrayType(string trayZone)
        {
            string ret = string.Empty;

            switch (trayZone)
            {
                case "BD":
                    ret = "BD\nBefore Degas Long Tray";
                    break;
                case "AD":
                    ret = "AD\nAfter Degas Short Tray";
                    break;
            }

            return ret;
        }
        #endregion
    }
}
