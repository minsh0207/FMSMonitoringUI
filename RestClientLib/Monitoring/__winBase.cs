using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RestClientLib
{
    #region WinManageEqp
    /// <summary>
    /// JSON base format : WinManageEqp
    /// </summary>
    public class _win_manage_eqp
    {
        public string EQP_ID { get; set; }
        public string EQP_NAME { get; set; }
        public string EQP_NAME_LOCAL { get; set; }
        public string EQP_MODE { get; set; }
        public int OPERATION_MODE { get; set; }
        public string EQP_STATUS { get; set; }
        public string TRAY_ID { get; set; }
        public string LEVEL { get; set; }
        public string TROUBLE_CODE { get; set; }
        public string TROUBLE_NAME { get; set; }
        public DateTime TRAY_INPUT_TIME { get; set; }
        public string TRAY_ZONE { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string LOT_ID { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
        public int CURRENT_CELL_CNT { get; set; }
        public string PROCESS_NAME { get; set; }
    }
    #endregion
    #region WinTrayInfo
    /// <summary>
    /// JSON base format : WinTrayInfo
    /// </summary>
    public class _win_tray_info
    {
        public string MODEL_ID { get; set; }
        public string TRAY_ID { get; set; }
        public DateTime TRAY_INPUT_TIME { get; set; }
        public string ROUTE_ID { get; set; }
        public string LOT_ID { get; set; }
        public string PROCESS_NAME { get; set; }        
        public string EQP_NAME { get; set; }
        public string EQP_NAME_LOCAL { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
        public int CURRENT_CELL_CNT { get; set; }
        public string TRAY_ZONE { get; set; }
        public string RACK_ID { get; set; }
    }
    #endregion
    #region WinTrayInfo
    /// <summary>
    /// JSON base format : WinTrayInfo
    /// </summary>
    public class _tray_process_flow
    {
        public string PROCESS_NAME { get; set; }
        public string EQP_NAME { get; set; }
        public string EQP_NAME_LOCAL { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public int CURRENT_CELL_CNT { get; set; }
        public string RECIPE_ID { get; set; }
        public string JSON_RECIPE { get; set; }
    }
    #endregion
    #region WinCellDetailInfo
    /// <summary>
    /// JSON base format : WinCellDetailInfo
    /// </summary>
    public class _cell_process_flow
    {
        public string PROCESS_NAME { get; set; }
        public string JSON_RECIPE { get; set; }
        public string json_process_data { get; set; }
    }
    #endregion
    #region WinLeadTime
    /// <summary>
    /// JSON base format : WinLeadTime
    /// </summary>
    public class _win_lead_time
    {
        public string LINE { get; set; }
        public string LANE { get; set; }
        public string BAY { get; set; }
        public string FLOOR { get; set; }
        public string RACK_ID { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public int AGING_TIME { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
    }
    #endregion
    #region WinLeadTime
    /// <summary>
    /// JSON base format : WinLeadTime
    /// </summary>
    public class _lead_time_chg
    {
        public string EQP_NAME { get; set; }
        public string UNIT_ID { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
    }
    #endregion
    #region WinAgingRackSetting
    /// <summary>
    /// JSON base format : WinAgingRackSetting
    /// </summary>
    public class _win_aging_rack
    {
        public string AGING_TYPE { get; set; }
        public string RACK_ID { get; set; }
        public string LINE { get; set; }
        public string LANE { get; set; }
        public string BAY { get; set; }
        public string FLOOR { get; set; }
        public string STATUS { get; set; }
        public string USE_FLAG { get; set; }
        public int TRAY_CNT { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public string SEL_TRAY_ID { get; set; }
        public string LEVEL { get; set; }
        public string TROUBLE_CODE { get; set; }
        public string TROUBLE_NAME { get; set; }
        public DateTime TRAY_INPUT_TIME { get; set; }
        public string TRAY_ZONE { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string RECIPE_ID { get; set; }
        public int PROCESS_NO { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
        public string PROCESS_NAME { get; set; }
    }
    #endregion
    #region AgingRackCount
    /// <summary>
    /// JSON base format : WinAgingRackSetting
    /// </summary>
    public class _aging_rack_count
    {
        public string AGING_TYPE { get; set; }
        public string LINE { get; set; }
        public string LANE { get; set; }
        public int TOTAL_RACK_CNT { get; set; }
        public int IN_AGING { get; set; }
        public int EMPTY_RACK{ get; set; }
        public int UNLOADING_RACK { get; set; }
        public int NO_INPUT_RACK { get; set; }
        public int NO_OUTPUT_RACK{ get; set; }
        public int BAD_RACK { get; set; }
        public int TOTAL_TROUBLE { get; set; }
    }
    #endregion
    #region AgingRackData
    /// <summary>
    /// JSON base format : WinAgingRackSetting
    /// </summary>
    public class _aging_rack_data
    {
        public string AGING_TYPE { get; set; }
        public string LINE { get; set; }
        public string LANE { get; set; }
        public string RACK_ID { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public string STATUS { get; set; }
        public int PROCESS_NO { get; set; }
        public string FIRE_STATUS { get; set; }
        public string USE_FLAG { get; set; }
    }
    #endregion
    #region WinFormationBox
    /// <summary>
    /// JSON base format : WinFormationBox
    /// </summary>
    public class _win_formation_box : _win_manage_eqp
    {
        public string UNIT_ID { get; set; }
        public string PROCESS_STATUS { get; set; }
        public string USE_FLAG { get; set; }
        public string RECIPE_ID { get; set; }
    }
    #endregion
    #region WinFormationHPC
    /// <summary>
    /// JSON base format : WinFormationBox
    /// </summary>
    public class _win_formation_hpc : _win_manage_eqp
    {
        public string UNIT_ID { get; set; }
    }
    #endregion
    #region CtrlFormationCHG
    /// <summary>
    /// JSON base format : CtrlFormationCHG
    /// </summary>
    public class _ctrl_formation_chg : _dat_temp_unit
    {
        public string EQP_NAME { get; set; }
        public string EQP_NAME_LOCAL { get; set; }
        public string PROCESS_STATUS { get; set; }
        public int OPERATION_MODE { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
    }
    #endregion
    #region CtrlFormationHPC
    /// <summary>
    /// JSON base format : CtrlFormationHPC
    /// </summary>
    public class _ctrl_formation_hpc : _dat_temp_hpc
    {
        public string EQP_NAME { get; set; }
        public string EQP_NAME_LOCAL { get; set; }
        public string EQP_MODE { get; set; }
        public string EQP_STATUS { get; set; }
        public int OPERATION_MODE { get; set; }
        public string PROCESS_NAME { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
        public string TROUBLE_CODE { get; set; }
        public string TROUBLE_NAME { get; set; }

    }
    #endregion
    #region CtrlFormationHPCTemp
    /// <summary>
    /// JSON base format : CtrlFormationHPCTemp
    /// </summary>
    public class _ctrl_formation_hpc_temp
    {
        public string UNIT_ID { get; set; }
        public string TRAY_ID { get; set; }
        public string CELL_NO { get; set; }
        public string CELL_ID { get; set; }
        public DateTime EVENT_TIME { get; set; }
        public float JIG_AVG { get; set; }

    }
    #endregion
    #region EntireEqpList
    /// <summary>
    /// JSON base format : EntireEqp
    /// </summary>
    public class _entire_eqp_list
    {
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string EQP_MODE { get; set; }
        public string EQP_STATUS { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public string LEVEL { get; set; }
        public string REWORK_FLAG { get; set; }

    }
    #endregion
    #region UserAuthority
    /// <summary>
    /// JSON base format : UserAuthority
    /// </summary>
    public class _user_authority
    {
        public string USER_ID { get; set; }
        public string WINDOW_ID { get; set; }
        public string AUTH_VIEW { get; set; }
        public string AUTH_SAVE { get; set; }
        public string WINDOW_NAME { get; set; }
        public string WINDOW_NAME_LOCAL { get; set; }
        public string DEFAULT_CLASS_ID { get; set; }

    }
    #endregion
    #region TroubleEquipmentList
    /// <summary>
    /// JSON base format : TroubleEquipmentList
    /// </summary>
    public class _trouble_equipment_list
    {
        public int ID { get; set; }
        public string EQP_ID{ get; set; }
        public string EQP_STATUS { get; set; }
        public string EQP_NAME { get; set; }
        public string EQP_NAME_LOCAL { get; set; }
        public string EQP_TROUBLE_CODE { get; set; }
        public string TROUBLE_CATEGORY { get; set; }
        public string TROUBLE_NAME { get; set; }
        public string TROUBLE_NAME_LOCAL { get; set; }
    }
    #endregion
    #region TroubleAgingList
    /// <summary>
    /// JSON base format : TroubleAgingList
    /// </summary>
    public class _trouble_aging_list
    {
        public string AGING_TYPE { get; set; }
        public string LINE { get; set; }
        public string LANE { get; set; }
        public string BAY { get; set; }
        public string FLOOR { get; set; }
        public string RACK_ID { get; set; }
        public string STATUS { get; set; }
        public string TROUBLE_CODE { get; set; }
        public string TROUBLE_CATEGORY { get; set; }
        public string TROUBLE_NAME { get; set; }
        public string TROUBLE_NAME_LOCAL { get; set; }
    }
    #endregion
    #region TroubleInfo
    /// <summary>
    /// JSON base format : TroubleAgingList
    /// </summary>
    public class _trouble_info : _dat_trouble
    {
        public string TROUBLE_NAME { get; set; }
        public string TROUBLE_NAME_LOCAL { get; set; }
    }
    #endregion

    #region _rework_tray
    /// <summary>
    /// JSON base format : _rework_tray
    /// </summary>
    public class _rework_tray
    {
        public string TRAY_ID { get; set; }
        public string REWORK_FLAG { get; set; }
    }
    #endregion
}