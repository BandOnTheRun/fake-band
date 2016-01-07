using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    internal class FakeGyroSensor : FakeBandSensor<IBandGyroscopeReading>
    {
        public override IBandSensorReading CreateReading()
        {
            throw new NotImplementedException();
        }
    }
}