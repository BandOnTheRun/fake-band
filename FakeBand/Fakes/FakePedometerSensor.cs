using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakePedometerSensor : FakeBandSensor<IBandPedometerReading>
    {
        public FakePedometerSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.Pedometer
            }
        }, bandType)
        {
        }

        public override IBandSensorReading CreateReading()
        {
            Random rand = new Random();
            return new FakeBandPedometerReading(rand.Next(1,5000));
        }
    }
}