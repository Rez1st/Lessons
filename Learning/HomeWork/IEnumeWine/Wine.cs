using System;

namespace HomeWork.IEnumeWine
{
    public class Wine
    {
        public WineColor WineColor;
        public WineType WineType;
        public DateTime HarvestYear;

        public Wine(WineColor wineColor, WineType wineType, DateTime harvestYear)
        {
            WineColor = wineColor;
            WineType = wineType;
            HarvestYear = harvestYear;
        }
    }
}