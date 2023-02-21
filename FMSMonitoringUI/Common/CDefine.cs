/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: Define
//  Create Data		: 2015.08.18
//  Author			: 석보원
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//===================================================================


/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationSystem
//===================================================================
using System;

namespace MonitoringUI.Common
{
    #region [Class CDefine]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CDefine
    //===================================================================
    public class CDefine
    {
        /////////////////////////////////////////////////////////////////////
        //	OPCServer List Define
        //=================================================================== 
        public static string CONFIG_FILENAME_OPCUA = @".\Config\OPCUAList.csv";

        /////////////////////////////////////////////////////////////////////
        //	Tag List Define
        //=================================================================== 
        public static string CONFIG_FILENAME_TAG = @"\TAGS_CLIENT_V1.xlsx";

        /////////////////////////////////////////////////////////////////////
        //	LogIn Define
        //=================================================================== 
        public static string m_strLoginID = "";         // Login ID
        public static string m_strLoginPass = "";		// Login Pass
		public static string m_strLoginName = "";       // Login Name
		public static string m_strLoginClass = "";      // Login Class
		public static string m_strLoginIP = "";         // Login IP Address
		public static string m_strSaveLoginID = "";		// Save Login ID
		public static string m_strSaveLoginPass = "";	// Save Login Pass
		public static string m_strSaveLoginName = "";	// Save Login Name
		public static string m_strSaveLoginClass = "";	// Save Login Class
        public static enLoginLanguage m_enLanguage;     // Login Language
        public static string m_strLanguage = "";	    // Login Language
        public static int UserClassID 
        {
            get { return Convert.ToInt16(m_strLoginClass); }
        }

        public static string m_strLineID = "001";       // 1공장: "001" / 2공장 "002"
        public static string m_strBizRestURI = @"http://192.168.110.5:9001/";       // 1공장: "001" / 2공장 "002"

        /////////////////////////////////////////////////////////////////////
        //	Log Path
        //===================================================================
        //#if (DEBUG == FALSE)
        //		public const string DEF_LOG_PATH = @"C:\Formation\LOG\";
        //#else
        //        public const string DEF_LOG_PATH = @"C:\Formation\Log\";
        //#endif
        //		public const string DEF_EXE_PATH = @"C:\FormationSystem\FormationSystem.exe";
        //		public const string DEF_LOG_FILENAME = "FormationUI";

//#if (DEBUG == FALSE)
//		public const string DEF_LOG_PATH = @"C:\Formation\LOG\";
//#else
        public const string DEF_LOG_PATH = @"D:\FMSSystem\Logs\";
//#endif
        public const string DEF_EXE_PATH = @"C:\FormationSystem\FormationSystem.exe";
        public const string DEF_LOG_FILENAME = "FormationUI";

        /////////////////////////////////////////////////////////////////////
        //	Exit Button Size
        //===================================================================
        public const int DEF_EXIT_WIDTH = 170;


        /////////////////////////////////////////////////////////////////////
        //	기타등등
        //===================================================================
        public const int DEF_MAX_TRAYID_LENGTH = 16;
        public const int DEF_MAX_CELL_COUNT = 30;
        public const int DEF_MAX_CELLID_LENGTH = 24;

        /////////////////////////////////////////////////////////////////////
        //	PLC OPCUA Server COUNT
        //=================================================================== 
        public const int DEF_PLC_SERVER_COUNT = 4;


        /////////////////////////////////////////////////////////////////////
        //	Define Count
        //=================================================================== 
        // FORMATION
        public const int DEF_FOR_LINE1BAY_COUNT = 20;
        public const int DEF_FOR_LINE2BAY_COUNT = 20;

        public const int DEF_FOR_BAYBOX_COUNT = 7;

        //
        public const int DEF_SELECTING_RANK_COUNT = 6;
        public const int DEF_GRADING_RANK_COUNT = 10;

