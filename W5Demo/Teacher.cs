using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Demo
{
    /// <summary>
    /// C# 1.0 /JAVA
    /// </summary>
    public class Teacher
    {
        string gh;

        public void setGH(string gh) { this.gh = gh; }
        public string getGH() { return this.gh; }
    }

    /// <summary>
    /// C# 2.0
    /// </summary>
    public class Teacher2
    {
        public Teacher2()
        {
            // this.Age = DateTime.Now.Year - BirthDate.Year;
        }
        string gh;
        public string GH
        {
            get { return gh; }
            set { this.gh = value; }
        }

        //C# 3.5
        public string Name { get; set; } = "系统";

        public DateTime BirthDate { get; set; }

        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
        }

        public int Age2 => DateTime.Now.Year - BirthDate.Year;


        public void Print()
        {
            Console.WriteLine("工号:{0}\n姓名:{1}\n年龄:{2}", gh, Name, Age);
        }

        public void Print2()
        {
            Print();
        }

        public int Add(int x, int y)
        {
            var z = x + y;
            x = 15;
            return z;
        }
        public string Add(string a, string b)
        {
            var c = a + b;
            a = "AAAAAAA";
            return c;
        }

        public int Add(ref int x, int y)
        {
            var z = x + y;
            x = 15;
            return z;
        }

        public int Add(ref int x, out int y)
        {
            y = 10;
            var z = x + y;
            x = 15;
            return z;
        }

       

        public int Add(int x, int y, params int[] agrs)
        {
            Console.WriteLine("agrs.Length={0}", agrs.Length);
            return x + y;
        }
        public int Add(params int[] agrs)
        {
            int sum = 0;
            foreach (var i in agrs) sum += i;
            return sum;
        }
    }
}
