
namespace RunningEnv
{
    public enum LOGISTICS_TROUBLE_CODE
    {
        // MC Troubles until 502 
        MC_ERROR = 0
        , EMERGENCY

        , CONVEYOR_TRIP = 3
        , DIVERTER_TRIP
        , TRAY_ABNORMAL
        , TRAY_JAM
        , FORK_DETECT
        , OUT_MEMORY
        , TRAY_POS_ABNORMAL
        
        , AIR_DROP = 10

        , CV_FW_OVERTIME = 15
        , CV_BW_OVERTIME
        , DIV_FW_OVERTIME
        , DIV_BW_OVERTIME

        , STP_UP_OVERTIME = 22
        , STP_DN_OVERTIME

        , SIDE_STP_UP_OVERTIME = 26
        , SIDE_STP_DN_OVERTIME

        , DIV_UP_OVERTIME = 30
        , DIV_DN_OVERTIME

        , TURN_TBL_BCR_CYL_FW_OVERTIME = 34
        , TURN_TBL_BCR_CYL_BW_OVERTIME
        , CHAM_CYL_TURN_GUIDE_FW_OVERTIME
        , CHAM_CYL_TURN_CUIDE_BW_OVERTIME
        , CHAM_CYL_MISS

        , LIFT_UP_LIMIT = 40
        , LIFT_DN_LIMIT
        , LIFT_CHAIN_CUT

        , DATA_MISSING = 45
        , STOP_OVERTIME

        , POSITION_COUNT_1 = 101
        , POSITION_COUNT_2
        , POSITION_COUNT_3
        , POSITION_COUNT_4
        , SOCKET_COMM_1
        , SOCKET_COMM_2
        , SOCKET_COMM_3
        , SOCKET_COMM_4
        , SOCKET_COMM_5
        , SOCKET_COMM_6
        , START_POSITION

        , LIFT_FW_OVERTIME = 115
        , LIFT_BW_OVERTIME

        , HOME_SRCH_UNCOMPLETE = 150

        , POWERMOLER = 501
        , DIVERTER_INVERTER

        // HOST Troubles from 9900
        , GENERAL_HOST_TROUBLE = 9900

        // PLC
        , PLC_READ_ERROR                    // PLC Reading error
        , PLC_WRITE_ERROR                   // PLC Writing error
        
        // TRAY ID
        , TRAY_ID_NOT_FOUND = 9910          // TrayID not found in DB
        , TRAY_INFORMATION_ERROR            // TrayID 로 DB 조회하였으나 기본 정보가 없음 (다음 공정, 3종세트, 라인 등)
        , TRAY_IS_EMPTY                     // Empty 가 아니어야 하는데 Empty 임
        , TRAY_IS_FULL                      // Full 이 아니어야 하는데 Full 임
        , TRAY_DESTINATION_NOT_FOUND        // TrayID 목적지를 찾을 수 없음
        , TRAY_ID_LENGTH_INVALID            // TrayID 길이가 invalid (짧거나 길거나, 16 자리이어야 함)
        , TRAY_PREV_PROC_NOT_FINISHED       // 이전 공정이 제대로 종료되지 않았음
        , TRAY_TROUBLE                      // Tray 가 Trouble 상태이다 (tTrayCurr Columns - Status)
        , TRAY_ID_MISMATCH_LINE             // tTrayCurr 의 LineID 와 TrayID 의 5번째 정보가 맞지않음
        , TRAY_WAITING

        // CRANE
        , JOB_COMPLETE_REPORT_ERROR = 9920  // Crane 에서 작업완료 보고 에러 (REST 오류)
        , JOB_DELETE_REPORT_ERROR           // Crane 에서 작업삭제 보고 에러 (REST 오류)
        , JOB_EMPTYOUT_REPORT_ERROR         // Crane 에서 공출고 보고 에러 (REST 오류)
        , JOB_DOUBLEIN_REPORT_ERROR         // Crane 에서 이중입고 보고 에러 (REST 오류)
        , FIRE_WATER_TANK_NOT_REARY         // 염수통에 트레이를 넣을 수 없음 (화재는 발생했는데 넣을 염수통이 준비가 안되어서)
        , FIRE_RESTOCK_RACK_NOT_FOUND       // 염수통에서 재입고 요청이 왔는데, 재입고 할 Rack 이 없음 (3종 세트 맞는게 없겠지...)
        , JOB_DOUBLEIN_ERROR                // 이중입고시 이벤트 발생
        , JOB_EMPTYOUT_ERROR                // 공출고 이벤트 발생


