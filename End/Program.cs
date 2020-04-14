using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace End
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //任务一：
            //用try - catch捕获在除法时可能出现的异常
            try
            {
                Console.WriteLine("输入被除数:");
                int bcs = int.Parse(Console.ReadLine());
                Console.WriteLine("输入除数:");
                int cs = int.Parse(Console.ReadLine());
                double s = bcs / cs;
                Console.WriteLine("商为:{0}", s);
            }
            //格式错误异常
            catch (FormatException ecf)
            {
                Console.WriteLine(ecf.Message);
            }
            //除数为零异常
            catch (DivideByZeroException ecd)
            {
                Console.WriteLine(ecd.Message);
            }
            //所有异常(出现上述没有的异常时运行这个)
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            //无论是否有异常都执行
            finally
            {
                Console.WriteLine("-----求商操作结束-----");
            }

            //任务二：
            //用除法的例子演示异常冒泡
            try
            {
                B();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Main()方法中捕获异常");
            }
            */

            string connstr = "server=.;uid=sa;pwd=mao204264;database=SuperShop";
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                conn.Open();
                string sql = "insert into test values('1','test','123456789')";
                SqlCommand comm = new SqlCommand();
                comm.CommandText = sql;
                comm.Connection = conn;
                //SqlConnection conn = new SqlConnection(sqll,conn);
                int num = comm.ExecuteNonQuery();
                if (num > 0)
                {
                    Console.WriteLine("OK");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void A()
        {
            Console.WriteLine("输入被除数:");
            int bcs = int.Parse(Console.ReadLine());
            Console.WriteLine("输入除数:");
            int cs = int.Parse(Console.ReadLine());
            double s = bcs / cs;
            Console.WriteLine("商为:{0}", s);
        }

        public static void B()
        {
            try
            {
                A();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "B()方法中捕获异常");
            }
        }
    }
}
