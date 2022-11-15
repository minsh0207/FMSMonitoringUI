using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AgingControls
{
    public partial class AgingLineControl: UserControl
    {
        public AgingLineControl()
        {
            InitializeComponent();

            // set size change listener
            this.SizeChanged += AgingLineControl_SizeChanged;

            // initially generate racks...
            GenerateRacks();
            CalcCoordinates();

            // prepare tooltip control
            PrepareTooltip();
        }

        #region [Set Highlight By Status]
        public void SetHighlightByStatus(char chrState, char chrFireState, char chrOperGroupId, char chrOperId, bool bPlanUnLoad)
        //public void SetHighlightByStatus(string chrState, string chrFireState, string chrOperGroupId, string chrOperId, string bPlanUnLoad)
        {
            char chrSetState = chrState;
            char chrSetFire = chrFireState;
            string chrSearchState = " ";

            switch (chrState)
            {
                case 'M':
                case 'R':
                case 'U':
                case 'T':
                case 'B':
                case 'X':
                case 'O':
                case '1':
                case '2':
                case 'I':
                case 'N':
                    break;

                default:
                    // HT Aging
                    if (chrOperGroupId == '3')
                    {
                        chrSetState = 'H';
                    }
                    // RT Aging
                    else if (chrOperGroupId == '1')
                    {
                        chrSetState = chrOperId;
                    }
                    break;
            }


            foreach (AgingRack rack in AgingRacks)
            {
                rack.fgBrush = RackStatusBrush.RackDefaultFilter_None;

                if (bPlanUnLoad == true)
                {
                    if (!rack.BPlanUnloadString.Equals(bPlanUnLoad.ToString()))
                        rack.bgBrush = RackStatusBrush.RackDefaultFilter_None;
                }
                else
                {
                    chrSearchState = rack.StatusString;
                    if (chrState == '1' || chrState == '2') { }
                    else
                    {
                        if (rack.OperGroupIdString == "3") chrSearchState = "H";
                        else if (rack.OperGroupIdString == "1" && chrSearchState != "O") chrSearchState = rack.OperIdString;
                    }
                    if (chrSetFire == ' ')
                    {
                        if (!chrSearchState.Equals(chrSetState.ToString()))
                            if (rack.DisplayString.Length < 1)
                                //rack.fgBrush = RackStatusBrush.RackStatusBrush_Empty;
                                rack.fgBrush = RackStatusBrush.RackStatusBrush_Empty_fg;
                            else
                                rack.bgBrush = RackStatusBrush.RackDefaultFilter_None;

                        else if (chrOperGroupId == '1' && chrOperId == '5')
                            rack.fgBrush = RackStatusBrush.RackSelectedFilter_Value;

                        if (rack.BPlanUnloadString.Equals("true"))
                            rack.fgBrush = RackStatusBrush.RackDefaultFilter_None;
                    }
                    else
                    {
                        if (!rack.FireStatusString.Equals(chrFireState.ToString()))
                            rack.bgBrush = RackStatusBrush.RackDefaultFilter_None;
                    }

                }

                //rack.RackID
                System.Diagnostics.Debug.Print(string.Format("### Rack property : {0} / {1}", rack.RackID, rack.StatusString));
            }

            if (DoubleReach)    
            {
                foreach (AgingRack rack in AgingRacksDoubleReach)
                {
                    rack.fgBrush = RackStatusBrush.RackDefaultFilter_None;

                    if (bPlanUnLoad == true)
                    {
                        if (!rack.BPlanUnloadString.Equals(bPlanUnLoad.ToString()))
                            rack.bgBrush = RackStatusBrush.RackDefaultFilter_None;
                    }
                    else
                    {
                        chrSearchState = rack.StatusString;
                        if (chrState == '1' || chrState == '2') { }
                        else
                        {
                            if (rack.OperGroupIdString == "3") chrSearchState = "H";
                            else if (rack.OperGroupIdString == "1" && chrSearchState != "O") chrSearchState = rack.OperIdString;
                        }
                        if (chrSetFire == ' ')
                        {
                            if (!chrSearchState.Equals(chrSetState.ToString()))
                                //if(rack.DisplayString.Length < 1)
                                //    rack.fgBrush = RackStatusBrush.RackStatusBrush_Empty;
                                //else
                                    rack.bgBrush = RackStatusBrush.RackDefaultFilter_None;
                            else if (chrOperGroupId == '1' && chrOperId == '5')
                                rack.fgBrush = RackStatusBrush.RackSelectedFilter_Value;

                            if (rack.BPlanUnloadString.Equals("true"))
                                rack.fgBrush = RackStatusBrush.RackDefaultFilter_None;
                        }
                        else
                        {
                            if (!rack.FireStatusString.Equals(chrFireState.ToString()))
                                rack.bgBrush = RackStatusBrush.RackDefaultFilter_None;
                        }

                    }

                    //rack.RackID
                    System.Diagnostics.Debug.Print(string.Format("### Rack property : {0} / {1}", rack.RackID, rack.StatusString));
                }
            }

            Invalidate();
        }
        #endregion

        #region [Set AgingRack Data to Control]
        //
        // Database 의 tMstAgingRack 을 읽은 다음
        // DataTable에 넣고, 이 함수를 호출하면 됨
        // DataTable에서 RackID를 보고 해당 라인의 Data를 가져오므로
        // 라인별로 나눠서 줄 필요 없고 그냥 dt 를 통채로 넘겨 주면 됩니다.
        // 단, DataTable Object를 넘겨 줄 때, ref 를 붙여서 넘겨주면 메모리가 절약됩니다.
        //
        public void SetDataTable(ref DataTable dt)
        {
            // dt 의 컬럼 중에서 "RackID"로 라인을 구분한다.
            // RackID 라는 이름이 다르거나 없으면, 에러남... (주의하세요)
            // 컬럼의 순서를 아래와 같이 꼭 지켜야 함
            // 0 : RackID
            // 1 : Status
            // 2 : FireStatus
            // 3~8 : TrayID-1 ~ TrayID-6
            // 9 : OperGroupID
            // 10 : OperID
            // 11 : PlanTime


            {
                //string where = string.Format("RackID LIKE '{0}%'", this.LinePrefix);
                //string orderby = "RackID ASC";
                bool isRTAging = false;
                //if (LinePrefix.Substring(0, 1) == "R")
                //    isRTAging = true;

                string where = string.Format("unit_id LIKE '{0}%'", this.LinePrefix);
                string orderby = "unit_id ASC";


                foreach (DataRow row in dt.Select(where, orderby))
                {
                    string[] trayids = new string[2];
                    // TrayID 하나만 존재한다. 20190125 KJY
                    trayids[0] = row["TrayID"].ToString();

                    //trayids[0] = row["TrayID_1"].ToString();
                    /*
                    trayids[1] = row["TrayID_2"].ToString();
                    trayids[2] = row["TrayID_3"].ToString();
                    trayids[3] = row["TrayID_4"].ToString();
                    trayids[4] = row["TrayID_5"].ToString();
                    trayids[5] = row["TrayID_6"].ToString();
                    */
                    trayids[1] = "";
                    //trayids[2] = "";
                    //trayids[3] = "";
                    //trayids[4] = "";
                    //trayids[5] = "";


                    AgingRack rack = this.AgingRacks.Find(x => x.RackID == row["RackID"].ToString());
                    //int a = 0;
                    //if (row["CellType"].ToString().Length > 0 && row["Status"].ToString() == "G")
                    //    a = 1;
                    // 20210430 KJY - 공Tray의 CellType 표기를 위해 parameter 추가
                    if (null != rack)
                    {
                        if (isRTAging == false)
                        {
                            rack.SetData(
                                row["Status"].ToString(),       // status (CHAR)
                                row["FireStatus"].ToString(),   // firestatus (CHAR)
                                row["TrayID"].ToString(),       // tTrayCurr trayid
                                row["OperGroupID"].ToString(),  // opergroupid (CHAR)
                                row["OperID"].ToString(),       // operid (CHAR)
                                trayids,                        // trayids
                                row["bPlanUnLoad"].ToString(),  // bPlanUnload
                                row["PlanTime"].ToString()      // PlanTime

                                // 20210430 KJY paramter 추가 - CellType
                                , row["CellType"].ToString()

                                );
                        } else
                        {
                            // 20211119 KJY - 상온이면 DummyFlag 활용해서 MES MArked Tray 구별여부에 사용한다.
                            rack.SetData(
                                row["Status"].ToString(),       // status (CHAR)
                                row["FireStatus"].ToString(),   // firestatus (CHAR)
                                row["TrayID"].ToString(),       // tTrayCurr trayid
                                row["OperGroupID"].ToString(),  // opergroupid (CHAR)
                                row["OperID"].ToString(),       // operid (CHAR)
                                trayids,                        // trayids
                                row["bPlanUnLoad"].ToString(),  // bPlanUnload
                                row["PlanTime"].ToString()      // PlanTime

                                // 20210430 KJY paramter 추가 - CellType
                                , row["CellType"].ToString()
                                //20211119 KJY - DummyFlag for MES API 추가
                                , row["DummyFlag"].ToString()
                                );
                        }
                    }
                }
            }

            if (DoubleReach)
            {
                string where = string.Format("RackID LIKE '{0}%'", this.DoubleReachLinePrefix);
                string orderby = "RackID ASC";
                foreach (DataRow row in dt.Select(where, orderby))
                {
                    string[] trayids = new string[2];
                    trayids[0] = row["TrayID_1"].ToString();
                    trayids[1] = row["TrayID_2"].ToString();
                    //trayids[2] = row["TrayID_3"].ToString();
                    //trayids[3] = row["TrayID_4"].ToString();
                    //trayids[4] = row["TrayID_5"].ToString();
                    //trayids[5] = row["TrayID_6"].ToString();

                    AgingRack rack = this.AgingRacksDoubleReach.Find(x => x.RackID == row["RackID"].ToString());
                    if (null != rack)
                    {
                        rack.SetData(
                            row["Status"].ToString(),       // status (CHAR)
                            row["FireStatus"].ToString(),   // firestatus (CHAR)
                            row["TrayID"].ToString(),       // tTrayCurr trayid
                            row["OperGroupID"].ToString(),  // opergroupid (CHAR)
                            row["OperID"].ToString(),       // operid (CHAR)
                            trayids,                        // trayids
                            row["bPlanUnLoad"].ToString(),  // bPlanUnload
                            row["PlanTime"].ToString()      // PlanTime
                            );
                    }
                }
            }

            Invalidate();
        }

        public void SetDataTable(DataSet ds)
        {
            // dt 의 컬럼 중에서 "RackID"로 라인을 구분한다.
            // RackID 라는 이름이 다르거나 없으면, 에러남... (주의하세요)
            // 컬럼의 순서를 아래와 같이 꼭 지켜야 함
            // 0 : RackID
            // 1 : Status
            // 2 : FireStatus
            // 3~8 : TrayID-1 ~ TrayID-6
            // 9 : OperGroupID
            // 10 : OperID
            // 11 : PlanTime
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string[] trayids = new string[2];
                    trayids[0] = row["tray_id"].ToString();
                    trayids[1] = row["tray_id_2"].ToString();

                    string rackid = row["rack_id"].ToString();

                    string bPlanUnload = "true";

                    if (row["use_flag"].ToString() == "N")
                    {
                        bPlanUnload = "false";
                    }

                    AgingRack rack = this.AgingRacks.Find(x => x.RackID == rackid);

                    if (null != rack)
                    {
                        rack.SetData(
                            row["status"].ToString(),       // status (CHAR)
                            row["fire_status"].ToString(),   // firestatus (CHAR)
                            row["tray_id"].ToString(),       // tTrayCurr trayid
                            "A",        // opergroupid (CHAR)
                            "B",        // operid (CHAR)
                            trayids,                          // trayids
                            bPlanUnload,  // bPlanUnload
                            row["start_time"].ToString()      // PlanTime
                            );
                    }
                }
            }

            Invalidate();
        }

        #endregion

        /*
        #region [IsPlanUnLoad]
        //bPlanUnLoad
        private bool IsPlanUnLoad(String planTime)
        {
            String m_string;
            DateTime dtPlanTime;
            DateTime dtDataBaseTime;
            bool bPlanUnLoad = false;

            // Get DataBaseTime
            dtDataBaseTime = Convert.ToDateTime(CDataBase.DBGetDateTime(0));

            //Set bool PlanTime
            dtPlanTime = DateTime.Parse(m_string.StringToDateTime(strData[8]));
            if (dtPlanTime < dtDataBaseTime && strData[1] != "O")
                bPlanUnLoad = true;
            else
                bPlanUnLoad = false;

            return bPlanUnLoad;
        }
        #endregion
        */

        #region [Hide Unused Racks]
        public void HideRacks(string[] rackids)
        {
            foreach (string rackid in rackids)
                HideRack(rackid);
        }

        public void HideRack(string rackid)
        {
            if (null == rackid || rackid == string.Empty || rackid.Length <= 0) return;
            
            AgingRack rack;
            rack = this.AgingRacks.Find(x => x.RackID == rackid);
            if (null == rack && DoubleReach) rack = this.AgingRacksDoubleReach.Find(x => x.RackID == rackid);

            if (null == rack) return;

            rack.Hide = true;
        }
        #endregion

        #region [ToolTip]
        ToolTip _toolTip = new ToolTip();
        private void PrepareTooltip()
        {
            _toolTip.InitialDelay = 100;
            _toolTip.ReshowDelay = 100;
            this.MouseHover += AgingLineControl_MouseHover;
            this.MouseMove += AgingLineControl_MouseMove;
        }

        void AgingLineControl_MouseMove(object sender, MouseEventArgs e)
        {
            ResetMouseEventArgs();
        }


        //
        // Tooltip 을 숨기고, 보이고 하는 것이 아래처럼 하는 것이 가장 무난해서 이렇게 했는데...
        // 더 좋은 방법 찾으면 고쳐보세요...
        //
        private void AgingLineControl_MouseHover(object sender, EventArgs e)
        {
            string tt = GetToolTipText();
            if (tt.Length > 0)
            {
                _toolTip.SetToolTip(this, tt);
                _toolTip.Show(tt, this);
            }
            else
            {
                _toolTip.Hide(this);
                _toolTip.SetToolTip(this, " ");
            }
        }

        private string GetToolTipText()
        {
            AgingRack rack = FindRackOfCurrentMousePosition();
            if (null != rack && !rack.Hide)
                return string.Format("{0}\n{1}", rack.RackID, rack.TrayId.Length>0?rack.TrayId:"(Empty)");
            else
                return string.Empty;
        }

        public AgingRack FindRackOfCurrentMousePosition()
        {
            Point pt = PointToClient(Cursor.Position);

            if (DoubleReach)
                foreach (AgingRack rack in AgingRacksDoubleReach)
                    if (rack.Rect.Contains(pt)) return rack;

            foreach (AgingRack rack in AgingRacks)
                if (rack.Rect.Contains(pt)) return rack;

            return null;
        }
        #endregion

        #region [Border Pens]
        // Entire Line
        Pen _penControlBorder = new Pen(Color.Black, 1.0f);

        // Bay Border
        Pen _penBayBorder = new Pen(Color.Black, 1.0f);

        // Rack Border
        Pen _penRackBorder = new Pen(Color.Black, 1.0f);

        // Label Border
        Pen _penLabelBorder = new Pen(Color.Black, 1.0f);
        #endregion

        #region [Layout Properties]
        int _BoxMargin = 2;
        [DisplayName("Margin"), Description("Margin Among Boxes in Pixels"), Category("Aging Line Layout")]
        public int BoxMargin
        {
            get { return _BoxMargin; }
            set
            {
                if (value != _BoxMargin)
                {
                    _BoxMargin = value;
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        int _BayCount = 20;
        [DisplayName("Bay Count"), Description("How Many Bays in This Line"), Category("Aging Line Layout")]
        public int BayCount
        {
            get { return _BayCount; }
            set
            {
                if (value != _BayCount)
                {
                    _BayCount = value;
                    GenerateRacks();
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        BayDirection _BayDir = BayDirection.RightToLeft;
        public enum BayDirection { LeftToRight = 1, RightToLeft = 2 };
        [DisplayName("Bay Direction"), Description("Bay Number Increases from Left or Right"), Category("Aging Line Layout")]
        public BayDirection BayDir
        {
            get { return _BayDir; }
            set
            {
                if (value != _BayDir)
                {
                    _BayDir = value;
                    GenerateRacks();
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        int _RackCount = 7;
        [DisplayName("Rack Count"), Description("How Many Racks in a Bay"), Category("Aging Line Layout")]
        public int RackCount
        {
            get { return _RackCount; }
            set
            {
                if (value != _RackCount)
                {
                    _RackCount = value;
                    GenerateRacks();
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        RackDirection _RackDir = RackDirection.BottomUp;
        public enum RackDirection { TopDown = 1, BottomUp = 2 };
        [DisplayName("Rack No Direction"), Description("Rack No Increases from the Top or Bottom"), Category("Aging Line Layout")]
        public RackDirection RackDir
        {
            get { return _RackDir; }
            set
            {
                if (value != _RackDir)
                {
                    _RackDir = value;
                    GenerateRacks();
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        bool _DoubleReach = false;
        [DisplayName("Double Reach"), Description("If Racks Have Double Reach"), Category("Aging Line Layout")]
        public bool DoubleReach
        {
            get { return _DoubleReach; }
            set
            {
                if (value != _DoubleReach)
                {
                    _DoubleReach = value;
                    GenerateRacks();
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        DoubleReachDisplayDirection _DoubleReachRackDirection = DoubleReachDisplayDirection.Horizontal;
        public enum DoubleReachDisplayDirection { Horizontal = 1, Vertical = 2 };
        [DisplayName("Double Reach Rack Direction"), Description("Racks Aligns Horizontally or Vertically"), Category("Aging Line Layout")]
        public DoubleReachDisplayDirection DoubleReachRackDirection
        {
            get { return _DoubleReachRackDirection; }
            set
            {
                if (value != _DoubleReachRackDirection)
                {
                    _DoubleReachRackDirection = value;
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        #endregion

        #region [특정 간격으로 bay 색을 다르게 지정하는 것과 관련된 Properties]
        bool _ShowBayNumber = true;
        [DisplayName("Show Bay Number"), Description("If True, Shows Bay Number Label"), Category("Bay Marker")]
        public bool ShowBayNumber
        {
            get { return _ShowBayNumber; }
            set
            {
                if (value != _ShowBayNumber)
                {
                    _ShowBayNumber = value;
                    GenerateRacks();
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        BayNumberLabelPosition _BayNoLabelPos = BayNumberLabelPosition.Top;
        public enum BayNumberLabelPosition { Top = 1, Bottom = 2 }
        [DisplayName("Bay Number Label Position"), Description("Where to Show Label of Bay Number"), Category("Bay Marker")]
        public BayNumberLabelPosition BayNoLabelPos
        {
            get { return _BayNoLabelPos; }
            set
            {
                if (value != _BayNoLabelPos)
                {
                    _BayNoLabelPos = value;
                    CalcCoordinates();
                    Invalidate();
                }
            }
        }

        int _BayNoLabelDisplayStep = 5;
        [DisplayName("Label Display Gap"), Description("Set 1 to Show Every Bay, 5 for Every 5th Bay"), Category("Bay Marker")]
        public int BayNoLabelDisplayStep
        {
            get { return _BayNoLabelDisplayStep; }
            set
            {
                if (value != _BayNoLabelDisplayStep)
                {
                    _BayNoLabelDisplayStep = value;
                    Invalidate();
                }
            }
        }
        #endregion

        #region [DataTable Properties]
        string _LinePrefix = "";
        [DisplayName("Line ID Prefix"), Description("To Select Racks Whose ID Starts with This"), Category("DataTable")]
        public string LinePrefix
        {
            get { return _LinePrefix; }
            set
            {
                if (value != _LinePrefix)
                {
                    _LinePrefix = value;
                    GenerateRacks();
                    Invalidate();
                }
            }
        }

        string _DoubleReachLinePrefix = "";
        [DisplayName("Double Reach Line ID Prefix"), Description("To Select Racks Whose ID Starts with This"), Category("DataTable")]
        public string DoubleReachLinePrefix
        {
            get { return _DoubleReachLinePrefix; }
            set
            {
                if (value != _DoubleReachLinePrefix)
                {
                    _DoubleReachLinePrefix = value;
                    GenerateRacks();
                    Invalidate();
                }
            }
        }
        #endregion

        #region [Generate Racks]
        // BayCount, RackCount 를 가지고 AgingRack Object 들을 만들고 List 에 담는다.
        // BayCount, RackCount 가 변경되면 자동으로 호출됨
        // Bay 번호가 왼쪽->오른쪽 또는 오른쪽->왼쪽으로 증가하는지에 따라 만들어진다.
        // Rack 번호도 위->아래 또는 아래->위 로 증가하는지에 따라 만들어진다.
        //
        private List<AgingRack> AgingRacks = new List<AgingRack>();
        private List<AgingRack> AgingRacksDoubleReach = new List<AgingRack>();
        private void AddRack(List<AgingRack> racks, string prefix, int bay, int rack)
        {
            AgingRack r = new AgingRack();
            r.RackID = string.Format("{0}{1:00}{2:00}", prefix, bay, rack);
            racks.Add(r);
        }
        public void GenerateRacks()
        {
            // check bay count and rack count
            if (BayCount <= 0 || RackCount <= 0) return;

            // check line-prefix
            if (LinePrefix.Length <= 0) return;

            // check double-reach-line-prefix when doublereach is true
            if (DoubleReach && DoubleReachLinePrefix.Length <= 0) return;

            // generate racks
            AgingRacks.Clear();
            AgingRacksDoubleReach.Clear();

            //
            if (BayDir == BayDirection.LeftToRight)
            {
                for (int bay = 1; bay <= BayCount; bay++)
                {
                    if (RackDir == RackDirection.TopDown)
                    {
                        for (int rack = 1; rack <= RackCount; rack++)
                        {
                            AddRack(AgingRacks, LinePrefix, bay, rack);
                            if (DoubleReach) AddRack(AgingRacksDoubleReach, DoubleReachLinePrefix, bay, rack);
                        }
                    }
                    else
                    {
                        for (int rack = RackCount; rack >= 1; rack--)
                        {
                            AddRack(AgingRacks, LinePrefix, bay, rack);
                            if (DoubleReach) AddRack(AgingRacksDoubleReach, DoubleReachLinePrefix, bay, rack);
                        }
                    }
                }
            }
            else
            {
                for (int bay = BayCount; bay >= 1; bay--)
                {
                    if (RackDir == RackDirection.TopDown)
                    {
                        for (int rack = 1; rack <= RackCount; rack++)
                        {
                            AddRack(AgingRacks, LinePrefix, bay, rack);
                            if (DoubleReach) AddRack(AgingRacksDoubleReach, DoubleReachLinePrefix, bay, rack);
                        }
                    }
                    else
                    {
                        for (int rack = RackCount; rack >= 1; rack--)
                        {
                            AddRack(AgingRacks, LinePrefix, bay, rack);
                            if (DoubleReach) AddRack(AgingRacksDoubleReach, DoubleReachLinePrefix, bay, rack);
                        }
                    }
                }
            }
        }
        #endregion

        #region [Control Sizing Handlers]
        protected override Size DefaultSize
        {
            get
            {
                return new Size(720, 120);
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
        }

        private void AgingLineControl_SizeChanged(object sender, EventArgs e)
        {
            CalcCoordinates();
        }

        private Rectangle _rcBorder;
        private List<Rectangle> _rcBays = new List<Rectangle>();
        private List<Rectangle> _rcBayNoLabels = new List<Rectangle>();
        private void CalcCoordinates()
        {
            if (AgingRacks.Count <= 0) return;

            _rcBorder = DisplayRectangle;
            _rcBorder.Inflate(-BoxMargin, -BoxMargin);

            // Bay No Label...
            int label_rack = ShowBayNumber ? 1 : 0;
            int v_offset_for_label_rack = (ShowBayNumber && BayNoLabelPos == BayNumberLabelPosition.Top) ? 1 : 0;

            int gap_pixels_v = (RackCount + 1 + label_rack) * BoxMargin; // rack이 6개라면, 사이 사이의 갭은 5개 + 위 + 아래 = 총 7개
            int rack_height = (_rcBorder.Height - gap_pixels_v) / (RackCount + label_rack); //한개의 rack 높이 계산

            int gap_pixels_h = BayCount * BoxMargin * 2; // Bay의 왼쪽과 오른쪽에 모두 Margin 하나씩
            int rack_width = (_rcBorder.Width - gap_pixels_h) / BayCount;       //rack의 가로사이즈 지정

            // fitting to center
            int fit_center_offset_h = (_rcBorder.Width - (rack_width + BoxMargin * 2) * (BayCount)) / 2;
            int fit_center_offset_v = (_rcBorder.Height - (rack_height + BoxMargin) * (RackCount + v_offset_for_label_rack) - BoxMargin) / 2;
            Rectangle rcLineBorder = _rcBorder;
            rcLineBorder.Inflate(-fit_center_offset_h, -fit_center_offset_v);

            for (int bay = 0; bay < BayCount; bay++)
            {
                // set aging racks' positions
                for (int rack = v_offset_for_label_rack; rack < RackCount + v_offset_for_label_rack; rack++)
                {
                    int i = bay * RackCount + rack - v_offset_for_label_rack;
                    AgingRacks[i].Rect.X = rcLineBorder.X + bay * (rack_width + 2 * BoxMargin) + BoxMargin;
                    AgingRacks[i].Rect.Y = rcLineBorder.Y + rack * (rack_height + BoxMargin) + BoxMargin;
                    AgingRacks[i].Rect.Width = rack_width;
                    AgingRacks[i].Rect.Height = rack_height;

                    if (DoubleReach)
                    {
                        if (this.DoubleReachRackDirection == DoubleReachDisplayDirection.Horizontal)
                        {
                            // 2nd rack (double reach rack) is right side of the 1st rack
                            AgingRacksDoubleReach[i].Rect = AgingRacks[i].Rect;
                            AgingRacksDoubleReach[i].Rect.Width /= 2;
                            AgingRacksDoubleReach[i].Rect.X += AgingRacksDoubleReach[i].Rect.Width;

                            // altering the size of 1st rack
                            AgingRacks[i].Rect.Width = AgingRacks[i].Rect.Width / 2;
                        }
                        else
                        {
                            // 2nd rack (double reach rack) is bottom side of the 1st rack
                            AgingRacksDoubleReach[i].Rect = AgingRacks[i].Rect;
                            AgingRacksDoubleReach[i].Rect.Height /= 2;
                            AgingRacksDoubleReach[i].Rect.Y += AgingRacksDoubleReach[i].Rect.Height;

                            // altering the size of 1st rack
                            AgingRacks[i].Rect.Height = AgingRacks[i].Rect.Height / 2;
                        }
                    }
                }
            }

            // calc bay number label rack position
            _rcBays.Clear();
            _rcBayNoLabels.Clear();
            if (BayDir == BayDirection.LeftToRight)
            {
                for (int bay = 0; bay < BayCount; bay++)
                {
                    // set bays' positions
                    _rcBays.Add(new Rectangle(
                        rcLineBorder.X + bay * (rack_width + 2 * BoxMargin),
                        rcLineBorder.Y + BoxMargin,
                        rack_width + 2 * BoxMargin,
                        (RackCount + v_offset_for_label_rack) * (rack_height + BoxMargin)
                        ));

                    // set bay no labels' positions
                    _rcBayNoLabels.Add(
                        new Rectangle(rcLineBorder.X + bay * (rack_width + 2 * BoxMargin) + BoxMargin,
                            BayNoLabelPos == BayNumberLabelPosition.Top ?
                                rcLineBorder.Y + BoxMargin :
                                rcLineBorder.Y + RackCount * (rack_height + BoxMargin) + BoxMargin,
                            rack_width, rack_height)
                        );
                }
            }
            else
            {
                for (int bay = BayCount - 1; bay >= 0; bay--)
                {

                    // set bays' positions
                    _rcBays.Add(new Rectangle(
                        rcLineBorder.X + bay * (rack_width + 2 * BoxMargin),
                        rcLineBorder.Y + BoxMargin,
                        rack_width + 2 * BoxMargin,
                        (RackCount + v_offset_for_label_rack) * (rack_height + BoxMargin)
                        ));

                    // set bay no labels' positions
                    _rcBayNoLabels.Add(
                        new Rectangle(rcLineBorder.X + bay * (rack_width + 2 * BoxMargin) + BoxMargin,
                            BayNoLabelPos == BayNumberLabelPosition.Top ?
                                rcLineBorder.Y + BoxMargin :
                                rcLineBorder.Y + RackCount * (rack_height + BoxMargin) + BoxMargin,
                            rack_width, rack_height)
                        );
                }
            }
        }

        #endregion

        #region [Draw Object]
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            DrawObject(gfx);
        }

        private void DrawObject(Graphics gfx)
        {
            gfx.DrawRectangle(_penControlBorder, _rcBorder);



            // draw bay
            foreach(Rectangle bay in _rcBays)
            {
                DrawBay(gfx, bay, RackStatusBrush.BayBrush_bg, _penBayBorder);
            }



            // draw bay no label
            if (ShowBayNumber)
            {
                for (int i = 1; i <= _rcBayNoLabels.Count; i++)
                {
                    if (i % BayNoLabelDisplayStep == 0)
                    {
                        DrawBay(gfx, _rcBays[i - 1], RackStatusBrush.MarkerBayBrush_bg, _penBayBorder);
                        DrawBayNo(gfx, _rcBayNoLabels[i - 1], RackStatusBrush.BayNoLabelBrush_bg, _penLabelBorder, i.ToString());
                    }
                }
            }
            else
            {
                // draw bay back ground color default
                for (int i = 1; i <= _rcBayNoLabels.Count; i++)
                {
                    if (i % BayNoLabelDisplayStep == 0)
                    {
                        DrawBay(gfx, _rcBays[i - 1], RackStatusBrush.MarkerBayBrush_bg, _penBayBorder);
                        //DrawBayNo(gfx, _rcBayNoLabels[i - 1], RackStatusBrush.BayNoLabelBrush_bg, _penLabelBorder, i.ToString());
                    }
                }
            }


            // draw racks
            foreach (AgingRack r in AgingRacks)
            {
                DrawRack(gfx, r, _penRackBorder);
            }

            // draw double reach racks
            if (DoubleReach)
            {
                foreach (AgingRack r in AgingRacksDoubleReach)
                {
                    DrawRack(gfx, r, _penRackBorder);
                }
            }
        }

        private void DrawBay(Graphics gfx, Rectangle rcBay, Brush bgBrush, Pen penBorder)
        {
            gfx.FillRectangle(bgBrush, rcBay);
            gfx.DrawRectangle(penBorder, rcBay);
        }

        private void DrawBayNo(Graphics gfx, Rectangle rcBayNoLabel, Brush bgBrush, Pen penBorder, string bayNo)
        {
            gfx.FillRectangle(bgBrush, rcBayNoLabel);
            gfx.DrawRectangle(penBorder, rcBayNoLabel);
            TextDisplay(gfx, rcBayNoLabel, bayNo, RackStatusBrush.BayNoLabelBrush_fg);
        }

        private void DrawRack(Graphics gfx, AgingRack rack, Pen penBorder)
        {
            if (rack.Hide) return;

            gfx.FillRectangle(rack.bgBrush, rack.Rect);
            gfx.DrawRectangle(penBorder, rack.Rect);
            //TextDisplay(gfx, rack.Rect, rack.DisplayString, Brushes.Black);
            TextDisplay(gfx, rack.Rect, rack.DisplayString, rack.fgBrush);
            //TextDisplay(gfx, rack.Rect, "E", rack.fgBrush);
        }

        private void TextDisplay(Graphics gfx, Rectangle border, string str, Brush brFontBrush)
        {
            using (Font font1 = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                Font goodFont = FindFont(gfx, str, border.Size, font1);
                
                //gfx.DrawString(str, goodFont, brFontBrush, border, sf);
                if (null != goodFont) gfx.DrawString(str, goodFont, brFontBrush, border, sf);
            }
        }

        private Font FindFont(Graphics gfx, string testString, Size Room, Font PreferedFont)
        {
            // 문자열을 그릴 때 필요한 공간을 계산한다
            SizeF RealSize = gfx.MeasureString(testString, PreferedFont);

            // 주어진 Room의 크기가 string을 그릴 크기보다 작으면
            // string을 그릴 폰트의 사이즈를 줄여야 한다.
            float sizingFactorW = 1.0f; // default sizing factor is 1.0
            if (RealSize.Width > Room.Width)
            {
                sizingFactorW = Room.Width / RealSize.Width;
            }

            float sizingFactorH = 1.0f; // default sizing factor is 1.0
            if (RealSize.Height > Room.Height)
            {
                sizingFactorH = Room.Height / RealSize.Height;
            }

            float sizingFactor = sizingFactorW < sizingFactorH ? sizingFactorW : sizingFactorH;

            if (sizingFactor > 0)
                return new Font(PreferedFont.FontFamily, sizingFactor * PreferedFont.Size, FontStyle.Regular, GraphicsUnit.Pixel);
            else
                return null;

        }
        #endregion
    }





    public class AgingRack
    {
        public Rectangle Rect = new Rectangle(0, 0, 0, 0);

        public Brush bgBrush = Brushes.Gray;
        // 아무정보 없는것은 검은색으로 20190409 KJY
        //public Brush bgBrush = Brushes.Black;
        public Brush fgBrush = Brushes.White;

        public string RackID = string.Empty;
        public string StatusString = string.Empty;
        public string DisplayString = string.Empty;
        public string PlanTime = string.Empty;
        public string TrayId = string.Empty;
        public int TrayIdCount = 0;

        // YGPark 추가 property for filter
        public string OperGroupIdString = string.Empty;
        public string OperIdString = string.Empty;
        public string FireStatusString = string.Empty;
        public string BPlanUnloadString = string.Empty;

        // Hansy
        public string[] TrayIds = new String[2];
        public string CurrTrayId = string.Empty;

        // to show this rack or not
        public bool Hide = false;

        // when you give arbitrary number of strings for arguments
        public void SetTrayIDs(params string[] trays)
        {
            TrayId = string.Empty;
            TrayIdCount = 0;
            foreach (string tray in trays)
            {
                // if a trayid is empty or filled with just spaces, ignore it
                if (tray.Trim().Length <= 0) continue;


                // separate trayids with NEW-LINE
                if (TrayId.Length > 0) TrayId += "\n";


                // holds multiple tray ids in one variable (with each tray id separated by NEW-LINE)
                TrayId += tray;
                TrayIdCount++;
            }
            //DisplayString = TrayIdCount.ToString();
            //20190409 KJY - TrayID 끝 5자리로 해보자.\
            int lengthLimit = 5;
            if (TrayIdCount < 1)
                DisplayString = "";
            else
            {
                if(trays[0].Length > lengthLimit)
                {
                    int TrayIDLength = trays[0].Length;
                    //DisplayString = trays[0].Substring(TrayIDLength - 5);
                    //2022.11.10 nvmsh : TrayID 두개를 모두 표시해준다.
                    DisplayString = string.Format($"{trays[0].Substring(TrayIDLength - lengthLimit)}\n{trays[1].Substring(TrayIDLength - lengthLimit)}");
                }
                else
                {
                    //DisplayString = trays[0];
                    DisplayString = string.Format($"{trays[0]}\n{trays[1]}");
                }
            }
        }

        // 20210430 KJY - 공Tray의 CellType 표기를 위해 parameter 추가
        public void SetData(string chrState, string chrFireState, string strCurrTrayId, string chrOperGroupId, string chrOperId, string[] strTrayIds, string bPlanUnLoad, string strPlanTime, string strCellType = null, string DummyFlag=null)
        {
            try
            {
                // Hansy
                StatusString = chrState;    // Status
                TrayIds = strTrayIds;       // TrayID array(6)
                CurrTrayId = strCurrTrayId; // tTrayCurr TrayID

                // Add the value of property by YGPark
                OperGroupIdString = chrOperGroupId;
                OperIdString = chrOperId;
                FireStatusString = chrFireState;
                BPlanUnloadString = bPlanUnLoad;

                // Set TrayID
                SetTrayIDs(strTrayIds);

                //Set Plan Time
                PlanTime = strPlanTime;

                // Fire Status
                switch (chrFireState)
                {
                    case "F":
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Fire_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Fire_fg;
                        DisplayString = chrFireState.ToString();
                        return;

                    case "W":
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Water_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Water_fg;
                        DisplayString = chrFireState.ToString();
                        return;
                }

                //
                //202004001 KJY - for 출고지연 Status = 'A'
                //
                if(chrState == "A")
                {
                    bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Fire_bg;
                    fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Fire_fg;
                    DisplayString = "※※※"; // 지연
                    return;
                }

                //20211119 KJY - Marked Tray by MES API 추가 (Lock/Unlock)
                if(DummyFlag !=null && DummyFlag == "M")
                {
                    // 별도표시
                    bgBrush = RackStatusBrush.RackStatusBrush_Lock_bg;
                    fgBrush = RackStatusBrush.RackStatusBrush_Lock_fg;
                    DisplayString = "Lock";
                    return;
                }



                // Rack Out Planned
                if (bPlanUnLoad.ToLower() == "true")
                {
                    bgBrush = RackStatusBrush.RackStatusBrush_UnloadPlanned_bg;
                    fgBrush = RackStatusBrush.RackStatusBrush_UnloadPlanned_fg;
                    
                    // 공출고시 Trouble 이다.. Trouble을 표시해주자.
                    if(chrState == "N")
                    {
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Emptied_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Emptied_fg;
                        DisplayString = "N";
                    } else if (chrState =="T")
                    {
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Trouble_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Trouble_fg;
                        DisplayString = "T";
                    }

                    return;
                }

                switch (chrState)
                {
                    // No Input Status
                    case "X":
                        bgBrush = RackStatusBrush.RackStatusBrush_NoInput_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_NoInput_fg;
                        DisplayString = "X";
                        break;

                    // No Out Status
                    case "O":
                        bgBrush = RackStatusBrush.RackStatusBrush_NoOutput_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_NoOutput_fg;
                        break;

                    // Loading
                    case "1":
                        bgBrush = RackStatusBrush.RackStatusBrush_Loading_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Loading_fg;
                        break;

                    // Unloading
                    case "2":
                        bgBrush = RackStatusBrush.RackStatusBrush_Unloading_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Unloading_fg;
                        break;

                    // BadRack
                    case "B":
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Bad_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Bad_fg;
                        DisplayString = "B";
                        break;

                    // Reserve
                    case "R":
                        bgBrush = RackStatusBrush.RackStatusBrush_LoadRequest_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_LoadRequest_fg;
                        break;

                    // Unload Request
                    case "U":
                        bgBrush = RackStatusBrush.RackStatusBrush_UnloadRequest_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_UnloadRequest_fg;
                        break;

                    // Trouble
                    case "T":
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Trouble_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Trouble_fg;
                        DisplayString = "T";
                        break;

                    // Duplication
                    case "D":
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Duplicated_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Duplicated_fg;
                        DisplayString = "D";
                        break;

                    // Empty Be Release
                    case "N":
                        bgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Emptied_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_Abnormal_Emptied_fg;
                        DisplayString = "N";
                        break;

                    // Empty
                    case "E":
                        bgBrush = RackStatusBrush.RackStatusBrush_Empty;
                        fgBrush = RackStatusBrush.RackStatusBrush_Empty_fg;
                        //DisplayString = string.Empty;
                        DisplayString = "";
                        break;
                    // 20190624 KJY 강제 입고 추가
                    case "G":

                        //20210430 KJY - Status가 'G' 일 경우 CellType에 따라 다른 색을 칠한다.
                        if(strCellType !=null && strCellType.Length >= 3)
                        {
                            //마지막 세글자를 읽어서 305인지 322인지 확인한다.
                            if(strCellType.Substring(strCellType.Length -3, 3) == "305")
                            {
                                bgBrush = RackStatusBrush.RackStatusBrush_G305Loading_bg;
                                fgBrush = RackStatusBrush.RackStatusBrush_G305Loading_fg;
                                DisplayString = "305";
                                break;
                            } else if (strCellType.Substring(strCellType.Length - 3, 3) == "322")
                            {
                                bgBrush = RackStatusBrush.RackStatusBrush_G322Loading_bg;
                                fgBrush = RackStatusBrush.RackStatusBrush_G322Loading_fg;
                                DisplayString = "322";
                                break;
                            }
                        }

                        bgBrush = RackStatusBrush.RackStatusBrush_GLoading_bg;
                        fgBrush = RackStatusBrush.RackStatusBrush_GLoading_fg;
                        DisplayString = "G";
                        break;
                    
                    
                    case "F":
                        // 20190125 KJY - F 이면 Tray가 들어있는것이고 여기서 각 공정별로 색상을 입히는게 맞지 않나?
                    //    bgBrush = RackStatusBrush.RackStatusBrush_Full;
                    //    fgBrush = RackStatusBrush.RackStatusBrush_Full;
                    //    break;
                    //default:
                        //HT Aging
                        if (chrOperGroupId == "3")
                        {
                            bgBrush = RackStatusBrush.RackStatusBrush_HTAging_bg;
                            fgBrush = RackStatusBrush.RackStatusBrush_HTAging_fg;
                            chrState = "H";
                            return;
                        }
                        else if (chrOperGroupId == "1")
                        {
                            switch (chrOperId)
                            {
                                // 상온 1차 Aging
                                case "1":
                                    bgBrush = RackStatusBrush.RackStatusBrush_1stAging_bg;
                                    fgBrush = RackStatusBrush.RackStatusBrush_1stAging_fg;
                                    return;

                                // 상온 2차 Aging
                                case "2":
                                    bgBrush = RackStatusBrush.RackStatusBrush_2ndAging_bg;
                                    fgBrush = RackStatusBrush.RackStatusBrush_2ndAging_fg;
                                    return;

                                // 상온 3차 Aging
                                case "3":
                                    bgBrush = RackStatusBrush.RackStatusBrush_3rdAging_bg;
                                    fgBrush = RackStatusBrush.RackStatusBrush_3rdAging_fg;
                                    return;

                                // 상온 4차 Aging
                                case "4":
                                    bgBrush = RackStatusBrush.RackStatusBrush_4thAging_bg;
                                    fgBrush = RackStatusBrush.RackStatusBrush_4thAging_fg;
                                    return;

                                // 상온 5차 Aging
                                case "5":
                                    bgBrush = RackStatusBrush.RackStatusBrush_5thAging_bg;
                                    fgBrush = RackStatusBrush.RackStatusBrush_5thAging_fg;
                                    return;


                                // 20191128 KJY
                                // 상온 6차 Aging
                                case "6":
                                    bgBrush = RackStatusBrush.RackStatusBrush_6thAging_bg;
                                    fgBrush = RackStatusBrush.RackStatusBrush_6thAging_fg;
                                    return;


                                // Shipping Aging
                                case "9":
                                    bgBrush = RackStatusBrush.RackStatusBrush_ShipRTAging_bg;
                                    fgBrush = RackStatusBrush.RackStatusBrush_ShipRTAging_fg;
                                    return;
                            }
                        }
                        else
                        {
                            // Default - Empty Rack
                            bgBrush = RackStatusBrush.RackStatusBrush_Empty;
                            fgBrush = RackStatusBrush.RackStatusBrush_Empty_fg;

                            
                        }
                        break;
                    default: // 여기가 NULL 일때?
                        bgBrush = RackStatusBrush.RackStatusBrush_Empty;
                        fgBrush = RackStatusBrush.RackStatusBrush_Empty_fg;
                        DisplayString = "0";
                        break;

                }


                


            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set Data Add Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }

    }
}
