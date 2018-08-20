using System;

namespace Playground
{
    public class RedDot : BaseDot
    {
        public new void WriteDotOnNew()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DOT");
        }

        public override void WriteDotOnOverride()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DOT");
        }
    }

    public class BaseDot
    {
        public virtual void WriteDotOnOverride()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DOT");
        }

        public virtual void WriteDotOnNew()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DOT");
        }
    }
}