using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    internal class FakeBarometerSensor : FakeBandSensor<IBandBarometerReading>
    {
        public override IBandSensorReading CreateReading()
        {
            throw new NotImplementedException();
        }
    }
}