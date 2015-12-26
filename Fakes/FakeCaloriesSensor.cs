using System;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeCaloriesSensor : FakeBandSensor<IBandCaloriesReading>
    {
        public override IBandSensorReading CreateReading()
        {
            throw new NotImplementedException();
        }
    }
}