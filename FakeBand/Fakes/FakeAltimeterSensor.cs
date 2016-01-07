using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    internal class FakeAltimeterSensor : FakeBandSensor<IBandAltimeterReading>
    {
        public override IBandSensorReading CreateReading()
        {
            return new FakeAltimeterReading();
        }
    }
}