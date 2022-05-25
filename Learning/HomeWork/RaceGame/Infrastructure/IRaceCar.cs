using System.Threading;
using System.Threading.Tasks;

namespace HomeWork.RaceGame.Infrastructure
{
    public interface IRaceCar
    {
        protected const int SpeedModificator = 33;
        public char CarLook { get; init; }
        public int Speed { get; init; }
        Task Drive(int position, int distance, CancellationToken token = default);
    }
}