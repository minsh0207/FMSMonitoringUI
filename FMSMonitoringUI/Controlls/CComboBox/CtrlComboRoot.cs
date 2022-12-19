//***************************************************************************
//  Description	    : CtrlComboRoot
//  Create Date	    : 
//  Author			: 
//  Remark			: 
//                      UI가 온전히 불러온 후 ComboBox List(DB)를 불러올 수 있게 한다.(김태훈)
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Data;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using MonitoringUI.Common;
#endregion

#region [NameSpace] CComboBox
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Classe]
    public partial class CtrlComboRoot : UserControlRoot
    {
        CString m_cString = new CString();

        #region Properties        
        string _labelText = "";
        [DisplayName("TitleText"), Description("Combo Title"), Category("Combo Setting")]
        public string TitleText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
                lbTitle.Text = _labelText;
            }
        }
        #endregion

        #region [Constructor]
        public CtrlComboRoot()
        {
            InitializeComponent();
        }
        #endregion

        #region [Resize]
        private void CtrlComboRoot_Resize(object sender, EventArgs e)
        {
            //this. Resize ..
            lbTitle.Top = 1;
            lbTitle.Left = 1;
            lbTitle.Width = Convert.ToInt32(Width * 0.4);
            lbTitle.Height = Height - 2;
        }
        #endregion




        #region [Method]
        #region [GetListTable]
        /// <summary>
        /// enDBTable eNum TO Function
        /// </summary>
        /// <returns></returns>
        public DataTable GetListTable(enDBTable enTable, bool bNull, string strFilter = "", string strOrder = "", string strColumn = "")
        {
            DataTable dt = new DataTable();
            object obj = new object();

            try
            {
                //DB Data Get
                obj = CDatabaseRest.SelectData(enTable, strFilter, strOrder, strColumn);

                //Data To DataTable 
                switch (enTable)
                {
                    case enDBTable.MST_PROD_MODEL:
                        dt = ModelIDList(obj, bNull);
                        break;
                    case enDBTable.LOT_INFO:
                        dt = LotIDList(obj, bNull);
                        break;
                    case enDBTable.MST_ROUTE_DEF:
                        dt = RouteIDList(obj, bNull);
                        break;

                    case enDBTable.MST_TROUBLE:
                        dt = TroubleList(obj, bNull);
                        break;
                    case enDBTable.MST_ROUTE_OPER:
                        dt = OperIDList(obj, bNull);
                        break;
                    case enDBTable.MST_EQP_GROUP:
                        dt = EqpGroupList(obj, bNull);
                        break;
                    case enDBTable.MST_EQUIPMENT:
                        dt = EqpList(obj, bNull);
                        break;
                    case enDBTable.MST_AGING_RACK:
                        dt = AgingList(obj, bNull);
                        break;
                    case enDBTable.MST_EQUIPMENT_CH:
                        dt = AgingList(obj, bNull);
                        break;

                    //20210208 for 공트레이 CellType
                    case enDBTable.MST_CELL_TYPE:
                        dt = CellTypeList(obj, bNull);
                        break;

                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Init ComBo List DB, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [GetListTable Query]
        /// <summary>
        /// enDBTable eNum TO Function
        /// </summary>
        /// <returns></returns>
        public DataTable GetListTableQuery(enDBTable enTable, bool bNull, List<string> lstVar)
        {
            DataTable dt = new DataTable();
            object obj = new object();

            try
            {
                //DB Data Get
                obj = CDatabaseRest.SelectQueryList(enTable, lstVar);

                //Data To DataTable  
                switch (enTable)
                {
                    case enDBTable.MST_PROD_MODEL:
                        dt = ModelIDList(obj, bNull);
                        break;
                    case enDBTable.LOT_INFO:
                        dt = LotIDList(obj, bNull);
                        break;
                    case enDBTable.MST_ROUTE_DEF:
                        dt = RouteIDList(obj, bNull);
                        break;
                    case enDBTable.MST_TROUBLE:
                        dt = TroubleList(obj, bNull);
                        break;
                    case enDBTable.MST_OPERATION:
                        dt = OperIDList(obj, bNull);
                        break;
                    case enDBTable.GROUPBY_EQP_STATE:
                        dt = OperIDList(obj, bNull);
                        break;
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Init ComBo List DB, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }
        #endregion

        #region [GetListTable Query]
        /// <summary>
        /// enDBTable eNum TO Function
        /// </summary>
        /// <returns></returns>
        public DataTable GetListTableGroupBy(enDBTable enTable, bool bNull, List<string> lstVar)
        {
            DataTable dt = new DataTable();

            object obj = new object();
            string strCols = null;
            string strFilter = null;
            string strGroupBy = null;
            string strGOrderBy = null;

            enDBTable newenTable = enTable;

            try
            {
                //Data To DataTable  
                switch (enTable)
                {
                    case enDBTable.GROUPBY_LOT:
                        strCols = "LotID";
                        strGroupBy = "LotID";
                        strGOrderBy = "LotID ASC";

                        if (lstVar.Count < 6) return null;
                        strFilter = "";

                        //WinProChange 생산중인 Tray의 다음공정을 변경 할 경우 생산중인 전체 LotID 를 조회.
                        //if (lstVar[1].Length > 0 && lstVar[2].Length > 0)
                        //{
                        //    // 20190314 KJY - IsVar[1] 이 lineID , [2]가 StartTime , [3] 이 EndTime이다. - 아씨. 아닌데.. 흠.. 3,1,2 네
                        //    //strFilter += m_cString.FilterStringADD("StartTime", lstVar[2], enTableWhere.WHERE, enTableWhereState.BT);
                        //    //strFilter += m_cString.FilterStringADD("", lstVar[3], enTableWhere.AND, enTableWhereState.BT_AND);
                        //    //strFilter += m_cString.FilterStringADD("LineID", lstVar[1], enTableWhere.AND, enTableWhereState.EQUALS);

                        //    // 20190529 KJY - 날짜가 있을때만 
                        //    if (lstVar[1].Length > 0 && lstVar[2].Length > 0)
                        //    {
                        //        strFilter += m_cString.FilterStringADD("StartTime", lstVar[1], enTableWhere.WHERE, enTableWhereState.BT);
                        //        strFilter += m_cString.FilterStringADD("", lstVar[2], enTableWhere.AND, enTableWhereState.BT_AND);
                        //    }
                        //    strFilter += m_cString.FilterStringADD("LineID", lstVar[3], enTableWhere.AND, enTableWhereState.EQUALS);


                        //}
                        //else
                        //{
                        //    // 20190314 KJY - IsVar[1] 이 lineID , [2]가 StartTime , [3] 이 EndTime이다. - 아니야아니야.. 어디서 잘못보내는곳이 있나보다.. -_-
                        //    //strFilter += m_cString.FilterStringADD("LineID", lstVar[1], enTableWhere.WHERE, enTableWhereState.EQUALS);
                        //    strFilter += m_cString.FilterStringADD("LineID", lstVar[3], enTableWhere.WHERE, enTableWhereState.EQUALS);
                        //}



                        strFilter += m_cString.FilterStringADD("LineID", lstVar[3], enTableWhere.WHERE, enTableWhereState.EQUALS);


                        // 20191213 KJY - 다시 날짜로 Lot가져오는거... 
                        if (lstVar[1].Length > 0 && lstVar[2].Length > 0)
                        {
                            strFilter += m_cString.FilterStringADD("StartTime", lstVar[1], enTableWhere.AND, enTableWhereState.BT);
                            strFilter += m_cString.FilterStringADD("", lstVar[2], enTableWhere.AND, enTableWhereState.BT_AND);
                        }


                        if (lstVar.Count >= 8)
                        {
                            // lsVar[6] : Cell 검색인지 여부 (기존엔 모두 Tray검색) - 'C' or 'T'
                            if (lstVar[6] == "C")
                            {
                                newenTable = enDBTable.CELL_CURR;

                                if (lstVar[7] == "N")
                                {
                                    strFilter += " AND Grade IN ('1', '2', '3', '4', 'T', 'N', 'M', 'K') ";
                                }
                                else
                                {
                                    strFilter += " AND ( Grade NOT IN ('1', '2', '3', '4', 'T', 'N', 'M', 'K') OR  Grade IS NULL ) ";
                                }
                            }
                        }

                        if (lstVar.Count >= 10)
                        {
                            if (lstVar[8] == "Past")
                            {
                                if (lstVar[6] == "C")
                                    newenTable = enDBTable.CELL_PRO_STEP;
                                else
                                    newenTable = enDBTable.TRAY_PRO_STEP;
                            }

                            if (lstVar[9].Length == 3)
                            {
                                strFilter += m_cString.FilterStringADD("EqpTypeID", lstVar[9].Substring(0, 1), enTableWhere.AND, enTableWhereState.EQUALS);
                                strFilter += m_cString.FilterStringADD("OperGroupID", lstVar[9].Substring(1, 1), enTableWhere.AND, enTableWhereState.EQUALS);
                                strFilter += m_cString.FilterStringADD("OperID", lstVar[9].Substring(2, 1), enTableWhere.AND, enTableWhereState.EQUALS);
                            }
                        }



                        strFilter += m_cString.FilterStringADD("LotID", "", enTableWhere.AND, enTableWhereState.IS_NOT_NULL);

                        //Filter, ADD
                        if (lstVar[4].Length > 0)
                        {
                            strFilter += m_cString.FilterStringADD("ProdModel", lstVar[4], enTableWhere.AND, enTableWhereState.EQUALS);
                        }

                        if (lstVar[5].Length > 0)
                        {
                            strFilter += m_cString.FilterStringADD("RouteID", lstVar[5], enTableWhere.AND, enTableWhereState.EQUALS);
                        }

                        obj = CDatabaseRest.SelectGroupBy(newenTable, strCols, strGroupBy, strFilter, strGOrderBy);


                        // 20191212 KJY - Cell 검색에서의 LotID 콤보박스는 tCellCurr에서 가져온다.
                        if (lstVar.Count >= 8)
                        {
                            if (lstVar[6] == "C")
                            {
                                if (lstVar[8] == "Past")
                                    dt = LotIDListFromCellProStep(obj, bNull);
                                else
                                    dt = LotIDListFromCellCurr(obj, bNull);
                            }
                            else
                            {
                                if (lstVar[8] == "Past")
                                    dt = LotIDListFromTrayProStep(obj, bNull);
                                else
                                    dt = LotIDList(obj, bNull);
                            }
                        }
                        else
                        {
                            dt = LotIDList(obj, bNull);
                        }

                        break;
                    case enDBTable.HIST_DB_GROUPBY_LOT:
                        strCols = "LotID";
                        strGroupBy = "LotID";
                        strGOrderBy = "LotID ASC";

                        if (lstVar.Count < 6) return null;

                        //if (lstVar[1].Length > 0 && lstVar[2].Length > 0)
                        //{
                        //    strFilter += m_cString.PartFilterADD(lstVar[1], lstVar[2]);

                        //    strFilter += m_cString.FilterStringADD("StartTime", lstVar[1], enTableWhere.AND, enTableWhereState.BT);
                        //    strFilter += m_cString.FilterStringADD("", lstVar[2], enTableWhere.AND, enTableWhereState.BT_AND);
                        //    strFilter += m_cString.FilterStringADD("LineID", lstVar[3], enTableWhere.AND, enTableWhereState.EQUALS);
                        //}
                        //else
                        //{
                        //    strFilter += m_cString.FilterStringADD("LineID", lstVar[3], enTableWhere.WHERE, enTableWhereState.EQUALS);
                        //}

                        strFilter += m_cString.FilterStringADD("LineID", lstVar[3], enTableWhere.WHERE, enTableWhereState.EQUALS);


                        // 20191213 KJY - 다시 날짜로 Lot가져오는거... 
                        if (lstVar[1].Length > 0 && lstVar[2].Length > 0)
                        {
                            //strFilter += m_cString.FilterStringADD("StartTime", lstVar[1], enTableWhere.AND, enTableWhereState.BT);
                            //strFilter += m_cString.FilterStringADD("", lstVar[2], enTableWhere.AND, enTableWhereState.BT_AND);


                            // 20210716 KJY - Hist 면 PartKey 사용해야 할것 같은데.. 넘 오래 걸려서... 
                            // 지금 lstVar[1], lstVar[2] 가 yyyyMMddHHmmss 로 오니깐
                            // PartKey > lstVar[1] , PartKey < lstVar[2]
                            //strFilter += $" AND PartKey > {lstVar[1].Substring(0, 8)} AND PartKey < {lstVar[2].Substring(0,8)} ";

                            //20210720 KJY 이거 StartTime으로 다시 바꿔야 겠다.
                            strFilter += m_cString.FilterStringADD("StartTime", lstVar[1], enTableWhere.AND, enTableWhereState.BT);
                            strFilter += m_cString.FilterStringADD("", lstVar[2], enTableWhere.AND, enTableWhereState.BT_AND);




                        }


                        //if (lstVar.Count == 8)
                        //{

                        //    if (lstVar[6] == "C")
                        //    {
                        //        newenTable = enDBTable.HIST_DB_CELL_CURR;

                        //        if (lstVar[7] == "N")
                        //        {
                        //            strFilter += " AND Grade IN ('1', '2', '3', '4', 'T', 'N', 'M', 'K') ";
                        //        }
                        //        else
                        //        {
                        //            strFilter += " AND ( Grade NOT IN ('1', '2', '3', '4', 'T', 'N', 'M', 'K') OR  Grade IS NULL ) ";
                        //        }
                        //    }
                        //}

                        if (lstVar.Count >= 8)
                        {

                            if (lstVar[6] == "C")
                            {
                                newenTable = enDBTable.HIST_DB_CELL_CURR;

                                if (lstVar[7] == "N")
                                {
                                    strFilter += " AND Grade IN ('1', '2', '3', '4', 'T', 'N', 'M', 'K') ";
                                }
                                else
                                {
                                    strFilter += " AND ( Grade NOT IN ('1', '2', '3', '4', 'T', 'N', 'M', 'K') OR  Grade IS NULL ) ";
                                }
                            }
                            else
                            {
                                //20210720
                                newenTable = enDBTable.HIST_DB_TRAY_CURR;
                            }
                        }

                        if (lstVar.Count >= 10)
                        {
                            if (lstVar[8] == "Past")
                            {
                                if (lstVar[6] == "C")
                                    //newenTable = enDBTable.HIST_DB_CELL_PRO_STEP;
                                    // 20210716 - KJY - 왜!!! 이 무거운 DB에서 가져오지... 뭔가 이유가 있었을까? ㅠㅠ  HIST_DB_CELL_PRO_STEP => HIST_DB_CELL_CURR
                                    // 공정완료 데이터는 partkey로 처리하자.. 날자로 처리하기가 힘들다. 
                                    // 20210720 KJY - 이걸...tTrayCurr, tCellCurr 구분을 해야 할것 같은데
                                    newenTable = enDBTable.HIST_DB_CELL_CURR;



                                else // tHistCellProStep 제일 무거워.. 이건 안돼... 
                                    //newenTable = enDBTable.HIST_DB_TRAY_PRO_STEP;
                                    newenTable = enDBTable.HIST_DB_TRAY_CURR;
                            }

                            if (lstVar[9].Length == 3)
                            {
                                strFilter += m_cString.FilterStringADD("EqpTypeID", lstVar[9].Substring(0, 1), enTableWhere.AND, enTableWhereState.EQUALS);
                                strFilter += m_cString.FilterStringADD("OperGroupID", lstVar[9].Substring(1, 1), enTableWhere.AND, enTableWhereState.EQUALS);
                                strFilter += m_cString.FilterStringADD("OperID", lstVar[9].Substring(2, 1), enTableWhere.AND, enTableWhereState.EQUALS);
                            }
                        }




                        strFilter += m_cString.FilterStringADD("LotID", "", enTableWhere.AND, enTableWhereState.IS_NOT_NULL);

                        //Filter, ADD
                        if (lstVar[4].Length > 0)
                        {
                            strFilter += m_cString.FilterStringADD("ProdModel", lstVar[4], enTableWhere.AND, enTableWhereState.EQUALS);
                        }

                        if (lstVar[5].Length > 0)
                        {
                            strFilter += m_cString.FilterStringADD("RouteID", lstVar[5], enTableWhere.AND, enTableWhereState.EQUALS);
                        }

                        //obj = CDatabaseRest.SelectGroupBy(enTable, strCols, strGroupBy, strFilter, strGOrderBy);
                        obj = CDatabaseRest.SelectGroupBy(newenTable, strCols, strGroupBy, strFilter, strGOrderBy);




                        if (lstVar.Count >= 8)
                        {
                            if (lstVar[6] == "C")
                            {
                                if (lstVar[8] == "Past")
                                    dt = LotIDListFromCellProStep(obj, bNull);
                                else
                                    dt = LotIDListFromCellCurr(obj, bNull);
                            }
                            else
                            {
                                //if (lstVar[8] == "Past")
                                //    dt = LotIDListFromTrayProStep(obj, bNull);
                                //else
                                //dt = LotIDList(obj, bNull);
                                dt = LotIDListFromTrayCurr(obj, bNull);
                            }
                        }
                        else
                        {
                            dt = LotIDList(obj, bNull);
                        }
                        break;
                    //20200603 KJY - tCellProStep에서 Group By로 Cell의 RouteID를 가져옴
                    case enDBTable.MST_ROUTE_FROM_PROSTEP:
                        break;
                    case enDBTable.HIST_DB_ROUTE_FROM_PROSTEP:
                        break;
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : GetListTableGroupBy, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }

        }
        #endregion

        #region [Model ID List]
        /// <summary>
        /// Key   : ProdModel
        /// Value : ProdModel
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable ModelIDList(object obj, bool bNull)
        {
            JsonModelIDList list = obj as JsonModelIDList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.ModelIDList)
                {
                    dt.Rows.Add(varData.ProdModel, varData.ProdModel);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Model ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [Model ID List]
        /// <summary>
        /// Key   : ProdModel
        /// Value : ProdModel
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable CellTypeList(object obj, bool bNull)
        {
            JsonCellTypeList list = obj as JsonCellTypeList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.CellTypeList)
                {
                    dt.Rows.Add(varData.CellType, varData.CellType);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Model ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [Lot ID List]
        /// <summary>
        /// Key   : LotID
        /// Value : LotID
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable LotIDList(object obj, bool bNull)
        {
            JsonLotIDList list = obj as JsonLotIDList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) return null;

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.LotIDList)
                {
                    dt.Rows.Add(varData.LotID, varData.LotID);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Lot ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        public DataTable LotIDListFromTrayCurr(object obj, bool bNull)
        {
            JsonTrayList list = obj as JsonTrayList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) return null;

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.TrayList)
                {
                    dt.Rows.Add(varData.LotID, varData.LotID);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Lot ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        //
        public DataTable LotIDListFromTrayProStep(object obj, bool bNull)
        {
            JsonTrayList list = obj as JsonTrayList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) return null;

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.TrayList)
                {
                    dt.Rows.Add(varData.LotID, varData.LotID);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Lot ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        public DataTable LotIDListFromCellCurr(object obj, bool bNull)
        {
            JsonCellCurrList list = obj as JsonCellCurrList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) return null;

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.CellCurrList)
                {
                    dt.Rows.Add(varData.LotID, varData.LotID);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Lot ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        public DataTable LotIDListFromCellProStep(object obj, bool bNull)
        {
            JsonCellProDataList list = obj as JsonCellProDataList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) return null;

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.CellProDataList)
                {
                    dt.Rows.Add(varData.LotID, varData.LotID);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Lot ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [Route ID List]
        /// <summary>
        /// Key   : RouteID
        /// Value : RouteID
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable RouteIDList(object obj, bool bNull, bool bFromProStep = false)
        {
            JsonRouteDefList list = obj as JsonRouteDefList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.RouteDefList)
                {
                    dt.Rows.Add(varData.RouteID, varData.RouteID);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Route ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [Trouble List]
        /// <summary>
        /// Key   : TroubleName
        /// Value : TroubleName
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable TroubleList(object obj, bool bNull)
        {
            JsonTroubleList list = obj as JsonTroubleList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.TroubleList)
                {
                    //언어 설정에 따른 분류 필요함.
                    if (Thread.CurrentThread.CurrentUICulture.ToString() == "zh-CN")
                    {
                        dt.Rows.Add(varData.TroubleName_kr, varData.TroubleName_cn);
                    }
                    else if (Thread.CurrentThread.CurrentUICulture.ToString() == "en-US")
                    {
                        dt.Rows.Add(varData.TroubleName_kr, varData.TroubleName_en);
                    }
                    else
                    {
                        dt.Rows.Add(varData.TroubleName_kr, varData.TroubleName_kr);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Trouble List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [Oper ID List]
        /// <summary>
        /// Key   : EqpTypeID + OperGroupID + OperID
        /// Value : OperName
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable OperIDList(object obj, bool bNull)
        {
            JsonRouteOperList list = obj as JsonRouteOperList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.RouteOperList)
                {
                    dt.Rows.Add(varData.EqpTypeID + varData.OperGroupID + varData.OperID, varData.OperName);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Oper ID List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [EqpGroup List]
        /// <summary>
        /// Key   : ProdModel
        /// Value : ProdModel
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable EqpGroupList(object obj, bool bNull)
        {
            JsonEqpGroupList list = obj as JsonEqpGroupList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.EqpGroupList)
                {
                    dt.Rows.Add(varData.EqpTypeID, varData.EqpTypeName);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : EQP Group List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [EqpGroup List]
        /// <summary>
        /// Key   : ProdModel
        /// Value : ProdModel
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable EqpList(object obj, bool bNull)
        {
            JsonEquipmentList list = obj as JsonEquipmentList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.EquipmentList)
                {
                    dt.Rows.Add(varData.UnitID, varData.UnitName);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : EQP List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [Aging List]
        /// <summary>
        /// Key   : ProdModel
        /// Value : ProdModel
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable AgingList(object obj, bool bNull)
        {
            JsonAgingRackList list = obj as JsonAgingRackList;
            DataTable dt = new DataTable();
            string strUnitName = "";

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.AgingRackList)
                {
                    //H 01 10 10 1
                    //SUBSTRING(A.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(A.RackID, 2, 2))) + '-' + SUBSTRING(A.RackID, 4, 1) + 'Line-' + SUBSTRING(A.RackID, 5, 2) + 'Bay-' + SUBSTRING(A.RackID, 7, 2) + 'Rack' AS UnitName"
                    strUnitName = "";                                                           //H0110101
                    strUnitName += varData.RackID.Substring(0, 1);                              //H
                    strUnitName += Convert.ToInt32(varData.RackID.Substring(1, 2)).ToString();  // 01
                    strUnitName += '-';                                                         //   
                    strUnitName += varData.RackID.Substring(3, 1);                              //   1
                    strUnitName += "Line-";                                                     //    
                    strUnitName += varData.RackID.Substring(4, 2);                              //    01
                    strUnitName += "Bay-" + varData.RackID.Substring(6, 2) + "Rack";            //      01

                    dt.Rows.Add(varData.RackID, strUnitName);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Aging List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion

        #region [EqpGroup List]
        /// <summary>
        /// Key   : ProdModel
        /// Value : ProdModel
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bNull"></param>
        /// <returns></returns>
        public DataTable EqpChList(object obj, bool bNull)
        {
            JsonGripperList list = obj as JsonGripperList;
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXID);
                dt.Columns.Add(CDefine.DEF_GRIDVIEW_COMBOXNAME);

                //ERROR Check Msg Return??
                if (list.code < 0) throw new Exception("DB CODE ERROR");
                if (list.count < 1) throw new Exception("DB COUNT ERROR");

                if (bNull) dt.Rows.Add("", "");

                foreach (var varData in list.GripperList)
                {
                    dt.Rows.Add(varData.CH, varData.CH);
                }

                return dt;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### UserCtrlComboBox : Eqp Channel List Get, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                return null;
            }
        }
        #endregion
        
        #endregion
    }
    #endregion
}
#endregion