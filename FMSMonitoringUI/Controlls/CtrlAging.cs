using System;
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

namespace MonitoringUI.Monitoring
{
    public partial class CtrlAging : UserControlRoot
    {
        #region [Variable]
        // Timer
        //DispatcherTimer m_timer;
        #endregion

        public CtrlAging()
        {
            InitializeComponent();
            InitTag();
            initAgingRack();


            // Timer 
            //m_timer = new DispatcherTimer();
            //m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Start();

            ctrlButtonDataView.Click += CtrlButtonDataView_Click;

            this.Disposed += CtrlRTAging_Disposed;
        }

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
                } else
                {
                    int selectedIndex = AgingTab.SelectedIndex; 
                    // data load
                    LoadAgingRackData(selectedIndex).GetAwaiter().GetResult();
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

        private async Task LoadAgingRackData(int nSelectedTabIndex=0)
        {
            try
            {

                RESTClient restClinet = new RESTClient();
                JObject loadRackQuery = new JObject();
                //string strSQL = "SELECT A.RackID, ISNULL(A.Status,' ') AS Status , ISNULL(A.FireStatus,' ') AS FireStatus , "
                //    + " A.TrayID, "
                //    + $" (SELECT ISNULL(OperGroupID,' ') FROM tTrayCurr WITH (NOLOCK) WHERE ObjectID = '{CDefine.m_strLineID}' + A.RackID AND TrayID = A.TrayID) OperGroupID , "
                //    + $" (SELECT ISNULL(OperID,' ') FROM tTrayCurr WITH (NOLOCK) WHERE ObjectID = '{CDefine.m_strLineID}' + A.RackID AND TrayID = A.TrayID) OperID  , "
                //    //+ $" ISNULL(A.EndTime,'99991231125959') AS PlanTime FROM tMstAgingRack A WITH (NOLOCK) WHERE RackID LIKE 'R%' AND A.LineID = '{CDefine.m_strLineID}' ORDER BY A.RackID";
                //    + $" ISNULL(A.EndTime,'99991231125959') AS PlanTime FROM tMstAgingRack A WITH (NOLOCK) WHERE A.LineID = '{CDefine.m_strLineID}' ";


                //20200326 KJY - Join Query로 수정
                string strSQL = "SELECT A.RackID, ISNULL(A.Status,' ') AS Status , ISNULL(A.FireStatus,' ') AS FireStatus ,A.TrayID, "
                   + " ISNULL(B.OperGroupID, ' ') OperGroupID, "
                   + " ISNULL(B.OperID, ' ') OperID, "
                   + " ISNULL(A.EndTime,'99991231125959') AS PlanTime "

                   //20200330 KJY - for DelayTime alarm
                   + " , A.DelayAlarmFlag "
                   + " , C.DelayTime "
                   + " , GetDate() CurrentDBTime "
                   + " , B.RouteID RouteID "
                   + " , B.ProdModel ProdModel "

                   //20200619 KJY - for RouteID Change Reservation
                   + " , A.ReserveRouteIDChageFlag "
                   + " , A.ReservedRouteID "
                   + " , A.ReservedProcID "


                   //20210429 KJY - tTrayCurr의 CellType도 가져온다.. 공트레이일경우 305, 322 구분을 위해
                   + " , B.CellType "

                   //20211118 KJY - DummyFlag 를 MES의 Marked Tray 구분에 사용한다.
                   + " , B.DummyFlag "


                   + " FROM tMstAgingRack A WITH (NOLOCK) "
                   + " LEFT OUTER JOIN tTrayCurr B WITH(NOLOCK) "

                   // 공트레이는 ObjectID가 없다. 이것때문에 공트레이의 CellType도 가져올수 있게 join where절 바꿔줘야 한다.
                   //+ $" ON B.ObjectID = '{CDefine.m_strLineID}'+ A.RackID AND B.TrayID = A.TrayID "
                   + $" ON (B.ObjectID = '{CDefine.m_strLineID}'+ A.RackID AND B.TrayID = A.TrayID) OR ((B.TrayID = A.TrayID AND B.Flag = 'E')) "


                   //20200330 KJY tMstRecipe join추가 - for DelayTime alarm
                   + " LEFT OUTER JOIN tMstRecipe C WITH(NOLOCK) "
                   + " ON B.ProdModel = c.ProdModel AND C.RouteID = B.RouteID AND C.EqpTypeID = B.EqpTypeID AND C.OperGroupID = B.OperGroupID AND C.OperID = B.OperID "

                   + $" WHERE A.LineID = '{CDefine.m_strLineID}' ";


                // 20190920 KJY - 선택된 tab의 데이터만 가져오도록 수정
                switch (nSelectedTabIndex)
                {
                    case 0:
                        strSQL += " AND ( A.RackID LIKE 'R01%' OR A.RackID LIKE 'R02%' )";
                        break;
                    case 1:
                        strSQL += " AND ( A.RackID LIKE 'R03%' OR A.RackID LIKE 'R04%' )";
                        break;
                    case 2:
                        strSQL += " AND ( A.RackID LIKE 'R05%' OR A.RackID LIKE 'R06%' )";
                        break;
                    case 3:
                        strSQL += " AND ( A.RackID LIKE 'R07%' OR A.RackID LIKE 'R08%' )";
                        break;
                    default:
                        strSQL += " AND ( A.RackID LIKE 'R01%' OR A.RackID LIKE 'R02%' )";
                        break;
                }



                // 20190919 위 query에서 order by 가 부하가 많이 걸린다.
                // 이거 빼고, 선택한 탭에서만 데이터 가져오도록 수정하자. TODO

                loadRackQuery["query"] = strSQL;
                var JsonResult = await restClinet.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "query.php", loadRackQuery);
                JsonAgingRackList Racks = JsonConvert.DeserializeObject<JsonAgingRackList>(JsonResult);

                ///////////////////////////////////////////////////////////////
                //
                //20200330 KJY - 여기서 Delay alarm off 결정해야 되지 싶다.
                //
                ///////////////////////////////////////////////////////////////
                foreach (JsonAgingRack rack in Racks.AgingRackList)
                {
                    // 상태가 F, U (출고요청) 일경우만 보면 되지 않을까? 
                    if (rack.Status == "F" || rack.Status == "U")
                    {
                        int DelayTime = GetDelayTime(rack.DelayTime);
                        if (DelayTime > 0) // DelayTime이 0 이상으로 설정되어 있을 경우만 확인
                        {
                            if (rack.PlanTime != null && rack.PlanTime.Length == 14)  // 출고 예정시간이 정상적으로 설정되어 있을경우만 확인
                            {
                                if (rack.DelayAlarmFlag == null || rack.DelayAlarmFlag == "0")  // 해당 rack의 DelayAlarmFlag가 설정되어 있지 않는 rack만 확인 (null 이거나 0이 아니면 알람없음)
                                {
                                    DateTime CurrentDBTime = Convert.ToDateTime(rack.CurrentDBTime);
                                    if (rack.PlanTime == "99999999999999") rack.PlanTime = "99991231125959";
                                    DateTime DelayAlarmTime = new DateTime(
                                        int.Parse(rack.PlanTime.Substring(0, 4)),
                                        int.Parse(rack.PlanTime.Substring(4, 2)),
                                        int.Parse(rack.PlanTime.Substring(6, 2)),
                                        int.Parse(rack.PlanTime.Substring(8, 2)),
                                        int.Parse(rack.PlanTime.Substring(10, 2)),
                                        int.Parse(rack.PlanTime.Substring(12, 2))
                                        );
                                    DelayAlarmTime = DelayAlarmTime.AddMinutes(DelayTime);

                                    if (DateTime.Compare(CurrentDBTime, DelayAlarmTime) > 0)
                                    {
                                        // alarm 대상 (현재DB시간보다 알람시간이 더 빠르다)
                                        rack.Status = "A"; // status가 "A"면 출고 Delay

                                    }
                                }
                            }
                        }

                    }
                }



                DataTable RackDT = ToDataTable<JsonAgingRack>(Racks.AgingRackList);

                AgingDataView(RackDT);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadAgingRackData] {0}", ex.ToString()));
            }
        }

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

                    //System.Diagnostics.Debug.Print(string.Format("### Aging Data View : PlanTime : {0}", row["PlanTime"].ToString()));
                    //dtPlanTime = DateTime.Parse(m_string.StringToDateTime(row["PlanTime"].ToString()));
                    if (row["PlanTime"].ToString() == "99999999999999" || row["PlanTime"].ToString() == "99991231235959" || row["PlanTime"].ToString() == "99991231125959" || row["PlanTime"].ToString() == "999912311235959")
                        //dtPlanTime = DateTime.MaxValue;
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
                        rt011.SetDataTable(ref dt);
                        rt012.SetDataTable(ref dt);
                        rt021.SetDataTable(ref dt);
                        rt022.SetDataTable(ref dt);
                        break;
                    case 1:
                        rt031.SetDataTable(ref dt);
                        rt032.SetDataTable(ref dt);
                        rt041.SetDataTable(ref dt);
                        rt042.SetDataTable(ref dt);
                        break;
                    case 2:
                        rt051.SetDataTable(ref dt);
                        rt052.SetDataTable(ref dt);
                        rt061.SetDataTable(ref dt);
                        rt062.SetDataTable(ref dt);
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

        private void initAgingRack()
        {
            // 좌 더블클릭 - Rack 설정
            rt011.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt012.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt021.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt022.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt031.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt032.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt041.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt042.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt051.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt052.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt061.MouseDoubleClick += AgingLineControl_DoubleClick;
            rt062.MouseDoubleClick += AgingLineControl_DoubleClick;

            // 우클릭 - Trouble
            rt011.Click += Rack_Click;
            rt012.Click += Rack_Click;
            rt021.Click += Rack_Click;
            rt022.Click += Rack_Click;
            rt031.Click += Rack_Click;
            rt032.Click += Rack_Click;
            rt041.Click += Rack_Click;
            rt042.Click += Rack_Click;
            rt051.Click += Rack_Click;
            rt052.Click += Rack_Click;
            rt061.Click += Rack_Click;
            rt062.Click += Rack_Click;

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

        private void Rack_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right)
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
                        //WinTroubleInfo troubleInfoWindow = new WinTroubleInfo(CDefine.DEF_EQP_TYPE_ID_AGING, strUnitID);
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
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // MessageBox.Show("show box");
                // Variable
                string strUnitID = "";
                string strTrayID = "";

                //20200401 KJY for Status (출고지연 알람상태전달을 위해)
                string strStatus = string.Empty;

                try
                {
                    //timer Stop
                    m_timer.Stop();

                    // Get agingBay info from Double Clicked object
                    AgingControls.AgingLineControl agingBay = (AgingControls.AgingLineControl)sender;
                    AgingControls.AgingRack rack = agingBay.FindRackOfCurrentMousePosition();

                    if (rack != null)
                    {
                        strUnitID = rack.RackID; 
                        strTrayID = rack.TrayId;

                        //20200401 KJY for Status (출고지연 알람상태전달을 위해)
                        strStatus = rack.StatusString; 

                        // Data Check
                        if (strUnitID.Length < 1) return;

                        // Rack 설정
                        WinAgingRackSetting winAgingRackSetting = new WinAgingRackSetting(CDefine.DEF_AGING_TYPE_RT, strUnitID, strTrayID, strStatus);
                        winAgingRackSetting.ShowDialog();
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
            Tag00.TagText = LocalLanguage.GetItemString("strTag00"); // 사용안함

            TagDelayAlarm.TagText = LocalLanguage.GetItemString("strDelayAlarm"); // 출고지연알람

            Tag01.TagText = LocalLanguage.GetItemString("strTag01"); // Empty
            Tag02.TagText = LocalLanguage.GetItemString("strTag02"); // RT 1st Aging
            Tag03.TagText = LocalLanguage.GetItemString("strTag03"); // RT 2nd Aging
            Tag04.TagText = LocalLanguage.GetItemString("strTag04"); // RT 3rd Aging
            Tag05.TagText = LocalLanguage.GetItemString("strTag05"); // RT 4th Aging
            Tag06.TagText = LocalLanguage.GetItemString("strTag06"); // RT 5th Aging

            Tag20.TagText = LocalLanguage.GetItemString("strTag20"); // RT 6th Aging 20191128

            Tag07.TagText = LocalLanguage.GetItemString("strTag07"); // 입고금지
            Tag08.TagText = LocalLanguage.GetItemString("strTag08"); // 출고금지

            //Tag09.TagText = LocalLanguage.GetItemString("strTag09"); // 입고
            Tag09.TagText = LocalLanguage.GetItemString("strGInput"); // 강제입고

            // 20210430 KJY - 공트레이 CellType 305, 322 추가
            Tag091.TagText = LocalLanguage.GetItemString("strGInput") + " (305)"; // 강제입고 (305)
            Tag092.TagText = LocalLanguage.GetItemString("strGInput") + " (322)"; // 강제입고 (322)

            Tag10.TagText = LocalLanguage.GetItemString("strTag10"); // 입고중
            Tag11.TagText = LocalLanguage.GetItemString("strTag11"); // 출고
            Tag12.TagText = LocalLanguage.GetItemString("strTag12"); // 출고중
            Tag13.TagText = LocalLanguage.GetItemString("strTag13"); // 출고대기중
            Tag14.TagText = LocalLanguage.GetItemString("strTag14"); // Bad Rack
            Tag15.TagText = LocalLanguage.GetItemString("strTag15"); // Trouble
            Tag16.TagText = LocalLanguage.GetItemString("strTag16"); // 화재
            Tag17.TagText = LocalLanguage.GetItemString("strTag17"); // 염수통
            Tag18.TagText = LocalLanguage.GetItemString("strTag18"); // 이중입고
            Tag19.TagText = LocalLanguage.GetItemString("strTag19"); // 공출고

        }

        

        private void CtrlButtonDataView_Click(object sender, EventArgs e)
        {
            m_timer.Stop();
            WinAgingInfo winAgingInfo = new WinAgingInfo(CDefine.DEF_AGING_TYPE_RT);
            winAgingInfo.ShowDialog();
            m_timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_timer.Stop();
            WinAgingRackSetting winAgingRackSetting = new WinAgingRackSetting();
            winAgingRackSetting.ShowDialog();
            m_timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_timer.Stop();
            WinTroubleInfo winTroubleInfo = new WinTroubleInfo();
            winTroubleInfo.ShowDialog();
            m_timer.Start();
        }


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
            LoadAgingRackData(selectedIndex).GetAwaiter().GetResult();
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


    }
}
