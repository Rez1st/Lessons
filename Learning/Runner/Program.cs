using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var players = new[] { new Game.Player(), new Game.Player(), new Game.Player() };
            var game = new Game(players);
            game.Start();
        }
    }

    public class Game
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly Player[] _players;


        public Game(Player[] players)
        {
            _players = players;
        }

        public void Start()
        {
            var tasks = new List<Task>();

            if (_players.Length > 0)
                foreach (var player in _players)
                    tasks.Add(Task.Factory.StartNew(() => player.Start(_cts.Token)));

            Thread.Sleep(10000);
            _cts.Cancel();
        }

        public class GameRules
        {
            static GameRules()
            {
                //тут конечно хешсет
                Items = new List<int>();
                Guessed = new Random().Next(Min, Max);
            }

            public static List<int> Items { get; set; }
            public static int Min => 1;
            public static int Max => int.MaxValue;
            public static int Guessed { get; set; }
        }


        public class Player
        {
            public async Task Start(CancellationToken ct)
            {
                var rnd = new Random();

                while (!ct.IsCancellationRequested)
                {
                    GameRules.Items.Add(rnd.Next(GameRules.Min, GameRules.Max));
                    await Task.Delay(2);
                }
            }
        }
    }
}