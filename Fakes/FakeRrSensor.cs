using System;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeRrSensor : FakeBandSensor<IBandRRIntervalReading>
    {
        Random _rand = new Random();
        public override IBandSensorReading CreateReading()
        {
            return new FakeBandRRIntervalReading(_rand.Next(1, 5));
        }
    }
}