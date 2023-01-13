using ControlGallery;
using CSVMgr;
using DBHandler;
using FMSMonitoringUI.Common;
using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
//using Microsoft.Office.Interop.Excel;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Monitoring;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json.Linq;
using Novasoft.Logger;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Interop;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaSchema;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlMonitoring : UserControlRoot
    {
        #region [Variable]
        private OPCUAClient[] _clientFMS;

        /// <summary>
        /// First=ConveyorNo, Second=Site(Track) Control
        /// </summary>
        private Dictionary<int, CtrlSiteTrack> _ListConveyor = new Dictionary<int, CtrlSiteTrack>();
        /// <summary>
        /// First=CraneNo, Second=Crane Control
        /// </summary>
        private Dictionary<int, CtrlSCraneH> _ListSCrane = new Dictionary<int, CtrlSCraneH>();
        /// <summary>
        /// First=SiteNo(TrackNo), Second=ItemInfo Class
        /// </summary>
        private Dictionary<int, ItemInfo>[] _ListSite = new Dictionary<int, ItemInfo>[CDefine.DEF_PLC_SERVER_COUNT];
        /// <summary>
        /// First=BCRNo, Second=BCRMarker Control
        /// </summary>
        private Dictionary<int, BCRMarker>[] _ListBCR = new Dictionary<int, BCRMarker>[CDefine.DEF_PLC_SERVER_COUNT];

        /// <summary>
        /// First=Equipment ID, Second=Control Index
        /// </summary>
        private Dictionary<string, ItemInfo> _ControlIdx = new Dictionary<string, ItemInfo>();

        /// <summary>
        /// string=Eqp Text, Color=Eqp Status Color
        /// </summary>
        private Dictionary<string, Color> _EqpStatus = new Dictionary<string, Color>();

        /// <summary>
        /// First=Equipment ID, Second=Eqp UserControl
        /// </summary>
        private Dictionary<string, UserControlEqp> _EntireEqpList = new Dictionary<string, UserControlEqp>();
                
        private COPCGroupCtrl _OPCGroupList= new COPCGroupCtrl();

        private Logger _Logger;

        private ApplicationInstance _OPCApplication = null;
        //public ApplicationInstance OPCApplication
        //{
        //    get { return _OPCApplication; }
        //    set { _OPCApplication = value; }
        //}

        private MySqlManager _mysql;

        private int _CVGroupNo = 0;
        private int _CVTrackNo = 0;
        #endregion

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        #region CtrlMain
        public CtrlMonitoring(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

            _OPCApplication = applicationInstance;

            // Timer 
            //m_timer.Tick += new EventHandler(OnTimer);
            //m_timer.Stop();

            _mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);
        }
        #endregion

        #region CtrlMain_Load
        /// <summary>
        /// Total MonitoringUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlMain_Load(object sender, EventArgs e)
        {
            InitMonitoring();
            InitLanguage();

            string msg = $"Full Monitoring";
            _Logger.Write(LogLevel.Info, msg, LogFileName.AllLog);
        }
        #endregion

        #region OnHandleDestroyed
        /// <summary>
        /// UserControl에서 종료시 호출
        /// </summary>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            if (this._TheadVisiable && this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            if (this._TheadVisiable)
                this._ProcessThread.Abort();
        }
        #endregion

        #region ProcessStart
        public void ProcessStart(bool start)
        {
            if (start)
            {
                _TheadVisiable = true;

                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    _ProcessThread = new Thread(() => ProcessThreadCallback());
                    _ProcessThread.IsBackground = true; _ProcessThread.Start();
                }));
            }
            else
            {
                if (this._TheadVisiable && this._ProcessThread.IsAlive)
                    this._TheadVisiable = false;

                if (this._TheadVisiable)
                    this._ProcessThread.Abort();
            }

            // Timer
            //if (onoff) m_timer.Start();
            //else m_timer.Stop();
        }
        #endregion

        #region MonitoringTimer
        public void MonitoringTimer(bool onoff)
        {
            // Timer
            //if (onoff)
            //{
            //    m_timer.Start();
            //}
            //else m_timer.Stop();
        }
        #endregion

        #region InitMonitoring
        private async void InitMonitoring()
        {
            Dictionary<int, List<ItemInfo>> ctrlGroupList = InitControls();

            List<CEqpTagItem> DataList = ReadTagConfig();
            List<COPCUAConfig> opcList = ReadOPCConfig();

            _clientFMS = new OPCUAClient[opcList.Count()];

            for (int i = 0; i < opcList.Count; i++)
            {
                _clientFMS[i] = new OPCUAClient(DataList, _OPCGroupList.GroupList[i], _OPCApplication, _ControlIdx, _ListSite[i]);
                _clientFMS[i].ServerNo = i;

                string msg = ($"Connecting to [{opcList[i].OPCServerURL}] ");
                _Logger.Write(LogLevel.Info, msg, LogFileName.AllLog);

                _clientFMS[i].SubscriptionEvent += CtrlMain_SubscriptionEvent;

                await _clientFMS[i].ConnectAsync(opcList[i].OPCServerURL, opcList[i].UserID, opcList[i].UserPW, opcList[i].FirstNodeID);              

            }
        }

        private void CtrlMain_SubscriptionEvent(int opcIdx, string url)
        {
            _clientFMS[opcIdx].Subscription.DataChanged += new DataChangedEventHandler(Subscription_DataChanged);

            string msg = ($"Subscription Event to [{url}] ");
            _Logger.Write(LogLevel.Info, msg, LogFileName.AllLog);
        }
        #endregion

        #region InitControls
        /// <summary>
        /// UI Control를 초기화 시킨다.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, List<ItemInfo>> InitControls()
        {
            _ListConveyor.Clear();
            _ListSCrane.Clear();
            _ControlIdx.Clear();

            CDeviceInfo[] siteInfo = new CDeviceInfo[CDefine.DEF_PLC_SERVER_COUNT];

            for (int i = 0; i < CDefine.DEF_PLC_SERVER_COUNT; i++)
            {
                _ListSite[i] = new Dictionary<int, ItemInfo>();
                _ListBCR[i] = new Dictionary<int, BCRMarker>();
                siteInfo[i] = new CDeviceInfo();
            }

            //int craneCnt = 0;

            // First=OPCUA Server로 구성된 Conveyor, Second=Site정보
            Dictionary<int, List<ItemInfo>> groupCtrl = new Dictionary<int, List<ItemInfo>>();

            foreach (var ctl in this.panel2.Controls)
            {
                if (ctl.GetType() == typeof(CtrlSiteTrack))
                {
                    CtrlSiteTrack conveyor = ctl as CtrlSiteTrack;
                    conveyor.ObjectDoubleClick += OnObjectDoubleClick;
                    _ListConveyor.Add(conveyor.PLCNo, conveyor);

                    foreach (var site in conveyor.SiteBoxArray)
                    {
                        if (site.SiteNo > 0)
                        {
                            //_ListSite.Add(site.SiteNo, conveyor.PLCNo);

                            int deviceID = conveyor.CVPLCListDeviceID;
                            ItemInfo itemInfo;

                            //if (site.SiteNo == 1)
                            //{
                            //    itemInfo = new ItemInfo()
                            //    {
                            //        SiteNo = site.SiteNo,
                            //        ControlType = enEqpType.CNV,
                            //        GroupNo = deviceID,
                            //        ConveyorNo = conveyor.PLCNo,
                            //        EqpID = GetConveyorEqpID(deviceID)

                            //    };
                            //}
                            //else
                            {
                                itemInfo = new ItemInfo()
                                {
                                    SiteNo = site.SiteNo,
                                    ControlType = enEqpType.CNV,
                                    GroupNo = deviceID,
                                    ConveyorNo = conveyor.PLCNo,
                                    EqpID = GetConveyorEqpID(deviceID)
                                };
                            }

                            _ListSite[deviceID].Add(site.SiteNo, itemInfo);

                            if (groupCtrl.ContainsKey(deviceID))
                            {
                                groupCtrl[deviceID].Add(itemInfo);
                            }
                            else
                            {
                                groupCtrl[deviceID] = new List<ItemInfo> { itemInfo };
                            }

                            siteInfo[deviceID].GroupNo = deviceID;
                            siteInfo[deviceID].AddItem(deviceID, itemInfo);
                            

                            if (!_ControlIdx.ContainsKey(itemInfo.EqpID))
                            {
                                _ControlIdx[itemInfo.EqpID] = itemInfo;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < CDefine.DEF_PLC_SERVER_COUNT; i++)
            {
                if (siteInfo[i].Item.Count > 0)
                {
                    _OPCGroupList.AddList(i, siteInfo[i]);
                }                
            }

            CDeviceInfo[] craneInfo = new CDeviceInfo[CDefine.DEF_PLC_SERVER_COUNT];

            for (int i = 0; i < CDefine.DEF_PLC_SERVER_COUNT; i++)
            {
                craneInfo[i] = new CDeviceInfo();
                _ListBCR[i] = new Dictionary<int, BCRMarker>();
            }

            foreach (var ctl in this.panel2.Controls)
            {
                if (ctl.GetType() == typeof(BCRMarker))
                {
                    BCRMarker bcr = ctl as BCRMarker;
                    //bcr.ObjectDoubleClick += OnObjectDoubleClick;

                    // tray-id bubble text
                    BubbleText bt = new BubbleText();
                    bcr.SetBubbleTextObject(bt, bcr.BCRLevel, bcr.BCRMarkPosition);

                    //
                    _ListBCR[bcr.CVPLCListDeviceID].Add(bcr.PLCNo, bcr);
                    this.Controls.Add(bt);      // Controls에 BubbleText를 추가해줘야 UI에서 Text가 표시된다.
                }
                else if (ctl.GetType() == typeof(CtrlSCraneV))       // RTV 대용으로 사용
                {
                    CtrlSCraneV crane = ctl as CtrlSCraneV;
                    //crane.SetSCHandler(GlobalArea.g_SCHandlerList.Find(x => x.DeviceID == crane.DeviceID));
                    crane.MouseDoubleClick += Crane_MouseDoubleClick;

                    //_ListCrane.Add(crane);
                }
                else if (ctl.GetType() == typeof(CtrlSCraneH))
                {
                    CtrlSCraneH crane = ctl as CtrlSCraneH;
                    //crane.SetSCHandler(GlobalArea.g_SCHandlerList.Find(x => x.DeviceID == crane.DeviceID));
                    crane.MouseDoubleClick += Crane_MouseDoubleClick;

                    _ListSCrane.Add(crane.CraneID, crane);

                    ItemInfo itemInfo = new ItemInfo()
                    {
                        CraneNo = crane.CraneID,
                        ControlType = enEqpType.STC,
                        GroupNo = crane.DeviceID,
                        EqpID = GetCraneEqpID(crane.CraneID)
                    };

                    if (groupCtrl.ContainsKey(itemInfo.GroupNo))
                    {
                        groupCtrl[itemInfo.GroupNo].Add(itemInfo);
                    }
                    else
                    {
                        groupCtrl[itemInfo.GroupNo] = new List<ItemInfo> { itemInfo };
                    }

                    craneInfo[itemInfo.GroupNo].GroupNo = itemInfo.GroupNo;
                    craneInfo[itemInfo.GroupNo].AddItem(itemInfo.GroupNo, itemInfo);

                    if (!_ControlIdx.ContainsKey(itemInfo.EqpID))
                    {
                        _ControlIdx[itemInfo.EqpID] = itemInfo;
                    }

                    //craneCnt++;
                }
                else if (ctl.GetType() == typeof(CtrlEqpCharger) ||
                         ctl.GetType() == typeof(CtrlEqpHPC) ||
                         ctl.GetType() == typeof(CtrlEqpOCV) ||
                         ctl.GetType() == typeof(CtrlEqpDCIR) ||
                         ctl.GetType() == typeof(CtrlEqpMicroCurrent) ||
                         ctl.GetType() == typeof(CtrlEqpDegas) ||
                         ctl.GetType() == typeof(CtrlEqpVisionInsp) ||
                         ctl.GetType() == typeof(CtrlEqpLeakCheck) ||
                         ctl.GetType() == typeof(CtrlEqpNGSorter) ||
                         ctl.GetType() == typeof(CtrlEqpPacking))
                {
                    UserControlEqp eqp = ctl as UserControlEqp;
                    if (_EntireEqpList.ContainsKey(eqp.EqpID) == false)
                    {
                        _EntireEqpList.Add(eqp.EqpID, eqp);
                    }
                }
                //else if (ctl.GetType() == typeof(CtrlEqpCharger))
                //{
                //    CtrlEqpCharger eqp = ctl as CtrlEqpCharger;
                //    foreach (var unitId in eqp.UnitID)
                //    {
                //        _EntireEqpList.Add(unitId, eqp);
                //    }
                //}
            }

            for (int i = 0; i < CDefine.DEF_PLC_SERVER_COUNT; i++)
            {
                if (craneInfo[i].Item.Count > 0)
                {
                    _OPCGroupList.AddList(i, craneInfo[i]);
                }
            }

            ctrlEqpHTAging1.Click_Evnet += CtrlEqpAging_Click;
            ctrlEqpHTAging2.Click_Evnet += CtrlEqpAging_Click;
            ctrlEqpLTAging1.Click_Evnet += CtrlEqpAging_Click;
            ctrlEqpLTAging2.Click_Evnet += CtrlEqpAging_Click;
            ctrlEqpLTAging3.Click_Evnet += CtrlEqpAging_Click;
            ctrlEqpLTAging4.Click_Evnet += CtrlEqpAging_Click;
            //ctrlEqpDGS.MouseClick += CtrlEqp_MouseClick_Evnet;

            //int idx = 0;
            //int groupCnt = groupCtrl.Count();
            //for (int i = groupCnt; i < groupCnt + craneCnt; i++, idx++)
            //{
            //    ItemInfo itemInfo = new ItemInfo()
            //    {
            //        CraneNo = idx,
            //        ControlType = enEqpType.STC,
            //        GroupNo = i
            //    };

            //    groupCtrl[i] = new List<ItemInfo> { itemInfo };
            //}

            _Logger.Write(LogLevel.Info, "Initialize the Controls", LogFileName.AllLog);

            return groupCtrl;
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            // CtrlTaggingName 언어 변환 호출
            foreach (var ctl in panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlTaggingName))
                {
                    CtrlTaggingName tagName = ctl as CtrlTaggingName;
                    tagName.CallLocalLanguage();

                    _EqpStatus.Add(tagName.ColorText, tagName.TagColor);
                }
                else if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel tagName = ctl as CtrlLabel;
                    tagName.CallLocalLanguage();
                }
            }
        }
        #endregion
        

        private void CtrlEqpAging_Click(string eqpId, string eqpType, int level)
        {
            string agingType = string.Empty;
            switch (eqpType)
            {
                case "HTA":
                    agingType = "HT Aging";
                    break;
                case "LTA1":
                    agingType = "LT Aging#1";
                    break;
                case "LTA2":
                    agingType = "LT Aging#2";
                    break;

                default:
                    break;
            }
            WinLeadTime form = new WinLeadTime(eqpId, agingType, level);
            form.ShowDialog();
        }

        private void CtrlEqp_MouseClick_Evnet(object sender, MouseEventArgs e)
        {
            //CtrlEqpDegas gv = (CtrlEqpDegas)sender;

            //gv.TrayInfoView.CurrentCell = null;
            //gv.TrayInfoView.ClearSelection();
            //gv.Refresh();

            //ctrlEqpDGS.Refresh();
        }        

        #region OnTimer
        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                m_timer.Stop();

                //ReadEqpInfo();
                ProcessThreadCallback();

                if (m_timer.Interval != 5000)
                    m_timer.Interval = 5000;
                m_timer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_entire_eqp_list> data)
        {
            if (data.Count == 0) return;

            Dictionary<string, List<_entire_eqp_list>> eqpData = new Dictionary<string, List<_entire_eqp_list>>();

            foreach (var item in data)
            {
                if (eqpData.ContainsKey(item.EQP_ID))
                {
                    eqpData[item.EQP_ID].Add(item);
                }
                else
                {
                    eqpData[item.EQP_ID] = new List<_entire_eqp_list> { item };
                }               
            }

            for (int i = 0; i < _EntireEqpList.Count; i++)
            {
                string eqpid = _EntireEqpList.Keys.ToList()[i];

                if (eqpData.ContainsKey(eqpid))
                {
                    if (eqpid == "F1HPC01")
                    {
                        ctrlEqpHPC1.SetData(eqpData[eqpid], _EqpStatus);
                        ctrlEqpHPC2.SetData(eqpData[eqpid], _EqpStatus);
                    }
                    else
                    {
                        UserControlEqp ctrlEqp = _EntireEqpList[eqpid];
                        ctrlEqp.SetData(eqpData[eqpid], _EqpStatus);
                    }
                }
            }
        }
        // Aging 
        private void SetData(List<_aging_rack_count> data)
        {
            if (data.Count == 0) return;
            int htAging1 = 0;
            int htAging2 = 0;
            int ltAging1 = 0;
            int ltAging2 = 0;
            int ltAging3 = 0;
            int ltAging4 = 0;

            foreach (var aging in data)
            {
                if (aging.AGING_TYPE == "H" && aging.LINE == "01" && aging.LANE == "1")
                {
                    ctrlEqpHTAging1.SetData(aging.TOTAL_RACK_CNT, aging.IN_AGING);
                }
                else if (aging.AGING_TYPE == "H" && aging.LINE == "01" && aging.LANE == "2")
                {
                    ctrlEqpHTAging2.SetData(aging.TOTAL_RACK_CNT, aging.IN_AGING);
                }
                else if (aging.AGING_TYPE == "L" && aging.LINE == "01" && aging.LANE == "1")
                {
                    ctrlEqpLTAging1.SetData(aging.TOTAL_RACK_CNT, aging.IN_AGING);
                }
                else if (aging.AGING_TYPE == "L" && aging.LINE == "01" && aging.LANE == "2")
                {
                    ctrlEqpLTAging2.SetData(aging.TOTAL_RACK_CNT, aging.IN_AGING);
                }
                else if (aging.AGING_TYPE == "L" && aging.LINE == "02" && aging.LANE == "1")
                {
                    ctrlEqpLTAging3.SetData(aging.TOTAL_RACK_CNT, aging.IN_AGING);
                }
                else if (aging.AGING_TYPE == "L" && aging.LINE == "02" && aging.LANE == "2")
                {
                    ctrlEqpLTAging4.SetData(aging.TOTAL_RACK_CNT, aging.IN_AGING);
                }
            }
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

                    RESTClient rest = new RESTClient();
                    //// Set Query
                    StringBuilder strSQL = new StringBuilder();

                    strSQL.Append(" SELECT A.eqp_type, A.eqp_id, A.unit_id, A.eqp_mode, A.eqp_status, A.tray_id,");
                    strSQL.Append("        B.rework_flag, IF(B.tray_id = A.tray_id, '0', '1') AS Level");
                    strSQL.Append("   FROM fms_v.tb_mst_eqp     A ");
                    strSQL.Append("        LEFT OUTER JOIN fms_v.tb_dat_tray B");
                    strSQL.Append("           ON B.tray_id IN (A.tray_id, A.tray_id_2)");
                    //필수값
                    strSQL.Append(" WHERE (A.eqp_type NOT IN ('SCH', 'SCF', 'SCL'))");
                    strSQL.Append("    AND ((A.eqp_type = 'HPC' AND A.unit_id IS NOT NULL)");
                    strSQL.Append("      OR (A.eqp_type = 'CHG' AND A.unit_id IS NOT NULL)");
                    strSQL.Append("      OR (A.eqp_type NOT IN ('HPC', 'CHG')))");

                    var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                    if (jsonResult != null)
                    {
                        _jsonEntireEqpListResponse result = rest.ConvertEntireEqpList(jsonResult.Result);

                        this.BeginInvoke(new Action(() => SetData(result.DATA)));
                    }

                    Thread.Sleep(100);

                    rest = new RESTClient();
                    // Set Query
                    strSQL = new StringBuilder();

                    strSQL.Append(" SELECT aging_type, line, lane,");
                    strSQL.Append("        COUNT(aging_type) AS total_rack_cnt,");
                    strSQL.Append("        COUNT(if(status = 'F', status, null)) AS in_aging");
                    strSQL.Append(" FROM (SELECT line, (");
                    strSQL.Append("           CASE WHEN lane = '1' OR lane = '2' THEN '1'  ELSE '2'END) AS lane,");
                    strSQL.Append("                 aging_type, status FROM fms_v.tb_mst_aging) table1");
                    //필수값
                    strSQL.Append($" WHERE aging_type IN ('H', 'L') AND  line IN ('01', '02') AND  lane IN ('1', '2')");
                    strSQL.Append($" GROUP BY aging_type, line, lane");

                    jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                    if (jsonResult != null)
                    {
                        _jsonAgingRackCountResponse result = rest.ConvertAgingRackCount(jsonResult.Result);

                        this.BeginInvoke(new Action(() => SetData(result.DATA)));
                    }

                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### FormationCHG ProcessThreadCallback Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region ReadConfig
        /// <summary>
        /// TAGS_CLIENT_V1.xlsx TagList를 읽어온다.
        /// </summary>
        /// <returns></returns>
        private List<CEqpTagItem> ReadTagConfig()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\TagList");

            FMSTagConfigReader reader = new FMSTagConfigReader($"{di}{CDefine.CONFIG_FILENAME_TAG}");

            _Logger.Write(LogLevel.Info, $"{di}{CDefine.CONFIG_FILENAME_TAG}", LogFileName.AllLog);

            return reader.Read();
        }
        /// <summary>
        /// OPCUAList.csv에서 OPC Config정보를 읽어온다.
        /// </summary>
        /// <returns></returns>
        private List<COPCUAConfig> ReadOPCConfig()
        {
            CSVLoader csv_opc = new CSVLoader(CDefine.CONFIG_FILENAME_OPCUA);

            _Logger.Write(LogLevel.Info, CDefine.CONFIG_FILENAME_OPCUA, LogFileName.AllLog);

            return csv_opc.Load<COPCUAConfig>();
        }
        #endregion

        #region [Mouse DBLCLK Event]
        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        //List<WinBCRConveyorInfo> forms = new List<WinBCRConveyorInfo>();

        private void OnObjectDoubleClick(object sender, ObjectDoubleClickEventArgs arg)
        {
            try
            {
                int groupno = arg.DeviceInfo.CVPLCListDeviceID;
                int trackno = arg.DeviceInfo.SiteNo;

                _CVGroupNo = groupno;
                _CVTrackNo = trackno;

                if (_clientFMS[groupno] == null) return;
                if (_clientFMS[groupno].ConveyorNodeID == null) return;

                if (trackno > -1 && trackno < 10)      // Water Tank
                {
                    int craneNo = trackno / 2;
                    WinWaterTank winForm = new WinWaterTank(_clientFMS[groupno], craneNo);
                    winForm.Show();
                }
                else
                {
                    //List<ReadValueId> cvInfo = _clientFMS[groupno].ConveyorNodeID[trackno];
                    //List<DataValue> data = _clientFMS[groupno].ReadNodeID(cvInfo);

                    //SiteTagInfo siteInfo = new SiteTagInfo()
                    //{
                    //    ConveyorNo = int.Parse(data[(int)enCVTagList.ConveyorNo].Value.ToString()),
                    //    ConveyorType = int.Parse(data[(int)enCVTagList.ConveyorType].Value.ToString()),
                    //    StationStatus = int.Parse(data[(int)enCVTagList.StationStatus].Value.ToString()),
                    //    TrayIdL1 = data[(int)enCVTagList.TrayIdL1].Value.ToString(),
                    //    TrayIdL2 = data[(int)enCVTagList.TrayIdL2].Value.ToString(),
                    //    TrayCount = int.Parse(data[(int)enCVTagList.TrayCount].Value.ToString()),
                    //    TrayExist = bool.Parse(data[(int)enCVTagList.TrayExist].Value.ToString()),
                    //    TrayType = int.Parse(data[(int)enCVTagList.TrayType].Value.ToString()),
                    //    Destination = int.Parse(data[(int)enCVTagList.Destination].Value.ToString())
                    //};

                    //string msg = $"Track No : {trackno}, TrayIdL1 : {siteInfo.TrayIdL1}, TrayIdL2 : {siteInfo.TrayIdL2}";
                    string msg = $"Track No : {trackno}";
                    _Logger.Write(LogLevel.Info, msg, LogFileName.ButtonClick);

                    if (trackno > 0 && _ListBCR[groupno].ContainsKey(trackno) == false)
                    {
                        WinConveyorInfo winForm = new WinConveyorInfo("Conveyor", _clientFMS[groupno], trackno);
                        winForm.ShowForm();
                    }
                    else
                    {
                        WinBCRConveyorInfo winForm = new WinBCRConveyorInfo(_clientFMS[groupno], trackno);
                        winForm.ShowForm();
                    }
                }

            }
            catch (Exception ex)
            {
                string info = string.Format($"Error={ex}");
                MessageBox.Show(info);
            }
        }

        private void Crane_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CtrlSCrane crane = sender as CtrlSCrane;

            if (_clientFMS[crane.DeviceID] == null || 
                _clientFMS[crane.DeviceID].Connected == false)
            {
                string msg = ($"Connection error to S/Crane OPC Server [{crane.Tag}] ");
                _Logger.Write(LogLevel.Error, msg, LogFileName.ErrorLog);

                MessageBox.Show(msg, "ERROR");

                return;
            }

            try
            {
                if (crane.DeviceID > 0)
                {
                    if (_clientFMS[crane.DeviceID].CraneNodeID != null)
                    {
                        List<ReadValueId> craneInfo = _clientFMS[crane.DeviceID].CraneNodeID[crane.CraneID];
                        List<DataValue> data = _clientFMS[crane.DeviceID].ReadNodeID(craneInfo);

                        //CraneTagInfo item = new CraneTagInfo()
                        //{
                        //    TrayIdL1 = data[(int)enCraneTagList.TrayIdL1].Value.ToString(),
                        //    TrayIdL2 = data[(int)enCraneTagList.TrayIdL2].Value.ToString(),
                        //    TrayCount = int.Parse(data[(int)enCraneTagList.TrayCount].Value.ToString()),
                        //    TrayExist = bool.Parse(data[(int)enCraneTagList.TrayExist].Value.ToString()),
                        //    JobType = int.Parse(data[(int)enCraneTagList.JobType].Value.ToString())
                        //};

                        //string msg = $"Crane No : {crane.CraneID}, TrayIdL1 : {item.TrayIdL1}, TrayIdL2 : {item.TrayIdL2}";
                        string msg = $"Crane No : {crane.CraneID}";
                        _Logger.Write(LogLevel.Info, "", LogFileName.ButtonClick);

                        WinCraneInfo winCrane = new WinCraneInfo(_clientFMS[crane.DeviceID], crane.CraneID);
                        winCrane.ShowForm();

                    }
                }
                else
                {
                    int groupno = crane.DeviceID;
                    int conveyorNo = 101;

                    //List<ReadValueId> cvInfo = _clientFMS[groupno].ConveyorNodeID[conveyorNo];
                    //List<DataValue> data = _clientFMS[groupno].ReadNodeID(cvInfo);

                    //SiteTagInfo siteInfo = new SiteTagInfo()
                    //{
                    //    ConveyorNo = int.Parse(data[(int)enCVTagList.ConveyorNo].Value.ToString()),
                    //    ConveyorType = int.Parse(data[(int)enCVTagList.ConveyorType].Value.ToString()),
                    //    StationStatus = int.Parse(data[(int)enCVTagList.StationStatus].Value.ToString()),
                    //    TrayIdL1 = data[(int)enCVTagList.TrayIdL1].Value.ToString(),
                    //    TrayIdL2 = data[(int)enCVTagList.TrayIdL2].Value.ToString(),
                    //    TrayCount = int.Parse(data[(int)enCVTagList.TrayCount].Value.ToString()),
                    //    TrayExist = bool.Parse(data[(int)enCVTagList.TrayExist].Value.ToString()),
                    //    TrayType = int.Parse(data[(int)enCVTagList.TrayType].Value.ToString()),
                    //    Destination = int.Parse(data[(int)enCVTagList.Destination].Value.ToString())
                    //};

                    WinConveyorInfo winForm = new WinConveyorInfo("RTV", _clientFMS[groupno], conveyorNo);
                    winForm.ShowForm();
                }
            }
            catch (Exception ex)
            {
                string info = string.Format($"Error={ex}");
                MessageBox.Show(info);
            }
        }
        #endregion

        #region Subscription DataChanged
        /// <summary>
        /// Callback to receive data changes from an UA server.
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="e"></param>
        private void Subscription_DataChanged(Subscription subscription, DataChangedEventArgs e)
        {
            if (e.DataChanges.Count > 1)        // 프로그램 기동시 모든 구독목록이 들어온다.
            {
                //return;
                _Logger.Write(LogLevel.Receive, $"Item Count = {e.DataChanges.Count}", LogFileName.AllLog);
            }

            Task task = SubscriptionAsync(e);

            //bool trayExist = false;
            //int pos;
            //Task task;

            //foreach (DataChange change in e.DataChanges)
            //{
            //    ItemInfo item = change.MonitoredItem.UserData as ItemInfo;

            //    string msg = string.Empty;

            //    if (item.BrowseName == "TrayExist")
            //        trayExist = bool.Parse(change.Value.ToString());

            //    if (item.ControlType == enEqpType.CNV)
            //    {
            //        if (trayExist)
            //        {
            //            SiteTagInfo tagInfo = ReadSiteInfo(item);
            //            task = DisplayBCRAsync(item.GroupNo, item.SiteNo, tagInfo);
            //        }

            //        task = StatusConveyorAsync(item.GroupNo, item.SiteNo, trayExist);

            //        msg = string.Format("[{0}-CNV{1:D4}] {2} = {3}",
            //            item.ControlType, item.SiteNo, item.BrowseName, change.Value);
            //    }
            //    else if (item.ControlType == enEqpType.STC)
            //    {
            //        if (item.BrowseName == "PosBay")
            //        {
            //            pos = int.Parse(change.Value.ToString());
            //            task = MoveCraneAsync(_ListSCrane[item.CraneNo], pos);
            //        }
            //        else
            //        {
            //            task = StatusCraneAsync(_ListSCrane[item.CraneNo], trayExist, "C");
            //        }

            //        msg = string.Format("[{0}-CraneNo{1:D2}] {2} = {3}",
            //            item.ControlType, item.CraneNo + 1, item.BrowseName, change.Value);
            //    }
            //    else if (item.ControlType == enEqpType.RTV)
            //    {
            //        if (item.BrowseName == "CarriagePos")
            //        {
            //            pos = int.Parse(change.Value.ToString());
            //            task = MoveCraneAsync(ctrlSCraneV1, pos);
            //        }
            //        else
            //        {
            //            task = StatusCraneAsync(ctrlSCraneV1, trayExist, "RTV");

            //            //if (trayExist)
            //            //{
            //            //    SiteTagInfo tagInfo = ReadSiteInfo(item);
            //            //    task = DisplayBCRAsync(item.SiteNo, tagInfo);
            //            //}

            //            //task = StatusConveyorAsync(item.SiteNo, trayExist);
            //        }

            //        msg = string.Format("[{0}-{1:D2}] {2} = {3}",
            //            item.ControlType, 1, item.BrowseName, change.Value);
            //    }

            //    _Logger.Write(LogLevel.Receive, msg, LogFileName.AllLog);
            //}

            //Refresh();

            //this.BeginInvoke(new Action(() => Refresh()));

            //this.Invoke(new MethodInvoker(delegate ()
            //{
            //    Refresh();
            //}));
        }
        #endregion

        #region ReadSiteInfo
        /// <summary>
        /// Site 정보를 가져온다.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private SiteTagInfo ReadSiteInfo(ItemInfo item)
        {
            List<ReadValueId> cvInfo = _clientFMS[item.GroupNo].ConveyorNodeID[item.SiteNo];
            List<DataValue> data = _clientFMS[item.GroupNo].ReadNodeID(cvInfo);

            SiteTagInfo tagInfo = new SiteTagInfo()
            {
                TrayIdL1 = data[(int)enCVTagList.TrayIdL1].Value.ToString(),
                TrayIdL2 = data[(int)enCVTagList.TrayIdL2].Value.ToString()
            };

            return tagInfo;
        }
        #endregion

        #region EQPTrayInfo
        private void ReadEqpInfo()
        {
            DataSet ds = _mysql.SelectEqpInfo();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string eqpid = row["eqp_id"].ToString();

                if (_EntireEqpList.ContainsKey(eqpid))
                {
                    UserControlEqp userControl = _EntireEqpList[eqpid];
                    //userControl.SetData(row);
                }
            }
        }
        #endregion

        #region MoveCraneAsync
        /// <summary>
        /// Crane 동작 처리
        /// </summary>
        /// <param name="crane"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        private async Task MoveCraneAsync(CtrlSCrane crane, int endPos)
        {
            Task task = MoveCrane(crane, endPos);

            await task;
        }
        private async Task MoveCrane(CtrlSCrane crane, int endPos)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    int startPos = crane.CurrentBay;

                    if (startPos == 0) startPos = endPos;

                    if (startPos < endPos)
                    {
                        for (int i = startPos; i <= endPos; i++)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                crane.CurrentBay = i;
                            }));

                            //this.BeginInvoke(new Action(() =>
                            //{
                            //    crane.CurrentBay = i;
                            //}));

                            Thread.Sleep(100);
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        for (int i = startPos; i >= endPos; i--)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                crane.CurrentBay = i;
                            }));

                            //this.BeginInvoke(new Action(() =>
                            //{
                            //    crane.CurrentBay = i;
                            //}));

                            Thread.Sleep(100);
                            Application.DoEvents();
                        }
                    }
                });
            }
        }
        #endregion

        #region StatusCraneAsync
        private async Task StatusCraneAsync(CtrlSCrane crane, bool trayExist, string craneName)
        {
            Task task = StatusCrane(crane, trayExist, craneName);

            await task;
        }

        private async Task StatusCrane(CtrlSCrane crane, bool trayExist, string craneName)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        crane.UpdateUI(trayExist, craneName);
                    }));

                    //this.BeginInvoke(new Action(() =>
                    //{
                    //    crane.UpdateUI(trayExist, craneName);
                    //}));
                });
            }
        }
        #endregion

        #region StatusConveyorAsync
        private async Task StatusConveyorAsync(int groupno, int siteno, bool trayExist)
        {
            Task task = StatusConveyor(groupno, siteno, trayExist);

            await task;
        }

        private async Task StatusConveyor(int groupno, int siteno, bool trayExist)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        ItemInfo siteInfo = _ListSite[groupno][siteno];

                        if (siteInfo.ConveyorNo > 0)
                        {
                            _ListConveyor[siteInfo.ConveyorNo].UpdateTrackStatus(siteno, trayExist);
                        }

                        //Refresh();
                    }));

                    //this.BeginInvoke(new Action(() =>
                    //{
                    //    ItemInfo siteInfo = _ListSite[groupno][siteno];

                    //    if (siteInfo.ConveyorNo > 0)
                    //    {
                    //        _ListConveyor[siteInfo.ConveyorNo].UpdateTrackStatus(siteno, trayExist);
                    //    }
                    //}));
                });
            }


        }
        #endregion

        #region DisplayBCRAsync
        /// <summary>
        /// BCRMarker Control에 TrayID를 표시한다.
        /// </summary>
        /// <param name="crane"></param>
        /// <param name="trayExist"></param>
        /// <param name="craneName"></param>
        /// <returns></returns>
        private async Task DisplayBCRAsync(int deviceID, int bcrno, SiteTagInfo tagInfo)
        {
            Task task = DisplayBCR(deviceID, bcrno, tagInfo);

            await task;
        }

        private async Task DisplayBCR(int deviceID, int bcrno, SiteTagInfo tagInfo)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (_ListBCR[deviceID].ContainsKey(bcrno))
                        {
                            BCRMarker bcr_ui = _ListBCR[deviceID][bcrno];

                            if (bcr_ui.BCRLevel == 1)
                            {
                                bcr_ui.BubbleText = string.Format($"{tagInfo.TrayIdL1}");
                            }
                            else
                            {
                                bcr_ui.BubbleText = string.Format($"{tagInfo.TrayIdL1}\n{tagInfo.TrayIdL2}");
                            }

                            if (bcr_ui.BubbleText != null && bcr_ui.BubbleText.Length > 0)
                            {
                                bcr_ui.ShowToolTip();
                                bcr_ui.BubbleText = string.Empty;
                            }

                            bcr_ui.BCRUseYN = true;
                        }
                    }));

                    //this.BeginInvoke(new Action(() =>
                    //{
                    //    if (_ListBCR[deviceID].ContainsKey(bcrno))
                    //    {
                    //        BCRMarker bcr_ui = _ListBCR[deviceID][bcrno];

                    //        if (bcr_ui.BCRLevel == 1)
                    //        {
                    //            bcr_ui.BubbleText = string.Format($"{tagInfo.TrayIdL1}");
                    //        }
                    //        else
                    //        {
                    //            bcr_ui.BubbleText = string.Format($"{tagInfo.TrayIdL1}\n{tagInfo.TrayIdL2}");
                    //        }

                    //        if (bcr_ui.BubbleText != null && bcr_ui.BubbleText.Length > 0)
                    //        {
                    //            bcr_ui.ShowToolTip();
                    //            bcr_ui.BubbleText = string.Empty;
                    //        }

                    //        bcr_ui.BCRUseYN = true;
                    //    }
                    //}));
                });
            }
        }
        #endregion

        #region WinTrayInfo
        /// <summary>
        /// Crane 동작 처리
        /// </summary>
        /// <param name="crane"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        private async Task SubscriptionAsync(DataChangedEventArgs e)
        {
            await SubscriptionDataChange(e);
        }
        private async Task SubscriptionDataChange(DataChangedEventArgs e)
        {
            //if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    bool trayExist = false;
                    int pos;
                    Task task;

                    foreach (DataChange change in e.DataChanges)
                    {
                        ItemInfo item = change.MonitoredItem.UserData as ItemInfo;

                        string msg = string.Empty;

                        if (item.BrowseName == "TrayExist")
                            trayExist = bool.Parse(change.Value.ToString());

                        if (item.ControlType == enEqpType.CNV)
                        {
                            if (trayExist)
                            {
                                SiteTagInfo tagInfo = ReadSiteInfo(item);
                                task = DisplayBCRAsync(item.GroupNo, item.SiteNo, tagInfo);
                            }

                            task = StatusConveyorAsync(item.GroupNo, item.SiteNo, trayExist);

                            msg = string.Format("[{0}-CNV{1:D4}] {2} = {3}",
                                item.ControlType, item.SiteNo, item.BrowseName, change.Value);
                        }
                        else if (item.ControlType == enEqpType.STC)
                        {
                            if (item.BrowseName == "PosBay")
                            {
                                pos = int.Parse(change.Value.ToString());
                                task = MoveCraneAsync(_ListSCrane[item.CraneNo], pos);
                            }
                            else
                            {
                                task = StatusCraneAsync(_ListSCrane[item.CraneNo], trayExist, "C");
                            }

                            msg = string.Format("[{0}-CraneNo{1:D2}] {2} = {3}",
                                item.ControlType, item.CraneNo + 1, item.BrowseName, change.Value);
                        }
                        else if (item.ControlType == enEqpType.RTV)
                        {
                            if (item.BrowseName == "CarriagePos")
                            {
                                pos = int.Parse(change.Value.ToString());
                                task = MoveCraneAsync(ctrlSCraneV1, pos);
                            }
                            else
                            {
                                task = StatusCraneAsync(ctrlSCraneV1, trayExist, "RTV");

                                //if (trayExist)
                                //{
                                //    SiteTagInfo tagInfo = ReadSiteInfo(item);
                                //    task = DisplayBCRAsync(item.SiteNo, tagInfo);
                                //}

                                //task = StatusConveyorAsync(item.SiteNo, trayExist);
                            }

                            msg = string.Format("[{0}-{1:D2}] {2} = {3}",
                                item.ControlType, 1, item.BrowseName, change.Value);
                        }

                        _Logger.Write(LogLevel.Receive, msg, LogFileName.AllLog);
                    }

                    //this.Invoke(new MethodInvoker(delegate ()
                    //{
                    //    Refresh();
                    //}));

                    // 비동기식 스레드
                    //this.BeginInvoke(new Action(() => Refresh()));

                    // 동기식 스레드
                    this.Invoke(new Action(() => Refresh()));
                });
            }            
        }
        #endregion

        #region GetConveyorEqpID
        private string GetConveyorEqpID(int eqpIdx)
        {
            string eqp = string.Empty;

            switch (eqpIdx)
            {
                case 0:
                    eqp = "F01CNV10010";
                    break;
                case 1:
                    eqp = "F01CNV10020";
                    break;
                case 2:
                    eqp = "F01CNV10030";
                    break;
                case 3:
                    eqp = "F01CNV10040";
                    break;
                default:
                    _Logger.Write(LogLevel.Error, "GetConveyorEqpID is Empty", LogFileName.ErrorLog);
                    break;
            }

            return eqp;
        }

        private string GetCraneEqpID(int eqpIdx)
        {
            string eqp = string.Empty;

            switch (eqpIdx)
            {
                case 0:
                    eqp = "F01STCH0010";
                    break;
                case 1:
                    eqp = "F01STCL0010";
                    break;
                case 2:
                    eqp = "F01STCL0020";
                    break;
                case 3:
                    eqp = "F01STCF0010";
                    break;
                default:
                    _Logger.Write(LogLevel.Error, "GetCraneEqpID is Empty", LogFileName.ErrorLog);
                    break;
            }

            return eqp;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            WinTroubleInfo form = new WinTroubleInfo();
            form.ShowDialog();

            //string node = "ns=2;i=1000";
            //_clientFMS[0].GetNodeID(node);

            //NodeId nodeToBrowse = new NodeId(Objects.RootFolder, 0);
            //NodeId nodeToBrowse = new NodeId(Objects.ObjectsFolder, 0);
            //_clientFMS[0].ScanOPCServer(nodeToBrowse);

            //Dictionary<string, object> _EntireEqpList = new Dictionary<string, object>();

            //_EntireEqpList.Add("F1DGS01", ctrlEqpDGS);
            //_EntireEqpList.Add("F1DCR01", ctrlEqpDCR);
            //_EntireEqpList.Add("F1OCV01", ctrlEqpOCV);

            //string connection = ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString;

            //DataSet ds = new DataSet();

            //using (MySqlConnection conn = new MySqlConnection(connection))
            //{
            //    //tb_mst_aging 전체 데이터를 조회합니다.            
            //    string selectQuery = string.Format($"SELECT eqp_id, tray_id, tray_id_2  FROM fms_v.tb_mst_eqp");

            //    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, conn);

            //    dataAdapter.Fill(ds);               
            //}

            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    string eqpid = row["eqp_id"].ToString();

            //    if (_EntireEqpList.ContainsKey(eqpid))
            //    {
            //        UserControlEqp userControl = _EntireEqpList[eqpid];
            //        userControl.SetData(row);
            //    }                
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {

            RESTClient rest = new RESTClient();
            //// Set Query
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append(" INSERT INTO fms_v.tb_dat_tray");
            strSQL.Append("        (fms_v.tb_dat_tray (tray_id, tray_status, tray_zone, tray_input_time, current_cell_cnt, model_id, route_id, lot_id, eqp_id)");
            strSQL.Append("   FROM fms_v.tb_mst_eqp     A ");
            strSQL.Append("        Inner JOIN fms_v.tb_dat_tray     B");
            strSQL.Append("           ON B.eqp_id = A.eqp_id ");
            //필수값
            strSQL.Append($" WHERE A.eqp_id = B.eqp_id");

            var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

            //_jsonDatCellResponse j1 =  rest.ConvertDatCell(jsonResult);

            //sql = "SELECT * FROM fms_v.tb_dat_tray Where tray_id = 'TRV000001'";
            //jsonResult = rest.GetJson(enActionType.SQL_SELECT, sql);

            //_jsonDatTrayResponse j2 = rest.ConvertDatTray(jsonResult);




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //WinAgingRackSetting form = new WinAgingRackSetting();
            //form.SetData();
            //form.ShowDialog();

            //WinLeadTime_old form = new WinLeadTime_old();
            //form.SetData("TVID00001");
            //form.ShowDialog();



            //Request 세팅
            //JObject reqBody = new JObject();
            //reqBody["ACTION_ID"] = "SQL_SELECT";
            //reqBody["REQUEST_TIME"] = DateTime.Now.ToString();
            //reqBody["QUERY"] = "SELECT * FROM tb_dat_tray;";

            //RESTClient restClient = new RESTClient();
            //string reqBody = "SELECT * FROM tb_dat_tray;";

            //// Rest API 호출해서 response 받아옴
            //var JsonResult = restClient.GetJson(enActionType.SQL_SELECT, reqBody).Result;

            //if (JsonResult != null)
            //{
            //    _jsonDatTrayResponse result = restClient.ConvertDatTray(JsonResult.ToString());

            //}

            RESTClient rest = new RESTClient();
            //// Set Query
            StringBuilder strSQL = new StringBuilder();

            //strSQL.Append(" SELECT A.eqp_type, A.eqp_id, A.unit_id, A.eqp_mode, A.eqp_status,");
            //strSQL.Append("        B.tray_id, B.rework_flag, IF(B.tray_id = A.tray_id, '0', '1') AS Level");
            //strSQL.Append("   FROM fms_v.tb_mst_eqp     A ");
            //strSQL.Append("        LEFT OUTER JOIN fms_v.tb_dat_tray B");
            //strSQL.Append("           ON B.tray_id IN (A.tray_id, A.tray_id_2)");
            ////필수값
            //strSQL.Append(" WHERE A.eqp_type = 'HPC' AND A.unit_id IS NOT NULL");
            //strSQL.Append("    OR A.eqp_type = 'CHG' AND A.unit_id IS NOT NULL");
            //strSQL.Append("    OR A.eqp_type NOT IN ('SCH', 'SCF', 'SCL')");

            strSQL.Append(" SELECT tray_id");
            strSQL.Append("   FROM fms_v.tb_dat_tray");
            //필수값

            var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

            if (jsonResult != null)
            {
                _jsonDatTrayResponse result = rest.ConvertDatTray(jsonResult.Result);

            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //LocalLanguage.resxLanguage = new ResourceManager("MonitoringUI.WinFormRoot", typeof(WinFormRoot).Assembly);

            //InitLanguage();

            //Refresh();

            //DataSet ds = _mysql.SelectEqpInfo();

            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    //string eqpid = row["eqp_id"].ToString();

            //    //if (_EntireEqpList.ContainsKey(eqpid))
            //    //{
            //    //    UserControlEqp userControl = _EntireEqpList[eqpid];
            //    //    userControl.SetData(row);
            //    //}
            //}

            //WinCellDetailInfo form = new WinCellDetailInfo();
            //form.ShowDialog();

            //WinLeadTime_old form = new WinLeadTime_old();
            //form.SetData("TVID00001");
            //form.ShowDialog();
        }

        //private void ctrlEqpHTAging1_DoubleClick(object sender, EventArgs e)
        //{
        //    WinLeadTime form = new WinLeadTime();
        //    form.SetData("TVID00001");
        //    form.ShowDialog();
        //}
    }
}
