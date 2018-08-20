using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    public class RedDot : BaseDot
    {
    }

    public class BaseDot
    {
        public virtual void WriteDot()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("DOT");
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
