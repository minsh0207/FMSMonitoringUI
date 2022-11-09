/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: Constants
//  Create Data		: 2015.08.18
//  Author			: 석보원
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [USing]
using System.Runtime.InteropServices;
#endregion

#region [NameSpace]
namespace MonitoringUI.Common
{
    #region [Main Delegate]
    // Mian Title Button Delegate
    public delegate void MainMonitoringCommandEventhandler();
    #endregion

	// System Time
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short Year;
        public short Month;
        public short DayOfWeek;
        public short Day;
        public short Hour;
        public short Minute;
        public short Second;
        public short Milliseconds;
    }



	// File time
	public enum enFileTimeMode
	{
		CreationTime,
		LastWriteTime,
		LastAccessTime
	}

    // Login Language
    public enum enLoginLanguage
    {
        Korean = 0,
        Chinese = 1,
        English = 2
    }

    // Spread Skin
    public enum enSpreadSkin
    {
        Default,
        Classic,
        ArcticSea,
        Grayscale,
        Metallic,
        Midnight,
        Newspaper,
        Pastel,
        Rose,
        Sandstorm,
        Seashell,
        Shamrock,
        Sunburst
    }

    // Spread Column Type
    public enum enSpreadColumnType
    {
        BarCode,
        Button,
        CheckBox,
        ColorPicker,
        ComboBox,
        Currency,
        DateTime,
        General,
        HyperLink,
        Image,
        Label,
        ListBox,
        Mask,
        MultiColumnComboBox,
        MultiOption,
        Number,
        Percent,
        Progress,
        RegularExpression,
        RichText,
        Slider,
        Text
    }

    // Route Type
    public enum enRouteType
    {
        Production_Route,
        Rework_Route,
        Study_Route,
        Test_Route,
        Manual_Route,
        Calibration_Route,
        Cleaner_Route
    }

    // Meas Type
    public enum enMeasType
    {
        Voltage,               //V,
        Current,               //I,
        End_Current,           //I,
        Capacity,              //C,
        Avg_Voltage,
        Start_Voltage,
        End_Voltage,           //E,
        Electric_Energy,       //W,
        IR,                    //R,
        OCV,                   //O,
		ΔOCV,                 //K,
        ΔAVG,                 //T
        ΔMED,                 //M
        ΔIRAVG,               //G
        ΔIR,                  //G
        ΔK



        //20190417 KJY - Degas
        ,
        DegasChamberNo,
        DegasChamberPos,
        DegasFinalVacuum,
        FinalWeight,
        RollingPos,
        Rolling1_Pressure,
        Rolling2_Pressure,
        FinalSealingPressure,
        FinalSealingTempUpper,
        FinalSealingTempLower,
        FinalSealingPos,
        Dimension1,
        Dimension2,
        Dimension3,
        Dimension4,
        Dimension5,
        Dimension6,
        Dimension7,
        Dimension8,
        Dimension9,
        Dimension10,
        Dimension11,
        Dimension12,
        Dimension13,
        Dimension14,
        Dimension15,
        HipotVolt,
        HipotTime,
        HipotResistant,
        HipotPos,
        CellThicknessPressure,
        CellThicknessPos,
        CellThicknessDataCH1,
        CellThicknessDataCH2,
        CellThicknessDataCH3,
        CellThicknessDataCH4,
        CellThicknessDataCH5,
        FilledWeight,
        PostFillWeight,
        LossWeight,
        RetentionWeight,
        CalcConstant,

        //20190709 KJY Degas 항목 추가
        CellThicknessDataAVG,

        // Assembly
        AForeFillWeight,
        AFilledWeight,
        APostFillWeight

    }

    //public enum enMeasTypeDeltaV
    //{
    //    Voltage,
    //    Current,
    //    Capacity,
    //    Electric_Energy,
    //    Impedance,
    //    OCV,
    //    ΔOCV,
    //    ΔAVG,
    //    ΔMED
    //}

    //// Process ID
    //public enum enProcessID
    //{       
    //    Charge_1 = 111,
    //    Charge_2 = 112,
    //    Charge_3 = 113,
    //    Charge_4 = 114,
    //    Shipping_Charge = 119,
    //    Discharge = 121,
    //    Shipping_Discharge = 129,
    //    Form_OCV_1 = 131,
    //    Form_OCV_2 = 132,
    //    Form_OCV_3 = 133,
    //    Form_OCV_4 = 134,
    //    Form_OCV_5 = 135,
    //    Form_OCV_6 = 136,

    //    RT_Aging_1 = 311,
    //    RT_Aging_2 = 312,
    //    RT_Aging_3 = 313,
    //    RT_Aging_4 = 314,
    //    RT_Aging_5 = 315,

    //    Shipping_RT_Aging = 319,
    //    HT_Aging = 331,
    //    OCV_1 = 511,
    //    OCV_2 = 512,
    //    OCV_3 = 513,

    //    Shipping_OCV = 519,
    //    Selector = 611,
    //    IR_OCV = 711,
    //    Grading = 811,

    //    //Rework C
    //    Charge_A = 1110, //11A
    //    Charge_B = 1111, //11B
    //    Charge_C = 1112, //11C
    //    Charge_D = 1113, //11D
    //    Discharge_A = 1210, //12A
    //    Discharge_B = 1211, //12B
    //    Discharge_C = 1212, //12C
    //    Discharge_D = 1213, //12D
    //}

    // Recipe Mode
    public enum enRecipeChildeMode
    {
        For_Charge,
        For_Discharge,
        For_OCV,
        For_DCImpedance,
        IROCV,
        DCIR,
        HPC_Charge,
        HPC_Discharge,
        HPC_OCV,
        HPC_DCImpedance,
        SaveTime,   //Aging
        //아래는 사용안함
        OCV,
        
        WaitTime,
        MeasRange,
        Calibration,
        Cleaner,
        Null
    }

    // Cell Meas Type
    //Impedance -> IR 명칭 변경된..DB Column
    public enum enCellMeasType
    {
        Capacity = 0,
        End_Voltage = 1,
        End_Current = 2,
        Electric_Energy = 3,
        OCV = 4,
        IR = 5
    }

    // Cell Meas Type Code
    public enum enCellMeasTypeCode
    {
        V,
        I,
        C,
        E,
        W,
        R,
        O,
        K,
        T
    }

    // Cell Info Type
    public enum enCellInfoType
    {
        Measuers = 0,
        Grading = 1
    }

    // FormationDataType
    public enum enFormationDataType
    { 
        TRAY_ID = 0, 
        LOT_ID = 1, 
        START_TIME = 2, 
        ESTD_END_TIME = 3, 
        BOX_TEMP = 4,
        BOX_MODEL_ID = 5,
        BOX_ROUTE_ID = 6
    }

	// MessageQueue Format Type
	public enum enMsmqType
	{
		ActiveXMessageFormatter = 0,
		XmlMessageFormatter = 1,
		BinaryMessageFormatter = 2
	}

	// Log level
	public enum enLogLevel
	{
		DEBUG = 0,
		LOG = 1,
		SEARCH = 2,
		ADD = 3,
		SAVE = 4,
		DELETE = 5,
		UPDATE = 6,
		ERROR = 7
	}

    public enum enDBTable
    {
        MST_PROD_MODEL,
        MST_OPERATION,
        MST_EQP_GROUP,
        MST_EQUIPMENT,
        MST_AGING_RACK,
        MST_AGING_RACK_SPEC,
        MST_ROUTE_OPER,
        MST_ROUTE_DEF,
        MST_ROUTE_FROM_PROSTEP,
        MST_USER,
        MST_TROUBLE,
        MST_RECIPE,
        MST_RECIPE_COMMON,
        MST_CELL_GRADE_TEMP,
        MST_WINDOW,
        MST_WINDOW_USER,
        MST_EQUIPMENT_CH,

        //20210204 KJY
        MST_CELL_TYPE,

        // for 등급
        //tMstCellGradeDef
        MST_CELL_GRADE_DEF,
        //tMstEQPGradeDef
        MST_EQP_GRADE_DEF,
        //
        MST_CELL_GRADE,

        TRAY_CURR,
        TRAY_PRO_STEP,
        LOT_INFO,
        CELL_CURR,
        CELL_PRO_DATA,         
        CELL_PRO_DEGAS,        
        CELL_PRO_STEP,

        CELL_PRO_CHG,
        CELL_PRO_OCV,
        CELL_PRO_IR,
        CELL_PRO_DCIR,

        USER_EVENT,
        EQP_STATUS,
        TROUBLE_EVENT_TM,
        TROUBLE_PIN,
        UNIT_TEMP,
        UNIT_TEMP_HPC,
        LOG_INFO,
        JSON_CELL_PRO_CHG,
        WIN_PROC_CHANGE,
        WIN_TRAY_INFO,
        WIN_TRAY_MANUAL_EQP_CHK,
        WIN_EQP_STATUS,
        RETURN_STRING,
        CTRL_TROUBLE_INFO,
        CTRL_TROUBLE_ANALYSIS,
        CTRL_FIRE_RECORD,
        CTRL_TROUBLE_INPUT,
        CTRL_LOG_INFO,
        CTRL_TEMPERATURE,
        CTRL_TEMPERATURE_HPC,
        CTRL_AGING_MARGINAL,
        CTRL_PROC_MONI,
        CTRL_LOT_MONI, 
        CTRL_GRIPPER,
        CTRL_EQP_REPAIR,
        CTRL_EQP_STATUS_REPORT,
        ROUTE_OPER,
        ROUTE_OPER_STEP,
        GROUPBY_LOT_INFO,
        GROUPBY_EQP_STATE,
        GROUPBY_ROUTE_OPER,
        GROUPBY_LOT,
        GROUPBY_AGING_CNT,
        GROUPBY_TRAY_CURR_CNT,
        GROUPBY_TRAY_PRO_STEP_CNT,
        GROUPBY_TRAY_PRO_STEP_MONI_CNT,
        GROUPBY_CELL_PRO_STEP_JUDGE_CNT,
        GROUPBY_CELL_PRO_STEP_DAILY_CNT,
        GROUPBY_CELL_PRO_STEP_CNT,

        //Grid Route 동적 생성
        GRID_CELL_PRO_STEP_DATA,
        UNIT_STATE,

        // Tray별로 공정을 탔었던 것을 모두 검색하기 위해 
        TRAYCURR_PROC,
        // 공정ID를 가지고 진행완료한 Tray를 검색하기 위해 
        TRAYCURR_PROCID,


        //여기부터 히스토리 지정
        HIST_DB_TRAY_CURR = 200,
        HIST_DB_TRAY_PRO_STEP,
        HIST_DB_TRAY_JUDGE,
        HIST_DB_CELL_CURR,
        HIST_DB_CELL_PRO_STEP,
        HIST_DB_CELL_PRO_DATA,
        HIST_DB_CELL_PRO_DEGAS,

        HIST_DB_CELL_PRO_CHG,
        HIST_DB_CELL_PRO_OCV,
        HIST_DB_CELL_PRO_IR,
        HIST_DB_CELL_PRO_DCIR,

        //Query
        HIST_DB_WIN_TRAY_INFO,
        HIST_DB_TRAY_CELL_HIST,
        //GroupBy
        HIST_DB_GROUPBY_LOT,
        HIST_DB_GROUPBY_TRAY_PRO_STEP_CNT,
        HIST_DB_GROUPBY_TRAY_PRO_STEP_MONI_CNT,
        HIST_DB_GROUPBY_CELL_PRO_STEP_CNT,
        HIST_DB_GROUPBY_CELL_PRO_STEP_JUDGE_CNT,
        HIST_DB_GRID_CELL_PRO_STEP_DATA,
        HIST_DB_GROUPBY_CELL_PRO_STEP_DAILY_CNT

        , HIST_DB_ROUTE_FROM_PROSTEP

        // 20190601 KJY
        , HIST_TRAYCURR_PROC
        // 20190613 KJY - hist의 Lot ID를 가져오기 위해
        , HIST_LOT_ID


    }

    public enum enDBSp
    {
        spUserWondowAuth,
        spMstUserWondowAuth
    }
    public enum enDBStoredProcedure
    {
        MOVE_CURR_TO_HIST
    }

    public enum enDBMsgState
    {
        TRUE,
        CANCEL,
        ERROR,
        INSERT_ERROR,
        UPDATE_ERROR,
        DELETE_ERROR,
        RESULT // UPDATA 까지 이상없이 진행된 경우.
    }

    #region [en Table Where]
    public enum enTableWhere
    {
        WHERE,
        AND,
        OR
    }
    #endregion

    #region [en Table Where]
    public enum enRestFilter
    {
        S, //-	Single
        M, //-	Multi 
        A  //-  ADD
    }
    #endregion

    #region [en Table Where]
    public enum enTableWhereState
    {
        EQUALS,
        DIFF,
        LIKE,
        RLIKE,
        LLIKE,
        GREATER_EQUALS,
        LESS_EQUALS,
        GREATER,
        LESS,
        IN,
        BT,
        BT_AND,
        IS_NULL,
        IS_NOT_NULL
    }
    #endregion

    #region [Class CUserControlList]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CUserControlList
    //===================================================================
    public class CUserControlList
    {
        public int
            //Extension
            nExtensionMonitor,

            //Monitoring
            nTotalWindow,
            nTotalExtWindow,
            nHTAgingWindow,
            nAgingWindow,
            nAgingMainWindow,
            nAgingExtWindow,
            nFormationWindow,
            nFormationExtWindow,

            //Managerment
            nRouteInputWindow,
            nRecipeWindow,
            nRecipeCalibrationWindow,
            nGradeJudgeTotalWindow,
            nTempCompensationWindow,
            nProdcutionModelWindow,
            nTroubleInputWindow,
            nUserManagementWindow,
            nWindow,

            //Report
            nProcProductionStateWindow,
            nTrayHistoryInfoWindow,
            nCellHistoryInfoWindow,
            nCellHistoryInfoNewWindow,
            nTrayCellHistoryInfoWindow,
            nProcProcductionResultWindow,
            nTrayProductionResultWindow,
            nDayProcductionResultWindow,
            nJudgeResultDataWindow,
            nTroubleInfoWindow,
            nEqpStatusInfoWindow,
            nTemperatureWindow,
            nFireRecordWindow,
            nPinTroubleWindow,
            nLogInfoWindow;

        public CUserControlList()
        {
            InitData();
        }

        public void InitData()
        {
            //Extension
            nExtensionMonitor = 0;

            //Monitoring
            nAgingWindow = 0;
            nFormationWindow = 0;

			//Managerment
			nRouteInputWindow = 0;
			nRecipeWindow = 0;
            nRecipeCalibrationWindow = 0;
            nGradeJudgeTotalWindow = 0;
			nTempCompensationWindow = 0;
			nProdcutionModelWindow = 0;
			nTroubleInputWindow = 0;

			//Report
			nProcProductionStateWindow = 0;
			nTrayHistoryInfoWindow = 0;
			nCellHistoryInfoWindow = 0;
            nCellHistoryInfoNewWindow = 0;
            nProcProcductionResultWindow = 0;
			nTrayProductionResultWindow = 0;
			nDayProcductionResultWindow = 0;
			nJudgeResultDataWindow = 0;
			nTroubleInfoWindow = 0;
            nEqpStatusInfoWindow = 0;
            nTemperatureWindow = 0;
			nFireRecordWindow = 0;
			nPinTroubleWindow = 0;

            //System
            nUserManagementWindow = 0;
        }
    }
    #endregion

    #region [Class Trouble Equipment List]
    /////////////////////////////////////////////////////////////////////
    //	Class Trouble Equipment List
    //===================================================================
	public class CTroubleEquipmentList
	{
		public string strEqpTypeID;
		public string strUnitID;
		public string strUnitName;
		public string strContent;
		public string strStatus;
        public string strTroubleCode;
        public bool bStatus;
		public bool bStatusPrev;
        public int nAlarmCnt;
		public CTroubleEquipmentList()
        {
            InitData();
        }

        public void InitData()
        {
			strEqpTypeID = "";
			strUnitID = "";
			strUnitName = "";
			strContent = "";
			strStatus = "";
            strTroubleCode = "";
            bStatus = false;
			bStatusPrev = false;
            nAlarmCnt = 0;
        }
	}
    #endregion

    #region [Log Type]
    public enum enLogType
    {
        Request,
        Response,
        Biz,
        DBQuery,
        DBResult
    }
    #endregion

    #region [동적 Hader 설정, Start Col 은 계산.]
    public class GridHeader
    {
        public int ColEnd { get; set; }
        public int RowStart { get; set; }
        public int RowEnd { get; set; }
        public string Title { get; set; }
        public string DataPropertyName { get; set; }
    }
    #endregion

}
#endregion