using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeBarometerReading : IBandBarometerReading
    {
        public FakeBarometerReading(double AirPressure, double Temperature)
        {
            _airPressure = AirPressure;
            _temperature = Temperature;
        }

        private Random _rand = new Random();
        private double _airPressure;
        private double _temperature;

        public double AirPressure
        {
            get
            {
                return _airPressure;
            }
        }

        public double Temperature
        {
            get
            {
                return _temperature;
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}