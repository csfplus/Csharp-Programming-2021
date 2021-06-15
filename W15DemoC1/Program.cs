using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W15DemoC1
{
    public delegate double DelegateSum(double x, double y);

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { XM = "小明" };
            //p.Buy("牛奶", "QQ糖", "青椒炒月饼");

            GoodPerson gp = new GoodPerson { XM = "好室友" };

            gp.PayforEvent += (money) => { Console.WriteLine($"收到{money}"); return money; };
            gp.Buy4Other = p.Buy;
            gp.Buy("包子");

            //匿名委托
            gp.PickSth = delegate (string s) { Console.WriteLine($"不是哪个XXX要我帮取{s}"); };

            //lambda
            gp.PickSth = (string s) => { Console.WriteLine($"楼上的XXX让我帮取{s}"); };
            gp.PickSth = s => Console.WriteLine($"楼上的XXX让我帮取{s}");


            gp.AddFunc = (x, y) => x + y;
            var t = gp.AddFunc(1, 1);
            Console.WriteLine(t);


            gp.EatAction = a => Console.WriteLine($"正在吃{a}");
            gp.EatAction("包子");




            Console.ReadKey();
            return;

            var key = Console.ReadLine();
            DelegateSum f = null;
            if (key == "+")
            {
                f = Sum;
            }
            else if (key == "/")
            {

                f = Div;
            }
            var sum = f(1.2, 3.4);
            Console.WriteLine(sum);

        }

        static public double Sum(double x, double y) { return x + y; }

        static public double Div(double x, double y) { return x / y; }

    }

    public class Person
    {
        public string XM { get; set; }

        virtual public double Buy(params string[] args)
        {
            var total = 2.0 * args.Length;
            Console.WriteLine($"{XM}要买{string.Join(",", args)},总共要支付{total}元");
            return total;
        }

        public void Pick(string sth)
        {
            Console.WriteLine($"{XM}要取{sth}");
        }
    }

    public class GoodPerson : Person
    {
        public BuySth Buy4Other { get; set; }
        public PickSth PickSth { get; set; }


        public Func<int, int, int> AddFunc { get; set; }

        public Action<string> EatAction { get; set; }


        public event Func<double, double> PayforEvent;

        public override double Buy(params string[] args)
        {
            var total = base.Buy(args);

            if (Buy4Other != null)
            {
                var money = Buy4Other("面包");
                PayforEvent?.Invoke(money);

                total += money;
            }

            return total;

        }

    }
    public delegate double BuySth(params string[] args);
    public delegate void PickSth(string sth);
}
