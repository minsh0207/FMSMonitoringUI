/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : CtrlProcessMonitoring
//  Create Date	    : 
//  Author			: 
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using MonitoringUI.Common;
using MonitoringUI.Popup;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

#endregion
#region [NameSpace]
namespace MonitoringUI.Monitoring
{
    #region [Class]
    public partial class WinAgingInfo : WinFormRoot
    {
        #region [Variable]
        CString m_string;
        bool m_bLoadFlag;
        string m_strLineID;
        string m_agingType = "R";
        // ProgressBar Window
        WinProgressBar m_progressbarWindow;
        #endregion

        #region [Constructor]
        public WinAgingInfo(string agingType)
        {
            InitializeComponent();
            Initialize();

            m_agingType = agingType;
        }
        #endregion

        #region [Window Event]
        #region [Loaded UserControl_Loaded]
        /// <summary>
        /// UserControl Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, EventArgs e)
        {
            try
            {
                //Init
                InitControl();
                // 조회
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Window Loaded Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "Window Loaded Error Exception " + ex.Message);
            }
        }
        #endregion
        #endregion

        #region [Init]
        #region [Initialize]
        /// <summary>
        /// Variable Menber Init
        /// </summary>
        private void Initialize()
        {
            try
            {
                // 화면ID 설정
                this.Tag = CAuthority.WindowsNameToWindowID(this.ToString());
                //LocalLanguage
                titBar.TitleText = LocalLanguage.GetItemString("titleAgingInfo");

                //RouteID 변경예약 트레이만
                cbReserved.Text = LocalLanguage.GetItemString("strReservedRouteIDTrayOnly");

                //Class Create
                m_string = new CString();

                m_bLoadFlag = false;
                m_strLineID = CDefine.m_strLineID;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Window Initialize Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }

        #endregion

        #region [InitControl]
        /////////////////////////////////////////////////////////////////////
        //	Init Control
        //===================================================================
        private void InitControl()
        {
            //Event Handler
            cboModel.OnCboItemChanged += cboModel_SelectionChanged;
            cboRoute.OnCboItemChanged += cboRoute_SelectionChanged;
            cboLotID.OnCboItemChanged += cboLotID_SelectionChanged;
            cboProc.OnCboItemChanged += cboProc_SelectionChanged;
            txtTrayID.OnTextBoxKeyDownEvent += txtTrayID_OnTextBoxKeyDownEvent;

            cboModel.InitComboBoxList(false);

            string strFilter = m_string.FilterStringADD("ProdModel", cboModel.SelectedKeyString, enTableWhere.WHERE, enTableWhereState.EQUALS);
            string strOrder = "DefaultFlag DESC";
            cboRoute.InitComboBoxList(false, strFilter, strOrder);

            strFilter = "";
            strFilter += m_string.FilterStringADD("ProdModel", cboModel.SelectedKeyString, enTableWhere.WHERE, enTableWhereState.EQUALS);
            strFilter += m_string.FilterStringADD("RouteID", cboRoute.SelectedKeyString, enTableWhere.AND, enTableWhereState.EQUALS);
            //strFilter += m_string.FilterStringADD("EqpTypeID", "0", enTableWhere.AND, enTableWhereState.DIFF);
            //strFilter += m_string.FilterStringADD("OperGroupID", "0", enTableWhere.AND, enTableWhereState.DIFF);
            // 20190314 KJY - Aging 공정만 가져오자
            strFilter += m_string.FilterStringADD("EqpTypeID", "3", enTableWhere.AND, enTableWhereState.EQUALS);
            strFilter += m_string.FilterStringADD("OperGroupID", "0", enTableWhere.AND, enTableWhereState.DIFF);
            strFilter += m_string.FilterStringADD("OperID", "0", enTableWhere.AND, enTableWhereState.DIFF);

            // order by 수정 , DefaultFlag는 없는것 같은데...
            strOrder = "EqpTypeID, OperGroupID, OperID ASC";

            cboProc.InitComboBoxList(true, strFilter, strOrder);

            cboLotID.InitComboBoxListQuery(true, GetLotFilter());

            // 19/8/31 날짜 검색 제거 요청
            //dtpDate.StartDate = DateTime.Now.AddDays(-1);
            //dtpDate.EndDate = DateTime.Now.AddDays(3);
            //lbDateRange.Text = LocalLanguage.GetItemString("strSearchDateLimit5Day"); //조회기간(5일)

            string ass = string.Empty;

            /// 
            /// 화면권한 관련
            /// 
            bool bView = false;
            bool bSave = false;
            // 화면ID 설정
            Tag = CAuthority.WindowsNameToWindowID(this.GetType().FullName.ToString());
            //Get Authority
            CAuthority.GetAuthority(CDefine.m_strLoginID, Tag.ToString(), ref bView, ref bSave);
            this.WindowID = Tag.ToString();
            ///
            ///
            ///

            btModify.LabelText = LocalLanguage.GetItemString("strTag08"); // 출고 금지 
            //btModify.Visible = false;

        }
        #endregion

        #region InitGrid
        private void InitGridView()
        {
            try
            {
                int nCol = 0;

                // Grid Data View, init
                gridList.Init(ScrollBars.Both, DataGridViewSelectionMode.CellSelect, true);

                List<string> lstTitle = new List<string>();
                lstTitle.Add("Flag");     //""
                lstTitle.Add("DEF_SPREAD_087");     //Tray ID
                lstTitle.Add("DEF_SPREAD_086");     //LOT ID
                lstTitle.Add("DEF_SPREAD_102");     //Model
                lstTitle.Add("DEF_SPREAD_011");     //RouteID
                lstTitle.Add("DEF_CONTROL_073");    //Rack ID
                lstTitle.Add("DEF_CONTROL_189");    //현재공정
                lstTitle.Add("DEF_CONTROL_085");    //다음공정

                lstTitle.Add("DEF_CONTROL_070");        //StartTime

                lstTitle.Add("strPlanTime");        //Plan Time
                lstTitle.Add("DEF_CONTROL_053");    //설비상태
                lstTitle.Add("DEF_CONTROL_114");    //현재 Cell 수량

                

                //20200619 KJY - for RouteID 변경 예약
                lstTitle.Add("strReservedRouteID");    //예약된 RouteID
                lstTitle.Add("strReservedProc");    //예약된 공정명

                //20191114 KJY - 출고금지 checkbox 여부
                lstTitle.Add("strTag08");    //출고금지


                gridList.AddHighHeaderList(lstTitle);

                // Grid Data View, init
                gridList.Init(ScrollBars.Both, DataGridViewSelectionMode.CellSelect, true);
                //Init
                nCol = -1;
                //Cell Type Set
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, lstTitle[nCol], false, false, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256);

                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256); // StartTime

                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, lstTitle[nCol], true, true, 256);
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, lstTitle[nCol], true, true, 256);

                

                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256); //예약 RouteID
                nCol++; gridList.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, lstTitle[nCol], true, true, 256); //예약 Proc명


                //20191114 KJY - 출고금지 checkbox
                nCol++; gridList.ColumnType(enSpreadColumnType.CheckBox, DataGridViewContentAlignment.MiddleCenter, 80, lstTitle[nCol], false, true, 256);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### Init Control Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #endregion

        #region [Button & Action Event]

        #region [txtTrayID_OnTextBoxKeyDownEvent]
        /// <summary>
        /// CtrlTextBoxRoot Handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTrayID_OnTextBoxKeyDownEvent(object sender, KeyEventArgs e)
        {
            // Enter Key 입력시 btnSearch_Click
            if (e.KeyCode != Keys.Enter) return;

            // 조회
            btnSearch_Click(sender, null);
        }
        #endregion

        #region [공정명 cboProc_SelectionChanged]
        private void cboProc_SelectionChanged(string strID, string strValue)
        {
            // Load 이면 패스
            if (m_bLoadFlag) return;

            // 조회
            //btnSearch_Click(sender, null);
        }
        #endregion

        #region [LOTID cboLotID_SelectionChanged]
        private void cboLotID_SelectionChanged(string strID, string strValue)
        {
            // Load 이면 패스
            if (m_bLoadFlag) return;

            // 조회
            //btnSearch_Click(sender, null);
        }
        #endregion

        #region [Model cboModel_SelectionChanged]
        private void cboModel_SelectionChanged(string strID, string strValue)
        {
            try
            {
                // Load 이면 패스
                if (m_bLoadFlag) return;

                string strFilter = m_string.FilterStringADD("ProdModel", cboModel.SelectedKeyString, enTableWhere.WHERE, enTableWhereState.EQUALS);
                string strOrder = "DefaultFlag DESC";

                cboRoute.InitComboBoxList(false, strFilter, strOrder);
                cboLotID.InitComboBoxListQuery(true, GetLotFilter());
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Model Selection Change Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Route cboRoute_SelectionChanged]
        private void cboRoute_SelectionChanged(string strID, string strValue)
        {
            // Load 이면 패스
            if (m_bLoadFlag) return;

            string strFilter = null;
            string strOrder = "RowNumber ASC";

            strFilter += m_string.FilterStringADD("ProdModel", cboModel.SelectedKeyString, enTableWhere.WHERE, enTableWhereState.EQUALS);
            strFilter += m_string.FilterStringADD("RouteID", cboRoute.SelectedKeyString, enTableWhere.AND, enTableWhereState.EQUALS);
            strFilter += m_string.FilterStringADD("EqpTypeID", "3", enTableWhere.AND, enTableWhereState.EQUALS);
            strFilter += m_string.FilterStringADD("OperGroupID", "0", enTableWhere.AND, enTableWhereState.DIFF);
            strFilter += m_string.FilterStringADD("OperID", "0", enTableWhere.AND, enTableWhereState.DIFF);

            cboProc.InitComboBoxList(true, strFilter, strOrder);
            cboLotID.InitComboBoxListQuery(true, GetLotFilter());

            //btnSearch_Click(null, null);
        }
        #endregion

        #region [Button Search Click]
        private void btnSearch_Click(object sender, EventArgs e)
        {
            m_bLoadFlag = true;

            DataTable dt = new DataTable();

            try
            {
                // 19/8/31 날짜 검색 제거요청
                //if (!checkDateRange())
                //{
                //    return;
                //}


                // Init GridView
                InitGridView();

                //Aging List Get
                if (SearchAging() == false)
                {
                    throw new Exception("");
                }
                //if (cboLotID.SelectedItem == null)
                //    cboLotID.InitComboBoxListQuery(true, GetLotFilter());
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### btnSearchClick Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }

            m_bLoadFlag = false;
        }
        #endregion

        #region [Button Excel Click]
        private void btnExcel_Click(object sender, EventArgs e)
        {
            gridList.GridViewToExportExcel(LocalLanguage.GetItemString("DEF_CONTROL_023"));
        }
        #endregion

        #region [Button Exit Click]
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #endregion

        #region [Method]
        #region [Search]
        private bool SearchAging()
        {
            List<string> lstData = new List<string>();
            List<string> lstVar = new List<string>();
            try
            {
                string strProc = null;
                CString m_string = new CString();

                lstVar.Add(m_strLineID);

                if (txtTrayID.TextData.Length > 0)
                {
                    lstVar.Add(txtTrayID.TextData);
                }
                else
                {
                    lstVar.Add(cboModel.SelectedKeyString);
                    lstVar.Add(cboRoute.SelectedKeyString);
                    lstVar.Add(cboLotID.SelectedKeyString);

                    if (cboProc.SelectedKeyString.Length > 0)
                    {
                        //KJY
                        strProc = cboProc.SelectedKeyString;

                        lstVar.Add(strProc.Substring(0, 1));
                        lstVar.Add(strProc.Substring(1, 1));
                        lstVar.Add(strProc.Substring(2, 1));
                    }
                    else
                    {
                        lstVar.Add("");
                        lstVar.Add("");
                        lstVar.Add("");
                    }
                    //lstVar.Add(m_agingType);
                    if (cbHTAging.Checked == true && cbRTAging.Checked == true)
                    {
                        lstVar.Add("");
                    }
                    else
                    {
                        if(cbHTAging.Checked == true)
                            lstVar.Add("H");
                        else if(cbRTAging.Checked == true)
                            lstVar.Add("R");
                        else
                            lstVar.Add("");
                    }

                    //PlanTime으로 검색 기능 추가 19/08/29 PYG => 19/08/31 다시 검색 기능 제거 요청 
                    //lstVar.Add(m_string.DateStartTime(dtpDate.StartDate, 3));
                    //lstVar.Add(m_string.DateStartTime(dtpDate.EndDate, 3));
                    
                }

                //20200729 KJY - TrayID를 입력해도 lsVar 끝에 하나 더 붙어야 검색이 된다. 바로 위에서 else 밖으로 뺌
                if (cbReserved.Checked == true)
                    lstVar.Add("1");
                else
                    lstVar.Add("");

                JsonProcChangeList jsonProcChangeList = CDatabaseRest.SelectQueryList(enDBTable.WIN_PROC_CHANGE, lstVar) as JsonProcChangeList;

                //Data Check
                if (jsonProcChangeList == null) throw new Exception("");
                if (jsonProcChangeList.code < 0) throw new Exception("");

                int nCnt = 0;

                // Progressbar Window
                m_progressbarWindow = new WinProgressBar(0, jsonProcChangeList.ProcChangeList.Count);
                m_progressbarWindow.Show();

                int nMaxCnt = jsonProcChangeList.ProcChangeList.Count;
                string tmpRackID = string.Empty;

                for (int nRow = 0; nRow < nMaxCnt; nRow++)
                {
                    nCnt++;
                    // Progress
                    m_progressbarWindow.Progress(nCnt);

                    lstData.Clear();
                    lstData.Add("");
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].TrayID);
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].LotID);
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].ProdModel);
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].RouteID);
                    //lstData.Add(jsonProcChangeList.ProcChangeList[nRow].RackID);
                    tmpRackID = jsonProcChangeList.ProcChangeList[nRow].RackID;     // 19.05.23 PYG : RackID 표시 수정.
                    lstData.Add(string.Concat(tmpRackID.Substring(0,3), "-", tmpRackID.Substring(3,1), "-", tmpRackID.Substring(4,2), "-", tmpRackID.Substring(6,2)));
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].NowOperName);
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].NextOperName);


                    //20190923 KJY - StartTime 추가
                    lstData.Add(m_string.StringToDateTime(jsonProcChangeList.ProcChangeList[nRow].StartTime));

                    lstData.Add(m_string.StringToDateTime(jsonProcChangeList.ProcChangeList[nRow].EndTime));
                    lstData.Add(GetAgingRackStatusName(jsonProcChangeList.ProcChangeList[nRow].FireStatus, jsonProcChangeList.ProcChangeList[nRow].Status));
                    // 20190824 PYG : Aging 공정 Tray의 CurrCell Cnt 항목 추가 
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].CurrCellCnt);

                    //Null Ref Error
                    // 20190314 KJY - lstData[5]에 null이 들어오면 null point exception
                    //if (lstData[5].Length < 1 && jsonProcChangeList.ProcChangeList[nRow].DefNowOperName != null)
                    if (lstData[5] == null && jsonProcChangeList.ProcChangeList[nRow].DefNowOperName != null)
                    {
                        lstData[5] = lstData[5].Length > 0 ? lstData[5] : jsonProcChangeList.ProcChangeList[nRow].DefNowOperName;
                    }

                    // 20190314 KJY - lstData[6]에 null이 들어오면 null point exception
                    //if (lstData[6].Length < 1 && jsonProcChangeList.ProcChangeList[nRow].DefNextOperName != null)
                    if (lstData[6] == null && jsonProcChangeList.ProcChangeList[nRow].DefNextOperName != null)
                    {
                        lstData[6] = lstData[6].Length > 0 ? lstData[6] : jsonProcChangeList.ProcChangeList[nRow].DefNextOperName;
                    }


                    //20200619 KJY - RouteID 변경 예약
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].ReservedRouteID);
                    //lstData.Add(jsonProcChangeList.ProcChangeList[nRow].ReservedProcID);
                    lstData.Add(jsonProcChangeList.ProcChangeList[nRow].DefReservedOperName);


                    gridList.CustRowADDHeaderNumber(lstData);
                }
                m_progressbarWindow?.Exit();
                return true;
            }
            catch (Exception ex)
            {
                m_progressbarWindow?.Exit();
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Proc History Data View Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return false;
            }
        }
        #endregion

        #region [Get Aging Rack Status Name]
        /////////////////////////////////////////////////////////////////////
        //	Get Unit Statis Name
        //===================================================================
        private string GetAgingRackStatusName(string strFireStatus, string strStatus)
        {
            // Variable
            string strStatusName = "";

            try
            {
                // Status Name Setting
                switch (strStatus)
                {
                    case "E":
                        strStatusName = "Empty";
                        break;
                    case "B":
                        strStatusName = "Bad Rack";
                        break;
                    case "R":
                        strStatusName = "Reserve";
                        break;
                    case "F":
                        strStatusName = LocalLanguage.GetItemString("strUnderProcessing"); // 공정중
                        break;
                    case "U":
                        strStatusName = LocalLanguage.GetItemString("strTag13"); // 출고대기중
                        break;
                    case "X":
                        strStatusName = "Prohibit Wearing";
                        break;
                    case "T":
                        strStatusName = "Trouble";
                        break;
                    case "W":
                        strStatusName = "Fire Water";
                        break;
                    case "D":
                        strStatusName = "Duplication";
                        break;
                    case "N":
                        strStatusName = "Empty Be Release";
                        break;
                    case "1":
                        strStatusName = "Loading";
                        break;
                    case "2":
                        strStatusName = "Unloading";
                        break;
                    case "O":
                        strStatusName = LocalLanguage.GetItemString("strTag08"); // 출고 금지
                        break;
                    default:
                        strStatusName = strStatus;
                        break;
                }

                switch (strFireStatus)
                {
                    case "F":
                        strStatusName = "Fire";
                        break;
                    case "W":
                        strStatusName = "Fire Water";
                        break;
                }

                // Return
                return strStatusName;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Aging Rack Status Name Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "GetAgingRackStatusName Error Exception : " + ex.Message);

                // Return
                return "";
            }
        }
        #endregion

        #region [Get Lot Filter]
        private List<string> GetLotFilter()
        {
            List<string> lstVar = new List<string>();
            string strStartTime = DateTime.Now.AddMonths(-2).ToString("yyyyMMddHHmmss");
            string strEndTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            lstVar.Add("Y");
            
            //20191029 KJY - 불필요한 날자 조건 제거
            //lstVar.Add(strStartTime);
            //lstVar.Add(strEndTime);
            lstVar.Add("");
            lstVar.Add("");
            lstVar.Add(m_strLineID);
            

            lstVar.Add(cboModel.SelectedKeyString);
            lstVar.Add(cboRoute.SelectedKeyString);
            return lstVar;
        }
        #endregion

        #region [Check Search Date Range]
        private bool checkDateRange()
        {
            DateTime dtStart = dtpDate.StartDate;
            DateTime dtEnd = dtpDate.EndDate;

            TimeSpan TP = dtEnd.Subtract(dtStart);

            //if (TP.TotalHours > 24)
            //    return false;

            if (TP.TotalDays > 5)
                return false;

            return true;
        }
        #endregion

        #endregion

        private void gridList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            string strTrayID = string.Empty;
            string strUnitID = string.Empty;
            string strAgingType = string.Empty;
            string strRackNumber = string.Empty;


            try
            {
                strTrayID = gridList.GetCellData(e.RowIndex, 1);
                strRackNumber = gridList.GetCellData(e.RowIndex, 5);
                if (strRackNumber.Length > 0)
                {
                    strUnitID = strRackNumber.Replace("-", "");
                    strAgingType = strRackNumber.Substring(0, 1);

                    // Rack 설정
                    WinAgingRackSetting winAgingRackSetting = new WinAgingRackSetting(strAgingType, strUnitID, strTrayID);
                    winAgingRackSetting.ShowDialog();
                }

                
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Aging List DoubleClick Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return;
            }

        }

        private void btModify_Click(object sender, EventArgs e)
        {
            
            // 일단 정말 할꺼냐고 물어보고
            if (CMessage.MsgQuestionYN(LocalLanguage.GetItemString("DEF_MSG_29")).ToString().ToUpper() != "YES") return; //데이터 변경사항을 저장하시겠습니까?

            // 로그인 되는지 보고... 
            //=======================================================================
            //  저장/삭제 사번 입력
            //-----------------------------------------------------------------------
            string strSaveUserID = null;
            string strEventStr = string.Empty;

            WinSaveLogin saveLogin = new WinSaveLogin();
            saveLogin.ShowDialog();

            if (CDefine.m_strSaveLoginID.Length < 1) return;
            strSaveUserID = CDefine.m_strSaveLoginID;

            ///
            bool bView = false;
            bool bSave = false;
            //Get Authority
            CAuthority.GetAuthority(strSaveUserID, Tag.ToString(), ref bView, ref bSave);
            if (bSave == false)
            {
                // 권한이 없습니다.
                CMessage.MsgError(LocalLanguage.GetItemString("strNoAuth"));
                return;
            }
            ///

            // 마지막 checkbox 가 edit mode에서 나와서 확인이 된다.
            gridList.ClearSelection();
            if (gridList.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
            {
                gridList.CurrentCell = gridList.Rows[0].Cells[12];
            }
            
            string strRackID = string.Empty;
            string strRackIDList = string.Empty;
            List<string> RackIDs = new List<string>();
            // check된 rackID 들을 가져오고
            foreach (DataGridViewRow row in gridList.Rows)
            {
               

                // rows.Cells[12] 가 CheckBox임
                //if (row.Cells[12] != null && row.Cells[12].Value != null && row.Cells[12].Value.GetType() == typeof(bool))
                if (row.Cells[14] != null && row.Cells[14].Value != null && row.Cells[14].Value.GetType() == typeof(bool))
                {
                    //if ((bool)row.Cells[12].Value == true)
                    if ((bool)row.Cells[14].Value == true)
                    {
                        // 여기서 rackID를 가져오자
                        strRackID = row.Cells[5].Value.ToString();
                        strRackID = strRackID.Replace("-", "");
                        if (strRackID.Length > 0)
                        {
                            RackIDs.Add(strRackID);
                            if (strRackIDList.Length > 0) strRackIDList += $", {strRackID}";
                            else strRackIDList = $"{strRackID}";
                        }
                    }
                }
            }

            if(RackIDs.Count < 1)
            {
                MessageBox.Show("Please Check more than 1");
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
                return;
            }


            //  
            if(SaveRackOutForbidden(RackIDs).GetAwaiter().GetResult() == true)
            {
                strEventStr = $"[Batch Save checked Racks Out-Forbidden] : {strRackIDList}";
                
                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_02")); //정상적으로 데이터를 저장하였습니다.

            } else
            {
                strEventStr = $"[Fail : Batch Save checked Racks Out-Forbidden] : {strRackIDList}";

                CMessage.MsgInformation(LocalLanguage.GetItemString("DEF_MSG_04")); //데이터를 변경하는중 오류가 발생하였습니다.
            }
            CDatabaseRest.DBSaveUserEvent(this.Tag.ToString(), CDefine.DEF_EQP_TYPE_ID_AGING, "", "", strSaveUserID, strEventStr);
            CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.Tag.ToString(), strSaveUserID, strEventStr);

            InitGridView();
            SearchAging();

        }

        private async Task<bool> SaveRackOutForbidden(List<string> RackIDList)
        {
            JObject jsonBody = new JObject();
            string strSet = string.Empty;

            DateTime updtm = DateTime.Now;
            string UpdateTime = updtm.ToString("yyyy-MM-dd HH:mm:ss");

            string inRackID = string.Empty;
            foreach (string row in RackIDList)
            {
                if (inRackID.Length > 0)
                    inRackID += $", '{row}'";
                else
                    inRackID = $"'{row}'";
            }


            strSet = $"Status = 'O', UpdateTime = '{UpdateTime}' ";

            jsonBody["set"] = strSet;
            jsonBody["filter"] = $"LineID = '{CDefine.m_strLineID}' AND RackID IN ({inRackID}) ";

            try
            {
                RESTClient RestClient = new RESTClient();
                var JsonResult = await RestClient.JsonRequest(JsonApiType.Table, JsonCRUD.PATCH, "api.php/tMstAgingRack", jsonBody);
                JsonRequest ret = JsonConvert.DeserializeObject<JsonRequest>(JsonResult);

                if (ret.code >= 1) // Success
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:GetRAckInfo] {0}", e.ToString()));
                return false;
            }



        }


    }
    
    #endregion
}

#endregion