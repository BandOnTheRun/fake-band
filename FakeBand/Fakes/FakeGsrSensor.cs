using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeGsrSensor : FakeBandSensor<IBandGsrReading>
    {
        public override IBandSensorReading CreateReading()
        {
            throw new NotImplementedException();
        }
    }
}