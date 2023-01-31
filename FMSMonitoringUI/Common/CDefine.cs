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
        public static int UserClassID 
        {
            get { return Convert.ToInt16(m_strLoginClass); }
        }

        public static string m_strLineID = "001";       // 1공장: "001" / 2공장 "002"
        public static string m_strBizRestURI = @"http://192.168.110.5:9001/";       // 1공장: "001" / 2공장 "002"
        /////////////////////////////////////////////////////////////////////
        //	Enable LogIn (Enable Check is Only Release Ver)
        //=================================================================== 
        public static string m_strUiMon1 = "192.168.10.11";
        public static string m_strUiMon2 = "192.168.10.12";
        public static string m_strUiMon3 = "192.168.10.13";
        public static string m_strUiMon4 = "192.168.10.14";
        public static string m_strUiMon5 = "192.168.10.15";
        public static string m_strUiRew1 = "192.168.10.17";
        public static string m_strUiRew2 = "192.168.10.18";
        public static string m_strUiSer1 = "192.168.10.1";
        public static string m_strUiSer2 = "192.168.10.2";
        public static string m_strUiSch1 = "192.168.10.5";
        public static string m_strUiSch2 = "192.168.10.6";

		public static string m_strOperator = "192.168.10.24";


        /////////////////////////////////////////////////////////////////////
        //	Log Path
        //===================================================================
#if (DEBUG == FALSE)
		public const string DEF_LOG_PATH = @"C:\Formation\LOG\";
#else
        public const string DEF_LOG_PATH = @"C:\Formation\Log\";
