using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace W14DemoC2
{
    static class Program
    {
        public class student
        {
            public string xh { get; set; }
            public string xm { get; set; }

            public int xb { get; set; }

            public int CId { get; set; }
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //var n = int.Parse(Console.ReadLine());
            //var list = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //for (var i = 0; i < n; i++)
            //{
            //    var arr = Console.ReadLine().Split();
            //    var x = list.IndexOf(arr[0]);
            //    var y = list.IndexOf(arr[1]);
            //    var z = x * y;
            //    x = z / 10;
            //    y = z % 10;
            //    Console.WriteLine("{0} {1}", x, y);
            //}

            //return;

            //学生名单
            List<student> lst = new List<student>
            {
                new student{xh="123",xm="sdsfsd",xb=1,CId=1},
                new student{xh="134",xm="sdsfsd",xb=0,CId=2},
                new student{xh="124",xm="sdsfsd",xb=1,CId=2},
                new student{xh="213",xm="sdsfsd",xb=1,CId=1},
                new student{xh="224",xm="sdsfsd",xb=0,CId=3},
                new student{xh="234",xm="sdsfsd",xb=1,CId=2},
            };

            //获取所有学生学号列表
            List<string> xhls = new List<string>();
            foreach (var s in lst)
                xhls.Add(s.xh);

            //linq 方法
            var ls1 = lst.Select(a => a.xh);

            //linq 语句
            var ls11 = from a in lst select a.xh;

            //sql select xh fomr lst

            //获取所有xb=1的学生名单
            List<student> xbls = new List<student>();
            foreach (var s in lst)
                if (s.xb == 1) xbls.Add(s);
            //统计数量 
            var n2 = lst.Where(x => x.xb == 1).Count();
            var n21 = lst.Count(a => a.xb == 1);

            //linq
            var ls2 = lst.Where(x => x.xb == 1);

            //linq 语句
            var ls21 = from x in lst where x.xb == 1 select x;

            var ls22 = from x in lst select x;  //lst


            //对学生先按班级升序排列，再按学号降序排列。

            //linq
            var _ = lst.OrderBy(__ => __.CId).ThenByDescending(___ => ___.xh);

            //linq 语句

            var ls31 = from x in lst
                       orderby x.CId, x.xh descending
                       select x;


            var ls4 = lst.GroupBy(a => a.CId).OrderBy(a => a.Key);
            foreach (var g in ls4)
            {
                foreach (var s in g)
                {

                }
            }

            var ls41 = from x in lst
                       group x by x.CId into a
                       orderby a.Key
                       select a;

            //var ls = lst.Select(a => a.xh);

            //var list = new List<string>();
            //foreach (var stu in lst)
            //    list.Add(stu.xh);



            //var ls1 = lst.Where(a => a.xb == 1);

            //var list1 = new List<student>();
            //foreach (var s in lst)
            //    if (s.xb == 1) list1.Add(s);

            //var ls2 = lst.OrderBy(a => a.CId).ThenBy(a => a.xh);


            //using (FileStream file = new FileStream("data.txt", FileMode.Open))
            //{
            //    using (var sr = new StreamReader(file))
            //    {
            //        List<int> ls = new List<int>();
            //        var line = sr.ReadLine();
            //        while (line != null)
            //        {
            //            ls.Add(int.Parse(line));
            //            line = sr.ReadLine();
            //        }
            //        ls.Sum();
            //    }
            //}

        }
    }
}
