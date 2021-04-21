using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("hello world!");
                string s = Console.ReadLine();
                int i = int.Parse(s);
                int sum = i + 100;
                Console.WriteLine($"结果是:{sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error：{0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("程序执行完成");
            }
            Console.ReadKey();
        }
    }
}
