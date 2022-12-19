//using AtemFMSAnfang.Global;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace OPCUAClientClassLib
{
    public class FMSTagConfigReader
    {
        string ConfigFilePath = "";

        public FMSTagConfigReader(string config_file_path)
        {
            ConfigFilePath = config_file_path;
        }

        public List<CEqpTagItem> Read(int data_start_row = 4, int data_start_col = 2)
        {
            DataSet ds = ReadSheetsAsDataSet();
            if (ds == null) return null;

            List<CEqpTagItem> eqplist = ReadEqpTypeAndList(ds, "EQPLIST", data_start_row, data_start_col);

            foreach (var eqptype in eqplist)
            {
                BuildEqpIdListForEqpType(ds, eqptype, data_start_row, data_start_col);
            }

            return eqplist;
        }

        public DataSet ReadSheetsAsDataSet()
        {
            try
            {
                using (var stream = File.Open(ConfigFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();

                        #region [If you want to print out the excel sheet...]
                        /*
                        if (result.Tables.Count > 0)
                        {
                            foreach (DataTable table in result.Tables)
                            {
                                Debug.WriteLine($"{table.TableName}, Rows:{table.Rows.Count}, Cols:{table.Columns.Count}");

                                if (table.Rows.Count > 0 && table.Columns.Count > 0)
                                {
                                    for (int row = 0; row < table.Rows.Count; row++)
                                    {
                                        for (int col = 0; col < table.Columns.Count; col++)
                                        {
                                            Debug.Write(table.Rows[row][col].ToString());
                                            Debug.Write(",\t");
                                        }
                                        Debug.WriteLine("");
                                    }
                                }
                            }
                        }
                        */
                        #endregion

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return null;
        }



        ///// <summary>
        ///// Read EQPLIST sheet from config file read result
        ///// </summary>
        ///// <param name="ds">Config File Read Reasult (Each Sheet Read Into a DataTable in the DataSet)</param>
        ///// <param name="sheet_name">Sheet Name Of EQPLIST</param>
        ///// <param name="data_start_row">Start Row That Data Starts, 1-based</param>
        ///// <param name="data_start_col">Start Col That Data Starts, 1-based</param>
        ///// <returns>Dictionary<string,List<string>> (EqpType:List<EqpId>)</returns>
        //public List<EqpTagItem> ReadEqpTypeAndList(DataSet ds, string sheet_name, int data_start_row, int data_start_col)
        //{
        //    List<EqpTagItem> eqptypelist = new List<EqpTagItem>();

        //    DataTable dt = ds.Tables[sheet_name];
        //    if (dt == null || dt.Rows.Count < data_start_row || dt.Columns.Count < data_start_col) return eqptypelist;

        //    for (int row = data_start_row - 1; row < dt.Rows.Count; row++)
        //    {
        //        string eqp_type = dt.Rows[row][data_start_col - 1].ToString();
        //        string eqp_id = dt.Rows[row][data_start_col].ToString();

        //        if (string.IsNullOrEmpty(eqp_type) || string.IsNullOrEmpty(eqp_id)) continue;


        //        var eqptype = eqptypelist.Find(x => x.TagName == eqp_type);
        //        if (eqptype == null)
        //        {
        //            eqptype = new EqpTagItem(eqp_type, EnvSettings.EnumTagType.FOLDER, string.Empty, null, false, false);
        //            eqptypelist.Add(eqptype);
        //        }

        //        //
        //        eqptype.AddChild(eqp_id, EnvSettings.EnumTagType.FOLDER, string.Empty, null, false, false);
        //    }

        //    return eqptypelist;
        //}

        /// <summary>
        /// Read EQPLIST sheet from config file read result
        /// </summary>
        /// <param name="ds">Config File Read Reasult (Each Sheet Read Into a DataTable in the DataSet)</param>
        /// <param name="sheet_name">Sheet Name Of EQPLIST</param>
        /// <param name="data_start_row">Start Row That Data Starts, 1-based</param>
        /// <param name="data_start_col">Start Col That Data Starts, 1-based</param>
        /// <returns>Dictionary<string,List<string>> (EqpType:List<EqpId>)</returns>
        public List<CEqpTagItem> ReadEqpTypeAndList(DataSet ds, string sheet_name, int data_start_row, int data_start_col)
        {
            List<CEqpTagItem> eqptypelist = new List<CEqpTagItem>();

            DataTable dt = ds.Tables[sheet_name];
            if (dt == null || dt.Rows.Count < data_start_row || dt.Columns.Count < data_start_col) return eqptypelist;

            for (int row = data_start_row - 1; row < dt.Rows.Count; row++)
            {
                string eqp_type = dt.Rows[row][data_start_col - 1].ToString();
                string eqp_id = dt.Rows[row][data_start_col].ToString();

                if (string.IsNullOrEmpty(eqp_type)) continue;


                var eqptype = eqptypelist.Find(x => x.TagName == eqp_type);
                if (eqptype == null)
                {
                    eqptype = new CEqpTagItem(eqp_type, EnumTagType.FOLDER, string.Empty, null, false, false);
                    eqptypelist.Add(eqptype);
                }

                //
                eqptype.AddChild(eqp_id, EnumTagType.FOLDER, string.Empty, null, false, false);
            }

            return eqptypelist;
        }



        ///// <summary>
        ///// Read Eqp Id List Of an Eqp Type
        ///// </summary>
        ///// <param name="ds">Config File Read Reasult (Each Sheet Read Into a DataTable in the DataSet)</param>
        ///// <param name="eqp_type">Eqp Type Name == Excel Sheet Name</param>
        ///// <param name="data_start_row">Start Row That Data Starts, 1-based</param>
        ///// <param name="data_start_col">Start Col That Data Starts, 1-based</param>
        //public void BuildEqpIdListForEqpType(DataSet ds, EqpTagItem eqp_type, int data_start_row, int data_start_col)
        //{
        //    DataTable dt = ds.Tables[eqp_type.TagName];
        //    if (dt == null || dt.Rows.Count < data_start_row || dt.Columns.Count < data_start_col) return;

        //    foreach (var eqpid in eqp_type.Children)
        //    {
        //        eqpid.Children = ReadEqpTagList(dt, eqpid, data_start_row, data_start_col);
        //        CreateCellTags(eqpid, EnvSettings.Settings.SETTING_UI_CELL_TAG_NAME_FORMAT, EnvSettings.Settings.SETTING_UI_CELL_NO_FORMAT, GlobalSettings.MAX_CELL_COUNT);
        //        CreateCellTags(eqpid, EnvSettings.Settings.SETTING_UI_REALTIME_CELL_TAG_NAME_FORMAT, EnvSettings.Settings.SETTING_UI_CELL_NO_FORMAT, GlobalSettings.MAX_CELL_COUNT);

        //        eqpid.Children.Sort((x, y) => x.TagName.CompareTo(y.TagName));
        //    }
        //}

        /// <summary>
        /// Read Eqp Id List Of an Eqp Type
        /// </summary>
        /// <param name="ds">Config File Read Reasult (Each Sheet Read Into a DataTable in the DataSet)</param>
        /// <param name="eqp_type">Eqp Type Name == Excel Sheet Name</param>
        /// <param name="data_start_row">Start Row That Data Starts, 1-based</param>
        /// <param name="data_start_col">Start Col That Data Starts, 1-based</param>
        public void BuildEqpIdListForEqpType(DataSet ds, CEqpTagItem eqp_type, int data_start_row, int data_start_col)
        {
            //DataTable dt = ds.Tables[eqp_type.TagName];
            //if (dt == null || dt.Rows.Count < data_start_row || dt.Columns.Count < data_start_col) return;
            string SETTING_UI_CELL_TAG_NAME_FORMAT = "_{0}";
            string SETTING_UI_CELL_NO_FORMAT = "D1";

            foreach (var eqpid in eqp_type.Children)
            {
                DataTable dt = ds.Tables[eqpid.TagName];
                if (dt == null || dt.Rows.Count < data_start_row || dt.Columns.Count < data_start_col) return;

                eqpid.Children = ReadEqpTagList(dt, eqpid, data_start_row, data_start_col);
                CreateCellTags(eqpid, SETTING_UI_CELL_TAG_NAME_FORMAT, SETTING_UI_CELL_NO_FORMAT, Settings.MAX_CELL_COUNT);
                CreateCellTags(eqpid, Settings.SETTING_UI_REALTIME_CELL_TAG_NAME_FORMAT, Settings.SETTING_UI_CELL_NO_FORMAT, Settings.MAX_CELL_COUNT);
                //CreateCellTags(eqpid, EnvSettings.Settings.SETTING_UI_CELL_TAG_NAME_FORMAT, EnvSettings.Settings.SETTING_UI_CELL_NO_FORMAT, GlobalSettings.MAX_CELL_COUNT);
                //CreateCellTags(eqpid, EnvSettings.Settings.SETTING_UI_REALTIME_CELL_TAG_NAME_FORMAT, EnvSettings.Settings.SETTING_UI_CELL_NO_FORMAT, GlobalSettings.MAX_CELL_COUNT);

                eqpid.Children.Sort((x, y) => x.TagName.CompareTo(y.TagName));


                //eqp_type.Children = ReadEqpTagList(dt, eqp_type, data_start_row, data_start_col);
                //CreateCellTags(eqp_type, EnvSettings.Settings.SETTING_UI_CELL_TAG_NAME_FORMAT, EnvSettings.Settings.SETTING_UI_CELL_NO_FORMAT, GlobalSettings.MAX_CELL_COUNT);
                //CreateCellTags(eqp_type, EnvSettings.Settings.SETTING_UI_REALTIME_CELL_TAG_NAME_FORMAT, EnvSettings.Settings.SETTING_UI_CELL_NO_FORMAT, GlobalSettings.MAX_CELL_COUNT);

                //eqp_type.Children.Sort((x, y) => x.TagName.CompareTo(y.TagName));
            }
        }


        ///// <summary>
        ///// Taglist 정의 Excel 파일에서
        ///// CELL 별 Tag 를 정의할 때, CELL 이 수십 개 있는 것을 다 하면, 복잡하고 지저분해 지니까...
        ///// CELL_01 이라는 tag 만 정의하면 cell_count 만큼 복사해서 만들어 주는 함수이다.
        ///// </summary>
        ///// <param name="eqpid"></param>
        ///// <param name="cell_tag_name_format"></param>
        ///// <param name="cell_no_format"></param>
        ///// <param name="cell_count"></param>
        //private void CreateCellTags(EqpTagItem eqpid, string cell_tag_name_format, string cell_no_format, int cell_count)
        //{
        //    int cell_01 = 1;
        //    string cell_01_tag_name = String.Format(cell_tag_name_format, cell_01.ToString(cell_no_format));

        //    var cell_01_tags = eqpid.Children.FindAllInTree(cell_01_tag_name);

        //    foreach (var cell_01_tag in cell_01_tags)
        //    {
        //        // method arguments Cell01 이 있어도 Cell32까지 자동으로 만들어 내지 않음...
        //        if (cell_01_tag.Parent.TagType == EnvSettings.EnumTagType.METHOD) continue;

        //        //
        //        for (int i = cell_01 + 1; i <= cell_count; i++)
        //        {
        //            EqpTagItem dupe = new EqpTagItem(tag_name: String.Format(cell_tag_name_format, i.ToString(cell_no_format)),
        //                tag_type: cell_01_tag.TagType,
        //                default_Value: cell_01_tag.DefaultValue,
        //                parent: cell_01_tag.Parent,
        //                subscribe: cell_01_tag.Subscribe,
        //                batchreport: cell_01_tag.BatchReport);

        //            dupe.Children = cell_01_tag.Children.MakeTreeCopy(dupe);
        //            cell_01_tag.Parent.Children.Add(dupe);
        //        }
        //    }
        //}

        /// <summary>
        /// Taglist 정의 Excel 파일에서
        /// CELL 별 Tag 를 정의할 때, CELL 이 수십 개 있는 것을 다 하면, 복잡하고 지저분해 지니까...
        /// CELL_01 이라는 tag 만 정의하면 cell_count 만큼 복사해서 만들어 주는 함수이다.
        /// </summary>
        /// <param name="eqpid"></param>
        /// <param name="cell_tag_name_format"></param>
        /// <param name="cell_no_format"></param>
        /// <param name="cell_count"></param>
        private void CreateCellTags(CEqpTagItem eqpid, string cell_tag_name_format, string cell_no_format, int cell_count)
        {
            int cell_01 = 0;
            string cell_01_tag_name = String.Format(cell_tag_name_format, cell_01.ToString(cell_no_format));

            var cell_01_tags = eqpid.Children.FindAllInTree(cell_01_tag_name);

            foreach (var cell_01_tag in cell_01_tags)
            {
                // method arguments Cell01 이 있어도 Cell32까지 자동으로 만들어 내지 않음...
                if (cell_01_tag.Parent.TagType == EnumTagType.METHOD) continue;

                //
                //for (int i = cell_01 + 1; i <= cell_count; i++)
                for (int i = cell_01 + 1; i < cell_count; i++)
                {
                    CEqpTagItem dupe = new CEqpTagItem(tag_name: String.Format(cell_tag_name_format, i.ToString(cell_no_format)),
                        tag_type: cell_01_tag.TagType,
                        default_Value: cell_01_tag.DefaultValue,
                        parent: cell_01_tag.Parent,
                        subscribe: cell_01_tag.Subscribe,
                        batchreport: cell_01_tag.BatchReport);

                    dupe.Children = cell_01_tag.Children.MakeTreeCopy(dupe);
                    cell_01_tag.Parent.Children.Add(dupe);
                }
            }
        }



        /// <summary>
        /// Read Tag List Of An Eqp
        /// </summary>
        /// <param name="dt">DataTable from DataSet Read From Excel Config File</param>
        /// <param name="data_start_row">Start Row That Data Starts, 1-based</param>
        /// <param name="data_start_col">Start Col That Data Starts, 1-based</param>
        /// <returns></returns>
        public List<CEqpTagItem> ReadEqpTagList(DataTable dt, CEqpTagItem eqpid, int data_start_row, int data_start_col)
        {
            List<CEqpTagItem> taglist = new List<CEqpTagItem>();

            for (int row = data_start_row - 1; row < dt.Rows.Count; row++)
            {
                string tag_name = dt.Rows[row][data_start_col - 1].ToString(); // tag name
                string parent_tag_name = dt.Rows[row][data_start_col].ToString(); // parent 
                string tag_type = dt.Rows[row][data_start_col + 1].ToString(); // tag type
                string method_arg_inout = dt.Rows[row][data_start_col + 2].ToString(); // method in/out args
                string subscribe = dt.Rows[row][data_start_col + 3].ToString(); // historizing
                string batchreport = dt.Rows[row][data_start_col + 4].ToString(); // batch report

                if (string.IsNullOrEmpty(tag_name)) continue;

                if (string.IsNullOrEmpty(subscribe)) subscribe = "FALSE";
                if (string.IsNullOrEmpty(batchreport)) batchreport = "FALSE";

                CEqpTagItem parent_tag = taglist.FindInTree(parent_tag_name);
                if (parent_tag == null)
                {
                    taglist.Add(new CEqpTagItem(tag_name, tag_type, method_arg_inout, eqpid, Convert.ToBoolean(subscribe), Convert.ToBoolean(batchreport)));
                }
                else
                {
                    parent_tag.AddChild(tag_name, tag_type, method_arg_inout, null, Convert.ToBoolean(subscribe), Convert.ToBoolean(batchreport));
                }
            }

            return taglist;
        }
    }

}
