using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeBarometerSensor : FakeBandSensor<IBandBarometerReading>
    {
        public FakeBarometerSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.Barometer
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