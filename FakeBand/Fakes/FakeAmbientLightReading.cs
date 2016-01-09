using Microsoft.Band.Sensors;
using System;
using System.Diagnostics;

namespace FakeBand.Fakes
{
    public class FakeAmbientLightReading : IBandAmbientLightReading
    {
        private int _brightness;

        public FakeAmbientLightReading(int brightness)
        {
            _brightness = brightness;
        }
        // 0.0001 -> 100,000
        public int Brightness
        {
            get
            {
                return _brightness;
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }
    }
}
