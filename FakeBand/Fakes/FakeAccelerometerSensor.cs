using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeAccelerometerSensor : FakeBandSensor<IBandAccelerometerReading>
    {
        public FakeAccelerometerSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromMilliseconds(16.0),
                SubscriptionType.Accelerometer16MS
            },
            {
                TimeSpan.FromMilliseconds(32.0),
                SubscriptionType.Accelerometer32MS
            },
            {
                TimeSpan.FromMilliseconds(128.0),
                SubscriptionType.Accelerometer128MS
            }
        }, bandType)
        {
        }

        Random rand = new Random();
        private BandTypeConstants bandType;

        public override IBandSensorReading CreateReading()
        {
            return new FakeAccelerometerReading(rand.Next(63, 130));
        }
    }
}