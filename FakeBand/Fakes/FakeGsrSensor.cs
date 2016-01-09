using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    public class FakeGsrSensor : FakeBandSensor<IBandGsrReading>
    {
        internal FakeGsrSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(5.0),
                SubscriptionType.Gsr
            }
        }, bandType)
        {
        }

        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeGsrReading(rand.Next(8, 12));
            return _cachedValue;
        }

        FakeGsrReading _cachedValue;

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeGsrReading;
            if (nr == null)
                return false;
            return _cachedValue.Resistance == nr.Resistance;
        }
    }
}