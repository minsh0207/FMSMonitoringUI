/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CAgingRackObject
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
	#region [Class CAgingRackObject]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CAgingRackObject
    //===================================================================
    class CAgingRackObject
    {
        #region [Variable]
        public char m_chrStatus;
        public char m_charFireStatus;
		public char m_chrOperGroupId;
		public char m_chrOperId;
        public bool m_bPlanUnload;
        public Brush m_bruBackColor;
        public Brush m_bruForeColor;
        public Border m_borRackObject;
        public TextBlock m_txtObject;
        public string[] m_strTrayIds;
        public string m_strPlanTime;
        public int m_nTrayCount;
  
        // Empty
        public Brush m_bruEmpty = Brushes.Gray;

        // RT Aging : OperGroubID = 1, OperID = 1 ~ 5
        public Brush m_bruRtAging1;
        public Brush m_bruRtAging2;
        public Brush m_bruRtAging3;
        public Brush m_bruRtAging4;
        public Brush m_bruRtAging5;
        
        public Brush m_bruShipRtAging;		// RT Aging Shipping :OperGroubID = 1, OperID = 9
        public Brush m_bruHtAging;			// HT Aging : OperGroubID = 3, OperID = 1
        public Brush m_bruBadRack;			// BadRack : Status = B
        public Brush m_bruNa;				// No Input : Status = X
        public Brush m_bruInput;			// Reserve : Status = R
		public Brush m_bruLoading;			// Loading
        public Brush m_bruOutput;			// Unload Request : Status = U        
		public Brush m_bruUnloading;		// Unloading
        public Brush m_bruPlanOutput;		// Plan Unload Request : bPlanUnLoad = True        
        public Brush m_bruTrouble;			// Trouble : Status = T        
        public Brush m_bruFire;				// Fire : Status = X, FireStatus = F
        public Brush m_bruWater;			// Water : Status = X, FireStatus = W
		public Brush m_bruDuplication;		// Duplication
		public Brush m_bruEmptyBeRelease;	// Empty Be Release
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
		public CAgingRackObject()
        {
            // Tray ID 변수 초기화
            m_strTrayIds = new string[6];
            for (int nCnt = 0; nCnt < m_strTrayIds.Length; nCnt++)
            {
                m_strTrayIds[nCnt] = "";
            }

            // Tray Count 초기화
            m_nTrayCount = 0;

			// Init
			m_bruEmpty = Brushes.Gray;
			m_bruRtAging1 = Brushes.LightCyan;
			m_bruRtAging2 = Brushes.Cyan;
			m_bruRtAging3 = Brushes.DarkCyan;
			m_bruRtAging4 = Brushes.Blue;
			m_bruRtAging5 = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 139));

			m_bruShipRtAging  = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 105, 255));
			m_bruHtAging      = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 204, 0));
			m_bruBadRack      = new SolidColorBrush(System.Windows.Media.Color.FromRgb(112, 48, 160));
			m_bruNa           = Brushes.Orange;
			m_bruInput        = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 135, 0));
			m_bruLoading	  = Brushes.Salmon;
			m_bruOutput       = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 195, 0));
			m_bruUnloading	  = Brushes.Chocolate;
			m_bruPlanOutput   = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
			m_bruTrouble	  = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
			m_bruFire         = Brushes.Indigo;
			m_bruFire		  = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
			m_bruWater        = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
			m_bruDuplication  = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
			m_bruEmptyBeRelease = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
        }
        #endregion

        #region [Method]
        #region [Get TrayCount]
        /////////////////////////////////////////////////////////////////////
        //	Get Tray Count
        //===================================================================
        public string GetTrayCount()
        {
            if (m_charFireStatus == 'W') return "W";
                
            if (m_charFireStatus == 'F') return "F";
                   
            if (m_chrStatus == 'T') return "T";

			if (m_chrStatus == 'O') return "-";

			if (m_chrStatus == 'D') return "D";

            if (m_chrStatus == 'N') return "N";

            if (m_chrStatus == 'B') return "B";

            if (m_chrStatus == 'X') return "X";

            return m_nTrayCount.ToString();
        }
        #endregion

        #region [Reset Tray]
        /////////////////////////////////////////////////////////////////////
        //	Reset Tray
        //===================================================================
        public void ResetTray()
        {
            m_bruBackColor = Brushes.Gray;
            m_bruForeColor = Brushes.Black; 
            for (int nCnt = 0; nCnt < m_strTrayIds.Length; nCnt++)
            {
                m_strTrayIds[nCnt] = "";
            }
            m_nTrayCount = 0;
        }
        #endregion

        #region [Set Data]
        /////////////////////////////////////////////////////////////////////
        //	Set Data
        //===================================================================
        public void SetData(char chrState, char chrFireState, char chrOperGroupId, char chrOperId, string[] strTrayId, bool bPlanUnLoad, string strPlanTime)
        {
            try
            {
                // Set TrayID
                for (int nCnt = 0; nCnt < strTrayId.Length; nCnt++)
                {
                    if (strTrayId[nCnt].Length > 0)
                    {
                        m_strTrayIds[nCnt] = strTrayId[nCnt];
                        m_nTrayCount++;
                    }
                }

                //Set Plan Time
                m_strPlanTime = strPlanTime;

                // State
                m_chrStatus = chrState;
				m_chrOperGroupId = chrOperGroupId;
				m_chrOperId = chrOperId;
                m_charFireStatus = chrFireState;
                m_bPlanUnload = bPlanUnLoad;


                // Fire Station
                if (m_charFireStatus == 'F')
                {
					m_bruBackColor = m_bruFire;
					chrFireState = 'F';
                    m_txtObject.Text = "F";
                    return;
                }

                // Water Station
                if (m_charFireStatus == 'W')
                {
					m_bruBackColor = m_bruFire;
					chrFireState = 'W';
                    return;
                }

                // No Input  Station
                if (chrState == 'X')
                {
                    m_bruBackColor = m_bruBadRack;
                    m_txtObject.Text = "X";
                    return;
                }

				// Loading
				if (chrState == '1')
				{
					m_bruBackColor = m_bruLoading;
					return;
				}

				// Unloading
				if (chrState == '2')
				{
					m_bruBackColor = m_bruUnloading;
					return;
				}

                // Trouble
				if (chrState == 'T')
				{
					m_bruBackColor = m_bruTrouble;
					return;
				} 

				// Duplication
                if (chrState == 'D')
				{
					m_bruBackColor = m_bruDuplication;
					return;
				}

                // Duplication
                if (chrState == 'B')
                {
                    m_bruBackColor = m_bruBadRack;
                    return;
                }
				
                // PlanUnLoad
                if (bPlanUnLoad == true)
                {
                    m_bruBackColor = m_bruPlanOutput;
                    return;
                }

                switch (chrState)
                {
                    // BadRack
                    //case 'B':
                    //    m_bruBackColor = m_bruBadRack;
                    //    break;

                    // Reserve
                    case 'R':
                        m_bruBackColor = m_bruInput;
                        break;

                    // Unload Request
                    case 'U':
                        m_bruBackColor = m_bruOutput;
                        break;

                    //// Trouble
                    //case 'T':
                    //    m_bruBackColor = m_bruTrouble; //m_bruTrouble;
                    //    break;

                    //// Duplication
                    //case 'D':
                    //    m_bruBackColor = m_bruDuplication;
                    //    break;

					// Empty Be Release
					case 'N':
						m_bruBackColor = m_bruEmptyBeRelease;
						break;

                    // Empty
                    case 'E':
                        m_bruBackColor = m_bruEmpty;
                        break;

                    default:
                        // HT Aging
                        if (chrOperGroupId == '3')
                        {
                            m_bruBackColor = m_bruHtAging;
                            //m_chrStatus = 'H';
                        }
                        // RT Aging
                        else if (chrOperGroupId == '1')
                        {
                            switch (chrOperId)
                            {
                                // 상온 1차 Aging
                                case '1':
                                    m_bruBackColor = m_bruRtAging1;
                                    break;
                                // 상온 2차 Aging
                                case '2':
                                    m_bruBackColor = m_bruRtAging2;
                                    break;
                                // 상온 3차 Aging
                                case '3':
                                    m_bruBackColor = m_bruRtAging3;
                                    break;
                                // 상온 4차 Aging
                                case '4':
                                    m_bruBackColor = m_bruRtAging4;
                                    break;
                                // 상온 5차 Aging
                                case '5':
                                    m_bruBackColor = m_bruRtAging5;
                                    m_bruForeColor = Brushes.White;
                                    break;

                                // Shipping Aging
                                case '9':
                                    m_bruBackColor = m_bruShipRtAging;
                                    break;
                            }
                        }
                        else
                            // Default
                            m_bruBackColor = m_bruEmpty;
                        break;
                }
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
