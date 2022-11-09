/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : 
//  Create Date	    :
//  Author			:
//  Remark			: 
//                      JsonTrayList : TrayCurr, TrayProStep, HistTrayCurr, HistTrayProStep : 동일하게 사용함.
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [Using]
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using MonitoringUI.Common;
#endregion

namespace MonitoringUI
{
    #region Class_for_ModelID
    public class JsonModelIDList
    {
        [JsonProperty("resource")]
        public List<JsonModelID> ModelIDList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonModelID
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("ProdDefaultFlag")]
        public string ProdDefaultFlag { get; set; }
        [JsonProperty("ProdModelDesc")]
        public string ProdModelDesc { get; set; }
                
        [JsonProperty("ProdSizeX")]
        public string ProdSizeX { get; set; }

        [JsonProperty("ProdSizeY")]
        public string ProdSizeY { get; set; }
    }
    #endregion

    //20210204 KJY
    #region Class_for_CellType
    public class JsonCellTypeList
    {
        [JsonProperty("resource")]
        public List<JsonCellType> CellTypeList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonCellType
    {
        [JsonProperty("CellType")]
        public string CellType { get; set; }
        [JsonProperty("DefaultFlag")]
        public string DefaultFlag { get; set; }
        [JsonProperty("Descr")]
        public string Descr { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }
        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
    }
    #endregion

    #region Class_for_LotID
    public class JsonLotIDList
    {
        [JsonProperty("resource")]
        public List<JsonLotID> LotIDList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonLotID
    {
        [JsonProperty("LotID")]
        public string LotID { get; set; }

        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("TrayInCnt")]
        public string TrayInCnt { get; set; }

        [JsonProperty("TrayOutCnt")]
        public string TrayOutCnt { get; set; }
    }
    #endregion

    #region Class_for_Operation
    public class JsonOperIDList
    {
        [JsonProperty("resource")]
        public List<JsonOperID> OperIDList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

        public string this[string strEqptypeID, string strOperGroupID, string strOperID]
        {
            get
            {
                string strOperName = "";
                var varOperList = this.OperIDList.FirstOrDefault(t => t.EqpTypeID == strEqptypeID
                                                              && t.OperGroupID == strOperGroupID
                                                              && t.OperID == strOperID
                                                      );

                if (varOperList == null) return strOperID;

                strOperName = varOperList.OperName;

                if (CDefine.m_enLanguage == enLoginLanguage.Chinese)
                {
                    strOperName = varOperList.OperName_cn;
                }

                return strOperName;
            }
        }
    }

    public class JsonOperID
    {
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("OperName")]
        public string OperName { get; set; }
        [JsonProperty("OperName_cn")]
        public string OperName_cn { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
    }
    #endregion

    #region Class_for_RouteID
    public class JsonRouteIDList
    {
        [JsonProperty("resource")]
        public List<JsonRouteID> RouteDList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonRouteID
    {
        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("RouteType")]
        public string RouteType { get; set; }
        [JsonProperty("DefaultFlag")]
        public string DefaultFlag { get; set; }

        [JsonProperty("RouteName")]
        public string RouteName { get; set; }
        [JsonProperty("TempBalanceFlag")]
        public string TempBalanceFlag { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }
        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
    }
    #endregion

    #region Class_for_Trouble
    public class JsonTroubleList
    {
        [JsonProperty("resource")]
        public List<JsonTrouble> TroubleList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonTrouble
    {
        [JsonProperty("TroubleCode")]
        public int TroubleCode { get; set; }
        [JsonProperty("TroubleName_kr")]
        public string TroubleName_kr { get; set; }
        [JsonProperty("TroubleName_en")]
        public string TroubleName_en { get; set; }
        [JsonProperty("TroubleName_cn")]
        public string TroubleName_cn { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("ErrLevel")]
        public string ErrLevel { get; set; }
        [JsonProperty("UserAction_kr")]
        public string UserAction_kr { get; set; }

        [JsonProperty("UserAction_en")]
        public string UserAction_en { get; set; }
        [JsonProperty("UserAction_cn")]
        public string UserAction_cn { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }
        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
    }
    #endregion

    #region Class_for_Tray
    public class JsonTrayList
    {
        [JsonProperty("resource")]
        public List<JsonTray> TrayList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonTray
    {
        [JsonProperty("PartKey")]
        public string PartKey { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
        [JsonProperty("LotID")]
        public string LotID { get; set; }
        [JsonProperty("CellType")]
        public string CellType { get; set; }
        [JsonProperty("Flag")]
        public string Flag { get; set; }
        [JsonProperty("TrayType")]
        public string TrayType { get; set; }
        [JsonProperty("TrayZone")]
        public string TrayZone { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("TrayInputObjectID")]
        public string TrayInputObjectID { get; set; }
        [JsonProperty("TrayInputLineID")]
        public string TrayInputLineID { get; set; }
        [JsonProperty("TrayInputFlag")]
        public string TrayInputFlag { get; set; }
        [JsonProperty("ManualInputFlag")]
        public string ManualInputFlag { get; set; }
        [JsonProperty("FormInputLineID")]
        public string FormInputLineID { get; set; }
        [JsonProperty("FormInputDate")]
        public string FormInputDate { get; set; }
        [JsonProperty("FormInputTime")]
        public string FormInputTime { get; set; }
        [JsonProperty("FormInputFlag")]
        public string FormInputFlag { get; set; }
        [JsonProperty("FormOperMode")]
        public string FormOperMode { get; set; }
        [JsonProperty("ReworkFlag")]
        public string ReworkFlag { get; set; }
        [JsonProperty("ReworkProc")]
        public string ReworkProc { get; set; }
        [JsonProperty("InputCellCnt")]
        public int? InputCellCnt { get; set; }
        [JsonProperty("ProcInputCellCnt")]
        public int? ProcInputCellCnt { get; set; }
        [JsonProperty("CurrCellCnt")]
        public int? CurrCellCnt { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public string ProcWorkIndex { get; set; }
        [JsonProperty("ProcWorkCnt")]
        public string ProcWorkCnt { get; set; }
        [JsonProperty("StartTime")]
        public string StartTime { get; set; }
        [JsonProperty("EndTime")]
        public string EndTime { get; set; }
        [JsonProperty("StartDate")]
        public string StartDate { get; set; }
        [JsonProperty("EndDate")]
        public string EndDate { get; set; }
        [JsonProperty("BarObjectID")]
        public string BarObjectID { get; set; }
        [JsonProperty("BarReadTime")]
        public string BarReadTime { get; set; }
        [JsonProperty("PlanTime")]
        public string PlanTime { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("NormalFlag")]
        public string NormalFlag { get; set; }
        [JsonProperty("DummyFlag")]
        public string DummyFlag { get; set; }
        [JsonProperty("Priority")]
        public string Priority { get; set; }
        [JsonProperty("ProStepFlag")]
        public string ProStepFlag { get; set; }
        [JsonProperty("TrayGrade")]
        public string TrayGrade { get; set; }
        [JsonProperty("BoxTempStart")]
        public string BoxTempStart { get; set; }
        [JsonProperty("BoxTempEnd")]
        public string BoxTempEnd { get; set; }
        [JsonProperty("BoxPresStart")]
        public string BoxPresStart { get; set; }
        [JsonProperty("BoxPresEnd")]
        public string BoxPresEnd { get; set; }
        [JsonProperty("NextEqpTypeID")]
        public string NextEqpTypeID { get; set; }
        [JsonProperty("NextOperGroupID")]
        public string NextOperGroupID { get; set; }
        [JsonProperty("NextOperID")]
        public string NextOperID { get; set; }
        [JsonProperty("NextObjectID")]
        public string NextObjectID { get; set; }
        [JsonProperty("CurrOperName")]
        public string CurrOperName { get; set; }
        
        [JsonProperty("NextOperName")]
        public string NextOperName { get; set; }

        [JsonProperty("ProcID")]
        public string ProcID { get; set; }

        // 공정순서로 검색하기위해 20190531 KJY
        [JsonProperty("RowNumber")]
        public int RowNumber { get; set; }
    }
    #endregion

    #region Class_for_AgingRack
    public class JsonAgingRackList
    {
        [JsonProperty("resource")]
        public List<JsonAgingRack> AgingRackList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonAgingRack
    {
        [JsonProperty("AgingType")]
        public string AgingType { get; set; }

        [JsonProperty("Hogi")]
        public string Hogi { get; set; }
        [JsonProperty("RackID")]
        public string RackID { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("FireStatus")]
        public string FireStatus { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("PlanTime")]
        public string PlanTime { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }
        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        //20200330 KJY - for DelayTime alarm
        [JsonProperty("DelayTime")]
        public string DelayTime { get; set; }
        [JsonProperty("DelayAlarmFlag")]
        public string DelayAlarmFlag { get; set; }
        [JsonProperty("CurrentDBTime")]
        public string CurrentDBTime { get; set; }

        //20200616 KJY for RouteID변경 예약
        [JsonProperty("ReserveRouteIDChageFlag")]
        public string ReserveRouteIDChageFlag { get; set; }
        [JsonProperty("ReservedRouteID")]
        public string ReservedRouteID { get; set; }
        [JsonProperty("ReservedProcID")]
        public string ReservedProcID { get; set; }

        //20210429 KJY - for Tray-CellType
        [JsonProperty("Celltype")]
        public string CellType { get; set; }

        //20211119 KJY - DummyFlag for IMS-MES API
        [JsonProperty("DummyFlag")]
        public string DummyFlag { get; set; }



    }
    #endregion

    #region Class_for_Aging Rack Spec
    public class JsonAgingReckSpecList
    {
        [JsonProperty("resource")]
        public List<JsonAgingReckSpec> AgingReckSpecList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

        public JsonAgingReckSpec this[string strAgingType, string strHogi]
        {
            get
            {
                return this.AgingReckSpecList.FirstOrDefault(t => t.AgingType == strAgingType && t.Hogi == strHogi);
            }
        }
    }

    public class JsonAgingReckSpec
    {
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("AgingType")]
        public string AgingType { get; set; }
        [JsonProperty("Hogi")]
        public string Hogi { get; set; }
        [JsonProperty("RackCnt")]
        public string RackCnt { get; set; }

        [JsonProperty("Spec")]
        public string Spec { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }

        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }

        [JsonProperty("RackTrayCnt")]
        public int RackTrayCnt { get; set; }
    }
    #endregion

    #region Class_for_Equipment
    public class JsonEqpGroupList
    {
        [JsonProperty("resource")]
        public List<JsonEqpGroup> EqpGroupList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

        public string this[string eqpTypeId]
        {
            get
            {
                //NullReference Exception, Check
                var varEqp = EqpGroupList.FirstOrDefault(t => t.EqpTypeID == eqpTypeId);

                if (varEqp == null)
                {
                    return string.Empty;
                }

                return varEqp.EqpTypeName;
            }
        }
    }

    public class JsonEqpGroup
    {
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }
        [JsonProperty("EqpTimeWriteLog")]
        public string EqpTimeWriteLog { get; set; }
    }
    #endregion

    #region Class_for_Equipment All
    public class JsonEquipmentList
    {
        [JsonProperty("resource")]
        public List<JsonEquipment> EquipmentList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

        public string this[string eqpTypeId, string strUnitID]
        {
            get
            {
                //NullReference Exception, Check
                var varEqp = EquipmentList.FirstOrDefault(t => t.EqpTypeID == eqpTypeId && t.UnitID == strUnitID);

                if (varEqp == null)
                {
                    return string.Empty;
                }

                return varEqp.UnitName;
            }
        }

    }

    public class JsonEquipment
    {
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }
        [JsonProperty("UnitID")]
        public string UnitID { get; set; }
        [JsonProperty("ForComUnitID")]
        public string ForComUnitID { get; set; }
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }

        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
        [JsonProperty("NextOperName")]
        public string NextOperName { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }

        [JsonProperty("InModelID")]
        public string InModelID { get; set; }
        [JsonProperty("InRouteID")]
        public string InRouteID { get; set; }
        [JsonProperty("InProcID")]
        public string InProcID { get; set; }
        [JsonProperty("InCellType")]
        public string InCellType { get; set; }
        [JsonProperty("FormBoxType")]
        public string FormBoxType { get; set; }
        [JsonProperty("FormWorkChannel")]
        public string FormWorkChannel { get; set; }
        [JsonProperty("ScheduleIpAddr")]
        public string ScheduleIpAddr { get; set; }
        [JsonProperty("ComAddress")]
        public string ComAddress { get; set; }
        [JsonProperty("ComPort")]
        public string ComPort { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("ComStatus")]
        public string ComStatus { get; set; }
        [JsonProperty("OperMode")]
        public string OperMode { get; set; }
        [JsonProperty("UnitStatus")]
        public string UnitStatus { get; set; }
        [JsonProperty("ProcessStatus")]
        public string ProcessStatus { get; set; }
        [JsonProperty("PhysicalStatus")]
        public string PhysicalStatus { get; set; }
        [JsonProperty("FormTrouFlag")]
        public string FormTrouFlag { get; set; }
        [JsonProperty("StartEndTime")]
        public string StartEndTime { get; set; }
        [JsonProperty("SingleActFlag")]
        public string SingleActFlag { get; set; }
        [JsonProperty("TransPrio")]
        public string TransPrio { get; set; }
        [JsonProperty("FormEvenOddLane")]
        public string FormEvenOddLane { get; set; }
        [JsonProperty("FormOperGroupID")]
        public string FormOperGroupID { get; set; }
        [JsonProperty("OldTrayID")]
        public string OldTrayID { get; set; }
        [JsonProperty("FinalCmdID")]
        public string FinalCmdID { get; set; }
        [JsonProperty("FinalSeqNo")]
        public string FinalSeqNo { get; set; }
        [JsonProperty("FinalRecipeID")]
        public string FinalRecipeID { get; set; }
        [JsonProperty("TroubleCode")]
        public string TroubleCode { get; set; }
        [JsonProperty("FireStatus")]
        public string FireStatus { get; set; }
        [JsonProperty("FireEventTime")]
        public string FireEventTime { get; set; }
        [JsonProperty("EqpUseFlag")]
        public string EqpUseFlag { get; set; }
        [JsonProperty("TrayCnt")]
        public string TrayCnt { get; set; }
        [JsonProperty("AssemblyLineID")]
        public string AssemblyLineID { get; set; }
        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }
        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
    }
    #endregion

    #region Class_for_RouteOper
    public class JsonRouteOperList
    {
        [JsonProperty("resource")]
        public List<RouteOper> RouteOperList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

        public string this[string strEqptypeID, string strOperGroupID, string strOperID]
        {
            get
            {
                var varOperList = this.RouteOperList.FirstOrDefault(t => t.EqpTypeID == strEqptypeID
                                                              && t.OperGroupID == strOperGroupID
                                                              && t.OperID == strOperID
                                                      );

                if (varOperList == null) return "";

                return varOperList.OperName;
            }
        }
    }

    public class RouteOper
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }

        [JsonProperty("OperID")]
        public string OperID { get; set; }

        [JsonProperty("RowNumber")]
        public string RowNumber { get; set; }

        [JsonProperty("OperName")]
        public string OperName { get; set; }

        [JsonProperty("FormBoxType")]
        public string FormBoxType { get; set; }

        [JsonProperty("NextEqpTypeID")]
        public string NextEqpTypeID { get; set; }

        [JsonProperty("NextOperGroupID")]
        public string NextOperGroupID { get; set; }

        [JsonProperty("NextOperID")]
        public string NextOperID { get; set; }

        [JsonProperty("WaitTimeNextOper")]
        public string WaitTimeNextOper { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }

        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }

        [JsonProperty("OperName_cn")]
        public string OperName_cn { get; set; }

        public string GroupProcId { get; set; } = "";
        public string GroupProcName { get; set; } = "";
    }
    #endregion

    #region Class_for_ProcChangeList
    public class JsonProcChangeList
    {
        [JsonProperty("resource")]
        public List<JsonProcChange> ProcChangeList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonProcChange
    {
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }

        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }

        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }

        [JsonProperty("LotID")]
        public string LotID { get; set; }

        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("RackID")]
        public string RackID { get; set; }

        [JsonProperty("NowOperName")]
        public string NowOperName { get; set; }

        [JsonProperty("NextOperName")]
        public string NextOperName { get; set; }

        [JsonProperty("DefNowOperName")]
        public string DefNowOperName { get; set; }

        [JsonProperty("DefNextOperName")]
        public string DefNextOperName { get; set; }

        //20190923 KJY - StartTime 추가
        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("FireStatus")]
        public string FireStatus { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("CurrCellCnt")]
        public string CurrCellCnt { get; set; }

        //20200619 - RouteID 변경예약
        [JsonProperty("ReserveRouteIDChageFlag")]
        public string ReserveRouteIDChageFlag { get; set; }
        [JsonProperty("ReservedRouteID")]
        public string ReservedRouteID { get; set; }
        [JsonProperty("ReservedProcID")]
        public string ReservedProcID { get; set; }
        [JsonProperty("DefReservedOperName")]
        public string DefReservedOperName { get; set; }


    }
    #endregion

    #region Class_for_Recipe
    // Query Return.. 1EA
    public class JsonRecipeList
    {
        [JsonProperty("resource")]
        public List<JsonRecipe> RecipeList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonRecipe
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("RecipeName")]
        public string RecipeName { get; set; }
        [JsonProperty("DefaultFlag")]
        public string DefaultFlag { get; set; }
        [JsonProperty("Step")]
        public string Step { get; set; }
        [JsonProperty("ConsCurrent")]
        public string ConsCurrent { get; set; }
        [JsonProperty("Voltage")]
        public string Voltage { get; set; }
        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        //20200402 KJY - for DelayTime (출고지연시간)
        [JsonProperty("DelayTime")]
        public string DelayTime { get; set; }


        [JsonProperty("JudgeVoltage")]
        public string JudgeVoltage { get; set; }
        [JsonProperty("EndCurrent")]
        public string EndCurrent { get; set; }
        [JsonProperty("EndVolt")]
        public string EndVolt { get; set; }
        [JsonProperty("EndCapacity")]
        public string EndCapacity { get; set; }
        [JsonProperty("ExpertTime")]
        public string ExpertTime { get; set; }
        [JsonProperty("WaitTime")]
        public string WaitTime { get; set; }
        [JsonProperty("WaitDeltaV")]
        public string WaitDeltaV { get; set; }
        [JsonProperty("WaitDeltaV_Flag")]
        public string WaitDeltaV_Flag { get; set; }
        [JsonProperty("CellLimitCnt")]
        public string CellLimitCnt { get; set; }
        [JsonProperty("OcvWorkType")]
        public string OcvWorkType { get; set; }
        [JsonProperty("OcvTabDir")]
        public string OcvTabDir { get; set; }
        [JsonProperty("OcvPinLimitCnt")]
        public string OcvPinLimitCnt { get; set; }
        [JsonProperty("OcvPinBadUpper")]
        public string OcvPinBadUpper { get; set; }
        [JsonProperty("OcvPinBadLower")]
        public string OcvPinBadLower { get; set; }
        [JsonProperty("OcvPinBadDelta")]
        public string OcvPinBadDelta { get; set; }
        [JsonProperty("OcvIrBadUpper")]
        public string OcvIrBadUpper { get; set; }
        [JsonProperty("OcvIrBadLower")]
        public string OcvIrBadLower { get; set; }
        [JsonProperty("OcvCellBadLimitCnt")]
        public string OcvCellBadLimitCnt { get; set; }
        [JsonProperty("OcvCellBadDeltaOCV")]
        public string OcvCellBadDeltaOCV { get; set; }
        [JsonProperty("OcvCellBadDeltaOCVMin")]
        public string OcvCellBadDeltaOCVMin { get; set; }
        [JsonProperty("OcvCellSigmaNValue")]
        public string OcvCellSigmaNValue { get; set; }
        [JsonProperty("Pressure")]
        public string Pressure { get; set; }
        [JsonProperty("Temp")]
        public string Temp { get; set; }
        [JsonProperty("ProfileVoltDev")]
        public string ProfileVoltDev { get; set; }
        [JsonProperty("CoolingTime")]
        public string CoolingTime { get; set; }
        [JsonProperty("AvgCapacityMin")]
        public string AvgCapacityMin { get; set; }
        [JsonProperty("AvgCapacityMax")]
        public string AvgCapacityMax { get; set; }
        [JsonProperty("AvgCapacityDelta")]
        public string AvgCapacityDelta { get; set; }
        [JsonProperty("AvgVoltMin")]
        public string AvgVoltMin { get; set; }
        [JsonProperty("AvgVoltMax")]
        public string AvgVoltMax { get; set; }
        [JsonProperty("AvgVoltDelta")]
        public string AvgVoltDelta { get; set; }
        [JsonProperty("IrAvgMax")]
        public string IrAvgMax { get; set; }
        [JsonProperty("IrAvgMin")]
        public string IrAvgMin { get; set; }
        [JsonProperty("IrAvgS1")]
        public string IrAvgS1 { get; set; }
        [JsonProperty("IrAvgS2")]
        public string IrAvgS2 { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }
        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
        [JsonProperty("cmmLimitCurrentUpper")]
        public string cmmLimitCurrentUpper { get; set; }
        [JsonProperty("cmmLimitCurrentLower")]
        public string cmmLimitCurrentLower { get; set; }
        [JsonProperty("cmmLimitVoltageUpper")]
        public string cmmLimitVoltageUpper { get; set; }
        [JsonProperty("cmmLimitVoltageLower")]
        public string cmmLimitVoltageLower { get; set; }
        [JsonProperty("cmmLimitTime")]
        public string cmmLimitTime { get; set; }
        [JsonProperty("cmmLimitStepTime")]
        public string cmmLimitStepTime { get; set; }
        [JsonProperty("cmmChgGetVolCheckTime")]
        public string cmmChgGetVolCheckTime { get; set; }
        [JsonProperty("cmmChgGetVolUpper")]
        public string cmmChgGetVolUpper { get; set; }
        [JsonProperty("cmmChgGetVolLower")]
        public string cmmChgGetVolLower { get; set; }
        [JsonProperty("cmmCoolingPressure")]
        public string cmmCoolingPressure { get; set; }
        [JsonProperty("cmmCoolingTemp")]
        public string cmmCoolingTemp { get; set; }
        [JsonProperty("cmmCoolingTime")]
        public string cmmCoolingTime { get; set; }
        [JsonProperty("cmmLimitRestVoltageUpper")]
        public string cmmLimitRestVoltageUpper { get; set; }
        [JsonProperty("cmmLimitRestVoltageLower")]
        public string cmmLimitRestVoltageLower { get; set; }
        [JsonProperty("cmmLimitPressUpper")]
        public string cmmLimitPressUpper { get; set; }
        [JsonProperty("cmmLimitPressLower")]
        public string cmmLimitPressLower { get; set; }

    }
    #endregion

    #region Class_for_RecipeCommon
    // Query Return.. 1EA
    public class JsonRecipeCommonList
    {
        [JsonProperty("resource")]
        public List<RecipeCommon> RecipeCommonList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class RecipeCommon
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }

        [JsonProperty("OperID")]
        public string OperID { get; set; }

        [JsonProperty("LimitCurrentUpper")]
        public string LimitCurrentUpper { get; set; }

        [JsonProperty("LimitCurrentLower")]
        public string LimitCurrentLower { get; set; }

        [JsonProperty("LimitVoltageUpper")]
        public string LimitVoltageUpper { get; set; }

        [JsonProperty("LimitVoltageLower")]
        public string LimitVoltageLower { get; set; }

        [JsonProperty("LimitTime")]
        public string LimitTime { get; set; }

        [JsonProperty("LimitStepTime")]
        public string LimitStepTime { get; set; }

        [JsonProperty("ChgGetVolCheckTime")]
        public string ChgGetVolCheckTime { get; set; }

        [JsonProperty("ChgGetVolUpper")]
        public string ChgGetVolUpper { get; set; }

        [JsonProperty("ChgGetVolLower")]
        public string ChgGetVolLower { get; set; }

        [JsonProperty("CoolingPressure")]
        public string CoolingPressure { get; set; }

        [JsonProperty("CoolingTemp")]
        public string CoolingTemp { get; set; }

        [JsonProperty("CoolingTime")]
        public string CoolingTime { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }

        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
    }
    #endregion

    #region Class_for_CellGradeTempList
    public class JsonCellGradeTempList
    {
        [JsonProperty("resource")]
        public List<CellGradeTemp> CellGradeTempList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class CellGradeTemp
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }

        [JsonProperty("OperID")]
        public string OperID { get; set; }

        [JsonProperty("TempMin")]
        public string TempMin { get; set; }

        [JsonProperty("TempMax")]
        public string TempMax { get; set; }

        [JsonProperty("TempKValue")]
        public string TempKValue { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }

        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
    }
    #endregion  

    #region Class_for_JsonMstUserList
    public class JsonMstUserList
    {
        [JsonProperty("resource")]
        public List<MstUser> MstUserList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

        public string this[string strUserID]
        {
            get
            {
                string strUserName = "";

                strUserName = this.MstUserList.FirstOrDefault(t => t.UserID == strUserID).UserName;

                if (strUserName == null) strUserName = "";

                return strUserName;
            }
        }
    }

    public class MstUser
    {
        [JsonProperty("UserID")]
        public string UserID { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("ClassID")]
        public string ClassID { get; set; }
    }
    #endregion

    #region Class_for_CellProDataList
    public class JsonCellProDataList
    {
        [JsonProperty("resource")]
        public List<CellProData> CellProDataList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }
    //CellProData + CellProStep
    public class CellProData
    {
        [JsonProperty("OperName")]
        public string OperName { get; set; }
        [JsonProperty("CellID")]
        public string CellID { get; set; }

        // 공정시 Cell위치
        [JsonProperty("Channel")]
        public string Channel { get; set; }

        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public string ProcWorkIndex { get; set; }
        [JsonProperty("ProcWorkCnt")]
        public string ProcWorkCnt { get; set; }
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("LotID")]
        public string LotID { get; set; }
        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
        [JsonProperty("CellType")]
        public string CellType { get; set; }
        [JsonProperty("InputDate")]
        public string InputDate { get; set; }
        [JsonProperty("InputTime")]
        public string InputTime { get; set; }
        [JsonProperty("InputObjectID")]
        public string InputObjectID { get; set; }
        [JsonProperty("InputLineID")]
        public string InputLineID { get; set; }
        [JsonProperty("InputFlag")]
        public string InputFlag { get; set; }
        [JsonProperty("ManualInputFlag")]
        public string ManualInputFlag { get; set; }
        [JsonProperty("FormInputLineID")]
        public string FormInputLineID { get; set; }
        [JsonProperty("FormInputDate")]
        public string FormInputDate { get; set; }
        [JsonProperty("FormInputTime")]
        public string FormInputTime { get; set; }
        [JsonProperty("FormInputFlag")]
        public string FormInputFlag { get; set; }
        [JsonProperty("StartDate")]
        public string StartDate { get; set; }
        [JsonProperty("EndDate")]
        public string EndDate { get; set; }
        [JsonProperty("StartTime")]
        public string StartTime { get; set; }
        [JsonProperty("EndTime")]
        public string EndTime { get; set; }
        [JsonProperty("ReworkFlag")]
        public string ReworkFlag { get; set; }
        [JsonProperty("ReworkProc")]
        public string ReworkProc { get; set; }
        [JsonProperty("ReworkCnt")]
        public string ReworkCnt { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("CellNo")]
        public string CellNo { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("Grade")]
        public string Grade { get; set; }
        [JsonProperty("GradeProc")]
        public string GradeProc { get; set; }
        [JsonProperty("GradeObjectID")]
        public string GradeObjectID { get; set; }
        [JsonProperty("Remark")]
        public string Remark { get; set; }
        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }
        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
        [JsonProperty("Step")]
        public string Step { get; set; }

        [JsonProperty("Capacity")]
        public string Capacity { get; set; }

        [JsonProperty("AvgVoltage")]
        public string AvgVoltage { get; set; }

        [JsonProperty("EndVoltage")]
        public string EndVoltage { get; set; }

        [JsonProperty("EndCurrent")]
        public string EndCurrent { get; set; }

        [JsonProperty("ElectricEnergy")]
        public string ElectricEnergy { get; set; }
        [JsonProperty("Temp")]
        public string Temp { get; set; }
        [JsonProperty("TempValue")]
        public string TempValue { get; set; }
        [JsonProperty("CapacityTemp")]
        public string CapacityTemp { get; set; }
        [JsonProperty("Ocv")]
        public string Ocv { get; set; }
        [JsonProperty("DeltaOCV")]
        public string DeltaOCV { get; set; }

        [JsonProperty("DeltaK")]
        public string DeltaK { get; set; }

        [JsonProperty("IR")]
        public string IR { get; set; }
        [JsonProperty("DeltaIR")]
        public string DeltaIR { get; set; }
        [JsonProperty("StartVoltage")]
        public string StartVoltage { get; set; }
        [JsonProperty("ErrCode")]
        public string ErrCode { get; set; }
        [JsonProperty("BadCell")]
        public string BadCell { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
        [JsonProperty("DataPath")]
        public string DataPath { get; set; }
        [JsonProperty("CellDataUpdateTime")]
        public string CellDataUpdateTime { get; set; }



        
        //20190417 KJY - Degas추가
        [JsonProperty("DegasChamberNo")]
        public string DegasChamberNo { get; set; }
        [JsonProperty("DegasChamberPos")]
        public string DegasChamberPos { get; set; }
        [JsonProperty("DegasFinalVacuum")]
        public string DegasFinalVacuum { get; set; }
        [JsonProperty("FinalWeight")]
        public string FinalWeight { get; set; }
        [JsonProperty("RollingPos")]
        public string RollingPos { get; set; }
        [JsonProperty("Rolling1_Pressure")]
        public string Rolling1_Pressure { get; set; }
        [JsonProperty("Rolling2_Pressure")]
        public string Rolling2_Pressure { get; set; }
        [JsonProperty("FinalSealingPressure")]
        public string FinalSealingPressure { get; set; }
        [JsonProperty("FinalSealingTempUpper")]
        public string FinalSealingTempUpper { get; set; }
        [JsonProperty("FinalSealingTempLower")]
        public string FinalSealingTempLower { get; set; }
        [JsonProperty("FinalSealingPos")]
        public string FinalSealingPos { get; set; }
        [JsonProperty("Dimension1")]
        public string Dimension1 { get; set; }
        [JsonProperty("Dimension2")]
        public string Dimension2 { get; set; }
        [JsonProperty("Dimension3")]
        public string Dimension3 { get; set; }
        [JsonProperty("Dimension4")]
        public string Dimension4 { get; set; }
        [JsonProperty("Dimension5")]
        public string Dimension5 { get; set; }
        [JsonProperty("Dimension6")]
        public string Dimension6 { get; set; }
        [JsonProperty("Dimension7")]
        public string Dimension7 { get; set; }
        [JsonProperty("Dimension8")]
        public string Dimension8 { get; set; }
        [JsonProperty("Dimension9")]
        public string Dimension9 { get; set; }
        [JsonProperty("Dimension10")]
        public string Dimension10 { get; set; }
        [JsonProperty("Dimension11")]
        public string Dimension11 { get; set; }
        [JsonProperty("Dimension12")]
        public string Dimension12 { get; set; }
        [JsonProperty("Dimension13")]
        public string Dimension13 { get; set; }
        [JsonProperty("Dimension14")]
        public string Dimension14 { get; set; }
        [JsonProperty("Dimension15")]
        public string Dimension15 { get; set; }
        [JsonProperty("HipotVolt")]
        public string HipotVolt { get; set; }
        [JsonProperty("HipotTime")]
        public string HipotTime { get; set; }
        [JsonProperty("HipotResistant")]
        public string HipotResistant { get; set; }
        [JsonProperty("HipotPos")]
        public string HipotPos { get; set; }
        [JsonProperty("CellThicknessPressure")]
        public string CellThicknessPressure { get; set; }
        [JsonProperty("CellThicknessPos")]
        public string CellThicknessPos { get; set; }
        [JsonProperty("CellThicknessDataCH1")]
        public string CellThicknessDataCH1 { get; set; }
        [JsonProperty("CellThicknessDataCH2")]
        public string CellThicknessDataCH2 { get; set; }
        [JsonProperty("CellThicknessDataCH3")]
        public string CellThicknessDataCH3 { get; set; }
        [JsonProperty("CellThicknessDataCH4")]
        public string CellThicknessDataCH4 { get; set; }
        [JsonProperty("CellThicknessDataCH5")]
        public string CellThicknessDataCH5 { get; set; }
        [JsonProperty("FilledWeight")]
        public string FilledWeight { get; set; }
        [JsonProperty("PostFillWeight")]
        public string PostFillWeight { get; set; }
        [JsonProperty("LossWeight")]
        public string LossWeight { get; set; }
        [JsonProperty("RetentionWeight")]
        public string RetentionWeight { get; set; }
        [JsonProperty("CalcConstant")]
        public string CalcConstant { get; set; }

        //20190709 KJY - Degas 항목추가
        [JsonProperty("CellThicknessDataAVG")]
        public string CellThicknessDataAVG { get; set; }


        //20190509 KJY for Assembly
        [JsonProperty("AForeFillWeight")]
        public string AForeFillWeight { get; set; }
        [JsonProperty("AFilledWeight")]
        public string AFilledWeight { get; set; }
        [JsonProperty("APostFillWeight")]
        public string APostFillWeight { get; set; }


        //20191101 KJY for additional HPC Charge Value
        [JsonProperty("StepStartTime")]
        public string StepStartTime { get; set; }
        [JsonProperty("StepEndTime")]
        public string StepEndTime { get; set; }
        [JsonProperty("Pressure_01")]
        public string Pressure_01 { get; set; }
        [JsonProperty("Pressure_02")]
        public string Pressure_02 { get; set; }
        [JsonProperty("CHG_StartVoltage")]
        public string CHG_StartVoltage { get; set; }
        [JsonProperty("CHG_Temp")]
        public string CHG_Temp { get; set; }

    }
    #endregion



    

    #region Class_for_ReturnString
    // alias 을 사용하여 하나의 리턴 값 을 사용.
    public class JsonReturnStringList
    {
        [JsonProperty("resource")]
        public List<ReturnString> ReturnStringList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class ReturnString
    {
        [JsonProperty("RetString")]
        public string RetString { get; set; }
    }
    #endregion

    #region Class_for_JsonRequest
    public class JsonRequest
    {
        [JsonProperty("code")]
        public int code { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("Message")]
        public string Message { get; set; }
    }
    #endregion

    #region Class_for_Formation_Box
    public class JsonFormationXBoxList
    {
        [JsonProperty("resource")]
        public List<JsonFormationBox> FormationBoxList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonFormationBox
    {
        [JsonProperty("UnitID")]
        public string UnitID { get; set; }
        [JsonProperty("UnitStatus")]
        public string UnitStatus { get; set; }
        [JsonProperty("InModelID")]
        public string InModelID { get; set; }
        [JsonProperty("InRouteID")]
        public string InRouteID { get; set; }
        [JsonProperty("InCellType")]
        public string InCellType { get; set; }
        [JsonProperty("ProcessStatus")]
        public string ProcessStatus { get; set; }
        [JsonProperty("ComStatus")]
        public string ComStatus { get; set; }
        [JsonProperty("EqpUseFlag")]
        public string EqpUseFlag { get; set; }
        [JsonProperty("SingleActFlag")]
        public string SingleActFlag { get; set; }
        [JsonProperty("OperMode")]
        public string OperMode { get; set; }

        [JsonProperty("FireStatus")]
        public string FireStatus { get; set; }
        [JsonProperty("LotID")]
        public string LotID { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }

        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("StartTime")]
        public string StartTime { get; set; }
        [JsonProperty("PlanTime")]
        public string PlanTime { get; set; }
        [JsonProperty("NextOperName")]
        public string NextOperName { get; set; }
        [JsonProperty("JigTempAvg")]
        public string JigTempAvg { get; set; }

    }
    #endregion

    #region Class_for_NReturnString
    // Query Return.. 1EA
    public class JsonNReturnString
    {
        [JsonProperty("resource")]
        public List<NReturnString> returnStringList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class NReturnString
    {
        [JsonProperty("RetString1")]
        public string RetString1 { get; set; }
        [JsonProperty("RetString2")]
        public string RetString2 { get; set; }
        [JsonProperty("RetString3")]
        public string RetString3 { get; set; }
        [JsonProperty("RetString4")]
        public string RetString4 { get; set; }
        [JsonProperty("RetString5")]
        public string RetString5 { get; set; }

    }
    #endregion

    #region Class_for_Trouble
    public class JsonTroubleEventTm
    {
        [JsonProperty("resource")]
        public List<TroubleEventTm> troubleEventTmList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class TroubleEventTm
    {
        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }
        [JsonProperty("BcrUnitName")]
        public string BcrUnitName { get; set; }
        [JsonProperty("EventTime")]
        public string EventTime { get; set; }
        [JsonProperty("UserAction")]
        public string UserAction { get; set; }
        [JsonProperty("TroubleCode")]
        public string TroubleCode { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("TroubleName_kr")]
        public string TroubleName_kr { get; set; }
        [JsonProperty("TroubleName_cn")]
        public string TroubleName_cn { get; set; }
        [JsonProperty("TroubleName_en")]
        public string TroubleName_en { get; set; }
        [JsonProperty("AgingUnitName")]
        public string AgingUnitName { get; set; }

    }
    #endregion

    #region Class_for_Window
    public class JsonMstWindowList
    {
        [JsonProperty("resource")]
        public List<JsonMstWindow> MstWindowList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

        public string this[string strWindowID]
        {
            get
            {
                string strWindowName = "";

                var varTemp = this.MstWindowList.FirstOrDefault(t => t.WindowID == strWindowID);

                if (varTemp == null) return strWindowName;

                if (CDefine.m_enLanguage == enLoginLanguage.Korean) strWindowName = varTemp.WindowName_kr;
                if (CDefine.m_enLanguage == enLoginLanguage.English) strWindowName = varTemp.WindowName_en;
                if (CDefine.m_enLanguage == enLoginLanguage.Chinese) strWindowName = varTemp.WindowName_cn;

                return strWindowName;
            }
        }
    }

    public class JsonMstWindow
    {
        [JsonProperty("WindowID")]
        public string WindowID { get; set; }

        [JsonProperty("WindowName_kr")]
        public string WindowName_kr { get; set; }

        [JsonProperty("WindowName_en")]
        public string WindowName_en { get; set; }

        [JsonProperty("WindowName_cn")]
        public string WindowName_cn { get; set; }

        [JsonProperty("DefaultClassID")]
        public string DefaultClassID { get; set; }
    }
    #endregion

    #region Class_for_Window
    public class JsonMstWindowUserList
    {
        [JsonProperty("resource")]
        public List<JsonMstWindowUser> MstWindowUserList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonMstWindowUser
    {
        [JsonProperty("UserID")]
        public string UserID { get; set; }
        [JsonProperty("WindowID")]
        public string WindowID { get; set; }
        [JsonProperty("Auth_View")]
        public string Auth_View { get; set; }
        [JsonProperty("Auth_Save")]
        public string Auth_Save { get; set; }
    }
    #endregion

    #region Class_for_CtrlTroubleInfoList
    public class JsonCtrlTroubleInfoList
    {
        [JsonProperty("resource")]
        public List<JsonCtrlTroubleInfo> CtrlTroubleInfoList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonCtrlTroubleInfo
    {
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("UnitID")]
        public string UnitID { get; set; }

        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }

        [JsonProperty("UnitName")]
        public string UnitName { get; set; }

        [JsonProperty("TroubleCode")]
        public string TroubleCode { get; set; }

        [JsonProperty("TroubleName_kr")]
        public string TroubleName_kr { get; set; }

        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        [JsonProperty("UserEventTime")]
        public string UserEventTime { get; set; }

        [JsonProperty("ActionFlag")]
        public string ActionFlag { get; set; }

        [JsonProperty("UserAction")]
        public string UserAction { get; set; }

        [JsonProperty("UnitStatus")]
        public string UnitStatus { get; set; }

        [JsonProperty("TroubleName_cn")]
        public string TroubleName_cn { get; set; }

        [JsonProperty("TroubleName_en")]
        public string TroubleName_en { get; set; }

        [JsonProperty("AgingUnitName")]
        public string AgingUnitName { get; set; }
        //분석화면.
        [JsonProperty("TroubleCnt")]
        public string TroubleCnt { get; set; }
    }
    #endregion

    #region Class_for_CtrlFireRecordList
    public class JsonCtrlFireRecordList
    {
        [JsonProperty("resource")]
        public List<JsonCtrlFireRecord> CtrlFireRecordList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonCtrlFireRecord
    {
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("UnitID")]
        public string UnitID { get; set; }

        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }

        [JsonProperty("UnitName")]
        public string UnitName { get; set; }

        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        [JsonProperty("UserEventTime")]
        public string UserEventTime { get; set; }

        [JsonProperty("ActionFlag")]
        public string ActionFlag { get; set; }

        [JsonProperty("UserAction")]
        public string UserAction { get; set; }

        [JsonProperty("UserAction_kr")]
        public string UserAction_kr { get; set; }

        [JsonProperty("UserAction_en")]
        public string UserAction_en { get; set; }

        [JsonProperty("UserAction_cn")]
        public string UserAction_cn { get; set; }

        [JsonProperty("TroubleCode")]
        public string TroubleCode { get; set; }

        [JsonProperty("TroubleName")]
        public string TroubleName { get; set; }

        [JsonProperty("TrayID")]
        public string TrayID { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("AgingUnitName")]
        public string AgingUnitName { get; set; }
    }
    #endregion

    #region Class_for_CtrlTroubleInputList
    public class JsonCtrlTroubleInputList
    {
        [JsonProperty("resource")]
        public List<JsonCtrlTroubleInput> CtrlTroubleInputList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonCtrlTroubleInput
    {
        [JsonProperty("TroubleCode")]
        public string TroubleCode { get; set; }

        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        [JsonProperty("TroubleLevel")]
        public string TroubleLevel { get; set; }

        [JsonProperty("TroubleName")]
        public string TroubleName { get; set; }

        [JsonProperty("UserAction")]
        public string UserAction { get; set; }

        [JsonProperty("UserAction_kr")]
        public string UserAction_kr { get; set; }

        [JsonProperty("UserAction_cn")]
        public string UserAction_cn { get; set; }

        [JsonProperty("UserAction_en")]
        public string UserAction_en { get; set; }

        [JsonProperty("TroubleName_kr")]
        public string TroubleName_kr { get; set; }

        [JsonProperty("TroubleName_cn")]
        public string TroubleName_cn { get; set; }

        [JsonProperty("TroubleName_en")]
        public string TroubleName_en { get; set; }
    }
    #endregion

    #region Class_for_RouteDefList
    public class JsonRouteDefList
    {
        [JsonProperty("resource")]
        public List<JsonRouteDef> RouteDefList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonRouteDef
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("RouteType")]
        public string RouteType { get; set; }

        [JsonProperty("DefaultFlag")]
        public string DefaultFlag { get; set; }

        [JsonProperty("RouteName")]
        public string RouteName { get; set; }

        [JsonProperty("TempBalanceFlag")]
        public string TempBalanceFlag { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }

        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
    }
    #endregion

    #region Class_for_LogInfoList
    public class JsonLogInfoList
    {
        [JsonProperty("resource")]
        public List<JsonLogInfo> LogInfoList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonLogInfo
    {
        [JsonProperty("UserID")]
        public string UserID { get; set; }

        [JsonProperty("WindowID")]
        public string WindowID { get; set; }

        [JsonProperty("UserEvent")]
        public string UserEvent { get; set; }

        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }

    }
    #endregion

    #region Class_for_CellCurrList
    public class JsonCellCurrList
    {
        [JsonProperty("resource")]
        public List<JsonCellCurr> CellCurrList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsonCellCurr
    {
        [JsonProperty("CellID")]
        public string CellID { get; set; }
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("LotID")]
        public string LotID { get; set; }
        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
        [JsonProperty("CellType")]
        public string CellType { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
        [JsonProperty("InputDate")]
        public string InputDate { get; set; }
        [JsonProperty("InputTime")]
        public string InputTime { get; set; }
        [JsonProperty("InputObjectID")]
        public string InputObjectID { get; set; }
        [JsonProperty("InputLineID")]
        public string InputLineID { get; set; }
        [JsonProperty("InputFlag")]
        public string InputFlag { get; set; }
        [JsonProperty("ManualInputFlag")]
        public string ManualInputFlag { get; set; }
        [JsonProperty("FormInputLineID")]
        public string FormInputLineID { get; set; }
        [JsonProperty("FormInputDate")]
        public string FormInputDate { get; set; }
        [JsonProperty("FormInputTime")]
        public string FormInputTime { get; set; }
        [JsonProperty("FormInputFlag")]
        public string FormInputFlag { get; set; }
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkCnt")]
        public string ProcWorkCnt { get; set; }
        [JsonProperty("StartTime")]
        public string StartTime { get; set; }
        [JsonProperty("EndTime")]
        public string EndTime { get; set; }
        [JsonProperty("ReworkFlag")]
        public string ReworkFlag { get; set; }
        [JsonProperty("ReworkProc")]
        public string ReworkProc { get; set; }
        [JsonProperty("ReworkCnt")]
        public string ReworkCnt { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("CellNo")]
        public string CellNo { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("Grade")]
        public string Grade { get; set; }
        [JsonProperty("GradeProc")]
        public string GradeProc { get; set; }
        [JsonProperty("GradeCode")]
        public string GradeCode { get; set; }
        [JsonProperty("GradeObjectID")]
        public string GradeObjectID { get; set; }
        [JsonProperty("Remark")]
        public string Remark { get; set; }
        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }
        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }
        [JsonProperty("NextEqpTypeID")]
        public string NextEqpTypeID { get; set; }
        [JsonProperty("NextOperGroupID")]
        public string NextOperGroupID { get; set; }
        [JsonProperty("NextOperID")]
        public string NextOperID { get; set; }
    }
    #endregion

    #region Class_for_UnitTempList
    public class JsonUnitTempList
    {
        [JsonProperty("resource")]
        public List<JsoUnitTemp> UnitTempList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsoUnitTemp
    {
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }

        [JsonProperty("LineID")]
        public string LineID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("UnitID")]
        public string UnitID { get; set; }

        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        [JsonProperty("TrayID")]
        public string TrayID { get; set; }

        [JsonProperty("ChCnt")]
        public string ChCnt { get; set; }

        [JsonProperty("JigTemp1")]
        public string JigTemp1 { get; set; }
        [JsonProperty("JigTemp2")]
        public string JigTemp2 { get; set; }
        [JsonProperty("JigTemp3")]
        public string JigTemp3 { get; set; }
        [JsonProperty("JigTemp4")]
        public string JigTemp4 { get; set; }
        [JsonProperty("JigTemp5")]
        public string JigTemp5 { get; set; }
        [JsonProperty("JigTemp6")]
        public string JigTemp6 { get; set; }
        [JsonProperty("JigTemp7")]
        public string JigTemp7 { get; set; }
        [JsonProperty("JigTemp8")]
        public string JigTemp8 { get; set; }

        [JsonProperty("JigTempAvg")]
        public string JigTempAvg { get; set; }
        [JsonProperty("JigTempMin")]
        public string JigTempMin { get; set; }
        [JsonProperty("JigTempMax")]
        public string JigTempMax { get; set; }

        [JsonProperty("PowerTemp1")]
        public string PowerTemp1 { get; set; }
        [JsonProperty("PowerTemp2")]
        public string PowerTemp2 { get; set; }
        [JsonProperty("PowerTemp3")]
        public string PowerTemp3 { get; set; }
        [JsonProperty("PowerTemp4")]
        public string PowerTemp4 { get; set; }
        [JsonProperty("PowerTemp5")]
        public string PowerTemp5 { get; set; }
        [JsonProperty("PowerTemp6")]
        public string PowerTemp6 { get; set; }
        [JsonProperty("PowerTemp7")]
        public string PowerTemp7 { get; set; }
        [JsonProperty("PowerTemp8")]
        public string PowerTemp8 { get; set; }

        [JsonProperty("PowerTempAvg")]
        public string PowerTempAvg { get; set; }
        [JsonProperty("PowerTempMin")]
        public string PowerTempMin { get; set; }
        [JsonProperty("PowerTempMax")]
        public string PowerTempMax { get; set; }

    }
    #endregion

    #region Class_for_UnitTempHPCList
    public class JsonUnitTempHPCList
    {
        [JsonProperty("resource")]
        public List<JsoUnitTempHPC> UnitTempHPCList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsoUnitTempHPC
    {
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }

        [JsonProperty("LineID")]
        public string LineID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("UnitID")]
        public string UnitID { get; set; }

        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        [JsonProperty("TrayID")]
        public string TrayID { get; set; }

        [JsonProperty("ChCnt")]
        public string ChCnt { get; set; }

        [JsonProperty("JigTemp1")]
        public string JigTemp1 { get; set; }
        [JsonProperty("JigTemp2")]
        public string JigTemp2 { get; set; }
        [JsonProperty("JigTemp3")]
        public string JigTemp3 { get; set; }
        [JsonProperty("JigTemp4")]
        public string JigTemp4 { get; set; }
        [JsonProperty("JigTemp5")]
        public string JigTemp5 { get; set; }
        [JsonProperty("JigTemp6")]
        public string JigTemp6 { get; set; }
        [JsonProperty("JigTemp7")]
        public string JigTemp7 { get; set; }
        [JsonProperty("JigTemp8")]
        public string JigTemp8 { get; set; }
        [JsonProperty("JigTemp9")]
        public string JigTemp9 { get; set; }
        [JsonProperty("JigTemp10")]
        public string JigTemp10 { get; set; }
        [JsonProperty("JigTemp11")]
        public string JigTemp11 { get; set; }
        [JsonProperty("JigTemp12")]
        public string JigTemp12 { get; set; }
        [JsonProperty("JigTemp13")]
        public string JigTemp13 { get; set; }
        [JsonProperty("JigTemp14")]
        public string JigTemp14 { get; set; }
        [JsonProperty("JigTemp15")]
        public string JigTemp15 { get; set; }
        [JsonProperty("JigTemp16")]
        public string JigTemp16 { get; set; }
        [JsonProperty("JigTemp17")]
        public string JigTemp17 { get; set; }
        [JsonProperty("JigTemp18")]
        public string JigTemp18 { get; set; }
        [JsonProperty("JigTemp19")]
        public string JigTemp19 { get; set; }
        [JsonProperty("JigTemp20")]
        public string JigTemp20 { get; set; }
        [JsonProperty("JigTemp21")]
        public string JigTemp21 { get; set; }
        [JsonProperty("JigTemp22")]
        public string JigTemp22 { get; set; }
        [JsonProperty("JigTemp23")]
        public string JigTemp23 { get; set; }
        [JsonProperty("JigTemp24")]
        public string JigTemp24 { get; set; }
        [JsonProperty("JigTemp25")]
        public string JigTemp25 { get; set; }
        [JsonProperty("JigTemp26")]
        public string JigTemp26 { get; set; }
        [JsonProperty("JigTemp27")]
        public string JigTemp27 { get; set; }
        [JsonProperty("JigTemp28")]
        public string JigTemp28 { get; set; }
        [JsonProperty("JigTemp29")]
        public string JigTemp29 { get; set; }
        [JsonProperty("JigTemp30")]
        public string JigTemp30 { get; set; }
        [JsonProperty("JigTemp31")]
        public string JigTemp31 { get; set; }
        [JsonProperty("JigTemp32")]
        public string JigTemp32 { get; set; }
        [JsonProperty("JigTemp33")]
        public string JigTemp33 { get; set; }
        [JsonProperty("JigTemp34")]
        public string JigTemp34 { get; set; }
        [JsonProperty("JigTemp35")]
        public string JigTemp35 { get; set; }
        [JsonProperty("JigTemp36")]
        public string JigTemp36 { get; set; }
        [JsonProperty("JigTemp37")]
        public string JigTemp37 { get; set; }
        [JsonProperty("JigTemp38")]
        public string JigTemp38 { get; set; }
        [JsonProperty("JigTemp39")]
        public string JigTemp39 { get; set; }
        [JsonProperty("JigTemp40")]
        public string JigTemp40 { get; set; }
        [JsonProperty("JigTemp41")]
        public string JigTemp41 { get; set; }
        [JsonProperty("JigTemp42")]
        public string JigTemp42 { get; set; }
        [JsonProperty("JigTemp43")]
        public string JigTemp43 { get; set; }
        [JsonProperty("JigTemp44")]
        public string JigTemp44 { get; set; }
        [JsonProperty("JigTemp45")]
        public string JigTemp45 { get; set; }
        [JsonProperty("JigTemp46")]
        public string JigTemp46 { get; set; }
        [JsonProperty("JigTemp47")]
        public string JigTemp47 { get; set; }
        [JsonProperty("JigTemp48")]
        public string JigTemp48 { get; set; }
        [JsonProperty("JigTemp49")]
        public string JigTemp49 { get; set; }
        [JsonProperty("JigTemp50")]
        public string JigTemp50 { get; set; }
        [JsonProperty("JigTemp51")]
        public string JigTemp51 { get; set; }
        [JsonProperty("JigTemp52")]
        public string JigTemp52 { get; set; }
        [JsonProperty("JigTemp53")]
        public string JigTemp53 { get; set; }
        [JsonProperty("JigTemp54")]
        public string JigTemp54 { get; set; }
        [JsonProperty("JigTemp55")]
        public string JigTemp55 { get; set; }
        [JsonProperty("JigTemp56")]
        public string JigTemp56 { get; set; }
        [JsonProperty("JigTemp57")]
        public string JigTemp57 { get; set; }
        [JsonProperty("JigTemp58")]
        public string JigTemp58 { get; set; }

        [JsonProperty("Pressure")]
        public string Pressure { get; set; }
    }
    #endregion

    #region Class_for_EqpStatusList
    public class JsonEqpStatusList
    {
        [JsonProperty("resource")]
        public List<JsoEqpStatus> EqpStatusList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JsoEqpStatus
    {
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("StatusFlag")]
        public string StatusFlag { get; set; }
        [JsonProperty("UnitID")]
        public string UnitID { get; set; }
        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }
        [JsonProperty("EventTime")]
        public string EventTime { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("AgingUnitName")]
        public string AgingUnitName { get; set; }

        [JsonProperty("Status_Cnt")]
        public string Status_Cnt { get; set; }
    }
    #endregion  

    #region Class_for_ProcMoniList
    //공정별 생산 현황..
    public class JsonProcMoniList
    {
        [JsonProperty("resource")]
        public List<ProcMoni> ProcMoniList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class ProcMoni
    {
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }

        [JsonProperty("OperID")]
        public string OperID { get; set; }

        [JsonProperty("OperName")]
        public string OperName { get; set; }

        [JsonProperty("RowNumber")]
        public string RowNumber { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("Status_W")]
        public string Status_W { get; set; }

        [JsonProperty("CurrCellCnt_W")]
        public string CurrCellCnt_W { get; set; }

        [JsonProperty("Status_R")]
        public string Status_R { get; set; }

        [JsonProperty("CurrCellCnt_R")]
        public string CurrCellCnt_R { get; set; }

        [JsonProperty("Status_E")]
        public string Status_E { get; set; }

        [JsonProperty("CurrCellCnt_E")]
        public string CurrCellCnt_E { get; set; }

        [JsonProperty("Status_T")]
        public string Status_T { get; set; }

        [JsonProperty("Status_B")]
        public string Status_B { get; set; }

        [JsonProperty("CurrCellCnt_T")]
        public string CurrCellCnt_T { get; set; }

        [JsonProperty("CurrCellCnt_B")]
        public string CurrCellCnt_B { get; set; }

        [JsonProperty("TotalTray")]
        public string TotalTray { get; set; }

        [JsonProperty("TotalCell")]
        public string TotalCell { get; set; }

        [JsonProperty("LotID")]
        public string LotID { get; set; }

        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
    }
    #endregion

    #region Class_for_JudgeReportList
    public class JsonJudgeReportList
    {
        [JsonProperty("resource")]
        public List<JudgeReport> JudgeReportList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }

    }

    public class JudgeReport
    {
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }

        [JsonProperty("OperID")]
        public string OperID { get; set; }

        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("CellCnt")]
        public int CellCnt { get; set; }

        [JsonProperty("InputCellCnt")]
        public int InputCellCnt { get; set; }

        [JsonProperty("NullCellCnt")]
        public int NullCellCnt { get; set; }

        [JsonProperty("ManualCellCnt")]
        public int ManualCellCnt { get; set; }

        [JsonProperty("NoneCellCnt")]
        public int NoneCellCnt { get; set; }

        [JsonProperty("Select_1")]
        public int Select_1 { get; set; }

        [JsonProperty("Select_2")]
        public int Select_2 { get; set; }

        [JsonProperty("Select_3")]
        public int Select_3 { get; set; }

        [JsonProperty("Grade_A")]
        public int Grade_A { get; set; }

        [JsonProperty("Grade_B")]
        public int Grade_B { get; set; }

        [JsonProperty("Grade_C")]
        public int Grade_C { get; set; }

        [JsonProperty("Grade_D")]
        public int Grade_D { get; set; }

        [JsonProperty("Grade_E")]
        public int Grade_E { get; set; }

        [JsonProperty("Grade_F")]
        public int Grade_F { get; set; }
    }
    #endregion

    #region Class_for_GripperList
    public class JsonGripperList
    {
        [JsonProperty("resource")]
        public List<JsonGripper> GripperList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonGripper
    {
        [JsonProperty("LineID")]
        public string LineID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }

        [JsonProperty("UnitID")]
        public string UnitID { get; set; }

        [JsonProperty("UnitName")]
        public string UnitName { get; set; }

        [JsonProperty("CH")]
        public string CH { get; set; }

        [JsonProperty("SpecCnt")]
        public string SpecCnt { get; set; }

        [JsonProperty("CurrCnt")]
        public string CurrCnt { get; set; }
    }
    #endregion  

    #region Class_for_TroublePinList
    public class JsonTroublePinList
    {
        [JsonProperty("resource")]
        public List<JsonTroublePin> TroublePinList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonTroublePin
    {
        [JsonProperty("LineID")]
        public string LineID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("UnitID")]
        public string UnitID { get; set; }
        [JsonProperty("EventTime")]
        public string EventTime { get; set; }
        [JsonProperty("CH")]
        public string CH { get; set; }

        [JsonProperty("EqpTroubleFlag")]
        public string EqpTroubleFlag { get; set; }

        [JsonProperty("UserEventTime")]
        public string UserEventTime { get; set; }

        [JsonProperty("UserID")]
        public string UserID { get; set; }

        [JsonProperty("UserAction")]
        public string UserAction { get; set; }

        [JsonProperty("UpdateUser")]
        public string UpdateUser { get; set; }

        [JsonProperty("UpdateTime")]
        public string UpdateTime { get; set; }

        [JsonProperty("EqpTypeName")]
        public string EqpTypeName { get; set; }
         
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }
    }
    #endregion  

    #region Class_for_ManualComment Response
    public class JsonManualCommandResponse
    {
        [JsonProperty("Ret")]
        public string Ret { get; set; }
    }
    #endregion

    #region Class_for_TrayCellCntList
    public class JsonTrayCellCntList
    {
        [JsonProperty("resource")]
        public List<JsonTrayCellCnt> TrayCellCntList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonTrayCellCnt
    {
        [JsonProperty("LotID")]
        public string LotID { get; set; }

        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("InputTrayCnt")]
        public string InputTrayCnt { get; set; }

        [JsonProperty("InputCellCnt")]
        public string InputCellCnt { get; set; }

        [JsonProperty("CurrCellCnt")]
        public string CurrCellCnt { get; set; }

        [JsonProperty("CurrTrayCnt")]
        public string CurrTrayCnt { get; set; }

        [JsonProperty("CurrNGCellCnt")]
        public string CurrNGCellCnt { get; set; }

        [JsonProperty("HistCellCnt")]
        public string HistCellCnt { get; set; }

        [JsonProperty("HistTrayCnt")]
        public string HistTrayCnt { get; set; }

        [JsonProperty("Grade_A")]
        public string Grade_A { get; set; }

        [JsonProperty("Grade_B")]
        public string Grade_B { get; set; }
        [JsonProperty("Grade_C")]
        public string Grade_C { get; set; }

        [JsonProperty("Grade_D")]
        public string Grade_D { get; set; }

        [JsonProperty("Grade_E")]
        public string Grade_E { get; set; }
        [JsonProperty("Grade_F")]
        public string Grade_F { get; set; }
    }
    #endregion  

    #region Class_for_TrayCellCntList
    public class JsonTrayCellProStepCntList
    {
        [JsonProperty("resource")]
        public List<JsonTrayCellProStepCnt> TrayCellProStepCnt { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonTrayCellProStepCnt
    {

        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }

        [JsonProperty("RouteID")]
        public string RouteID { get; set; }

        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }

        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }

        [JsonProperty("OperID")]
        public string OperID { get; set; }

        [JsonProperty("CurrCellCnt_R")]
        public string CurrCellCnt_R { get; set; }

        [JsonProperty("Status_R")]
        public string Status_R { get; set; }

        [JsonProperty("CurrCellCnt_E")]
        public string CurrCellCnt_E { get; set; }

        [JsonProperty("Status_E")]
        public string Status_E { get; set; }

    }
    #endregion  

    #region Class_for_CellDailyCntList
    public class JsonCellDailyCntList
    {
        [JsonProperty("resource")]
        public List<JsonCellDailyCnt> CellDailyCntList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellDailyCnt
    {
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("Grade")]
        public string Grade { get; set; }
        [JsonProperty("CellCnt")]
        public string CellCnt { get; set; }
    }
    #endregion


    #region Class_for_CellProCHGList
    public class JsonCellProCHGList
    {
        [JsonProperty("resource")]
        public List<JsonCellProCHG> CellProCHGList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellProCHG
    {
        [JsonProperty("PartKey")]
        public string PartKey { get; set; }
        [JsonProperty("CellID")]
        public string CellID { get; set; }
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public string ProcWorkIndex { get; set; }
        [JsonProperty("Step")]
        public string Step { get; set; }
        [JsonProperty("Capacity")]
        public string Capacity { get; set; }
        [JsonProperty("AvgVoltage")]
        public string AvgVoltage { get; set; }
        [JsonProperty("EndVoltage")]
        public string EndVoltage { get; set; }
        [JsonProperty("EndCurrent")]
        public string EndCurrent { get; set; }
        [JsonProperty("Temp")]
        public string Temp { get; set; }
        [JsonProperty("TempValue")]
        public string TempValue { get; set; }
        [JsonProperty("CapacityTemp")]
        public string CapacityTemp { get; set; }
        [JsonProperty("ErrCode")]
        public string ErrCode { get; set; }
        [JsonProperty("BadCell")]
        public string BadCell { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("CellNo")]
        public string CellNo { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
    }
    #endregion

    #region Class_for_CellProOcvList
    public class JsonCellProOcvList
    {
        [JsonProperty("resource")]
        public List<JsonCellProOcv> CellProOcvList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellProOcv
    {
        [JsonProperty("PartKey")]
        public string PartKey { get; set; }
        [JsonProperty("CellID")]
        public string CellID { get; set; }
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public string ProcWorkIndex { get; set; }
        [JsonProperty("Step")]
        public string Step { get; set; }

        [JsonProperty("Ocv")]
        public string Ocv { get; set; }
        [JsonProperty("DeltaOCV")]
        public string DeltaOCV { get; set; }

        [JsonProperty("ErrCode")]
        public string ErrCode { get; set; }
        [JsonProperty("BadCell")]
        public string BadCell { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("CellNo")]
        public string CellNo { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
    }
    #endregion

    #region Class_for_CellProIRList
    public class JsonCellProIRList
    {
        [JsonProperty("resource")]
        public List<JsonCellProIR> CellProIRList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellProIR
    {
        [JsonProperty("PartKey")]
        public string PartKey { get; set; }
        [JsonProperty("CellID")]
        public string CellID { get; set; }
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public string ProcWorkIndex { get; set; }
        [JsonProperty("Step")]
        public string Step { get; set; }

        [JsonProperty("IR")]
        public string IR { get; set; }
        [JsonProperty("DeltaIR")]
        public string DeltaIR { get; set; }

        [JsonProperty("ErrCode")]
        public string ErrCode { get; set; }
        [JsonProperty("BadCell")]
        public string BadCell { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("CellNo")]
        public string CellNo { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
    }
    #endregion

    #region Class_for_CellProDCIRList
    public class JsonCellProDCIRList
    {
        [JsonProperty("resource")]
        public List<JsonCellProDCIR> CellProDCIRList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellProDCIR
    {
        [JsonProperty("PartKey")]
        public string PartKey { get; set; }
        [JsonProperty("CellID")]
        public string CellID { get; set; }
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public string ProcWorkIndex { get; set; }
        [JsonProperty("Step")]
        public string Step { get; set; }
        [JsonProperty("IR")]
        public string IR { get; set; }
        [JsonProperty("StartVoltage")]
        public string StartVoltage { get; set; }
        [JsonProperty("EndVoltage")]
        public string EndVoltage { get; set; }
        [JsonProperty("EndCurrent")]
        public string EndCurrent { get; set; }
        [JsonProperty("ErrCode")]
        public string ErrCode { get; set; }
        [JsonProperty("BadCell")]
        public string BadCell { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("CellNo")]
        public string CellNo { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
    }
    #endregion

    #region Class_for_CellProDegasLis
    public class JsonCellProDegasList
    {
        [JsonProperty("resource")]
        public List<JsonCellProDegas> CellProDegasList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellProDegas
    {
        [JsonProperty("PartKey")]
        public string PartKey { get; set; }
        [JsonProperty("CellID")]
        public string CellID { get; set; }
        [JsonProperty("LineID")]
        public string LineID { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public string ProcWorkIndex { get; set; }
        [JsonProperty("Step")]
        public string Step { get; set; }

        [JsonProperty("Weight1")]
        public string Weight1 { get; set; }
        [JsonProperty("Weight2")]
        public string Weight2 { get; set; }
        [JsonProperty("Weight3")]
        public string Weight3 { get; set; }
        [JsonProperty("Dimension1")]
        public string Dimension1 { get; set; }
        [JsonProperty("Dimension2")]
        public string Dimension2 { get; set; }
        [JsonProperty("Dimension3")]
        public string Dimension3 { get; set; }
        [JsonProperty("Dimension4")]
        public string Dimension4 { get; set; }
        [JsonProperty("Dimension5")]
        public string Dimension5 { get; set; }
        [JsonProperty("Dimension6")]
        public string Dimension6 { get; set; }
        [JsonProperty("Dimension7")]
        public string Dimension7 { get; set; }
        [JsonProperty("Dimension8")]
        public string Dimension8 { get; set; }
        [JsonProperty("Dimension9")]
        public string Dimension9 { get; set; }
        [JsonProperty("Dimension10")]
        public string Dimension10 { get; set; }
        [JsonProperty("Thick1")]
        public string Thick1 { get; set; }
        [JsonProperty("Thick2")]
        public string Thick2 { get; set; }

        [JsonProperty("ErrCode")]
        public string ErrCode { get; set; }
        [JsonProperty("BadCell")]
        public string BadCell { get; set; }
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("CellNo")]
        public string CellNo { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }
        [JsonProperty("ObjectID")]
        public string ObjectID { get; set; }
    }
    #endregion


    public class JsonCellProcDataList
    {
        [JsonProperty("resource")]
        public List<JsonCellProcData> CellProcDataList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }
    public class JsonCellProcData
    {
        [JsonProperty("Step")]
        public int Step { get; set; }
        [JsonProperty("CellID")]
        public string CellID{ get; set; }
        [JsonProperty("CellNo")]
        public int CellNo { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public int ProcWorkIndex{ get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID{ get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID{ get; set; }
        [JsonProperty("OperID")]
        public string OperID{ get; set; }

        [JsonProperty("TrayID")]
        public string TrayID{ get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate{ get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime{ get; set; }

        //[JsonProperty("Capacity")]
        //public float Capacity { get; set; }
        //[JsonProperty("AvgVoltage")]
        //public float AvgVoltage { get; set; }
        //[JsonProperty("EndVoltage")]
        //public float EndVoltage { get; set; }
        //[JsonProperty("EndCurrent")]
        //public float EndCurrent { get; set; }
        //[JsonProperty("Ocv")]
        //public float Ocv { get; set; }
        //[JsonProperty("DeltaOCV")]
        //public float DeltaOCV { get; set; }
        //[JsonProperty("IR")]
        //public float IR { get; set; }
        //[JsonProperty("DeltaIR")]
        //public float DeltaIR { get; set; }
        //[JsonProperty("StartVoltage")]
        //public float StartVoltage { get; set; }

        [JsonProperty("MeasureValue")]
        public float MeasureValue { get; set; }
    }

    public class JsonCellProStepList
    {
        [JsonProperty("resource")]
        public List<JsonCellProStep> CellProStepList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }
    public class JsonCellProStep
    {
        [JsonProperty("Step")]
        public int Step { get; set; }
        [JsonProperty("CellID")]
        public string CellID { get; set; }
        [JsonProperty("CellNo")]
        public int CellNo { get; set; }
        [JsonProperty("ProcWorkIndex")]
        public int ProcWorkIndex { get; set; }
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("OperGroupID")]
        public string OperGroupID { get; set; }
        [JsonProperty("OperID")]
        public string OperID { get; set; }

        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
        [JsonProperty("TrayInputDate")]
        public string TrayInputDate { get; set; }
        [JsonProperty("TrayInputTime")]
        public string TrayInputTime { get; set; }

        [JsonProperty("LotID")]
        public string LotID { get; set; }

    }

    #region Class_for_UnitState
    public class JsonUnitStateList
    {
        [JsonProperty("resource")]
        public List<JsonUnitState> UnitStateList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonUnitState
    {
        [JsonProperty("EqpTypeID")]
        public string EqpTypeID { get; set; }
        [JsonProperty("UnitStatus")]
        public string UnitStatus { get; set; }
        [JsonProperty("FireStatus")]
        public string FireStatus { get; set; }
        [JsonProperty("UnitID")]
        public string UnitID { get; set; }
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }
        [JsonProperty("TroubleCode")]
        public string TroubleCode { get; set; }
    }
    #endregion


    #region For Call SP
    // sp
    public class REST_RESULT_CUD_SP_RESOURCE
    {
        public string on_ret_num { get; set; }
        public string os_ret_msg { get; set; }
    }

    public class REST_RESULT_CUD_SP
    {
        public int count { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public REST_RESULT_CUD_SP_RESOURCE[] resource { get; set; }
    }
    #endregion

    #region For countonly
    public class REST_RESULT_COUNTONLY
    {
        public int count { get; set; }
        public object[] resource { get; set; }
    }
    #endregion
    #region Class_for_CellCurrList_CELLIDONLY
    public class JsonCellList_CELLIDONLY
    {
        [JsonProperty("resource")]
        public List<JsonCellCurr_CELLIDONLY> CellIDList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellCurr_CELLIDONLY
    {
        [JsonProperty("CellID")]
        public string CellID { get; set; }
    }

    #endregion

    #region Class_for_TrayCurrList_TRAYIDONLY
    public class JsonTRAYList_TRAYIDONLY
    {
        [JsonProperty("resource")]
        public List<JsonTray_TRAYIDONLY> TrayIDList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonTray_TRAYIDONLY
    {
        [JsonProperty("TrayID")]
        public string TrayID { get; set; }
    }

    #endregion

    #region Cell이 가질수 있는 등급들
    public class JsonCellGradeDefList
    {
        [JsonProperty("resource")]
        public List<JsonCellGradeDef> CellGradeDefList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonCellGradeDef
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
        [JsonProperty("Grade_EqpTypeID")]
        public string Grade_EqpTypeID { get; set; }
        [JsonProperty("Grade")]
        public string Grade { get; set; }
    }
    #endregion

    #region Selector/Grader 각 배출구가 가질수 있는 등급들
    public class JsonEQPGradeDefList
    {
        [JsonProperty("resource")]
        public List<JsonEQPGradeDef> EQPGradeDeList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonEQPGradeDef
    {
        [JsonProperty("ProdModel")]
        public string ProdModel { get; set; }
        [JsonProperty("RouteID")]
        public string RouteID { get; set; }
        [JsonProperty("Grade_EqpTypeID")]
        public string Grade_EqpTypeID { get; set; }
        [JsonProperty("SlotNo")]
        public int SlotNo { get; set; }
        [JsonProperty("Grade")]
        public string Grade { get; set; }
        [JsonProperty("DefaultNGFlag")]
        public string DefaultNGFlag { get; set; }
    }
    #endregion

    #region tMstConfig
    public class JsonMstConfigList
    {
        [JsonProperty("resource")]
        public List<JsonMstConfig> MstConfigList { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonMstConfig
    {
        [JsonProperty("GraderBypassFlag")]
        public string GraderBypassFlag { get; set; }
        [JsonProperty("GraderBypassRate")]
        public string GraderBypassRate { get; set; }


        [JsonProperty("MainLoopTrafficAlarm")]
        public string MainLoopTrafficAlarm { get; set; }

        //20201216 KJY  for ASMLimit
        [JsonProperty("ASMEmptyTrayLimit")]
        public string ASMEmptyTrayLimit { get; set; }
    }
    #endregion

    #region [Class for T Data]
    class CMReturn<T>
    {
        [JsonProperty("resource")]
        public List<T> resource { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }
    #endregion


    #region [ProStep by Grade]
    class JsonProStepGradeList
    {
        [JsonProperty("resource")]
        public List<JsonProStepGrade> resource { get; set; }
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
    }

    public class JsonProStepGrade
    {
        public string StartDate { get; set; }
        public string ProdModel { get; set; }
        public string LotID { get; set; }
        public string Grade { get; set; }
        public string CNT { get; set; }
        public int rowNum { get; set; } = 0;
        public int colNum { get; set; } = 0;
    }
    #endregion

    public class JsonGripperCount
    {
        [JsonProperty("UnitID")]
        public string UnitID { get; set; }
        [JsonProperty("UnitName")]
        public string UnitName { get; set; }
        [JsonProperty("GripperAVG")]
        public string GripperAVG { get; set; }
        [JsonProperty("mLine")]
        public int mLine { get; set; }
    }

    // 20210104 KJY - for  RouteID 관리 (삭제, 복제)
    public class JsontCellGradeList
    {
        [JsonProperty("resource")]
        public List<jsonCellGrade> CellGradeList;
        public int count;
        public int code;
    }

    public class jsonCellGrade
    {
        public string ProdModel;
        public string RouteID;


        public string Grade_EqpTypeID;
        public string Grade_OperGroupID;
        public string Grade_OperID;

        public string Grade;
        // 아래꺼는 불필요할듯
        public int RowPos;
        public int ColPos;

        public string cal_text;
        public string Descr;

        public string UpdateUser;
        public string UpdateTime;
    }
}

