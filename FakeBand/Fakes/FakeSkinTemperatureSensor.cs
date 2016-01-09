using FakeBand.Utils;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;

namespace FakeBand.Fakes
{
    public class FakeSkinTemperatureSensor : FakeBandSensor<IBandSkinTemperatureReading>
    {
        internal FakeSkinTemperatureSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromMinutes(1.0),
                SubscriptionType.SkinTemperature
            }
        }, bandType)
        {
        }

        Random _rand = new Random();

        private FakeBandSkinTemperatureReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeBandSkinTemperatureReading(_rand.Next(35, 160));
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandSkinTemperatureReading;
            if (nr == null)
                return false;
            return nr.Temperature != _cachedValue.Temperature ||
                   nr.Quality != _cachedValue.Quality;
        }
    }
}