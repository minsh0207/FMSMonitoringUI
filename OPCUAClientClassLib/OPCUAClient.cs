using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaClient.Controls;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using Novasoft.Logger;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace OPCUAClientClassLib
{
    public partial class OPCUAClient : IDisposable
    {
        /// <summary>
        /// Subscription_DataChanged
        /// </summary>
        public delegate void SubscriptionEventHandler(int opcIdx, string url);
        /// <summary>
        /// Use the delegate as event.
        /// </summary>
        public event SubscriptionEventHandler SubscriptionEvent = null;
        /// <summary>
        /// Subscription_DataChanged
        /// </summary>
        public void OnSubscriptionEvent(int opcIdx, string url)
        {
            if (SubscriptionEvent != null)
            {
                SubscriptionEvent(opcIdx, url);
            }
        }

        /// <summary>
        /// ServerConnectionStatus
        /// </summary>
        public delegate void ConnectionEventHandler(int opcIdx, string url, ServerConnectionStatus status);
        public event ConnectionEventHandler ConnectionStatusEvent = null;

        public void OnConnectionStatusEvent(int opcIdx, string url, ServerConnectionStatus status)
        {
            if (ConnectionStatusEvent != null)
            {
                ConnectionStatusEvent(opcIdx, url, status);
            }
        }


        private static int BROWSEPATH_MAXCOUNT = 999;
        private Logger _Logger;

        #region [public props]
        //public string FIRST_NODEID = "ns=2;i=1000";

        /// <summary>
        /// Tag의 Start NodeID
        /// </summary>
        //string _StartNodeID;
        //public string StartNodeID
        //{
        //    get => _StartNodeID;
        //    set => _StartNodeID = value;
        //}



        private Dictionary<string, List<CBrowerInfo>> _OPCTagList;
        public Dictionary<string, List<CBrowerInfo>> OPCTagList
        {
            get => _OPCTagList;
            set => _OPCTagList = value;
        }

        //List<string> _SubscribeTagList;
        //public List<string> SubscribeTagList
        //{
        //    get => _SubscribeTagList;
        //    set => _SubscribeTagList = value;
        //}

        private Dictionary<int, List<BrowsePath>> _PathsToTranslate;
        public Dictionary<int, List<BrowsePath>> PathsToTranslate
        {
            get => _PathsToTranslate;
            set => _PathsToTranslate = value;
        }

        private Dictionary<int, List<ReadValueId>> _ConveyorNodeID;
        public Dictionary<int, List<ReadValueId>> ConveyorNodeID
        {
            get => _ConveyorNodeID;
            set => _ConveyorNodeID = value;
        }

        private Dictionary<int, List<ReadValueId>> _CraneNodeID;
        public Dictionary<int, List<ReadValueId>> CraneNodeID
        {
            get => _CraneNodeID;
            set => _CraneNodeID = value;
        }

        /// <summary>
        /// First=BrowseName, Second=NamespaceIndex
        /// </summary>
        private Dictionary<string, int> _BrowseNSIndex = new Dictionary<string, int>();
        public Dictionary<string, int> BrowseNSIndex
        {
            get => _BrowseNSIndex;
            set => _BrowseNSIndex = value;
        }

        //Dictionary<int, OPCTagItem> _BrowseNodeID; 
        //public Dictionary<int, OPCTagItem> BrowseNodeID
        //{
        //    get => _BrowseNodeID;
        //    set => _BrowseNodeID = value;
        //}

        /// <summary>
        /// FMS에서 수신된 장비 ID
        /// </summary>
        string _EqpID;
        public string EQP_ID
        {
            get => _EqpID;
            set => _EqpID = value;
        }

        /// <summary>
        /// FMS에서 수신된 장비 Type
        /// </summary>
        string _EqpType;
        public string EqpType
        {
            get => _EqpType;
            set => _EqpType = value;
        }
        /// <summary>
        /// Provides access to the OPC UA server and its services.
        /// </summary>
        //private ApplicationInstance m_Application = null;

        /// <summary>
        /// Provides access to OPC UA server.
        /// </summary>
        Session _session;
        public Session Session
        {
            get => _session;
            set => _session = value;
        }

        /// <summary>
        /// OPC UA server no.
        /// </summary>
        int _serverNo;
        public int ServerNo
        {
            get => _serverNo;
            set => _serverNo = value;
        }

        /// <summary>
        /// Provides access to the subscription being created.
        /// </summary>
        private Subscription _Subscription = null;
        public Subscription Subscription
        {
            get { return _Subscription; }
            set { _Subscription = value; }           
        }

        /// <summary>
        /// Publishing enabled for the subscription
        /// </summary>
        private bool _PublishingEnabled = true;
        public bool PublishingEnabled
        {
            get => _PublishingEnabled;
            set => _PublishingEnabled = value;
        }
        /// <summary>
        /// The publishing interval for the subscription
        /// </summary>
        private double _PublishingInterval = 500;        // Default 500
        public double PublishingInterval
        {
            get => _PublishingInterval;
            set => _PublishingInterval = value;
        }

        private bool _Connected = false;
        public bool Connected
        {
            get
            {
                return _Connected && _session != null;
            }
            set
            {
                if (value != _Connected)
                {
                    _Connected = value;
                }
            }
        }

        /// <summary>
        /// CreateMonitoredItems 상태 코드
        /// </summary>
        bool _StatusCode;
        public bool StatusCode
        {
            get => _StatusCode;
            set => _StatusCode = value;
        }

        private ApplicationInstance _OPCApplication;

        //private List<ItemInfo> _TrackList;

        private List<CDeviceInfo> _DeviceList;

        private Dictionary<string, ItemInfo> _ControlIdx;

        private Dictionary<int, ItemInfo> _ListSite;

        private string _FirstNodeID;

        #endregion

        #region Properties to access Controls
        //string m_lastClientUrlsForReverseConnect;

        bool IsReverseConnectSelected
        {
            get
            {
                return false;
            }
        }

        //string ClientUrlForReverseConnect
        //{
        //    get
        //    {
        //        if (IsReverseConnectSelected)
        //        {
        //            return m_lastClientUrlsForReverseConnect;
        //        }
        //        return null;
        //    }
        //}
        #endregion

        //public delegate void EventHandler(string value);
        //public event EventHandler Subscription_Event = null;

        //public OPCUAClient(
        //    List<CEqpTagItem> dataList, 
        //    List<ItemInfo> trackList, 
        //    ApplicationInstance application,
        //    Dictionary<string, ItemInfo> controlIndex,
        //    Dictionary<int, ItemInfo> listSite)
        //{
        //    _OPCApplication = application;
        //    _TrackList = trackList;
        //    _ControlIdx = controlIndex;
        //    _ListSite = listSite;

        //    string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
        //    _Logger = new Logger(logPath, LogMode.Hour);

        //    LoadTagList(dataList, _TrackList);
        //}

        public OPCUAClient(
            List<CEqpTagItem> dataList,
            List<CDeviceInfo> deviceList,
            ApplicationInstance application,
            Dictionary<string, ItemInfo> controlIndex,
            Dictionary<int, ItemInfo> listSite)
        {
            _OPCApplication = application;
            _DeviceList = deviceList;
            _ControlIdx = controlIndex;
            _ListSite = listSite;

            string logPath = ConfigurationManager.AppSettings["LOG_PATH"];
            _Logger = new Logger(logPath, LogMode.Hour);

            LoadTagList(dataList, _DeviceList);
        }

        /// <summary>
        /// Task를 통해 OPCUA 통신 연결 호출
        /// </summary>
        /// <param name="connect_uri"></param>
        /// <param name="user_id"></param>
        /// <param name="user_pw"></param>
        /// <returns></returns>
        public async Task ConnectAsync(string connect_uri, string user_id, string user_pw, string firstNodeID)
        {
            _FirstNodeID = firstNodeID;

            //Task task = Task.Run(() => Connect(connect_uri, user_id, user_pw));
            //await task;

            await Task.Run(() => Connect(connect_uri, user_id, user_pw));
        }

        /// <summary>
        /// OPCUA 통신 연결
        /// </summary>
        /// <param name="connect_uri"></param>
        /// <param name="user_id"></param>
        /// <param name="user_pw"></param>
        /// <returns></returns>
        private void Connect(string connect_uri, string user_id, string user_pw)
        {            
            try
            {
                //
                DisconnectIfRequired();

                //
                _LOG_(LogLevel.OPCUA, $"Connecting to [{connect_uri}]");

                // Get the endpoint by connecting to server's discovery endpoint.
                // Try to find the first endopint without security.
                bool urlType = false;
                if (urlType)
                {
                    EndpointDescription endpoint;
                    endpoint = GetEndPoint(connect_uri);

                    _LOG_(LogLevel.OPCUA, $"EndPoint [{endpoint}]");

                    if (endpoint != null)
                        ConnectToSelectedEndpoint(endpoint, user_id, user_pw);
                }
                else
                {
                    // 원격 uri접속
                    ConnectWithDiscoveryUrl(connect_uri);
                }

                //EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(_app_config);
                //ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

                //
                //var login = new UserIdentity(user_id, user_pw);

                // Create the session
                //Session session = await Session.Create(
                //    _app_config,
                //    endpoint,
                //    false,
                //    false,
                //    _app_config.ApplicationName,
                //    10 * 1000,
                //    login,
                //    null
                //);

                // Assign the created session
                //if (session != null && session.Connected)
                //{
                //    _session = session;
                //    _session.KeepAliveInterval = 5000; // every 10 sec calls 'Session_KeepAlive' : default: 5000
                //    _session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);
                //}

                // Session created successfully.
                //msg = ($"[{connect_uri}] Connected, SessionName = {_session.SessionName}");
            }
            catch (Exception ex)
            {
                // Log Error
                _EX_LOG_(ex);
            }
        }

        private void Disconnect()
        {
            try
            {
                if (_session != null)
                {
                    _LOG_(LogLevel.OPCUA, "Disconnecting...");

                    // Call the disconnect service of the server.
                    _session.Disconnect(SubscriptionCleanupPolicy.Delete, null);
                    _session.ConnectionStatusUpdate -= new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);
                    _session.Dispose();
                    _session = null;

                    Connected = false;

                    // Log Session Disconnected event
                    _LOG_(LogLevel.OPCUA, "Session Disconnected.");
                }
                else
                {
                    _LOG_(LogLevel.Error, "Session not created!");
                }
            }
            catch (Exception ex)
            {
                _EX_LOG_(ex);
            }
        }

        public void DisconnectIfRequired()
        {
            if (_session != null)
            {
                Disconnect();
            }
        }

        private void CreateSession()
        {
            try
            {
                _session = new Session(_OPCApplication);

            }
            catch (Exception ex)
            {
                _EX_LOG_(ex);
            }

        }

        private void ConnectToSelectedEndpoint(EndpointDescription endpoint, string user_id, string user_pw)
        {
            CreateSession();

            _session.UseDnsNameAndPortFromDiscoveryUrl = true;
            _session.DefaultRequestSettings.OperationTimeout = 30000;

            // Attach to events
            _session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);

            // Call connect with endpoint
            if (!IsReverseConnectSelected)
            {
                _session.UserIdentity = new UserIdentity
                {
                    IdentityType = UserIdentityType.UserName, 
                    UserName = user_id, 
                    Password = user_pw 
                };

                _session.Connect(endpoint, RetryInitialConnect.Yes, null);
                
            }
            else
            {
                _session.ReverseConnect(endpoint, null);
            }
        }

        private void ConnectWithDiscoveryUrl(string connect_uri)
        {
            CreateSession();

            _session.UseDnsNameAndPortFromDiscoveryUrl = true;
            _session.DefaultRequestSettings.OperationTimeout = 30000;

            // Attach to events
            _session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);

            // Id & Password
            //_session.UserIdentity = new UserIdentity() { IdentityType = UserIdentityType.UserName, UserName = "fms", Password = "fms@!" };
            
            // Call connect with URL
            //if (IsReverseConnectSelected)
            //{
            //    _session.ReverseConnect(connect_uri, SecuritySelection.None);
            //}
            //else
            {
                _session.Connect(connect_uri, SecuritySelection.None);
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void Session_ServerConnectionStatusUpdate(Session sender, ServerConnectionStatusUpdateEventArgs e)
        {
            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke(new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate), sender, e);
            //    return;
            //}

            // check that the current session matches the session that raised the event.
            if (!Object.ReferenceEquals(_session, sender))
            {
                return;
            }

            lock (this)
            {
                string msg = string.Empty;
                string endpointUri = string.Empty;

                if (_session.EndpointDescription != null)
                {
                    endpointUri = _session.EndpointDescription.EndpointUrl;
                }
                OnConnectionStatusEvent(ServerNo, endpointUri, e.Status);

                switch (e.Status)
                {
                    case ServerConnectionStatus.Disconnected:
                        //_LOG_(LogLevel.OPCUA, $"Disconnected to [{_session.EndpointDescription.EndpointUrl}]");
                        UpdateAfterDisconnect();                                               
                        break;
                    case ServerConnectionStatus.Connected:
                        _LOG_(LogLevel.OPCUA, $"Connected to [{_session.EndpointDescription.EndpointUrl}]");

                        if (Connected == false)
                        {
                            Connected = true;

                            foreach (KeyValuePair<string, List<CBrowerInfo>> kv in OPCTagList)
                            {
                                string eqpType = kv.Key;
                                List<CBrowerInfo> tagList = kv.Value;

                                string startNodeID = GetStartNodeID(eqpType);

                                NodeId nodeToBrowse = NodeId.Parse(startNodeID); //new NodeId(Objects.ObjectsFolder, 0);
                                ScanOPCServer(nodeToBrowse, startNodeID);

                                Dictionary<int, List<BrowsePath>> dictBrowsePath = AddBrowsePath(startNodeID, eqpType, tagList);
                                Dictionary<int, List<BrowsePathResult>> dictResultPath = ReadBrowse(dictBrowsePath);

                                if (eqpType == enEqpType.CNV.ToString())
                                {
                                    AddConveyorNodeID(dictResultPath, dictBrowsePath);
                                }
                                else if (eqpType == enEqpType.STC.ToString())
                                {
                                    AddCraneNodeID(dictResultPath, dictBrowsePath, _ControlIdx);
                                }

                                dictBrowsePath = AddSubscibeBrowsePath(startNodeID, eqpType, tagList);
                                dictResultPath = ReadBrowse(dictBrowsePath);

                                SubscribeNodes(dictResultPath, dictBrowsePath, _ListSite, _ControlIdx);
                            }

                            OnSubscriptionEvent(ServerNo, _session.EndpointDescription.EndpointUrl);

                            _LOG_(LogLevel.OPCUA, $"Connected to [{_session.EndpointDescription.EndpointUrl}]");
                        }
                       


                        // Update ToolStripMenu
                        //connectToolStripMenuItem.Enabled = false;
                        //disconnectToolStripMenuItem.Enabled = true;
                        //// Set enabled state for combobox
                        //EndpointCB.Enabled = false;
                        //DiscoveryUrlCB.Enabled = false;
                        //DiscoveryTypeCB.Enabled = false;
                        //ClientUrlTB.Enabled = false;

                        //// Aggregate the UserControls.
                        //browseControl.Session = m_Session;

                        //attributeListControl.Session = m_Session;
                        //monitoredItemsControl.Session = m_Session;

                        //CommonClass.Session = m_Session;
                        //seqEqp.Session = m_Session;

                        //// Update status label.
                        //toolStripStatusLabel.Text = "Connected to " + m_Session.EndpointDescription.EndpointUrl;
                        ////toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.success;

                        //// Browse first level.
                        //browseControl.Browse(null);

                        ////SetTagValue(START_NODEID, VAL_ON);
                        //seqEqp.GetBrowsingNodeID();

                        //monitoredItemsControl.UpdateSubscriptions();
                        //seqEqp.SetTagValue(EQPSTATUS_MODE, "4", EnumLType.None);
                        //seqEqp.SetTagValue(EQPSTATUS_STATUS, VAL_IDLE, EnumLType.None);

                        break;
                    case ServerConnectionStatus.ConnectionWarningWatchdogTimeout:
                        _LOG_(LogLevel.OPCUA, $"Watchdog timed out to [{_session.EndpointDescription.EndpointUrl}]");
                        //    // Update status label.
                        //    toolStripStatusLabel.Text = "Watchdog timed out";
                        //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ConnectionErrorClientReconnect:
                        _LOG_(LogLevel.OPCUA, $"Trying to reconnect to [{_session.EndpointDescription.EndpointUrl}]");
                        //    // Update status label.
                        //    toolStripStatusLabel.Text = "Trying to reconnect";
                        //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ServerShutdownInProgress:
                        _LOG_(LogLevel.OPCUA, $"Server is shutting down to [{_session.EndpointDescription.EndpointUrl}]");
                        //    // Update status label.
                        //    toolStripStatusLabel.Text = "Server is shutting down";
                        //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ServerShutdown:
                        _LOG_(LogLevel.OPCUA, $"Server has shut down to [{_session.EndpointDescription.EndpointUrl}]");
                        //    // Update status label.
                        //    toolStripStatusLabel.Text = "Server has shut down";
                        //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.SessionAutomaticallyRecreated:
                        _LOG_(LogLevel.OPCUA, $"A new Session was created to [{_session.EndpointDescription.EndpointUrl}]");
                        //    // Update status label.
                        //    toolStripStatusLabel.Text = "A new Session was created";
                        //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.success;
                        //    // clear controls
                        //    bClearControls = true;
                        break;
                    case ServerConnectionStatus.Connecting:
                        //_LOG_(LogLevel.OPCUA, $"Trying to Connecting");
                        //    // Update status label.
                        //    EndpointDescription endpoint;
                        //    string endpointUrl;
                        //    if (TryGetSelectedEndpoint(out endpoint))
                        //    {
                        //        endpointUrl = endpoint.EndpointUrl;
                        //    }
                        //    else
                        //    {
                        //        endpointUrl = DiscoveryUrl;
                        //    }
                        //    toolStripStatusLabel.Text = "Trying to connect to " + endpointUrl;
                        break;
                }
            }
        }

        private void UpdateAfterDisconnect()
        {
            Connected = false;
        }

        #region LoadTagList
        /// <summary>
        /// TAGS_CLIENT_V1.xlsx에서 TagList를 가져온다.
        /// </summary>
        /// <param name="trackList"></param>
        /// <param name="group"></param>
        private void LoadTagList(List<CEqpTagItem> dataList, List<CDeviceInfo> deviceList)
        {
            //List<EqpTagItem> DataList = ReadConfig();
            if (_OPCTagList == null)
                _OPCTagList = new Dictionary<string, List<CBrowerInfo>>();
            //if (_SubscribeTagList == null)
            //    _SubscribeTagList = new List<string>();


            for (int i = 0; i < deviceList.Count; i++)
            {
                CDeviceInfo deviceInfo = deviceList[i];

                foreach (KeyValuePair<int, List<ItemInfo>> kv in deviceInfo.Item)
                {
                    _EqpType = kv.Value[0].ControlType.ToString();

                    if (_EqpID == null) _EqpID = kv.Value[0].EqpID;

                    if (_EqpType == "CNV")
                    {
                        ConveyorTag(kv.Value, dataList[0].Children[0]);
                    }
                    else if (_EqpType == "STC")
                    {
                        CraneTag(kv.Value, dataList[0].Children[1]);
                    }
                }

                //for (int j = 0; j < deviceInfo.Item.Count; j++)
                //{
                //    List<ItemInfo> item = deviceInfo.Item[1];

                //    _EqpType = item[0].ControlType.ToString();

                //    if (_EqpType == "CNV")
                //    {
                //        ConveyorTag(item, dataList[0].Children[0]);
                //    }
                //    else if (_EqpType == "STC")
                //    {
                //        CraneTag(item, dataList[0].Children[1]);
                //    }
                //}
            }
        }

        /// <summary>
        /// Conveyor TagList를 가져온다.
        /// </summary>
        /// <param name="trackList"></param>
        /// <param name="eqpList"></param>
        /// <param name="group"></param>
        private void ConveyorTag(List<ItemInfo> trackList, CEqpTagItem eqpList)
        {
            string trackno;

            //foreach (var item in eqpList.Children[group].Children)
            CBrowerInfo browerInfo;

            foreach (var item in eqpList.Children)
            {
                for (int i = 0; i < trackList.Count; i++)
                {
                    //if (trackList[i].SiteNo > 300) continue;
//#if DEBUG
                    trackno = string.Format($"CNV{trackList[i].SiteNo}");
                    //#else
                    //                    trackno = string.Format($"CNV00{{0:D2}}", trackList[i].SiteNo);
                    //#endif
                    // Water Tank에 있는 Conveyor는 StackerCrane에 종속되어 있어 TagList에서 제외시킴.
                    if (trackList[i].SiteNo < 1000) continue;

                    foreach (var itemLv1 in item.Children)
                    {
                        foreach (var itemLv2 in itemLv1.Children)
                        {
                            foreach (var itemLv3 in itemLv2.Children)
                            {
                                string ctrlType = trackList[i].ControlType.ToString();

                                if (itemLv3.Children.Count == 0)
                                {
                                    browerInfo = new CBrowerInfo
                                    {
                                        EqpID = trackList[i].EqpID,
                                        BrowerPath = string.Format($"{trackList[i].EqpID}.{trackno}.{itemLv2.TagName}.{itemLv3.TagName}"),
                                        //BrowerPath = string.Format($"{trackno}.{itemLv2.TagName}.{itemLv3.TagName}"),
                                        SubScribe = itemLv3.Subscribe
                                    };

                                    if (_OPCTagList.ContainsKey(ctrlType))
                                    {
                                        _OPCTagList[ctrlType].Add(browerInfo);
                                    }
                                    else
                                    {
                                        _OPCTagList[ctrlType] = new List<CBrowerInfo> { browerInfo };
                                    }
                                }
                                else
                                {
                                    foreach (var itemLv4 in itemLv3.Children)
                                    {
                                        browerInfo = new CBrowerInfo
                                        {
                                            EqpID = trackList[i].EqpID,
                                            BrowerPath = string.Format($"{trackList[i].EqpID}.{trackno}.{itemLv2.TagName}.{itemLv3.TagName}.{itemLv4.TagName}"),
                                            //BrowerPath = string.Format($"{trackno}.{itemLv2.TagName}.{itemLv3.TagName}.{itemLv4.TagName}")
                                            SubScribe = itemLv4.Subscribe
                                        };

                                        if (browerInfo.SubScribe == true)
                                        {
                                            ;
                                        }

                                        if (_OPCTagList.ContainsKey(ctrlType))
                                        {
                                            _OPCTagList[ctrlType].Add(browerInfo);
                                        }
                                        else
                                        {
                                            _OPCTagList[ctrlType] = new List<CBrowerInfo> { browerInfo };
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// StackCrane의 TagList를 가져온다.
        /// </summary>
        /// <param name="trackList"></param>
        /// <param name="eqpList"></param>
        /// <param name="group"></param>
        private void CraneTag(List<ItemInfo> craneList, CEqpTagItem eqpList)
        {
            //if (_OPCTagList == null) 
            //    _OPCTagList = new List<string>();            
            //if (_SubscribeTagList == null) 
            //    _SubscribeTagList = new List<string>();

            //foreach (var itemLv1 in eqpList.Children[group].Children)
            CBrowerInfo browerInfo;

            foreach (var itemLv1 in eqpList.Children)
            {
                for (int i = 0; i < craneList.Count; i++)
                {
                    foreach (var itemLv2 in itemLv1.Children)
                    {
                        foreach (var itemLv3 in itemLv2.Children)
                        {
                            string ctrlType = craneList[i].ControlType.ToString();

                            if (itemLv3.Children.Count == 0)
                            {
                                browerInfo = new CBrowerInfo();

                                browerInfo.BrowerPath = string.Format($"{craneList[i].EqpID}.{itemLv2.TagName}.{itemLv3.TagName}");
                                browerInfo.SubScribe = itemLv3.Subscribe;

                                if (_OPCTagList.ContainsKey(ctrlType))
                                {
                                    _OPCTagList[ctrlType].Add(browerInfo);
                                }
                                else
                                {
                                    _OPCTagList[ctrlType] = new List<CBrowerInfo> { browerInfo };
                                }                                
                            }
                            else
                            {
                                foreach (var itemLv4 in itemLv3.Children)
                                {
                                    browerInfo = new CBrowerInfo();

                                    browerInfo.BrowerPath = string.Format($"{craneList[i].EqpID}.{itemLv2.TagName}.{itemLv3.TagName}.{itemLv4.TagName}");
                                    browerInfo.SubScribe = itemLv4.Subscribe;

                                    if (_OPCTagList.ContainsKey(ctrlType))
                                    {
                                        _OPCTagList[ctrlType].Add(browerInfo);
                                    }
                                    else
                                    {
                                        _OPCTagList[ctrlType] = new List<CBrowerInfo> { browerInfo };
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
#endregion

        private void GetAllByNodeIDRecursive(List<CEqpTagItem> list, CEqpTagItem item)
        {
            list.Add(item);
            foreach (var child in item.Children)
            {
                GetAllByNodeIDRecursive(list, child);
            }
        }

        private void GetNodePathRecursive(List<CEqpTagItem> list)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var child in list)
            {
                sb.Append($"{child.TagName}.");

                if (child.Children.Count == 0)
                {
                    string path = sb.ToString();
                    sb.Clear();
                }
            }            
        }

        #region GetStartNodeID
        /// <summary>
        /// OPCServer에 시작 Tag NodeID를 가져온다.
        /// </summary>
        private string GetStartNodeID(string eqpType)
        {
            string startNodeID = string.Empty;
            byte[] continuationPoint;

            if (_FirstNodeID == "")
            {
                NodeId nodeToBrowse = new NodeId(Objects.ObjectsFolder, 0);

                BrowseContext browseContext = new BrowseContext()
                {
                    BrowseDirection = BrowseDirection.Forward,
                    ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
                    IncludeSubtypes = true,
                    NodeClassMask = 0,
                    ResultMask = (uint)BrowseResultMask.All,
                    MaxReferencesToReturn = 100
                };

                List<ReferenceDescription> results = _session.Browse(
                                    nodeToBrowse,
                                    browseContext,
                                    out continuationPoint);

                foreach (var item in results)
                {
                    if (eqpType == item.ToString())
                    {
                        startNodeID = item.NodeId.ToString();
                    }
                }
            }
            else
            {
                // parse the node id.
                NodeId startingNodeId = NodeId.Parse(_FirstNodeID);

                List<BrowsePath> browsePath = new List<BrowsePath>
                {
                    GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"/2:{eqpType}"))
                };

                List<BrowsePathResult> browerResult = ReadBrowse(browsePath);

                startNodeID = browerResult[0].Targets[0].TargetId.ToString();
            }

            _LOG_(LogLevel.OPCUA, $"[{EQP_ID}] Start NodeID : {startNodeID}");

            return startNodeID;
        }
#endregion

#region GetNodeID
        /// <summary>
        /// NodeID를 가지고 BrowerName을 가져온다.
        /// </summary>
        /// <param name="nodeid"></param>
        public void GetBrowerName(string nodeid)
        {
            /// [Browse 1]
            // set up the browse filters.
            BrowseContext context = new BrowseContext();

            // parse the node id.
            NodeId nodeId = NodeId.Parse(nodeid);

            byte[] continuationPoint = null;

            // browse the references (setting a 10 second timeout).
            List<ReferenceDescription> references = _session.Browse(
                nodeId,
                context,
                new RequestSettings() { OperationTimeout = 10000 },
                out continuationPoint);

            //foreach (var item in references)
            //{
            //    nodeId = NodeId.Parse(item.NodeId.ToString());
            //}


        }

        /// <summary>
        /// BrowerName에 해당되는 NodeID를 가져온다.
        /// </summary>
        /// <param name="brower"></param>
        /// <returns></returns>
        public NodeId GetNodeID(string brower)
        {
            BaseNode bNode = BrowsedNodeList.Find(x => x.Path == brower);
            return NodeId.Parse(bNode.NodeId);
        }
        
#endregion

#region [IDisposable Impl.]
        // Track whether Dispose has been called.
        private bool disposed = false;

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(disposing: true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    if (_session != null)
                    {
                        _session.Disconnect(SubscriptionCleanupPolicy.Delete, null);
                        _session.Dispose();
                        _session = null;
                    }
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                //CloseHandle(handle);
                //handle = IntPtr.Zero; // such as file handle, memory handle or other UN-MANAGED HANDLES!

                // Note disposing has been done.
                disposed = true;
            }
        }

        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# finalizer syntax for finalization code.
        // This finalizer will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide finalizer in types derived from this class.
        ~OPCUAClient()
        {

            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(disposing: false) is optimal in terms of
            // readability and maintainability.
            Dispose(disposing: false);
        }
#endregion

#region [Logger]

        private void _LOG_(LogLevel level, string msg)
        {
//#if DEBUG
//            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.ffff}, {msg}");
//#endif
            _Logger.Write(level, msg, LogFileName.OPCUA);
        }

        

        private void _EX_LOG_(Exception ex)
        {
            //_LOG_(ex.Message);
            //_LOG_(ex.StackTrace);
            _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
            _Logger.Write(LogLevel.Error, ex.StackTrace, LogFileName.ErrorLog);
        }

#endregion

#region GetEndPoint
        private EndpointDescription GetEndPoint(string connect_uri)
        {
            //CreateSession();

            //_session.UseDnsNameAndPortFromDiscoveryUrl = true;
            //_session.DefaultRequestSettings.OperationTimeout = 30000;

            // Attach to events
            //_session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);


            //m_Session.ReverseConnect(DiscoveryUrl, SecuritySelection.None);
            //Discovery discovery = new Discovery(m_Application);
            Discovery discovery = new Discovery();
            List<ApplicationDescription> servers = discovery.FindServers(connect_uri);
            GetEndpoints(connect_uri, discovery);

            foreach (ApplicationDescription server in servers)
            {
                foreach (string discoveryUrl in server.DiscoveryUrls)
                {
                    Uri uri = new Uri(discoveryUrl);
                    if (uri.Scheme == "opc.tcp")
                    {
                        GetEndpoints(discoveryUrl, discovery);

                        IList<EndpointDescription> endpoints = discovery.GetEndpoints(discoveryUrl);

                        foreach (EndpointDescription endpoint in endpoints)
                        {
                            if (endpoint.SecurityMode == UnifiedAutomation.UaBase.MessageSecurityMode.None)
                            {
                                return endpoint;
                            }
                        }
                    }
                }
            }

            return null;
        }

        private void GetEndpoints(string connect_uri, Discovery discovery)
        {
            try
            {
                //Cursor = Cursors.WaitCursor;

                IList<EndpointDescription> endpoints;
                if (!IsReverseConnectSelected)
                {
                    endpoints = discovery.GetEndpoints(connect_uri);
                }
                else
                {
                    endpoints = discovery.ReverseGetEndpoints(connect_uri);
                }
                //AddEndpointsToControl(endpoints);
            }
            catch (Exception ex)
            {
                //PrintException(e, $"GetEndpoints failed for {(connect_uri)}");
                _EX_LOG_(ex);
            }
            finally
            {
                //Cursor = Cursors.Default;
            }
        }
#endregion

#region ScanOPCServer
        public void ScanOPCServer(NodeId nodeToBrowse, string nodeID)
        {
            byte[] continuationPoint;
            List<ReferenceDescription> results;

            BrowsedNodeList.Clear();
            _BrowseNSIndex.Clear();

            BrowseContext browseContext = new BrowseContext()
            {
                BrowseDirection = BrowseDirection.Forward,
                ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
                IncludeSubtypes = true,
                NodeClassMask = 0,
                ResultMask = (uint)BrowseResultMask.All,
                MaxReferencesToReturn = 100
            };

            try
            {
                // Call browse service.
                results = _session.Browse(
                    nodeToBrowse,
                    browseContext,
                    out continuationPoint);


                foreach (var item in results)
                {
                    string nodeName = item.DisplayName.ToString();

                    if (!NodeListCheckPass(nodeName)) continue;

                    // Get the data about the parent tree node
                    //ReferenceDescription parentRefDescription = item;

                    // set nodeid
                    nodeToBrowse = ExpandedNodeId.ToNodeId(item.NodeId, Session.NamespaceUris);

                    BaseNode parent = new BaseNode();
                    parent.NodeId = item.NodeId.ToString();

                    // 각 Tag의 Browse별 NamespaceIndex를 가져온다.
                    if (_BrowseNSIndex.ContainsKey(item.BrowseName.Name) == false)
                    {
                        _BrowseNSIndex[item.BrowseName.Name] = item.BrowseName.NamespaceIndex;
                    }

                    BrowseNodesRecursive(parent);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### ScanOPCServer : PlanTime Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                throw;
            }
        }

        private void BrowseNodesRecursive(BaseNode parent, char path_sep = '.')
        {
            byte[] continuationPoint;
            List<ReferenceDescription> browseResults;
            NodeId nodeToBrowse;

            BrowseContext browseContext = new BrowseContext()
            {
                BrowseDirection = BrowseDirection.Forward,
                ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
                IncludeSubtypes = true,
                NodeClassMask = 0,
                ResultMask = (uint)BrowseResultMask.All,
                MaxReferencesToReturn = 100
            };

            nodeToBrowse = NodeId.Parse(parent.NodeId);

            browseResults = _session.Browse(
                    nodeToBrowse,
                    browseContext,
                    out continuationPoint);

            BaseNode baseNode = new BaseNode();

            foreach (var node in browseResults)
            {
                string path = $"{parent.Path}{path_sep}{node.DisplayName.Text}";
                //if (!WhiteAndBlackListCheckPass(path)) continue;

                BaseNode child = new BaseNode();
                child.Parent = parent;
                child.NodeId = node.NodeId.ToString();
                child.NodeClassString = node.NodeClass.ToString();
                child.TypeString = node.TypeDefinition.ToString();
                child.DisplayName = node.DisplayName.Text;
                child.Path = path;
                child.BrowseName = child.Path; // node.BrowseName.Name;
                BrowsedNodeList.Add(child);

                // 각 Tag의 Browse별 NamespaceIndex를 가져온다.
                if (_BrowseNSIndex.ContainsKey(node.BrowseName.Name) == false)
                {
                    _BrowseNSIndex[node.BrowseName.Name] = node.BrowseName.NamespaceIndex;
                }

                //_LOG_($"BrowsedAdded: {child.Path}");

                /* -- METHOD args 들을 browsing 하고 싶다면... 아래 코드 사용하세요
                 
                if(child.NodeClassString == "Method")
                {
                    //System.Console.WriteLine($"\nMethod: {child.BrowseName}");
                }
                else if (child.DisplayName == "InputArguments" || child.DisplayName == "OutputArguments")
                {
                    //System.Console.WriteLine($"\nMethod: {child.BrowseName}");
                    //GetArgumentsAsChildNodes(child, path_sep);
                }
                */

                baseNode = child;
            }

            if (_BrowseNSIndex.ContainsKey("Common"))
            {
                return;
            }

            BrowseNodesRecursive(baseNode, path_sep);
        }

        private bool NodeListCheckPass(string path)
        {
            if (path.StartsWith("Server")) return false;
            if (path.StartsWith("Aliases")) return false;

            return true;
        }
#endregion

    }
}
