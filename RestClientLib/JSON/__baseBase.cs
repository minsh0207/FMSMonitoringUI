﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RestClientLib
{
    /// <summary>
    /// JSON base format : Request
    /// </summary>  
    public class __baseRequest
    {
        public __baseRequest() { }
        ~__baseRequest() { }

        public string ROW_COUNT { get; set; }

        public string ACTION_ID { get; set; }

        public string REQUEST_TIME { get; set; }
    }

    /// <summary>
    /// JSON base format : Response
    /// </summary>    
    public class _baseResponse
    {
        public _baseResponse() { }
        ~_baseResponse() { }

        public string ROW_COUNT { get; set; }

        public string ACTION_ID { get; set; }

        public string RESPONSE_TIME { get; set; }

        public string RESPONSE_CODE { get; set; }

        public string RESPONSE_MESSAGE { get; set; }

        public string PROCESSING_TIME { get; set; }
    }

    /// <summary>
    /// JSON base format : Tray ID List
    /// </summary>  
    public class _tray_list
    {
        public _tray_list() { }
        ~_tray_list() { }

        public string TRAY_ID_1 { get; set; }
        public string TRAY_ID_2 { get; set; }
    }

    /// <summary>
    /// JSON base format : Recipe Data
    /// </summary>  
    public class _recipe_data
    {
        public _recipe_data() { }
        ~_recipe_data() { }

        public string RECIPE_ID { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public string NEXT_PROCESS_EXIST { get; set; }
        public string OPERATION_MODE { get; set; }

        //public Dictionary<string, object> RECIPE_ITEM;
        public List<_recipe_item> RECIPE_ITEM;
    }

    public class _recipe_item
    {
        public string NAME { get; set; }
        public string VALUE { get; set; }
        public string UNIT { get; set; }
    }


    /// <summary>
    /// JSON base format : Processing Data
    /// </summary>  
    public class _processing_data
    {
        public _processing_data() { }
        ~_processing_data() { }

        public string TRAY_ID { get; set; }
        public int PROCESSING_NO { get; set; }
        public string ROUTE_ID { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string RECIPE_ID { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }

        public string PROCESS_START_TIME { get; set; }
        public string PROCESS_END_TIME { get; set; }
        public int CELL_COUNT { get; set; }

        public List<_cell_data_request> CELL_DATA;

        public Dictionary<string, object> RESULT_DATA;
    }


    /// <summary>
    /// JSON base format : Processing Data
    /// </summary>  
    public class _cell_data_request
    {
        public _cell_data_request() { }
        ~_cell_data_request() { }

        public int CELL_POSITION { get; set; }
        public string CELL_EXIST { get; set; }
        public string CELL_ID { get; set; }
        public string LOT_ID { get; set; }

        // 이하 Response에서 사용
        public string JUDGE { get; set; }
        public string JUDGE_REASON_CODE { get; set; }
        public string DEFECT_TYPE { get; set; }

        public string RESULT_DATA { get; set; }
    }

    #region tb_dat_tray
    /// <summary>
    /// JSON base format : tb_dat_tray
    /// </summary>
    public class _dat_tray
    {
        public string TRAY_ID { get; set; }
        public string TRAY_STATUS { get; set; }
        public string TRAY_ZONE { get; set; }
        public string TRAY_GRADE { get; set; }
        public string TRAY_INPUT_TIME { get; set; }
        public string TRAY_INPUT_EQP_ID { get; set; }
        public int TRAY_INPUT_CELL_CNT { get; set; }
        public int CURRENT_CELL_CNT { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string LOT_ID { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string UNIT_ID_LEVEL { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public string START_TIME { get; set; }
        public string END_TIME { get; set; }
        public string PLAN_TIME { get; set; }
        public string NEXT_MANUAL_SET_FLAG { get; set; }
        public string NEXT_EQP_TYPE { get; set; }
        public string NEXT_PROCESS_TYPE { get; set; }
        public int NEXT_PROCESS_NO { get; set; }
        public string NEXT_EQP_ID { get; set; }
        public string NEXT_UNIT_ID { get; set; }
        public string REWORK_FLAG { get; set; }
        public string REWORK_USER { get; set; }
        public string REWORK_TIME { get; set; }
        public string REWORK_EQP_ID { get; set; }
        public string REWORK_UNIT_ID { get; set; }
        public string FIRE_FLAG { get; set; }
        public string FIRE_TIME { get; set; }
        public string FIRE_EQP_ID { get; set; }
        public string FIRE_UNIT_ID { get; set; }
        public string RECIPE_ID { get; set; }
        public string JSON_RECIPE { get; set; }
        public string JSON_PROCESS_DATA { get; set; }
        public string JSON_PROCESS_START_DATA { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_cell
    /// <summary>
    /// JSON base format : tb_dat_cell
    /// </summary>
    public class _dat_cell
    {
        public string CELL_ID { get; set; }
        public string TRAY_ID { get; set; }
        public int CELL_NO { get; set; }
        public DateTime TRAY_INPUT_TIME { get; set; }
        public string TRAY_INPUT_EQP_ID { get; set; }
        public string PREV_TRAY_ID { get; set; }
        public int PREV_CELL_NO { get; set; }
        public DateTime PREV_TRAY_INPUT_TIME { get; set; }
        public string PREV_TRAY_INPUT_EQP_ID { get; set; }
        public string GRADE { get; set; }
        public string GRADE_CODE { get; set; }
        public string GRADE_NG_TYPE { get; set; }
        public string GRADE_DEFECT_TYPE { get; set; }
        public string GRADE_EQP_TYPE { get; set; }
        public string GRADE_PROCESS_TYPE { get; set; }
        public int GRADE_PROCESS_NO { get; set; }
        public int GRADE_STEP_NO { get; set; }
        public string GRADE_EQP_ID { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string LOT_ID { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public int UNIT_ID_LEVEL { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public string REWORK_FLAG { get; set; }
        public DateTime REWORK_TIME { get; set; }
        public string REWORK_EQP_ID { get; set; }
        public string REWORK_UNIT_ID { get; set; }
        public string FIRE_FLAG { get; set; }
        public DateTime FIRE_TIME { get; set; }
        public string FIRE_EQP_ID { get; set; }
        public string FIRE_UNIT_ID { get; set; }
        public string SCRAP_FLAG { get; set; }
        public string SCRAP_USER { get; set; }
        public DateTime SCRAP_TIME { get; set; }
        public string RECIPE_ID { get; set; }
        public string JSON_RECIPE { get; set; }
        public string JSON_PROCESS_DATA { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_cell_proc
    /// <summary>
    /// JSON base format : tb_dat_cell_process
    /// </summary>
    public class _dat_cell_proc
    {
        public int ID { get; set; }
        public string CELL_ID { get; set; }
        public string IN_TRAY_ID { get; set; }
        public int IN_CELL_NO { get; set; }
        public string IN_TRAY_INPUT_TIME { get; set; }
        public string IN_TRAY_INPUT_EQP_ID { get; set; }
        public string OUT_TRAY_ID { get; set; }
        public int OUT_CELL_NO { get; set; }
        public string OUT_TRAY_INPUT_TIME { get; set; }
        public string OUT_TRAY_INPUT_EQP_ID { get; set; }
        public string GRADE { get; set; }
        public string GRADE_CODE { get; set; }
        public string GRADE_DEFECT_TYPE { get; set; }
        public string GRADE_EQP_TYPE { get; set; }
        public string GRADE_PROCESS_TYPE { get; set; }
        public int GRADE_PROCESS_NO { get; set; }
        public int GRADE_STEP_NO { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string LOT_ID { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public int UNIT_ID_LEVEL { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public string START_TIME { get; set; }
        public string END_TIME { get; set; }
        public string REWORK_FLAG { get; set; }
        public string REWORK_TIME { get; set; }
        public string REWORK_EQP_ID { get; set; }
        public string REWORK_UNIT_ID { get; set; }
        public string FIRE_FLAG { get; set; }
        public string FIRE_TIME { get; set; }
        public string FIRE_EQP_ID { get; set; }
        public string FIRE_UNIT_ID { get; set; }
        public string SCRAP_FLAG { get; set; }
        public string SCRAP_USER { get; set; }
        public string SCRAP_TIME { get; set; }
        public string RECIPE_ID { get; set; }
        public string JSON_RECIPE { get; set; }
        public string JSON_PROCESS_DATA { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_lot
    /// <summary>
    /// JSON base format : tb_dat_lot
    /// </summary>
    public class _dat_lot
    {
        public string LOT_ID { get; set; }
        public string MODEL_ID { get; set; }
        public string PART_ID { get; set; }
        public string IN_START_TIME { get; set; }
        public string IN_END_TIME { get; set; }
        public int IN_TRAY_CNT { get; set; }
        public int IN_CELL_CNT { get; set; }
        public string OUT_START_TIME { get; set; }
        public string OUT_END_TIME { get; set; }
        public int OUT_TRAY_CNT { get; set; }
        public int OUT_CELL_CNT { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_process_data
    /// <summary>
    /// JSON base format : tb_dat_process_data
    /// </summary>
    public class _dat_process_data
    {
        public string CELL_ID { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public string EVENT_TIME { get; set; }
        public string GRADE { get; set; }
        public string GRADE_CODE { get; set; }
        public string RECIPE_ID { get; set; }
        public string JSON_RECIPE { get; set; }
        public string JSON_PROCESS_DATA { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_status_eqp
    /// <summary>
    /// JSON base format : tb_dat_status_eqp
    /// </summary>
    public class _dat_status_eqp
    {
        public string EQP_TYPE { get; set; }
        public string EQP_ID { get; set; }
        public string EVENT_TIME { get; set; }
        public string EQP_MODE { get; set; }
        public string EQP_STATUS { get; set; }
        public float EQP_TEMP { get; set; }
        public string TRAY_IDS { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_status_unit
    /// <summary>
    /// JSON base format : tb_dat_status_unit
    /// </summary>
    public class _dat_status_unit
    {
        public string EQP_TYPE { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string EVENT_TIME { get; set; }
        public string UNIT_MODE { get; set; }
        public string UNIT_STATUS { get; set; }
        public float UNIT_TEMP { get; set; }
        public string TRAY_IDS { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_temp_hpc
    /// <summary>
    /// JSON base format : tb_dat_temp_hpc
    /// </summary>
    public class _dat_temp_hpc
    {
        public string EQP_TYPE { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string EVENT_TIME { get; set; }
        public string TRAY_ID { get; set; }
        public float PRESSURE { get; set; }
        public float JIG_01 { get; set; }
        public float JIG_02 { get; set; }
        public float JIG_03 { get; set; }
        public float JIG_04 { get; set; }
        public float JIG_05 { get; set; }
        public float JIG_06 { get; set; }
        public float JIG_07 { get; set; }
        public float JIG_08 { get; set; }
        public float JIG_09 { get; set; }
        public float JIG_10 { get; set; }
        public float JIG_11 { get; set; }
        public float JIG_12 { get; set; }
        public float JIG_13 { get; set; }
        public float JIG_14 { get; set; }
        public float JIG_15 { get; set; }
        public float JIG_16 { get; set; }
        public float JIG_17 { get; set; }
        public float JIG_18 { get; set; }
        public float JIG_19 { get; set; }
        public float JIG_20 { get; set; }
        public float JIG_21 { get; set; }
        public float JIG_22 { get; set; }
        public float JIG_23 { get; set; }
        public float JIG_24 { get; set; }
        public float JIG_25 { get; set; }
        public float JIG_26 { get; set; }
        public float JIG_27 { get; set; }
        public float JIG_28 { get; set; }
        public float JIG_29 { get; set; }
        public float JIG_30 { get; set; }
        public float JIG_AVG { get; set; }
    }
    #endregion
    #region tb_dat_temp_unit
    /// <summary>
    /// JSON base format : tb_dat_temp_unit
    /// </summary>
    public class _dat_temp_unit
    {
        public string EQP_TYPE { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string EVENT_TIME { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public float JIG_11 { get; set; }
        public float JIG_12 { get; set; }
        public float JIG_13 { get; set; }
        public float JIG_14 { get; set; }
        public float JIG_15 { get; set; }
        public float JIG_16 { get; set; }
        public float JIG_17 { get; set; }
        public float JIG_18 { get; set; }
        public float JIG_21 { get; set; }
        public float JIG_22 { get; set; }
        public float JIG_23 { get; set; }
        public float JIG_24 { get; set; }
        public float JIG_25 { get; set; }
        public float JIG_26 { get; set; }
        public float JIG_27 { get; set; }
        public float JIG_28 { get; set; }
        public float JIG_AVG { get; set; }
    }
    #endregion
    #region tb_dat_tray_proc
    /// <summary>
    /// JSON base format : tb_dat_tray_proc
    /// </summary>
    public class _dat_tray_proc
    {
        public int ID { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_STATUS { get; set; }
        public string TRAY_ZONE { get; set; }
        public string TRAY_GRADE { get; set; }
        public string TRAY_INPUT_TIME { get; set; }
        public string TRAY_INPUT_EQP_ID { get; set; }
        public int TRAY_INPUT_CELL_CNT { get; set; }
        public int CURRENT_CELL_CNT { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string LOT_ID { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string UNIT_ID_LEVEL { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public string START_TIME { get; set; }
        public string END_TIME { get; set; }
        public string PLAN_TIME { get; set; }
        public string NEXT_MANUAL_SET_FLAG { get; set; }
        public string NEXT_EQP_TYPE { get; set; }
        public string NEXT_PROCESS_TYPE { get; set; }
        public int NEXT_PROCESS_NO { get; set; }
        public string NEXT_EQP_ID { get; set; }
        public string NEXT_UNIT_ID { get; set; }
        public string REWORK_FLAG { get; set; }
        public string REWORK_USER { get; set; }
        public string REWORK_TIME { get; set; }
        public string REWORK_EQP_ID { get; set; }
        public string REWORK_UNIT_ID { get; set; }
        public string FIRE_FLAG { get; set; }
        public string FIRE_TIME { get; set; }
        public string FIRE_EQP_ID { get; set; }
        public string FIRE_UNIT_ID { get; set; }
        public string RECIPE_ID { get; set; }
        public string JSON_RECIPE { get; set; }
        public string JSON_PROCESS_DATA { get; set; }
        public string JSON_PROCESS_START_DATA { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_dat_trouble
    /// <summary>
    /// JSON base format : tb_dat_trouble
    /// </summary>
    public class _dat_trouble
    {
        public string EQP_TYPE { get; set; }
        public string TROUBLE_CATEGORY { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public DateTime EVENT_TIME { get; set; }
        public string TROUBLE_CODE { get; set; }
        public string TROUBLE_REMARK { get; set; }
        public string USER_ACTION { get; set; }
        public DateTime USER_ACTION_TIME { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_Aging
    /// <summary>
    /// JSON base format : tb_mst_Aging
    /// </summary>
    public class _mst_Aging
    {
        public string AGING_TYPE { get; set; }
        public string LINE { get; set; }
        public string LANE { get; set; }
        public string BAY { get; set; }
        public string DECK { get; set; }
        public string RACK_ID { get; set; }
        public string USE_FLAG { get; set; }
        public string STATUS { get; set; }
        public int TROUBLE_CODE { get; set; }
        public string START_TIME { get; set; }
        public string END_TIME { get; set; }
        public string PLAN_TIME { get; set; }
        public int TRAY_CNT { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public int AGING_TIME { get; set; }
        public string FORCE_OUT_FLAG { get; set; }
        public string FORCE_OUT_USER { get; set; }
        public string FORCE_OUT_TIME { get; set; }
        public string FIRE_STATUS { get; set; }
        public string FIRE_ENVETTIME { get; set; }
        public string RACK_TYPE { get; set; }
        public string IN_MODEL_ID { get; set; }
        public string IN_ROUTE_ID { get; set; }
        public string IN_EQP_TYPE { get; set; }
        public string IN_PROCESS_TYPE { get; set; }
        public int IN_PROCESS_NO { get; set; }
        public string IN_TRAY_ZONE { get; set; }
        public string IN_CELL_TYPE { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_eqp
    /// <summary>
    /// JSON base format : tb_mst_eqp
    /// </summary>
    public class _mst_eqp
    {
        public int ID { get; set; }
        public string EQP_TYPE { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string EQP_NAME { get; set; }
        public string EQP_NAME_LOCAL { get; set; }
        public string USE_FLAG { get; set; }
        public string EQP_MODE { get; set; }
        public string EQP_STATUS { get; set; }
        public string EQP_TROUBLE_CODE { get; set; }
        public float EQP_TEMP { get; set; }
        public string PROCESS_STATUS { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public int OPERATION_NO { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public DateTime PLAN_TIME { get; set; }
        public string FIRE_FLAG { get; set; }
        public DateTime FIRE_TIME { get; set; }
        public int GRIPPER_CNT { get; set; }
        public string IN_MODEL_ID { get; set; }
        public string IN_ROUTE_ID { get; set; }
        public string IN_EQP_TYPE { get; set; }
        public string IN_PROCESS_TYPE { get; set; }
        public int IN_PROCESS_NO { get; set; }
        public string IN_TRAY_ZONE { get; set; }
        public string IN_CELL_TYPE { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_eqp_type
    /// <summary>
    /// JSON base format : tb_mst_eqp_type
    /// </summary>
    public class _mst_eqp_type
    {
        public string EQP_TYPE { get; set; }
        public string EQP_TYPE_NAME { get; set; }
        public string EQP_TYPE_NAME_LOCAL { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_model
    /// <summary>
    /// JSON base format : tb_mst_model
    /// </summary>
    public class _mst_model
    {
        public string MODEL_ID { get; set; }
        public string MODEL_NAME { get; set; }
        public string CELL_TYPE { get; set; }
        public string CELL_SIZE { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_process_type
    /// <summary>
    /// JSON base format : tb_mst_process_type
    /// </summary>
    public class _mst_process_type
    {
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public string PROCESS_TYPE_NAME { get; set; }
        public string PROCESS_TYPE_NAME_LOCAL { get; set; }
        public string DESCR { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_route
    /// <summary>
    /// JSON base format : tb_mst_route
    /// </summary>
    public class _mst_route
    {
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string IS_MASTER_ROUTE { get; set; }
        public string ROUTE_NAME { get; set; }
        public string ROUTE_TYPE { get; set; }
        public string JSON_DATA { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_route_hist
    /// <summary>
    /// JSON base format : tb_mst_route_hist
    /// </summary>
    public class _mst_route_hist
    {
        public int ID { get; set; }
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public string IS_MASTER_ROUTE { get; set; }
        public string ROUTE_NAME { get; set; }
        public string ROUTE_TYPE { get; set; }
        public string JSON_DATA { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_route_order
    /// <summary>
    /// JSON base format : tb_mst_route_order
    /// </summary>
    public class _mst_route_order
    {
        public string MODEL_ID { get; set; }
        public string ROUTE_ID { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string EQP_TYPE { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public string PROCESS_NAME { get; set; }
        public string PROCESS_NAME_LOCAL { get; set; }
        public string IS_MASTER_RECIPE { get; set; }
        public string RECIPE_ID { get; set; }
        public string JSON_RECIPE { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_trouble
    /// <summary>
    /// JSON base format : tb_mst_trouble
    /// </summary>
    public class _mst_trouble
    {
        public string EQP_TYPE { get; set; }
        public string TROUBLE_CATEGORY { get; set; }
        public string TROUBLE_CODE { get; set; }
        public string TROUBLE_LEVEL { get; set; }
        public string TROUBLE_NAME { get; set; }
        public string TROUBLE_NAME_LOCAL { get; set; }
        public string USER_ACTION { get; set; }
        public string USER_ACTION_LOCAL { get; set; }
        public DateTime UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_unit
    /// <summary>
    /// JSON base format : tb_mst_unit
    /// </summary>
    public class _mst_unit
    {
        public string EQP_TYPE { get; set; }
        public string EQP_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public string UNIT_NAME_LOCAL { get; set; }
        public string USE_FLAG { get; set; }
        public string UNIT_MODE { get; set; }
        public string UNIT_STATUS { get; set; }
        public float UNIT_TEMP { get; set; }
        public string PROCESS_STATUS { get; set; }
        public string TRAY_ID { get; set; }
        public string TRAY_ID_2 { get; set; }
        public int ROUTE_ORDER_NO { get; set; }
        public string PROCESS_TYPE { get; set; }
        public int PROCESS_NO { get; set; }
        public int STEP_NO { get; set; }
        public string START_TIME { get; set; }
        public string END_TIME { get; set; }
        public string PLAN_TIME { get; set; }
        public string FIRE_FLAG { get; set; }
        public string FIRE_TIME { get; set; }
        public int GRIPPER_CNT { get; set; }
        public string IN_MODEL_ID { get; set; }
        public string IN_ROUTE_ID { get; set; }
        public string IN_EQP_TYPE { get; set; }
        public string IN_PROCESS_TYPE { get; set; }
        public int IN_PROCESS_NO { get; set; }
        public string IN_TRAY_ZONE { get; set; }
        public string IN_CELL_TYPE { get; set; }
        public string UPDATE_USER { get; set; }
        public string UPDATE_TIME { get; set; }
        public string CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_user
    /// <summary>
    /// JSON base format : tb_mst_user
    /// </summary>
    public class _mst_user
    {
        public string USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_PASSWORD { get; set; }
        public string CLASS_ID { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_user_class
    /// <summary>
    /// JSON base format : tb_mst_user_class
    /// </summary>
    public class _mst_user_class
    {
        public string CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }
        public string CLASS_NAME_LOCAL { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_window
    /// <summary>
    /// JSON base format : tb_mst_window
    /// </summary>
    public class _mst_window
    {
        public string WINDOW_ID { get; set; }
        public string WINDOW_NAME { get; set; }
        public string WINDOW_NAME_LOCAL { get; set; }
        public string DEFAULT_CLASS_ID { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
    #region tb_mst_window_user
    /// <summary>
    /// JSON base format : tb_mst_window_user
    /// </summary>
    public class _mst_window_user
    {
        public string USER_ID { get; set; }
        public string WINDOW_ID { get; set; }
        public string AUTH_VIEW { get; set; }
        public string AUTH_SAVE { get; set; }
        public string UPDATE_USER { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }
    }
    #endregion
}