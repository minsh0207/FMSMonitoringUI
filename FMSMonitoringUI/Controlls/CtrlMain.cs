using ControlGallery;
using CSVMgr;
using FMSMonitoringUI.Common;
using FMSMonitoringUI.Monitoring;
//using Microsoft.Office.Interop.Excel;
using MonitoringUI;
using Novasoft.Logger;
using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlMain : UserControlRoot
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
        /// First=SiteNo, Second=ItemInfo Class
        /// </summary>
        private Dictionary<int, ItemInfo> _ListSite = new Dictionary<int, ItemInfo>();
        /// <summary>
        /// First=BCRNo, Second=BCRMarker Control
        /// </summary>
        private Dictionary<int, BCRMarker> _ListBCR = new Dictionary<int, BCRMarker>();

        /// <summary>
        /// First=Equipment ID, Second=Control Index
        /// </summary>
        private Dictionary<string, ItemInfo> _ControlIdx = new Dictionary<string, ItemInfo>();

        private Logger _Logger; // { get; set; }

        private ApplicationInstance _Application = null;

        public CtrlMain(ApplicationInstance applicationInstance)
        {
            InitializeComponent();

            _Application = applicationInstance;

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);
        }

        #region CtrlMain_Load
        /// <summary>
        /// Total MonitoringUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CtrlMain_Load(object sender, EventArgs e)
        {
            Dictionary<int, List<ItemInfo>> ctrlGroupList = InitControls();

            List<EqpTagItem> DataList = ReadTagConfig();
            List<COPCUAConfig> opcList = ReadOPCConfig();

            _clientFMS = new OPCUAClient[opcList.Count()];

            for (int i = 0; i < opcList.Count; i++)
            {
                _clientFMS[i] = new OPCUAClient(DataList, ctrlGroupList[i], _Application);
                
                bool ret = await _clientFMS[i].ConnectAsync(opcList[i].OPCServerURL, opcList[i].UserID, opcList[i].UserPW);

                if (ret)
                {
                    _Logger.Write(LogLevel.Info, $"Connected to {opcList[i].OPCServerURL}", LogFileName.AllLog);

                    // Start NodeID
                    _clientFMS[i].GetStartNodeID(opcList[i].FirstNodeID);

                    // Tag List
                    Dictionary<int, List<BrowsePath>> dictBrowsePath = _clientFMS[i].AddBrowsePath(_clientFMS[i].OPCTagList);
                    Dictionary<int, List<BrowsePathResult>> dictResultPath = _clientFMS[i].ReadBrowse(dictBrowsePath);

                    if (ctrlGroupList[i].ElementAt(0).ControlType == enEqpType.CNV)
                    {
                        _clientFMS[i].AddConveyorNodeID(dictResultPath, dictBrowsePath);
                    }
                    else if (ctrlGroupList[i].ElementAt(0).ControlType == enEqpType.STC)
                    {
                        _clientFMS[i].AddCraneNodeID(dictResultPath, dictBrowsePath, _ControlIdx);
                    }

                    // Subscribe List
                    dictBrowsePath = _clientFMS[i].AddBrowsePath(_clientFMS[i].SubscribeTagList);
                    dictResultPath = _clientFMS[i].ReadBrowse(dictBrowsePath);

                    _clientFMS[i].SubscribeNodes(dictResultPath, dictBrowsePath, _ListSite, _ControlIdx);
                    _clientFMS[i].Subscription.DataChanged += Subscription_DataChanged;
                }
                else
                {
                    _clientFMS[i] = null;
                }
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
            _ListSite.Clear();
            _ListBCR.Clear();
            _ControlIdx.Clear();

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

                            if (site.SiteNo == 1)
                            {
                                itemInfo = new ItemInfo()
                                {
                                    SiteNo = site.SiteNo,
                                    ControlType = enEqpType.RTV,
                                    GroupNo = deviceID,
                                    ConveyorNo = conveyor.PLCNo,
                                    EqpID = GetConveyorEqpID(deviceID)
                                    
                                };
                            }
                            else
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

                            _ListSite.Add(site.SiteNo, itemInfo);

                            if (groupCtrl.ContainsKey(deviceID))
                            {
                                groupCtrl[deviceID].Add(itemInfo);
                            }
                            else
                            {
                                groupCtrl[deviceID] = new List<ItemInfo> { itemInfo };
                            }

                            if (!_ControlIdx.ContainsKey(itemInfo.EqpID))
                            {
                                _ControlIdx[itemInfo.EqpID] = itemInfo;
                            }
                        }
                    }
                }

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

                if (ctl.GetType() == typeof(CtrlSCraneV))       // RTV 대용으로 사용
                {
                    CtrlSCraneV crane = ctl as CtrlSCraneV;
                    //crane.SetSCHandler(GlobalArea.g_SCHandlerList.Find(x => x.DeviceID == crane.DeviceID));
                    crane.MouseDoubleClick += Crane_MouseDoubleClick;
                    
                    //_ListCrane.Add(crane);
                }

                if (ctl.GetType() == typeof(CtrlSCraneH))
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

                    if (!_ControlIdx.ContainsKey(itemInfo.EqpID))
                    {
                        _ControlIdx[itemInfo.EqpID] = itemInfo;
                    }

                    //craneCnt++;
                }
            }

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

            string log = $"Initialize the Controls";
            _Logger.Write(LogLevel.Info, log, LogFileName.AllLog);

            return groupCtrl;
        }
        #endregion

        #region ReadConfig
        /// <summary>
        /// TAGS_CLIENT_V1.xlsx TagList를 읽어온다.
        /// </summary>
        /// <returns></returns>
        private List<EqpTagItem> ReadTagConfig()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\TagList");

            FMSTagConfigReader reader = new FMSTagConfigReader($"{di}{RunningEnv.StaticParamClass.CONFIG_FILENAME_TAG}");
            return reader.Read();
        }
        /// <summary>
        /// OPCUAList.csv에서 OPC Config정보를 읽어온다.
        /// </summary>
        /// <returns></returns>
        private List<COPCUAConfig> ReadOPCConfig()
        {
            CSVLoader csv_opc = new CSVLoader(RunningEnv.StaticParamClass.CONFIG_FILENAME_OPCUA);
            return csv_opc.Load<COPCUAConfig>();
        }
        #endregion

        //private int nIdx = 0;
        //private int nRTVIdxH = 0;
        //private int nRTVIdxV = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            //Task Ret = MoveRTV(1, 1000);



            //for (int i = 0; i < 1000; i++)
            //{
            //    ctrlSCraneV1.CurrentBay = i;
            //    ctrlSCraneV1.UpdateUI("RTV");
            //    Thread.Sleep(50);

            //}
            //int[] nRTVPosV = { 1, 11, 21, 32, 44, 60, 74, 90, 98 };
            //int[] nRTVPosH = { 1, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            //if (nRTVIdxV > 8) nRTVIdxV = 0;
            //ctrlSCraneV1.CurrentBay = nRTVPosV[nRTVIdxV];
            //ctrlSCraneV1.UpdateUI("RTV");

            //if (nRTVIdxH > 10) nRTVIdxH = 0;
            //_ListSCrane[1].CurrentBay = nRTVPosH[nRTVIdxH];
            //_ListSCrane[1].UpdateUI("In");

            //ctrlSCraneH2.CurrentBay = nRTVPosH[nRTVIdxH];
            //ctrlSCraneH2.UpdateUI("In");

            //ctrlSCraneH3.CurrentBay = nRTVPosH[nRTVIdxH];
            //ctrlSCraneH3.UpdateUI("In");

            //nRTVIdxV++;
            //nRTVIdxH++;

            //if (true)
            //{
            //    if (_ListSite.ContainsKey(nIdx))
            //    {
            //        int nCVNo = _ListSite[nIdx];

            //        if (nCVNo > 0)
            //        {
            //            if (_ListSite.ContainsKey(nCVNo))
            //            {
            //                _ListConveyor[nCVNo].UpdateTrackStatus(nIdx);

            //                if (_ListBCR.ContainsKey(nIdx))
            //                {
            //                    BCRMarker bcr_ui = _ListBCR[nIdx];

            //                    if (bcr_ui.BCRLevel == 1)
            //                    {
            //                        bcr_ui.BubbleText = "F101AAFB1010683";
            //                    }
            //                    else
            //                    {
            //                        bcr_ui.BubbleText = "F101AAFB1010683\nF101AAFB1010684";
            //                    }

            //                    if (bcr_ui.BubbleText != null && bcr_ui.BubbleText.Length > 0)
            //                    {
            //                        bcr_ui.ShowToolTip();
            //                        bcr_ui.BubbleText = string.Empty;
            //                    }

            //                    bcr_ui.BCRUseYN = true;
            //                }

            //                Refresh();
            //            }
            //        }
            //    }

            //    nIdx++;
            //}
            //else
            //{
            //    //ctrlSiteTrack1.DemoSiteStatus();
            //}
        }

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

                        WinTrayInfo winTray = new WinTrayInfo();
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
            //if (e.DataChanges.Count > 1)        // 프로그램 기동시 모든 구독목록이 들어온다. 처음연결시 들어오는 event는 무시한다.
            //{
            //    return;
            //}

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

                    task = StatusConveyorAsync(item.SiteNo, trayExist);

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
                        item.ControlType, item.CraneNo+1, item.BrowseName, change.Value);
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
        private async Task StatusConveyorAsync(int siteno, bool trayExist)
        {
            Task task = StatusConveyor(siteno, trayExist);

            await task;
        }

        private async Task StatusConveyor(int siteno, bool trayExist)
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        ItemInfo siteInfo = _ListSite[siteno];

                        if (siteInfo.ConveyorNo > 0)
                        {
                            _ListConveyor[siteInfo.ConveyorNo].UpdateTrackStatus(siteno, trayExist);
                        }

                        Refresh();
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
                    WinTrayInfo winTray = new WinTrayInfo();
                    winTray.SetTrayInfo(tagInfo);
                    winTray.Show();
                });
            }
        }
        #endregion

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
            }

            return eqp;
        }
    }
}
