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

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandCaloriesReading();
        }
    }
}