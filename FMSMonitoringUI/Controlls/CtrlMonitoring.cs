using ControlGallery;
using CSVMgr;
using DBHandler;
using FMSMonitoringUI.Common;
using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
//using Microsoft.Office.Interop.Excel;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Monitoring;
using MySql.Data.MySqlClient;
using Novasoft.Logger;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Utilities;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Interop;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlMonitoring : UserControlRoot
    {
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
        private Dictionary<int, BCRMarker> _ListBCR = new Dictionary<int, BCRMarker>();

        /// <summary>
        /// First=Equipment ID, Second=Control Index
        /// </summary>
        private Dictionary<string, ItemInfo> _ControlIdx = new Dictionary<string, ItemInfo>();

        /// <summary>
        /// First=Equipment ID, Second=Eqp UserControl
        /// </summary>
        private Dictionary<string, UserControlEqp> _EntireEqpList = new Dictionary<string, UserControlEqp>();
                
        private COPCGroupCtrl _OPCGroupList= new COPCGroupCtrl();

        private Logger _Logger; // { get; set; }

        private ApplicationInstance _OPCApplication = null;
        //public ApplicationInstance OPCApplication
        //{
        //    get { return _OPCApplication; }
        //    set { _OPCApplication = value; }
        //}

        private MySqlManager _mysql;

        #region CtrlMain
        public CtrlMonitoring(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

            _OPCApplication = applicationInstance;

            // Timer 
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Stop();

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
            string msg = $"Full Monitoring";
            _Logger.Write(LogLevel.Info, msg, LogFileName.AllLog);

            InitMonitoring();
        }
        #endregion

        #region MonitoringTimer
        public void MonitoringTimer(bool onoff)
        {
            // Timer
            if (onoff) m_timer.Start();
            else m_timer.Stop();
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
            _ListBCR.Clear();
            _ControlIdx.Clear();

            CDeviceInfo[] siteInfo = new CDeviceInfo[CDefine.DEF_PLC_SERVER_COUNT];

            for (int i = 0; i < CDefine.DEF_PLC_SERVER_COUNT; i++)
            {
                _ListSite[i] = new Dictionary<int, ItemInfo>();
                siteInfo[i] = new CDeviceInfo();
            }

            //int craneCnt = 0;

            // First=OPCUA Server로 구성된 Conveyor, Second=Site정보
            Dictionary<int, List<ItemInfo>> groupCtrl = new Dictionary<int, List<ItemInfo>>();

            foreach (var ctl in this.Controls)
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
            }

            foreach (var ctl in this.Controls)
            { 
                if (ctl.GetType() == typeof(BCRMarker))
                {
                    BCRMarker bcr = ctl as BCRMarker;
                    //bcr.ObjectDoubleClick += OnObjectDoubleClick;

                    // tray-id bubble text
                    BubbleText bt = new BubbleText();
                    bcr.SetBubbleTextObject(bt, bcr.BCRLevel, bcr.BCRMarkPosition);

                    //
                    _ListBCR.Add(bcr.PLCNo, bcr);
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
                    _EntireEqpList.Add(eqp.EqpID, eqp);
                }
            }

            for (int i = 0; i < CDefine.DEF_PLC_SERVER_COUNT; i++)
            {
                if (craneInfo[i].Item.Count > 0)
                {
                    _OPCGroupList.AddList(i, craneInfo[i]);
                }
            }

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

        private void CtrlEqp_MouseClick_Evnet(object sender, MouseEventArgs e)
        {
            //CtrlEqpDegas gv = (CtrlEqpDegas)sender;

            //gv.TrayInfoView.CurrentCell = null;
            //gv.TrayInfoView.ClearSelection();
            //gv.Refresh();

            //ctrlEqpDGS.Refresh();
        }
        #endregion

        #region OnTimer
        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                m_timer.Stop();

                ReadEqpInfo();

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
        private void OnObjectDoubleClick(object sender, ObjectDoubleClickEventArgs arg)
        {
            if (arg.DeviceInfo.SiteNo > 0)
            {
                int groupno = arg.DeviceInfo.CVPLCListDeviceID;
                int trackno = arg.DeviceInfo.SiteNo;

                try
                {
                    if (_clientFMS[groupno] != null)
                    {
                        List<ReadValueId> cvInfo = _clientFMS[groupno].ConveyorNodeID[trackno];
                        List<DataValue> data = _clientFMS[groupno].ReadNodeID(cvInfo);

                        SiteTagInfo siteInfo = new SiteTagInfo()
                        {
                            ConveyorNo = int.Parse(data[(int)enSiteTagList.ConveyorNo].Value.ToString()),
                            ConveyorType = int.Parse(data[(int)enSiteTagList.ConveyorType].Value.ToString()),
                            StationStatus = int.Parse(data[(int)enSiteTagList.StationStatus].Value.ToString()),
                            TrayIdL1 = data[(int)enSiteTagList.TrayIdL1].Value.ToString(),
                            TrayIdL2 = data[(int)enSiteTagList.TrayIdL2].Value.ToString(),
                            TrayCount = int.Parse(data[(int)enSiteTagList.TrayCount].Value.ToString()),
                            TrayExist = bool.Parse(data[(int)enSiteTagList.TrayExist].Value.ToString()),
                            TrayType = int.Parse(data[(int)enSiteTagList.TrayType].Value.ToString())
                        };

                        string msg = $"Track No : {trackno}, TrayIdL1 : {siteInfo.TrayIdL1}, TrayIdL2 : {siteInfo.TrayIdL2}";
                        _Logger.Write(LogLevel.Info, "", LogFileName.ButtonClick);

                        WinCVTrayInfo winTray = new WinCVTrayInfo();
                        winTray.SetTrayInfo(siteInfo);
                        winTray.Show();

                    }                   
                }
                catch (Exception ex)
                {
                    string info = string.Format($"Error={ex}");
                    MessageBox.Show(info);
                }
            }
        }

        private void Crane_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CtrlSCrane crane = sender as CtrlSCrane;

            if (crane.DeviceID > 0)
            {
                try
                {
                    if (_clientFMS[crane.DeviceID] != null)
                    {
                        List<ReadValueId> craneInfo = _clientFMS[crane.DeviceID].CraneNodeID[crane.CraneID];
                        List<DataValue> data = _clientFMS[crane.DeviceID].ReadNodeID(craneInfo);

                        CraneTagInfo item = new CraneTagInfo()
                        {
                            TrayIdL1 = data[(int)enCraneTagList.TrayIdL1].Value.ToString(),
                            TrayIdL2 = data[(int)enCraneTagList.TrayIdL2].Value.ToString(),
                            TrayCount = int.Parse(data[(int)enCraneTagList.TrayCount].Value.ToString()),
                            TrayExist = bool.Parse(data[(int)enCraneTagList.TrayExist].Value.ToString()),
                            JobType = int.Parse(data[(int)enCraneTagList.JobType].Value.ToString())
                        };

                        string msg = $"Crane No : {crane.CraneID}, TrayIdL1 : {item.TrayIdL1}, TrayIdL2 : {item.TrayIdL2}";
                        _Logger.Write(LogLevel.Info, "", LogFileName.ButtonClick);

                        WinCraneInfo winCrane = new WinCraneInfo();
                        winCrane.SetTrayInfo(item);
                        winCrane.Show();

                    }
                }
                catch (Exception ex)
                {
                    string info = string.Format($"Error={ex}");
                    MessageBox.Show(info);
                }
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
            //            task = DisplayBCRAsync(item.SiteNo, tagInfo);
            //        }

            //        task = StatusConveyorAsync(item.SiteNo, trayExist);

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
                TrayIdL1 = data[(int)enSiteTagList.TrayIdL1].Value.ToString(),
                TrayIdL2 = data[(int)enSiteTagList.TrayIdL2].Value.ToString()
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
                    userControl.SetData(row);
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
        private async Task DisplayBCRAsync(int bcrno, SiteTagInfo tagInfo)
        {
            Task task = DisplayBCR(bcrno, tagInfo);

            await task;
        }

        private async Task DisplayBCR(int bcrno, SiteTagInfo tagInfo)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (_ListBCR.ContainsKey(bcrno))
                        {
                            BCRMarker bcr_ui = _ListBCR[bcrno];

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
        private async Task CallWinTrayInfoAsync(SiteTagInfo tagInfo)
        {
            Task task = TrayInfoPopup(tagInfo);

            await task;
        }
        private async Task TrayInfoPopup(SiteTagInfo tagInfo)
        {
            //if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    WinCVTrayInfo winTray = new WinCVTrayInfo();
                    winTray.SetTrayInfo(tagInfo);
                    winTray.Show();
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
                                task = DisplayBCRAsync(item.SiteNo, tagInfo);
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

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        Refresh();
                    }));
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

            string sql = "SELECT * FROM tb_dat_cell;";            
            string jsonResult = rest.GetJson(enActionType.SQL_SELECT, sql);

            _jsonDatCellResponse j1 =  rest.ConvertDatCell(jsonResult);

            sql = "SELECT * FROM fms_v.tb_dat_tray Where tray_id = 'TRV000001'";
            jsonResult = rest.GetJson(enActionType.SQL_SELECT, sql);

            _jsonDatTrayResponse j2 = rest.ConvertDatTray(jsonResult);

        }
    }
}
