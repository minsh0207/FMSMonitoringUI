//using AtemFMSAnfang.Global;
//using AtemOPCUAServer.FMS;
//using Opc.Ua;
using System;

namespace OPCUAClientClassLib
{
    [Serializable]
    public enum EnumTagType
    {
        Null = 0,        
        BOOLEAN,
        FOLDER,
        METHOD,
        WORD,
        UINT16 = 5,
        UINT32 = 7,
        nt64,
        UINT64,
        FLOAT = 10,
        DOUBLE,
        STRING = 12,
        OBJECT,
        DATETIME,
    }

    [Serializable]
    public enum EnumEqpType
    {
        /// <summary>
        /// Beginning Of Route Steps
        /// </summary>
        AAA = 0,

        /// <summary>
        /// Tray Input
        /// </summary>
        ASM,

        /// <summary>
        /// Pre-Charger
        /// </summary>
        PRE,
        /// <summary>
        /// Formation
        /// </summary>
        FOR,
        /// <summary>
        /// DCIR
        /// </summary>
        DCR,
        /// <summary>
        /// IR-OCV
        /// </summary>
        IRO,
        /// <summary>
        /// OCV
        /// </summary>
        OCV,

        /// <summary>
        /// Degas
        /// </summary>
        DGS,

        /// <summary>
        /// Aging Cooler
        /// </summary>
        AGC,
        /// <summary>
        /// RT Aging
        /// </summary>
        AGR,

        /// <summary>
        /// HT Aging
        /// </summary>
        AGH,

        /// <summary>
        /// Tray Clamper
        /// </summary>
        CLP,

        /// <summary>
        /// Tray Cleaner
        /// </summary>
        TCL,

        /// <summary>
        /// Tray Changer
        /// </summary>
        TCH,

        /// <summary>
        /// Cell Evaluation Step (Before SEL/GRD)
        /// </summary>
        EVL,
        /// <summary>
        /// NG SELECTOR
        /// </summary>
        SEL,
        /// <summary>
        /// Cell Grade Sorter
        /// </summary>
        GRD,

        /// <summary>
        /// BCR
        /// </summary>
        BCR,
        /// <summary>
        /// Sensor
        /// </summary>
        SEN,
        /// <summary>
        /// Conveyor
        /// </summary>
        CNV,
        /// <summary>
        /// Stacker Crane : Formation
        /// </summary>
        SCF,
        /// <summary>
        /// Stacker Crane : HT Aging
        /// </summary>
        SCH,
        /// <summary>
        /// Stacker Crane : RT Aging
        /// </summary>
        SCR,
        /// <summary>
        /// Stacker Crane : Cooling Aging
        /// </summary>
        SCC,

        /// <summary>
        /// EOL : Outgoing Inspection
        /// </summary>
        EOL,

        /// <summary>
        /// Packing (EOL)
        /// </summary>
        PAC,

        /// <summary>
        /// Fire Detector System
        /// </summary>
        EMS,

        /// <summary>
        /// End of Route Steps
        /// </summary>
        ZZZ = 999,

        /// <summary>
        /// FMS Eqp Type
        /// </summary>
        FMS
    }

    public static class EquipmentInformation
    {
        public static object GetEquipmentInformation(string parent_tag_name, string tag_name, string eqp_id)
        {
            switch (tag_name)
            {
                case "Equipment_ID":
                    return Settings.FMSEqpIdSeq++;

                case "Equipment_Name":
                    return eqp_id;
            }

            return null;
        }

    }

    public static class Settings
    {
        public static int MAX_CELL_COUNT = 30;

        public static UInt32 FMSEqpIdSeq = 1000;

        public static string FMSOPCServerURL { get; set; } = "";

        /// <summary>
        /// Realtime Data Cell Tag Name Template
        /// </summary>
        public static string SETTING_UI_REALTIME_CELL_TAG_NAME_FORMAT { get; set; } = "RealTime_Cell{0}";

        //    /// <summary>
        //    /// Result Data Cell Tag Name Template
        //    /// </summary>
        //    public static string SETTING_UI_CELL_TAG_NAME_FORMAT { get; set; } = "Cell{0}";

        /// <summary>
        /// Cell Tag Name Number Format
        /// </summary>
        public static string SETTING_UI_CELL_NO_FORMAT { get; set; } = "D2";

        //    /// <summary>
        //    /// Node Path Separator
        //    /// </summary>
        //    public static char SETTING_UI_NODE_PATH_SEPARATOR { get; set; } = '.';

        //    /// <summary>
        //    /// TagName for Alarm Event
        //    /// </summary>
        //    public static string SETTING_UI_ALARM_TAG_NAME { get; set; } = "ErrorNo";

