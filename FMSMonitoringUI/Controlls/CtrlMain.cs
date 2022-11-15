using ControlGallery;
using CSVMgr;
using FMSMonitoringUI.Common;
//using Microsoft.Office.Interop.Excel;
using MonitoringUI;
using Novasoft.Logger;
using OPCUAClientClassLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

        private Logger _Logger; // { get; set; }

        public CtrlMain()
        {
            InitializeComponent();

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

            for (int i = 0; i < ctrlGroupList.Count; i++)
            {
                _clientFMS[i] = new OPCUAClient(DataList, ctrlGroupList[i], i);

                bool ret = await _clientFMS[i].ConnectAsync(opcList[i].OPCServerURL, opcList[i].UserID, opcList[i].UserPW);

                if (ret)
                {
                    // Start NodeID
                    _clientFMS[i].GetStartNodeID();

                    // Tag List
                    Dictionary<int, List<BrowsePath>> dictBrowsePath = _clientFMS[i].AddBrowsePath(_clientFMS[i].OPCTagList, i);
                    Dictionary<int, List<BrowsePathResult>> dictResultPath = _clientFMS[i].ReadBrowse(dictBrowsePath);

                    if (ctrlGroupList[i].ElementAt(0).ControlType == EnumCtrlType.CNV)
                    {
                        _clientFMS[i].AddConveyorNodeID(dictResultPath, dictBrowsePath);
                    }

                    // Subscribe List
                    dictBrowsePath = _clientFMS[i].AddBrowsePath(_clientFMS[i].SubscribeTagList, i);
                    dictResultPath = _clientFMS[i].ReadBrowse(dictBrowsePath);

                    _clientFMS[i].SubscribeNodes(dictResultPath, dictBrowsePath, _ListSite, ctrlGroupList[i].ElementAt(0));
                    _clientFMS[i].Subscription.DataChanged += Subscription_DataChanged;
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

            int craneCnt = 0;

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
                                    ControlType = EnumCtrlType.RTV,
                                    GroupNo = deviceID,
                                    ConveyorNo = conveyor.PLCNo
                                };
                            }
                            else
                            {
                                itemInfo = new ItemInfo()
                                {
                                    SiteNo = site.SiteNo,
                                    ControlType = EnumCtrlType.CNV,
                                    GroupNo = deviceID,
                                    ConveyorNo = conveyor.PLCNo
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
                    _ListSCrane.Add(int.Parse(crane.DeviceID), crane);

                    craneCnt++;
                }
            }

            int idx = 0;
            int groupCnt = groupCtrl.Count();
            for (int i = groupCnt; i < groupCnt + craneCnt; i++, idx++)
            {
                ItemInfo itemInfo = new ItemInfo()
                {
                    CraneNo = idx,
                    ControlType = EnumCtrlType.STC,
                    GroupNo = i
                };

                groupCtrl[i] = new List<ItemInfo> { itemInfo };
            }

            string log = $"Initialize the Controls";
            _Logger.Write(LogLevel.Information, log, LogFileName.AllLog);

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
            if (arg.DeviceInfo.IsControled) // 장비 안쪽에 Conveyor 는 제어 안하는거다
            {
                //SiteMonitor f = new SiteMonitor();
                //f.SetSiteNo(arg.DeviceInfo.SiteNo);
                //f.SetPLC(GlobalArea.g_CVPLCList.GetCVPLC(arg.DeviceInfo.CVPLCListDeviceID));
                //f.SetBCRHandler(GlobalArea.g_BCRHandlerList.GetBCRHandler(arg.DeviceInfo.SiteNo));
                //f.StartPosition = FormStartPosition.CenterScreen;
                //f.Show(this);

                int groupno = arg.DeviceInfo.CVPLCListDeviceID;
                int trackno = arg.DeviceInfo.SiteNo;
                string info;

                try
                {
                    List<ReadValueId> cvInfo = _clientFMS[groupno].ConveyorNodeID[trackno];
                    List<DataValue> data = _clientFMS[groupno].ReadNodeID(cvInfo);

                    SiteTagInfo tagInfo = new SiteTagInfo()
                    {
                        TrayIdL1 = data[(int)EnumSite.TrayIdL1].Value.ToString(),
                        TrayIdL2 = data[(int)EnumSite.TrayIdL2].Value.ToString()
                    };

                    info = string.Format($"TrackNo={trackno}, TrayIdL1={tagInfo.TrayIdL1}, TrayIdL2={tagInfo.TrayIdL2}");
                }
                catch (Exception ex)
                {
                    info = string.Format($"Error={ex}");
                }

                MessageBox.Show(info.ToString());
            }
        }

        private void Crane_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //SCrane crane = sender as SCrane;
            //CraneHandler.SCHandler h = crane.GetSCHandler();
            //h.ShowStatusForm(this);

            MessageBox.Show("Crane_MouseDoubleClick");
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

                if (item.BrowseName == "TrayExist")
                    trayExist = bool.Parse(change.Value.ToString());

                if (item.ControlType == EnumCtrlType.CNV)
                {
                    if (trayExist)
                    {
                        SiteTagInfo tagInfo = ReadSiteInfo(item);
                        task = DisplayBCRAsync(item.SiteNo, tagInfo);
                    }

                    task = StatusConveyorAsync(item.SiteNo, trayExist);
                }
                else if (item.ControlType == EnumCtrlType.STC)
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
                }
                else if (item.ControlType == EnumCtrlType.RTV)
                {
                    if (item.BrowseName == "CarriagePos")
                    {
                        pos = int.Parse(change.Value.ToString());
                        task = MoveCraneAsync(ctrlSCraneV1, pos);
                    }
                    else
                    {
                        task = StatusCraneAsync(ctrlSCraneV1, trayExist, "RTV");
                    }
                }
            }

            // Update the value
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(delegate ()
            //    {
            //        bool trayExist = false;
            //        int pos = 0;

            //        foreach (DataChange change in e.DataChanges)
            //        {
            //            ItemInfo item = change.MonitoredItem.UserData as ItemInfo;

            //            if (item.BrowseName == "TrayExist")
            //                trayExist = bool.Parse(change.Value.ToString());                            

            //            if (item.ControlType == EnumCtrlType.CNV)
            //            {
            //                if (trayExist)
            //                {
            //                    ConveyorData conveyor = ReadConveyorInfo(item);
            //                    BCRUpdateUI(item.TrackNo, conveyor);

            //                    ctrlSCraneV1.UpdateUI(trayExist, "RTV");
            //                }

            //                if (item.BrowseName == "CarriagePos")
            //                {
            //                    pos = int.Parse(change.Value.ToString());
            //                    Task ret = MoveRTV(ctrlSCraneV1, pos);
            //                }
            //                else
            //                {
            //                    ConveyorUpdateUI(item.TrackNo, trayExist);
            //                }
            //            }
            //            else
            //            {
            //                if (item.BrowseName == "PosBay")
            //                {
            //                    pos = int.Parse(change.Value.ToString());
            //                    Task ret = MoveCrane(_ListSCrane[item.CraneNo], pos);
            //                    //Task ret = Start(_ListSCrane[item.CraneNo], pos);
            //                }
            //                else
            //                {
            //                    _ListSCrane[item.CraneNo].UpdateUI(trayExist, "C");
            //                }
            //            }
            //        }
            //    }));
            //}
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
                TrayIdL1 = data[(int)EnumSite.TrayIdL1].Value.ToString(),
                TrayIdL2 = data[(int)EnumSite.TrayIdL2].Value.ToString()
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


    }
}
