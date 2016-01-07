using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
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