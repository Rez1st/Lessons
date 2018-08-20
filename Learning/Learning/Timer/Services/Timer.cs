using System;
using System.Threading;
using System.Threading.Tasks;
using Learning.Timer.Interfaces;

namespace Learning.Timer.Services
{
    public class Timer : ITimer
    {
        public delegate void CounterMethod();

        /// <summary>
        ///     Get time as 00:00
        /// </summary>
        public Timer()
        {
            Counter();
        }

        private int _currentTime { get; set; }

        private int _alarmTime { get; set; }

        public event CounterMethod OnAlarm;

        private void Counter()
        {
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //Sleep for one second
                    Thread.Sleep(1000);
                    //And increment our inner counter
                    _currentTime += 1;

                    if (_alarmTime == _currentTime) OnAlarm?.Invoke();
                } while (true);
            });
        }

        public void ShowCurrentTime()
        {
            while (true)
            {
                var time = TimeSpan.FromSeconds(_currentTime);
                var alarm = TimeSpan.FromSeconds(_alarmTime);

                Console.SetCursorPosition(15, 3);
                Console.Write($" Clock  |{time.Hours}:{time.Minutes}:{time.Seconds}|");
                Console.SetCursorPosition(0, 3);
                Console.Write($" Alarm  |{alarm.Hours}:{alarm.Minutes}:{alarm.Seconds}|");
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(1000);
            }
        }

        public void SetAlarm(int minutes)
        {
            _alarmTime = _currentTime + minutes * 60;
        }
    }
}