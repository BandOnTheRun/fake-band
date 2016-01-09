using System;
using Microsoft.Band.Sensors;
using FakeBand.Utils;
using System.Collections.Generic;

namespace FakeBand.Fakes
{
    internal class FakeRrSensor : FakeBandSensor<IBandRRIntervalReading>
    {
        public FakeRrSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.Zero,
                SubscriptionType.RRInterval
            }
        }, bandType)
        {
        }

        Random _rand = new Random();

        private FakeBandRRIntervalReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeBandRRIntervalReading(_rand.Next(1, 5));
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandRRIntervalReading;
            if (nr == null)
                return false;
            return nr.Interval != _cachedValue.Interval;
        }
    }
}