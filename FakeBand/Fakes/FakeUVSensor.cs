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

        private FakeBandUVReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeBandUVReading();
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandUVReading;
            if (nr == null)
                return false;
            return nr.IndexLevel != _cachedValue.IndexLevel;
        }
    }
}
