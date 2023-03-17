using ExcelDataReader.Log;
using FMSMonitoringUI.Controlls.WindowsForms;
using Google.Protobuf.WellKnownTypes;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
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

        private List<_dat_cell> _CellInfo;
        private List<_cell_process_flow> _CellProcessFlow;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinCellDetailInfo(string trayId)
        {
            InitializeComponent();

            InitControl();
            InitGridViewCellList();
            InitGridViewCell();
            InitGridViewProcessName(0);
            
            List<_recipe_item> recipeItem = new List<_recipe_item>();
            InitGridViewRecipeInfo(recipeItem);

            Dictionary<string, object> recipeData = new Dictionary<string, object>();
            InitGridViewProcessData(recipeData);
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

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
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
            lbProcessFlow.CallLocalLanguage();
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
            //lstTitle.Add("");
            gridCellIDLIst.AddRowsHeaderList(lstTitle);

            gridCellIDLIst.RowsHeight(22);

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
                //LocalLanguage.GetItemString("DEF_UnitID_Level"),
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
                //LocalLanguage.GetItemString("DEF_Rework_EQPID"),
                //LocalLanguage.GetItemString("DEF_Rework_UnitID"),
                // 화재 관련
                LocalLanguage.GetItemString("DEF_Fire_Flag"),
                LocalLanguage.GetItemString("DEF_Fire_Time")
                //LocalLanguage.GetItemString("DEF_Fire_EQPID"),
                //LocalLanguage.GetItemString("DEF_Fire_UnitID"),
                // Scrap 관련
                //LocalLanguage.GetItemString("DEF_Scrap_Flag"),
                //LocalLanguage.GetItemString("DEF_Scrap_User"),
                //LocalLanguage.GetItemString("DEF_Scrap_Time"),
                //""
            };
            gridCellInfo.AddRowsHeaderList(lstTitle);

            gridCellInfo.RowsHeight(22);

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

            gridProcessName.RowsHeight(22);

            gridProcessName.SetGridViewStyles();
            gridProcessName.ColumnHeadersWidth(0, 60);
        }

        //private void InitGridViewRecipeInfo(Dictionary<string, string> rcpItem)
        private void InitGridViewRecipeInfo(List<_recipe_item> rcpItem)
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
                //lstTitle.Add(item.Key);
                lstTitle.Add(item.NAME);
            }
            gridRecipeInfo.AddRowsHeaderList(lstTitle);

            gridRecipeInfo.RowsHeight(22);

            gridRecipeInfo.SetGridViewStyles();
            gridRecipeInfo.ColumnHeadersWidth(0, 200);

            for (int i = 0; i < rcpItem.Count; i++)
            {
                //gridRecipeInfo.SetValue(1, i, rcpItem.Values.ToList()[i]);

                //string val = string.Format("{0:0.0} {1}", rcpItem[i].VALUE, rcpItem[i].UNIT);
                string val = string.Format("{0} {1}", rcpItem[i].VALUE, rcpItem[i].UNIT);
                gridRecipeInfo.SetValue(1, i, val);
            }
        }
        //private void InitGridViewProcessData(List<_recipe_item> dataItem)
        private void InitGridViewProcessData(Dictionary<string, object> dataItem)
        {
            if (dataItem == null) return;

            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Name"),
                LocalLanguage.GetItemString("DEF_Value")
            };
            gridProcessData.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            foreach (var item in dataItem)
            {
                lstTitle.Add(item.Key);
                //lstTitle.Add(item.NAME);
            }
            gridProcessData.AddRowsHeaderList(lstTitle);

            gridProcessData.RowsHeight(22);

            gridProcessData.SetGridViewStyles();
            gridProcessData.ColumnHeadersWidth(0, 200);

            for (int i = 0; i < dataItem.Count; i++)
            {

                gridProcessData.SetValue(1, i, string.Format("{0:0.00}", dataItem.Values.ToList()[i]));
                //gridProcessData.SetValue(1, i, dataItem[i].VALUE);
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
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
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
                        SetCellList(result.DATA);

                        _CellInfo = result.DATA;
                    }
                    else
                    {
                        string log = "ConvertDatCell : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertDatCell : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("LoadCellData Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadCellData Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
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
            string time = _CellInfo[cellNo].TRAY_INPUT_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].TRAY_INPUT_TIME.Year == 1 ? "" : time); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].TRAY_INPUT_EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_CODE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_NG_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_DEFECT_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_EQP_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_PROCESS_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_PROCESS_NO); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_STEP_NO); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].GRADE_EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].MODEL_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].ROUTE_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].LOT_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].EQP_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].UNIT_ID); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].UNIT_ID_LEVEL); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].RECIPE_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].ROUTE_ORDER_NO); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].EQP_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].PROCESS_TYPE); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].PROCESS_NO); row++;
            time = _CellInfo[cellNo].START_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].START_TIME.Year == 1 ? "" : time); row++;
            time = _CellInfo[cellNo].END_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].END_TIME.Year == 1 ? "" : time); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_FLAG); row++;
            time = _CellInfo[cellNo].REWORK_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_TIME.Year == 1 ? "" : time); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_EQP_ID); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].REWORK_UNIT_ID); row++;
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_FLAG); row++;
            time = _CellInfo[cellNo].FIRE_TIME.ToString("dd-MM-yyyy HH:mm:ss");
            gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_TIME.Year == 1 ? "" : time); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_EQP_ID); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].FIRE_UNIT_ID); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].SCRAP_FLAG); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].SCRAP_USER); row++;
            //gridCellInfo.SetValue(1, row, _CellInfo[cellNo].SCRAP_TIME.Year == 1 ? "" : _CellInfo[cellNo].SCRAP_TIME.ToString()); row++;

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

        #region SetRecipeInfo
        private void SetRecipeInfo(int idx)
        {
            try
            {
                RESTClient rest = new RESTClient();

                string jsonResult = _CellProcessFlow[idx].JSON_RECIPE;

                if (jsonResult != null)
                {
                    _jsonRecipeInfoResponse result = rest.ConvertRecipeInfo(jsonResult);

                    if (result != null)
                    {
                        InitGridViewRecipeInfo(result.RECIPE_ITEM);
                    }
                    else
                    {
                        List<_recipe_item> recipeItem = new List<_recipe_item>();
                        InitGridViewRecipeInfo(recipeItem);
                    }
                }
                else
                {
                    string log = "JSON_RECIPE : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("SetRecipeInfo Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("SetRecipeInfo Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        private void SetProcessData(int idx)
        {
            try
            {
                RESTClient rest = new RESTClient();

                string jsonResult = _CellProcessFlow[idx].json_process_data;
                if (jsonResult != null)
                {
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
                else
                {
                    string log = "json_process_data : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }                    
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("SetProcessData Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("SetProcessData Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }

        }
        #endregion

        #region GetCellIDList
        private void GetCellIDList(string trayId)
        {
            try
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

                    if (result != null)
                    {
                        this.BeginInvoke(new Action(() => SetCellList(result.DATA)));

                        _CellInfo = result.DATA;
                    }
                    else
                    {
                        string log = "ConvertDatCell : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertDatCell : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("GetCellIDList Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("GetCellIDList Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
            
        }
        #endregion

        #region GetCellProcessName
        private void GetCellProcessName(string cellId)
        {
            try
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

                    if (result != null) 
                    {
                        this.BeginInvoke(new Action(() => SetProcessName(result.DATA)));

                        _CellProcessFlow = result.DATA;
                    }
                    else
                    {
                        string log = "ConvertCellPorcessFlow : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertCellPorcessFlow : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("GetCellProcessName Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("GetCellProcessName Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
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

            List<_recipe_item> recipeItem = new List<_recipe_item>();
            InitGridViewRecipeInfo(recipeItem);

            Dictionary<string, object> recipeData = new Dictionary<string, object>();
            InitGridViewProcessData(recipeData);
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

        


    }
}
