using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Demo
{
    /// <summary>
    /// C# 1.0
    /// </summary>
    public class Student
    {
        string xh;

        public void setXh(string xh) { this.xh = xh; }

        public string getXh() { return this.xh; }
    }

    /// <summary>
    /// C#2.0
    /// </summary>
    public class Student2
    {
        public Student2()
        {
            XM = "AADFADF";
        }
        string xh;

        public string XH
        {
            get { return this.xh; }
            set { this.xh = value; }
        }


        public string XM { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Age => DateTime.Now.Year - BirthDay.Year;


        public DateTime BirthDay { get; set; }


        public void Print()
        {
            Console.WriteLine("学号：{0}\n姓名：{1}\n年龄:{2}", xh, XM, Age);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Add(ref int x, int y)
        {
            var sum = x + y;
            return sum;
        }

        public string Add(out string a, string b)
        {
            a = "123456789";
            var c = a + b;
            return c;
        }

        public int Add(params int[] x)
        {
            var sum = 0;
            foreach (var i in x) sum += i;
            return sum;
        }

        public void Test(int x,int y,params int[] c)
        {
            Console.WriteLine(c.Length);
        }
    }
}
