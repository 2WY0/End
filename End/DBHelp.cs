using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace End
{
    //封装DBHelper类
    class DBHelp
    {
        //优化
        static string MySql = "server=.;uid=sa;pwd=mao204264;database=Test";

        //增删改
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection MySqlCon = new SqlConnection(MySql);
            SqlCommand SqlRun = new SqlCommand(sql, MySqlCon);
            try
            {
                MySqlCon.Open();
                int num = SqlRun.ExecuteNonQuery();
                return num;
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                return -1;
            }
            finally
            {
                MySqlCon.Close();
            }
        }

        //查询标量
        public static object ExecuteScalar(string sql)
        {
            SqlConnection MySqlCon = new SqlConnection(MySql);
            SqlCommand SqlRun = new SqlCommand(sql, MySqlCon);
            try
            {
                MySqlCon.Open();
                return SqlRun.ExecuteScalar();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                return null;
            }
            finally
            {
                MySqlCon.Close();
            }
        }

        //查询多结果
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection MySqlCon = new SqlConnection(MySql);
            SqlCommand SqlRun = new SqlCommand(sql, MySqlCon);
            try
            {
                MySqlCon.Open();
                SqlDataReader Arr = SqlRun.ExecuteReader(CommandBehavior.CloseConnection);
                return Arr;
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                if (MySqlCon.State != ConnectionState.Closed)
                {
                    MySqlCon.Close();
                }
                return null;
            }

        }

    }
}
