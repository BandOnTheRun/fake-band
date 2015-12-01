using Microsoft.Band.Sensors;
using System;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandHeartRateReading : IBandHeartRateReading
    {
        public FakeBandHeartRateReading(int heartRate)
        {
            _heartRate = heartRate;
        }

        private int _heartRate;
        public int HeartRate
        {
            get
            {
                return _heartRate;
            }
        }

        public HeartRateQuality Quality
        {
            get
            {
                return HeartRateQuality.Locked;
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
