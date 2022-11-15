/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CtrlAgingBay
//  Create Data		: 
//  Author			: 
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//===================================================================
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;

/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationMonCtrl
//===================================================================
namespace FormationMonCtrl
{
	#region [Class CtrlAgingBay]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CtrlAgingBay
    //===================================================================
    public partial class CtrlAgingBay : UserControl
    {
        #region [Variable]
        CAgingRackObject[] m_agingRacks;
        string m_strObjectId = "";
        string m_strRackId = "";
		string[] m_strTrayIds;
        string m_strPlanTime = "";
        string m_strStatus = "";
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
		public CtrlAgingBay()
        {
            // InitializeComponent
            InitializeComponent();

            m_agingRacks = new CAgingRackObject[7];
            for (int nCnt = 0; nCnt < m_agingRacks.Length; nCnt++)
            {
                m_agingRacks[nCnt] = new CAgingRackObject();
            }
            m_agingRacks[0].m_borRackObject = borRack01;
            m_agingRacks[0].m_txtObject = txtRack01;
            m_agingRacks[1].m_borRackObject = borRack02; 
            m_agingRacks[1].m_txtObject = txtRack02;
            m_agingRacks[2].m_borRackObject = borRack03;
            m_agingRacks[2].m_txtObject = txtRack03;
            m_agingRacks[3].m_borRackObject = borRack04;
            m_agingRacks[3].m_txtObject = txtRack04;
            m_agingRacks[4].m_borRackObject = borRack05;
            m_agingRacks[4].m_txtObject = txtRack05;

            m_agingRacks[5].m_borRackObject = borRack06;
            m_agingRacks[5].m_txtObject = txtRack06;
            m_agingRacks[6].m_borRackObject = borRack07;
            m_agingRacks[6].m_txtObject = txtRack07;
			m_strTrayIds = new string[7];


        }
        #endregion

        #region [Property]
        #region [Object ID Setting]
        /////////////////////////////////////////////////////////////////////
        //	Object ID Setting
        //===================================================================
        [Description("Set Object ID"), Category("Appearance")]
        public string ObjectID
        {
            get
            {
                return m_strObjectId;
            }
            set
            {
                m_strObjectId = string.Copy(value);
            }
        }
        #endregion

        #region [Rack ID Setting]
        /////////////////////////////////////////////////////////////////////
        //	Rack ID Setting
        //===================================================================
        [Description("Set Rack ID"), Category("Appearance")]
        public string RackID
        {
            get
            {
                return m_strRackId;
            }
            set
            {
                m_strRackId = string.Copy(value);
            }
        }
        #endregion

		#region [Tray ID Setting]
		/////////////////////////////////////////////////////////////////////
		//	Tray ID Setting
		//===================================================================
		[Description("Set Tray ID"), Category("Appearance")]
		public string[] TrayID
		{
			get
			{
				return m_strTrayIds;
			}
			set
			{
				Array.Copy(value, 0, m_strTrayIds, 0, m_strTrayIds.Length);
				//m_strTrayIds = string.Copy(value);
			}
		}
		#endregion

        #region [Plan Time Setting]
        /////////////////////////////////////////////////////////////////////
        //	Plan Time Setting
        //===================================================================
        [Description("Set Plan Time"), Category("Appearance")]
        public string PlanTime
        {
            get
            {
                return m_strPlanTime;
            }
            set
            {
                m_strPlanTime = string.Copy(value);
            }
        }
        #endregion

        #region [Status Setting]
        /////////////////////////////////////////////////////////////////////
        //	Status Setting
        //===================================================================
        [Description("Set Status"), Category("Appearance")]
        public string Status
        {
            get
            {
                return m_strStatus;
            }
            set
            {
                m_strStatus = string.Copy(value);
            }
        }
        #endregion
        #endregion

