using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakePedometerSensor : FakeBandSensor<IBandPedometerReading>
    {
        public FakePedometerSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.Pedometer
            }
        }, bandType)
        {
        }

        Random rand = new Random();

        private FakeBandPedometerReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeBandPedometerReading(rand.Next(1, 5000));
            return _cachedValue;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandPedometerReading;
            if (nr == null)
                return false;
            return nr.TotalSteps != _cachedValue.TotalSteps;
        }
    }
}