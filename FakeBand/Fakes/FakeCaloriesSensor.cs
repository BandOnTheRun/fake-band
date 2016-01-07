using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    internal class FakeCaloriesSensor : FakeBandSensor<IBandCaloriesReading>
    {
        public override IBandSensorReading CreateReading()
        {
            return new FakeBandCaloriesReading();
        }
    }
}