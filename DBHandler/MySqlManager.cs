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
                string where = string.Format("unit_id LIKE '{0}%'", linePrefix);
                string orderby = "unit_id ASC";

                //tb_mst_aging 전체 데이터를 조회합니다.            
                string selectQuery = string.Format($"SELECT * FROM fms_v.tb_mst_aging WHERE {where} ORDER BY {orderby}");

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
    }
}
