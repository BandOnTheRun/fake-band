using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeCaloriesSensor : FakeBandSensor<IBandCaloriesReading>
    {
        public FakeCaloriesSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.Calories1S
            }
        }, bandType)
        {
        }

        private FakeBandCaloriesReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeBandCaloriesReading();
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandCaloriesReading;
            if (nr == null)
                return false;
            return nr.Calories != _cachedValue.Calories;
        }
    }
}