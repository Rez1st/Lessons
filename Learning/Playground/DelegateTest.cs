using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Playground
{
    public class DelegateTest
    {
        public delegate void DoVoid();

        public delegate int RunViachle(Viachle viachle);

        public List<Delegate> ListToInvoke { get; set; }

        public void Start()
        {
            //Declare delegate and adding method to invocation list;
            DoVoid d = Printhello;

            //Way to add another method to invocation list
            d = d + PrintThing;

            //anonymus method added to invocation list
            d += () =>
            {
                Console.WriteLine("Another thing");
            };

            //We can call delagates all together
            DelayRun(d);

            //they will be called as a list
            d?.Invoke();

            Console.ReadLine();
        }

        //We can specify in signature to accept delegate and invoke it as we want to
        private void DelayRun(Delegate del)
        {
            var t = 0;

            while (t <= 5)
            {
                Thread.Sleep(1000);
                t++;
            }

            del?.DynamicInvoke();
        }

        public void Printhello()
        {
            Console.WriteLine("Hello World");
        }

        public void PrintThing()
        {
            Console.WriteLine("Thing");
        }

        public void RunAllDelegates()
        {
            if (ListToInvoke.Any())
                foreach (var del in ListToInvoke)
                {
                    del?.DynamicInvoke();
                }
        }
    }

    public enum Viachle
    {
        Car,
        Airplane
    }
}
