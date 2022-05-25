using System;

namespace HomeWork.IEnumeWine
{
    public static class WineHomeWorkInit
    {
        public static Wine[] Init()
        {
            var years = new DateTime[]
            {
                new(1985, 1, 1),
                new(2019, 1, 1),
                new(2008, 1, 1),
                new(1997, 1, 1),
                new(1989, 1, 1),
                new(2019, 1, 1),
                new(2019, 1, 1)
            };

            var wineArray = new Wine[]
            {
                new Wine(WineColor.White, WineType.Dry, years[0]),
                new Wine(WineColor.Rose, WineType.Sparkling, years[1]),
                new Wine(WineColor.Red, WineType.Semisweet, years[2]),
                new Wine(WineColor.Rose, WineType.Cuvee, years[3]),
                new Wine(WineColor.Red, WineType.Brut, years[4]),
                new Wine(WineColor.White, WineType.Dry, years[5]),
                new Wine(WineColor.White, WineType.Dry, years[6]),
            };

            return wineArray;
        }
    }
}
