/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CBoxObject
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
    #region [Class CBoxObject]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CBoxObject
    //===================================================================
    public class CBoxObject
    {
        #region [Variable]
		public string m_strTrayId;
		public char m_chrUnitStatus;
		public char m_chrProcStatus;
		public char m_chrFireStatus;
		public char m_chrComStatus;
		public char m_chrOperMode;
        public char m_chrOperGroupId;
        public char m_chrOperId;
        public string m_strStateText;
        public Brush m_bruBackColor;
        public Brush m_bruForeColor;
        public Border m_borBoxObject;
        public TextBlock m_txtObject;
        //Display 영역도 이제는 포함. 20181203 KJY
        // TrayID, LotID, StartTime, BoxTemperature
        public Border m_borDisplayObject;
        public Brush m_bruDisplayBackColor;
        public Brush m_bruDisplayForeColor;
        public TextBlock m_txtDisplayInfo;
        public string m_strLotID;
        public string m_strStartTime;
        public string m_strBoxTemperature;
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
        public CBoxObject()
        {
			m_strTrayId = "No Tray";
            m_chrOperGroupId = ' ';
			m_chrUnitStatus = ' ';
			m_chrFireStatus = ' ';
			m_chrProcStatus = ' ';
			m_chrComStatus = ' ';
			m_chrOperMode = ' ';
            m_chrOperId = ' ';
            m_strStateText = "";
            //m_bruBackColor = Brushes.Gray;
            //m_bruForeColor = Brushes.Black;
            m_bruBackColor = Brushes.Gray;
            m_bruForeColor = Brushes.Black;

            //Display 영역도 이제는 포함. 20181203 KJY
            // TrayID, LotID, StartTime, BoxTemperature
            m_strLotID = "";
            m_strStartTime = "";
            m_strBoxTemperature = "";
        }
        #endregion

        #region [Method]
        #region [Set Data]
        /////////////////////////////////////////////////////////////////////
        //	Set Data
        //===================================================================
        public void SetData(string strTrayId, char chrUnitStatus, char chrProcStatus, char chrFireStatus, char chrComStatus, char chrOperMode, char chrOperGroupId, char chrOperId, bool bEqpUseFlag, char chrCanInputBox)
        {
            try
            {
                this.m_strTrayId = strTrayId;
                this.m_chrUnitStatus = chrUnitStatus;
                this.m_chrProcStatus = chrProcStatus;
                this.m_chrFireStatus = chrFireStatus;
                this.m_chrComStatus = chrComStatus;
                this.m_chrOperMode = chrOperMode;
                this.m_chrOperGroupId = chrOperGroupId;
                this.m_chrOperId = chrOperId;

                m_strStateText = " ";
                m_bruBackColor = Brushes.White;
                m_bruForeColor = Brushes.Black;

                // ComStatus :: Offline
                if (m_chrComStatus == 'F')
                {
                    m_strStateText = "OFF";
                    m_bruBackColor = Brushes.Black;
                    m_bruForeColor = Brushes.White;
                    return;
                }

                // Fire Status
                if (m_chrFireStatus == 'F' || m_chrFireStatus == 'W')
                {
                    m_strStateText = m_chrFireStatus.ToString();
                    //m_bruBackColor = Brushes.Red;
                    m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                    m_bruForeColor = Brushes.White;
                    return;
                }


                // OperMode :: 수동 운전
                if (m_chrOperMode == 'M')
                {
                    m_strStateText = "M";
                    //m_bruBackColor = Brushes.Orange;
                    m_bruBackColor = new SolidColorBrush(Color.FromRgb(197, 135, 21));
                    m_bruForeColor = Brushes.Black;
                    return;
                }

                // OperMode :: 자동 운전
                if (m_chrOperMode == 'C' || m_chrOperMode == 'A' || m_chrOperMode == 'L')     
                {
                    if (m_chrUnitStatus == 'R' && m_chrProcStatus == 'R')    //UnitStatus :: Run, ProcessStatus :: 가동중     
                    {
                        switch (chrOperGroupId)
                        {
                            case '1':   // Charging
				            	m_strStateText = m_chrOperId.ToString();
                                //m_bruBackColor = Brushes.Green;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(0, 128, 1));
                                m_bruForeColor = Brushes.Black;
				            	break;
                            case '2':   // discharging
								m_strStateText = "D" + m_chrOperId.ToString();
                                //m_bruBackColor = Brushes.DarkKhaki;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(155, 145, 32));
                                m_bruForeColor = Brushes.Black;
				            	break;
                            case '3':   // OCV
				            	m_strStateText = "O";
                                //m_bruBackColor = Brushes.Cyan;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(7, 153, 153));
                                m_bruForeColor = Brushes.Black;
				            	break;
							case '4':   // DC Impedance
								m_strStateText = "I" + m_chrOperId.ToString();
                                //m_bruBackColor = Brushes.DarkOliveGreen;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(86, 107, 48));
                                m_bruForeColor = Brushes.Black;
								break;
                            default:    // Data Error
                                m_strStateText = "E";
                                //m_bruBackColor = Brushes.Red;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                                m_bruForeColor = Brushes.Black;
                                break;
                        }

                        // OperMode :: Calibration
                        if (m_chrOperMode == 'A')
                        {
                            m_strStateText = "A";
                            m_bruBackColor = Brushes.Gold;
                            m_bruForeColor = Brushes.Black;
                            return;
                        }

                        // OperMode :: Cleaner
                        if (m_chrOperMode == 'L')
                        {
                            m_strStateText = "L";
                            m_bruBackColor = Brushes.GreenYellow;
                            m_bruForeColor = Brushes.Black;
                            return;
                        }
                    }
                    else if (m_chrUnitStatus == 'I')                   //UnitStatus :: Idle
                    {
                        switch (m_chrProcStatus)
                        {
                            case 'L':   // Load Requst
                                m_strStateText = "L";
                                //m_bruBackColor = Brushes.Pink;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(161, 130, 198));
                                m_bruForeColor = Brushes.Black;
                                break;
							case '1':   // Loading
								m_strStateText = "L";
                                //m_bruBackColor = Brushes.Salmon;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(199, 49, 208));
                                m_bruForeColor = Brushes.Black;
								break;
							//case 'V':   // 예약
							//    m_strStateText = "V";
							//    m_bruBackColor = Brushes.Brown;
							//    m_bruForeColor = Brushes.White;
							//    break;
							case 'U':   // Unload Requst
                                m_strStateText = "U";
                                //m_bruBackColor = Brushes.Brown;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(96, 62, 138));
                                m_bruForeColor = Brushes.White;
                                break;
							case '2':   // Unloading
								m_strStateText = "U";
                                //m_bruBackColor = Brushes.Chocolate;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(251, 77, 89));
                                m_bruForeColor = Brushes.White;
								break;
                            case 'T':   // Trouble(1)
                                m_strStateText = "";
                                //m_bruBackColor = Brushes.Red;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                                m_bruForeColor = Brushes.White;
                                break;
                            default:    //Idle
                                m_strStateText = "";
                                //m_bruBackColor = Brushes.Yellow;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(208, 209, 7));
                                m_bruForeColor = Brushes.Black;
                                break;
                        }
                        if(m_chrProcStatus == 'L' && chrCanInputBox == 'N')     // Load Request && Box의 기준온도 이상일 경우
                        {
                            //m_bruBackColor = Brushes.Red;
                            m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                        }
                    }
                    else if (m_chrUnitStatus == 'A')  // Abnormal
                    {
                        m_strStateText = "I";
                        //m_bruBackColor = Brushes.Orange;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(208, 209, 7));
                        m_bruForeColor = Brushes.Black;
                    }
                    else if (m_chrUnitStatus == 'S')  //Puse
                    {
                        m_strStateText = "P";
                        //m_bruBackColor = Brushes.LightGray;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(122, 122, 122));
                        m_bruForeColor = Brushes.Black;
                    }
                    else if (m_chrUnitStatus == 'P')  //Power On
                    {
                        m_strStateText = "ON";
                        m_bruBackColor = Brushes.White;
                        m_bruForeColor = Brushes.Black;
                    }
                    else if ( m_chrUnitStatus == 'M' || m_chrUnitStatus == 'N' || m_chrUnitStatus == 'E' || m_chrUnitStatus == 'R')
                    {
                        // 표시 상태 없음
                        m_strStateText = " ";
                        m_bruBackColor = Brushes.White;
                        m_bruForeColor = Brushes.Black;

                        if (m_chrUnitStatus == 'M')
                        {
                            m_strStateText = "M";
                            m_bruBackColor = new SolidColorBrush(Color.FromRgb(197, 135, 21));
                            m_bruForeColor = Brushes.White;
                            return;
                        }

                        // OperMode :: Calibration
                        if (m_chrOperMode == 'A')
                        {
                            m_strStateText = "";
                            m_bruBackColor = Brushes.Gold;
                            m_bruForeColor = Brushes.Black;
                            return;
                        }

                        // OperMode :: Cleaner
                        if (m_chrOperMode == 'L')
                        {
                            m_strStateText = "";
                            m_bruBackColor = Brushes.GreenYellow;
                            m_bruForeColor = Brushes.Black;
                            return;
                        }
                    }
                    else if(m_chrUnitStatus == 'O' )
                    {
                        m_strStateText = "OFF";
                        m_bruBackColor = Brushes.Black;
                        m_bruForeColor = Brushes.White;
                    }
                    else if (m_chrUnitStatus == 'T')  //Trouble(2)
                    {
                        m_strStateText = "";
                        //m_bruBackColor = Brushes.Red;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                        m_bruForeColor = Brushes.White;
                    }
                    else  //Data Err
                    {
                        m_strStateText = "D";
                        //m_bruBackColor = Brushes.Red;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                        m_bruForeColor = Brushes.Black;
                    }
                }


                // 사용 금지
                if (bEqpUseFlag == true)
                {
                    //m_bruBackColor = new SolidColorBrush(Color.FromRgb(254, 86, 24));
                    //m_bruForeColor = Brushes.Black;
                    m_strStateText = "N";
                    m_bruBackColor = Brushes.DarkGray;
                    m_bruForeColor = Brushes.White;
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Set Data Add Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        // LotID, StartTime, BoxTemperature 추가
        // Blush 컬러 update
        public void SetData(string strTrayId, char chrUnitStatus, char chrProcStatus, char chrFireStatus, char chrComStatus, char chrOperMode, char chrOperGroupId, char chrOperId, bool bEqpUseFlag, char chrCanInputBox, string strLotID, string strStartTime, string strBoxTemperature)
        {
            try
            {
                this.m_strTrayId = strTrayId;
                this.m_chrUnitStatus = chrUnitStatus;
                this.m_chrProcStatus = chrProcStatus;
                this.m_chrFireStatus = chrFireStatus;
                this.m_chrComStatus = chrComStatus;
                this.m_chrOperMode = chrOperMode;
                this.m_chrOperGroupId = chrOperGroupId;
                this.m_chrOperId = chrOperId;

                //LotID, StartTime, BoxTemperature 추가
                this.m_strLotID = strLotID;
                this.m_strStartTime = strStartTime;
                this.m_strBoxTemperature = strBoxTemperature;

                m_strStateText = " ";
                m_bruBackColor = Brushes.White;
                m_bruForeColor = Brushes.Black;

                // ComStatus :: Offline
                if (m_chrComStatus == 'F')
                {
                    m_strStateText = "OFF";
                    m_bruBackColor = Brushes.Black;
                    m_bruForeColor = Brushes.White;
                    return;
                }

                // Fire Status
                if (m_chrFireStatus == 'F' || m_chrFireStatus == 'W')
                {
                    m_strStateText = m_chrFireStatus.ToString();
                    //m_bruBackColor = Brushes.Red;
                    m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                    m_bruForeColor = Brushes.White;
                    return;
                }


                // OperMode :: 수동 운전
                if (m_chrOperMode == 'M')
                {
                    m_strStateText = "M";
                    //m_bruBackColor = Brushes.Orange;
                    m_bruBackColor = new SolidColorBrush(Color.FromRgb(197, 135, 21));
                    m_bruForeColor = Brushes.Black;
                    return;
                }

                // OperMode :: 자동 운전
                if (m_chrOperMode == 'C' || m_chrOperMode == 'A' || m_chrOperMode == 'L')
                {
                    if (m_chrUnitStatus == 'R' && m_chrProcStatus == 'R')    //UnitStatus :: Run, ProcessStatus :: 가동중     
                    {
                        switch (chrOperGroupId)
                        {
                            case '1':   // Charging
                                m_strStateText = "C " + m_chrOperId.ToString();
                                //m_bruBackColor = Brushes.Green;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(0, 128, 1));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            case '2':   // discharging
                                m_strStateText = "D " + m_chrOperId.ToString();
                                //m_bruBackColor = Brushes.DarkKhaki;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(155, 145, 32));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            case '3':   // OCV
                                m_strStateText = "O";
                                //m_bruBackColor = Brushes.Cyan;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(7, 153, 153));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            case '4':   // DC Impedance
                                m_strStateText = "I " + m_chrOperId.ToString();
                                //m_bruBackColor = Brushes.DarkOliveGreen;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(86, 107, 48));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            default:    // Data Error
                                m_strStateText = "E";
                                //m_bruBackColor = Brushes.Red;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                        }

                        // OperMode :: Calibration
                        if (m_chrOperMode == 'A')
                        {
                            m_strStateText = "A";
                            m_bruBackColor = Brushes.Gold;
                            //m_bruForeColor = Brushes.Black;
                            m_bruForeColor = Brushes.White;
                            return;
                        }

                        // OperMode :: Cleaner
                        if (m_chrOperMode == 'L')
                        {
                            m_strStateText = "L";
                            m_bruBackColor = Brushes.GreenYellow;
                            //m_bruForeColor = Brushes.Black;
                            m_bruForeColor = Brushes.White;
                            return;
                        }
                    }
                    else if (m_chrUnitStatus == 'I')                   //UnitStatus :: Idle
                    {
                        switch (m_chrProcStatus)
                        {
                            case 'L':   // Load Requst
                                m_strStateText = "L";
                                //m_bruBackColor = Brushes.Pink;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(161, 130, 198));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            case '1':   // Loading
                                m_strStateText = "Loading";
                                //m_bruBackColor = Brushes.Salmon;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(199, 49, 208));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            //case 'V':   // 예약
                            //    m_strStateText = "V";
                            //    m_bruBackColor = Brushes.Brown;
                            //    m_bruForeColor = Brushes.White;
                            //    break;
                            case 'U':   // Unload Requst
                                m_strStateText = "U";
                                //m_bruBackColor = Brushes.Brown;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(96, 62, 138));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            case '2':   // Unloading
                                m_strStateText = "Unloading";
                                //m_bruBackColor = Brushes.Chocolate;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(251, 77, 89));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            case 'T':   // Trouble(1)
                                m_strStateText = "T";
                                //m_bruBackColor = Brushes.Red;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                            default:    //Idle
                                m_strStateText = "";
                                //m_bruBackColor = Brushes.Yellow;
                                m_bruBackColor = new SolidColorBrush(Color.FromRgb(208, 209, 7));
                                //m_bruForeColor = Brushes.Black;
                                m_bruForeColor = Brushes.White;
                                break;
                        }
                        if (m_chrProcStatus == 'L' && chrCanInputBox == 'N')     // Load Request && Box의 기준온도 이상일 경우
                        {
                            //m_bruBackColor = Brushes.Red;
                            m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                        }
                    }
                    else if (m_chrUnitStatus == 'A')  // Abnormal
                    {
                        m_strStateText = "I";
                        //m_bruBackColor = Brushes.Orange;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(208, 209, 7));
                        m_bruForeColor = Brushes.Black;
                    }
                    else if (m_chrUnitStatus == 'S')  //Puse
                    {
                        m_strStateText = "P";
                        //m_bruBackColor = Brushes.LightGray;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(122, 122, 122));
                        m_bruForeColor = Brushes.Black;
                    }
                    else if (m_chrUnitStatus == 'P')  //Power On
                    {
                        m_strStateText = "ON";
                        m_bruBackColor = Brushes.White;
                        m_bruForeColor = Brushes.Black;
                    }
                    else if (m_chrUnitStatus == 'M' || m_chrUnitStatus == 'N' || m_chrUnitStatus == 'E' || m_chrUnitStatus == 'R')
                    {
                        // 표시 상태 없음
                        m_strStateText = " ";
                        m_bruBackColor = Brushes.CornflowerBlue;
                        m_bruForeColor = Brushes.Black;

                        if (m_chrUnitStatus == 'M')
                        {
                            m_strStateText = "M";
                            m_bruBackColor = new SolidColorBrush(Color.FromRgb(197, 135, 21));
                            m_bruForeColor = Brushes.White;
                            return;
                        }

                        // OperMode :: Calibration
                        if (m_chrOperMode == 'A')
                        {
                            m_strStateText = "";
                            m_bruBackColor = Brushes.Gold;
                            m_bruForeColor = Brushes.Black;
                            return;
                        }

                        // OperMode :: Cleaner
                        if (m_chrOperMode == 'L')
                        {
                            m_strStateText = "";
                            m_bruBackColor = Brushes.GreenYellow;
                            m_bruForeColor = Brushes.Black;
                            return;
                        }
                        
                    }
                    else if (m_chrUnitStatus == 'O')
                    {
                        m_strStateText = "OFF";
                        m_bruBackColor = Brushes.Black;
                        m_bruForeColor = Brushes.White;
                    }
                    else if (m_chrUnitStatus == 'T')  //Trouble(2)
                    {
                        m_strStateText = "T";
                        //m_bruBackColor = Brushes.Red;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                        m_bruForeColor = Brushes.White;
                    }
                    
                    else  //Data Err
                    {
                        m_strStateText = "D";
                        //m_bruBackColor = Brushes.Red;
                        m_bruBackColor = new SolidColorBrush(Color.FromRgb(244, 30, 30));
                        m_bruForeColor = Brushes.Black;
                    }
                }

                // 사용 금지
                if (bEqpUseFlag == true)
                {
                    //m_bruBackColor = new SolidColorBrush(Color.FromRgb(254, 86, 24));
                    //m_bruForeColor = Brushes.Black;
                    m_strStateText = "N";
                    m_bruBackColor = Brushes.DarkGray;
                    m_bruForeColor = Brushes.White;
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
