using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    internal class FakeAccelerometerSensor : FakeBandSensor<IBandAccelerometerReading>
    {
        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeAccelerometerReading(rand.Next(63, 130));
        }
    }
}