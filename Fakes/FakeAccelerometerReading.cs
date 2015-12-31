using System;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeAccelerometerReading : IBandSensorReading
    {
        private int v;

        public FakeAccelerometerReading(int v)
        {
            this.v = v;
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
                ;
            }
        }
    }
}