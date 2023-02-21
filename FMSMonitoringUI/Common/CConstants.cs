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

    // Authority Type
    public enum enAuthority
    {
        View,
        Save
    }

    #region Manual Command Type
    public enum enCommnadType
    {
        ConfigurationSave,
        PlanTimeSave,
        DataClearSave
    }
    #endregion    

    // Login Language
    public enum enLoginLanguage
    {
        Korean = 0,
        France = 1,     //fr-FR
        English = 2,
    }

	// Log level
	public enum enLogLevel
	{
		DEBUG = 0,
		LOG,
        Info,
        ButtonClick,
        Search,
		ADD,
		SAVE,
		DELETE,
		UPDATE,
        Send,
        Receive,
		Error
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

    #region CTroubleEquipmentList
    /////////////////////////////////////////////////////////////////////
    //	Class Trouble Equipment List
    //===================================================================
    public class CTroubleEquipmentList
	{
		public int nEqpTypeID;
        public string strEqpID;
        public string strUnitID;
		public string strUnitName;
		public string strContent;
		public string strStatus;
        public string strTroubleCode;
        public string strTroubleCodePrev;
        public bool bStatus;
		public bool bStatusPrev;
        public int nAlarmCnt;

		public CTroubleEquipmentList()
        {
            InitData();
        }

        public void InitData()
        {
            nEqpTypeID = 0;
			strUnitID = "";
			strUnitName = "";
			strContent = "";
			strStatus = "";
            strTroubleCode = "";
            strTroubleCodePrev = "";
            bStatus = false;
			bStatusPrev = false;
            nAlarmCnt = 0;
        }
	}
    #endregion
}
#endregion