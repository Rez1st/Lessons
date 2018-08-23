using System;
using System.Threading;

namespace LearningCore
{
    public static class Extentions
    {
        /// <summary>
        ///     Pause for given amount of seconds
        /// </summary>
        /// <param name="seconds">Seconds</param>
        /// <param name="shouldClear">Should clear the console</param>
        public static void Pause(this int seconds, bool shouldClear = false)
        {
            for (var i = 0; i < seconds; i++) Thread.Sleep(1000);

            if (shouldClear)
                Console.Clear();
        }
    }
}