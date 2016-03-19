using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeBandPedometerReading : IBandPedometerReading
    {
        private readonly int _steps;
        private DateTimeOffset _timestamp;

        public FakeBandPedometerReading(int steps, DateTimeOffset timestamp)
        {
            _steps = steps;
            _timestamp = timestamp;
        }

        public long StepsToday
        {
            get
            {
                return 210;
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return _timestamp;
            }
        }

        public long TotalSteps
        {
            get
            {
                return _steps;
            }
        }
    }
}