#endif
		public const string DEF_EXE_PATH = @"C:\FormationSystem\FormationSystem.exe";
		public const string DEF_VERSION = "Formation System V1";
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
        //	Message Queue Define
        //=================================================================== 
        public const string DEF_MQ_SERVER_IP = "192.168.10.5";
        //public const string DEF_MQ_SERVER_IP = "192.168.10.5";
		//public const string DEF_MQ_SERVER_IP = "192.168.11.1";
		//public const string DEF_MQ_SERVER_IP = "192.168.10.6";
        //public const string DEF_MQ_SERVER_IP = "127.0.0.1";
       
		public const string DEF_MQ_FORMATION_1_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_formation_1_recv";
		public const string DEF_MQ_FORMATION_2_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_formation_2_recv";
		public const string DEF_MQ_FORMATION_3_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_formation_3_recv";
        public const string DEF_MQ_FORMATION_4_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_formation_4_recv";
        public const string DEF_MQ_FORMATION_5_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_formation_5_recv";

        public const string DEF_MQ_OCV_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_1_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_2_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_3_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_4_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_5_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_6_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_7_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_8_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_9_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";
        public const string DEF_MQ_OCV_10_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_ocv_recv";

        public const string DEF_MQ_IROCV_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_irocv_recv";
		public const string DEF_MQ_IROCV_1_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_irocv_recv";
		public const string DEF_MQ_IROCV_2_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_irocv_recv";
        public const string DEF_MQ_IROCV_3_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_irocv_recv";
        public const string DEF_MQ_IROCV_4_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_irocv_recv";
        public const string DEF_MQ_IROCV_5_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_irocv_recv";
        public const string DEF_MQ_IROCV_6_RECV = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_irocv_recv";

        //public const string DEF_MQ_AGING_SEND = @"FormatName:Direct=TCP:" + DEF_MQ_SERVER_IP + @"\Private$\mq_aging_send";

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
        //	EqpTypeID
        //=================================================================== 
        //public const string DEF_EQP_TYPE_ID_ASSEMBLY                = "A";
		public const int DEF_EQP_TYPE_ID_OCV					 = 1;
        public const int DEF_EQP_TYPE_ID_DCIR                    = 2;
        public const int DEF_EQP_TYPE_ID_MICRO_CURRENT           = 3;
        public const int DEF_EQP_TYPE_ID_LEAK_CHECK              = 4;
        public const int DEF_EQP_TYPE_ID_VISION_INSPECTION       = 5;
        public const int DEF_EQP_TYPE_ID_DEGAS                   = 6;
        public const int DEF_EQP_TYPE_ID_NG_SORTER               = 7;
        public const int DEF_EQP_TYPE_ID_HPC                     = 8;
        public const int DEF_EQP_TYPE_ID_FORMATION				 = 9;
		public const int DEF_EQP_TYPE_ID_HT_AGING			     = 10;
        public const int DEF_EQP_TYPE_ID_LT_AGING_01             = 11;
        public const int DEF_EQP_TYPE_ID_LT_AGING_02             = 12;
        public const int DEF_EQP_TYPE_ID_HT_AGING_STACKER        = 13;
        public const int DEF_EQP_TYPE_ID_LT_AGING_01_STACKER     = 14;
        public const int DEF_EQP_TYPE_ID_LT_AGING_02_STACKER     = 15;
        public const int DEF_EQP_TYPE_ID_FORMATION_STACKER		 = 16;
		public const int DEF_EQP_TYPE_ID_PACKING				 = 17;
        public const int DEF_EQP_TYPE_ID_FORMATION_1B_1F         = 18;
        public const int DEF_EQP_TYPE_ID_FORMATION_1B_2F         = 19;
        public const int DEF_EQP_TYPE_ID_FORMATION_1B_3F         = 20;
        public const int DEF_EQP_TYPE_ID_FORMATION_1B_4F         = 21;
        public const int DEF_EQP_TYPE_ID_FORMATION_2B_1F         = 22;
        public const int DEF_EQP_TYPE_ID_FORMATION_2B_2F         = 23;
        public const int DEF_EQP_TYPE_ID_FORMATION_2B_3F         = 24;
        public const int DEF_EQP_TYPE_ID_FORMATION_2B_4F         = 25;
        public const int DEF_EQP_TYPE_ID_FORMATION_3B_1F         = 26;
        public const int DEF_EQP_TYPE_ID_FORMATION_3B_2F         = 27;
        public const int DEF_EQP_TYPE_ID_FORMATION_3B_3F         = 28;
        public const int DEF_EQP_TYPE_ID_HPC_01                  = 29;
        public const int DEF_EQP_TYPE_ID_HPC_02                  = 30;



        /////////////////////////////////////////////////////////////////////
        //	OperGroupID
        //=================================================================== 
        public const string DEF_OPER_GROUP_ID_CHARGE = "1";
        public const string DEF_OPER_GROUP_ID_DISCHARGE = "2";
        public const string DEF_OPER_GROUP_ID_FORMOCV = "3";


        /////////////////////////////////////////////////////////////////////
        //	Status
        //=================================================================== 
        public const string DEF_STATUS_FIRE = "F";
		public const string DEF_STATUS_WATER = "W";
		public const string DEF_STATUS_TROUBLE = "T";


        /////////////////////////////////////////////////////////////////////
        //	Operation Mode
        //=================================================================== 
        public const string DEF_OPER_MODE_CONTROL = "C";
        public const string DEF_OPER_MODE_MANUAL = "M";
        public const string DEF_OPER_MODE_CALIBRATION = "A";
        public const string DEF_OPER_MODE_CLEANER = "L";


        ///////////////////////////////////////////////////////////////////////
        ////	Define UNIT ID
        ////=================================================================== 
        public const string DEF_UNITID_AI_BCR_1 = "B60035";		// Assembly Input   #35
        public const string DEF_UNITID_HT_BCR_1 = "B60005";		// 고온 BCR1		#301
        public const string DEF_UNITID_RT_BCR_1 = "B60006";		// 상온 BCR1		#313
        public const string DEF_UNITID_RT_BCR_2 = "B60010";		// 상온 BCR2		#333
        public const string DEF_UNITID_RT_BCR_3 = "B60013";		// 상온 BCR3		#353

        public const string DEF_UNITID_IN_BCR_1 = "B60001";		// 물류투입		    #901
        public const string DEF_UNITID_HT_BCR_3 = "B60004";		// 고온 투입분기 BCR3	#911
        public const string DEF_UNITID_HT_BCR_4 = "B61005";		// 고온 가상 BCR3	#303V

        //public const string DEF_UNITID_HT_AGING_1_CRANE = "410010";	// 고온 Aging Stacker Crane
        //public const string DEF_UNITID_RT_AGING_1_CRANE = "430010";	// 상온 Aging #1 Stacker Crane
        //public const string DEF_UNITID_RT_AGING_2_CRANE = "450010";	// 상온 Aging #2 Stacker Crane
        //public const string DEF_UNITID_RT_AGING_3_CRANE = "470010";	// 상온 Aging #3 Stacker Crane
        //public const string DEF_UNITID_RT_AGING_4_CRANE = "490010";	// 상온 Aging #4 Stacker Crane

        public const string DEF_UNITID_HT_AGING_1_WATER = "F31990";	// 고온 Aging #1 Water
        public const string DEF_UNITID_RT_AGING_1_WATER = "F33990";	// 상온 Aging #1 Water
        public const string DEF_UNITID_RT_AGING_2_WATER = "F35990";	// 상온 Aging #2 Water
        public const string DEF_UNITID_RT_AGING_3_WATER = "F37990";	// 상온 Aging #3 Water

        public const string DEF_UNITID_HT_AGING_1_WATER_RACKID = "H01W0001";	// 고온 Aging #1 Water
        public const string DEF_UNITID_RT_AGING_1_WATER_RACKID = "R01W0001";	// 상온 Aging #1 Water
        public const string DEF_UNITID_RT_AGING_2_WATER_RACKID = "R02W0001";	// 상온 Aging #2 Water
        public const string DEF_UNITID_RT_AGING_3_WATER_RACKID = "R03W0001";	// 상온 Aging #3 Water

		public const string DEF_UNITID_FORMATION_1_CRANE = "210010";	// Formation #1 Stacker Crane
		public const string DEF_UNITID_FORMATION_1_CRANE_F1 = "210011";	// Formation #1 Stacker Crane Fork-1
		public const string DEF_UNITID_FORMATION_1_CRANE_F2 = "210012";	// Formation #1 Stacker Crane Fork-2
		public const string DEF_UNITID_FORMATION_2_CRANE = "220010";	// Formation #2 Stacker Crane
		public const string DEF_UNITID_FORMATION_2_CRANE_F1 = "220011";	// Formation #2 Stacker Crane Fork-1
		public const string DEF_UNITID_FORMATION_2_CRANE_F2 = "220012";	// Formation #2 Stacker Crane Fork-2
        //public const string DEF_UNITID_FORMATION_3_CRANE = "230010";	// Formation #3 Stacker Crane
        //public const string DEF_UNITID_FORMATION_3_CRANE_F1 = "230011";	// Formation #3 Stacker Crane Fork-1
        //public const string DEF_UNITID_FORMATION_3_CRANE_F2 = "230012";	// Formation #3 Stacker Crane Fork-2
        //public const string DEF_UNITID_FORMATION_4_CRANE = "240010";	// Formation #4 Stacker Crane
        //public const string DEF_UNITID_FORMATION_4_CRANE_F1 = "240011";	// Formation #4 Stacker Crane Fork-1
        //public const string DEF_UNITID_FORMATION_4_CRANE_F2 = "240012";	// Formation #4 Stacker Crane Fork-2

		public const string DEF_UNITID_SENSOR_866 = "S90866";		// Sensor 966


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



        /////////////////////////////////////////////////////////////////////////////
        //	Define Key for Configuration
        // ==========================================================================
        public const string DEF_CFG_API_KEY = "DBRestAPIKey";
        public const string DEF_CFG_AUTH_KEY = "DBRestAuthorization";
        //public const string DEF_DB_API_KEY = "X-DreamFactory-API-Key";
        public const string DEF_DB_API_KEY = "APIKey";
        public const string DEF_DB_AUTH_KEY = "Authorization";
        public const string DEF_DB_CONTENT_TYPE = "application/json";

        public const string DEF_CFG_MAXCELLCNT = "MaxCellCnt";

        /////////////////////////////////////////////////////////////////////////////
        //	HTTP Method
        // ==========================================================================
        public const string HTTP_METHOD_GET = "GET";
        public const string HTTP_METHOD_POST = "POST";
        public const string HTTP_METHOD_PUT = "PUT";
        public const string HTTP_METHOD_PATCH = "PATCH";
        public const string HTTP_METHOD_DELETE = "DELETE";

        /////////////////////////////////////////////////////////////////////////////
        //	Table Define
        // ==========================================================================
        public const string TB_MST_MODEL = "tMstProdModel";
        public const string TB_EQUIPMENT = "tMstEquipment";
        public const string TB_TRAY_CURR = "tTrayCurr";
        public const string TB_TRAY_PROSTEP = "tTrayProStep";
        public const string TB_CELL_GRADEVALUE = "tCellGradeValue";
        public const string TB_CELL_PROCHG = "tCellProChg";
        public const string TB_CELL_PROOCV = "tCellProOcv";
        public const string TB_CELL_PROIMP = "tCellProImp";
        public const string TB_MST_RECIPT = "tMstRecipe";
        public const string TB_MST_ROUTEOPER = "tMstRouteOper";
        public const string TB_MST_TROUBLE = "tMstTrouble";
        public const string TB_TROUBLEEVENT = "tTroubleEventTm";
        public const string TB_EQPSTATUS = "tEqpStatus_";
        public const string TB_UNITTEMP = "tUnitTemp_";
        public const string TB_HIST_CELLPRO = "tHistCellProStep";

        public const string DEF_CFG_TROUBLE_LEVEL_DEFAULT = "A";

        public const string DEF_TRAY_FLAG_F = "F";
        public const string DEF_TRAY_FLAG_D = "D";
        public const string DEF_TRAY_FLAG_E = "E";

        public const string DEF_AUTH_MON = "1";
        public const string DEF_AUTH_OPER = "3";
        public const string DEF_AUTH_MASTER = "5";
        public const string DEF_AUTH_DEV = "9";

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






        //public const string DEF_WINDOW_MON_TEMP_COMPENSATION = "MST-005";                       //CtrlTempCompensation
        //public const string DEF_WINDOW_MON_USER_MANAGEMENT = "MST-006";                         //CtrlUserManagement
        //public const string DEF_WINDOW_MON_WINDOWS = "MST-007";                                 //CtrlWindow
        //public const string DEF_WINDOW_MON_WIN_DEFAULT_ROUTE_INPUT = "MST-008";                 //WinDefaultRouteInput
        //public const string DEF_WINDOW_MON_RECIPE = "MST-009";                                  //CtrlRecipe
        //public const string DEF_WINDOW_MON_RECIPE_DATA = "MST-010";                             //CtrlRecipeData
        //public const string DEF_WINDOW_MON_RECIPE_TIME = "MST-011";                             //CtrlRecipeTime
        //public const string DEF_WINDOW_MON_USER_WINDOW_AUTH = "MST-012";                        //CtrlUserWindowAuth
        //public const string DEF_WINDOW_MON_EQUIPMENT = "MST-013";                               //CtrlEquipment

        ////20201230 KJY - copy RouteID
        //public const string DEF_WINDOW_MST_COPY_ROUTEID = "MST-014";                            //WinCopyRouteID

        ////20210204 KJY - for CellType Mgm
        //public const string DEF_WINDOW_MST_CELL_TYPE = "MST-015";                               //CtrlCellType

        //public const string DEF_WINDOW_MONI_FORMATION = "MON-001";                              //CtrlFormation
        //public const string DEF_WINDOW_MONI_FORMATION_HPC = "MON-002";                          //CtrlFormationHPC
        //public const string DEF_WINDOW_MONI_HP_AGING = "MON-003";                               //CtrlHTAging
        //public const string DEF_WINDOW_MONI_RT_AGING = "MON-004";                               //CtrlRTAging
        //public const string DEF_WINDOW_MONI_TOTAL_MONITORING = "MON-005";                       //CtrlTotalMonitoring
        //public const string DEF_WINDOW_MONI_WIN_AGING_INFO = "MON-006";                         //WinAgingInfo
        //public const string DEF_WINDOW_MONI_WIN_AGING_RACK_SETTING = "MON-007";                 //WinAgingRackSetting
        //public const string DEF_WINDOW_MONI_WIN_EQP_MANUAL_JOB = "MON-008";                     //WinEqpManualJob
        //// WinFormationManualJob 불필요 WinEqpManualJob에서 모두 처리
        ////public const string DEF_WINDOW_MONI_WIN_FORMATION_MANUAL_JOB = "MON-009";               //WinFormationManualJob
        //public const string DEF_WINDOW_MONI_WIN_HP_AGING_FOR_DUAL = "MON-010";                  //WinHTAgingForDual
        //public const string DEF_WINDOW_MONI_WIN_MODEL_CHANGE = "MON-011";                       //WinModelChange
        //public const string DEF_WINDOW_MONI_WIN_TROUBLE_INFO = "MON-012";                       //WinTroubleInfo

        //public const string DEF_WINDOW_MONI_WIN_GRADE_EDIT = "MON-013";                       //WinGradeNameEdit
        //public const string DEF_WINDOW_MONI_WIN_OUT_GRADE_SETTING = "MON-014";                 //WinGradeOutSlotSetting

        //public const string DEF_WINDOW_MON_MODIFY_MAIN_LOOP_TRAFFIC = "MON-015";                //WinMainLoopTraffic
        ////20200611 KJY for AgingRack내 Tray의 RouteID 변경
        //public const string DEF_WINDOW_MON_CHANGE_ROUTEID = "MON-016";                          //WinChangeTrayZone
        ////20201216 KJY for 조립설비로 가는 공트레이 제한
        //public const string DEF_WINDOW_MON_ASM_LIMIT = "MON-017";                          //WinChangeTrayZone

        ////20211111 KJY - 
        //public const string DEF_WINDOW_MONI_WIN_AGING_RACK_OUT_MANAGE = "MON-018";                 //WinAgingRackOutManage

        //public const string DEF_WINDOW_RTP_AGING_MARGINAL = "RTP-001";                          //CtrlAgingMarginal
        //public const string DEF_WINDOW_RTP_CELL_HISTORY_INFO = "RTP-002";                       //CtrlCellHistoryInfo
        //public const string DEF_WINDOW_RTP_DAILY_PROCESS_INFO = "RTP-003";                      //CtrlDailyProcessInfo
        //public const string DEF_WINDOW_RTP_EQP_REPAIR = "RTP-004";                              //CtrlEqpRepair
        //public const string DEF_WINDOW_RTP_EQP_STATUS_INFO = "RTP-005";                         //CtrlEqpStatusInfo
        //public const string DEF_WINDOW_RTP_EQP_STATUS_REPORT = "RTP-006";                       //CtrlEqpStatusReport
        //public const string DEF_WINDOW_RTP_FIRE_RECORD = "RTP-007";                             //CtrlFireRecord
        //public const string DEF_WINDOW_RTP_GRIPPER = "RTP-008";                                 //CtrlGripper
        //public const string DEF_WINDOW_RTP_JUDGE_REPORT= "RTP-009";                             //CtrlJudgeReport
        //public const string DEF_WINDOW_RTP_JUDGE_RESULT_DATA = "RTP-010";                       //CtrlJudgeResultData
        //public const string DEF_WINDOW_RTP_LOG_INFO = "RTP-011";                                //CtrlLogInfo
        //public const string DEF_WINDOW_RTP_LOT_MONITORING = "RTP-012";                          //CtrlLotMonitoring
        //public const string DEF_WINDOW_RTP_PROCESS_MONITORING = "RTP-013";                      //CtrlProcessMonitoring
        //public const string DEF_WINDOW_RTP_TEMPERATURE = "RTP-014";                             //CtrlTemperature
        //public const string DEF_WINDOW_RTP_TEMPERATURE_HPC = "RTP-015";                         //CtrlTemperatureHPC
        //public const string DEF_WINDOW_RTP_TRAY_CELL_HISTORY_INFO = "RTP-016";                  //CtrlTrayCellHistoryInfo
        //public const string DEF_WINDOW_RTP_TRAY_HISTORY_INFO = "RTP-017";                       //CtrlTrayHistoryInfo
        //public const string DEF_WINDOW_RTP_TRAY_PRO_STEP_HIST = "RTP-018";                      //CtrlTrayProStepHist
        //public const string DEF_WINDOW_RTP_TROUBLE_ANALYSIS = "RTP-019";                        //CtrlTroubleAnalysis
        //public const string DEF_WINDOW_RTP_TROUBLE_INFO = "RTP-020";                            //CtrlTroubleInfo
        //public const string DEF_WINDOW_RTP_WIN_CELL_MEASUREMENTS = "RTP-021";                   //WinCellMeasurements
        //public const string DEF_WINDOW_RTP_WIN_EQP_REPAIR = "RTP-022";                          //WinEqpRepair
        //public const string DEF_WINDOW_RTP_WIN_EQP_STATUS_HIS = "RTP-023";                      //WinEqpStatusHis
        //public const string DEF_WINDOW_RTP_WIN_GRADE_JUDGE = "RTP-024";                         //WinGradeJudge
        //public const string DEF_WINDOW_RTP_WIN_MANUAL_OUT_CELL = "RTP-025";                     //WinManualOutCell
        //public const string DEF_WINDOW_RTP_WIN_PROC_CHANGE = "RTP-026";                         //WinProcChange
        //public const string DEF_WINDOW_RTP_WIN_ROUTE_CHANGE = "RTP-027";                        //WinRouteChange
        //public const string DEF_WINDOW_RTP_WIN_TEMPERATURE_CHART = "RTP-028";                   //WinTemperatureChart
        //public const string DEF_WINDOW_RTP_WIN_TRAY_INFO = "RTP-029";                           //WinTrayInfo
        //public const string DEF_WINDOW_RTP_WIN_TRAY_MANUAL = "RTP-030";                         //WinTrayManual
        //public const string DEF_WINDOW_RTP_WIN_TRAY_MANUAL_INFO = "RTP-031";                    //WinTrayManualInfo
        //public const string DEF_WINDOW_RTP_WIN_TROUBLE_INPUT = "RTP-032";
        //public const string DEF_WINDOW_RTP_WIN_TRAY_STATUS_CHANGE = "RTP-033";
        //public const string DEF_WINDOW_RTP_RE_WORK = "RTP-034";
        //public const string DEF_WINDOW_RTP_RE_WORK_CREATE = "RTP-035";
        //public const string DEF_WINDOW_RTP_JUDGE_DAILY_REPORT = "RTP-037";                      //CtrlGradeMonitoring
        //public const string DEF_WINDOW_RTP_INSERT_CELL_DATA = "RTP-038";                        // Cell Data 수동입력

        //// Cell별 ProStep 조회
        //public const string DEF_WINDOW_RTP_CELL_INFO = "RTP-036";

        //// 20200414 KJY for 공트레이 TrayZone변경 Window
        //public const string DEF_WINDOW_RTP_CHANGE_TRAY_ZONE = "RTP-039";


        ///////////////////////////////////////////////////////////////////////////////
        ////	ETC Define
        //// ==========================================================================
        //// Test Route Code
        //public const string DEF_ROUTE_TEST_CODE = "T";

    }
    #endregion
}
