/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CtrlBcr
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
	#region [Class CtrlBcr]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CtrlBcr
    //===================================================================
    public partial class CtrlBcr : UserControl
    {
        #region [Variable]
        CTrayObject m_trayObject;
        string m_strObjectId = "";
        string m_strDirection = "";
        Brush m_strDirectionBG;
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
		public CtrlBcr()
        {
            // InitializeComponent
            InitializeComponent();

            m_trayObject = new CTrayObject();
            m_trayObject.m_borBoxObject = borCurrTray;
            m_trayObject.m_txtObject = txtCurrTray;
            m_strDirectionBG = Brushes.DeepPink;
        }
        #endregion

        #region [Property]

        #region [Direction Setting]
        /////////////////////////////////////////////////////////////////////
        //	Object ID Setting
        //===================================================================
        [Description("Set Direction"), Category("Appearance")]
        public string Direction
        {
            get
            {
                return m_strDirection;
            }
            set
            {
                m_strDirection = string.Copy(value);
                switch (m_strDirection)
                {
                    case "T":   //오른쪽 직진
                        grdRowTop.Height = new GridLength(4, GridUnitType.Pixel);
                        borTop.Background = Brushes.DeepPink;
                        break;
                    case "B":
                        grdRowBottom.Height = new GridLength(4, GridUnitType.Pixel); 
                        borBottom.Background = Brushes.Teal;
                        break;
                    case "L":
                        grdColumnLeft.Width = new GridLength(4, GridUnitType.Pixel);
                        borLeft.Background = Brushes.DeepPink;
                        break;
                    case "R":
                        grdColumnRight.Width = new GridLength(4, GridUnitType.Pixel);
                        borRight.Background = Brushes.Teal;
                        break;
                    case "F":   //왼쪽 직진 OR 위쪽 투입
                        borBottom.Background = m_strDirectionBG;
                        borLeft.Background = m_strDirectionBG;
                        break;

                }
            }
        }
        #endregion

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

		#region [Device Name Setting]
		/////////////////////////////////////////////////////////////////////
		//	Device Name Setting
        //===================================================================
        [Description("Set Device Name"), Category("Appearance")]
        public string DeviceName
        {
            get
            {
                return this.txtDeviceName.Text;
            }
            set
            {
                this.txtDeviceName.Text = value;

                // 이후에 UpdateLayout이 강제로 지정하는 경우가 아니면 업데이트는 비동기적으로 수행됩니다. 
                InvalidateVisual();
            }
        }
        #endregion
        #endregion

        #region [Method]
        #region [Set Tray]
        /////////////////////////////////////////////////////////////////////
        //	Set Tray
        //===================================================================
        public void SetTray(CTrayObject trayObj)
        {
			SetTray(trayObj.m_strObjectId, trayObj.m_strTrayId, trayObj.m_chrOperMode, trayObj.m_chrUnitStatus, trayObj.m_chrProcStatus, trayObj.m_chrEqpTypeId, trayObj.m_chrOperGroupId, trayObj.m_chrOperId, "");
		}
		public void SetTray(string strObjectId, string strTrayId, char chrOperMode = ' ', char chrUnitStatus = ' ', char chrProcStatus = ' ', char chrEqpTypeId = ' ', char chrOperGroupId = ' ', char chrchrOperId = ' ', string strNextOperName = "", bool bEqpUseFlag = true)
		{
            try
            {
                // Set Data
				m_trayObject.SetData(strObjectId, chrOperMode, strTrayId, chrUnitStatus, chrProcStatus, chrEqpTypeId, chrOperGroupId, chrchrOperId, strNextOperName, bEqpUseFlag);
				borCurrTray.Background = m_trayObject.m_bruBackColor;
				
                // 요소의 정렬 상태(레이아웃)을 무효화합니다. 
                // 무효화 이후 해당 요소의 레이아웃은 업데이트되며, 
                // 이후에 UpdateLayout이 강제로 지정하는 경우가 아니면 업데이트는 비동기적으로 수행됩니다. 
                InvalidateVisual();
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Insert Tray Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Reset Tray]
        /////////////////////////////////////////////////////////////////////
        //	Reset Tray
        //===================================================================
        public void ResetTray()
        {
            SetTray("" ,"");
        }
        #endregion

        #endregion
    }
    #endregion
}