        // BCR
        , BCR_READ_FAILED  = 9930           // BCR 읽기 실패
        , BCR_CONNECTION_ERROR              // BCR 에 TCP 로 연결하는데 실패했음
        , BCR_FAIL_NO_OUT_SITE              // BCR 읽기 실패했는데, RetryBCRNo 도 없고, 강제 배출도 정해지지 않아서 제자리에서 PLC 로 HostTrouble 준다

        // REST
        , REST_CALL_ERROR = 9940            // REST 호출 자체에 문제가 있음
        , REST_RETURN_ERROR                 // REST 호출은 정상이나 실행에 문제가 있음

        // BIZ
        , BIZ_ERROR = 9950
        , FIRE_WATER_HAS_NO_TRAYID          // 염수통 재입고 시에 거기 있던 TrayID 를 염수통 ObjectID 로 tMstEquipment 에서 찾아 보았으나, TrayID 가 없다.

        // ASSEMBLY PLC DATA
        , TRAYID_ERROR = 9960
        , MODEL_ERROR
        , LOTID_ERROR
        , CELLTYPE_ERROR
        , CELLSIZE_ERROR
        , FORMATION_LINE_ERROR
        , TRAYTYPE_ERROR
        , CELLCOUNT_ERROR
        , CELLEXISTINFO_ERROR
        , CELLID_ERROR
        , CELLCOUNT_ID_MISMATCH_ERROR

        // ASSEMBLY DATA REPORT
        , SP_FORMATION_INPUT_ERROR      // spFormationInput 실행 오류 
        , SP_PROCWORK_INDEX_ASM_ERROR   // spProcWorkIndex_CellProAssembly 실행 오류
        , INSERT_CELLPROASSEMBLY_ERROR  // tCellProAssembly 데이터 INSERT 에러

        //20190720 KJY log 더 디테일하게... 
        , TRAYID_EMPTY
        , TRAYID_LENGTH_ERROR
        , TRAY_NOT_REGISTERED
        , NOT_EMPTY_TRAY
        , CELLID_DUIPLICATION

        //20191101 KJY
        , MODELID_NOT_EXIST  // 화성라인에 없는 ProdModel
        , ROUTEID_NOT_EXIST  // 화성라인에 없는 RouteID


        //20191111 KJY
        , TRAYID_IN_EQP   // TrayID가 tMstEquipment 에 들어있다.
        , TRAYID_IN_AGING_RACK //TrayID가  tMstAgingRack에 들어있다.

        //20220211 KJY
        , SP_MES_INSERT_REQUEST_ENTRY_ERROR // spMesInsertRequestEntry 호출에러

