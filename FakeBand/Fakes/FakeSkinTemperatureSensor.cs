using FakeBand.Utils;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;

namespace FakeBand.Fakes
{
    public class FakeSkinTemperatureSensor : FakeBandSensor<IBandSkinTemperatureReading>
    {
        public FakeSkinTemperatureSensor() :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromMinutes(1.0),
                SubscriptionType.SkinTemperature
            }
        })
        {
        }

        Random _rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandSkinTemperatureReading(_rand.Next(35, 160));
        }
    }
}