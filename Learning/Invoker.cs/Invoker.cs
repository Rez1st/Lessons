using System;
using System.Diagnostics;

namespace Helper
{
    public sealed class Invoker
    {
        private static volatile Invoker instance;
        private static object syncRoot = new Object();

        private Invoker() { }

        public static Invoker Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Invoker();
                    }
                }

                return instance;
            }
        }

        public void Invoke(Action action)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("ATTN!\nProgram not completed successfully");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception occuded: \n\n Message: {e.Message} \n StackTrace: {e.StackTrace}");
            }

            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Elapsed time: {sw.Elapsed}");
            Console.ResetColor();
        }
    }
}