        // Cell ID 화성라인 중복
        , CELLID_DUPLICATION_CH_01 = 10001
        , CELLID_DUPLICATION_CH_02
        , CELLID_DUPLICATION_CH_03
        , CELLID_DUPLICATION_CH_04
        , CELLID_DUPLICATION_CH_05
        , CELLID_DUPLICATION_CH_06
        , CELLID_DUPLICATION_CH_07
        , CELLID_DUPLICATION_CH_08
        , CELLID_DUPLICATION_CH_09
        , CELLID_DUPLICATION_CH_10
        , CELLID_DUPLICATION_CH_11
        , CELLID_DUPLICATION_CH_12
        , CELLID_DUPLICATION_CH_13
        , CELLID_DUPLICATION_CH_14
        , CELLID_DUPLICATION_CH_15
        , CELLID_DUPLICATION_CH_16
        , CELLID_DUPLICATION_CH_17
        , CELLID_DUPLICATION_CH_18
        , CELLID_DUPLICATION_CH_19
        , CELLID_DUPLICATION_CH_20
        , CELLID_DUPLICATION_CH_21
        , CELLID_DUPLICATION_CH_22
        , CELLID_DUPLICATION_CH_23
        , CELLID_DUPLICATION_CH_24
        , CELLID_DUPLICATION_CH_25
        , CELLID_DUPLICATION_CH_26
        , CELLID_DUPLICATION_CH_27
        , CELLID_DUPLICATION_CH_28
        , CELLID_DUPLICATION_CH_29
        , CELLID_DUPLICATION_CH_30
        , CELLID_DUPLICATION_CH_31
        , CELLID_DUPLICATION_CH_32
        , CELLID_DUPLICATION_CH_33
        , CELLID_DUPLICATION_CH_34
        , CELLID_DUPLICATION_CH_35
        , CELLID_DUPLICATION_CH_36
        // 채널별 셀 데이터 에러 (3가지 값중 하나라도 0 이면 Trouble) 
        , CELL_DATA_ERROR_CH_01 = 10101
        , CELL_DATA_ERROR_CH_02
        , CELL_DATA_ERROR_CH_03
        , CELL_DATA_ERROR_CH_04
        , CELL_DATA_ERROR_CH_05
        , CELL_DATA_ERROR_CH_06
        , CELL_DATA_ERROR_CH_07
        , CELL_DATA_ERROR_CH_08
        , CELL_DATA_ERROR_CH_09
        , CELL_DATA_ERROR_CH_10
        , CELL_DATA_ERROR_CH_11
        , CELL_DATA_ERROR_CH_12
        , CELL_DATA_ERROR_CH_13
        , CELL_DATA_ERROR_CH_14
        , CELL_DATA_ERROR_CH_15
        , CELL_DATA_ERROR_CH_16
        , CELL_DATA_ERROR_CH_17
        , CELL_DATA_ERROR_CH_18
        , CELL_DATA_ERROR_CH_19
        , CELL_DATA_ERROR_CH_20
        , CELL_DATA_ERROR_CH_21
        , CELL_DATA_ERROR_CH_22
        , CELL_DATA_ERROR_CH_23
        , CELL_DATA_ERROR_CH_24
        , CELL_DATA_ERROR_CH_25
        , CELL_DATA_ERROR_CH_26
        , CELL_DATA_ERROR_CH_27
        , CELL_DATA_ERROR_CH_28
        , CELL_DATA_ERROR_CH_29
        , CELL_DATA_ERROR_CH_30
        , CELL_DATA_ERROR_CH_31
        , CELL_DATA_ERROR_CH_32
        , CELL_DATA_ERROR_CH_33
        , CELL_DATA_ERROR_CH_34
        , CELL_DATA_ERROR_CH_35
        , CELL_DATA_ERROR_CH_36

    }

