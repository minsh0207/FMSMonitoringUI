using FMSMonitoringUI.Controlls.WindowsForms;
using Google.Protobuf.WellKnownTypes;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MonitoringUI.Popup;
using Newtonsoft.Json.Linq;
using OPCUAClientClassLib;
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
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinFormationHPC : WinFormRoot
    {
        private Point point = new Point();
        private string _EqpID = string.Empty;
        private string _EqpType = string.Empty;
        private string _UnitID = string.Empty;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinFormationHPC(string titleText, string eqpid, string eqpType, string unitid)
        {
            InitializeComponent();

            _EqpID = eqpid;
            _EqpType = eqpType;
            _UnitID = unitid;

            titBar.TitleText = $"{titleText} {LocalLanguage.GetItemString("DEF_Information")}";
        }

        #region WinFormationHPC Event
        private void WinFormationHPC_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Text) == false)
            {
                Exit_Click(null, null);
                return;
            }

            InitControl();
            InitGridViewEqp();
            InitGridViewTray();
            InitLanguage();

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

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }
        private void WinFormationHPC_FormClosed(object sender, FormClosedEventArgs e)
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
            //titBar.CallLocalLanguage();

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
                LocalLanguage.GetItemString("DEF_HPC_Information"),
                ""
            };
            gridEqpInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_HPC_ID"),
                LocalLanguage.GetItemString("DEF_Name"),
                LocalLanguage.GetItemString("DEF_Control_Mode").Replace(" :", ""),
                LocalLanguage.GetItemString("DEF_Status").Replace(" :", ""),
                LocalLanguage.GetItemString("DEF_Operation_Mode"),
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
                LocalLanguage.GetItemString("DEF_HPC_Information")
            };
            gridEqpInfo.ColumnMergeList(lstColumn, lstTitle);

            gridEqpInfo.SetGridViewStyles();
            gridEqpInfo.ColumnHeadersWidth(0, 140);
        }

        private void InitGridViewTray()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Tray_Information"),
                ""
            };
            gridTrayInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Tray_ID"),
                LocalLanguage.GetItemString("DEF_Binding_Time"),           // tray_input_time      
                LocalLanguage.GetItemString("DEF_Tray_Type"),
                LocalLanguage.GetItemString("DEF_Model_ID"),
                LocalLanguage.GetItemString("DEF_Route_ID"),
                LocalLanguage.GetItemString("DEF_Lot_ID"),
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
            gridTrayInfo.ColumnMergeList(lstColumn, lstTitle);

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
                        LoadFormationHPC(_UnitID).GetAwaiter().GetResult();
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

        #region LoadFormationHPC
        private async Task LoadFormationHPC(string unitid)
        {
            try
            {
                RESTClient rest = new RESTClient();
                // Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT A.unit_id, A.eqp_name, A.eqp_mode, A.eqp_status, A.operation_mode, A.tray_id,");
                strSQL.Append("        B.trouble_code, B.trouble_name,");
                strSQL.Append("        C.tray_input_time, C.tray_zone, C.model_id, C.route_id, C.lot_id, C.start_time, C.plan_time,");
                strSQL.Append("        (SELECT sf_get_process_name(C.model_id, C.route_id, C.eqp_type, C.process_type, C.process_no)) AS process_name");
                strSQL.Append(" FROM fms_v.tb_mst_eqp   A");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_mst_trouble    B");
                strSQL.Append("         ON A.eqp_trouble_code = B.trouble_code AND A.eqp_type = B.eqp_type");
                strSQL.Append("     LEFT OUTER JOIN fms_v.tb_dat_tray   C");
                strSQL.Append("         ON C.tray_id IN (A.tray_id, A.tray_id_2)");
                //필수값
                strSQL.Append($" WHERE A.unit_id = '{unitid}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonWinFormationHPCResponse result = rest.ConvertWinFormationHPC(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertWinFormationHPC : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertWinFormationHPC : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadFormationHPC Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadFormationHPC Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region SendEquipmentControl
        private async Task<bool> SendEquipmentControl(string eqpID, string eqpType, string unitID, string command)
        {
            try
            {
                RESTClient rest = new RESTClient(eqpType, unitID);

                //Request 세팅
                JObject reqBody = new JObject();
                reqBody["ACTION_ID"] = enActionType.SEND_MANUAL_COMMAND.ToString();
                reqBody["ACTION_USER"] = CDefine.m_strSaveLoginID;
                reqBody["REQUEST_TIME"] = DateTime.Now.ToString();
                reqBody["EQP_TYPE"] = eqpType;
                reqBody["EQP_ID"] = eqpID;
                reqBody["UNIT_ID"] = unitID;
                reqBody["COMMAND"] = command;

                var jsonResult = await rest.SetJson(CRestModulePath.POST_MANUAL_COMMAND, reqBody);

                if (jsonResult != null)
                {
                    _jsonManualCommandResponse result = rest.ConvertManualCommand(jsonResult);

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
                        string log = "ConvertManualCommand : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                        return false;
                    }
                }
                else
                {
                    string log = "ConvertManualCommand : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("SendEquipmentControl Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("SendEquipmentControl Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                return false;
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

                strSQL.Append(" UPDATE fms_v.tb_mst_eqp");
                switch (saveType)
                {
                    case enCommnadType.DataClearSave:
                        strSQL.Append($" SET {value}");
                        break;
                }

                //필수값
                strSQL.Append($" WHERE unit_id = '{rackid}'");

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
                System.Diagnostics.Debug.Print(string.Format("SendEquipmentControl Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("SendEquipmentControl Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);

                return false;
            }            
        }
        #endregion

        #region SetData
        public void SetData(List<_win_formation_hpc> data)
        {
            if (data == null || data.Count == 0) return;

            int row = 0;
            gridEqpInfo.SetValue(1, row, data[0].UNIT_ID); row++;
            gridEqpInfo.SetValue(1, row, data[0].EQP_NAME); row++;

            gridEqpInfo.SetValue(1, row, GetEqpStatus(data[0].EQP_MODE)); row++;
            gridEqpInfo.SetValue(1, row, GetEqpStatus(data[0].EQP_STATUS)); row++;

            //if (data[0].OPERATION_MODE == 0) gridEqpInfo.RowsVisible(row, false);
            //else gridEqpInfo.RowsVisible(row, true);
            gridEqpInfo.SetValue(1, row, GetOperationMode(data[0].OPERATION_MODE)); row++;

            gridEqpInfo.SetValue(1, row, data[0].TROUBLE_CODE); row++;
            string troubleName = (CDefine.m_enLanguage == enLoginLanguage.English ? data[0].TROUBLE_NAME : data[0].TROUBLE_NAME_LOCAL);
            gridEqpInfo.SetValue(1, row, troubleName);

            for (int i = 0; i < data.Count; i++)
            {
                row = 0;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].TRAY_INPUT_TIME.Year == 1 ? "" : data[i].TRAY_INPUT_TIME.ToString()); row++;
                gridTrayInfo.SetValue(i + 1, row, GetTrayType(data[i].TRAY_ZONE)); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].MODEL_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].ROUTE_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].LOT_ID); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].PROCESS_NAME); row++;
                gridTrayInfo.SetValue(i + 1, row, data[i].START_TIME.Year == 1 ? "" : data[i].TRAY_INPUT_TIME.ToString()); row++;
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

        #region Exit_Click
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            CtrlButton btn = sender as CtrlButton;

            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID == "") return;

            bool update = false;
            string updateValue = string.Empty;

            if (CAuthority.CheckAuthority(enAuthority.Save, CDefine.m_strSaveLoginID, this.Text))
            {
                CLogger.WriteLog(enLogLevel.ButtonClick, this.WindowID, $"Save UserID : {CDefine.m_strSaveLoginID}, Save UserName : {CDefine.m_strSaveLoginName}");

                if (btn.Name == EqpControlSave.Name)
                {
                    updateValue = GetEqpControlSave();
                    update = SendEquipmentControl(_EqpID, _EqpType, _UnitID, updateValue).GetAwaiter().GetResult();
                }
                else if (btn.Name == DataClearSave.Name)
                {
                    updateValue = GetDataClear();
                    update = UpdateManualCommand(enCommnadType.DataClearSave, _UnitID, updateValue).GetAwaiter().GetResult();
                }

                CLogger.WriteLog(enLogLevel.Info, this.WindowID, $"{btn.Name} : Unit ID = {_UnitID}, Update Value = {updateValue}, Return Code = {(update ? "OK" : "Fail")}");

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

        #region GetOperationMode 
        private string GetOperationMode(int mode)
        {
            string opModeName = string.Empty;

            switch (mode)
            {
                case 1:
                    opModeName = LocalLanguage.GetItemString("DEF_OCV");
                    break;
                case 2:
                    opModeName = LocalLanguage.GetItemString("DEF_Charge") + " (CC)";
                    break;
                case 4:
                    opModeName = LocalLanguage.GetItemString("DEF_Charge") + " (CCCV)";
                    break;
                case 8:
                    opModeName = LocalLanguage.GetItemString("DEF_Discharge") + " (CC)";
                    break;
                case 16:
                    opModeName = LocalLanguage.GetItemString("DEF_Discharge") + " (CCCV)";
                    break;
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
                    statusName = LocalLanguage.GetItemString("DEF_Control_Mode").Replace(" :", "");
                    break;
                case "M":
                    statusName = LocalLanguage.GetItemString("DEF_Maintenance_Mode");
                    break;
                case "I":
                    statusName = LocalLanguage.GetItemString("DEF_Idle");
                    break;
                case "R":
                    statusName = LocalLanguage.GetItemString("DEF_Running");
                    break;
                case "T":
                    statusName = LocalLanguage.GetItemString("DEF_Machine_Trouble");
                    break;
                case "P":
                    statusName = LocalLanguage.GetItemString("DEF_Pause");
                    break;
                case "S":
                    statusName = LocalLanguage.GetItemString("DEF_Stop");
                    break;
                case "L":
                    statusName = LocalLanguage.GetItemString("DEF_Loading");
                    break;
                case "F":
                    statusName = $"{LocalLanguage.GetItemString("DEF_Fire")}\r\n{LocalLanguage.GetItemString("DEF_Temperature_Alarm_Only")}";
                    break;
                case "F2":
                    statusName = $"{LocalLanguage.GetItemString("DEF_Fire2")}\r\n{LocalLanguage.GetItemString("DEF_Smoke_Only_or_Both")}";
                    break;
            }

            return statusName;
        }
        #endregion

        #region GetEqpControlSave
        private string GetEqpControlSave()
        {
            string commandID = string.Empty;

            if (rbStop.Checked)
                commandID = "1";
            else if (rbRestart.Checked)
                commandID = "2";
            else if (rbPause.Checked)
                commandID = "4";
            else if (rbResume.Checked)
                commandID = "8";
            else if (rbForceUnload.Checked)
                commandID = "16";

            return commandID;
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

        #region GetDataClear
        private string GetDataClear()
        {
            string sql = string.Empty;

            // status는 현장가서 확인 해 볼것.
            if (rbClearInfo.Checked)
            {
                sql = "tray_cnt = null, tray_id = null, tray_id_2 = null, start_time = null, end_time = null";
            }
            else if (rbClearTrouble.Checked)
            {
                sql = "eqp_trouble_code = null";
            }

            return sql;
        }
        #endregion

    }
}
