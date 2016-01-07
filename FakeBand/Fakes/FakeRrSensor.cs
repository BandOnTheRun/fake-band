using System;
using Microsoft.Band.Sensors;
using FakeBand.Utils;
using System.Collections.Generic;

namespace FakeBand.Fakes
{
    internal class FakeRrSensor : FakeBandSensor<IBandRRIntervalReading>
    {
        public FakeRrSensor() :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.Zero,
                SubscriptionType.RRInterval
            }
        })
        {
        }

        Random _rand = new Random();
        public override IBandSensorReading CreateReading()
        {
            return new FakeBandRRIntervalReading(_rand.Next(1, 5));
        }
    }
}