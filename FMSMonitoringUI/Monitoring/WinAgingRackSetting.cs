using FMSMonitoringUI.Controlls.WindowsForms;
using Google.Protobuf.WellKnownTypes;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MonitoringUI.Popup;
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
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinAgingRackSetting : WinFormRoot
    {
        private Point point = new Point();
        private string _EqpID = string.Empty;
        private string _RackID = string.Empty;

        Dictionary<string, KeyValuePair<string, Color>> _RackStatus;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinAgingRackSetting(string eqpid, string rackId, Dictionary<string, KeyValuePair<string, Color>> rackStatus)
        {
            InitializeComponent();

            _EqpID = eqpid;
            _RackID = rackId;

            _RackStatus = rackStatus;

            InitControl();
            InitGridViewEqp();
            InitGridViewTray();
            InitLanguage();
        }

        #region WinAgingRackSetting Event
        private void WinAgingRackSetting_Load(object sender, EventArgs e)
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
        private void WinAgingRackSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (_TheadVisiable)
                this._ProcessThread.Abort();
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            Exit.Left = (this.panel3.Width - Exit.Width) / 2;             
            Exit.Top = (this.panel3.Height - Exit.Height) / 2;

            dtPlanTime.StartTime = DateTime.Now;
            dtPlanTime.OnValueChanged += OnDateTimeChanged;
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            titBar.CallLocalLanguage();

            foreach (var ctl in splitContainer2.Panel2.Controls)
            {
                if (ctl.GetType() == typeof(CtrlGroupBox))
                {
                    CtrlGroupBox grBox = ctl as CtrlGroupBox;
                    grBox.CallLocalLanguage();

                    foreach (var ctl2 in grBox.Controls)
                    {
                        if (ctl2.GetType() == typeof(CtrlRadioButton))
                        {
                            CtrlRadioButton tagName = ctl2 as CtrlRadioButton;
                            tagName.CallLocalLanguage();
                        }
                        else if (ctl2.GetType() == typeof(CtrlButton))
                        {
                            CtrlButton tagName = ctl2 as CtrlButton;
                            tagName.CallLocalLanguage();
                        }
                    }
                }
                else if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel tagName = ctl as CtrlLabel;
                    tagName.CallLocalLanguage();
                }
            }

            Exit.CallLocalLanguage();
        }
        #endregion

        #region InitGridView
        private void InitGridViewEqp()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Rack_Information"),
                ""
            };
            gridEqpInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Rack_ID"),
                LocalLanguage.GetItemString("DEF_Rack_Name"),
                LocalLanguage.GetItemString("DEF_Rack_Status"),
                LocalLanguage.GetItemString("DEF_Use_Flag"),
                LocalLanguage.GetItemString("DEF_Trouble_Code"),
                LocalLanguage.GetItemString("DEF_Trouble_Name")
            };
            gridEqpInfo.AddRowsHeaderList(lstTitle);

            gridEqpInfo.ColumnHeadersHeight(31);
            gridEqpInfo.RowsHeight(31);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Rack_Information")
            };
            gridEqpInfo.ColumnMergeList(lstColumn, lstTitle);

            gridEqpInfo.SetGridViewStyles();
            gridEqpInfo.ColumnHeadersWidth(0, 120);
        }

        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Tray_Information"),
                "",
                ""
            };
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Tray_ID"),
                LocalLanguage.GetItemString("DEF_Level"),
                LocalLanguage.GetItemString("DEF_Binding_Time"),           // tray_input_time      
                LocalLanguage.GetItemString("DEF_Tray_Type"),
                LocalLanguage.GetItemString("DEF_Model_ID"),
                LocalLanguage.GetItemString("DEF_Route_ID"),
                LocalLanguage.GetItemString("DEF_Recipe_ID"),
                LocalLanguage.GetItemString("DEF_Cerrent_Process"),
                LocalLanguage.GetItemString("DEF_Start_Time"),
                LocalLanguage.GetItemString("DEF_Plan_Time")
            };
            gridTrayInfo.AddRowsHeaderList(lstTitle);

            gridTrayInfo.ColumnHeadersHeight(31);
            gridTrayInfo.RowsHeight(31);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Tray_Information")
            };
            gridTrayInfo.ColumnMergeList(lstColumn, lstTitle, 0, 3);

            gridTrayInfo.SetGridViewStyles();
            gridTrayInfo.ColumnHeadersWidth(0, 120);
        }
        #endregion

        #region OnDateTimeChanged
        /// <summary>
        /// Plan Time변경 Event
        /// </summary>
        private void OnDateTimeChanged()
        {
            rbForceUnload.Checked = false;
            rbPlanTime.Checked = true;
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
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
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

                strSQL.Append(" SELECT A.aging_type, A.line, A.lane, A.bay, A.floor, A.rack_id, A.use_flag, A.status, A.tray_cnt, A.process_no,");
                strSQL.Append("        C.tray_id AS sel_tray_id, IF(A.tray_id = C.tray_id, '1', '2') AS level,");
                strSQL.Append("        B.trouble_name,B.trouble_name_local,");
                strSQL.Append("        C.tray_zone, C.model_id, C.route_id, C.recipe_id, C.start_time, C.plan_time,");
                strSQL.Append("        (SELECT sf_get_process_name(C.model_id, C.route_id, C.eqp_type, C.process_type, C.process_no)) AS process_name");
                strSQL.Append(" FROM fms_v.tb_mst_aging   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_trouble    B");
                strSQL.Append("         ON A.trouble_code = B.trouble_code AND A.in_eqp_type = B.eqp_type");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   C");
                strSQL.Append("         ON C.tray_id IN (A.tray_id, A.tray_id_2)");
                //필수값
                strSQL.Append($" WHERE A.rack_id = '{rackid}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonWinAgingRackSettingResponse result = rest.ConvertWinAgingRackSetting(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertWinAgingRackSetting : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertWinAgingRackSetting : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadAgingRackSetting Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadAgingRackSetting Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region UpdateManualCommand
        private async Task<bool> UpdateManualCommand(enCommnadType saveType, string rackid, object value)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" UPDATE fms_v.tb_mst_aging");
                switch (saveType)
                {
                    case enCommnadType.ConfigurationSave:
                        strSQL.Append($" SET status = '{value}'");
                        break;
                    case enCommnadType.PlanTimeSave:
                        strSQL.Append($" SET end_time = '{value}'");
                        break;
                    case enCommnadType.DataClearSave:
                        strSQL.Append($" SET {value}");
                        break;
                }

                //필수값
                strSQL.Append($" WHERE rack_id = '{rackid}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_UPDATE, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonUpdateBaseResponse result = rest.ConvertUpdateBase(jsonResult);

                    if (result != null)
                    {
                        if (result.RESPONSE_CODE == "200")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        string log = "ConvertUpdateBase : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                        return false;
                    }
                }
                else
                {
                    string log = "ConvertUpdateBase : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("UpdateManualCommand Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("UpdateManualCommand Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                return false;
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_win_aging_rack> data)
        {
            if (data == null || data.Count == 0) return;

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
            string troubleName = (CDefine.m_enLanguage == enLoginLanguage.English ? data[0].TROUBLE_NAME : data[0].TROUBLE_NAME_LOCAL);
            gridEqpInfo.SetValue(1, row, troubleName);

            SetConfiguration(data[0]);

            if (data[0].STATUS == "E") return;

            for (int i = 0; i < data.Count; i++)
            {
                row = 0;
                gridTrayInfo.SetValue(i + 1, row, data[i].SEL_TRAY_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].SEL_TRAY_ID == null ? "" : data[i].LEVEL); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_INPUT_TIME.Year == 1 ? "" : data[i].TRAY_INPUT_TIME.ToString()); row++;
                gridTrayInfo.SetValue(i + 1, row, GetTrayType(data[i].TRAY_ZONE)); row++;
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
                CLogger.WriteLog(enLogLevel.ButtonClick, this.WindowID, $"Tray Info : Eqp ID = {_EqpID}, Unit ID = {_RackID}, Tray ID = {value}");

                WinTrayInfo form = new WinTrayInfo(_EqpID, _RackID, value.ToString());
                form.ShowDialog();
            }
        }
        #endregion

        #region SetConfiguration
        private void SetConfiguration(_win_aging_rack trayStatus)
        {
            if (trayStatus.TRAY_CNT == 0 && trayStatus.TRAY_ID == null && trayStatus.TRAY_ID_2 == null)
            {
                rbYesOut.Visible = false;
                rbNoOut.Visible = false;
                rbYesIn.Visible = true;
                rbNoIn.Visible = true;
            }
            else
            {
                rbYesIn.Visible = false;
                rbNoIn.Visible = false;
                rbYesOut.Visible = true;
                rbNoOut.Visible = true;
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
            saveLogin.ShowDialog();

            bool update = false;
            string updateValue = string.Empty;

            if (CDefine.m_strSaveLoginID == "") return;

            if (CAuthority.CheckAuthority(enAuthority.Save, CDefine.m_strSaveLoginID, this.Text))
            {
                CLogger.WriteLog(enLogLevel.ButtonClick, this.WindowID, $"Save UserID : {CDefine.m_strSaveLoginID}, Save UserName : {CDefine.m_strSaveLoginName}");

                if (btn.Name == ConfigurationSave.Name)
                {
                    updateValue = GetConfiguration();
                    update = UpdateManualCommand(enCommnadType.ConfigurationSave, _RackID, updateValue).GetAwaiter().GetResult();
                }
                else if (btn.Name == PlanTimeSave.Name)
                {
                    updateValue = GetPlanTime();
                    update = UpdateManualCommand(enCommnadType.PlanTimeSave, _RackID, updateValue).GetAwaiter().GetResult();
                }
                else if (btn.Name == DataClearSave.Name)
                {
                    updateValue = GetDataClear();
                    update = UpdateManualCommand(enCommnadType.DataClearSave, _RackID, updateValue).GetAwaiter().GetResult();
                }

                CLogger.WriteLog(enLogLevel.Info, this.WindowID, $"{btn.Name} : Rack ID = {_RackID}, Update Value = {updateValue}, Return Code = {(update ? "OK" : "Fail")}");

                if (update)
                    CMessage.MsgInformation($"{btn.Name} OK.");
                else
                    CMessage.MsgInformation($"{btn.Name} Fail.");
                
            }
            else
            {
                CMessage.MsgInformation($"{btn.Name} Fail.");
            }
        }
        #endregion

        #region GetConfiguration
        private string GetConfiguration()
        {
            string status = string.Empty;

            if (rbYesIn.Checked)        // 입고 가능
            {
                status = "E";
            }
            else if (rbNoIn.Checked)    // 입고 불가
            {
                status = "X";
            }

            if (rbYesOut.Checked)       // 출고 가능
            {
                status = "F";
            }
            else if (rbNoOut.Checked)   // 출고 불가
            {
                status = "O";
            }

            return status;
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

        #region GetPlanTime
        private string GetPlanTime()
        {
            string now = string.Empty;

            if (rbForceUnload.Checked)
            {
                now = DateTime.Now.ToString();
            }
            else if (rbPlanTime.Checked)
            {
                now = dtPlanTime.StartTime.ToString("yyyyMMddHHmmss");
            }

            return now;
        }
        #endregion

        #region GetDataClear
        private string GetDataClear()
        {
            string sql = string.Empty;

            // status는 현장가서 확인 해 볼것.
            if (rbClearInfo.Checked)
            {
                sql = "status = 'E', tray_cnt = null, tray_id = null, tray_id_2 = null, start_time = null, end_time = null";
            }
            else if (rbClearTrouble.Checked)
            {
                sql = "status = 'E', trouble_code = null";
            }

            return sql;
        }
        #endregion
    }
}
