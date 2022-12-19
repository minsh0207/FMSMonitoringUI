/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CTrayObject
//  Create Data		: 
//  Author			: 
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//===================================================================
using System;
using System.Windows.Media;
using System.Windows.Controls;


/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationMonCtrl
//===================================================================
namespace FormationMonCtrl
{
    #region [Class CTrayObject]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CTrayObject
    //===================================================================
    public class CTrayObject
    {
        #region [Variable]
		public char m_chrEqpTypeId;
		public char m_chrOperMode;
		public char m_chrOperGroupId;
		public char m_chrOperId;
		public char m_chrUnitStatus;
		public char m_chrProcStatus;
		public string m_strObjectId;
        public string m_strTrayId;
        public Brush m_bruBackColor;
		public Border m_borBoxObject;
        public TextBlock m_txtObject;
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
        public CTrayObject()
        {
			m_chrOperMode = ' ';
			m_chrEqpTypeId = ' ';
			m_chrOperGroupId = ' ';
			m_chrOperId = ' ';
			m_chrProcStatus = ' ';
			m_chrUnitStatus = ' ';
			m_strObjectId = "";
			m_strTrayId = "";
			m_bruBackColor = Brushes.Gray;
        }
        #endregion

        #region [Method]
        #region [Reset Data]
        /////////////////////////////////////////////////////////////////////
        //	Reset Data
        //===================================================================
        public void ResetData()
        {
			m_chrEqpTypeId = ' ';
			m_chrOperGroupId = ' ';
			m_chrOperId = ' ';
			m_chrProcStatus = ' ';
			m_chrUnitStatus = ' ';
			m_strObjectId = "";
			m_strTrayId = "";
			m_bruBackColor = Brushes.Gray;
        }
        #endregion

		#region [Set Data]
		/////////////////////////////////////////////////////////////////////
		//	Set Data
		//===================================================================
		public void SetData(CTrayObject trayObj)
		{
			SetData(trayObj.m_strObjectId, m_chrOperMode, trayObj.m_strTrayId, trayObj.m_chrUnitStatus, trayObj.m_chrProcStatus, trayObj.m_chrEqpTypeId, trayObj.m_chrOperGroupId, trayObj.m_chrOperId, "");
		}
		public void SetData(string strObjectId, char chrOperMode, string strTrayId, char chrUnitStatus = ' ', char chrProcessStatus = ' ', char chrEqpTypeID = ' ', char chrOperGroupID = ' ', char chrOperID = ' ', string strNextOperName = "", bool bEqpUseFlag = true, string tooltipOptInfo = "")
		{
			try
			{
				// Init
				m_borBoxObject.ToolTip = "EMPTY" + tooltipOptInfo;

				// Get Data
				this.m_strObjectId = strObjectId;
				this.m_chrOperMode = chrOperMode;
				this.m_strTrayId = strTrayId;
				this.m_chrUnitStatus = chrUnitStatus;
				this.m_chrProcStatus = chrProcessStatus;
				this.m_chrEqpTypeId = chrEqpTypeID;
				this.m_chrOperGroupId = chrOperGroupID;
				this.m_chrOperId = chrOperID;

				// Default
				this.m_bruBackColor = Brushes.Orange;

				// OperMode :: 수동 운전
                if (m_chrOperMode == 'M')     
                {
					this.m_bruBackColor = Brushes.Orange;
                    switch(m_chrUnitStatus)
                    {
                        case 'O':
                            this.m_bruBackColor = Brushes.Black;
                            break;
                    }
                }
				else
				{
				//// OperMode :: 자동 운전
				//if (m_chrOperMode == 'C')
				//{
					switch (m_chrUnitStatus)
					{
                        //OFF
                        case 'O':   // OperMode(C)이고 UnitStatus(O)인 경우는 없다. IT에서 PowerOff후에 Auto-Manual일 경우 상태 변경을 하지 않아서 Unitstatus가 변경이 안된것 같다.. PYG
                            //this.m_bruBackColor = Brushes.Black;
                            //break;
                        // N, Manual M:유지보수
                        case 'N':
                        case 'M':
                            this.m_bruBackColor = Brushes.Orange;
                            break;
						// Run
						case 'R':
							this.m_bruBackColor = Brushes.Green;
							break;
						// Trouble
						case 'T':
							this.m_bruBackColor = Brushes.Red;
							break;
						// Idle
						case 'I':
							this.m_bruBackColor = Brushes.Yellow;

							// Stacker Crane
							//if (chrEqpTypeID == CDefine.DEF_EQP_TYPE_ID_AGING_STACKER || chrEqpTypeID == CDefine.DEF_EQP_TYPE_ID_FORMATION_STACKER)
       //                     if(chrEqpTypeID == CDefine.DEF_EQP_TYPE_STACKERCRANE)
							//{
							//	if (m_chrProcStatus == 'L' || m_chrProcStatus == 'I')
							//	{
							//		this.m_bruBackColor = Brushes.Yellow;
							//	}
							//	else
							//	{
							//		this.m_bruBackColor = Brushes.DeepPink;
							//	}
							//}

							// BCR
							//if (m_strObjectId == CDefine.DEF_UNITID_BCR_04 || m_strObjectId == CDefine.DEF_UNITID_BCR_07 ||
							//	m_strObjectId == CDefine.DEF_UNITID_BCR_10 || m_strObjectId == CDefine.DEF_UNITID_BCR_11 ||
							//	m_strObjectId == CDefine.DEF_UNITID_BCR_13 || m_strObjectId == CDefine.DEF_UNITID_BCR_14 ||
							//	m_strObjectId == CDefine.DEF_UNITID_BCR_02)
							//{
							//	//if (m_chrProcStatus != 'I' || m_chrProcStatus != 'U')
							//	//{ 
							//	//    if (strTrayId.Length < 1) this.m_bruBackColor = Brushes.Yellow;
							//	//    else this.m_bruBackColor = Brushes.DeepPink; 
							//	//}
							//}
							break;
						default:
                            this.m_bruBackColor = Brushes.Gray;

                            break;
					}
				}

				// 화재 물통
				if (chrEqpTypeID == CDefineCtrl.DEF_EQP_TYPE_ID_FIRE)
				{
					// 투입가능 상태
					if (chrUnitStatus == 'I' && chrProcessStatus == 'L')
					{
						this.m_bruBackColor = Brushes.Yellow;
					}
					// 투입 불가 상태
					else
					{
						this.m_bruBackColor = Brushes.Red;
					}
				}

				m_txtObject.Text = strTrayId;
				if (strTrayId.Length > 0) m_borBoxObject.ToolTip = strTrayId + "\r\n" + "Next Process: " + strNextOperName + tooltipOptInfo;
				if (bEqpUseFlag != true) { m_bruBackColor = Brushes.Gray; m_txtObject.Text = "未使用"; }   //Not Use
			}
			catch (Exception ex)
			{
				// System Debug
				System.Diagnostics.Debug.Print(string.Format("### Set Data Add Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
			}
		}
		#endregion
        #endregion
    }
    #endregion
}
