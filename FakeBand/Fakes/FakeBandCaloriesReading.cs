using Microsoft.Band.Sensors;
using System;

namespace FakeBand.Fakes
{
    public class FakeBandCaloriesReading : IBandCaloriesReading
    {
        public long Calories
        {
            get
            {
                Random rnd = new Random();
                return 5 * rnd.Next(100, 15000);
            }
        }

        public long CaloriesToday
        {
            get
            {
                return 32;
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }
    }
}