    public enum CRANE_TROUBLE_CODE
    {
        ECP_Communication_Delay_ALARM = 1
        , SC_CC_LINK_ERROR = 2
        , SC_Laser_Communication = 3
        , ECP_TROUBLE_CODE_ERROR = 4
        , PLC_Battry_Change_Req = 5
        , ST_CV_Pos_Load_Fail = 6
        , ST_CV_Pos_UnLoad_Fail = 7
        , Command_DATA_ERROR = 9
        , SC_Run_Inverter_ERROR = 10
        , Home_REQ_ERROR = 11
        , SC_Run_FW_OVERRUN = 12
        , SC_Run_BW_OVERRUN = 13
        , SC_Run_Time_Over = 14
        , SC_Laser_Intercepted = 15
        , SC_Run_Encoder_ERROR = 16
        , SCC_Stop = 18
        , SRC_Stop = 19
        , SC_Elev_Inverter_ERROR = 20
        , SC_Elev_Up_OVERRUN = 22
        , SC_Elev_Down_OVERRUN = 23
        , SC_Elev_Time_Over_ERROR = 24
        , SC_Elev_Encoder_ERROR = 26
        , SC_Left_TRAY_Protect_ERROR = 27
        , SC_Right_TRAY_Protect_ERROR = 28
        , SC_WIRE_CUT_ERROR = 29
        , SC_FORK_Inverter_ERROR = 30
        , SC_FORK_TimeOver_ERROR = 33
        , SC_FORK_Encoder_ERROR = 35
        , SC_Run_Inverter_Speed_Conf_ERROR = 39
        , SC_Elev_Inverter_Speed_Conf_ERROR = 40
        , SC_Fork_Inverter_Speed_Conf_ERROR = 41
        , SC_Elev_Counter_ERROR = 43
        , SC_Run_Counter_ERROR = 44
        , SC_Run_Location_ERROR = 46
        , SC_Elev_Location_ERROR = 47
        , SC_FORK_Location_ERROR = 48
        , SC_Double_In = 50
        , SC_Empty_Out = 51
        , SC_Manual_Task = 52
        , Line_Command_ERROR = 57
        , Bay_Command_ERROR = 58
        , Floor_Command_ERROR = 59
        , SC_Time_Over_ERROR = 69
        , SC_SafeDoor_OPEN = 77
        , SC_CenterPath_OPEN = 78
        , SC_FireWall_ERROR = 80
        , ECP_Host_Communication_ERROR = 101
        , ECP_Command_DATA_ERROR = 102
        , ECP_TROUBLE = 103
        , SCF_Run_Control_Stop_ERROR = 104
        , SCF_Elev_Control_Stop_ERROR = 105
        , SCF_Rack_Load_Fail_ERROR = 106
        , SCF_Rack_Unload_Fail_ERROR = 107
        , SCF_PLC_Battry_Change_Req = 108
        , SCF_Run_SERVO_ERROR = 110
        , SCF_Run_ENCODER_ERROR = 111
        , SCF_RunFW_OVERRUN_ERROR = 112
        , SCF_RunBW_OVERRUN_ERROR = 113
        , SCF_PathSensor_ERROR = 115
        , SCF_Light_Comm_ERROR = 116
        , SCF_Elev_MCCB_Off = 117
        , SCF_SCC_Stop = 118
        , SCF_SRC_Stop = 119
        , SCF_Elev_SERVO_ERROR = 120
        , SCF_Elev_UP_OVERRUN_ERROR = 122
        , SCF_Elev_Down_OVERRUN_ERROR = 123
        , SCF_Elev_WIRE_TENSION_ERROR = 125
        , SCF_FORK_TRAY_Arrival_ERROR = 126
        , SCF_Left_TRAY_Protect_ERROR = 127
        , SCF_Right_TRAY_Protect_ERROR = 128
        , SCF_Fire_SHUTTER_ERROR = 129
        , SCF_FORK_SERVO_ERROR = 130
        , SCF_RightFORK_OVERRUN_ERROR = 131
        , SCF_LeftFORK_OVERRUN_ERROR = 132
        , SCF_Double_In_ERROR = 133
        , SCF_Empty_Out_ERROR = 134
        , SCF_CV_Load_Fail = 135
        , SCF_CV_Unload_Fail = 136
        , SCF_Center_Req_ERROR = 140
        , ECP_DATA_ERROR = 141
        , SCF_Elev_SERVO_OFF = 142
        , SCF_Run_SERVO_OFF = 143
        , SCF_FORK_SERVO_OFF = 144
        , SCF_SafeDoor_Open_ERR0R = 145
        , SCF_Run_OverTime_ERROR = 146
        , SCF_Elev_Act_OverTime_ERROR = 147
        , SCF_FORK_Act_OverTime_ERROR = 148
        , SCF_Act_OverTime_ERROR = 149
        , SCF_RunFW_OVERRUN = 152
        , SCF_RunBW_OVERRUN = 153
        , SCF_Load_Elev_Location_ERROR = 154
        , SCF_After_Load_Up_UpperLocation_ERROR = 155
        , Tray_In_Conveyor_Ready_ERROR = 163
        , SCF_SafeDoor_Open_ERROR = 173
        , SCF_Unload_Arrived_Elev_ERROR = 179
        , SCF_Unload_Elev_Location_ERROR = 180
        , Tray_Out_Conveyor_Ready_Error = 187
        , SCF_Unload_Elev_DownLocation_Error = 193
        , ECP_Host_JobComplete_Error = 198

    }

}
