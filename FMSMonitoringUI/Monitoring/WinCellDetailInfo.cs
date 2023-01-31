using FMSMonitoringUI.Controlls.WindowsForms;
using Google.Protobuf.WellKnownTypes;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
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
using System.Web.Http.Results;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinCellDetailInfo : WinFormRoot
    {
        private Point point = new Point();
        private string _TrayId = string.Empty;

        private Logger _Logger;

        private List<_dat_cell> _CellInfo;
        private List<_cell_process_flow> _CellProcessFlow;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinCellDetailInfo(string trayId)
        {
            InitializeComponent();

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);

            InitControl();
            InitGridViewCellList();
            InitGridViewCell();
            InitGridViewProcessName(0);
            Dictionary<string, object> data = new Dictionary<string, object>();
            InitGridViewRecipeInfo(data);
            InitGridViewProcessData(data);
            InitLanguage();

            _TrayId = trayId;
        }

        #region WinCellDetailInfo Event
        private void WinCellDetailInfo_Load(object sender, EventArgs e)
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
            gridCellIDLIst.MouseCellDoubleClick_Evnet += GridCellIDLIst_MouseCellDoubleClick;
            gridProcessName.MouseCellDoubleClick_Evnet += GridProcessName_MouseCellDoubleClick;
            #endregion

            //GetCellIDList(_TrayId);

            _TheadVisiable = true;            

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

            this.WindowID = CAuthority.GetWindowsText(this.Text);
        }
        private void WinCellDetailInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
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

            lbCellIDList.CallLocalLanguage();
            lbCellInfo.CallLocalLanguage();
            lbProcessName.CallLocalLanguage();
            lbRecipeInfo.CallLocalLanguage();
            lbProcessData.CallLocalLanguage();

            Exit.CallLocalLanguage();
        }
        #endregion

        #region InitGridView
        private void InitGridViewCellList()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_No"),
                LocalLanguage.GetItemString("DEF_Cell_ID")
            };

            gridCellIDLIst.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            for (int i = 1; i <= CDefine.DEF_MAX_CELL_COUNT; i++)
            {
                lstTitle.Add(i.ToString());
            }
            lstTitle.Add("");
            gridCellIDLIst.AddRowsHeaderList(lstTitle);

            gridCellIDLIst.RowsHeight(26);

            gridCellIDLIst.SetGridViewStyles();
            gridCellIDLIst.ColumnHeadersWidth(0, 60);


        }
        private void InitGridViewCell()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Select Cell ID");      // -1
            lstTitle.Add("");
            gridCellInfo.AddColumnHeaderList(lstTitle);
            gridCellInfo.ColumnHeadersVisible(false);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Cell_ID"),
                // 현재 Tray 정보
                LocalLanguage.GetItemString("DEF_Tray_ID"),
                LocalLanguage.GetItemString("DEF_Cell_No"),
                LocalLanguage.GetItemString("DEF_Tray_InputTime"),
                LocalLanguage.GetItemString("DEF_Tray_InputEqpID"),
                // 등급 판정 관련
                LocalLanguage.GetItemString("DEF_Grade"),
                LocalLanguage.GetItemString("DEF_Grade_Code"),
                LocalLanguage.GetItemString("DEF_Grade_NG_Type"),
                LocalLanguage.GetItemString("DEF_Grade_Defect_Type"),
                LocalLanguage.GetItemString("DEF_Grade_EQP_Type"),
                LocalLanguage.GetItemString("DEF_Grade_Process_Type"),
                LocalLanguage.GetItemString("DEF_Grade_Process_No"),
                LocalLanguage.GetItemString("DEF_Grade_EQP_ID"),
                // Cell 정보
                LocalLanguage.GetItemString("DEF_Model_ID"),
                LocalLanguage.GetItemString("DEF_Route_ID"),
                LocalLanguage.GetItemString("DEF_Lot_ID"),
                // Cell의 현재 설비 정보
                LocalLanguage.GetItemString("DEF_EQP_ID"),
                LocalLanguage.GetItemString("DEF_Unit_ID"),
                LocalLanguage.GetItemString("DEF_UnitID_Level"),
                // Cell의 현재 설비 정보
                LocalLanguage.GetItemString("DEF_Recipe_ID"),
                LocalLanguage.GetItemString("DEF_Route_OrderNo"),
                LocalLanguage.GetItemString("DEF_EQP_Type"),
                LocalLanguage.GetItemString("DEF_Process_Type"),
                LocalLanguage.GetItemString("DEF_Process_No"),
                LocalLanguage.GetItemString("DEF_Start_Time"),
                LocalLanguage.GetItemString("DEF_End_Time"),
                // Rework 관련 정보
                LocalLanguage.GetItemString("DEF_Rework_Flag"),
                LocalLanguage.GetItemString("DEF_Rework_Time"),
                LocalLanguage.GetItemString("DEF_Rework_EQPID"),
                LocalLanguage.GetItemString("DEF_Rework_UnitID"),
                // 화재 관련
                LocalLanguage.GetItemString("DEF_Fire_Flag"),
                LocalLanguage.GetItemString("DEF_Fire_Time"),
                LocalLanguage.GetItemString("DEF_Fire_EQPID"),
                LocalLanguage.GetItemString("DEF_Fire_UnitID"),
                // Scrap 관련
                LocalLanguage.GetItemString("DEF_Scrap_Flag"),
                LocalLanguage.GetItemString("DEF_Scrap_User"),
                LocalLanguage.GetItemString("DEF_Scrap_Time"),
                ""
            };

            //lstTitle = new List<string>();
            //lstTitle.Add("Cell ID");
            //// 현재 Tray 정보
            //lstTitle.Add("Tray ID");
            //lstTitle.Add("Cell No");
            //lstTitle.Add("Tray InputTime");
            //lstTitle.Add("Tray InputEqpID");
            //// 등급 판정 관련
            //lstTitle.Add("Grade");
            //lstTitle.Add("Grade Code");
            //lstTitle.Add("Grade NG Type");
            //lstTitle.Add("Grade Defect Type");
            //lstTitle.Add("Grade EQP Type");
            //lstTitle.Add("Grade Process Type");
            //lstTitle.Add("Grade Process No");
            //lstTitle.Add("Grade EQP ID");
            //// Cell 정보
            //lstTitle.Add("Model ID");
            //lstTitle.Add("Route ID");
            //lstTitle.Add("Lot ID");
            //// Cell의 현재 설비 정보
            //lstTitle.Add("EQP ID");
            //lstTitle.Add("UNIT ID");
            //lstTitle.Add("UNITID LEVEL");
            //// Cell의 현재 process 정보
            //lstTitle.Add("Recipe ID");
            //lstTitle.Add("Route OrderNo");
            //lstTitle.Add("EQP Type");
            //lstTitle.Add("Process Type");
            //lstTitle.Add("Process No");
            //lstTitle.Add("Start Time");
            //lstTitle.Add("End Time");
            //// Rework 관련 정보
            //lstTitle.Add("Rework Flag");
            //lstTitle.Add("Rework Time");
            //lstTitle.Add("Rework EQPID");
            //lstTitle.Add("Rework UnitID");
            //// 화재 관련
            //lstTitle.Add("Fire Flag");
            //lstTitle.Add("Fire Time");
            //lstTitle.Add("Fire EQPID");
            //lstTitle.Add("Fire UnitID");
            //// Scrap 관련
            //lstTitle.Add("Scrap Flag");
            //lstTitle.Add("Scrap User");
            //lstTitle.Add("Scrap Time");
            //lstTitle.Add("");
            gridCellInfo.AddRowsHeaderList(lstTitle);

            gridCellInfo.RowsHeight(26);

            gridCellInfo.SetGridViewStyles();
            gridCellInfo.ColumnHeadersWidth(0, 160);            
        }
        private void InitGridViewProcessName(int rowCount)
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_No"),
                LocalLanguage.GetItemString("DEF_Process_Name")
            };

            gridProcessName.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            for (int i = 0; i < rowCount; i++)
            {
                lstTitle.Add((i + 1).ToString());
            }
            gridProcessName.AddRowsHeaderList(lstTitle);

            gridProcessName.RowsHeight(26);

            gridProcessName.SetGridViewStyles();
            gridProcessName.ColumnHeadersWidth(0, 60);


        }
        private void InitGridViewRecipeInfo(Dictionary<string, object> rcpItem)
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Name"),
                LocalLanguage.GetItemString("DEF_Value")
            };
            gridRecipeInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            foreach (var item in rcpItem)
            {
                lstTitle.Add(item.Key);
            }
            gridRecipeInfo.AddRowsHeaderList(lstTitle);

            gridRecipeInfo.RowsHeight(26);

            gridRecipeInfo.SetGridViewStyles();
            //gridRecipeInfo.ColumnHeadersWidth(0, 140);

            for (int i = 0; i < rcpItem.Count; i++)
            {
                gridRecipeInfo.SetValue(1, i, rcpItem.Values.ToList()[i]);
            }
        }
        private void InitGridViewProcessData(Dictionary<string, object> dataItem)
        {
            if (dataItem == null) return;

            List<string> lstTitle = new List<string>();
            lstTitle.Add("Name");      // -1
            lstTitle.Add("Value");
            gridProcessData.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            foreach (var item in dataItem)
            {
                lstTitle.Add(item.Key);
            }
            gridProcessData.AddRowsHeaderList(lstTitle);

            gridProcessData.RowsHeight(26);

            gridProcessData.SetGridViewStyles();
            //gridProcessData.ColumnHeadersWidth(0, 140);

            for (int i = 0; i < dataItem.Count; i++)
            {
                gridProcessData.SetValue(1, i, dataItem.Values.ToList()[i]);
            }
        }
        #endregion

        #region SetData
        private void SetCellList(List<_dat_cell> data)
        {
            if (data == null || data.Count == 0) return;

            for (int i = 0; i < CDefine.DEF_MAX_CELL_COUNT; i++)
            {
                gridCellIDLIst.SetValue(1, i, data[i].CELL_ID);
            }
        }
        private void SetCellInfo(int cellNo)
        {
            int row = 0;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].CELL_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].TRAY_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].CELL_NO); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].TRAY_INPUT_TIME); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].TRAY_INPUT_EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_CODE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_NG_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_DEFECT_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_EQP_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_PROCESS_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_PROCESS_NO); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_STEP_NO); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].MODEL_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].ROUTE_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].LOT_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].UNIT_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].UNIT_ID_LEVEL); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].RECIPE_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].ROUTE_ORDER_NO); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].EQP_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].PROCESS_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].PROCESS_NO); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].START_TIME); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].END_TIME); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_FLAG); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_TIME); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_UNIT_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_FLAG); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_TIME); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_UNIT_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].SCRAP_FLAG); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].SCRAP_USER); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].SCRAP_TIME); row++;

        }
        private void SetProcessName(List<_cell_process_flow> data)
        {
            InitGridViewProcessName(data.Count);

            if (data == null || data.Count == 0) return;

            for (int i = 0; i < data.Count; i++)
            {
                gridProcessName.SetValue(1, i, data[i].PROCESS_NAME);
            }            
        }
        private void SetRecipeInfo(int idx)
        {
            RESTClient rest = new RESTClient();

            string jsonResult = _CellProcessFlow[idx].JSON_RECIPE;
            _jsonRecipeInfoResponse result = rest.ConvertRecipeInfo(jsonResult);

            if (result != null)
            {
                InitGridViewRecipeInfo(result.RECIPE_ITEM);
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                InitGridViewRecipeInfo(data);
            }
        }
        private void SetProcessData(int idx)
        {
            RESTClient rest = new RESTClient();

            string jsonResult = _CellProcessFlow[idx].json_process_data;
            _jsonProcessDataResponse result = rest.ConvertProcessData(jsonResult);

            if (result != null)
            {
                InitGridViewProcessData(result.RESULT_DATA);
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                InitGridViewProcessData(data);
            }
        }
        #endregion

        #region GetCellIDList
        private void GetCellIDList(string trayId)
        {
            RESTClient rest = new RESTClient();
            //// Set Query
            StringBuilder strSQL = new StringBuilder();
            // Tray Information
            strSQL.Append(" SELECT *");
            strSQL.Append(" FROM fms_v.tb_dat_cell");
            //필수값
            strSQL.Append($" WHERE tray_id = '{trayId}'");

            var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

            if (jsonResult != null)
            {
                _jsonDatCellResponse result = rest.ConvertDatCell(jsonResult.Result);

                this.BeginInvoke(new Action(() => SetCellList(result.DATA)));

                _CellInfo = result.DATA;
            }
        }
        #endregion

        #region GetCellProcessName
        private void GetCellProcessName(string cellId)
        {
            RESTClient rest = new RESTClient();
            //// Set Query
            StringBuilder strSQL = new StringBuilder();
            // Tray Information
            strSQL.Append(" SELECT B.process_name,");
            strSQL.Append("        A.json_recipe, A.json_process_data");
            strSQL.Append(" FROM tb_dat_cell_proc A, tb_mst_route_order B");
            //필수값
            strSQL.Append($" WHERE A.cell_id = '{cellId}'");
            strSQL.Append("    AND A.proc_work_index = 0");
            strSQL.Append("    AND B.route_id = A.route_id");
            strSQL.Append("    AND B.eqp_type = A.eqp_type");
            strSQL.Append("    AND B.process_type = A.process_type");
            strSQL.Append("    AND B.process_no = A.process_no");
            strSQL.Append(" ORDER BY A.start_time");

            var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

            if (jsonResult != null)
            {
                _jsonCellProcessFlowResponse result = rest.ConvertCellPorcessFlow(jsonResult.Result);

                this.BeginInvoke(new Action(() => SetProcessName(result.DATA)));

                _CellProcessFlow = result.DATA;
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
        private void GridCellIDLIst_MouseCellDoubleClick(int col, int row, object value)
        {
            for (int i = 0; i < 30; i++)
            {
                gridCellIDLIst.SetStyleBackColor(col, i, Color.FromArgb(27,27,27));
                gridCellIDLIst.SetStyleForeColor(col, i, Color.White);
            }

            if (col == 1 && row > -1)
            {
                gridCellIDLIst.SetStyleBackColor(col, row, Color.LightBlue);
                gridCellIDLIst.SetStyleForeColor(col, row, Color.Black);

                SetCellInfo(row);

                GetCellProcessName(value.ToString());
            }

            Dictionary<string, object> data = new Dictionary<string, object>();
            InitGridViewRecipeInfo(data);
            InitGridViewProcessData(data);
        }        
        private void GridProcessName_MouseCellDoubleClick(int col, int row, object value)
        {
            for (int i = 0; i < _CellProcessFlow.Count; i++)
            {
                gridProcessName.SetStyleBackColor(col, i, Color.FromArgb(27, 27, 27));
                gridProcessName.SetStyleForeColor(col, i, Color.White);
            }

            if (col == 1 && row > -1)
            {
                gridProcessName.SetStyleBackColor(col, row, Color.LightBlue);
                gridProcessName.SetStyleForeColor(col, row, Color.Black);

                SetRecipeInfo(row);
                SetProcessData(row);
            }
        }
        #endregion

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
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
                        LoadCellData(_TrayId).GetAwaiter().GetResult();
                    }));

                    //Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### WinCellDetailInfo ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region LoadCellData
        private async Task LoadCellData(string trayid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT *");
                strSQL.Append(" FROM fms_v.tb_dat_cell");
                //필수값
                strSQL.Append($" WHERE tray_id = '{trayid}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonDatCellResponse result = rest.ConvertDatCell(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetCellList(result.DATA);

                        _CellInfo = result.DATA;
                    }
                    else
                    {
                        string log = "LoadCellData : jsonResult is null";
                        _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                    }
                }
                else
                {
                    string log = "LoadCellData : jsonResult is null";
                    _Logger.Write(LogLevel.Error, log, LogFileName.ErrorLog);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("[Exception:LoadCellData] {0}", ex.ToString()));
            }
        }
        #endregion


    }
}
