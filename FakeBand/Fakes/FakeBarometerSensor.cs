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

        private Random _rand = new Random();
        private FakeBarometerReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeBarometerReading(20.0 * _rand.NextDouble(), 20.0 * _rand.NextDouble());
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBarometerReading;
            if (nr == null)
                return false;
            return nr.AirPressure != _cachedValue.AirPressure ||
                   nr.Temperature != _cachedValue.Temperature;
        }
    }
}