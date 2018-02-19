using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    class Class1
    {
        private int _smallestNumber { get; set; }
        private int BiggestNumber { get; set; }

        public int[] arrNumbers;

        public void GetNumbersUser()
        {
            Console.WriteLine("Введите меньшее число");
            int.TryParse(Console.ReadLine(), out int result);

            _smallestNumber = result;
        }

    }
}
