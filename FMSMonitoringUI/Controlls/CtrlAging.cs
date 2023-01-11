using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MonitoringUI.Common;
using MySql.Data.MySqlClient;
using System.Reflection;
using DBHandler;
using MySqlX.XDevAPI;
using Novasoft.Logger;
using System.Threading;
using FMSMonitoringUI.Monitoring;
using OPCUAClientClassLib;
using ControlGallery;
using FMSMonitoringUI.Controlls;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using MonitoringUI.Controlls.CButton;
using FMSMonitoringUI.Controlls.WindowsForms;

namespace MonitoringUI.Monitoring
{
    public partial class CtrlAging : UserControlRoot
    {
        #region [Variable]
        private MySqlManager _mysql;
        private Logger _Logger;

        private string _AgingType = string.Empty;
        private string _AgingLine = string.Empty;
        #endregion

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public CtrlAging()
        {
            InitializeComponent();

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);

            InitTag();
            InitAgingRack();
            InitGridView();

            // Timer 
            //m_timer.Tick += new EventHandler(OnTimer);
            //m_timer.Stop();

            _mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);

            ctrlButtonDataView.Click += CtrlButtonDataView_Click;

            this.Disposed += CtrlRTAging_Disposed;
        }
        #region CtrlAging_Load
        /// <summary>
        /// Total MonitoringUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlAging_Load(object sender, EventArgs e)
        {
            btnHTAging.BackColor = Color.LightYellow;
            btnHTAging.ForeColor = Color.Black;

            string log = $"Aging Monitoring";
            _Logger.Write(LogLevel.Info, log, LogFileName.AllLog);
        }
        #endregion

        #region AgingTimer
        public void AgingTimer(bool onoff)
        {
            // Timer
            if (onoff)
            {
                //m_timer.Start();

                _TheadVisiable = true;

                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    _ProcessThread = new Thread(() => ProcessThreadCallback());
                    _ProcessThread.IsBackground = true; _ProcessThread.Start();
                }));
            }
            else
            {
                //m_timer.Stop();

                if (_TheadVisiable && this._ProcessThread.IsAlive)
                    this._TheadVisiable = false;

                if (_TheadVisiable)
                    this._ProcessThread.Abort();
            }
        }
        #endregion

        private void CtrlRTAging_Disposed(object sender, EventArgs e)
        {
            m_timer.Stop();

            
        }

        private void CtrlRTAging_HandleDestroyed(object sender, EventArgs e)
        {
            m_timer.Stop();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                m_timer.Stop();

                // RTAging Tab 자동 변환
                if(cbRTAutoChange.Checked)
                {
                    MoveNextRTAgingTab();
                } 
                else
                {
                    int selectedIndex = AgingTab.SelectedIndex;
                    // data load
                    //LoadAgingRackData(selectedIndex).GetAwaiter().GetResult();
                    Task task = LoadAgingRackData();
                }

                if (m_timer.Interval != 5000)
                    m_timer.Interval = 5000;

                m_timer.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
            }
        }

        private void MoveNextRTAgingTab()
        {
            int nIndex = AgingTab.SelectedIndex;
            if (nIndex == (AgingTab.TabCount - 1))
                AgingTab.SelectTab(0);
            else
                AgingTab.SelectTab(nIndex + 1);
        }

        private async Task LoadAgingRackData()
        {
            try
            {
                Task task = AgingDataView();
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadAgingRackData] {0}", ex.ToString()));
            }
        }

        //private async Task LoadAgingRackData(int nSelectedTabIndex=0)
        //{
        //    try
        //    {

        //        RESTClient restClinet = new RESTClient();
        //        JObject loadRackQuery = new JObject();

        //        //20200326 KJY - Join Query로 수정
        //        string strSQL = "SELECT A.RackID, ISNULL(A.Status,' ') AS Status , ISNULL(A.FireStatus,' ') AS FireStatus ,A.TrayID, "
        //           + " ISNULL(B.OperGroupID, ' ') OperGroupID, "
        //           + " ISNULL(B.OperID, ' ') OperID, "
        //           + " ISNULL(A.EndTime,'99991231125959') AS PlanTime "

        //           //20200330 KJY - for DelayTime alarm
        //           + " , A.DelayAlarmFlag "
        //           + " , C.DelayTime "
        //           + " , GetDate() CurrentDBTime "
        //           + " , B.RouteID RouteID "
        //           + " , B.ProdModel ProdModel "

        //           //20200619 KJY - for RouteID Change Reservation
        //           + " , A.ReserveRouteIDChageFlag "
        //           + " , A.ReservedRouteID "
        //           + " , A.ReservedProcID "


        //           //20210429 KJY - tTrayCurr의 CellType도 가져온다.. 공트레이일경우 305, 322 구분을 위해
        //           + " , B.CellType "

        //           //20211118 KJY - DummyFlag 를 MES의 Marked Tray 구분에 사용한다.
        //           + " , B.DummyFlag "


        //           + " FROM tMstAgingRack A WITH (NOLOCK) "
        //           + " LEFT OUTER JOIN tTrayCurr B WITH(NOLOCK) "

        //           // 공트레이는 ObjectID가 없다. 이것때문에 공트레이의 CellType도 가져올수 있게 join where절 바꿔줘야 한다.
        //           //+ $" ON B.ObjectID = '{CDefine.m_strLineID}'+ A.RackID AND B.TrayID = A.TrayID "
        //           + $" ON (B.ObjectID = '{CDefine.m_strLineID}'+ A.RackID AND B.TrayID = A.TrayID) OR ((B.TrayID = A.TrayID AND B.Flag = 'E')) "


        //           //20200330 KJY tMstRecipe join추가 - for DelayTime alarm
        //           + " LEFT OUTER JOIN tMstRecipe C WITH(NOLOCK) "
        //           + " ON B.ProdModel = c.ProdModel AND C.RouteID = B.RouteID AND C.EqpTypeID = B.EqpTypeID AND C.OperGroupID = B.OperGroupID AND C.OperID = B.OperID "

        //           + $" WHERE A.LineID = '{CDefine.m_strLineID}' ";


        //        // 20190920 KJY - 선택된 tab의 데이터만 가져오도록 수정
        //        switch (nSelectedTabIndex)
        //        {
        //            case 0:
        //                strSQL += " AND ( A.RackID LIKE 'R01%' OR A.RackID LIKE 'R02%' )";
        //                break;
        //            case 1:
        //                strSQL += " AND ( A.RackID LIKE 'R03%' OR A.RackID LIKE 'R04%' )";
        //                break;
        //            case 2:
        //                strSQL += " AND ( A.RackID LIKE 'R05%' OR A.RackID LIKE 'R06%' )";
        //                break;
        //            case 3:
        //                strSQL += " AND ( A.RackID LIKE 'R07%' OR A.RackID LIKE 'R08%' )";
        //                break;
        //            default:
        //                strSQL += " AND ( A.RackID LIKE 'R01%' OR A.RackID LIKE 'R02%' )";
        //                break;
        //        }



        //        // 20190919 위 query에서 order by 가 부하가 많이 걸린다.
        //        // 이거 빼고, 선택한 탭에서만 데이터 가져오도록 수정하자. TODO

        //        loadRackQuery["query"] = strSQL;
        //        var JsonResult = await restClinet.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "query.php", loadRackQuery);
        //        JsonAgingRackList Racks = JsonConvert.DeserializeObject<JsonAgingRackList>(JsonResult);

        //        ///////////////////////////////////////////////////////////////
        //        //
        //        //20200330 KJY - 여기서 Delay alarm off 결정해야 되지 싶다.
        //        //
        //        ///////////////////////////////////////////////////////////////
        //        foreach (JsonAgingRack rack in Racks.AgingRackList)
        //        {
        //            // 상태가 F, U (출고요청) 일경우만 보면 되지 않을까? 
        //            if (rack.Status == "F" || rack.Status == "U")
        //            {
        //                int DelayTime = GetDelayTime(rack.DelayTime);
        //                if (DelayTime > 0) // DelayTime이 0 이상으로 설정되어 있을 경우만 확인
        //                {
        //                    if (rack.PlanTime != null && rack.PlanTime.Length == 14)  // 출고 예정시간이 정상적으로 설정되어 있을경우만 확인
        //                    {
        //                        if (rack.DelayAlarmFlag == null || rack.DelayAlarmFlag == "0")  // 해당 rack의 DelayAlarmFlag가 설정되어 있지 않는 rack만 확인 (null 이거나 0이 아니면 알람없음)
        //                        {
        //                            DateTime CurrentDBTime = Convert.ToDateTime(rack.CurrentDBTime);
        //                            if (rack.PlanTime == "99999999999999") rack.PlanTime = "99991231125959";
        //                            DateTime DelayAlarmTime = new DateTime(
        //                                int.Parse(rack.PlanTime.Substring(0, 4)),
        //                                int.Parse(rack.PlanTime.Substring(4, 2)),
        //                                int.Parse(rack.PlanTime.Substring(6, 2)),
        //                                int.Parse(rack.PlanTime.Substring(8, 2)),
        //                                int.Parse(rack.PlanTime.Substring(10, 2)),
        //                                int.Parse(rack.PlanTime.Substring(12, 2))
        //                                );
        //                            DelayAlarmTime = DelayAlarmTime.AddMinutes(DelayTime);

        //                            if (DateTime.Compare(CurrentDBTime, DelayAlarmTime) > 0)
        //                            {
        //                                // alarm 대상 (현재DB시간보다 알람시간이 더 빠르다)
        //                                rack.Status = "A"; // status가 "A"면 출고 Delay

        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //        }



        //        DataTable RackDT = ToDataTable<JsonAgingRack>(Racks.AgingRackList);

        //        AgingDataView(RackDT);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(string.Format("[Exception:LoadAgingRackData] {0}", ex.ToString()));
        //    }
        //}

        public int GetDelayTime(string strDelayTime)
        {
            int iDelayTime = 0;

            if (strDelayTime == null) return 0;
            if (strDelayTime.Trim().Length == 0) return 0;
            if (strDelayTime.Trim() == "NULL" || strDelayTime.Trim() == "null") return 0;

            try
            {
                iDelayTime = int.Parse(strDelayTime.Trim());
            }
            catch
            {
                return 0;
            }

            return iDelayTime;
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #region [Aging Data View]
        /////////////////////////////////////////////////////////////////////////////
        //  Aging Data View
        //===========================================================================  
        private async Task<bool> AgingDataView()
        {
            try
            {
                //if (this.InvokeRequired)
                {
                    await Task.Run(() =>
                    {
                        //this.BeginInvoke(new Action(() =>
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            //선택된 Tab의 데이터만 Load하자.
                            int nSelectedIndex = AgingTab.SelectedIndex;

                            // Set RT Aging
                            switch (nSelectedIndex)
                            {
                                case 0:
                                    ht011.SetDataTable(_mysql.SelectAgingInfo(ht011.LinePrefix));
                                    ht012.SetDataTable(_mysql.SelectAgingInfo(ht012.LinePrefix));
                                    ht013.SetDataTable(_mysql.SelectAgingInfo(ht013.LinePrefix));
                                    ht014.SetDataTable(_mysql.SelectAgingInfo(ht014.LinePrefix));
                                    break;
                                case 1:
                                    lt011.SetDataTable(_mysql.SelectAgingInfo(lt011.LinePrefix));
                                    lt012.SetDataTable(_mysql.SelectAgingInfo(lt012.LinePrefix));
                                    lt013.SetDataTable(_mysql.SelectAgingInfo(lt013.LinePrefix));
                                    lt014.SetDataTable(_mysql.SelectAgingInfo(lt014.LinePrefix));
                                    break;
                                case 2:
                                    lt021.SetDataTable(_mysql.SelectAgingInfo(lt021.LinePrefix));
                                    lt022.SetDataTable(_mysql.SelectAgingInfo(lt022.LinePrefix));
                                    lt023.SetDataTable(_mysql.SelectAgingInfo(lt023.LinePrefix));
                                    lt024.SetDataTable(_mysql.SelectAgingInfo(lt024.LinePrefix));
                                    break;
                            }
                        }));
                    });
                }
            }
            catch (Exception ex)        // 예외처리
            {
                Console.WriteLine(string.Format("[Exception:AgingDataView] {0}", ex.ToString()));
                // Return
                return false;
            }

            // Return
            return true;
        }
        private bool AgingDataView(DataTable dt)
        {
            // Variable
            DateTime dtPlanTime;
            DateTime dtDataBaseTime;
            bool bPlanUnLoad = false;

            // dt 조작 : dt record count 만큼 돌면서 PlanTIme 값으로 bPlanUnLoad 값을 계산하여 dt 에 추가
            // for dt > dt.add("bPlanUnLoad")

            // Get DataBaseTime - 일단 현재시간
            dtDataBaseTime = DateTime.Now;


            // Add columns to Datatable
            dt.Columns.Add("bPlanUnLoad", typeof(bool));

            //foreach (DataRow row in dt.Select(where, orderby))
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    if (row["PlanTime"].ToString() == "99999999999999" || row["PlanTime"].ToString() == "99991231235959" || row["PlanTime"].ToString() == "99991231125959" || row["PlanTime"].ToString() == "999912311235959")
                        dtPlanTime = DateTime.ParseExact("99981230235959", "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                    else
                        dtPlanTime = DateTime.ParseExact(row["PlanTime"].ToString(), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                    if (dtPlanTime < dtDataBaseTime && row["Status"].ToString() != "O")
                        bPlanUnLoad = true;
                    else bPlanUnLoad = false;

                    //Console.WriteLine("["+bPlanUnLoad+"]");
                    row["bPlanUnLoad"] = bPlanUnLoad.ToString().ToLower(); 

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print(string.Format("### Aging Data View : PlanTime Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                    throw;
                }
            }

            try
            {
                //선택된 Tab의 데이터만 Load하자.
                int nSelectedIndex = AgingTab.SelectedIndex;


                // Set RT Aging
                switch(nSelectedIndex)
                {
                    case 0:
                        ht011.SetDataTable(ref dt);
                        ht012.SetDataTable(ref dt);
                        ht013.SetDataTable(ref dt);
                        ht014.SetDataTable(ref dt);
                        break;
                    case 1:
                        lt011.SetDataTable(ref dt);
                        lt012.SetDataTable(ref dt);
                        lt013.SetDataTable(ref dt);
                        lt014.SetDataTable(ref dt);
                        break;
                    case 2:
                        lt021.SetDataTable(ref dt);
                        lt022.SetDataTable(ref dt);
                        lt022.SetDataTable(ref dt);
                        lt024.SetDataTable(ref dt);
                        break;
                }


                // Return
                return true;
            }

            // 예외처리
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:AgingDataView] {0}", ex.ToString()));
                // Return
                return false;
            }
        }
        #endregion

        private void InitAgingRack()
        {
            // 좌 더블클릭 - Rack 설정
            ht011.MouseDoubleClick += AgingLineControl_DoubleClick;
            ht012.MouseDoubleClick += AgingLineControl_DoubleClick;
            ht013.MouseDoubleClick += AgingLineControl_DoubleClick;
            ht014.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt011.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt012.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt013.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt014.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt021.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt022.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt022.MouseDoubleClick += AgingLineControl_DoubleClick;
            lt024.MouseDoubleClick += AgingLineControl_DoubleClick;

            // 우클릭 - Trouble
            ht011.Click += Rack_Click;
            ht012.Click += Rack_Click;
            ht013.Click += Rack_Click;
            ht014.Click += Rack_Click;
            lt011.Click += Rack_Click;
            lt012.Click += Rack_Click;
            lt013.Click += Rack_Click;
            lt014.Click += Rack_Click;
            lt021.Click += Rack_Click;
            lt022.Click += Rack_Click;
            lt023.Click += Rack_Click;
            lt024.Click += Rack_Click;

            /// 
            /// 화면권한 관련
            /// 
            bool bView = false;
            bool bSave = false;
            // 화면ID 설정
            Tag = CAuthority.WindowsNameToWindowID(this.ToString());
            //Get Authority
            CAuthority.GetAuthority(CDefine.m_strLoginID, Tag.ToString(), ref bView, ref bSave);

            ///
            ///
            ///

            initAgingTab_Language();
        }

        private void InitGridView()
        {
            string[] columnName = { "Status Name", "Total Rack Count", "In Aging", "Empty Rack", 
                                    "Unloading Rack", "No Input Rack", "No Output Rack", "Bad Rack", "Tatal Trouble" };

            List<string> lstTitle = new List<string>();

            foreach (var item in columnName)
            {
                lstTitle.Add(item);
            }
            AgingInfoView_HT.AddColumnHeaderList(lstTitle);
            AgingInfoView_LT1.AddColumnHeaderList(lstTitle);
            AgingInfoView_LT2.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Count");
            AgingInfoView_HT.AddRowsHeaderList(lstTitle);
            AgingInfoView_LT1.AddRowsHeaderList(lstTitle);
            AgingInfoView_LT2.AddRowsHeaderList(lstTitle);

            AgingInfoView_HT.ColumnHeadersHeight(30);
            AgingInfoView_HT.RowsHeight(30);
            AgingInfoView_LT1.ColumnHeadersHeight(30);
            AgingInfoView_LT1.RowsHeight(30);
            AgingInfoView_LT2.ColumnHeadersHeight(30);
            AgingInfoView_LT2.RowsHeight(30);

            AgingInfoView_HT.SetGridViewStyles();
            AgingInfoView_HT.ColumnHeadersWidth(0, 140);
            AgingInfoView_LT1.SetGridViewStyles();
            AgingInfoView_LT1.ColumnHeadersWidth(0, 140);
            AgingInfoView_LT2.SetGridViewStyles();
            AgingInfoView_LT2.ColumnHeadersWidth(0, 140);

            AgingTab.SelectedIndex = 0;
            _AgingType = "H";
            _AgingLine = "01";

            //string[] columnName = { "Total Rack Count", "In Aging", "Empty Rack", "Unloading Rack", "No Input Rack","No Output Rack","Bad Rack", "Tatal Trouble"}; 

            //AgingInfoView.EnableHeadersVisualStyles = false;
            //AgingInfoView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 27, 27);

            //AgingInfoView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //AgingInfoView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //for (int i = 0; i < AgingInfoView.ColumnCount; i++)
            //{
            //    AgingInfoView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}

            //for (int i = 0; i < columnName.Length; i++)
            //{
            //    AgingInfoView.Rows.Add(new string[] { columnName[i], "", "", "" });

            //}

            ////AgingInfoView[1, 1].Style.BackColor = Color.White;

            //AgingInfoView.CurrentCell = null;
            //AgingInfoView.ClearSelection();
        }

        private void Rack_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                // MessageBox.Show("show box");
                // Variable
                string strUnitID = null;

                try
                {
                    //timer Stop
                    m_timer.Stop();

                    // Get agingBay info from Double Clicked object
                    AgingControls.AgingLineControl agingBay = (AgingControls.AgingLineControl)sender;
                    AgingControls.AgingRack rack = agingBay.FindRackOfCurrentMousePosition();

                    if (rack != null)
                    {
                        strUnitID = rack.RackID; // +"0";

                        // Data Check
                        if (strUnitID.Length < 1) return;

                        // Trouble Window
                        WinTroubleInfo winTroubleInfo = new WinTroubleInfo(CDefine.DEF_EQP_TYPE_ID_AGING, strUnitID);
                        winTroubleInfo.ShowDialog();
                    }

                    //timer Start
                    m_timer.Start();
                    //CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "CtrlAging_MouseDown : Start Timer");
                }
                catch (Exception ex)
                {
                    // System Debug
                    System.Diagnostics.Debug.Print(string.Format("### CtrlAging MouseDown Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                }
            }
        }

        private void AgingLineControl_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    //timer Stop
                    m_timer.Stop();

                    // Get agingBay info from Double Clicked object
                    AgingControls.AgingLineControl agingBay = (AgingControls.AgingLineControl)sender;
                    AgingControls.AgingRack rack = agingBay.FindRackOfCurrentMousePosition();

                    if (rack != null)
                    {
                        string strRackID = rack.RackID;

                        // Data Check
                        if (strRackID.Length < 1) return;

                        // Rack 설정
                        //WinAgingRackSetting winAgingRackSetting = new WinAgingRackSetting(CDefine.DEF_AGING_TYPE_RT, strUnitID, strTrayID, strStatus);
                        //winAgingRackSetting.ShowDialog();

                        // Rack Info
                        //DataSet ds = _mysql.SelectRackInfo(strRackID);

                        string msg = $"Rack ID : {strRackID}";
                        _Logger.Write(LogLevel.Info, msg, LogFileName.ButtonClick);

                        WinAgingRackSetting winRack = new WinAgingRackSetting(agingBay.EqpID, strRackID);
                        winRack.Show();
                    }

                    //timer Start
                    m_timer.Start();
                    //CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "CtrlAging_MouseDown : Start Timer");
                }
                catch (Exception ex)
                {
                    // System Debug
                    System.Diagnostics.Debug.Print(string.Format("### CtrlAging MouseDown Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                }
            }
        }

        private void InitTag()
        {
            // Tab 메뉴 관리
            int selectedIndex = AgingTab.SelectedIndex;

            //for (int i = 0; i < AgingTab.TabCount; i++)
            //{
            //    string strTabName = $"RT Aging #{(i * 2) + 1}, #{(i * 2) + 2}";
            //    AgingTab.TabPages[i].Text = strTabName;
            //}


            // 랙 상태 Tag
            //Tag00.TagText = LocalLanguage.GetItemString("strTag00"); // 사용안함

            //TagDelayAlarm.TagText = LocalLanguage.GetItemString("strDelayAlarm"); // 출고지연알람

            //Tag01.TagText = LocalLanguage.GetItemString("strTag01"); // Empty
            //Tag02.TagText = LocalLanguage.GetItemString("strTag02"); // RT 1st Aging
            //Tag03.TagText = LocalLanguage.GetItemString("strTag03"); // RT 2nd Aging
            //Tag04.TagText = LocalLanguage.GetItemString("strTag04"); // RT 3rd Aging
            //Tag05.TagText = LocalLanguage.GetItemString("strTag05"); // RT 4th Aging
            //Tag06.TagText = LocalLanguage.GetItemString("strTag06"); // RT 5th Aging

            //Tag20.TagText = LocalLanguage.GetItemString("strTag20"); // RT 6th Aging 20191128

            //Tag07.TagText = LocalLanguage.GetItemString("strTag07"); // 입고금지
            //Tag08.TagText = LocalLanguage.GetItemString("strTag08"); // 출고금지

            ////Tag09.TagText = LocalLanguage.GetItemString("strTag09"); // 입고
            //Tag09.TagText = LocalLanguage.GetItemString("strGInput"); // 강제입고

            //// 20210430 KJY - 공트레이 CellType 305, 322 추가
            //Tag091.TagText = LocalLanguage.GetItemString("strGInput") + " (305)"; // 강제입고 (305)
            //Tag092.TagText = LocalLanguage.GetItemString("strGInput") + " (322)"; // 강제입고 (322)

            //Tag10.TagText = LocalLanguage.GetItemString("strTag10"); // 입고중
            //Tag11.TagText = LocalLanguage.GetItemString("strTag11"); // 출고
            //Tag12.TagText = LocalLanguage.GetItemString("strTag12"); // 출고중
            //Tag13.TagText = LocalLanguage.GetItemString("strTag13"); // 출고대기중
            //Tag14.TagText = LocalLanguage.GetItemString("strTag14"); // Bad Rack
            //Tag15.TagText = LocalLanguage.GetItemString("strTag15"); // Trouble
            //Tag16.TagText = LocalLanguage.GetItemString("strTag16"); // 화재
            //Tag17.TagText = LocalLanguage.GetItemString("strTag17"); // 염수통
            //Tag18.TagText = LocalLanguage.GetItemString("strTag18"); // 이중입고
            //Tag19.TagText = LocalLanguage.GetItemString("strTag19"); // 공출고

        }

        

        private void CtrlButtonDataView_Click(object sender, EventArgs e)
        {
            //m_timer.Stop();
            //WinAgingInfo winAgingInfo = new WinAgingInfo(CDefine.DEF_AGING_TYPE_RT);
            //winAgingInfo.ShowDialog();
            //m_timer.Start();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    m_timer.Stop();
        //    WinAgingRackSetting winAgingRackSetting = new WinAgingRackSetting();
        //    winAgingRackSetting.ShowDialog();
        //    m_timer.Start();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    m_timer.Stop();
        //    WinTroubleInfo winTroubleInfo = new WinTroubleInfo();
        //    winTroubleInfo.ShowDialog();
        //    m_timer.Start();
        //}


        // 탭을 선택하면 눈에 띄게 좀 바꿀라고 했는데 안되네.. 쩝.
        // 이건 나중에 여유 있을때 해보자
         private void AgingTab_SelectedIndexChanged(object sender, EventArgs e)
        {   
            // 선택된 TabPage만 잘 보이게
            int selectedIndex = AgingTab.SelectedIndex;
            for (int i = 0; i < AgingTab.TabCount; i++)
            {
                string strTabName;  // = $"{LocalLanguage.GetItemString("lbMonTabAging")} #{(i * 2) + 1}, #{(i * 2) + 2}";

                switch (i)
                {
                    case 0:
                        strTabName = $"HT {LocalLanguage.GetItemString("lbMonTabAging")}";
                        break;
                    default:
                        strTabName = $"LT {LocalLanguage.GetItemString("lbMonTabAging")} #{i}";
                        break;
                }
                AgingTab.TabPages[i].Text = strTabName;
                if(i==selectedIndex)
                {
                    AgingTab.TabPages[i].ForeColor = Color.Blue;
                }
                else
                {
                    AgingTab.TabPages[i].ForeColor = Color.Black;
                }
            }
            //LoadAgingRackData(selectedIndex).GetAwaiter().GetResult();
            Task task = LoadAgingRackData();
        }

        /// <summary>
        /// Loading시 Aging Tab Title에 언어적용
        /// </summary>
        private void initAgingTab_Language()
        {
            string strTabName;  // = $"{LocalLanguage.GetItemString("lbMonTabAging")} #{(i * 2) + 1}, #{(i * 2) + 2}";

            for (int i = 0; i < AgingTab.TabCount; i++)
            {
                switch (i)
                {
                    case 0:
                        strTabName = $"HT {LocalLanguage.GetItemString("lbMonTabAging")}";
                        break;
                    default:
                        strTabName = $"LT {LocalLanguage.GetItemString("lbMonTabAging")} #{i}";
                        break;
                }
                AgingTab.TabPages[i].Text = strTabName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //updateTable();

            //_mysql.UpdateAgingInfo("status", "G", "aging_type", "L");
            //_mysql.UpdateAgingInfo("status", "G", "aging_type", "H");

            //string starttime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
            //_mysql.UpdateAgingInfo("start_time", starttime, "aging_type", "H");
            //_mysql.UpdateAgingInfo("start_time", starttime, "aging_type", "L");

            //Thread.Sleep(5000);

            //starttime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
            //_mysql.UpdateAgingInfo("end_time", starttime, "aging_type", "H");
            //_mysql.UpdateAgingInfo("end_time", starttime, "aging_type", "L");

            //_mysql.UpdateAgingInfo("tray_cnt", "2", "aging_type", "H");
            //_mysql.UpdateAgingInfo("tray_cnt", "2", "aging_type", "L");
        }

        private void updateTable()
        {
            try
            {
                

                string connection = ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString;

                int idx = 1;
                //accounts_table의 특정 id의 name column과 phone column 데이터를 수정합니다.

                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    for (int line = 1; line <= 4; line++)
                    {
                        for (int bay = 1; bay <= 11; bay++)
                        {
                            for (int deck = 1; deck <= 5; deck++)
                            {
                                //string trayid1 = string.Format($"F101EEFB101{{0:D5}}", idx);
                                //string trayid2 = string.Format($"F101FFFB102{{0:D5}}", idx);
                                //string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                                //                                   $"SET tray_id = '{trayid1}', tray_id_2 = '{trayid2}' " +
                                //                                   $"WHERE aging_type = 'H' AND line = '01' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);


                                //string starttime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                                //string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                                //                                   $"SET start_time = '{starttime}' " +
                                //                                   $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);

                                //string starttime = "G";
                                //string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                                //                                   $"SET status = '{starttime}' " +
                                //                                   $"WHERE aging_type = 'L' AND line = '02' AND lane = '{line}' AND bay = '{{0:D2}}' AND deck = '{{1:D2}}'", bay, deck);



                                //MySqlCommand command = new MySqlCommand(updateQuery, conn);

                                //command.Connection.Open();

                                //command.ExecuteNonQuery();

                                //command.Connection.Close();

                                //if (command.ExecuteNonQuery() != 1)
                                //    MessageBox.Show("Failed to delete data.");

                                idx++;
                            }

                        }
                    }
                }
                

                //_mysql.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #region SetData
        private void SetData(List<_aging_rack_count> data)
        {
            if (data.Count == 0) return;

            int col = 1;

            int selectedIndex = AgingTab.SelectedIndex;
            CtrlDataGridView gridRackCount = new CtrlDataGridView();

            switch (selectedIndex)
            {
                case 0:
                    gridRackCount = AgingInfoView_HT;
                    break;
                case 1:
                    gridRackCount = AgingInfoView_LT1;
                    break;
                case 2:
                    gridRackCount = AgingInfoView_LT2;
                    break;
            }

            gridRackCount.SetValue(col, 0, data[0].TOTAL_RACK_CNT); col++;
            gridRackCount.SetValue(col, 0, data[0].IN_AGING); col++;
            gridRackCount.SetValue(col, 0, data[0].EMPTY_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].UNLOADING_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].NO_INPUT_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].NO_OUTPUT_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].BAD_RACK); col++;
            gridRackCount.SetValue(col, 0, data[0].TOTAL_TROUBLE);
        }
        #endregion

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {

                while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    Task task = LoadAgingRackData();

                    RESTClient rest = new RESTClient();
                    // Set Query
                    StringBuilder strSQL = new StringBuilder();

                    strSQL.Append(" SELECT COUNT(aging_type) AS total_rack_cnt,");
                    strSQL.Append("        COUNT(if(tray_cnt > 0, tray_cnt, null)) AS in_aging,");
                    strSQL.Append("        COUNT(if(tray_cnt = 0, tray_cnt, null)) AS empty_rack,");
                    strSQL.Append("        COUNT(if(status = 'U', status, null)) AS unloading_rack,");
                    strSQL.Append("        COUNT(if(status = 'X', status, null)) AS no_input_rack,");
                    strSQL.Append("        COUNT(if(status = 'O', status, null)) AS no_output_rack,");
                    strSQL.Append("        COUNT(if(status = 'B', status, null)) AS bad_rack,");
                    strSQL.Append("        COUNT(if(status = 'T', status, null)) AS total_trouble");
                    strSQL.Append(" FROM fms_v.tb_mst_aging");
                    //필수값
                    strSQL.Append($" WHERE aging_type = '{_AgingType}' AND line = '{_AgingLine}'");

                    string jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                    if (jsonResult != null)
                    {
                        _jsonAgingRackCountResponse result = rest.ConvertAgingRackCount(jsonResult);

                        this.BeginInvoke(new Action(() => SetData(result.DATA)));
                    }

                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Aging ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        private void selectTable(string connectionAddress)
        {
            try
            {
                //using (MySqlConnection mysql = new MySqlConnection(connectionAddress))
                //{
                //    _mysql.Open();

                //    string where = string.Format("unit_id LIKE '{0}%'", ht011.LinePrefix);
                //    string orderby = "unit_id ASC";

                //    //accounts_table의 전체 데이터를 조회합니다.            
                //    string selectQuery = string.Format($"SELECT * FROM fms_v.tb_mst_aging WHERE {where} ORDER BY {orderby}");

                //    MySqlCommand command = new MySqlCommand(selectQuery, _mysql);
                //    MySqlDataReader table = command.ExecuteReader();

                //    //while (table.Read())
                //    //{
                //    //    string unitid = table["unit_id"].ToString();
                //    //    string trayid1 = table["tray_id_1"].ToString();
                //    //    string trayid2 = table["tray_id_2"].ToString();
                //    //}


                //    //ht011.SetDataTable(ref table);

                //    table.Close();
                //}
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void AgingTab_Click(object sender, EventArgs e)
        {
            CtrlButtonType2 btn = (CtrlButtonType2)sender;
            int tabIdx = int.Parse(btn.Tag.ToString());

            foreach (var ctl in this.Controls)
            {
                if (ctl.GetType() == typeof(CtrlButtonType2))
                {
                    CtrlButtonType2 btnCtrl = ctl as CtrlButtonType2;

                    btnCtrl.BackColor = Color.FromArgb(27, 27, 27);
                    btnCtrl.ForeColor = Color.White;
                }
            }

            btn.BackColor = Color.LightYellow;
            btn.ForeColor = Color.Black;

            AgingTab.SelectedTab = AgingTab.TabPages[tabIdx];

            switch (tabIdx)
            {
                case 0:
                    _AgingType = "H";
                    _AgingLine = "01";
                    break;
                case 1:
                    _AgingType = "L";
                    _AgingLine = "01";
                    break;
                case 2:
                    _AgingType = "L";
                    _AgingLine = "02";
                    break;
                default:
                    break;
            }
        }
    }
}
