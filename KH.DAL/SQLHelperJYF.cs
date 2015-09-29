using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.DAL
{
    public class SQLHelperJYF
    {


        public static readonly string str = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public static SqlConnection CreatConnection()
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }

        public static object ExecuteScalar(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 返回一行一列结果的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = CreatConnection())
            {

                return ExecuteScalar(conn, sql, parameters);
            }
        }
  
        public static int ExecuteNonQuery(SqlConnection conn, SqlTransaction sqltran, string sql, params SqlParameter[] ps)
        {

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();//打开数据库
                }

                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                cmd.Transaction = sqltran;//事物
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }

        }
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = CreatConnection())
            {
                return ExecuteNonQuery(conn, sql, parameters);

            }

        }

        public static DataTable ExecuteQuery(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();

            using (SqlCommand cmd = conn.CreateCommand())
            {

                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                    return table;
                }

            }

        }
        public static DataTable ExecuteQuery(string sql,
         params SqlParameter[] parameters)
        {
            using (SqlConnection conn = CreatConnection())
            {
                return ExecuteQuery(conn, sql, parameters);
            }
        }


        /// <summary>
        /// 该方法用户读取 数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>SqlDataReader类型</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
        {
            SqlConnection con = new SqlConnection(str);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                    throw ex;
                }
            }
        }
    }

}