        //    /// <summary>
        //    /// FMS Server 가 자동으로 Batch : True 인 것들을 outargs 로 하는 method 를 만든다 (BatchReportMethod)
        //    /// MES 는 이 Tag 를 모니터링 하다가 값이 쓰여지면 BatchReportMethod 를 호출해서 결과 데이터를 받아 간다.
        //    /// </summary>
        //    public static string SETTING_UI_BATCH_REPORT_INDICATOR_TAG_NAME = "BatchReport";

        //    /// <summary>
        //    /// FMs Server가 자동으로 RealTime_CellNN인 것들을 outargs 로 하는 Method 를 만든다. (RealTimeReportMethod)
        //    /// MES 는 이 Tag 를 모니터링 하다가 값이 쓰여지면 RealTimeReportMethod 를 호출해서 데이터를 받아 간다.
        //    /// </summary>
        //    public static string SETTING_UI_REALTIME_REPORT_INDICATOR_TAG_NAME = "RealTimeReport";

        //    /// <summary>
        //    /// Variable 을 만들 때, tag path 에 여기에 정해진 문자열("RealTime_") 이 있으면 realtime report 대상으로 포함시킨다.
        //    /// </summary>
        //    public static string SETTING_UI_REALTIME_TAG_MARKER = "RealTime_";

        //    /// <summary>
        //    /// MES User Id
        //    /// </summary>
        //    public static string SETTING_UI_MES_USER_ID { get; set; } = "mes";

        //    /// <summary>
        //    /// MES User Password
        //    /// </summary>
        //    public static string SETTING_UI_MES_USER_PW { get; set; } = "mes@!";

        //    /// <summary>
        //    /// AtemFMS Command Service Server Address
        //    /// </summary>
        //    public static string SETTING_UI_AtemFMSCmdServerAddress { get; set; } = GlobalSettings.ATEM_FMS_COMMAND_SERVER_URI;

        //    /// <summary>
        //    /// Historian Buffer Expiration in Seconds
        //    /// </summary>
        //    public static int SETTING_UI_HISTORY_BUFFER_EXPIRED_SEC { get; set; } = GlobalSettings.HISTORIAN_VALUE_KEEPING_DURATION_SEC;



        //    public static NodeId OPCDataTypeFromEnumTagType(EnumTagType t)
        //    {
        //        switch (t)
        //        {
        //            case EnumTagType.FOLDER:
        //                return DataTypeIds.ObjectNode;

        //            case EnumTagType.METHOD:
        //                return DataTypeIds.MethodNode;

        //            case EnumTagType.BOOLEAN:
        //                return DataTypeIds.Boolean;

        //            case EnumTagType.WORD:
        //                return DataTypeIds.UInt16;

        //            case EnumTagType.INT16:
        //                return DataTypeIds.Int16;

        //            case EnumTagType.INT:
        //                return DataTypeIds.Int32;

        //            case EnumTagType.UINT16:
        //                return DataTypeIds.UInt16;

        //            case EnumTagType.UINT32:
        //                return DataTypeIds.UInt32;

        //            case EnumTagType.UINT64:
        //                return DataTypeIds.UInt64;

        //            case EnumTagType.FLOAT:
        //                return DataTypeIds.Float;

        //            case EnumTagType.DOUBLE:
        //                return DataTypeIds.Double;

        //            case EnumTagType.STRING:
        //                return DataTypeIds.String;

        //            case EnumTagType.DATETIME:
        //                return DataTypeIds.DateTime;

        //            default:
        //                return DataTypeIds.String;
        //        }
        //    }



        //    /// <summary>
        //    /// NodeId Pattern: ns=4;s=FOR/F01FOR01100202/Temperature/JigTemp01
        //    /// </summary>
        //    /// <param name="node_id">NodeId String</param>
        //    /// <returns></returns>
        //    public static string GetEqpTypeFromNodeId(string node_id)
        //    {
        //        int start = node_id.LastIndexOf('=') + 1;
        //        int end = node_id.IndexOf(EnvSettings.Settings.SETTING_UI_NODE_PATH_SEPARATOR);
        //        return node_id.Substring(start, end - start);
        //    }

        //    public static string GetEqpIdFromNodeId(string node_id)
        //    {
        //        string[] splits = node_id.Split(EnvSettings.Settings.SETTING_UI_NODE_PATH_SEPARATOR);
        //        return splits[1];
        //    }

        //    public static string ComposeNodePath(string eqp_id, string sub_path_to_node)
        //    {
        //        return $"{eqp_id}{EnvSettings.Settings.SETTING_UI_NODE_PATH_SEPARATOR}{sub_path_to_node}";
        //    }
    }

}
