/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CtrlFireWater
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
    #region [Class CtrlFireWater]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CtrlFireWater
    //===================================================================
    public partial class CtrlFireWater : UserControl
    {
        #region [Variable]
        CTrayObject m_currTray;
        string m_strObjectId = "";
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
        public CtrlFireWater()
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

        #region [Object ID Setting]
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
			InsertTray(trayObj.m_strObjectId, trayObj.m_strTrayId, trayObj.m_chrOperMode, trayObj.m_chrUnitStatus, trayObj.m_chrProcStatus, trayObj.m_chrEqpTypeId, trayObj.m_chrOperGroupId, trayObj.m_chrOperId, "");
		}
		public void InsertTray(string strObjectId, string strTrayId, char chrOperMode = ' ', char chrUnitStatus = ' ', char chrProcStatus = ' ', char chrEqpTypeId = ' ', char chrOperGroupId = ' ', char chrchrOperId = ' ', string strNextProcessName = "", string strTrayCnt = "0", bool bEqpUseFlag = true)
		{
            try
            {
                // Set Data
				m_currTray.SetData(strObjectId, chrOperMode, strTrayId, chrUnitStatus, chrProcStatus, chrEqpTypeId, chrOperGroupId, chrchrOperId, strNextProcessName, bEqpUseFlag);
				borCurrtray.Background = m_currTray.m_bruBackColor;

                // Tray Count
                txtTrayCnt.Text = strTrayCnt;
                bortrayCnt.Background = m_currTray.m_bruBackColor;
				
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
            InsertTray("", "");
        }
        #endregion
        #endregion
    }
    #endregion
}
