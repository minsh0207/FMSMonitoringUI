using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace OPCUAClientClassLib
{
    public partial class OPCUAClient : IDisposable
    {

        private static int BROWSEPATH_MAXCOUNT = 999;
        #region [public props]
        public string FIRST_NODEID = "ns=2;i=1000";

        /// <summary>
        /// Tag의 Start NodeID
        /// </summary>
        string _StartNodeID;
        public string StartNodeID
        {
            get => _StartNodeID;
            set => _StartNodeID = value;
        }

        List<string> _OPCTagList;
        public List<string> OPCTagList
        {
            get => _OPCTagList;
            set => _OPCTagList = value;
        }

        List<string> _SubscribeTagList;
        public List<string> SubscribeTagList
        {
            get => _SubscribeTagList;
            set => _SubscribeTagList = value;
        }

        Dictionary<int, List<BrowsePath>> _PathsToTranslate;
        public Dictionary<int, List<BrowsePath>> PathsToTranslate
        {
            get => _PathsToTranslate;
            set => _PathsToTranslate = value;
        }

        //Dictionary<string, NodeId> _BrowseNodeID;
        //public Dictionary<string, NodeId> BrowseNodeID
        //{
        //    get => _BrowseNodeID;
        //    set => _BrowseNodeID = value;
        //}

        Dictionary<int, List<ReadValueId>> _ConveyorNodeID;
        public Dictionary<int, List<ReadValueId>> ConveyorNodeID
        {
            get => _ConveyorNodeID;
            set => _ConveyorNodeID = value;
        }

        Dictionary<int, OPCTagItem> _BrowseNodeID; 
        public Dictionary<int, OPCTagItem> BrowseNodeID
        {
            get => _BrowseNodeID;
            set => _BrowseNodeID = value;
        }

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
        /// Provides access to the OPC UA server and its services.
        /// </summary>
        //private ApplicationInstance m_Application = null;

        /// <summary>
        /// Provides access to OPC UA server.
        /// </summary>
        Session _session;
        public Session Session
        {
            get
            {
                return _session;
            }

            set
            {
                _session = value;
            }
        }

        /// <summary>
        /// Provides access to the subscription being created.
        /// </summary>
        private Subscription _Subscription = null;
        public Subscription Subscription
        {
            get { return _Subscription; }
        }

        /// <summary>
        /// Publishing enabled for the subscription
        /// </summary>
        private bool _PublishingEnabled = true;
        public bool PublishingEnabled
        {
            get { return _PublishingEnabled; }
            set { _PublishingEnabled = value; }
        }
        /// <summary>
        /// The publishing interval for the subscription
        /// </summary>
        private double _PublishingInterval = 500;        // Default 500
        public double PublishingInterval
        {
            get { return _PublishingInterval; }
            set { _PublishingInterval = value; }
        }

        //public ApplicationConfiguration App_config
        //{
        //    get
        //    {
        //        return _app_config;
        //    }

        //    set
        //    {
        //        _app_config = value;
        //    }
        //}

        string _connect_uri;
        public string Connect_uri
        {
            get
            {
                return _connect_uri;
            }

            set
            {
                _connect_uri = value;
            }
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
                    _LOG_($"OPCUAClient.Connected: {_Connected}");
                }
            }
        }

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

        public OPCUAClient(List<EqpTagItem> dataList, List<ItemInfo> trackList, int group)
        {
            LoadTagList(dataList, trackList, group);
        }

        /// <summary>
        /// Task를 통해 OPCUA 통신 연결 호출
        /// </summary>
        /// <param name="connect_uri"></param>
        /// <param name="user_id"></param>
        /// <param name="user_pw"></param>
        /// <returns></returns>
        public async Task<bool> ConnectAsync(string connect_uri, string user_id, string user_pw)
        {
            var task1 = Task.Run(() => Connect(connect_uri, user_id, user_pw));

            bool status = await task1;

            return status;
        }

        /// <summary>
        /// OPCUA 통신 연결
        /// </summary>
        /// <param name="connect_uri"></param>
        /// <param name="user_id"></param>
        /// <param name="user_pw"></param>
        /// <returns></returns>
        private bool Connect(string connect_uri, string user_id, string user_pw)
        {
            try
            {
                //
                DisconnectIfRequired();

                //
                _LOG_("Connecting...");

                // Get the endpoint by connecting to server's discovery endpoint.
                // Try to find the first endopint without security.
                bool urlType = true;
                if (urlType)
                {
                    EndpointDescription endpoint;
                    endpoint = GetEndPoint(connect_uri);
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
                _LOG_($"[{connect_uri}] Connected, SessionName = {_session.SessionName}");
            }
            catch (Exception ex)
            {
                // Log Error
                _EX_LOG_(ex);
                Connected = false;
            }

            return Connected;
        }

        private void Disconnect()
        {
            try
            {
                if (_session != null)
                {
                    _LOG_("Disconnecting...");

                    // Call the disconnect service of the server.
                    _session.Disconnect(SubscriptionCleanupPolicy.Delete, null);
                    _session.ConnectionStatusUpdate -= new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);
                    _session.Dispose();
                    _session = null;

                    Connected = false;

                    // Log Session Disconnected event
                    _LOG_("Session Disconnected.");
                }
                else
                {
                    _LOG_("Session not created!");
                }
            }
            catch (Exception ex)
            {
                _EX_LOG_(ex);
            }
        }

        private void DisconnectIfRequired()
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
                _session = new Session();
            }
            catch (Exception ex)
            {
                _EX_LOG_(ex);
            }

        }

        private void ConnectToSelectedEndpoint(EndpointDescription endpoint, string user_id, string user_pw)
        {
            CreateSession();

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
                switch (e.Status)
                {
                    case ServerConnectionStatus.Disconnected:
                        UpdateAfterDisconnect();
                        break;
                    case ServerConnectionStatus.Connected:
                        Connected = true;

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
                    //    // Update status label.
                    //    toolStripStatusLabel.Text = "Watchdog timed out";
                    //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ConnectionErrorClientReconnect:
                    //    // Update status label.
                    //    toolStripStatusLabel.Text = "Trying to reconnect";
                    //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ServerShutdownInProgress:
                    //    // Update status label.
                    //    toolStripStatusLabel.Text = "Server is shutting down";
                    //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ServerShutdown:
                    //    // Update status label.
                    //    toolStripStatusLabel.Text = "Server has shut down";
                    //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.SessionAutomaticallyRecreated:
                    //    // Update status label.
                    //    toolStripStatusLabel.Text = "A new Session was created";
                    //    //toolStripStatusLabel.Image = global::OPCUAClientClassLib.Properties.Resources.success;
                    //    // clear controls
                    //    bClearControls = true;
                        break;
                    case ServerConnectionStatus.Connecting:
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
        private void LoadTagList(List<EqpTagItem> dataList, List<ItemInfo> trackList, int group)
        {
            //List<EqpTagItem> DataList = ReadConfig();

            foreach (var eqpList in dataList)
            {
                _EqpID = eqpList.Children[group].TagName;

                if (_EqpID.Substring(3, 3) == "CNV")
                {
                    ConveyorTag(trackList, eqpList, group);
                }
                else if (_EqpID.Substring(3, 3) == "STC")
                {
                    CraneTag(trackList, eqpList, group);
                }
            }
        }

        /// <summary>
        /// Conveyor TagList를 가져온다.
        /// </summary>
        /// <param name="trackList"></param>
        /// <param name="eqpList"></param>
        /// <param name="group"></param>
        private void ConveyorTag(List<ItemInfo> trackList, EqpTagItem eqpList, int group)
        {
            string trackno;

            _OPCTagList = new List<string>();
            _SubscribeTagList = new List<string>();

            foreach (var item in eqpList.Children[group].Children)
            {
                for (int i = 0; i < trackList.Count; i++)
                {
                    if (trackList[i].SiteNo > 50) continue;

                    trackno = string.Format($"CNV00{{0:D2}}", trackList[i].SiteNo);

                    foreach (var itemLv1 in item.Children)
                    {
                        foreach (var itemLv2 in itemLv1.Children)
                        {
                            if (itemLv2.Children.Count == 0)
                            {
                                //_OPCTagList.Add(string.Format($"{eqp_id}.{trackno}.{itemLv1.TagName}.{itemLv2.TagName}"));
                                _OPCTagList.Add(string.Format($"{trackno}.{itemLv1.TagName}.{itemLv2.TagName}"));

                                if (itemLv2.Subscribe == true)
                                {
                                    _SubscribeTagList.Add(string.Format($"{trackno}.{itemLv1.TagName}.{itemLv2.TagName}"));
                                }
                            }
                            else
                            {
                                foreach (var itemLv3 in itemLv2.Children)
                                {
                                    //_OPCTagList.Add(string.Format($"{eqp_id}.{trackno}.{itemLv1.TagName}.{itemLv2.TagName}.{itemLv3.TagName}"));
                                    _OPCTagList.Add(string.Format($"{trackno}.{itemLv1.TagName}.{itemLv2.TagName}.{itemLv3.TagName}"));

                                    if (itemLv2.Subscribe == true)
                                    {
                                        _SubscribeTagList.Add(string.Format($"{trackno}.{itemLv1.TagName}.{itemLv2.TagName}.{itemLv3.TagName}"));
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
        private void CraneTag(List<ItemInfo> craneList, EqpTagItem eqpList, int group)
        {
            _OPCTagList = new List<string>();
            _SubscribeTagList = new List<string>();

            foreach (var itemLv1 in eqpList.Children[group].Children)
            {
                foreach (var itemLv2 in itemLv1.Children)
                {
                    if (itemLv2.Children.Count == 0)
                    {
                        //_OPCTagList.Add(string.Format($"{eqp_id}.{trackno}.{itemLv1.TagName}.{itemLv2.TagName}"));
                        _OPCTagList.Add(string.Format($"{itemLv1.TagName}.{itemLv2.TagName}"));

                        if (itemLv2.Subscribe == true)
                        {
                            _SubscribeTagList.Add(string.Format($"{itemLv1.TagName}.{itemLv2.TagName}"));
                        }
                    }
                    else
                    {
                        foreach (var itemLv3 in itemLv2.Children)
                        {
                            //_OPCTagList.Add(string.Format($"{eqp_id}.{trackno}.{itemLv1.TagName}.{itemLv2.TagName}.{itemLv3.TagName}"));
                            _OPCTagList.Add(string.Format($"{itemLv1.TagName}.{itemLv2.TagName}.{itemLv3.TagName}"));

                            if (itemLv3.Subscribe == true)
                            {
                                _SubscribeTagList.Add(string.Format($"{itemLv1.TagName}.{itemLv2.TagName}.{itemLv3.TagName}"));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void GetAllByNodeIDRecursive(List<EqpTagItem> list, EqpTagItem item)
        {
            list.Add(item);
            foreach (var child in item.Children)
            {
                GetAllByNodeIDRecursive(list, child);
            }
        }

        private void GetNodePathRecursive(List<EqpTagItem> list)
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
        /// OPCServer에 시작 TagNode를 가져온다.
        /// </summary>
        public void GetStartNodeID()
        {
            // parse the node id.
            NodeId startingNodeId = NodeId.Parse(FIRST_NODEID);

            List<BrowsePath> browsePath = new List<BrowsePath>();

            browsePath.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"/2:{_EqpID}")));

            List<BrowsePathResult> browerResult = ReadBrowse(browsePath);

            StartNodeID = browerResult[0].Targets[0].TargetId.ToString();
        }
        #endregion

        #region GetNodeID
        /// <summary>
        /// NodeID를 가지고 BrowerName을 가져온다.
        /// </summary>
        /// <param name="nodeid"></param>
        public void GetNodeID(string nodeid)
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

        private void _LOG_(string msg)
        {
#if DEBUG
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.ffff}, {msg}");
#endif
        }

        

        private void _EX_LOG_(Exception ex)
        {
            _LOG_(ex.Message);
            _LOG_(ex.StackTrace);
        }

        #endregion

        #region GetEndPoint
        private EndpointDescription GetEndPoint(string connect_uri)
        {
            CreateSession();

            _session.UseDnsNameAndPortFromDiscoveryUrl = true;
            _session.DefaultRequestSettings.OperationTimeout = 30000;

            // Attach to events
            _session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);


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
    }
}
