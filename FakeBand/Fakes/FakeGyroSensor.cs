using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeGyroSensor : FakeBandSensor<IBandGyroscopeReading>
    {
        public FakeGyroSensor(BandTypeConstants bandType) : 
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromMilliseconds(16.0),
                SubscriptionType.AccelerometerGyroscope16MS
            },
            {
                TimeSpan.FromMilliseconds(32.0),
                SubscriptionType.AccelerometerGyroscope32MS
            },
            {
                TimeSpan.FromMilliseconds(128.0),
                SubscriptionType.AccelerometerGyroscope128MS
            }
        }, bandType)
        {
        }

        public override IBandSensorReading CreateReading()
        {
            throw new NotImplementedException();
        }
    }
}