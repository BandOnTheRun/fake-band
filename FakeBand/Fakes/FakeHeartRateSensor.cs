using Microsoft.Band.Sensors;
using System;

namespace FakeBand.Fakes
{
    public class FakeHeartRateSensor : FakeBandSensor<IBandHeartRateReading>
    {
        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandHeartRateReading(rand.Next(63, 130));
        }
    }
}
