using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace prjC
{
     class DataAccess
    {
        public static System.Data.SqlClient.SqlConnection GetConnection()
        {
            string ConString = ConfigurationManager.ConnectionStrings["PRN292_Project"].ConnectionString;
            SqlConnection Connection = new SqlConnection(ConString);
            return Connection;
        }
        public static int ExecuteNonQuery(string sql, params SqlParameter[] @params)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(@params);
            command.Connection.Open();
            int numRows = command.ExecuteNonQuery();
            command.Connection.Close();
            return numRows;
        }
        //thuc thi cau sql, voi ds cac tham so Parameters
        public static int ExecuteSQL(string sql, params SqlParameter[] Parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(Parameters);
            command.Connection.Open();
            int count = command.ExecuteNonQuery();
            command.Connection.Close();
            return count;
        }

        public static DataTable GetDataBySQL(string sql, params SqlParameter[] Parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(Parameters);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            command.Connection.Close();
            return dt;
        }

        public static DataTable GetDataBySQLListParam(string sql, List<SqlParameter> Parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            foreach (SqlParameter param in Parameters)
            {
                command.Parameters.Add(param);
            }
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            command.Connection.Close();
            return dt;
        }

        public static DataTable GetAccountByLogin(string UserName, string Password)
        {
            string sql = "SELECT * FROM Employees WHERE AccountName = @usr AND AccountPassword = @up;";
            SqlParameter param0 = new SqlParameter("usr", System.Data.SqlDbType.NVarChar);
            param0.Value = UserName;
            SqlParameter param1 = new SqlParameter("up", System.Data.SqlDbType.NVarChar);
            param1.Value = Password;
            return GetDataBySQL(sql,param0,param1);
        }
        
        public static DataTable ExecuteReader(string sql, params SqlParameter[] @params)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(@params);
            command.Connection.Open();
            SqlDataReader sdr = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sdr);
            command.Connection.Close();
            return dataTable;
        }

        public static int ExecuteScalar(string sql, params SqlParameter[] @params)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(@params);
            command.Connection.Open();
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            command.Connection.Close();
            return id;
        }

    }
}
