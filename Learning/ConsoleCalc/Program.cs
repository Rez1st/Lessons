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
            ShowInterface();
        }

        public static void ShowInterface()
        {
            bool exitRequested;

            Console.WriteLine("Welcome to calculator");
            Console.WriteLine("Lets perform our actions");

            do
            {
                PerformAction(GetNumber(), GetNumber(), GetAction());

                Console.WriteLine("Another operation?");
                bool.TryParse(Console.ReadLine(), out exitRequested);
            } while (exitRequested);

        }

        private static int GetNumber()
        {
            Console.WriteLine("Input number");

            if (int.TryParse(Console.ReadLine(), out int nubmer))
                return nubmer;

            Console.WriteLine("Input number is not valid");
            return GetNumber();
        }

        private static Action GetAction()
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

        private  static double PerformAction(int firstNumber, int secondNumber, Action action)
        {
            switch (action)
            {
                case Action.Addition:
                    return firstNumber + secondNumber;
                case Action.Substraction:
                    return firstNumber - secondNumber;
                case Action.Division:
                    if (secondNumber != 0)
                        return (double)firstNumber / secondNumber;
                    Console.WriteLine("Division by Zero");
                    return 0;
                case Action.Multiplication:
                    return firstNumber * secondNumber;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
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
