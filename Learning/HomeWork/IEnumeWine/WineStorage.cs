using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.IEnumeWine
{
    public class WineStorage : IEnumerable, IEnumerator
    {
        private readonly Wine[] _bottle;
        private int _position = -1;

        public WineStorage(Wine[] wineArray)
        {
            _bottle = new Wine[wineArray.Length];

            for (var i = 0; i < wineArray.Length; i++) _bottle[i] = wineArray[i];
        }

        public Wine Current
        {
            get
            {
                try
                {
                    return _bottle[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _bottle.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current => Current;

        public WineStorage GetEnumerator()
        {
            return new WineStorage(_bottle);
        }

        public Wine[] GetByYear(DateTime date)
        {
            return _bottle.Where(wb => wb.HarvestYear.Year == date.Year).ToArray();
        }

        public IEnumerable<Wine> GetByWineType(WineType wineType)
        {
            return _bottle.Where(b => b.WineType == wineType);
        }

        public List<Wine> GetByWineColor(WineColor wineColor)
        {
            return _bottle.Where(b => b.WineColor == wineColor).ToList();
        }

        public Wine GetTheOldestHarvestYearBottle()
        {
            var minYear = _bottle.Min(wb => wb.HarvestYear.Year);
            return _bottle.FirstOrDefault(wb => wb.HarvestYear.Year == minYear);
        }

        public bool AnyOlder(int year)
        {
            return _bottle.Any(wb => wb.HarvestYear.Year < year);
        }
    }
}