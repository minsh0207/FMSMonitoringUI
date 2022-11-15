/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CtrlComEquipment
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
	#region [Class CtrlComEquipment]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CtrlComEquipment
    //===================================================================
    public partial class CtrlComEquipment : UserControl
    {
        #region [Variable]
        CTrayObject m_currTray;
        string m_strObjectId = "";
        string m_strInModelID = "";
        string m_strInRouteID = "";
        string m_strInCellType = "";
        string tooltipOptInfo = "";         //ToolTip에 추가적인 정보 표시를 위해
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
        public CtrlComEquipment()
        {
            // InitializeComponent
            InitializeComponent();

            // Curr Tray
            m_currTray = new CTrayObject();
            m_currTray.m_borBoxObject = borCurrtray;
            m_currTray.m_txtObject = txtCurr;
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

        #region [Model ID Setting]
        /////////////////////////////////////////////////////////////////////
        //	Model TYpe Setting
        //===================================================================
        [Description("Set Equipment Model ID"), Category("Appearance")]
        public string InModelID
        {
            get
            {
                return m_strInModelID;
            }
            set
            {
                m_strInModelID = string.Copy(value);
            }
        }
        #endregion

        #region [Route ID Setting]
        /////////////////////////////////////////////////////////////////////
        //	Route ID Setting
        //===================================================================
        [Description("Set Equipment RouteID"), Category("Appearance")]
        public string InRouteID
        {
            get
            {
                return m_strInRouteID;
            }
            set
            {
                m_strInRouteID = string.Copy(value);
            }
        }
        #endregion

        #region [Cell Type Setting]
        /////////////////////////////////////////////////////////////////////
        //	Cell Type Setting
        //===================================================================
        [Description("Set Equipment InCellType"), Category("Appearance")]
        public string InCellType
        {
            get
            {
                return m_strInCellType;
            }
            set
            {
                m_strInCellType = string.Copy(value);
            }
        }
        #endregion

        #region [Device Name Setting]
        /////////////////////////////////////////////////////////////////////
        //	Object ID Setting
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
        #region [Insert Tray]
        /////////////////////////////////////////////////////////////////////
        //	Insert Tray
        //===================================================================
		public void InsertTray(CTrayObject trayObj)
		{
			InsertTray(trayObj.m_strObjectId, "", "","", trayObj.m_strTrayId, trayObj.m_chrOperMode, trayObj.m_chrUnitStatus, trayObj.m_chrProcStatus, trayObj.m_chrEqpTypeId, trayObj.m_chrOperGroupId, trayObj.m_chrOperId, "");
		}
		public void InsertTray(string strObjectId, string strInModelID, string strInRouteID, string strInCellType, string strTrayId, char chrOperMode = ' ', char chrUnitStatus = ' ', char chrProcStatus = ' ', char chrEqpTypeId = ' ', char chrOperGroupId = ' ', char chrchrOperId = ' ', string strNextProcessName = "", bool bEqpUseFlag = true)
		{
            try
            {
                // Set Data
                m_strObjectId = strObjectId;
                m_strInModelID = strInModelID;
                m_strInRouteID = strInRouteID;
                m_strInCellType = strInCellType;
                tooltipOptInfo = "";


                if (!m_strInModelID.Equals("")) tooltipOptInfo += " ["+ m_strInModelID +"]";
                if (!m_strInRouteID.Equals("")) tooltipOptInfo += " [" + m_strInRouteID + "]";
                if (!m_strInCellType.Equals("")) tooltipOptInfo += " [" + m_strInCellType + "]";

                m_currTray.SetData(strObjectId, chrOperMode, strTrayId, chrUnitStatus, chrProcStatus, chrEqpTypeId, chrOperGroupId, chrchrOperId, strNextProcessName, bEqpUseFlag, tooltipOptInfo);
				borCurrtray.Background = m_currTray.m_bruBackColor;
				
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

        #region [Remove Tray]
        /////////////////////////////////////////////////////////////////////
        //	Remove Tray
        //===================================================================
        public void RemoveTray()
        {
            InsertTray("", "", "", "","");
        }
        #endregion
        #endregion
    }
    #endregion
}
