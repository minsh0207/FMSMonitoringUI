/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//	Class Name		: 
//  Description		: 
//  Create Data		:       
//  Author			: 
//  Remark			: 개별 화면에서 설정하는 값들..따로..
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region []
using System.Data;
#endregion

#region [Namespace]
namespace MonitoringUI.Common
{
    #region [Class]
    public class CDataTable
    {
        #region [Formation Line]
        public static DataTable TableFormationLine()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");

            for (int nCnt = 1; nCnt <= 2; nCnt++)
            {
                dt.Rows.Add(nCnt.ToString(), nCnt.ToString() + "Line");
            }
            
            return dt;
        }
        #endregion

        #region [Formation Bay]
        public static DataTable TableFormationBay()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");

            for (int nCnt = 1; nCnt < 9; nCnt++)
            {
                dt.Rows.Add(nCnt.ToString("00"), nCnt.ToString() + "Bay");
            }

            return dt;
        }
        #endregion

        #region [Formation Box]
        public static DataTable TableFormationBox(int nLevel = 9)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");

            for (int nCnt = 1; nCnt < nLevel; nCnt++)
            {
                dt.Rows.Add(string.Format("{0:D2}", nCnt), nCnt.ToString() + "Box");
            }

            return dt;
        }
        #endregion

        #region [HPC CHANGE]
        public static DataTable TableHPCChange()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");

            for (int nCnt = 1; nCnt <= 6; nCnt++)
            {
                dt.Rows.Add(nCnt.ToString() + "01", "HPC # " + nCnt.ToString());
            }

            return dt;
        }
        #endregion

        #region [HPC Jig]
        public static DataTable TableHPCJig()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");

            for (int nCnt = 1; nCnt <= 17; nCnt++)
            {
                dt.Rows.Add(string.Format("{0:D2}", nCnt), "JIg" + nCnt.ToString());
            }

            return dt;
        }
        #endregion

        #region [User Grade]
        public static DataTable TableUserGrade()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("1", "Monitoring");
            dt.Rows.Add("3", "Opreator");
            dt.Rows.Add("5", "Master");
            dt.Rows.Add("9", "DEV");

            return dt;
        }
        #endregion

        #region [Table Cell Info]
        public static DataTable TableCellInfo()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add((int)enCellInfoType.Measuers, "Measuers");
            dt.Rows.Add((int)enCellInfoType.Grading, "Grading");

            return dt;
        }
        #endregion

        #region [User Meas]
        public static DataTable TableMeas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add((int)enCellMeasType.Capacity, "Capacity");
            dt.Rows.Add((int)enCellMeasType.End_Voltage, "End Voltage");
            dt.Rows.Add((int)enCellMeasType.End_Current, "End Current");
            dt.Rows.Add((int)enCellMeasType.Electric_Energy, "Electric Energy");
            dt.Rows.Add((int)enCellMeasType.OCV, "OCV");
            dt.Rows.Add((int)enCellMeasType.IR, "Impedance");

            return dt;
        }
        #endregion

        #region [Table Meas Type]
        public static DataTable TableMeasType()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add((int)enMeasType.Voltage, "V");
            dt.Rows.Add((int)enMeasType.Current, "I");
            dt.Rows.Add((int)enMeasType.Capacity, "C");
            dt.Rows.Add((int)enMeasType.Electric_Energy, "W");
            dt.Rows.Add((int)enMeasType.IR, "R");
            dt.Rows.Add((int)enMeasType.OCV, "O");
            dt.Rows.Add((int)enMeasType.ΔOCV, "K");
            dt.Rows.Add((int)enMeasType.ΔAVG, "A");
            dt.Rows.Add((int)enMeasType.ΔMED, "M");
            dt.Rows.Add((int)enMeasType.ΔIRAVG, "G");

            return dt;
        }
        #endregion

        #region [Table Rewor State]
        public static DataTable TableReworState()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add(LocalLanguage.GetItemString("DEF_SPREAD_56"), "G");
            dt.Rows.Add(LocalLanguage.GetItemString("DEF_SPREAD_57"), "R");
            dt.Rows.Add(LocalLanguage.GetItemString("DEF_SPREAD_58"), "O");
            return dt;
        }
        #endregion

        #region [Item Grade]
        public static DataTable TableItemGrade(int nInDex)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            switch (nInDex)
            {
                case 0:
                    dt.Rows.Add("", "");
                    dt.Rows.Add("1", "1");
                    dt.Rows.Add("2", "2");
                    dt.Rows.Add("A", "A: A" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("B", "B: B" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("C", "C: C" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("D", "D: D" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("E", "E: E" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("F", "F: F" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("G", "G: G" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("H", "H: H" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    break;
                case 1:
                    dt.Rows.Add("", "");
                    dt.Rows.Add("1", "1");
                    dt.Rows.Add("2", "2");
                    break;
                case 2:
                    dt.Rows.Add("", "");
                    dt.Rows.Add("A", "A: A" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("B", "B: B" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("C", "C: C" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("D", "D: D" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("E", "E: E" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("F", "F: F" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("G", "G: G" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("H", "H: H" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    break;
                case 3:
                    dt.Rows.Add("", "");
                    dt.Rows.Add("A", "A: A" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("B", "B: B" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("C", "C: C" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("D", "D: D" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("E", "E: E" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("F", "F: F" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("G", "G: G" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    dt.Rows.Add("H", "H: H" + LocalLanguage.GetItemString("DEF_ITEM_04"));
                    break;
                case 4:
                    dt.Rows.Add("", "");
                    dt.Rows.Add("1", "1");
                    dt.Rows.Add("2", "2");
                    dt.Rows.Add("A", "A");
                    dt.Rows.Add("B", "B");
                    dt.Rows.Add("C", "C");
                    dt.Rows.Add("D", "D");
                    dt.Rows.Add("E", "E");
                    dt.Rows.Add("F", "F");
                    dt.Rows.Add("G", "G");
                    dt.Rows.Add("H", "H");
                    break;
            }
            
            return dt;
        }
        #endregion

        #region [User Eng, A~Z]
        public static DataTable TableEng()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            for (int nCnt = 65; nCnt < 90; nCnt++)
            {
                dt.Rows.Add(((char)nCnt).ToString(), ((char)nCnt).ToString());
            }

            return dt;
        }
        #endregion

        #region [User Eng, A~Z]
        public static DataTable TableTabDirection()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("Simplex", "Simplex");
            dt.Rows.Add("Duplex", "Duplex");

            return dt;
        }
        #endregion

        #region [TableYN]
        public static DataTable TableYN()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("Y", "Y");
            dt.Rows.Add("N", "N");
            return dt;
        }
        #endregion

        #region [Model Def, "D"]
        public static DataTable TableModelDef()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("D", "D");

            return dt;  
        }
        #endregion

        #region [RouteType]
        public static DataTable TableRouteType()
        {
            DataTable dt = new DataTable();

            DataColumn keyColumn = new DataColumn();
            keyColumn.DataType = System.Type.GetType("System.String");
            keyColumn.ColumnName = CDefine.DEF_GRIDVIEW_COMBOXID;

            dt.Columns.Add(keyColumn);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("P", enRouteType.Production_Route.ToString().Replace("_", " "));
            dt.Rows.Add("R", enRouteType.Rework_Route.ToString().Replace("_", " "));
            dt.Rows.Add("S", enRouteType.Study_Route.ToString().Replace("_", " "));
            dt.Rows.Add("T", enRouteType.Test_Route.ToString().Replace("_", " "));
            dt.Rows.Add("M", enRouteType.Manual_Route.ToString().Replace("_", " "));
            dt.Rows.Add("A", enRouteType.Calibration_Route.ToString().Replace("_", " "));
            dt.Rows.Add("L", enRouteType.Cleaner_Route.ToString().Replace("_", " "));

            DataColumn[] key = new DataColumn[1];

            key[0] = keyColumn;
            dt.PrimaryKey = key;

            return dt;
        }
        #endregion

        #region [Formation Box Type, Recipe]
        public static DataTable TableFormBoxType()
        {
            //0=ALL, 6A=충방전6A, 30A=충방전30A, DCIR=DCIR

            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("0", "ALL");
            dt.Rows.Add("6A", "6A");
            dt.Rows.Add("30A", "30A");
            dt.Rows.Add("DCIR", "DCIR");
            return dt;
        }
        #endregion

        #region [MstEquipment : UnitStatus]
        //18. 장치상태(P:Power On, O:Power Off, M:유지보수,
        //      --               R:가동중, I:작업 대기중, T:trouble,
        //      --               S:Pause, N:Manual
        //      --               A:Abnomal(Scheduler에서 장치상태가 정상적으로 되지 않았을때) )
        //      --     * Formation의 경우 작업시작시 'R', 작업종료시 'I'
        //      --       그외 설비는 Tray 도착보고시 'R', Unload 완료보고시 'I'
        public static DataTable TableEQPUnitStatus()
        {
            //0=ALL, 6A=충방전6A, 30A=충방전30A, DCIR=DCIR

            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            if (CDefine.m_enLanguage == enLoginLanguage.Korean)
            {
                dt.Rows.Add("", "");
                dt.Rows.Add("P", "Power On");
                dt.Rows.Add("O", "Power Off");
                dt.Rows.Add("M", "유지보수");
                dt.Rows.Add("R", "가동중");
                dt.Rows.Add("I", "작업 대기 중");
                dt.Rows.Add("T", "Trouble");
                dt.Rows.Add("S", "Pause");
                dt.Rows.Add("N", "Manual");
                dt.Rows.Add("A", "Abnomal");
            }
            else
            {
                dt.Rows.Add("", "");
                dt.Rows.Add("P", "开电源");
                dt.Rows.Add("O", "关电源");
                dt.Rows.Add("M", "维修维护");
                dt.Rows.Add("R", "启动中");
                dt.Rows.Add("I", "工作等待");
                dt.Rows.Add("T", "障碍");
                dt.Rows.Add("S", "中止");
                dt.Rows.Add("N", "手动");
                dt.Rows.Add("A", "非正常");
            }

            return dt;
        }
        #endregion

        #region [MstEquipment : ProcessStatus]
        //9. 진행 상태
        //--     01) L : Load Request
        //--     02) 1 : 입고중
        //--     02) V : Reserve - 예약
        //--     03) W : Wait - Stacker Crane 으로 Formation Box에 입고시
        //--     04) I : Idle(충방전기에서 도착 보고)
        //--     05) R : RUN
        //--     06) E : End(작업종료보고시)
        //--     07) P : Pause(일시정지)
        //--     08) S : Stop(정지)
        //--     09) U : Unload Request
        //--     10) NULL(Unload Complete)                                                --     
        //--     11) 1 : Stacker Crane에 입고중
        //--     12) 2 : Stacker Crane에 출고중                                                --
        //--     13) F : 화재 출고
        //--
        //--     1) 층방전기의 경우
        //--       1- 1) 충방전기에서 Load 요청시              : L
        //--       1- 2) Stacker Crane에 입고명령시            : 1
        //--       1- 3) Stacker Crane이 충방전기에 입고완료시 : W
        //--       1- 4) 도착보고전에 충방전기에서 CMD_153으로 Stacker Crane 완료 여부 확인
        //--       1- 5) 충방전기에서 도착보고                 : I                                                
        //--       1- 6) 충방전기 작업시                       : R,,,,
        //--       1- 7) 충방전기에서 UnLoad 요청시            : U
        //--       1- 8) Stacker Crane에서 출고명령시          : 2
        //--       1- 9) Statker Crane이 출고완료시            : NULL
        //--       1-10) Unload Complete 전에 충방전기에서 CMD_153으로 Stacker Crane 완료 여부 확인                                                
        //--       1-11) 충방전기에서 UnLoad Complete         : NULL
        public static DataTable TableEQPProcessStatus()
        {
            //0=ALL, 6A=충방전6A, 30A=충방전30A, DCIR=DCIR

            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("L", "Load Request");
            dt.Rows.Add("1", "입고중");
            dt.Rows.Add("V", "Reserve");
            dt.Rows.Add("W", "Wait");
            dt.Rows.Add("I", "Idle");
            dt.Rows.Add("R", "RUN");
            dt.Rows.Add("E", "End");
            dt.Rows.Add("P", "Pause");
            dt.Rows.Add("S", "Stop");
            dt.Rows.Add("U", "Unload Request");
            dt.Rows.Add("1", "Stacker Crane 입고 중");
            dt.Rows.Add("2", "Stacker Crane 출고 중");
            dt.Rows.Add("F", "화재 출고");
            return dt;
        }
        #endregion

        #region [MstEquipment : PhysicalStatus]
        //20. 장비의 실제 상태 표시
        //  -- 13.1 Stacker Crane과 충방전기 사이의 I/F
        //  --     1) Stacker Crane이 상태 요청시(CMD_151)
        //  --        'R' : Request
        //  --     2) Formation에서 CMD_152응답시
        //  --        '0' : 입/출고 불가
        //  --        '1' : 입고가능
        //  --        '2' : 출고가능
        //  --     3) Stacker Crane에서 작업완료시
        //  --        NULL : Stacker Crane에서 작업완료시 Reset
        //  --
        //  --   *이하 Stacker Crane Biz에서 직접 Conveyor PLC 연결해서 Bit Set/Reset
        //  ---- 13.2 Stacker Crane과 Conveyor 사이의 I/F
        //  ----     1) Stacker Crane의 입고대/출고대 동작가능
        //  ----        'L' : Load Request
        //  --
        public static DataTable TableEQPPhysicalStatus()
        {
            //0=ALL, 6A=충방전6A, 30A=충방전30A, DCIR=DCIR

            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("R", "Request");
            dt.Rows.Add("0", "입/출고 불가");
            dt.Rows.Add("1", "입고가능");
            dt.Rows.Add("2", "출고가능");
            dt.Rows.Add("L", "Load Request");

            return dt;
        }
        #endregion
        
        #region [MstEquipment : PhysicalStatus]
        //20. 장비의 실제 상태 표시
        //  -- 13.1 Stacker Crane과 충방전기 사이의 I/F
        //  --     1) Stacker Crane이 상태 요청시(CMD_151)
        //  --        'R' : Request
        //  --     2) Formation에서 CMD_152응답시
        //  --        '0' : 입/출고 불가
        //  --        '1' : 입고가능
        //  --        '2' : 출고가능
        //  --     3) Stacker Crane에서 작업완료시
        //  --        NULL : Stacker Crane에서 작업완료시 Reset
        //  --
        //  --   *이하 Stacker Crane Biz에서 직접 Conveyor PLC 연결해서 Bit Set/Reset
        //  ---- 13.2 Stacker Crane과 Conveyor 사이의 I/F
        //  ----     1) Stacker Crane의 입고대/출고대 동작가능
        //  ----        'L' : Load Request
        //  --
        public static DataTable TableLanguage()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("CHINESE", "CHINESE");
            dt.Rows.Add("KOREAN", "KOREAN");
            //dt.Rows.Add("ENGLISH", "ENGLISH");

            return dt;
        }
        #endregion

        #region [Window ID Group]
        public static DataTable TableWinIDGroup()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            dt.Rows.Add("", "");
            dt.Rows.Add("MST", "MST");
            dt.Rows.Add("RTP", "RTP");
            dt.Rows.Add("MON", "MON");

            return dt;
        }
        #endregion

        #region [Table Cell Info]
        public static DataTable TableTrayStatus()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            //(Run, End, Move, Wait, Manual, Prompt wait, Delete:수동삭제,  Bad,  reServe:예약, X:비상배출, T:강제배출)
            //F
            //LocalLanguage.GetItemString("DEF_CONTROL_304");

            dt.Rows.Add("", "");
            dt.Rows.Add("R", "RUN(R)");
            dt.Rows.Add("E", LocalLanguage.GetItemString("DEF_CONTROL_141") +" (E)"); // 작업종료
            dt.Rows.Add("M", "Move(M)");
            dt.Rows.Add("N", "Manual(N)");
            dt.Rows.Add("P", "Prompt wait(P)");
            dt.Rows.Add("D", "Delete(D)");
            dt.Rows.Add("B", "Bad(B)");
            dt.Rows.Add("T", LocalLanguage.GetItemString("strForcedOut") + " (T)");  // 강제배출
            dt.Rows.Add("X", LocalLanguage.GetItemString("strEmergencyOut") + " (X)");  // 비상배출
            dt.Rows.Add("F", "Fire(F)");

            return dt;
        }
        #endregion

        #region [Table Cell Info]
        //Assembly / Degas / Grader
        public static DataTable TableTrayZone()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
            dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

            //dt.Rows.Add("", "");
            dt.Rows.Add(CDefine.DEF_EQP_TYPE_ID_ASSEMBLY, "[A]ssembly");
            dt.Rows.Add(CDefine.DEF_EQP_TYPE_ID_DEGAS, "[D]egas");
            dt.Rows.Add(CDefine.DEF_EQP_TYPE_ID_GRADER, "[G]rader");

            return dt;
        }
        #endregion

    }
    #endregion
}
#endregion
