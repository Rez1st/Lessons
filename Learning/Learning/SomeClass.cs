using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    public class SomeClass
    {
        public delegate void DoSome();

        public void Print1()
        {
            Console.WriteLine("print 1");
        }

        public void Print2()
        {
            Console.WriteLine("print 2");
        }
    }
}
