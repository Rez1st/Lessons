using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Delegates;
using Helper;
using Module3;

namespace Learning
{
    internal class Program
    {
        public static Invoker invoker = Invoker.Instance;

        private static void Main(string[] args)
        {
            #region Start

            //Console.WriteLine($".NET C# \n");

            #endregion

            #region Body

            //invoker.Invoke(() =>
            //{
            //    //new GenericLesson().Process();
            //    //new ReflectionLesson().Process();
            //    //new CollectionLesson().Process();
            //    //new MutlyThreadingLesson().Process();

            //});
            Clock clock = new Clock();
            clock.Start();

            #endregion

            #region End

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

            #endregion
        }

    }
}