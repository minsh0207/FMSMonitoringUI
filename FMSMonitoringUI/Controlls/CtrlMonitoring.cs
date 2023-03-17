using ControlGallery;
using CSVMgr;
using DBHandler;
using ExcelDataReader.Log;
using FMSMonitoringUI.Common;
using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
//using Microsoft.Office.Interop.Excel;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Monitoring;
using MonitoringUI.Popup;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json.Linq;
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
using System.Web.Http.Results;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Interop;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaSchema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlMonitoring : UserControlRoot
    {
        #region Properties
        public override string Text { get; set; }
        #endregion

        #region [Variable]
        private OPCUAClient[] _clientFMS;

        /// <summary>
        /// First=ConveyorNo, Second=Site(Track) Control
        /// </summary>
        private Dictionary<int, CtrlSiteTrack> _ListConveyor;   // = new Dictionary<int, CtrlSiteTrack>();
        /// <summary>
        /// First=CraneNo, Second=Crane Control
        /// </summary>
        private Dictionary<int, CtrlSCraneH> _ListSCrane;   // = new Dictionary<int, CtrlSCraneH>();
        /// <summary>
        /// First=SiteNo(TrackNo), Second=ItemInfo Class
        /// </summary>
        private Dictionary<int, ItemInfo>[] _ListSite;  // = new Dictionary<int, ItemInfo>[CDefine.DEF_PLC_SERVER_COUNT];
        /// <summary>
        /// First=BCRNo, Second=BCRMarker Control
        /// </summary>
        private Dictionary<int, BCRMarker>[] _ListBCR;  // = new Dictionary<int, BCRMarker>[CDefine.DEF_PLC_SERVER_COUNT];

        /// <summary>
        /// First=Equipment ID, Second=Control Index
        /// </summary>
        private Dictionary<string, ItemInfo> _ControlIdx;   // = new Dictionary<string, ItemInfo>();

        /// <summary>
        /// string=Eqp Status, Color=Eqp Status Color
        /// </summary>
        private Dictionary<string, KeyValuePair<string, Color>> _EqpStatus;    // = new Dictionary<string, KeyValuePair<string, string>>();

        /// <summary>
        /// string=Process Status, Color=Process Status Color
        /// </summary>
        public Dictionary<string, Color> _ProcessStatus;

        /// <summary>
        /// First=Equipment ID, Second=Eqp UserControl
        /// </summary>
        private Dictionary<string, UserControlEqp> _EntireEqpList;  // = new Dictionary<string, UserControlEqp>();

        /// <summary>
        /// First=Equipment ID, Second=Eqp Name
        /// </summary>
        public Dictionary<string, string> _EqpName;

        public List<string> _ReworkTray;

        CSubscribeInfo[] _SubscribeInfo;



        private COPCGroupCtrl _OPCGroupList;    //= new COPCGroupCtrl();

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


        //private Logger _Logger;

        #region CtrlMain
        public CtrlMonitoring(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

            //string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            //_Logger = new Logger(logPath, LogMode.Hour);

            _OPCApplication = applicationInstance;

            // Timer 
            //m_timer.Tick += new EventHandler(OnTimer);
            //m_timer.Stop();

            _ListConveyor = new Dictionary<int, CtrlSiteTrack>();
            _ListSCrane = new Dictionary<int, CtrlSCraneH>();
            _ListSite = new Dictionary<int, ItemInfo>[CDefine.DEF_PLC_SERVER_COUNT];
            _ListBCR = new Dictionary<int, BCRMarker>[CDefine.DEF_PLC_SERVER_COUNT];
            _ControlIdx = new Dictionary<string, ItemInfo>();
            _EqpStatus = new Dictionary<string, KeyValuePair<string, Color>>();
            _ProcessStatus = new Dictionary<string, Color>();
            _EntireEqpList = new Dictionary<string, UserControlEqp>();
            _OPCGroupList = new COPCGroupCtrl();
            _EqpName = new Dictionary<string, string>();
            _ReworkTray = new List<string>();

            _SubscribeInfo = new CSubscribeInfo[CDefine.DEF_PLC_SERVER_COUNT];

            _mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);
        }
        #endregion

        #region CtrlMonitoring_Load
        /// <summary>
        /// Total MonitoringUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlMonitoring_Load(object sender, EventArgs e)
        {
            InitMonitoring();
            InitLanguage();

            CLogger.WriteLog(enLogLevel.Info, this.Text, "Window Load");
        }
        #endregion

        //#region OnHandleDestroyed
        ///// <summary>
        ///// UserControl에서 종료시 호출
        ///// </summary>
        //protected override void OnHandleDestroyed(EventArgs e)
        //{
        //    base.OnHandleDestroyed(e);

        //    if (this._TheadVisiable && this._ProcessThread.IsAlive)
        //        this._TheadVisiable = false;

        //    if (this._TheadVisiable)
        //        this._ProcessThread.Abort();
        //}
        //#endregion

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
        }
        #endregion

        #region CtrlMonitoring_ConnectionStatusEvent
        private void CtrlMonitoring_ConnectionStatusEvent(int opcIdx, string url, ServerConnectionStatus status)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                switch (status)
                {
                    case ServerConnectionStatus.Connected:
                        controlStatus.SetPLCConnectionStatus(opcIdx, 2);
                        CLogger.WriteLog(enLogLevel.Info, this.Text, $"Connected to the PLC server. [{url}]");
                        break;

                    case ServerConnectionStatus.Connecting:
                        controlStatus.SetPLCConnectionStatus(opcIdx, 1);
                        //CLogger.WriteLog(enLogLevel.Error, this.Text, $"Connecting to the PLC server. [{url}]");
                        break;

                    case ServerConnectionStatus.Disconnected:
                        controlStatus.SetPLCConnectionStatus(opcIdx, 4);
                        CLogger.WriteLog(enLogLevel.Error, this.Text, $"Disconnected to the PLC server. [{url}]");
                        break;

                    default:
                        controlStatus.SetPLCConnectionStatus(opcIdx, 4);
                        break;
                }
            }));
        }
        #endregion

        #region CtrlMonitoring_SubscriptionEvent
        private void CtrlMonitoring_SubscriptionEvent(int opcIdx, string url)
        {
            _clientFMS[opcIdx].Subscription.DataChanged += new DataChangedEventHandler(Subscription_DataChanged);

            if (_clientFMS[opcIdx].StatusCode == true)
            {
                CLogger.WriteLog(enLogLevel.Info, this.Text, $"Success in Subscription_StatusChanged callback [{url}]");
            }
            else
            {
                CLogger.WriteLog(enLogLevel.Error, this.Text, $"Error in Subscription_StatusChanged callback [{url}]");
            }
        }
        #endregion

        #region InitMonitoring
        private async void InitMonitoring()
        {
            Dictionary<int, List<ItemInfo>> ctrlGroupList = InitControls();

            List<CEqpTagItem> DataList = ReadTagConfig();
            List<COPCUAConfig> opcList = ReadOPCConfig();

            _clientFMS = new OPCUAClient[opcList.Count()];

            int fmsIdx = 0;
            foreach (var opcua in opcList)
            {
                int opcIdx = Convert.ToInt32(opcua.DeviceID);

                _clientFMS[fmsIdx] = new OPCUAClient(DataList, _OPCGroupList.GroupList[opcIdx], _OPCApplication, _ControlIdx, _ListSite[opcIdx]);
                _clientFMS[fmsIdx].ServerNo = fmsIdx;

                _clientFMS[fmsIdx].SubscriptionEvent += CtrlMonitoring_SubscriptionEvent;
                _clientFMS[fmsIdx].ConnectionStatusEvent += CtrlMonitoring_ConnectionStatusEvent;

                await _clientFMS[fmsIdx].ConnectAsync(opcua.OPCServerURL, opcua.UserID, opcua.UserPW, opcua.FirstNodeID);

                fmsIdx++;
            }
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

                _SubscribeInfo[i] = new CSubscribeInfo();

                controlStatus.SetPLCConnectionStatus(i, 4);
            }

            controlStatus.SetRestConnectionStatus(4);

            //int craneCnt = 0;

            // First=OPCUA Server로 구성된 Conveyor, Second=Site정보
            Dictionary<int, List<ItemInfo>> groupCtrl = new Dictionary<int, List<ItemInfo>>();

            foreach (var ctl in this.panel2.Controls)
            {
                if (ctl.GetType() == typeof(CtrlSiteTrack))
                {
                    CtrlSiteTrack conveyor = ctl as CtrlSiteTrack;
                    conveyor.ObjectDoubleClick += OnConveyor_MouseDoubleClick;
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

                            _SubscribeInfo[deviceID].Item[site.SiteNo] = new CMonitoredItem();

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
                    crane.MouseDoubleClick += OnCrane_MouseDoubleClick;
                    crane.MouseClick += Crane_MouseClick;

                    //_ListCrane.Add(crane);
                }
                else if (ctl.GetType() == typeof(CtrlSCraneH))
                {
                    CtrlSCraneH crane = ctl as CtrlSCraneH;
                    //crane.SetSCHandler(GlobalArea.g_SCHandlerList.Find(x => x.DeviceID == crane.DeviceID));
                    crane.MouseDoubleClick += OnCrane_MouseDoubleClick;
                    crane.MouseClick += Crane_MouseClick;

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

                    _SubscribeInfo[itemInfo.GroupNo].Item[crane.CraneID] = new CMonitoredItem();

                    //craneCnt++;
                }
                else if (ctl.GetType() == typeof(CtrlEqpOCV) ||
                         ctl.GetType() == typeof(CtrlEqpDCIR) ||
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
                        eqp.EqpName = _EqpName[eqp.EqpID];
                    }
                }
                //else if (ctl.GetType() == typeof(CtrlEqpCharger))
                //{
                //    CtrlEqpCharger eqp = ctl as CtrlEqpCharger;
                //    foreach (var unitId in eqp.UnitID)
                //    {
                //        _EntireEqpList.Add(unitId, eqp);
                //        eqp.EqpName = _EqpName[unitId];
                //    }
                //}
                else if (ctl.GetType() == typeof(CtrlEqpHPC))
                {
                    CtrlEqpHPC eqp = ctl as CtrlEqpHPC;

                    _EntireEqpList.Add(eqp.UnitID, eqp);
                    eqp.EqpName = _EqpName[eqp.UnitID];
                }
                else if (ctl.GetType() == typeof(CtrlEqpHTAging))
                {
                    CtrlEqpHTAging eqp = ctl as CtrlEqpHTAging;

                    //if (_EntireEqpList.ContainsKey(eqp.EqpID) == false)
                    //{
                    //    _EntireEqpList.Add(eqp.EqpID, eqp);
                    //}
                    eqp.EqpName = _EqpName[eqp.EqpID];
                }
                else if (ctl.GetType() == typeof(CtrlEqpLTAging))
                {
                    CtrlEqpLTAging eqp = ctl as CtrlEqpLTAging;

                    //if (_EntireEqpList.ContainsKey(eqp.EqpID) == false)
                    //{
                    //    _EntireEqpList.Add(eqp.EqpID, eqp);
                    //}
                    eqp.EqpName = _EqpName[eqp.EqpID];
                }
                else if (ctl.GetType() == typeof(CtrlEqpCharger))
                {
                    CtrlEqpCharger eqp = ctl as CtrlEqpCharger;

                    _EntireEqpList.Add(eqp.EqpID, eqp);
                    eqp.EqpName = _EqpName[eqp.EqpID];
                }
                else if (ctl.GetType() == typeof(CtrlEqpMicroCurrent))
                {
                    CtrlEqpMicroCurrent eqp = ctl as CtrlEqpMicroCurrent;

                    _EntireEqpList.Add(eqp.EqpID, eqp);
                    eqp.EqpName = _EqpName[eqp.UnitID];
                }
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

            ctrlEqpCharger.Click_Evnet += CtrlEqpAging_Click;


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

            CLogger.WriteLog(enLogLevel.Info, this.Text, "Initialize the Controls");

            return groupCtrl;
        }
        #endregion

        #region InitLanguage
        public void InitLanguage()
        {
            _EqpStatus.Clear();

            // CtrlTaggingName 언어 변환 호출
            foreach (var ctl in panel1.Controls)
            {
                if (ctl.GetType() == typeof(CtrlTaggingName))
                {
                    CtrlTaggingName tagName = ctl as CtrlTaggingName;
                    tagName.CallLocalLanguage();

                    KeyValuePair<string, Color> tag;

                    if (tagName.StatusCode == "T")
                    {
                        tag = new KeyValuePair<string, Color>("Trouble", tagName.TagColor);
                    }
                    else
                    {
                        tag = new KeyValuePair<string, Color>(tagName.TagText, tagName.TagColor);
                    }

                    _EqpStatus.Add(tagName.StatusCode, tag);
                }
                else if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel tagName = ctl as CtrlLabel;
                    tagName.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlControlStatus))
                {
                    CtrlControlStatus controlStatus = ctl as CtrlControlStatus;
                    controlStatus.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlCheckBox))
                {
                    CtrlCheckBox cbCtl = ctl as CtrlCheckBox;
                    cbCtl.CallLocalLanguage();
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
                case "CHG":
                    agingType = "CHG";
                    break;
                default:
                    break;
            }

            WinLeadTime form = new WinLeadTime(eqpId, agingType, level);
            form.ShowDialog();
        }

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LoadEntireEqpList().GetAwaiter().GetResult();
                        LoadAgingRackCount().GetAwaiter().GetResult();
                        LoadReworkTray().GetAwaiter().GetResult();
                    }));

                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region LoadEntireEqpList
        private async Task LoadEntireEqpList()
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT A.eqp_type, A.eqp_id, A.unit_id, A.eqp_mode, A.eqp_status, A.process_status,");
                strSQL.Append("        B.rework_flag AS rework_tray_1, C.rework_flag AS rework_tray_2,");
                strSQL.Append("        CASE WHEN B.tray_id = null THEN A.tray_id ELSE B.tray_id END AS tray_id, A.tray_id_2");
                strSQL.Append("   FROM fms_v.tb_mst_eqp     A ");
                strSQL.Append("        LEFT OUTER JOIN fms_v.tb_dat_tray B");
                strSQL.Append("           ON B.tray_id = A.tray_id");
                strSQL.Append("        LEFT OUTER JOIN fms_v.tb_dat_tray C");
                strSQL.Append("           ON C.tray_id = A.tray_id_2");
                //필수값
                strSQL.Append(" WHERE (A.eqp_type NOT IN ('HTA', 'LTA', 'SCH', 'SCF', 'SCL'))");
                strSQL.Append("    AND ((A.eqp_type = 'HPC' AND A.unit_id IS NOT NULL)");
                strSQL.Append("      OR (A.eqp_type = 'CHG' AND A.unit_id IS NOT NULL)");
                strSQL.Append("      OR (A.eqp_type NOT IN ('HPC', 'CHG')))");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonEntireEqpListResponse result = rest.ConvertEntireEqpList(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);

                        controlStatus.SetRestConnectionStatus(2);
                    }
                    else
                    {
                        string log = "ConvertEntireEqpList : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                        controlStatus.SetRestConnectionStatus(4);
                    }
                }
                else
                {
                    string log = "ConvertEntireEqpList : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                    controlStatus.SetRestConnectionStatus(4);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadEntireEqpList Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadEntireEqpList Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region LoadAgingRackCount
        private async Task LoadAgingRackCount()
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT aging_type, line, lane,");
                strSQL.Append("        COUNT(aging_type) AS total_rack_cnt,");
                strSQL.Append("        COUNT(if(status = 'F', status, null)) AS in_aging");
                strSQL.Append(" FROM (SELECT line, (");
                strSQL.Append("           CASE WHEN lane = '1' OR lane = '2' THEN '1'  ELSE '2'END) AS lane,");
                strSQL.Append("                 aging_type, status FROM fms_v.tb_mst_aging) table1");
                //필수값
                strSQL.Append($" WHERE aging_type IN ('H', 'L') AND  line IN ('01', '02') AND  lane IN ('1', '2')");
                strSQL.Append($" GROUP BY aging_type, line, lane");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonAgingRackCountResponse result = rest.ConvertAgingRackCount(jsonResult);

                    if (result != null)
                    {
                        SetData(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertAgingRackCount : jsonResult is null";
                        CLogger.WriteLog(enLogLevel.Error, this.Text, log);
                    }
                }
                else
                {
                    string log = "ConvertAgingRackCount : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadAgingRackCount Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadAgingRackCount Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region LoadReworkTray
        private async Task LoadReworkTray()
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT tray_id, rework_flag");
                strSQL.Append("   FROM fms_v.tb_dat_tray");
                //필수값
                strSQL.Append(" WHERE rework_flag = 'Y'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonReworkTrayResponse result = rest.ConvertReworkTray(jsonResult);

                    if (result != null)
                    {
                        //this.BeginInvoke(new Action(() => SetData(result.DATA)));
                        SetData(result.DATA);

                        controlStatus.SetRestConnectionStatus(2);
                    }
                    else
                    {
                        string log = "ConvertEntireEqpList : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                        controlStatus.SetRestConnectionStatus(4);
                    }
                }
                else
                {
                    string log = "ConvertEntireEqpList : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.Text, log);

                    controlStatus.SetRestConnectionStatus(4);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("LoadEntireEqpList Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadEntireEqpList Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }
        #endregion

        #region SetData
        public void SetData(List<_entire_eqp_list> data)
        {
            if (data == null || data.Count == 0) return;

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

            for (int i = 0; i < eqpData.Count; i++)
            {
                string eqpid = eqpData.Keys.ToList()[i];

                if (eqpid == CDefine.DEF_EQP_HPC)
                {
                    ctrlEqpHPC1.SetData(eqpData[eqpid], _EqpStatus);
                    ctrlEqpHPC2.SetData(eqpData[eqpid], _EqpStatus);
                }
                if (eqpid == CDefine.DEF_EQP_CHG)
                {
                    ctrlEqpCharger.SetData(eqpData[eqpid], _EqpStatus, _ProcessStatus);
                }
                else
                {
                    UserControlEqp ctrlEqp = _EntireEqpList[eqpid];
                    ctrlEqp.SetData(eqpData[eqpid], _EqpStatus);
                }
            }

            //for (int i = 0; i < _EntireEqpList.Count; i++)
            //{
            //    string eqpid = _EntireEqpList.Keys.ToList()[i];

            //    if (eqpData.ContainsKey(eqpid))
            //    {
            //        if (eqpid == "F1HPC01")
            //        {
            //            ctrlEqpHPC1.SetData(eqpData[eqpid], _EqpStatus);
            //            ctrlEqpHPC2.SetData(eqpData[eqpid], _EqpStatus);
            //        }
            //        else
            //        {
            //            UserControlEqp ctrlEqp = _EntireEqpList[eqpid];
            //            ctrlEqp.SetData(eqpData[eqpid], _EqpStatus);
            //        }
            //    }
            //}
        }
        // Aging 
        private void SetData(List<_aging_rack_count> data)
        {
            if (data == null || data.Count == 0) return;

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
        //Rework
        public void SetData(List<_rework_tray> data)
        {
            if (data == null || data.Count == 0)
            {
                lock (_ReworkTray)
                {
                    _ReworkTray.Clear();
                }
                return;
            }

            foreach (var item in data)
            {
                lock (_ReworkTray)
                {
                    if (_ReworkTray.Contains(item.TRAY_ID) == false)
                    {
                        _ReworkTray.Add(item.TRAY_ID);
                    }
                }
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

            CLogger.WriteLog(enLogLevel.Info, this.Text, $"Read TagList : {di}{CDefine.CONFIG_FILENAME_TAG}");

            return reader.Read();
        }
        /// <summary>
        /// OPCUAList.csv에서 OPC Config정보를 읽어온다.
        /// </summary>
        /// <returns></returns>
        private List<COPCUAConfig> ReadOPCConfig()
        {
            CSVLoader csv_opc = new CSVLoader(CDefine.CONFIG_FILENAME_OPCUA);

            CLogger.WriteLog(enLogLevel.Info, this.Text, $"Read OPC Config : {CDefine.CONFIG_FILENAME_OPCUA}");

            return csv_opc.Load<COPCUAConfig>();
        }
        #endregion

        #region [Mouse DBLCLK Event]
        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        //List<WinBCRConveyorInfo> forms = new List<WinBCRConveyorInfo>();

        private void OnConveyor_MouseDoubleClick(object sender, ObjectDoubleClickEventArgs arg)
        {
            try
            {
                string trayid1 = string.Empty;
                string trayid2 = string.Empty;

                int groupno = arg.DeviceInfo.CVPLCListDeviceID;
                int trackno = arg.DeviceInfo.SiteNo;

                _CVGroupNo = groupno;
                _CVTrackNo = trackno;

                if (_CVTrackNo < 0) return;
                if (_clientFMS[groupno] == null) return;
                if (_clientFMS[groupno].ConveyorNodeID == null) return;

                if (trackno > 0 && trackno < 40)      // Water Tank
                {
                    int craneNo = trackno / 10;
                    int tankIdx = trackno % 2;
                    CtrlSiteTrack siteTrack = sender as CtrlSiteTrack;

                    WinWaterTank form = new WinWaterTank(_clientFMS[groupno], craneNo, _EqpName[siteTrack.Tag.ToString()], tankIdx);
                    form.ShowDialog();

                    form.GetTrayID(ref trayid1, ref trayid2);
                    CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"WaterTank = {_EqpName[siteTrack.Tag.ToString()]}, TrayID L1 = {trayid1}, TrayID L2 = {trayid2}");
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

                    //string log =   $"Track No : {trackno}, TrayIdL1 : {siteInfo.TrayIdL1}, TrayIdL2 : {siteInfo.TrayIdL2}";

                    if (trackno > 0 && _ListBCR[groupno].ContainsKey(trackno) == false)
                    {
                        WinConveyorInfo form = new WinConveyorInfo("Conveyor", _clientFMS[groupno], trackno);
                        form.ShowDialog();

                        form.GetTrayID(ref trayid1, ref trayid2);
                        CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"Track No = {trackno}, TrayID L1 = {trayid1}, TrayID L2 = {trayid2}");

                    }
                    else
                    {
                        WinBCRConveyorInfo form = new WinBCRConveyorInfo(_clientFMS[groupno], trackno);
                        form.ShowDialog();

                        form.GetTrayID(ref trayid1, ref trayid2);
                        CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"Track No = {trackno}, TrayID L1 = {trayid1}, TrayID L2 = {trayid2}");
                    }

                    CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"Track No : {trackno}");
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("OnConveyor_MouseDoubleClick Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("OnConveyor_MouseDoubleClick Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
            }
        }

        private void Crane_MouseClick(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                CtrlSCrane crane = sender as CtrlSCrane;

                if (crane.EqpID != "")
                {
                    WinTroubleInfo winTroubleInfo = new WinTroubleInfo(_EqpName[crane.EqpID], crane.EqpID.Substring(2, 3), crane.EqpID, "");
                    winTroubleInfo.ShowDialog();
                }
            }
        }

        private void OnCrane_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CtrlSCrane crane = sender as CtrlSCrane;

            string trayid1 = string.Empty;
            string trayid2 = string.Empty;

            if (_clientFMS[crane.DeviceID] == null ||
                _clientFMS[crane.DeviceID].Connected == false)
            {
                CMessage.MsgInformation($"Connection error to S/Crane PLC Server [{crane.Tag}]");

                CLogger.WriteLog(enLogLevel.Error, this.Text, $"Connection error to S/Crane PLC Server [{crane.Tag}]");
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

                        Point parentPoint = this.Location;

                        WinCraneInfo form = new WinCraneInfo(_clientFMS[crane.DeviceID], crane.CraneID, _EqpName[crane.EqpID]);
                        form.StartPosition = FormStartPosition.Manual;  // 폼의 위치가 Location 의 속성에 의해서 결정
                        form.Location = new Point((this.ClientSize.Width - form.Width) / 2, parentPoint.Y + 90);
                        form.ShowDialog();
                        form.GetTrayID(ref trayid1, ref trayid2);

                        CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"Crane No = {crane.CraneID}, TrayID L1 = {trayid1}, TrayID L2 = {trayid2}");
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

                    WinConveyorInfo form = new WinConveyorInfo("RTV", _clientFMS[groupno], conveyorNo);
                    form.ShowDialog();

                    form.GetTrayID(ref trayid1, ref trayid2);
                    CLogger.WriteLog(enLogLevel.ButtonClick, this.Text, $"RTV No = {conveyorNo}, TrayID L1 = {trayid1}, TrayID L2 = {trayid2}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("OnCrane_MouseDoubleClick Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("OnCrane_MouseDoubleClick Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.Text, log);
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
            if (e.DataChanges.Count > 0)        // 프로그램 기동시 모든 구독목록이 들어온다.
            {
                //return;
                CLogger.WriteLog(enLogLevel.Receive, this.Text, $"Subscription Item Count = {e.DataChanges.Count}");
            }

            Task task = SubscriptionAsync(e);

            //foreach (DataChange change in e.DataChanges)
            //{
            //    ItemInfo item = change.MonitoredItem.UserData as ItemInfo;

            //    switch (item.ControlType)
            //    {
            //        case enEqpType.CNV:
            //            Task task = ConveyorAsync(item, change.Value.ToString());
            //            break;
            //        //case enEqpType.STC:
            //        //    task = StackerCraneDataChange(item, change.Value.ToString());
            //        //    break;
            //        //case enEqpType.RTV:
            //        //    task = RTVDataChange(item, change.Value.ToString());
            //        //    break;
            //        default:
            //            break;
            //    }
            //}

            //Thread.Sleep(20);
            //Application.DoEvents();
            //this.BeginInvoke(new Action(() => Refresh()));

            //bool trayExist = false;
            //int pos;
            //Task task;

            //foreach (DataChange change in e.DataChanges)
            //{
            //    ItemInfo item = change.MonitoredItem.UserData as ItemInfo;

            //    string log =   string.Empty;

            //    if (item.ControlType == enEqpType.CNV)
            //    {
            //        if (item.BrowseName == "ConveyorInformation.TrayExist")
            //            trayExist = bool.Parse(change.Value.ToString());

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
            //        if (item.BrowseName == "Carriage.PosBay")
            //        {
            //            pos = int.Parse(change.Value.ToString());
            //            task = MoveCraneAsync(_ListSCrane[item.CraneNo], pos);
            //        }
            //        else if (item.BrowseName == "CraneCommand.TrayExist")
            //        {
            //            trayExist = bool.Parse(change.Value.ToString());
            //            task = StatusCraneAsync(_ListSCrane[item.CraneNo], trayExist, "C");
            //        }
            //        else if (item.BrowseName == "WaterTank.TrayExist")  // WaterTank01
            //        {
            //            switch (item.GroupNo)
            //            {
            //                case 1: // HT Aging S/Crane
            //                    task = StatusConveyorAsync(item.GroupNo, 1, bool.Parse(change.Value.ToString()));
            //                    break;

            //                case 2: // LT Aging S/Crane
            //                    if (item.CraneNo == 1)   // LT Aging#1 S/Crane
            //                    {
            //                        task = StatusConveyorAsync(item.GroupNo, 11, bool.Parse(change.Value.ToString()));
            //                    }
            //                    else   // LT Aging#2 S/Crane
            //                    {
            //                        task = StatusConveyorAsync(item.GroupNo, 21, bool.Parse(change.Value.ToString()));
            //                    }
            //                    break;
            //                case 3:    // Charger
            //                    task = StatusConveyorAsync(item.GroupNo, 31, bool.Parse(change.Value.ToString()));
            //                    break;
            //            }
            //        }
            //        else if (item.BrowseName == "WaterTank02.TrayExist")  // WaterTank01
            //        {
            //            switch (item.GroupNo)
            //            {
            //                case 1: // HT Aging S/Crane
            //                    task = StatusConveyorAsync(item.GroupNo, 2, bool.Parse(change.Value.ToString()));
            //                    break;

            //                case 2: // LT Aging S/Crane
            //                    if (item.CraneNo == 1)   // LT Aging#1 S/Crane
            //                    {
            //                        task = StatusConveyorAsync(item.GroupNo, 12, bool.Parse(change.Value.ToString()));
            //                    }
            //                    else   // LT Aging#2 S/Crane
            //                    {
            //                        task = StatusConveyorAsync(item.GroupNo, 22, bool.Parse(change.Value.ToString()));
            //                    }
            //                    break;
            //            }
            //        }

            //        msg = string.Format("[{0}-CraneNo{1:D2}] {2} = {3}",
            //            item.ControlType, item.CraneNo + 1, item.BrowseName, change.Value);
            //    }
            //    else if (item.ControlType == enEqpType.RTV)
            //    {
            //        if (item.BrowseName == "ConveyorInformation.CarriagePos")
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

            //Thread.Sleep(20);
            //Application.DoEvents();
            //this.BeginInvoke(new Action(() => Refresh()));
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
            List<ReadValueId> cvInfo = _clientFMS[item.ServerNo].ConveyorNodeID[item.SiteNo];
            List<DataValue> data = _clientFMS[item.ServerNo].ReadNodeID(cvInfo);

            SiteTagInfo tagInfo = new SiteTagInfo();

            tagInfo.TrayIdL1 = Convert.ToString(data[(int)enCVTagList.TrayIdL1].Value);
            tagInfo.TrayIdL2 = Convert.ToString(data[(int)enCVTagList.TrayIdL2].Value);

            return tagInfo;
        }
        private SiteTagInfo ReadSiteInfo(int serverNo, int siteNo)
        {
            List<ReadValueId> cvInfo = _clientFMS[serverNo].ConveyorNodeID[siteNo];
            List<DataValue> data = _clientFMS[serverNo].ReadNodeID(cvInfo);

            SiteTagInfo tagInfo = new SiteTagInfo();

            tagInfo.TrayIdL1 = Convert.ToString(data[(int)enCVTagList.TrayIdL1].Value);
            tagInfo.TrayIdL2 = Convert.ToString(data[(int)enCVTagList.TrayIdL2].Value);

            return tagInfo;
        }
        #endregion

        private SiteTagInfo ReadWaterTankInfo(int serverNo, int craneNo, int watertankNo)
        {
            List<ReadValueId> craneInfo = _clientFMS[serverNo].CraneNodeID[craneNo];
            List<DataValue> data = _clientFMS[serverNo].ReadNodeID(craneInfo);

            int[] trayIdx = { 0, 0 };
            if (watertankNo == 1)
            {
                trayIdx[0] = 43;    // Water Tank01번에 Tray ID L1의 Index
                trayIdx[1] = 44;    // Water Tank01번에 Tray ID L2의 Index
            }
            else
            {
                trayIdx[0] = 57;    // Water Tank02번에 Tray ID L1의 Index
                trayIdx[1] = 58;    // Water Tank02번에 Tray ID L2의 Index
            }

            SiteTagInfo tagInfo = new SiteTagInfo();

            if (data[trayIdx[0]].Value != null)
                tagInfo.TrayIdL1 = data[trayIdx[0]].Value.ToString();

            if (data[trayIdx[1]].Value != null)
                tagInfo.TrayIdL2 = data[trayIdx[1]].Value.ToString();

            return tagInfo;
        }

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
        /// <param name="pos"></param>
        /// <returns></returns>
        private async Task MoveCraneAsync(CtrlSCrane crane, double pos, CMonitoredItem item)
        {
            Task task = MoveCrane(crane, pos, item);

            await task;
        }
        private async Task MoveCrane(CtrlSCrane crane, double pos, CMonitoredItem item)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    int startPos = crane.CurrentBay;
                    int endPos = (int)Math.Round(pos);

                    //if (startPos == 0) startPos = (int)endPos;

                    //this.Invoke(new MethodInvoker(delegate ()
                    //{
                    //    crane.UpdateUI(item.TrayExist, item.CraneName, item.EqpStatus);
                    //}));

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

                            Thread.Sleep(20);
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

                            Thread.Sleep(20);
                            Application.DoEvents();
                        }
                    }


                });
            }
        }
        #endregion

        #region StatusCraneAsync
        private async Task StatusCraneAsync(CtrlSCrane crane, CMonitoredItem item)
        {
            Task task = StatusCrane(crane, item);

            await task;
        }

        private async Task StatusCrane(CtrlSCrane crane, CMonitoredItem item)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        crane.UpdateUI(item.TrayExist, item.CraneName, item.EqpStatus);
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
        private async Task StatusConveyorAsync(int groupno, int siteno, CMonitoredItem item)
        {
            Task task = StatusConveyor(groupno, siteno, item);

            await task;
        }

        private async Task StatusConveyor(int groupno, int siteno, CMonitoredItem item)
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
                            _ListConveyor[siteInfo.ConveyorNo].UpdateTrackStatus(siteno, item.TrayExist, item.TrayRework, item.EqpStatus);
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

        #region SubscriptionAsync
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
                    //double pos;
                    //Task task;

                    foreach (DataChange change in e.DataChanges)
                    {
                        ItemInfo item = change.MonitoredItem.UserData as ItemInfo;

                        //string log = string.Empty;

                        if (item.ControlType == enEqpType.CNV)
                        {
                            ConveyorDataChange(item, change.Value.ToString());

                            //_SubscribeInfo[item.GroupNo].Item[item.SiteNo].GroupNo = item.GroupNo;
                            //_SubscribeInfo[item.GroupNo].Item[item.SiteNo].SiteNo = item.SiteNo;

                            //if (item.BrowseName == "ConveyorInformation.TrayExist")
                            //    _SubscribeInfo[item.GroupNo].Item[item.SiteNo].TrayExist = Convert.ToBoolean(change.Value.ToString());

                            //if (item.BrowseName == "EquipmentStatus.Status")
                            //    _SubscribeInfo[item.GroupNo].Item[item.SiteNo].EqpStatus = Convert.ToInt16(change.Value.ToString());

                            //if (_SubscribeInfo[item.GroupNo].Item[item.SiteNo].TrayExist)
                            //{
                            //    SiteTagInfo tagInfo = ReadSiteInfo(item);
                            //    task = DisplayBCRAsync(item.GroupNo, item.SiteNo, tagInfo);

                            //    _SubscribeInfo[item.GroupNo].Item[item.SiteNo].TrayRework = CheckReworkTray(tagInfo.TrayIdL1);
                            //}

                            //task = StatusConveyorAsync(item.GroupNo, item.SiteNo, _SubscribeInfo[item.GroupNo].Item[item.SiteNo]);

                            //log = string.Format("[{0}-CNV{1:D4}] {2} = {3}",
                            //    item.ControlType, item.SiteNo, item.BrowseName, change.Value);
                        }
                        else if (item.ControlType == enEqpType.STC)
                        {
                            StackerCraneDataChange(item, change.Value.ToString());

                            //if (item.BrowseName == "EquipmentStatus.Status")
                            //{
                            //    _SubscribeInfo[item.GroupNo].Item[item.CraneNo].CraneName = "C";
                            //    _SubscribeInfo[item.GroupNo].Item[item.CraneNo].EqpStatus = Convert.ToInt16(change.Value.ToString());
                            //    task = StatusCraneAsync(_ListSCrane[item.CraneNo], _SubscribeInfo[item.GroupNo].Item[item.CraneNo]);
                            //}
                            //else if (item.BrowseName == "Carriage.PosBay")
                            //{
                            //    double dBayCnt = 0;
                            //    switch (item.CraneNo)
                            //    {
                            //        case 0:     // HT Aging
                            //            dBayCnt = 12;
                            //            break;
                            //        case 3:     // Charger
                            //            dBayCnt = 5;
                            //            break;
                            //        default:    // LT Aging
                            //            dBayCnt = 18;
                            //            break;
                            //    }

                            //    pos = (double.Parse(change.Value.ToString()) / dBayCnt) * 100;
                            //    task = MoveCraneAsync(_ListSCrane[item.CraneNo], pos, _SubscribeInfo[item.GroupNo].Item[item.CraneNo]);
                            //}
                            //else if (item.BrowseName == "CraneCommand.TrayExist")
                            //{
                            //    _SubscribeInfo[item.GroupNo].Item[item.CraneNo].CraneName = "C";
                            //    _SubscribeInfo[item.GroupNo].Item[item.CraneNo].TrayExist = Convert.ToBoolean(change.Value.ToString());
                            //    task = StatusCraneAsync(_ListSCrane[item.CraneNo], _SubscribeInfo[item.GroupNo].Item[item.CraneNo]);
                            //}
                            //else if ((item.BrowseName == "WaterTank.TrayExist") || // WaterTank01
                            //         (item.BrowseName == "WaterTank.FireSensor"))
                            //{
                            //    int siteNo = GetWaterTankSiteNo(1, item.GroupNo, item.CraneNo);

                            //    _SubscribeInfo[item.GroupNo].Item[siteNo].GroupNo = item.GroupNo;
                            //    _SubscribeInfo[item.GroupNo].Item[siteNo].CraneNo = item.CraneNo;

                            //    if (item.BrowseName == "WaterTank.TrayExist")
                            //        _SubscribeInfo[item.GroupNo].Item[siteNo].TrayExist = Convert.ToBoolean(change.Value.ToString());

                            //    if (item.BrowseName == "WaterTank.FireSensor")
                            //        _SubscribeInfo[item.GroupNo].Item[siteNo].FireSensor = Convert.ToBoolean(change.Value.ToString());

                            //    if (_SubscribeInfo[item.GroupNo].Item[siteNo].TrayExist)
                            //    {
                            //        SiteTagInfo tagInfo = ReadSiteInfo(item.GroupNo, siteNo);
                            //        _SubscribeInfo[item.GroupNo].Item[siteNo].TrayRework = CheckReworkTray(tagInfo.TrayIdL1);
                            //    }

                            //    switch (item.GroupNo)
                            //    {
                            //        case 1: // HT Aging WaterTank
                            //            task = StatusConveyorAsync(item.GroupNo, 1, _SubscribeInfo[item.GroupNo].Item[siteNo]);
                            //            break;

                            //        case 2: // LT Aging WaterTank
                            //            if (item.CraneNo == 1)   // LT Aging#1 S/Crane
                            //            {
                            //                task = StatusConveyorAsync(item.GroupNo, 11, _SubscribeInfo[item.GroupNo].Item[siteNo]);
                            //            }
                            //            else   // LT Aging#2 WaterTank
                            //            {
                            //                task = StatusConveyorAsync(item.GroupNo, 21, _SubscribeInfo[item.GroupNo].Item[siteNo]);
                            //            }
                            //            break;
                            //        case 3:    // Charger WaterTank
                            //            task = StatusConveyorAsync(item.GroupNo, 31, _SubscribeInfo[item.GroupNo].Item[siteNo]);
                            //            break;
                            //    }

                            //}
                            //else if ((item.BrowseName == "WaterTank02.TrayExist") || // WaterTank01
                            //         (item.BrowseName == "WaterTank.FireSensor"))
                            //{
                            //    int siteNo = GetWaterTankSiteNo(2, item.GroupNo, item.CraneNo);

                            //    _SubscribeInfo[item.GroupNo].Item[siteNo].GroupNo = item.GroupNo;
                            //    _SubscribeInfo[item.GroupNo].Item[siteNo].CraneNo = item.CraneNo;

                            //    if (item.BrowseName == "WaterTank.TrayExist")
                            //    {
                            //        _SubscribeInfo[item.GroupNo].Item[siteNo].TrayExist = Convert.ToBoolean(change.Value.ToString());
                            //    }

                            //    if (item.BrowseName == "WaterTank.FireSensor")
                            //        _SubscribeInfo[item.GroupNo].Item[siteNo].FireSensor = Convert.ToBoolean(change.Value.ToString());

                            //    if (_SubscribeInfo[item.GroupNo].Item[siteNo].TrayExist)
                            //    {
                            //        SiteTagInfo tagInfo = ReadSiteInfo(item.GroupNo, siteNo);
                            //        _SubscribeInfo[item.GroupNo].Item[siteNo].TrayRework = CheckReworkTray(tagInfo.TrayIdL1);
                            //    }

                            //    switch (item.GroupNo)
                            //    {
                            //        case 1: // HT Aging WaterTank
                            //            task = StatusConveyorAsync(item.GroupNo, 2, _SubscribeInfo[item.GroupNo].Item[siteNo]);
                            //            break;

                            //        case 2: // LT Aging WaterTank
                            //            if (item.CraneNo == 1)   // LT Aging#1 WaterTank
                            //            {
                            //                task = StatusConveyorAsync(item.GroupNo, 12, _SubscribeInfo[item.GroupNo].Item[siteNo]);
                            //            }
                            //            else   // LT Aging#2 WaterTank
                            //            {
                            //                task = StatusConveyorAsync(item.GroupNo, 22, _SubscribeInfo[item.GroupNo].Item[siteNo]);
                            //            }
                            //            break;
                            //    }
                            //}

                            //log = string.Format("[{0}-CraneNo{1:D2}] {2} = {3}",
                            //    item.ControlType, item.CraneNo + 1, item.BrowseName, change.Value);
                        }
                        else if (item.ControlType == enEqpType.RTV)
                        {
                            RTVDataChange(item, change.Value.ToString());

                            //if (item.BrowseName == "EquipmentStatus.Status")
                            //    _SubscribeInfo[item.GroupNo].Item[item.CraneNo].EqpStatus = Convert.ToInt16(change.Value.ToString());

                            //if (item.BrowseName == "ConveyorInformation.CarriagePos")
                            //{
                            //    pos = int.Parse(change.Value.ToString());
                            //    task = MoveCraneAsync(ctrlSCraneV1, pos, _SubscribeInfo[item.GroupNo].Item[item.CraneNo]);
                            //}
                            //else
                            //{
                            //    _SubscribeInfo[item.GroupNo].Item[item.CraneNo].CraneName = "RTV";
                            //    task = StatusCraneAsync(ctrlSCraneV1, _SubscribeInfo[item.GroupNo].Item[item.CraneNo]);

                            //    //if (trayExist)
                            //    //{
                            //    //    SiteTagInfo tagInfo = ReadSiteInfo(item);
                            //    //    task = DisplayBCRAsync(item.SiteNo, tagInfo);
                            //    //}

                            //    //task = StatusConveyorAsync(item.SiteNo, trayExist);
                            //}

                            //log = string.Format("[{0}-{1:D2}] {2} = {3}",
                            //    item.ControlType, 1, item.BrowseName, change.Value);
                        }

                        //CLogger.WriteLog(enLogLevel.Receive, this.Text, log);
                    }

                    //this.Invoke(new MethodInvoker(delegate ()
                    //{
                    //    Refresh();
                    //}));

                    // 비동기식 스레드
                    //this.BeginInvoke(new Action(() => Refresh()));

                    // 동기식 스레드
                    //this.Invoke(new Action(() => Refresh()));
                });

                Thread.Sleep(20);
                Application.DoEvents();
                this.BeginInvoke(new Action(() => Refresh()));
            }
        }
        #endregion

        #region ConveyorDataChange
        private void ConveyorDataChange(ItemInfo item, string value)
        {
            Task task;

            string log = string.Empty;

            int groupNo = item.GroupNo;
            int siteNo = item.SiteNo;

            if (item.BrowseName == "ConveyorInformation.TrayExist")
                _SubscribeInfo[groupNo].Item[siteNo].TrayExist = Convert.ToBoolean(value);

            if (item.BrowseName == "EquipmentStatus.Status")
                _SubscribeInfo[groupNo].Item[siteNo].EqpStatus = Convert.ToInt16(value);

            if (_SubscribeInfo[groupNo].Item[siteNo].TrayExist)
            {
                SiteTagInfo tagInfo = ReadSiteInfo(item);
                task = DisplayBCRAsync(item.GroupNo, item.SiteNo, tagInfo);

                _SubscribeInfo[groupNo].Item[siteNo].TrayRework = CheckReworkTray(tagInfo.TrayIdL1);
            }

            task = StatusConveyorAsync(item.GroupNo, item.SiteNo, _SubscribeInfo[groupNo].Item[siteNo]);

            log = string.Format("[{0}-T{1:D4}] {2} = {3}", item.ControlType, siteNo, item.BrowseName, value);

            CLogger.WriteLog(enLogLevel.Receive, this.Text, log);
        }
        #endregion

        #region StackerCraneDataChange
        private void StackerCraneDataChange(ItemInfo item, string value)
        {
            Task task;

            double pos;
            string log = string.Empty;

            int groupNo = item.GroupNo;
            int craneNo = item.CraneNo;

            if (item.BrowseName == "EquipmentStatus.Status")
            {
                _SubscribeInfo[groupNo].Item[craneNo].CraneName = "C";
                _SubscribeInfo[groupNo].Item[craneNo].EqpStatus = Convert.ToInt16(value);
                task = StatusCraneAsync(_ListSCrane[craneNo], _SubscribeInfo[groupNo].Item[craneNo]);
            }
            else if (item.BrowseName == "Carriage.PosBay")
            {
                double dBayCnt = 0;
                switch (item.CraneNo)
                {
                    case 0:     // HT Aging
                        dBayCnt = 12;
                        break;
                    case 3:     // Charger
                        dBayCnt = 5;
                        break;
                    default:    // LT Aging
                        dBayCnt = 18;
                        break;
                }

                pos = (double.Parse(value) / dBayCnt) * 100;
                task = MoveCraneAsync(_ListSCrane[craneNo], pos, _SubscribeInfo[groupNo].Item[craneNo]);
            }
            else if (item.BrowseName == "CraneCommand.TrayExist")
            {
                _SubscribeInfo[groupNo].Item[craneNo].CraneName = "C";
                _SubscribeInfo[groupNo].Item[craneNo].TrayExist = Convert.ToBoolean(value);
                task = StatusCraneAsync(_ListSCrane[craneNo], _SubscribeInfo[groupNo].Item[craneNo]);
            }
            else if ((item.BrowseName == "WaterTank01.TrayExist") || // WaterTank01
                     (item.BrowseName == "WaterTank01.FireSensor"))
            {
                int siteNo = GetWaterTankSiteNo(1, item.GroupNo, item.CraneNo);

                _SubscribeInfo[groupNo].Item[siteNo].GroupNo = item.GroupNo;
                _SubscribeInfo[groupNo].Item[siteNo].CraneNo = item.CraneNo;

                if (item.BrowseName == "WaterTank01.TrayExist")
                    _SubscribeInfo[groupNo].Item[siteNo].TrayExist = Convert.ToBoolean(value);

                if (item.BrowseName == "WaterTank01.FireSensor")
                    _SubscribeInfo[groupNo].Item[siteNo].FireSensor = Convert.ToBoolean(value);

                if (_SubscribeInfo[groupNo].Item[siteNo].TrayExist)
                {
                    SiteTagInfo tagInfo = ReadWaterTankInfo(item.ServerNo, item.CraneNo, 1);
                    _SubscribeInfo[groupNo].Item[siteNo].TrayRework = CheckReworkTray(tagInfo.TrayIdL1);
                }

                switch (item.GroupNo)
                {
                    case 1: // LT Aging WaterTank
                        if (item.CraneNo == 1)   // LT Aging#1 S/Crane
                        {
                            task = StatusConveyorAsync(groupNo, 11, _SubscribeInfo[groupNo].Item[siteNo]);
                        }
                        else   // LT Aging#2 WaterTank
                        {
                            task = StatusConveyorAsync(groupNo, 21, _SubscribeInfo[groupNo].Item[siteNo]);
                        }
                        break;
                    case 2: // HT Aging WaterTank
                        task = StatusConveyorAsync(groupNo, 1, _SubscribeInfo[groupNo].Item[siteNo]);
                        break;                    
                    case 3:    // Charger WaterTank
                        task = StatusConveyorAsync(groupNo, 31, _SubscribeInfo[groupNo].Item[siteNo]);
                        break;
                }

            }
            else if ((item.BrowseName == "WaterTank02.TrayExist") || // WaterTank02
                     (item.BrowseName == "WaterTank02.FireSensor"))
            {
                int siteNo = GetWaterTankSiteNo(2, item.GroupNo, item.CraneNo);

                if (siteNo > 0) 
                {
                    _SubscribeInfo[groupNo].Item[siteNo].GroupNo = item.GroupNo;
                    _SubscribeInfo[groupNo].Item[siteNo].CraneNo = item.CraneNo;

                    if (item.BrowseName == "WaterTank02.TrayExist")
                    {
                        _SubscribeInfo[groupNo].Item[siteNo].TrayExist = Convert.ToBoolean(value);
                    }

                    if (item.BrowseName == "WaterTank02.FireSensor")
                        _SubscribeInfo[groupNo].Item[siteNo].FireSensor = Convert.ToBoolean(value);

                    if (_SubscribeInfo[groupNo].Item[siteNo].TrayExist)
                    {
                        SiteTagInfo tagInfo = ReadWaterTankInfo(item.ServerNo, item.CraneNo, 2);
                        _SubscribeInfo[groupNo].Item[siteNo].TrayRework = CheckReworkTray(tagInfo.TrayIdL1);
                    }

                    switch (item.GroupNo)
                    {
                        case 1: // LT Aging WaterTank
                            if (item.CraneNo == 1)   // LT Aging#1 WaterTank
                            {
                                task = StatusConveyorAsync(groupNo, 12, _SubscribeInfo[groupNo].Item[siteNo]);
                            }
                            else   // LT Aging#2 WaterTank
                            {
                                task = StatusConveyorAsync(groupNo, 22, _SubscribeInfo[groupNo].Item[siteNo]);
                            }
                            break;
                        case 2: // HT Aging WaterTank
                            task = StatusConveyorAsync(groupNo, 2, _SubscribeInfo[groupNo].Item[siteNo]);
                            break;
                    }
                }
            }

            log = string.Format("[{0}-CraneNo{1:D2}] {2} = {3}", item.ControlType, item.CraneNo + 1, item.BrowseName, value);
            CLogger.WriteLog(enLogLevel.Receive, this.Text, log);
        }
        #endregion

        #region RTVDataChange
        private void RTVDataChange(ItemInfo item, string value)
        {
            double pos;
            string log = string.Empty;

            Task task;

            int groupNo = item.GroupNo;
            int craneNo = item.CraneNo;

            if (item.BrowseName == "EquipmentStatus.Status")
                _SubscribeInfo[groupNo].Item[craneNo].EqpStatus = Convert.ToInt16(value);

            if (item.BrowseName == "ConveyorInformation.CarriagePos")
            {
                pos = int.Parse(value);
                task = MoveCraneAsync(ctrlSCraneV1, pos, _SubscribeInfo[groupNo].Item[craneNo]);
            }
            else
            {
                _SubscribeInfo[groupNo].Item[craneNo].CraneName = "RTV";
                task = StatusCraneAsync(ctrlSCraneV1, _SubscribeInfo[groupNo].Item[craneNo]);

                //if (trayExist)
                //{
                //    SiteTagInfo tagInfo = ReadSiteInfo(item);
                //    task = DisplayBCRAsync(item.SiteNo, tagInfo);
                //}

                //task = StatusConveyorAsync(item.SiteNo, trayExist);
            }

            log = string.Format("[{0}-{1:D2}] {2} = {3}", item.ControlType, 1, item.BrowseName, value);

            CLogger.WriteLog(enLogLevel.Receive, this.Text, log);
        }
        #endregion

        #region GetConveyorEqpID
        private string GetConveyorEqpID(int eqpIdx)
        {
            string eqp = string.Empty;

            switch (eqpIdx)
            {
                case 0:
                    eqp = "F1CNV01";    //"F01CNV10010";
                    break;
                case 1:
                    eqp = "F1CNV02";
                    break;
                case 2:
                    eqp = "F1CNV03";
                    break;
                case 3:
                    eqp = "F1CNV04";
                    break;
                default:
                    CLogger.WriteLog(enLogLevel.Error, this.Text, "GetConveyorEqpID is Empty");
                    break;
            }

            return eqp;
        }
        #endregion

        #region GetCraneEqpID
        private string GetCraneEqpID(int eqpIdx)
        {
            string eqp = string.Empty;

            switch (eqpIdx)
            {
                case 0:
                    eqp = "F1SCL01";   // "F01STCL0010";
                    break;
                case 1:
                    eqp = "F1SCL02";    //"F01STCL0020";
                    break;
                case 2:
                    eqp = "F1SCH01";    //"F01STCH0010";
                    break;
                case 3:
                    eqp = "F1SCF01";    //"F01STCF0010";
                    break;
                default:
                    CLogger.WriteLog(enLogLevel.Error, this.Text, "GetCraneEqpID is Empty");
                    break;
            }

            return eqp;
        }
        #endregion

        #region GetWaterTankSiteNo
        public int GetWaterTankSiteNo(int waterTank, int groupNo, int craneNo)
        {
            int siteNo = 0;

            if (waterTank == 1)
            {
                switch (groupNo)
                {
                    case 1: // LT Aging WaterTank
                        if (craneNo == 1)   // LT Aging#1 WaterTank
                        {
                            siteNo = 11;
                        }
                        else   // LT Aging#2 WaterTank
                        {
                            siteNo = 21;
                        }
                        break;
                    case 2: // HT Aging WaterTank
                        siteNo = 1;
                        break;
                    case 3:
                        siteNo = 31;
                        break;
                }
            }
            else
            {
                switch (groupNo)
                {
                    case 1: // LT Aging WaterTank
                        if (craneNo == 1)   // LT Aging#1 WaterTank
                        {
                            siteNo = 12;
                        }
                        else   // LT Aging#2 WaterTank
                        {
                            siteNo = 22;
                        }
                        break;
                    case 2: // HT Aging WaterTank
                        siteNo = 2;
                        break;
                }
            }

            return siteNo;
        }
        #endregion

        public bool CheckReworkTray(string trayId)
        {
            bool ret = false;

            lock (_ReworkTray)
            {
                ret = _ReworkTray.Contains(trayId);
            }

            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

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
            string node = "ns=2;i=5013";
            _clientFMS[0].GetBrowerName(node);

            //WinTroubleAlarm form = new WinTroubleAlarm();
            //form.ShowDialog();

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
