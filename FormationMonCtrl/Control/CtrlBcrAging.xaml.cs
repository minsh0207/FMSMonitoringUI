/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: BcrAgingControl
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
	#region [Class CtrlBcrAging]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CtrlBcrAging
    //===================================================================
    public partial class CtrlBcrAging : UserControl
    {
        #region [Variable]
        CTrayObject[] m_trayObject;
        string m_strObjectId = "";
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
		public CtrlBcrAging()
        {
            // InitializeComponent
            InitializeComponent();

            m_trayObject = new CTrayObject[6];
            for (int nCnt = 0; nCnt < m_trayObject.Length; nCnt++)
            {
                m_trayObject[nCnt] = new CTrayObject();
            }
            m_trayObject[0].m_borBoxObject = borTray1;
            m_trayObject[0].m_txtObject = txtTray1;
            m_trayObject[1].m_borBoxObject = borTray2;
            m_trayObject[1].m_txtObject = txtTray2;
            m_trayObject[2].m_borBoxObject = borTray3;
            m_trayObject[2].m_txtObject = txtTray3;

            m_trayObject[3].m_borBoxObject = borTray4;
            m_trayObject[3].m_txtObject = txtTray4;
            m_trayObject[4].m_borBoxObject = borTray5;
            m_trayObject[4].m_txtObject = txtTray5;
            m_trayObject[5].m_borBoxObject = borTray6;
            m_trayObject[5].m_txtObject = txtTray6;
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
        public void SetTray(int nIndex, CTrayObject trayObj)
        {
			SetTray(nIndex, trayObj.m_strObjectId, trayObj.m_strTrayId, trayObj.m_chrOperMode, trayObj.m_chrUnitStatus, trayObj.m_chrProcStatus, trayObj.m_chrEqpTypeId, trayObj.m_chrOperGroupId, trayObj.m_chrOperId, "");
        }
		public void SetTray(int nIndex, string strObjectId, string strTrayId, char chrOperMode = ' ', char chrUnitStatus = ' ', char chrProcStatus = ' ', char chrEqpTypeId = ' ', char chrOperGroupId = ' ', char chrOperId = ' ', string strNextProcessName = "", bool bEqpUseFlag = true)
        {
            try
            {
                // index boundary check
                if (nIndex < 0) nIndex = 0;
                if (nIndex >= m_trayObject.Length) nIndex = m_trayObject.Length - 1;

                // Set Data
				m_trayObject[nIndex].SetData(strObjectId, chrOperMode, strTrayId, chrUnitStatus, chrProcStatus, chrEqpTypeId, chrOperGroupId, chrOperId, strNextProcessName, bEqpUseFlag);								

				borTray1.Background = m_trayObject[nIndex].m_bruBackColor;
				borTray2.Background = m_trayObject[nIndex].m_bruBackColor;
				borTray3.Background = m_trayObject[nIndex].m_bruBackColor;
				borTray4.Background = m_trayObject[nIndex].m_bruBackColor;
				borTray5.Background = m_trayObject[nIndex].m_bruBackColor;
				borTray6.Background = m_trayObject[nIndex].m_bruBackColor;             

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
            for (int nCnt = 0; nCnt < m_trayObject.Length; nCnt++)
            {
                ResetTray(nCnt);
            }
        }
        public void ResetTray(int nIndex)
        {
            SetTray(nIndex, "", "");
        }
        #endregion
        #endregion
    }
    #endregion
}