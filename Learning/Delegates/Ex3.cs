using System;

namespace Delegates
{
    /// <summary>
    /// PREDICATES
    /// </summary>
    public class Ex3
    {
        public static void Do()
        {
            //
            // This Predicate instance returns true if the argument is one.
            //
            Predicate<int> isOne =
                x => x == 1;
            //
            // This Predicate returns true if the argument is greater than 4.
            //
            Predicate<int> isGreaterEqualFive =
                x => x >= 5;

            //
            // Test the Predicate instances with various parameters.
            //
            Console.WriteLine(isOne.Invoke(1));
            Console.WriteLine(isOne.Invoke(2));
            Console.WriteLine(isGreaterEqualFive.Invoke(3));
            Console.WriteLine(isGreaterEqualFive.Invoke(10));
        }
    }
}