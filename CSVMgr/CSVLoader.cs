using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CSVMgr
{

    /*
     * CSV 파일로부터 임의의 클래스의 필드값들을 채워서 해당 클래스 인스턴스의 리스트(또는 배열)을 만들어 주는 클래스이다.
     * CSV 파일의 첫 번째 줄은 필드이름이어야 한다. 이 필드이름을 사용해서 클래스 변수 중 같은 이름을 찾아 값을 넣어 준다.
     * CSV 필드이름과 클래스의 필드 이름을 비교할 때, 대소문자를 구분할 지 여부를 정해 줄 수 있다.
     * 
     * 그리고 CSV 에는 필드가 있는데, 클래스에 없다면 (주로, 새로 필드를 추가하는 경우 이런 실수 할 수 있다) Exception 을 발생시키도록 할 수 있다.
     * 에러 리턴을 하지 않고 Exception 을 발생시키는 이유는, 이러한 오류는 디버깅(코딩) 할 때 만나서 코드를 수정해야 하기 때문이다.
     * (그냥 에러 리턴을 하는 경우, 모르고 지나칠 수 있음)
     * 
     * 또한 위 옵션과 반대로, 클래스에는 필드(변수)가 있는데 CSV 에 없다면 Exception 을 발생시키도록 할 수도 있는데,
     * 이 옵션을 쓸 때는 조심해야 한다. 왜냐하면, 클래스에는 CSV 로부터 읽어들일 필드와 다른 용도로 사용할 필드가 더 있을 수 있는데
     * 이런 경우에도 Exception 을 발생시킬 것이기 때문이다. 그래서 기본 설정으로는 이 옵션을 꺼 두도록 한다.
     * 만약, CSV 에서 읽어들일 필드와 같은 필드들만으로 구성된 클래스가 있다면 이 옵션을 사용해도 될 것이다.
     * 
     */

    public class CSVLoader
    {

        /// <summary>
        /// Constructor : 읽어 들일 파일과 필드명 비교시 대소문자 구분 여부를 지정할 수 있다
        /// </summary>
        /// <param name="csv_file_path">읽어 들일 파일 경로</param>
        /// <param name="fld_name_match_ignore_case">CSV 첫줄에 있는 필드명과 클래스의 변수명을 비교해서 찾을 때, 대소문자 구분할 지 여부</param>
        /// <param name="exception_if_csv_fld_missing">클래스 변수는 있는데 CSV에는 없다면 에러</param>
        /// <param name="exception_if_class_fld_missig">CSV에는 있는데 클래스 변수가 없다면 에러</param>
        public CSVLoader(string csv_file_path, bool fld_name_match_ignore_case = true, bool exception_if_class_fld_missig = true, bool exception_if_csv_fld_missing = false)
        {
            _CSV_FILE_PATH = csv_file_path;
            _FLD_NAME_MATCH_IGNORE_CASE = fld_name_match_ignore_case;
            _EXCEPTION_WHEN_CSV_FIELD_MISSING = exception_if_csv_fld_missing;
            _EXCEPTION_WHEN_TARGET_CLASS_FIELD_MISSING = exception_if_class_fld_missig;


            // 이런 에러는 테스트 할 때 다 잡아야 한다...
            if (File.Exists(this._CSV_FILE_PATH) == false)
            {
                throw new Exception("File Not Found!!!");
            }

            // 이런 에러는 테스트 할 때 다 잡아야 한다...
            if(GetCSVHeader() == false)
            {
                throw new Exception($"{_CSV_FILE_PATH} : GetCSVHeader Failed!!!");
            }
        }





        /// <summary>
        /// 읽어 들일 CSV 파일의 Full Path
        /// </summary>
        private string _CSV_FILE_PATH = string.Empty;





        /// <summary>
        /// CSV 헤더에 있는 필드 이름과 대상 클래스의 변수이름을 비교할 때, 대소문자 구분할 지 여부
        /// </summary>
        private bool _FLD_NAME_MATCH_IGNORE_CASE = true;





        /// <summary>
        /// CSV 헤더에 있는 필드 이름을 가지고 있는 String Array
        /// </summary>
        private string[] _CSV_FLD_NAMES;
        public string[] CSV_FIELDS { get { return _CSV_FLD_NAMES; } }




        /// <summary>
        /// CSV 에는 필드가 있는데, 대상 클래스에 똑같은 이름의 필드가 없으면 Exception 발생시킬 지 여부
        /// </summary>
        private bool _EXCEPTION_WHEN_TARGET_CLASS_FIELD_MISSING = true;

        /// <summary>
        /// 대상 클래스에는 필드가 있는데, CSV에 똑같은 이름의 필드가 없으면 Exception 발생시킬 지 여부
        /// </summary>
        private bool _EXCEPTION_WHEN_CSV_FIELD_MISSING = false;




        /// <summary>
        /// CSV 파일로부터 맨 첫 줄을 읽어서, 필드들의 이름을 배열에 넣는 함수
        /// </summary>
        /// <returns></returns>
        private bool GetCSVHeader()
        {

            // 이런 에러는 테스트 할 때 다 잡아야 한다...
            if (File.Exists(this._CSV_FILE_PATH) == false)
            {
                throw new Exception("File Not Found!!!");
            }

            try
            {
                using (FileStream fs = new FileStream(_CSV_FILE_PATH, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string header_line = sr.ReadLine();

                        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                        _CSV_FLD_NAMES = CSVParser.Split(header_line);
                    }
                }
            }
            catch
            {
                return false;
            }

            return _CSV_FLD_NAMES.Length > 0;
        }





        /// <summary>
        /// _EXCEPTION_WHEN_CSV_FIELD_MISSING 옵션과 _EXCEPTION_WHEN_TARGET_CLASS_FIELD_MISSING 옵션에 따라
        /// CSV 에 있는 필드들과 클래스에 있는 필드들의 존재 여부를 확인하고 오류가 감지되면 Exception 을 발생시킨다
        /// </summary>
        /// <param name="target">대상 클래스의 Type</param>
        /// <param name="csv_header_flds">CSV 헤더에 있는 필드 이름들의 배열</param>
        /// <returns></returns>
        private bool ValidateFields(Type target_type, string[] csv_header_flds)
        {

            PropertyInfo[] props = target_type.GetProperties();

            if (_EXCEPTION_WHEN_CSV_FIELD_MISSING)
            {
                // target class 에는 필드가 있고, csv 에는 없는지 확인
                foreach(PropertyInfo p in props)
                {
                    if (p.CanWrite)
                    {
                        int csv_fld_index = GetCSVFieldIndexOf(p.Name);
                        if (csv_fld_index < 0)
                        {
                            throw new Exception("_EXCEPTION_WHEN_CSV_FIELD_MISSING");
                        }
                    }
                }
            }

            if(_EXCEPTION_WHEN_TARGET_CLASS_FIELD_MISSING)
            {
                // csv 에는 필드가 있고, target class 에는 없는지 확인
                foreach(string csv_fld in csv_header_flds)
                {
                    string comp_csv_fld = this._FLD_NAME_MATCH_IGNORE_CASE == true ? csv_fld.ToUpper() : csv_fld;

                    bool found = false;
                    foreach (PropertyInfo p in props)
                    {
                        if (p.CanWrite)
                        {
                            string comp_prop_name = this._FLD_NAME_MATCH_IGNORE_CASE == true ? p.Name.ToUpper() : p.Name;

                            if (comp_csv_fld == comp_prop_name)
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if(!found)
                    {
                        throw new Exception("_EXCEPTION_WHEN_TARGET_CLASS_FIELD_MISSING");
                    }
                }
            }

            return true;
        }


        public DataTable LoadDT()
        {
            DataTable dt = new DataTable();

            foreach(string fn in _CSV_FLD_NAMES)
                dt.Columns.Add(fn, typeof(String));

            try
            {
                using (FileStream fs = new FileStream(_CSV_FILE_PATH, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string header_line = sr.ReadLine();
                        while (sr.Peek() > 0)
                        {
                            string line = sr.ReadLine();
                            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                            string[] csv_flds = CSVParser.Split(line);

                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < _CSV_FLD_NAMES.Length; i++)
                            {
                                if(csv_flds[i] != null && csv_flds[i].Length > 0)
                                {
                                    dr[_CSV_FLD_NAMES[i]] = csv_flds[i];
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return dt;
        }


        /// <summary>
        /// Load CSV Fld values into Target Class Instance List
        /// </summary>
        /// <typeparam name="T">Target Class : MUST HAVE DEFAULT CONSTRUCTOR!!!</typeparam>
        /// <returns>List Of Target Class Instances Created From The CSV File</returns>
        public List<T> Load<T>()
        {

            // 이런 에러는 테스트 할 때 다 잡아야 한다...
            if (File.Exists(this._CSV_FILE_PATH) == false)
            {
                throw new Exception("File Not Found!!!");
            }



            List<T> targetList = new List<T>();

            try
            {
                using (FileStream fs = new FileStream(_CSV_FILE_PATH, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {

                        // bypass header_line
                        string header_line = sr.ReadLine();


                        // read data lines...
                        while (sr.Peek() > 0)
                        {
                            string line = sr.ReadLine();
                            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                            string[] csv_flds = CSVParser.Split(line);

                            try
                            {
                                T obj = (T)Activator.CreateInstance(typeof(T));
                                CSV_INTO_CLASS(obj, csv_flds);
                                targetList.Add(obj);
                            }
                            catch (TargetInvocationException tie)
                            {
                                if (tie.InnerException != null)
                                {
                                    Console.WriteLine(tie.InnerException.Message);
                                    if (tie.InnerException.InnerException != null)
                                    {
                                        Console.WriteLine(tie.InnerException.InnerException.Message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return targetList;

        }

        private void CSV_INTO_CLASS(object target, string[] csv_flds)
        {
            Type targetType = target.GetType();
            PropertyInfo[] props = targetType.GetProperties();


            for(int i = 0; i < _CSV_FLD_NAMES.Length; i++)
            {
                foreach (PropertyInfo p in props)
                {
                    if (p.CanWrite)
                    {
                        if (String.Compare(_CSV_FLD_NAMES[i], p.Name, _FLD_NAME_MATCH_IGNORE_CASE) == 0)
                        {
                            string csv_fld_val = string.Empty;
                            if (csv_flds[i] != null)
                            {
                                csv_fld_val = csv_flds[i].Trim();
                            }

                            if (p.PropertyType != typeof(string) && csv_fld_val.Length <= 0)
                            {
                                if (p.PropertyType == typeof(bool))
                                {
                                    p.SetValue(target, Convert.ChangeType("false", p.PropertyType));
                                }
                                else
                                {
                                    p.SetValue(target, Convert.ChangeType("0", p.PropertyType));
                                }
                            }
                            else
                            {
                                p.SetValue(target, Convert.ChangeType(csv_fld_val, p.PropertyType));
                            }
                            break;
                        }
                    }
                }
            }
        }

        private int GetCSVFieldIndexOf(string class_fld_name)
        {

            if (_CSV_FLD_NAMES.Length <= 0)
            {
                throw new Exception("Set CSV Field Names First");
            }

            string compare = this._FLD_NAME_MATCH_IGNORE_CASE == true ? class_fld_name.ToUpper() : class_fld_name;
            for (int i = 0; i < _CSV_FLD_NAMES.Length; i++)
            {
                string csv_fld_name = this._FLD_NAME_MATCH_IGNORE_CASE == true ? _CSV_FLD_NAMES[i].ToUpper() : _CSV_FLD_NAMES[i];
                if (compare == csv_fld_name) return i;
            }

            return -1;
        }

    }
}
