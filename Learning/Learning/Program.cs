using System;
using System.Collections.Generic;
using Delegates;
using Helper;

namespace Learning
{
    internal class Program
    {
        public static Invoker invoker = Invoker.Instance;

        private static void Main(string[] args)
        {
            #region Start

            Console.WriteLine($".NET C# \n");

            #endregion

            #region Body

            invoker.Invoke(() =>
            {
                #region InvokeBody

                var ex1 = new DelegatesExamples();

                FirstEverDelegate del1 = TestDelegate.MyFuction; // We can attach delegate like this
                FirstEverDelegate del2 = new FirstEverDelegate(ex1.PrintSomeText); // or like this
                FirstEverDelegate del3 = () => { Console.WriteLine("From anonymus"); }; //this is delegate attached to anonymus method

                //add a chain to one delegate //MULTICAST
                del1 += ex1.PrintSomeText;
                del1 += (() => { Console.WriteLine("Just added more to multicast"); });

                var delList = new List<FirstEverDelegate>();
                delList.Add(del1);
                delList.Add(del2);
                delList.Add(del3);

                foreach (var del in delList)
                {
                    del.Invoke();
                }

                #endregion
            });

            #endregion

            #region End

            Console.ReadLine();

            #endregion
        }


        #region Methods

        public static void Do()
        {
        }

        #endregion
    }
}