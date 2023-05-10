using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    public class CRestDefine
    {
        

    }

    #region _action_id define
    /// <summary>
    /// action ID
    /// </summary>
    public static class CRestModulePath
    {

        public const string POST_SQL = "ecs/SQL";
        public const string POST_MANUAL_COMMAND = "ecs/sendManualCommand";
        public const string POST_USER_EVENT = "ecs/userEvent";

#if VERKOR
        public const string BaseUrl = "https://10.13.27.20";
#else
        public const string BaseUrl = "https://210.91.148.176";
#endif
        public const string ECSUrl = "https://localhost";

        public const string LOG_PATH = @"D:\Logs\FMSSystem";


        /////////////////////////////////////////////////////////////////////
        //	RestServer List Define
        //=================================================================== 
        public const string CONFIG_FILENAME_REST = @".\Config\RestServerList.csv";

        //public const string status_eqp = "STATUS_EQP";
        //public const string status_unit = "STATUS_UNIT";
        //public const string trayLoadRequest = "TRAY_LOAD_REQUEST";
        //public const string trayArrived = "TRAY_ARRIVED";
        //public const string masterRecipe = "MASTER_RECIPE";
        //public const string processStart = "PROCESS_START";
        //public const string processEnd = "PROCESS_END";
        //public const string trayUnloadRequest = "TRAY_UNLOAD_REQUEST";
        //public const string trayUnloadComplete = "TRAY_UNLOAD_COMPLETE";
        //public const string trayNextDestination = "TRAY_NEXT_DESTINATION";
        //public const string manualTrayCellInput = "MANUAL_TRAY_CELL_INPUT";
        //public const string manualTrayCellOutput = "MANUAL_TRAY_CELL_OUTPUT";
    }
#endregion


}
