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

        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeGyroReading(rand.NextDouble(), rand.NextDouble(), rand.NextDouble(),
                                               rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
            return _cachedValue;
        }

        FakeGyroReading _cachedValue;

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeGyroReading;
            if (nr == null)
                return false;
            return nr.AccelerationX != _cachedValue.AccelerationX ||
                   nr.AccelerationY != _cachedValue.AccelerationY ||
                   nr.AccelerationZ != _cachedValue.AccelerationZ ||
                   nr.AngularVelocityX != _cachedValue.AngularVelocityX ||
                   nr.AngularVelocityY != _cachedValue.AngularVelocityY ||
                   nr.AngularVelocityZ != _cachedValue.AngularVelocityZ;
        }
    }
}