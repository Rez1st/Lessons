using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Trash
{
    public class Calc
    {
    }

    public static class Extentions
    {
        public static void Add(this Calc calc, int x, int y)
        {
            Console.WriteLine($"Sum is {x + y}");
        }

        public static int Substract(this Calc calc, int x, int y)
        {
            return x - y;
        }

        public static void PrintSome(this List<int> list)
        {
            list.Where(x => x % 2 == 0 && x % 3 == 0)
                .ToList()
                .ForEach(Console.WriteLine);

        }
    }

}
