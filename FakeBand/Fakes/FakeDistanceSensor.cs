using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using FakeBand.Utils;
using System.Diagnostics;

namespace FakeBand.Fakes
{
    public class FakeDistanceSensor : FakeBandSensor<IBandDistanceReading>
    {
        internal FakeDistanceSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.Distance
            }
        }, bandType)
        {
        }

        Random rand = new Random();

        private FakeBandDistanceReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            // Running Speed is measured in cm/s
            // 3 - 15 miles per hour roughly walking - running
            // map from km/h used here to cm/s * (1000 / 36)
            DateTimeOffset lastTime;
            double newSpeed;
            DateTimeOffset time = DateTime.Now;
            if (_cachedValue != null)
            {
                lastTime = _cachedValue.Timestamp;
                double val = (-2.0 + 4.0 * rand.NextDouble());
                if (Math.Abs(val) < 0.5)
                    val = 0.0;
                newSpeed = Math.Max(Math.Min(_cachedValue.Speed + val, MaxSpeed), MinSpeed);
                _totalDistance += (long)((time - lastTime).TotalSeconds * _cachedValue.Speed);
            }
            else
            {
                newSpeed = (25.0 * 1000.0 / 36.0) * rand.NextDouble();
            }

            _cachedValue = new FakeBandDistanceReading(newSpeed, _totalDistance, time);
            Debug.WriteLine("Distance - " + _cachedValue.ToString());
            return _cachedValue;
        }

        private long _totalDistance;
        private static double MaxSpeed = 670;
        private static double MinSpeed = 0;

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandDistanceReading;
            if (nr == null)
                return false;

            return nr.CurrentMotion != _cachedValue.CurrentMotion ||
                   nr.Pace != _cachedValue.Pace ||
                   nr.Speed != _cachedValue.Speed ||
                   nr.TotalDistance != _cachedValue.TotalDistance;
        }
    }
}
