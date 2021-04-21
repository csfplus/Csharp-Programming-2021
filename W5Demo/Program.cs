using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Student2 s = new Student2
            {
                XH = "201912452",
                XM = "张三",
                BirthDay = new DateTime(2001, 9, 5)
            };
            s.Print();

            int x = 10, y = 20;
            s.Add(ref x, y);
            Console.WriteLine(x);

            string a, b = "b";
            s.Add(out a, b);
            Console.WriteLine(a);


            s.Add(1, 2,3,4,5,6,7,8,9,10);

            s.Test(1, 2,3,4,5);
            */


            Teacher2 t = new Teacher2
            {
                BirthDate = new DateTime(2002, 10, 10),
                GH = "123456",
                Name = "张三"
            };
            Console.WriteLine("age={0}", t.Age);

            t.Print();

            int x = 1, y = 2;
            int z = t.Add(x, y);

            Console.WriteLine("x={0}，z={1}", x, z);

            string a = "a", b = "b";
            var c = t.Add(a, b);
            Console.WriteLine("a={0}，c={1}", a, c);

            z = t.Add(ref x, y);
            Console.WriteLine("ref x={0}，z={1}", x, z);


            z = t.Add(ref x, out y);
            Console.WriteLine("ref x={0}，y={1},z={2}", x, y, z);


            int h = 1, j = 2;
            var k = t.Add(ref h, j);
            var l = t.Add(ref h, out int m);


            var f = t.Add(1, 2, 3, 4, 5, 6, 7, 8, 9);



            Console.ReadKey();


        }
    }
}
