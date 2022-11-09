
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace RunningEnv
{
    public static class StaticParamClass
    {
        #region [GetTickCount64]

        [DllImport("kernel32")]
        public extern static UInt64 GetTickCount64();

        #endregion


        // Config Files
        public static string CONFIG_FILENAME_OPCUA = @".\Config\OPCUAList.csv";


        // Tag File
        public static string CONFIG_FILENAME_TAG = @"\TAGS_CLIENT_V1.xlsx";






















        // Line ID 
        public static string LOGIS_LINE_ID_STR = "001";
        public static int LOGIS_LINE_ID_INT = 1;

        /// <summary>
        /// TrayID 5번째. 1구역. 조립 1,2호기
        /// </summary>
        public const char AREA_CODE_1 = 'A'; 
        /// <summary>
        /// TrayID 5번째. 2구역. 조립 4,5호기
        /// </summary>
        public const char AREA_CODE_2 = 'B'; 
        /// <summary>
        /// TrayID 5번째. 3구역. 조립 3호기
        /// </summary>
        public const char AREA_CODE_3 = 'C';

        public static string PWD = "13688041388"; // 사용자 버튼 클릭시 확인할 비번. 국련 IT 담당자 전화번호(나중에는 Config 에서 받도록 수정예정)
        public static bool CheckPWD(string _pwd)
        {
            return PWD.Equals(_pwd);
        }

        public static string ASMEmptyLimit = "10";


        // Config Files
        public static string CONFIG_FILENAME_CRANE = @".\Config\SCHandlerList.csv";
        public static string CONFIG_FILENAME_CV = @".\Config\CVPLCList.csv";
        public static string CONFIG_FILENAME_BCR = @".\Config\BCR_Station_List.csv";


        // PLC Reader
        public static ulong PLC_READER_LOOP_DELAY_MSEC = 200;
        public static ulong PLC_CONNECTION_CHECK_INTERVAL_MSEC = 10000;

        // PLC Alive Params
        public static ulong PLC_ALIVE_CYCLE_MSEC = 1000;
        public static short PLC_ALIVE_VALUE_MIN = 1;
        public static short PLC_ALIVE_VALUE_MAX = 9;

        // Main Loop Traffic
        public static double MAINLOOP_TRAFFIC_WARNING = 70.00;      // Main-Loop Traffic 경고 수준
        public static double MAINLOOP_TRAFFIC_ALARM = 90.00;        // Main-Loop Traffic 알람 수준 (RTAging 이 알람이상이면 출고하지 않는다, 단!
        public static bool MAINLOOP_USE_TRAFFICE_ALARM = true;      // 이 값이 false 면 Main-Loop Traffic 상관하지 않고 그냥 출고한다.

        // KeyenceReader
        public static int BCR_SOCK_BUFFER_SIZE = 128;
        public static int BCR_PORT = 9004;
        public static int BCR_SOCKET_TIMEOUT_MSEC = 3000; // 1000 == 1초
        public static int BCR_MAX_SOCKET_TIMEOUT_MSEC = 10000; // 10000 == 10초
        public static int BCR_READ_FAIL_COUNT_MAX = 3;
        public static int BCR_FAIL_COUNT_MAX = 3;
        public static string BCR_READ_START_COMMAND = "LON\r";
        public static string BCR_READ_ABORT_COMMAND = "LOFF\r";

        // TrayID Validation
        public static int MIN_TRAYID_LEN = 16;
        public static int MAX_TRAYID_LEN = 16;
        public static bool CheckTrayFormat(string trayid)
        {
            return true;
        }

        public static AREACODE GET_AREACODEfromTRAYID(string trayid)
        {
            if (string.IsNullOrEmpty(trayid)) return AREACODE.None;

            switch (trayid[5])
            {
                case AREA_CODE_1:
                    return AREACODE.A_LINE1;
                case AREA_CODE_2:
                    return AREACODE.B_LINE2;
                case AREA_CODE_3:
                    return AREACODE.C_LINE3;
                default:
                    return AREACODE.None;
            }
        }

        // Tray ForceInCnt MAX Value. 1->3 변경. by won 20190416
        public static int MAX_TRAY_FORCE_IN_CNT = 3;

        // CELL ID Length
        // 20210428 KJY - CellID 길이 24 byte네... 왜 32로 적어놨지.. -_-;;
        // 아.. word 2개라 32 구낭.. 그냥 두면됨
        public static int CELL_ID_LEN = 32;

        // OBJECT ID Length
        public static int OBJECT_ID_LEN = 9;

        // CRANE RackID Length
        public static int FORMATION_RACKID_LEN = 5;
        public static int AGING_RACKID_LEN = 8;

        private static string GET_OBJECT_ID_PART(string object_id, int start, int len)
        {
            object_id = object_id.Trim();
            if (string.IsNullOrEmpty(object_id) || object_id.Length < OBJECT_ID_LEN) return string.Empty;
            return object_id.Substring(start, len);
        }

        public static string GET_LINE_ID(string object_id)
        {
            return GET_OBJECT_ID_PART(object_id, 0, 3);
        }
        public static string GET_LINE_ID(AREACODE ac)
        {
            switch (ac)
            {
                case AREACODE.A_LINE1:
                    return "001";
                case AREACODE.B_LINE2:
                    return "002";
                case AREACODE.C_LINE3:
                    return "003";
                default:
                    return string.Empty;
            }
        }
        public static string GET_LINE_ID_INT(int lineid)
        {
            switch(lineid)
            {
                case StaticParamClass.AREA_CODE_1:
                    return "001";
                case StaticParamClass.AREA_CODE_2:
                    return "002";
                case StaticParamClass.AREA_CODE_3:
                    return "003";
                default:
                    return string.Empty;
            }
        }

        public static string GET_EQP_TYPE_ID(string object_id)
        {
            string s = GET_OBJECT_ID_PART(object_id, 3, 1);
            if (s.Length < 1) return string.Empty;
            else return s;
        }

        public static string GET_UNIT_ID(string object_id)
        {
            return GET_OBJECT_ID_PART(object_id, 4, 5);
        }

        // Logger
        //public static string LOGGER_LOG_ROOT = @"D:\FormationECS\Log";
        public static string LOGGER_LOG_ROOT = Thread.GetDomain().BaseDirectory.Substring(0, 3) + @"Formation\Log";


        public const string LOGGER_LOG_BASEFILENAME_ECS = "ECS";
        public const string LOGGER_LOG_BASEFILENAME_ASM = "ASM";
        public const string LOGGER_LOG_BASEFILENAME_CRANE = "CRANE";

        public static string LOGGER_LOG_DATETIMEFORMAT_DAY = "yyyy-MM-dd";
        public static string LOGGER_LOG_DATETIMEFORMAT_SEC = "yyyy-MM-dd HH:mm:ss";
        public static string LOGGER_LOG_DATETIMEFORMAT_MILISEC = "yyyy-MM-dd HH:mm:ss.fff";

        // Crane
        public static int CRANE_IN_OUT_ORDER_SCHEME = 0; // RoundRobin : In->Out->In->Out
        //public static int CRANE_IN_OUT_ORDER_SCHEME = 1; // Check Crane Position (bay<1 이면 Input, 아니면 Output)
        public static uint CRANE_JOB_CHECK_CYCLE_MSEC = 3000; // 3초에 한번 씩, Crane Job Check 를 함...

        // Round Robbin current index. HogiChoose, ForceInBCR 의 자식 BCR 에서 순번을 정한다
        public static bool IsRoundRobbin = false;
        // Key=SiteNo, Value=자식 BCR 중에 마지막 목적지 순번
        public static Dictionary<short, int> RRCurrSeq = new Dictionary<short, int>();



        /*
         * 
         * CV JobNo : 물류 프로그램이 1공장/2공장 따로 돌아갈 것이므로, JobNo Min 을 정해주고, JobNo 크기는 5000으로 동일하다.
         * 1공장 물류 : 10001 ~ 15000
         * 2공장 물류 : 20001 ~ 25000
         * 
         */

        private static short g_JOB_NO_MIN = 10001;
        public static void SetCVJobNoMin(short val)
        {
            g_JOB_NO_MIN = val;
        }
        public static short GetCVJobNoMin()
        {
            return g_JOB_NO_MIN;
        }

        private static short JOB_NO_COUNT = 4999;
        public static void SetCVJobNoCount(short cnt)
        {
            JOB_NO_COUNT = (short)(cnt - 1);
            if (JOB_NO_COUNT <= 0) JOB_NO_COUNT = 1;
        }
        public static short GetCVJobNoCount()
        {
            return (short)(JOB_NO_COUNT + 1);
        }



        private static object _job_no_object = new object();
        private static short _curr_cv_job_no = 0;

        public static short CV_NEXT_JOBNO
        {
            get
            {
                lock (_job_no_object)
                {
                    int ret = g_JOB_NO_MIN + _curr_cv_job_no++;
                    if (_curr_cv_job_no > JOB_NO_COUNT) _curr_cv_job_no = 0;
                    return (short)ret;
                }
            }
        }



#region [Misc]

        public static int SilentParseInt(int? i)
        {
            if (i == null) return 0;
            else return (int)i;
        }

        public static int SilentParseInt(string s)
        {
            int r = 0;

            if (s == null || s.Length <= 0) return r;

            try
            {
                r = int.Parse(s);
            }
            catch
            {
                r = 0;
            }

            return r;
        }

        public static bool IsSameText(string s1, string s2)
        {
            if (s1 == null) return false;
            if (s2 == null) return false;
            return s1.Trim() == s2.Trim();
        }

        public static bool IsSameText(char c1, char c2)
        {
            return IsSameText(c1.ToString(), c2.ToString());
        }

        public static bool IsSameText(string s1, char c1)
        {
            if (s1 == null) return false;
            else return IsSameText(s1, c1.ToString());
        }

        public static bool IsSameText(char c1, string s1)
        {
            if (s1 == null) return false;
            else return IsSameText(s1, c1.ToString());
        }

        public static string GetMyEXEFileCreationTime()
        {
            string exe_path = System.Reflection.Assembly.GetEntryAssembly().Location;
            return System.IO.File.GetLastWriteTime(exe_path).ToString(LOGGER_LOG_DATETIMEFORMAT_SEC);
        }

#endregion

    }

    public enum AREACODE
    {
        None = 0,
        A_LINE1 = 1,
        B_LINE2 = 2,
        C_LINE3 = 3,
        P_PACKING = 4
    }
}
