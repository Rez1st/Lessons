using System;
using System.Diagnostics;

namespace Helper
{
    public sealed class Invoker
    {
        private static volatile Invoker _instance;
        private static readonly object SyncRoot = new object();

        private Invoker() { }

        public static Invoker Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new Invoker();
                    }
                }

                return _instance;
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