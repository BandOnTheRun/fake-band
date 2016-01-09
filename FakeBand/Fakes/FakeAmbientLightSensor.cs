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

        private FakeAmbientLightReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeAmbientLightReading();
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeAmbientLightReading;
            if (nr == null)
                return false;
            return nr.Brightness != _cachedValue.Brightness;
        }
    }
}