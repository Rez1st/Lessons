using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.RaceGame.Infrastructure;

namespace HomeWork.RaceGame.Models
{
    public class RaceCar : IRaceCar
    {
        private const int Delta = 10;
        private static readonly object _syncLock = new();
        private int _progress;

        public RaceCar(int speed, ConsoleColor carColor)
        {
            Color = carColor;
            Speed = speed;

            lock (_syncLock)
            {
            }

        }
        
        /// <summary>
        ///     Just a re-use in normal situation you will split colors
        /// </summary>
        public ConsoleColor Color { get; init; }
        public char CarLook { get; init; }
        public int Speed { get; init; }
        public string DriverName { get; set; }

        public Task Drive(int position, int distance, CancellationToken token = default)
        {
            lock (_syncLock)
            {
                $"Driver : {DriverName}".PrintAt(_progress, position - 1, Color);
                "|".PrintAt(distance / Delta + 1, position, ConsoleColor.White);
            }
            
            while (!token.IsCancellationRequested)
            {
                lock (_syncLock)
                {
                    var sb = new StringBuilder();

                    for (var j = 0; j <= _progress; j++)
                    {
                        if (_progress == j)
                        {
                            sb.Append(CarLook);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    sb.ToString().PrintAt(0, position, Color);
                    _progress++;

                    if (distance < _progress * Delta)
                        break;
                }

                Thread.Sleep(distance / Speed * IRaceCar.SpeedModificator);
            }

            return Task.CompletedTask;
        }
    }

}