using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeAccelerometerReading : IBandAccelerometerReading
    {
        private int x;
        private int y;
        private int z;

        public FakeAccelerometerReading(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double AccelerationX
        {
            get
            {
                return x;
            }
        }

        public double AccelerationY
        {
            get
            {
                return y;
            }
        }

        public double AccelerationZ
        {
            get
            {
                return z;
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