        /////////////////////////////////////////////////////////////////////
        //	OperGroupID
        //=================================================================== 
        //public const string DEF_OPER_GROUP_ID_CHARGE = "1";
        //public const string DEF_OPER_GROUP_ID_DISCHARGE = "2";
        //public const string DEF_OPER_GROUP_ID_FORMOCV = "3";


        /////////////////////////////////////////////////////////////////////
        //	Status
        //=================================================================== 
        public const string DEF_STATUS_FIRE = "F";
		public const string DEF_STATUS_WATER = "W";
		public const string DEF_STATUS_TROUBLE = "T";

		/////////////////////////////////////////////////////////////////////
		//	Define Trouble Code
		//=================================================================== 
		public const string DEF_TROUBLE_FORMATION_FIRE = "102";
        public const string DEF_TROUBLE_AGING_FIRE_OFFLINE = "301";
		public const string DEF_TROUBLE_AGING_FIRE = "302";
		public const string DEF_TROUBLE_OCV_FIRE = "861";
        public const string DEF_TROUBLE_ALIVE_FAIL = "902";


        /////////////////////////////////////////////////////////////////////
        //	Formation config value
        //=================================================================== 
        public const string DEF_CONFIG_MULTIPRODUCTIONFLAG = "1";           //다 모델 생산 라인일 경우 '0':단일모델, '1':다 모델

        /////////////////////////////////////////////////////////////////////
        //	Aging Type
        //=================================================================== 
        public const string DEF_AGING_TYPE_RT= "R";           //상온 에이징
        public const string DEF_AGING_TYPE_HT = "H";           //상온 에이징

        // 20180525 KJY - user class별 권한
        public const string DEF_USER_CLASS_AUTH_VIEW = "0";
        public const string DEF_USER_CLASS_AUTH_UPDATE = "1";
        public const string DEF_USER_CLASS_AUTH_ADDDEL = "2";


        public const string DEF_GRIDVIEW_COMBOXID = "ValueID";
        public const string DEF_GRIDVIEW_COMBOXNAME = "ValueName";

        //MON-001 ~ (Monitoring)
        //RTP-001 ~ (Report)
        //MST-001 ~ (Master)
        public const string DEF_MON_CTRL_MONITORING = "MON-001";                    //CtrlMonitoring
        public const string DEF_MON_CTRL_AGING = "MON-002";                         //CtrlAging
        public const string DEF_MON_CTRL_FORMATION_CHG = "MON-003";                 //CtrlFormationCHG
        public const string DEF_MON_CTRL_FORMATION_HPC = "MON-004";                 //CtrlFormationHPC
        public const string DEF_MON_WIN_MANAGE_EQP = "MON-005";                     //WinManageEqp
        public const string DEF_MON_WIN_AGING_RACK_SETTING = "MON-006";             //WinAgingRackSetting
        public const string DEF_MON_WIN_BCR_CONVEYOR_INFO = "MON-007";              //WinBCRConveyorInfo
        public const string DEF_MON_WIN_CONVEYOR_INFO = "MON-008";                  //WinConveyorInfo
        public const string DEF_MON_WIN_CELL_DETAILS = "MON-009";                   //WinCellDetailInfo
        public const string DEF_MON_WIN_CRANE_INFO = "MON-010";                     //WinCraneInfo
        public const string DEF_MON_WIN_FORMATION_BOX = "MON-011";                  //WinFormationBox
        public const string DEF_MON_WIN_FORMATION_HPC = "MON-012";                  //WinFormationHPC
        public const string DEF_MON_WIN_LEAD_TIME = "MON-013";                      //WinLeadTime
        public const string DEF_MON_WIN_RECIPE_INFO = "MON-014";                    //WinRecipeInfo
        public const string DEF_MON_WIN_TRAY_DETAILS = "MON-015";                   //WinTrayDetails
        public const string DEF_MON_WIN_TRAY_INFO = "MON-016";                      //WinTrayInfo
        public const string DEF_MON_WIN_WATER_TANK = "MON-017";                     //WinWaterTank
        public const string DEF_MON_WIN_TROUBLE_INFO = "MON-018";                   //WinTroubleInfo
    }
    #endregion
}
