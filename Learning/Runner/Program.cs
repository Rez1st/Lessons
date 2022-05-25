using System;
using System.Diagnostics;
using HomeWork.RaceGame;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                new RaceGame(new[] {"Alexandra", "Vlad", "Valentina", "Tim", "Bogdan", "Dmytro"})
                    .Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                sw.Stop();

                Console.WriteLine(sw.Elapsed);
            }

            Console.ReadLine();
        }
    }
}