        #region [Route Event]
        // Routed Event
        // 이 이벤트가 발생하면 사용자의 클릭 상자 항목값 인수가 1부터 상자의 개수, 박스 번호는 아래에서 위로 증가
        public static readonly RoutedEvent BayClickedEvent = EventManager.RegisterRoutedEvent("BayClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CtrlAgingBay));

        #region [Box Clicked Event]
        /////////////////////////////////////////////////////////////////////
        //	BoxClicked
        //===================================================================
        public event RoutedEventHandler BoxClicked
        {
            add { AddHandler(BayClickedEvent, value); }
            remove { RemoveHandler(BayClickedEvent, value); }
        }
        #endregion

        #region [RoutedEventArgs Event]
        /////////////////////////////////////////////////////////////////////
        //	RoutedEventArgs
        //===================================================================
        protected RoutedEventArgs RaiseBoxClickedEvent(int nBoxNumber)
        {
            return RaiseBoxClickedEvent(this, nBoxNumber);
        }
        #endregion

        #region [RoutedEventArgs Event]
        /////////////////////////////////////////////////////////////////////
        //	RoutedEventArgs
        //===================================================================
        internal static RoutedEventArgs RaiseBoxClickedEvent(UIElement target, int nBoxNumber)
        {
            if (target == null) return null;
            CBoxClickedEventArgs args = new CBoxClickedEventArgs(nBoxNumber);
            args.RoutedEvent = BayClickedEvent;
            RaiseEvent(target, args);
            return args;
        }
        #endregion

        #region [RaiseEvent]
        /////////////////////////////////////////////////////////////////////
        //	Raise Event
        //===================================================================
        private static void RaiseEvent(DependencyObject target, RoutedEventArgs args)
        {
            if (target is UIElement)
            {
                (target as UIElement).RaiseEvent(args);
            }
            else if (target is ContentElement)
            {
                (target as ContentElement).RaiseEvent(args);
            }
        }
        #endregion

        #region [AddHandler]
        /////////////////////////////////////////////////////////////////////
        //	AddHandler
        //===================================================================
        private static void AddHandler(DependencyObject element, RoutedEvent routedEvent, Delegate handler)
        {
            UIElement uie = element as UIElement;
            if (uie != null)
            {
                uie.AddHandler(routedEvent, handler);
            }
            else
            {
                ContentElement ce = element as ContentElement;
                if (ce != null)
                {
                    ce.AddHandler(routedEvent, handler);
                }
            }
        }
        #endregion

        #region [RemoveHandler]
        /////////////////////////////////////////////////////////////////////
        //	RemoveHandler
        //===================================================================
        private static void RemoveHandler(DependencyObject element, RoutedEvent routedEvent, Delegate handler)
        {
            UIElement uie = element as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(routedEvent, handler);
            }
            else
            {
                ContentElement ce = element as ContentElement;
                if (ce != null)
                {
                    ce.RemoveHandler(routedEvent, handler);
                }
            }
        }
        #endregion
        #endregion

        #region [Button & Action Event]
        #region [Bay Mouse Click]
        /////////////////////////////////////////////////////////////////////
        //	Box Mouse Click
        //===================================================================
		protected void Bay_MouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string strObjectName = ((Border)sender).Name;
            int nBoxNumber = System.Convert.ToInt16(strObjectName.Substring(strObjectName.Length - 2));
            this.m_strRackId = m_agingRacks[nBoxNumber - 1].m_txtObject.Tag.ToString();
            this.m_strTrayIds = m_agingRacks[nBoxNumber - 1].m_strTrayIds;
            this.m_strPlanTime = m_agingRacks[nBoxNumber - 1].m_strPlanTime;
            this.m_strStatus = string.Format("{0}", m_agingRacks[nBoxNumber - 1].m_chrStatus);

            CBoxClickedEventArgs args = new CBoxClickedEventArgs(nBoxNumber);
            args.RoutedEvent = BayClickedEvent;
            RaiseEvent(this, args);
        }
        #endregion
        #endregion

        #region [Method]
        #region [Make Tooltip Text]
        /////////////////////////////////////////////////////////////////////
        //	Make Tooltip Text
        //===================================================================
        private string MakeTooltipText(string[] strAry, string strStatus = "")
        {
            try
            {
                int nFirstNotEmpty = -1;
                for (int nCnt = 0; nCnt < strAry.Length; nCnt++)
                {
                    if (strAry[nCnt].Length > 0)
                    {
                        nFirstNotEmpty = nCnt;
                        break;
                    }
                }

                if (nFirstNotEmpty < 0) return "Empty";

                
                string strRet = strAry[nFirstNotEmpty];
                for (int nCnt = nFirstNotEmpty + 1; nCnt < strAry.Length; nCnt++)
                {
                    if (strAry[nCnt].Length > 0)
                        strRet = strAry[nCnt] + "\r\n" + strRet;
                        //strRet += "\r\n" + strAry[nCnt];

                }

                // Return
                return strRet;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Make ToolTip Text Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return "";
            }
        }
        #endregion

