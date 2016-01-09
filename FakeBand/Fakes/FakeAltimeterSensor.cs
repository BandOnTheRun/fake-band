using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeAltimeterSensor : FakeBandSensor<IBandAltimeterReading>
    {
        public FakeAltimeterSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.Elevation
            }
        }, bandType)
        {
        }

        private FakeAltimeterReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeAltimeterReading();
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeAltimeterReading;
            if (nr == null)
                return false;
            return nr.FlightsAscended != _cachedValue.FlightsAscended ||
                   nr.FlightsDescended != _cachedValue.FlightsDescended ||
                   nr.Rate != _cachedValue.Rate ||
                   nr.SteppingGain != _cachedValue.SteppingGain ||
                   nr.SteppingLoss != _cachedValue.SteppingLoss ||
                   nr.StepsAscended != _cachedValue.StepsAscended ||
                   nr.StepsDescended != _cachedValue.StepsDescended ||
                   nr.TotalGain != _cachedValue.TotalGain ||
                   nr.TotalLoss != _cachedValue.TotalLoss;
        }
    }
}