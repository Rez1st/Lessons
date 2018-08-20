using System;
using Playground;

namespace Learning
{
    class Program
    {
        static void Main(string[] args)
        {

            BaseDot d = new RedDot();
            d.WriteDotOnNew();
            d.WriteDotOnOverride();

            BaseDot d1 = new BaseDot();
            d1.WriteDotOnNew();
            d1.WriteDotOnOverride();

            Console.ReadLine();
            //Если мы создаем инстанс BaseDot d = new RedDot() таким образом, то там где new будет вызван Базовый
            //Если мы создаем инстанс RedDot d = new RedDot() таким образом, то там где new будет вызван Конеретный метод который мы переопределили
        }


        public static void Delegates()
        {
            DelegateTest t = new DelegateTest();

            t.Start();
        }

        public static void Timer()
        {
            Timer.Services.Timer c = new Timer.Services.Timer();

            WashingMachine wm = new WashingMachine();
            AirConditioner ac = new AirConditioner();

            c.OnAlarm += wm.SartWash;
            c.OnAlarm += ac.StopWorking;
            c.SetAlarm(1);

            c.ShowCurrentTime();
        }
    }
}
