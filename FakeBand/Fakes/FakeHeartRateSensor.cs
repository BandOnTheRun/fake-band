using FakeBand.Utils;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;

namespace FakeBand.Fakes
{
    public class FakeHeartRateSensor : FakeBandSensor<IBandHeartRateReading>
    {
        internal FakeHeartRateSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.HeartRate
            }
        }, bandType)
        {
        }

        Random rand = new Random();
        private FakeBandHeartRateReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeBandHeartRateReading(rand.Next(63, 130));
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandHeartRateReading;
            if (nr == null)
                return false;
            return nr.HeartRate != _cachedValue.HeartRate ||
                   nr.Quality != _cachedValue.Quality;
        }
    }
}
