using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler
{
    public partial class MySqlManager
    {
        string _connectionString;

        public MySqlManager(string connectionString)
        {
            _connectionString = connectionString;         
        }

        public DataSet SelectAgingInfo(string linePrefix)
        {
            DataSet ds = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                string where = string.Format("rack_id LIKE '{0}%'", linePrefix);
                string orderby = "rack_id ASC";

                //tb_mst_aging 전체 데이터를 조회합니다.            
                string selectQuery = string.Format($"SELECT * FROM fms_v.tb_mst_aging WHERE {where} ORDER BY {orderby}");

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, conn);

                dataAdapter.Fill(ds);

                return ds;
            }
        }

        public DataSet SelectChargerInfo()
        {
            DataSet ds = new DataSet();
            StringBuilder strSQL = new StringBuilder();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                // Set Query
                strSQL.Append(" SELECT A.tray_id, A.tray_id_2, A.unit_status, A.unit_mode, A.start_time,");
                strSQL.Append("                   B.lot_id");
                strSQL.Append("   FROM fms_v.tb_mst_unit    A");
                strSQL.Append("        LEFT OUTER JOIN fms_v.tb_dat_tray    B");
                strSQL.Append("          ON B.tray_id   = A.tray_id");
                //필수값
                strSQL.Append($" WHERE A.tray_id	            = 'F101ACHG10101'");
                //조회조건
                //if (strEqpTypeID.Length > 0) strSQL.Append($"   AND A.EqpTypeID	    = '{strEqpTypeID}'");
                //if (strUnitID.Length > 0) strSQL.Append($"   AND A.UnitID	        = '{strUnitID}'");



                //string where = string.Format("eqp_id LIKE '{0}%'", "F1CHG01");
                //string orderby = "eqp_id ASC";

                //tb_mst_unit 전체 데이터를 조회합니다.            
                //string selectQuery = string.Format($"SELECT * FROM fms_v.tb_mst_unit WHERE {where} ORDER BY {orderby}");
                //string selectQuery = string.Format($"SELECT * FROM fms_v.tb_mst_unit WHERE {where}");

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(strSQL.ToString(), conn);

                dataAdapter.Fill(ds);

                return ds;
            }
        }

        public DataSet SelectRackInfo(string rackid)
        {
            DataSet ds = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                string where = string.Format("rack_id = '{0}'", rackid);

                //tb_mst_aging 전체 데이터를 조회합니다.            
                string selectQuery = string.Format($"SELECT * FROM fms_v.tb_mst_aging WHERE {where}");

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, conn);

                dataAdapter.Fill(ds);

                return ds;
            }
        }

        /// <summary>
        /// tb_mst_aging Table에 값을 Update시킨다.
        /// </summary>
        /// <param name="updateColumn">aaaa</param>
        /// <param name="updateValue"></param>
        /// <param name="whereName"></param>
        /// <param name="whereValue"></param>
        /// <returns></returns>
        public bool UpdateAgingInfo(string updateColumn, string updateValue, string whereName, string whereValue)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                string updateQuery = string.Format($"UPDATE fms_v.tb_mst_aging " +
                                               $"SET {updateColumn} = '{updateValue}' " +
                                               $"WHERE {whereName} = '{whereValue}'");

                MySqlCommand command = new MySqlCommand(updateQuery, conn);

                command.Connection.Open();

                if (command.ExecuteNonQuery() != 1)
                {
                    command.Connection.Clone();
                    return false;
                }

                command.Connection.Clone();

                return true;
            }
        }

        public bool UpdateChargerInfo(string updateColumn, string updateValue, string whereName, string whereValue)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                string updateQuery = string.Format($"UPDATE fms_v.tb_mst_unit " +
                                               $"SET {updateColumn} = '{updateValue}' " +
                                               $"WHERE {whereName} = '{whereValue}'");

                MySqlCommand command = new MySqlCommand(updateQuery, conn);

                command.Connection.Open();

                if (command.ExecuteNonQuery() != 1)
                {
                    command.Connection.Clone();
                    return false;
                }

                command.Connection.Clone();

                return true;
            }
        }
    }
}
