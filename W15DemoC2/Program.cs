using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W15DemoC2
{
    static class Program
    {
        static void Main()
        {
            Student s1 = new Student() { XH = "20190001002", XM = "小明" };
            //s1.Buy("牛奶", "面包", "鸡蛋");

            Console.WriteLine("=========");
            GoodMan gm = new GoodMan { XH = "20190001001", XM = "好室友" };
            gm.EatEvent += () =>
            {
                s1.Eat();
            };
            gm.BuyForOther = s1.Buy;
            ///gm.BuyForOther("牛奶", "面包");
            gm.Buy("包子");
            Console.ReadKey();
            return;

            gm.Add4Other = s1.Add;
            gm.Add4Other(1, 1);

            //gm.Add3ForOther = s1.Add3;
            //int zt = gm.Add3ForOther(1, 2, 3);

            //匿名委托
            gm.Add3ForOther = delegate (int x, int y, int z) { return x * y * z; };
            int aa = gm.Add3ForOther(1, 2, 3);

            //lambda
            gm.Add3ForOther = (int x, int y, int z) => { return x * y * z; };

            gm.Add3ForOther = (x, y, z) => x * y * z;


            Console.ReadKey();
        }



        public class Student
        {
            public string XH { get; set; }
            public string XM { get; set; }

            virtual public double Buy(params string[] lst)
            {
                double total = 5.0 * lst.Length;
                Console.WriteLine($"{XM}要买{string.Join(",", lst)},需要支付{5.0 * lst.Length}元。");

                return 5.0 * lst.Length;
            }

            public void Eat()
            {
                Console.WriteLine($"{XM}正在吃东西……");
            }

            public int Add(int x, int y)
            {
                return x + y;
            }

            public int Add3(int x, int y, int z)
            {
                return x + y + z;
            }
        }


        public class GoodMan : Student
        {
            /// <summary>
            /// 替人买
            /// </summary>
            public DelegateBuy BuyForOther { get; set; }

            public DelegateAdd Add4Other { get; set; }

            public Func<int, int, int, int> Add3ForOther { get; set; }

            public override double Buy(params string[] lst)
            {
                var total = base.Buy(lst);
                var other = BuyForOther?.Invoke("粥");

                EatEvent?.Invoke();
                return total;
            }

            public event Action EatEvent;


        }

        public delegate double DelegateBuy(params string[] args);
        public delegate int DelegateAdd(int x, int y);
        public delegate int DelegateAdd3(int x, int y, int z);
    }
}
