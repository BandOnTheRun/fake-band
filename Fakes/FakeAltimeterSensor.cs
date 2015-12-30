using System;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeAltimeterSensor : FakeBandSensor<IBandAltimeterReading>
    {
        public override IBandSensorReading CreateReading()
        {
            return new FakeAltimeterReading();
        }
    }
}