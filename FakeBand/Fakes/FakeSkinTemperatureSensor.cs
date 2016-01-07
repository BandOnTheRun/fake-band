using Microsoft.Band.Sensors;
using System;

namespace FakeBand.Fakes
{
    public class FakeSkinTemperatureSensor : FakeBandSensor<IBandSkinTemperatureReading>
    {
        Random _rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandSkinTemperatureReading(_rand.Next(35, 160));
        }
    }
}