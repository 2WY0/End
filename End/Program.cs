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

            //向数据库Test中的Employee表
            //添加数据
            //string MySql = "server=.;uid=sa;pwd=mao204264;database=Test";
            //SqlConnection MySqlCon = new SqlConnection(MySql);

            //string insert = "insert into Employee values('001','张三','男','1990.1.1')";
            //try
            //{
            //    MySqlCon.Open();
            //    SqlCommand SqlRun = new SqlCommand(insert, MySqlCon);
            //    int num = SqlRun.ExecuteNonQuery();
            //    if (num > 0)
            //    {
            //        Console.WriteLine("Insert Success!");
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    MySqlCon.Close();
            //}

            ////修改数据
            //string update = "update Employee set name='李四' where num='001'";
            //try
            //{
            //    MySqlCon.Open();
            //    SqlCommand SqlRun = new SqlCommand(update, MySqlCon);
            //    int num = SqlRun.ExecuteNonQuery();
            //    if (num > 0)
            //    {
            //        Console.WriteLine("update Success!");
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    MySqlCon.Close();
            //}

            ////删除数据
            //string delete = "delete from Employee";
            //try
            //{
            //    MySqlCon.Open();
            //    SqlCommand SqlRun = new SqlCommand(delete, MySqlCon);
            //    int num = SqlRun.ExecuteNonQuery();
            //    if (num > 0)
            //    {
            //        Console.WriteLine("Delete Success!");
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    MySqlCon.Close();
            //}

            ////从控制台接受用户输入员工号，查询该员工的名字。
            //Console.WriteLine("请输入员工编号：");
            //string uid = Console.ReadLine();
            //string select = string.Format("select name from Employee where num='{0}'", uid);
            //try
            //{
            //    MySqlCon.Open();
            //    SqlCommand SqlRun = new SqlCommand(select, MySqlCon);
            //    int num = SqlRun.ExecuteNonQuery();
            //    object name = SqlRun.ExecuteScalar();
            //    if (name == null)
            //    {
            //        Console.WriteLine("未查到该数据");
            //    }
            //    else
            //    {
            //        Console.WriteLine("员工姓名为：" + name);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    MySqlCon.Close();
            //}










            //从控制台接收员工的工号，查询该员工的全部信息并输出
            string MySql = "server=.;uid=sa;pwd=mao204264;database=Test";
            SqlConnection MySqlCon = new SqlConnection(MySql);
            Console.WriteLine("请输入要查询的员工编号：");
            string uid = Console.ReadLine();
            string select = string.Format("select * from Employee where num='{0}'", uid);
            try
            {
                MySqlCon.Open();
                SqlCommand SqlRun = new SqlCommand(select, MySqlCon);
                SqlDataReader SqlArr = SqlRun.ExecuteReader();
                while (SqlArr.Read())
                {
                    string name = SqlArr["name"].ToString();
                    string sex = SqlArr["sex"].ToString();
                    string birthday = SqlArr["birthday"].ToString();
                    Console.WriteLine("姓名：{0}\n性别：{1}\n生日：{2}\n", name, sex, birthday);
                }
                SqlArr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MySqlCon.Close();
            }


            //调用标量查询方法
            Console.WriteLine("员工编号：");
            string num = Console.ReadLine();
            string sql = string.Format("select name from Employee where num='{0}'", num);
            string EmpName = DBHelp.ExecuteScalar(sql).ToString();
            Console.WriteLine(EmpName == null ? "查询失败" : EmpName);

            //调用多结果查询方法
            Console.WriteLine("员工编号：");
            string EmpId = Console.ReadLine();
            string sql1 = string.Format("select * from Employee where num='{0}'", EmpId);
            try
            {
                SqlDataReader Arr = DBHelp.ExecuteReader(sql1);
                while (Arr.Read())
                {
                    string EmpName1 = Arr["name"].ToString();
                    string EmpSex = Arr["sex"].ToString();
                    string EmpBirthday = Arr["birthday"].ToString();
                    Console.WriteLine("姓名：{0}\n性别：{1}\n生日：{2}", EmpName1, EmpSex, EmpBirthday);
                }
                Arr.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            //调用增删改方法
            Console.WriteLine("员工编号：");
            string EmpId1 = Console.ReadLine();
            Console.WriteLine("新名字：");
            string NewName = Console.ReadLine();
            string sql2 = string.Format("update Employee set name='{0}' where num='{1}'", NewName, EmpId1);
            int count = DBHelp.ExecuteNonQuery(sql2);
            Console.WriteLine(count > 0 ? "更新成功" : "更新失败");













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
