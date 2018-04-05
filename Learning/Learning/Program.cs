﻿using System;
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

                TestAction();

                #endregion
            });

            #endregion

            #region End

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

            #endregion
        }


        #region Methods

        public static void TestAction()
        {
            Console.Title = "My First App in A-level lecure room";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine("***** Welcome to My Awesome App *****");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        #endregion
    }
}