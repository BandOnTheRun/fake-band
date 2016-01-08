using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    public class FakeDistanceSensor : FakeBandSensor<IBandDistanceReading>
    {
        internal FakeDistanceSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.Distance
            }
        }, bandType)
        {
        }

        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandDistanceReading();
        }
    }

}
