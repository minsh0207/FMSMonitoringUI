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
    #region [Class CtrlMainLeakCheck]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CtrlFormationBoxHPC
    //===================================================================
    public partial class CtrlMainLeakCheck : UserControl
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
        public CtrlMainLeakCheck()
        {
            // InitializeComponent
            InitializeComponent();

            m_boBoxObject = new CBoxObject[1];
            for (int nCnt = 0; nCnt < m_boBoxObject.Length; nCnt++)
            {
                m_boBoxObject[nCnt] = new CBoxObject();
            }
            //m_boBoxObject[0].m_borBoxObject = borBox01;
            //m_boBoxObject[0].m_txtObject = txtBox01;
            // Display영역 추가
            m_boBoxObject[0].m_borDisplayObject = borBox01_Info;
            m_boBoxObject[0].m_txtDisplayInfo = txtBox01_Info;
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
        public static readonly RoutedEvent BoxClickedEvent = EventManager.RegisterRoutedEvent("BoxClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CtrlMainLeakCheck));

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
            try
            {
                if (target == null) return null;
                CBoxClickedEventArgs args = new CBoxClickedEventArgs(nBoxNumber);
                args.RoutedEvent = BoxClickedEvent;
                RaiseEvent(target, args);
                return args;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:RaiseBoxClickedEvent] {0}", e.ToString()));
                return null;
            }
		}
		#endregion

		#region [RaiseEvent]
		/////////////////////////////////////////////////////////////////////
		//	Raise Event
		//===================================================================
		private static void RaiseEvent(DependencyObject target, RoutedEventArgs args)
		{
            try
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
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:RaiseEvent] {0}", e.ToString()));
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

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:AddHandler] {0}", e.ToString()));
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

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(string.Format("[Exception:RemoveHandler] {0}", e.ToString()));
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
            //this.m_nBoxIndex = 0;


            //CBoxClickedEventArgs args = new CBoxClickedEventArgs(nBoxNumber);
            //args.RoutedEvent = BoxClickedEvent;
            //RaiseEvent(this, args);
		}

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
        public void setBox(string trayID)
        {
            int nIndex = 0;
            m_boBoxObject[nIndex++].m_txtDisplayInfo.Text = trayID;
        }
        #endregion
        #endregion
    }
    #endregion
}
