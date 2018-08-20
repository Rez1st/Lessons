using System;
using Playground;

namespace Learning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Counter counter = new Counter();

            counter.OnCount += () =>
            {
                Console.WriteLine("event rized");
            };

            counter.Start();

            Console.ReadLine();
        }

        public static string Mod(string s)
        {
            return s + "!";
        }

        private static string Add(int arg1, int arg2)
        {
            return (arg1 + arg2).ToString();
        }

        public static void Do()
        {
        }

        public static bool Doint(int i)
        {
            return true;
        }

        public static void NewOverride()
        {
            BaseDot d = new RedDot();
            d.WriteDotOnNew();
            d.WriteDotOnOverride();

            var d1 = new BaseDot();
            d1.WriteDotOnNew();
            d1.WriteDotOnOverride();

            Console.ReadLine();
            //Если мы создаем инстанс BaseDot d = new RedDot() таким образом, то там где new будет вызван Базовый
            //Если мы создаем инстанс RedDot d = new RedDot() таким образом, то там где new будет вызван Конеретный метод который мы переопределили
        }


        public static void Delegates()
        {
            var t = new DelegateTest();

            t.Start();
        }

        public static void Timer()
        {
            var c = new Timer.Services.Timer();

            var wm = new WashingMachine();
            var ac = new AirConditioner();

            c.OnAlarm += wm.SartWash;
            c.OnAlarm += ac.StopWorking;
            c.SetAlarm(1);

            c.ShowCurrentTime();
        }
    }
}