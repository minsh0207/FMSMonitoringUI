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
        public string TRAY_ID { get; set; }
        public string LEVEL { get; set; }
        public string TROUBLE_CODE { get; set; }
        public string TROUBLE_NAME { get; set; }
        public DateTime TRAY_INPUT_TIME { get; set; }
        public string TRAY_ZONE { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string RECIPE_ID { get; set; }
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
        public float TEMP_AVG { get; set; }

    }
    #endregion
    #region CtrlFormationHPC
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
        public float TEMP_JIG { get; set; }

    }
    #endregion
}