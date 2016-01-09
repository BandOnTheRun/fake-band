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

        private Random _rnd = new Random();

        public override IBandSensorReading CreateReading()
        {
            // make a flight 300 cms...
            // Generate a random target value and then move towards it slowly, when we get 
            // there, generate another..
            //int target = 0;
            //while (target == 0)
            //    target = _rnd.Next(-5, 5);

            //double steps = target * 300 / 20.0;

            var rate = _rnd.NextNormal(0.0, 5.0);

            _cachedValue = new FakeAltimeterReading((float)rate);
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