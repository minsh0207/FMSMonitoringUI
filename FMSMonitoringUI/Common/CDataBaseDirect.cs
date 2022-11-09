using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringUI.Common
{
    class CDataBaseDirect
    {
        #region [Variable]
        public static string m_strDbCon = "Data Source=192.168.10.1,1433;Initial Catalog=formation;Persist Security Info=True;User ID=formation;Password=!q2w3e4r5t;Timeout=3";
        public static SqlConnection m_dbCon;
        public static SqlDataReader m_dataReader;
        public static int m_nLockTimeOut = 3000;
        #endregion


        #region [DB Connection]
        /////////////////////////////////////////////////////////////////////
        //   Database Connection
        //===================================================================
        public static bool DBConnect()
        {
            try
            {
                // DB Connection                                         
                m_dbCon = new SqlConnection(m_strDbCon);

                // Open
                m_dbCon.Open();

                // Return Value 
                if (m_dbCon.State == ConnectionState.Open)
                {
                    // DB Lock Timeout 설정
                    CDataBaseDirect.DBSetLockTimeOut(m_nLockTimeOut);
                    return true;
                }
                else
                {
                    // 에러가 발생 되면 예외를 던진다.
                    throw new Exception();
                }
            }

            // 예외 처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB Connection Error...!!! : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Error Message
                //MessageBox.Show("DB Connection Error...!!!\n\n" + ex.Message, "ERROR");
                return false;
            }
        }
        #endregion

        #region [DB DisConnection]
        /////////////////////////////////////////////////////////////////////
        //   Database DisConnection
        //===================================================================
        public static void DBDisconnect()
        {
            // Close          
            m_dbCon.Close();
        }
        #endregion

        #region [DB ExecuteReader]
        /////////////////////////////////////////////////////////////////////
        //   ExecuteReader : ADO.NEET 연결 모델 이용
        //===================================================================
        public static SqlDataReader ExecuteReader(string strSql)
        {
            try
            {
                // Command 생성
                SqlCommand cmd = new SqlCommand(strSql, m_dbCon);
                cmd.CommandTimeout = 25;

                // Command 실행후 DataReader 얻어내기
                m_dataReader = cmd.ExecuteReader();

                // Return
                return m_dataReader;
            }

            // 예외처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB SQL Command Error...!!! : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Error Message
                //MessageBox.Show("DB SQL Command Error...!!!\n\n" + ex.Message, "ERROR");

                // Return
                return null;
            }
        }
        #endregion

        #region [DB ExecuteReader]
        /////////////////////////////////////////////////////////////////////
        //   ExecuteReader : ADO.NEET 연결 모델 이용
        //===================================================================
        public static SqlDataReader ExecuteReader(string strSql, int cmdTimeout)
        {
            try
            {
                // Command 생성
                SqlCommand cmd = new SqlCommand(strSql, m_dbCon);
                cmd.CommandTimeout = cmdTimeout;

                // Command 실행후 DataReader 얻어내기
                m_dataReader = cmd.ExecuteReader();

                // Return
                return m_dataReader;
            }

            // 예외처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB SQL Command Error...!!! : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Error Message
                //MessageBox.Show("DB SQL Command Error...!!!\n\n" + ex.Message, "ERROR");

                // Return
                return null;
            }
        }
        #endregion

        #region [DB ExecuteNonQuery]
        /////////////////////////////////////////////////////////////////////////////
        //   ExecuteNonQuery
        //===========================================================================       
        public static bool ExecuteNonQuery(string strSql)
        {
            try
            {
                // Command 생성
                SqlCommand Comm = new SqlCommand(strSql, m_dbCon);

                // ExecuteNonQuery
                Comm.ExecuteNonQuery();

                // Return
                return true;
            }

            // 예외처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB SQL ExecuteNonQuery Error...!!! : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Error Message
                //MessageBox.Show("DB SQL ExecuteNonQuery Error...!!!\n\n" + e.Message, "ERROR");

                // Return
                return false;
            }
        }
        #endregion

        #region [DB Set Lock Time Out ]
        /////////////////////////////////////////////////////////////////////
        //	DB Set Lok Time Out
        //===================================================================
        public static bool DBSetLockTimeOut(int nLockTimeOut)
        {
            // Variable
            string strSql = "";

            try
            {
                strSql = "\n" + " SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED"
                       + "\n" + " SET LOCK_TIMEOUT " + nLockTimeOut + "";

                if (CDataBaseDirect.ExecuteNonQuery(strSql) == false)
                {
                    throw new Exception();
                }

                // Return
                return true;
            }
            // 예외처리
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB Set Lock Timeout Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion
    }
}
