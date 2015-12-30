using System;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeAmbientLightSensor : FakeBandSensor<IBandAmbientLightReading>
    {
        public override IBandSensorReading CreateReading()
        {
            return new FakeAmbientLightReading();
        }
    }
}