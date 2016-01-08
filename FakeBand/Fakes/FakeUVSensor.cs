using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    public class FakeUVSensor : FakeBandSensor<IBandUVReading>
    {
        internal FakeUVSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromMinutes(1.0),
                SubscriptionType.UV
            },
            {
                TimeSpan.FromMilliseconds(400.0),
                SubscriptionType.UVFast
            }
        }, bandType)
        {
        }

        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandUVReading();
        }
    }
}
