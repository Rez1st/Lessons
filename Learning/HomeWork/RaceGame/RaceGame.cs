using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.RaceGame.Infrastructure;
using HomeWork.RaceGame.Models;

namespace HomeWork.RaceGame
{
    public class RaceGame
    {
        private const int MaxSpeed = 300;
        private const int MinSpeed = 100;
        private const int Distance = 1000;

        private readonly List<IRaceCar> _raceCars;
        private readonly CancellationTokenSource _cts = new();
        private static readonly char[] CarLooks = {'%', '$', '#', '8', 'O', '&', '@', '+'};

        public RaceGame(string[] playerNames)
        {
            _raceCars = new List<IRaceCar>(playerNames.Length);

            for (int i = 0; i < playerNames.Length; i++)
            {
                _raceCars.Add(new RaceCar(GetRandomBetween(MinSpeed, MaxSpeed), (ConsoleColor)GetRandomBetween(1, 15))
                {
                    DriverName = playerNames[i],
                    CarLook = CarLooks[i]
                });
            }
        }

        public void Start()
        {
            var tasks = new List<Task>();
            int position = 2;

            '='.GetStrWithLength(100)
                .PrintAt(position - 2, 0, ConsoleColor.White);

            '='.GetStrWithLength(100)
                .PrintAt(0, position * _raceCars.Count + 1, ConsoleColor.White);

            foreach (var raceCar in _raceCars)
            {
                var pos = position;
                tasks.Add(new Task(() => raceCar.Drive(pos, Distance, _cts.Token)));
                position += 2;
            }

            tasks.ForEach(t => t.Start());
            Task.WaitAny(tasks.ToArray());
            _cts.Cancel();
        }

        private int GetRandomBetween(int start, int end)
        {
            return new Random().Next(start, end);
        }
    }
}
