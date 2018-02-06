using System;

namespace Delegates
{
    /// <summary>
    ///     We can declare delegates as standalone
    /// </summary>
    public delegate void FirstEverDelegate();

    /// <summary>
    /// </summary>
    public class DelegatesExamples
    {
        /// <summary>
        /// We can point on instance
        /// </summary>
        public void PrintSomeText()
        {
            Console.WriteLine("Some text");
        }
    }

    public class TestDelegate
    {
        /// <summary>
        /// We can point on static
        /// </summary>
        public static void MyFuction()
        {
            Console.WriteLine("Some other text");
        }
    }
}