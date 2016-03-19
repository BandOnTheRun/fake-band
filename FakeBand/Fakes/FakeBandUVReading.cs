using Microsoft.Band.Sensors;
using System;

namespace FakeBand.Fakes
{
    public class FakeBandUVReading : IBandUVReading
    {
        public long ExposureToday
        {
            get
            {
                return 12;
            }
        }

        public UVIndexLevel IndexLevel
        {
            get
            {
                return UVIndexLevel.Medium;
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
