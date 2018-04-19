using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void ShowInterface()
        {
            Console.WriteLine("Input your command");

        }

        private int GetNumber()
        {
            Console.WriteLine("Input number");

            if (int.TryParse(Console.ReadLine(), out int nubmer))
                return nubmer;

            Console.WriteLine("Input number is not valid");
            return GetNumber();
        }

        private Action GetAction()
        {
            Console.WriteLine("Input action and press enter");
            Console.WriteLine("Example given : +, -, /, *");

            if (char.TryParse(Console.ReadLine(), out char action))
                switch (action)
                {
                    case '+':
                        return Action.Addition;
                    case '-':
                        return Action.Substraction;
                    case '/':
                        return Action.Division;
                    case '*':
                        return Action.Multiplication;
                    default:
                        Console.WriteLine("Can't recognize action");
                        return GetAction();
                }

            Console.WriteLine("Input action is not valid");
            return GetAction();
        }
    }

    enum Action
    {
        Addition,
        Substraction,
        Division,
        Multiplication
    }
}
