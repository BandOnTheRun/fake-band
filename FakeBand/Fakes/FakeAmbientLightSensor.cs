using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeAmbientLightSensor : FakeBandSensor<IBandAmbientLightReading>
    {
        public FakeAmbientLightSensor() :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromMilliseconds(500.0),
                SubscriptionType.AmbientLight
            }
        })
        {

        }
        public override IBandSensorReading CreateReading()
        {
            return new FakeAmbientLightReading();
        }
    }
}