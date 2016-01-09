using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;
using System.Diagnostics;

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

        private DistributeValues _dist = new DistributeValues(100, 200, 1, 100000);

        private FakeAmbientLightReading _cachedValue;

        public override IBandSensorReading CreateReading()
        {
            _cachedValue = new FakeAmbientLightReading((int)_dist.Next());
            Debug.WriteLine($"Ambient light = {_cachedValue.Brightness}");
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

    public class DistributeValues
    {
        private double _maxValue;
        private double _maxWavelength;
        private double _minValue;
        private double _minWavelength;
        private Random _rand = new Random();

        private double _current;
        private double _step;
        private double _target;

        public DistributeValues(double minWavelength, double maxWavelength, double minValue, double maxValue)
        {
            _minWavelength = minWavelength;
            _maxWavelength = maxWavelength;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        private void UpdateTarget()
        {
            _target = _minValue + (_maxValue - _minValue) * _rand.NextDouble();
            var pace = _minWavelength + (_maxWavelength - _minWavelength) * _rand.NextDouble();
            var dist = _target - _current;
            _step = dist / pace;
            Debug.WriteLine($"step = {_step}");
        }

        public double Next()
        {
            if (_current >= _target)
            {
                UpdateTarget();
                Debug.WriteLine($"New target = {_target}");
            }
            _current += _step;
            return _current;
        }
    }
}