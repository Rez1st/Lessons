using System.Threading.Tasks;

namespace Selenium
{
    public static class TimeHolder
    {
        private static readonly int ShortDelayTime = 500;
        private static readonly int LongDelayTime = 3000;
        private static readonly int DelayTime = 1500;

        public static Task Delay()
        {
            return Task.Delay(DelayTime);
        }

        public static Task ShortDelay()
        {
            return Task.Delay(ShortDelayTime);
        }

        public static Task LongDelay()
        {
            return Task.Delay(LongDelayTime);
        }
    }
}
