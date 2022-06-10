using System;

namespace HomeWork.SeaBattle
{
    internal class SeaBattle
    {
        private static readonly string[] LetterMap = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
        private static readonly byte[] NumberCodes = {48, 49, 50, 51, 52, 53, 54, 55, 56, 57};

        private static readonly bool[,] ShipMap =
        {
            {true, false, false, false, false, false, false, false, true, false},
            {false, false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false, false},
            {false, false, true, true, false, false, false, true, false, false},
            {false, false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false, false},
            {false, false, true, false, false, false, true, true, true, false},
            {false, false, true, false, false, false, false, false, false, false},
            {true, false, true, false, false, false, false, false, false, false},
            {false, false, true, false, false, false, true, true, false, false}
        };

        public static void Play()
        {
            var hitMap = new bool?[10, 10];

            do
            {
                PrintMap(hitMap);

                var x = GetXCoordinate();
                var y = GetYCoordinate();

                hitMap[x, y] = ShipMap[x, y]; //true //true

                if (IsFinish(hitMap, ShipMap)) break;

                Console.Clear();
            } while (true);
        }

        private static void PrintMap(bool?[,] map)
        {
            const char empty = ' '; //null
            const char miss = '*'; // false
            const char hit = 'X'; // true
            for (var i = 0; i < map.GetLongLength(0) + 1; i++)
            {
                Console.Write(i == 0 ? " " : $"{LetterMap[i - 1]}");

                for (var j = 0; j < map.GetLongLength(1); j++)
                    Console.Write(
                        i == 0
                            ? $" {j} "
                            : $"[{(map[i - 1, j] == null ? empty : map[i - 1, j] == true ? hit : miss)}]");

                Console.WriteLine();
            }
        }

        private static bool IsFinish(bool?[,] hitMap, bool[,] shipMap)
        {
            byte shipHitBox = 0;
            byte hitBox = 0;

            for (var i = 0; i < hitMap.GetLongLength(0); i++)
            for (var j = 0; j < hitMap.GetLongLength(1); j++)
            {
                if (hitMap[i, j] == true) hitBox++;

                if (shipMap[i, j]) shipHitBox++;
            }

            return hitBox == shipHitBox;
        }

        private static int GetXCoordinate()
        {
            Console.Write(" Letter: ");
            var pos = Console.GetCursorPosition();
            do
            {
                var key = Console.ReadKey().KeyChar.ToString().ToUpper();

                var indexResult = Array.FindIndex(LetterMap, l => l == key);

                if (indexResult != -1) return indexResult;

                Console.SetCursorPosition(pos.Left, pos.Top);
            } while (true);
        }

        private static int GetYCoordinate()
        {
            Console.Write(" Number: ");
            var pos = Console.GetCursorPosition();

            do
            {
                var key = Console.ReadKey().KeyChar;
                var indexResult = Array.FindIndex(NumberCodes,
                    c => c == key);

                if (indexResult != -1) return indexResult;

                Console.SetCursorPosition(pos.Left, pos.Top);
            } while (true);
        }
    }
}