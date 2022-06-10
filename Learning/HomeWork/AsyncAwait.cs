using System;
using System.Threading.Tasks;

namespace HomeWork
{
    public class AsyncAwait
    {
        private const int Timeout = 1500;
        private const int Answer = 42;

        /// <summary>
        ///  7.5-million years, Deep Thought determined the answer was the number 42
        /// </summary>
        /// <returns></returns>
        public async Task<int> TheAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything()
        {
            Console.WriteLine("My name is Deep Thought, I'm created" +
                              " to figure out the answer to the so-called " +
                              "Ultimate Question of Life, the Universe, and Everything");
 
            // .. 1.5 million years passed..
            await Task.Delay(Timeout);  
            Console.WriteLine("step 2");

            // .. 1.5 million years passed..
            await Task.Delay(Timeout); // userBook id = user.id
            Console.WriteLine("step 3");

            // .. 1.5 million years passed..
            await Task.Delay(Timeout);
            Console.WriteLine("step 4");

            // .. 1.5 million years passed..
            await Task.Delay(Timeout);
            Console.WriteLine("step 6");

            return Answer;
        }
    }
}
