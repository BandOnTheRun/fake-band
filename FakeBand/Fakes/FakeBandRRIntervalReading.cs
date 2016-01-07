using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeBandRRIntervalReading : IBandRRIntervalReading
    {
        public FakeBandRRIntervalReading(double interval)
        {
            Interval = interval;
        }

        public double Interval { get; }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }
    }
}
