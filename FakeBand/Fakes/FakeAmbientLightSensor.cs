using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    internal class FakeAmbientLightSensor : FakeBandSensor<IBandAmbientLightReading>
    {
        public override IBandSensorReading CreateReading()
        {
            return new FakeAmbientLightReading();
        }
    }
}