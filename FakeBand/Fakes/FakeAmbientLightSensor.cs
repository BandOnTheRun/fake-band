using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeAmbientLightSensor : FakeBandSensor<IBandAmbientLightReading>
    {
        public FakeAmbientLightSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromMilliseconds(500.0),
                SubscriptionType.AmbientLight
            }
        }, bandType)
        {

        }
        public override IBandSensorReading CreateReading()
        {
            return new FakeAmbientLightReading();
        }
    }
}