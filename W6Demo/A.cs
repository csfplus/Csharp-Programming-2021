using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6Demo
{
    class A
    {
        public string Name { get; set; }
        public A(string name)
        {
            Name = "A";
            Console.WriteLine("A is Created");
        }

        public void Print()
        {
            Console.WriteLine("A hahaha!!!");
        }
        virtual public void Print2()
        {
            Console.WriteLine("A hahaha again!!!");
        }
    }
    class B : A
    {
        public new string Name { get; private set; }
        public B() : base("B")
        {
            //Name = "B";
            Console.WriteLine("B is Created");
        }
        public B(string name) : base(name)
        {

        }
        new public void Print()
        {
            Console.WriteLine("B hahaha!!!");
        }
    }
    sealed class C : B
    {
        public C()
        {
            Console.WriteLine("C is Created");
        }

        public override void Print2()
        {
            Console.WriteLine("C hahaha again!!!");
        }
        new public void Print()
        {
            Console.WriteLine("C hahaha!!!");
        }

    }

    abstract class D : B
    {
        abstract public void Test();
    }

    class E : D
    {
        public override void Test()
        {

        }
    }

    interface IUSB
    {
        void TranData(string from, string to);
    }

    interface IIphone
    {
        void Call(string number);
        void SendMessage(string number, string msg);
    }

    interface ISmart
    {
        void Video(string number);
    }

    interface IBluetooth
    {
        void TranData(string from, string to);
    }

    public class Phone : IIphone
    {
        public void Call(string number)
        {
            Console.WriteLine($"正在给{number}打电话");
        }

        public void SendMessage(string number, string msg)
        {
            Console.WriteLine($"正在给{number}发{msg}");
        }


    }
    public class Moblie : Phone, IUSB
    {
        public void TranData(string from, string to)
        {
            Console.WriteLine($"USB 正在从{from}传输数据到{to}");
        }
    }

    partial class SmartPhone : Phone, ISmart, IBluetooth, IUSB
    {
        public void Video(string number)
        {
            Console.WriteLine($"正在和{number}视频通话");
        }

        void IBluetooth.TranData(string from, string to)
        {
            Console.WriteLine($"BlueTooth 正在从{from}传输数据到{to}");
        }

        void IUSB.TranData(string from, string to)
        {
            Console.WriteLine($"USB 正在从{from}传输数据到{to}");
        }
    }

}
