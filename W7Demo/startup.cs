using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W7Demo
{
    public class startup
    {
        static void Main(string[] args)
        {
            /*----------ArrayList-----------*/

            Array array = new string[] { "aaa", "bb", "cc" };
            Console.WriteLine("Length={0}", array.Length);


            ArrayList arrayList = new ArrayList
            {
                "a",
                123,
                "a",
                "a",
                4.56
            };
            arrayList.Insert(1, 'c');
            arrayList.AddRange(new object[] { 'a', "b", 0xd3, 1.356e-5 });
            arrayList.InsertRange(3, new int[] { 1, 2, 3 });

            foreach (var o in arrayList)
                Console.Write("{0}\t", o);
            Console.WriteLine("Count={0}", arrayList.Count);

            var aa = (string)arrayList[0];
            var i = (int)arrayList[2];

            arrayList.Remove("a");
            foreach (var o in arrayList)
                Console.Write("{0}\t", o);

            Console.WriteLine("Count={0}", arrayList.Count);

            /******===========Hashtable================**/

            Hashtable ht = new Hashtable
            {
                { 1, 1 },
                { "a", 2 },
                { 'c', 333 }
            };

            Stack stack = new Stack();
            //FILO   LIFO

            stack.Push("A");
            stack.Push("B");

            var a = stack.Pop();
            Console.WriteLine(stack.Count);
            var b = stack.Peek();


            Queue queue = new Queue();
            queue.Enqueue("AAA"); //enter queue
            var k = (string)queue.Dequeue();
            //var m = queue.Peek();


            /*****************List<T>********/

            List<int> list = new List<int> { 1, 2, 3, 4, 0xd3, 0b1001_0010 };
            list.Add(100_000_444);
            list.AddRange(new int[] { 9, 8, 7, 6 });
            list.InsertRange(0, new int[] { -1, -2 });

            list.RemoveAll(x => x == 1);

            List<int> lst = new List<int> { 1, 2, 3, 0, 0, 0, 0, 0 };
            foreach (var x in lst) Console.Write("{0}\t", x);
            Console.WriteLine();
            for (var idx = 0; idx < lst.Count; idx++)
                if (lst[idx] == 0) lst.RemoveAt(idx);
            foreach (var x in lst) Console.Write("{0}\t", x);


            /**************Dict********/
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "A", 1 },
                { "B", 2 },
                { "C", 3 }
            };


            StudentList students = new StudentList()
            {
                new Student(){ Chinese=100, English=95, Math=80, XH="201912349876",XM="张三丰"},
                new Student(){ Chinese=90, English=75, Math=87, XH="201912349875",XM="张四丰"},
                new Student(){ Chinese=100, English=85, Math=84, XH="201912349874",XM="赵三丰"},
                new Student(){ Chinese=100, English=55, Math=50, XH="201912349873",XM="马三丰"}
            };

            var first = students[0];
            var second = students.FindByXh("201912349875");
            var third = students["201912349875"];










            ///*ArrayList*/
            //ArrayList arrayList = new ArrayList
            //{
            //    "a",
            //    "b",
            //  2,
            //    "a",
            //    "b"
            //};

            ////var first = (int)arrayList[1];
            ////Console.WriteLine(first);


            //arrayList.Remove("a");
            //arrayList.Remove(2);
            //arrayList.Remove("d");
            //foreach (var t in arrayList) Console.Write(t);
            //arrayList.Insert(1, "ddd");
            //Console.WriteLine("ArrayList.Count={0}", arrayList.Count);

            ///***Hashtable****/

            //Hashtable ht = new Hashtable
            //{
            //    { "A", "tttt" },
            //    { "B", 123 },
            //    { 123, "B" }
            //};
            //Console.WriteLine("A={0}", ht["A"]);
            //Console.WriteLine("Count={0}", ht.Count);

            //if (ht.ContainsKey("BB"))
            //    ht.Remove("BB");
            //Console.WriteLine("Remove BB Count={0}", ht.Count);


            //Stack stack = new Stack();

            //Queue queue = new Queue();


            ///*---------List<T>-----------*/

            //List<int> list = new List<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            ////list.Add("A");

            //foreach (var i in list)
            //    Console.Write("{0}\t", i);

            //Dictionary<string, int> dict = new Dictionary<string, int>
            //{
            //    { "A", 1 },
            //    { "B", 2 }
            //};

            //Stack<string> stackT = new Stack<string>();
            //stackT.Push("AAA");


            //StudentList students = new StudentList();
            //students.Add(new Student { Chinese = 100, English = 95, Math = 60, XH = "201912349876", XM = "张故事" });
            //students.Add(new Student { Chinese = 100, English = 95, Math = 80, XH = "201912349765", XM = "张奔在" });
            //students.Add(new Student { Chinese = 100, English = 55, Math = 96, XH = "201912349345", XM = "左奔夺" });


            //var t0 = students["201912349876", "xh"];



            Console.ReadKey();

        }
    }
}
