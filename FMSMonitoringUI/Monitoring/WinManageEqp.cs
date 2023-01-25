using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MonitoringUI.Popup;
using Novasoft.Logger;
using OPCUAClientClassLib;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinManageEqp : WinFormRoot
    {
        private Point point = new Point();
        private string _EqpID = string.Empty;
        private string _UnitID = string.Empty;
        private string _EqpType = string.Empty;
        private int _TrayCnt = 0;

        private Logger _Logger;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable = false;
        #endregion

        public WinManageEqp(string eqpid, string unitid, string eqpType, int traycnt)
        {
            InitializeComponent();

            _EqpID = eqpid;
            _UnitID = unitid;
            _EqpType = eqpType;
            _TrayCnt = traycnt;

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);
        }

        #region WinManageEqp Event
        private void WinManageEqp_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Text) == false)
            {
                Exit_Click(null, null);
                return;
            }

            InitGridViewEqp();
            InitGridViewTray();

            InitControl();

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            _TheadVisiable = true;

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

            this.WindowID = CAuthority.GetWindowsText(this.Text);
        }
        private void WinManageEqp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (_TheadVisiable)
                this._ProcessThread.Abort();

            _Logger = null;
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            int btnPos = (this.Width - CDefine.DEF_EXIT_WIDTH) / 2;   // Button Width Size 170            
            this.Exit.Padding = new System.Windows.Forms.Padding(btnPos, 10, btnPos, 10);
        }
        #endregion

        #region InitGridView
        private void InitGridViewEqp()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Equipment Information");
            lstTitle.Add("");
            gridEqpInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Equipment ID");
            lstTitle.Add("Equipment Name");
            lstTitle.Add("Control Mode");       // Eqp Mode
            lstTitle.Add("Status");
            lstTitle.Add("Operation Mode");       // Operation Mode
            lstTitle.Add("Trouble Code");
            lstTitle.Add("Trouble Name");
            gridEqpInfo.AddRowsHeaderList(lstTitle);

            gridEqpInfo.ColumnHeadersHeight(30);
            gridEqpInfo.RowsHeight(30);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);          // DataGridView Header 병합
            //lstColumn.Add(6);         // DataGridView 6번째 Column 병합
            lstTitle = new List<string>();
            lstTitle.Add("Equipment Information");
            //lstTitle.Add("Tray Information");
            gridEqpInfo.ColumnMergeList(lstColumn, lstTitle);

            gridEqpInfo.SetGridViewStyles();
            gridEqpInfo.ColumnHeadersWidth(0, 140);
        }
        private void InitGridViewTray()
        {
            if (_TrayCnt > 1) this.Size = new System.Drawing.Size(1100, 531);
            else this.Size = new System.Drawing.Size(960, 531);

            List<string> lstTitle = new List<string>();
            lstTitle.Add("Tray Information");
            lstTitle.Add("");
            if (_TrayCnt > 1) lstTitle.Add("");

            gridTrayInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Tray ID");
            lstTitle.Add("Level");
            lstTitle.Add("Binding Time");           // tray_input_time      
            lstTitle.Add("Tray Type");              // tray_zone
            lstTitle.Add("Model");
            lstTitle.Add("Route");
            lstTitle.Add("Lot ID");
            lstTitle.Add("Current Process");        // Porcess_Name
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Cell Count");
            gridTrayInfo.AddRowsHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersHeight(30);
            gridTrayInfo.RowsHeight(30);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>();
            lstTitle.Add("Tray Information");
            gridTrayInfo.ColumnMergeList(lstColumn, lstTitle, 0, _TrayCnt+1);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 140);

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
                        LoadWinManageEqp(_EqpID, _EqpType, _UnitID).GetAwaiter().GetResult();
                    }));

                    //Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WInManageEqp ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region LoadEntireEqpList
        private async Task LoadWinManageEqp(string eqpid, string eqptype, string unitid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT A.eqp_id, A.eqp_name, A.eqp_mode, A.operation_mode, A.eqp_status, A.eqp_trouble_code,C.tray_id, IF(A.tray_id = C.tray_id, '1', '2') AS level,");
                strSQL.Append("        B.trouble_code, B.trouble_name,");
                strSQL.Append("        C.tray_input_time, C.tray_zone, C.model_id, C.route_id, C.lot_id, C.start_time, C.plan_time, C.current_cell_cnt,");
                strSQL.Append("        D.process_name");
                strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_trouble    B");
                strSQL.Append("         ON A.eqp_trouble_code = B.trouble_code AND A.eqp_type = B.eqp_type");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   C");
                strSQL.Append("         ON C.tray_id IN (A.tray_id, A.tray_id_2)");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_route_order    D");
                strSQL.Append("         ON A.route_order_no = D.route_order_no AND C.route_id = D.route_id");
                //필수값
                if (eqptype == "HPC")
                {
                    strSQL.Append($" WHERE A.unit_id = '{unitid}'");
                    strSQL.Append($"    AND (A.eqp_type = '{eqptype}' AND A.unit_id IS NOT NULL)");
                }
                else
                {
                    strSQL.Append($" WHERE A.eqp_id = '{eqpid}'");
                }

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonWinManageEqpResponse result = rest.ConvertWinManageEqp(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "WinManageEqp : jsonResult is null";
                        _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                    }
                }
                else
                {
                    string log = "WinManageEqp : jsonResult is null";
                    _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadWinManageEqp] {0}", ex.ToString()));
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_win_manage_eqp> data)
        {
            if (data.Count == 0) return;

            int row = 0;
            gridEqpInfo.SetValue(1, row, data[0].EQP_ID); row++;
            gridEqpInfo.SetValue(1, row, data[0].EQP_NAME); row++;

            gridEqpInfo.SetValue(1, row, GetEqpStatus(data[0].EQP_MODE)); row++;
            gridEqpInfo.SetValue(1, row, GetEqpStatus(data[0].EQP_STATUS)); row++;

            if (data[0].OPERATION_MODE == 0) gridEqpInfo.RowsVisible(row, false);
            else gridEqpInfo.RowsVisible(row, true);
            gridEqpInfo.SetValue(1, row, GetOperationMode(data[0].OPERATION_MODE)); row++;

            gridEqpInfo.SetValue(1, row, data[0].TROUBLE_CODE); row++;
            gridEqpInfo.SetValue(1, row, data[0].TROUBLE_NAME);

            for (int i = 0; i < data.Count; i++)
            {
                row = 0;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_ID == null ? "" : data[i].LEVEL); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_INPUT_TIME.Year == 1 ? "" : data[i].TRAY_INPUT_TIME.ToString()); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_ZONE); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].MODEL_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].ROUTE_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].LOT_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].PROCESS_NAME); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].START_TIME.Year == 1 ? "" : data[i].START_TIME.ToString()); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].PLAN_TIME.Year == 1 ? "" : data[i].PLAN_TIME.ToString()); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].CURRENT_CELL_CNT);
            }
        }
        #endregion

        #region GetOperationMode 
        private string GetOperationMode(int mode)
        {
            string opModeName = string.Empty;

            if (_EqpType == "CHG")
            {
                switch (mode)
                {
                    case 1:
                        opModeName = "OCV";
                        break;
                    case 2:
                        opModeName = "Charge (CC)";
                        break;
                    case 4:
                        opModeName = "Charge (CCCV)";
                        break;
                    case 8:
                        opModeName = "Discharge (CC)";
                        break;
                    case 16:
                        opModeName = "Discharge (CCCV)";
                        break;
                }
            }
            else if (_EqpType == "DCR")
            {
                switch (mode)
                {
                    case 1:
                        opModeName = "OCV";
                        break;
                    case 64:
                        opModeName = "Power Discharge";
                        break;
                    case 128:
                        opModeName = "Power Charge";
                        break;
                }
            }
            else if (_EqpType == "OCV")
            {
                switch (mode)
                {
                    case 1:
                        opModeName = "OCV";
                        break;
                    case 32:
                        opModeName = "ACIR";
                        break;
                    case 33:
                        opModeName = "OCV and ACIR";
                        break;
                }
            }
            else if (_EqpType == "MIC")
            {
                switch (mode)
                {
                    case 1:
                        opModeName = "OCV";
                        break;
                    case 256:
                        opModeName = "SDM";
                        break;
                }
            }

            return opModeName;
        }
        #endregion

        #region GetEqpStatus
        private string GetEqpStatus(string status)
        {
            string statusName = string.Empty;

            switch (status)
            {
                case "C":
                    statusName = "Control Mode";
                    break;
                case "M":
                    statusName = "Maintenance Mode";
                    break;
                case "I":
                    statusName = "Idle";
                    break;
                case "R":
                    statusName = "Running";
                    break;
                case "T":
                    statusName = "Machine Trouble";
                    break;
                case "P":
                    statusName = "Pause";
                    break;
                case "S":
                    statusName = "Stop";
                    break;
                case "L":
                    statusName = "Loading";
                    break;
                case "F":
                    statusName = $"Fire\r\n(Temperature Alarm Only)";
                    break;
                case "F2":
                    statusName = $"Fire\r\n(Smoke Only or Both)";
                    break;
            }

            return statusName;
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

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            CtrlButton btn = sender as CtrlButton;

            WinSaveLogin saveLogin = new WinSaveLogin();
            DialogResult result = saveLogin.ShowDialog();

            if (result != DialogResult.Yes) return;

            if (CAuthority.CheckAuthority(enAuthority.Save, CDefine.m_strSaveLoginID, this.Text))
            {
                if (btn.Name == EqpControlSave.Name)
                {
                    
                    CMessage.MsgInformation("EqpControlSave Save OK.");
                }
                else
                {
                    if (rbDataClear.Checked)
                        SetDataClear(_EqpID).GetAwaiter().GetResult();
                    else if (rbClearTrouble.Checked)
                        SetDataClear(_EqpID).GetAwaiter().GetResult();

                    CMessage.MsgInformation("DataClearSave Save OK.");
                }                
            }
            else
            {
                CMessage.MsgInformation("Save Fail.");
            }
        }
        #endregion

        #region SetDataClear
        private async Task SetDataClear(string eqpid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" UPDATE fms_v.tb_mst_eqp");
                strSQL.Append(" SET tray_cnt = null, tray_id = null, tray_id_2 = null");
                //필수값
                strSQL.Append($" WHERE eqp_id = '{eqpid}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_UPDATE, strSQL.ToString());

                //if (jsonResult != null)
                //{
                //    _jsonWinManageEqpResponse result = rest.ConvertWinManageEqp(jsonResult);

                //    if (result != null)
                //    {
                //        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                //        SetData(result.DATA);
                //    }
                //    else
                //    {
                //        string log = "WinManageEqp : jsonResult is null";
                //        _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                //    }
                //}
                //else
                //{
                //    string log = "WinManageEqp : jsonResult is null";
                //    _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadWinManageEqp] {0}", ex.ToString()));
            }
        }
        #endregion
    }
}