        #region [Reset Rack]
        /////////////////////////////////////////////////////////////////////
        //	Reset Rack
        //===================================================================
        public void ResetRack(int nIndex)
        {
            try
            {
            // index boundary check
            if (nIndex < 0) nIndex = 0;
            if (nIndex >= m_agingRacks.Length) nIndex = m_agingRacks.Length - 1;
            m_agingRacks[nIndex].ResetTray();
            m_agingRacks[nIndex].m_borRackObject.ToolTip = MakeTooltipText(m_agingRacks[nIndex].m_strTrayIds);
            m_agingRacks[nIndex].m_borRackObject.Background = m_agingRacks[nIndex].m_bruBackColor;
            m_agingRacks[nIndex].m_txtObject.Text = m_agingRacks[nIndex].GetTrayCount();
			m_agingRacks[nIndex].m_chrStatus = ' ';
			m_agingRacks[nIndex].m_chrOperGroupId = ' ';
			m_agingRacks[nIndex].m_chrOperId = ' ';
			m_agingRacks[nIndex].m_bPlanUnload = false;

            InvalidateVisual();
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Reset Rack Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Set Rack]
        /////////////////////////////////////////////////////////////////////
        //	Set Rack
        //===================================================================
        public void SetRack(int nIndex, char chrState, char chrFireState, char chrOperGroupId, char chrOperId, string[] strTrayId, string strRackID, bool bPlanUnLoad, string strPlanTime)
        {
            try
            {
                // index boundary check
                if (nIndex < 0) nIndex = 0;
                if (nIndex >= m_agingRacks.Length) nIndex = m_agingRacks.Length - 1;

                m_agingRacks[nIndex].SetData(chrState, chrFireState, chrOperGroupId, chrOperId, strTrayId, bPlanUnLoad, strPlanTime);

                m_agingRacks[nIndex].m_borRackObject.ToolTip = MakeTooltipText(m_agingRacks[nIndex].m_strTrayIds);
                m_agingRacks[nIndex].m_borRackObject.Background = m_agingRacks[nIndex].m_bruBackColor;
                m_agingRacks[nIndex].m_txtObject.Foreground = m_agingRacks[nIndex].m_bruForeColor;
                m_agingRacks[nIndex].m_txtObject.Text = m_agingRacks[nIndex].GetTrayCount();
                m_agingRacks[nIndex].m_txtObject.Tag = strRackID;

                if (strRackID.Substring(0, 1).ToString() == "H")
                {
                    // H-Aging의 경우 개수가 다르다
                    //this.grdRackContainer.RowDefinitions[0].Height = new GridLength(0.0, GridUnitType.Star);
                    //this.grdRackContainer.RowDefinitions[1].Height = new GridLength(0.0, GridUnitType.Star);

                    //this.grdRackContainer.RowDefinitions[0].Height = GridLength.Auto;
                    //this.grdRackContainer.RowDefinitions[1].Height = GridLength.Auto;
                }

                // 요소의 정렬 상태(레이아웃)을 무효화합니다. 
                // 무효화 이후 해당 요소의 레이아웃은 업데이트되며, 
                // 이후에 UpdateLayout이 강제로 지정하는 경우가 아니면 업데이트는 비동기적으로 수행됩니다. 
                InvalidateVisual();
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set Rack Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Set Highlight By Status]
        /////////////////////////////////////////////////////////////////////
        //	Set Highlight By Status
        //===================================================================
        public void SetHighlightByStatus(char chrState, char chrFireState, char chrOperGroupId, char chrOperId, bool bPlanUnLoad)
        {
            try
            {
                char chrSetState = chrState;
                char chrSetFire = chrFireState;
				char chrSearchState = ' ';

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

                foreach (CAgingRackObject argRackObj in m_agingRacks)
                {
                    argRackObj.m_txtObject.Foreground = Brushes.Black;
                        
                    if (bPlanUnLoad == true)
                    {
                        if (argRackObj.m_bPlanUnload != bPlanUnLoad)
                            argRackObj.m_borRackObject.Background = Brushes.Black;
                    }
                    else
                    {
						chrSearchState = argRackObj.m_chrStatus;
						if (chrState == '1' || chrState == '2') { }
						else
						{
							// HT Aging
							if (argRackObj.m_chrOperGroupId == '3') chrSearchState = 'H';
							// RT Aging
							else if (argRackObj.m_chrOperGroupId == '1' && chrSearchState != 'O') chrSearchState = argRackObj.m_chrOperId;
						}

                        if (chrSetFire == ' ')
                        {
							if (chrSearchState != chrSetState)
                                if (argRackObj.m_txtObject.Text.Length < 1) 
                                    argRackObj.m_txtObject.Foreground = Brushes.Gray;
                                else
								    argRackObj.m_borRackObject.Background = Brushes.Black;
							else if (chrOperGroupId == '1' && chrOperId == '5')
								argRackObj.m_txtObject.Foreground = Brushes.White;

							if (argRackObj.m_bPlanUnload == true)
								argRackObj.m_txtObject.Foreground = Brushes.Black;
                        }
                        else 
                        {
							if (argRackObj.m_charFireStatus != chrSetFire)
								argRackObj.m_borRackObject.Background = Brushes.Black;
                            //else if (argRackObj.m_chrStatus != chrState)
                            //    argRackObj.m_borRackObject.Background = Brushes.Black;
                        }
                        //}
                    }
                }
                // 요소의 정렬 상태(레이아웃)을 무효화합니다. 
                // 무효화 이후 해당 요소의 레이아웃은 업데이트되며, 
                // 이후에 UpdateLayout이 강제로 지정하는 경우가 아니면 업데이트는 비동기적으로 수행됩니다. 
                InvalidateVisual();
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set Highlight By Status Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

		#region [Set Highlight By SPDClick]
		/////////////////////////////////////////////////////////////////////
		//	Set Highlight By SPDClick
		//===================================================================
        public void SetHighlightBySPDClick(string strTrayId)
        {
            try
            {
                foreach (CAgingRackObject argRackObj in m_agingRacks)
                {
                    for (int nCnt = 0; nCnt < argRackObj.m_nTrayCount; nCnt++)
                    {
                        if (argRackObj.m_strTrayIds[nCnt] == strTrayId)
                            argRackObj.m_borRackObject.Background = Brushes.Magenta;
                    }
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set SetHighlightBySPDClick By Status Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
		}
		#endregion
		#endregion
	}
    #endregion
}
