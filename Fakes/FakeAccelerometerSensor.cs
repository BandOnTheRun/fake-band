using System;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
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