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
//	Namespace:  FormationMonCtrl
//===================================================================
namespace FormationMonCtrl
{
	#region [Class CDefine]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CDefine
	//===================================================================
	public class CDefineCtrl
	{
		/////////////////////////////////////////////////////////////////////
		//	EqpTypeID
		//=================================================================== 
		public const char DEF_EQP_TYPE_ID_FORMATION = '1';
		public const char DEF_EQP_TYPE_ID_FORMATION_STACKER = '2';
		public const char DEF_EQP_TYPE_ID_AGING = '3';
		public const char DEF_EQP_TYPE_ID_AGING_STACKER = '4';
		public const char DEF_EQP_TYPE_ID_OCV = '5';
		public const char DEF_EQP_TYPE_ID_SELECTOR = '6';
		public const char DEF_EQP_TYPE_ID_IROCV = '7';
		public const char DEF_EQP_TYPE_ID_GRADER = '8';
		public const char DEF_EQP_TYPE_ID_BARCODE = 'B';
		public const char DEF_EQP_TYPE_ID_SENSOR = 'S';
		public const char DEF_EQP_TYPE_ID_FIRE = 'F';

        //추가
        public const char DEF_EQP_TYPE_STACKERCRANE = 'K';
        public const char DEF_EQP_TYPE_TRAYCLEANER = 'C';


        /////////////////////////////////////////////////////////////////////
        //	Define UNIT ID
        //===================================================================
        public const string DEF_UNITID_BCR_35 = "B60035";		// Assembly Input BCR-35
		public const string DEF_UNITID_BCR_29 = "B60029";		// 상온 BCR29
		public const string DEF_UNITID_BCR_25 = "B60025";		// 상온 BCR25
		public const string DEF_UNITID_BCR_07 = "B60007";		// 상온 BCR1
		public const string DEF_UNITID_BCR_04 = "B60004";		// 상온 BCR2
		public const string DEF_UNITID_BCR_02 = "B60002";		// 고온 BCR1

		public const string DEF_UNITID_BCR_10 = "B10010";		// Formation-2 BCR-10
		public const string DEF_UNITID_BCR_11 = "B10011";		// Formation-2 BCR-11
		public const string DEF_UNITID_BCR_13 = "B10013";		// Formation-1 BCR-13
		public const string DEF_UNITID_BCR_14 = "B10014";		// Formation-1 BCR-14
		public const string DEF_UNITID_BCR_34 = "B10034";		// Formation-3 BCR-34

		public const string DEF_SENSORID_HT_AGING_1_IN = "S30207";		// 고온 Aging 입고 위치
		public const string DEF_SENSORID_HT_AGING_1_IN_BUF = "S30206";		// 고온 Aging 입고 위치 전 Buffer
		public const string DEF_SENSORID_HT_AGING_1_OUT = "S30220";		// 고온 Aging 출고 위치
		public const string DEF_SENSORID_RT_AGING_1_OUT = "S30340";		// 상온 Aging #1 출고 위치
		public const string DEF_SENSORID_RT_AGING_2_OUT = "S30440";		// 상온 Aging #2 출고 위치
		public const string DEF_SENSORID_RT_AGING_3_OUT = "S30940";		// 상온 Aging #3 출고 위치
		public const string DEF_SENSORID_RT_AGING_4_OUT = "S31040";		// 상온 Aging #4 출고 위치

		public const string DEF_SENSORID_FORM_1_IN_F1 = "S90712";		// Formation #1 입고 위치 센서 F1
		public const string DEF_SENSORID_FORM_1_IN_F2 = "S90711";		// Formation #1 입고 위치 센서 F2
		public const string DEF_SENSORID_FORM_1_OUT_F1 = "S10720";		// Formation #1 출고 위치 센서 F1
		public const string DEF_SENSORID_FORM_1_OUT_F2 = "S10721";		// Formation #1 출고 위치 센서 F2	

		public const string DEF_SENSORID_FORM_2_IN_F1 = "S90612";		// Formation #2 입고 위치 센서 F1
		public const string DEF_SENSORID_FORM_2_IN_F2 = "S90611";		// Formation #2 입고 위치 센서 F2	
		public const string DEF_SENSORID_FORM_2_OUT_F1 = "S10620";		// Formation #2 출고 위치 센서 F1
		public const string DEF_SENSORID_FORM_2_OUT_F2 = "S10621";		// Formation #2 출고 위치 센서 F2

		public const string DEF_SENSORID_FORM_3_IN_F1 = "S91212";		// Formation #3 입고 위치 센서 F1
		public const string DEF_SENSORID_FORM_3_IN_F2 = "S91211";		// Formation #3 입고 위치 센서 F2	
		public const string DEF_SENSORID_FORM_3_OUT_F1 = "S11220";		// Formation #3 출고 위치 센서 F1
		public const string DEF_SENSORID_FORM_3_OUT_F2 = "S11221";		// Formation #3 출고 위치 센서 F2	


		public const string DEF_UNITID_SENSOR_866 = "S90866";		// Sensor 866
	}
	#endregion
}
