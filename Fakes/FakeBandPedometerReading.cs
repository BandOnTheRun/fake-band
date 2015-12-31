using System;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandPedometerReading : IBandPedometerReading
    {
        private readonly int _steps;

        public FakeBandPedometerReading(int steps)
        {
            _steps = steps;
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return  DateTimeOffset.Now;
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