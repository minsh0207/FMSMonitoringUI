/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CtrlFormationCell
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
	#region [Class CtrlFormationCell]
	/////////////////////////////////////////////////////////////////////
    //	Class:  FormationCellControl
    //===================================================================
    public partial class CtrlFormationBoxJIG : UserControl
    {
        #region [Variable]
        CBoxObject[] m_boBoxObject;
        string m_strObjectId = "";
		string m_strUnitId = "";
        int m_nBoxIndex = 0;
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
		public CtrlFormationBoxJIG()
        {
            // InitializeComponent
            InitializeComponent();

            int boxIdx = 0;
            m_boBoxObject = new CBoxObject[30];
            for (int nCnt = 0; nCnt < m_boBoxObject.Length; nCnt++)
            {
                m_boBoxObject[nCnt] = new CBoxObject();
            }
            //m_boBoxObject[0].m_borBoxObject = borBox01;
            //m_boBoxObject[0].m_txtObject = txtBox01;
            m_boBoxObject[boxIdx].m_borDisplayObject = borBox01_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox01_Info;

            //m_boBoxObject[1].m_borBoxObject = borBox02;
            //m_boBoxObject[1].m_txtObject = txtBox02;
            m_boBoxObject[boxIdx].m_borDisplayObject = borBox02_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox02_Info;

            //m_boBoxObject[2].m_borBoxObject = borBox03;
            //m_boBoxObject[2].m_txtObject = txtBox03;
            m_boBoxObject[boxIdx].m_borDisplayObject = borBox03_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox03_Info;

            //m_boBoxObject[3].m_borBoxObject = borBox04;
            //m_boBoxObject[3].m_txtObject = txtBox04;
            m_boBoxObject[boxIdx].m_borDisplayObject = borBox04_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox04_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox05_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox05_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox06_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox06_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox07_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox07_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox08_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox08_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox09_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox09_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox10_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox10_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox11_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox11_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox12_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox12_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox13_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox13_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox14_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox14_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox15_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox15_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox16_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox16_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox17_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox17_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox18_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox18_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox19_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox19_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox20_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox20_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox21_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox21_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox22_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox22_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox23_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox23_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox24_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox24_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox25_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox25_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox26_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox26_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox27_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox27_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox28_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox28_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox29_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox29_Info;

            m_boBoxObject[boxIdx].m_borDisplayObject = borBox30_Info;
            m_boBoxObject[boxIdx++].m_txtDisplayInfo = txtBox30_Info;
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

		#region [UnitID Setting]
		/////////////////////////////////////////////////////////////////////
		//	Object ID Setting
		//===================================================================
		[Description("Set Unit ID"), Category("Appearance")]
		public string UnitID
		{
			get
			{
				return m_strUnitId;
			}
			set
			{
				m_strUnitId = string.Copy(value);
			}
		}
        #endregion
        //KJY test
        #region [Box Index Setting]
        /////////////////////////////////////////////////////////////////////
        //	Box Index Setting
        //  한 박스내의 여러 박스 (Dipaly영역 구별을 위해)
        //===================================================================
        [Description("Set Box Index"), Category("Appearance")]
        public int BoxIndex
        {
            get
            {
                return m_nBoxIndex;
            }
            set
            {
                m_nBoxIndex = value;
            }
        }
        #endregion
        #endregion

        #region [Route Event]
        // Routed Event
        // 이 이벤트가 발생하면 사용자의 클릭 상자 항목값 인수가 1부터 상자의 개수, 박스 번호는 아래에서 위로 증가
        public static readonly RoutedEvent BoxClickedEvent = EventManager.RegisterRoutedEvent("BoxClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CtrlFormationBoxJIG));

		#region [Box Clicked Event]
		/////////////////////////////////////////////////////////////////////
		//	BoxClicked
		//===================================================================
		public event RoutedEventHandler BoxClicked
		{
			add { AddHandler(BoxClickedEvent, value); }
			remove { RemoveHandler(BoxClickedEvent, value); }
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
			args.RoutedEvent = BoxClickedEvent;
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
		#region [Box Mouse Click]
		/////////////////////////////////////////////////////////////////////
		//	Box Mouse Click
		//===================================================================
		protected void Box_MouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//string strObjectName = ((Border)sender).Name;
			//int nBoxNumber = System.Convert.ToInt16(strObjectName.Substring(strObjectName.Length - 2));
			//this.m_strUnitId = m_boBoxObject[nBoxNumber - 1].m_txtObject.Tag.ToString();
   //         this.m_nBoxIndex = 0;


   //         CBoxClickedEventArgs args = new CBoxClickedEventArgs(nBoxNumber);
			//args.RoutedEvent = BoxClickedEvent;
			//RaiseEvent(this, args);
		}
        //KJY for Test
        protected void Text_MouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //string strObjectName = ((Border)sender).Name;
            //int nBoxNumber = System.Convert.ToInt16(strObjectName.Substring(strObjectName.Length - 7, 2));
            //this.m_strUnitId = m_boBoxObject[nBoxNumber - 1].m_txtObject.Tag.ToString();
            //this.m_nBoxIndex = 1;

            //CBoxClickedEventArgs args = new CBoxClickedEventArgs(nBoxNumber);
            //args.RoutedEvent = BoxClickedEvent;
            //RaiseEvent(this, args);
        }
        #endregion
        #endregion

        #region [Method]
        #region [Set Box]
        /////////////////////////////////////////////////////////////////////
        //	Set Box
        //===================================================================
        public void setBox(string templature)
        {
            for (int i = 0; i < 30; i++)
            {
                m_boBoxObject[i].m_txtDisplayInfo.Text = templature;
            }
        }
        public void setBox(int nIndex, CBoxObject boxObj)
        {
			setBox(nIndex, boxObj.m_strTrayId, boxObj.m_chrUnitStatus, boxObj.m_chrProcStatus, boxObj.m_chrFireStatus, boxObj.m_chrComStatus, boxObj.m_chrOperMode, boxObj.m_chrOperGroupId, boxObj.m_chrOperId, "", "", "");
        }
		public void setBox(int nIndex, string strTrayId, char chrUnitStatus, char chrProcState, char chrFireStatus, char chrComStatus, char chrOperMode, char chrOperGroupId, char chrOperId, string strStatus, string strUnitId, string strNextProcName, bool bEqpUseFlag = true, char chrCanInputBox = 'Y')
        {

            try
            {
                // index boundary check
                if (nIndex < 0) nIndex = 0;
                if (nIndex >= m_boBoxObject.Length) nIndex = m_boBoxObject.Length - 1;

                #if (DEBUG)
				m_boBoxObject[nIndex].m_borBoxObject.ToolTip = strTrayId + " " + strStatus + "\r\n" + "Next Process: " + strNextProcName;
				#else
                if (chrProcState == 'U' || chrUnitStatus == 'R' || chrUnitStatus == 'S' || chrUnitStatus == 'T')
                    m_boBoxObject[nIndex].m_borBoxObject.ToolTip = strTrayId + "\r\n" + "Next Process: " + strNextProcName;
                else
                    m_boBoxObject[nIndex].m_borBoxObject.ToolTip = null;
				//if (strTrayId.Length > 0) m_boBoxObject[nIndex].m_borBoxObject.ToolTip = strTrayId;
                #endif
				m_boBoxObject[nIndex].SetData(strTrayId, chrUnitStatus, chrProcState, chrFireStatus, chrComStatus, chrOperMode, chrOperGroupId, chrOperId, bEqpUseFlag, chrCanInputBox);
                m_boBoxObject[nIndex].m_borBoxObject.Background = m_boBoxObject[nIndex].m_bruBackColor;
                m_boBoxObject[nIndex].m_txtObject.Foreground = m_boBoxObject[nIndex].m_bruForeColor;
                m_boBoxObject[nIndex].m_txtObject.Text = m_boBoxObject[nIndex].m_strStateText;
                m_boBoxObject[nIndex].m_txtObject.Tag = strUnitId;

                InvalidateVisual();
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set Box Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        public void setBox(int nIndex, string strTrayId, string strLotID, string strStartTime, string strBoxTemperature, FormationMonCtrl.eDisplayInfomation eDisplayInfo, char chrUnitStatus, char chrProcState, char chrFireStatus, char chrComStatus, char chrOperMode, char chrOperGroupId, char chrOperId, string strStatus, string strUnitId, string strNextProcName, bool bEqpUseFlag = true, char chrCanInputBox = 'Y')
        {
            try
            {

                // index boundary check
                if (nIndex < 0) nIndex = 0;
                if (nIndex >= m_boBoxObject.Length) nIndex = m_boBoxObject.Length - 1;

#if (DEBUG)
                m_boBoxObject[nIndex].m_borBoxObject.ToolTip = strTrayId + " " + strStatus + "\r\n" + "Next Process: " + strNextProcName;
#else
                if (chrProcState == 'U' || chrUnitStatus == 'R' || chrUnitStatus == 'S' || chrUnitStatus == 'T')
                    m_boBoxObject[nIndex].m_borBoxObject.ToolTip = strTrayId + "\r\n" + "Next Process: " + strNextProcName;
                else
                    m_boBoxObject[nIndex].m_borBoxObject.ToolTip = null;
				//if (strTrayId.Length > 0) m_boBoxObject[nIndex].m_borBoxObject.ToolTip = strTrayId;
#endif
                //m_boBoxObject[nIndex].SetData(strTrayId, chrUnitStatus, chrProcState, chrFireStatus, chrComStatus, chrOperMode, chrOperGroupId, chrOperId, bEqpUseFlag, chrCanInputBox);
                m_boBoxObject[nIndex].SetData(strTrayId, chrUnitStatus, chrProcState, chrFireStatus, chrComStatus, chrOperMode, chrOperGroupId, chrOperId, bEqpUseFlag, chrCanInputBox,
                    strLotID, strStartTime, strBoxTemperature);
                m_boBoxObject[nIndex].m_borBoxObject.Background = m_boBoxObject[nIndex].m_bruBackColor;
                m_boBoxObject[nIndex].m_txtObject.Foreground = m_boBoxObject[nIndex].m_bruForeColor;
                m_boBoxObject[nIndex].m_txtObject.Text = m_boBoxObject[nIndex].m_strStateText;
                m_boBoxObject[nIndex].m_txtObject.Tag = strUnitId;
                //Display Infomation 영역
                //테두리와 Text의 color는 위의것의 Baackgroud 와 동일하게 간다.
                m_boBoxObject[nIndex].m_borDisplayObject.Background = new SolidColorBrush(Color.FromRgb(245,245,245));
                m_boBoxObject[nIndex].m_borDisplayObject.BorderBrush = m_boBoxObject[nIndex].m_bruBackColor;
                m_boBoxObject[nIndex].m_txtDisplayInfo.Foreground = m_boBoxObject[nIndex].m_bruBackColor;
                // Radio에서 선택한 값을 Display에 보여준다.
                switch (eDisplayInfo)
                {
                    case FormationMonCtrl.eDisplayInfomation.TrayID:
                        m_boBoxObject[nIndex].m_txtDisplayInfo.Text = m_boBoxObject[nIndex].m_strTrayId;
                        break;
                    case FormationMonCtrl.eDisplayInfomation.LotID:
                        m_boBoxObject[nIndex].m_txtDisplayInfo.Text = m_boBoxObject[nIndex].m_strLotID;
                        break;
                    case FormationMonCtrl.eDisplayInfomation.StartTime:
                        m_boBoxObject[nIndex].m_txtDisplayInfo.Text = m_boBoxObject[nIndex].m_strStartTime;
                        break;
                    case FormationMonCtrl.eDisplayInfomation.BoxTemperature:
                        m_boBoxObject[nIndex].m_txtDisplayInfo.Text = m_boBoxObject[nIndex].m_strBoxTemperature;
                        break;
                    default:
                        break;
                }




                InvalidateVisual();
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set Box Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion
        #endregion
    }
    #endregion
}
