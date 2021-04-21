using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new C();
            Console.WriteLine(c.Name);
            c.Print();
            c.Print2();

            Console.WriteLine("=====强制转换成A");
            var a = (A)c;
            a.Print2();
            a.Print();

            Console.WriteLine("=====强制转换成B");
            var b = c as B;
            b.Print();


            Console.WriteLine("创建普通手机");
            Moblie phone = new Moblie();
            phone.Call("13112345678");
            phone.TranData("电脑", "手机");

            phone.QQ("123456");

            Console.WriteLine("创建智能手机");
            SmartPhone smart = new SmartPhone();

            var usb = (IUSB)smart;
            usb.TranData("手机", "电脑");

            if (smart is IBluetooth)
            {
                var blue = smart as IBluetooth;
                blue.TranData("手机", "电脑");
            }

            if (smart is IBluetooth bt)
            {
                bt.TranData("手机", "电脑");
            }

            smart.QQ();

            var x = new Complex(1, 2);
            Console.WriteLine($"x={x}");
            var y = new Complex(3, 4);
            Console.WriteLine($"y={y}");

            var z = x + y;

            Console.WriteLine($"x+y={z}");

            /*
            var mp3 = new MP3();
            mp3.Play();

            var usn = (IUSB)mp3;
            Phone phone = new Phone();
            var usb = (IUSB)phone;
            usb.TranData("电脑", "手机");

            if (phone is IBluetooth)
            {
                var blue = phone as IBluetooth;
                blue.TranData("电脑", "手机");
            }

            if (phone is IUSB uu)
            {
                uu.TranData("电脑", "手机");
            }
            phone.Call();
            phone.DaRen("Tom");

            var a = new Complex(3, 4);
            Console.WriteLine(a);

            var b = new Complex(1, 2);
            Console.WriteLine(b);

            var c = a + b;
            Console.WriteLine(c);
            */

            Console.ReadKey();

        }

    }

    /*
    abstract class A
    {
        public string Name { get; set; }
        public A(string name)
        {
            Name = name;
            Console.WriteLine("A is Created");
        }

        public virtual void Print()
        {
            Console.WriteLine(Name);
        }
        public void Print2()
        {
            Console.WriteLine(Name);
        }

        public abstract void Print3();
    }
    class B : A
    {
        new public string Name { set; private get; }
        public B(string name) : base(name) { }
        public B() : this("B")
        {
            Console.WriteLine("B is Created");
        }

        sealed public override void Print()
        {
            base.Print();
            Console.WriteLine("Good,Good!!");
        }

        public new void Print2()
        {
            base.Print2();
            Console.WriteLine(Name);
        }

        public override void Print3()
        {
            throw new NotImplementedException();
        }
    }
    sealed class C : B
    {
        public C()
        {
            Console.WriteLine("C is Created");
        }
    }

    interface IUSB
    {
        void TranData(string from, string to);
    }

    interface IBluetooth
    {
        void TranData(string from, string to);
    }

    public class MP3 : IUSB
    {
        public void Play()
        {
            Console.WriteLine("正在播放音乐！");
        }

        public void TranData(string from, string to)
        {
            Console.WriteLine($"正在从{from}设备传输数据到{to}设备");
        }
    }

    public partial class Phone : IUSB, IBluetooth
    {
        void IUSB.TranData(string from, string to)
        {
            Console.WriteLine($"USB 正在从{from}设备传输数据到{to}设备");
        }

        void IBluetooth.TranData(string from, string to)
        {
            Console.WriteLine($"BlueTooth 正在从{from}设备传输数据到{to}设备");
        }
    }
    */
}
