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
            Console.WriteLine("hello world!");
            string s = Console.ReadLine();
            Console.WriteLine($"你输入的是:{s}");
            Console.ReadKey();
        }
    }
}
