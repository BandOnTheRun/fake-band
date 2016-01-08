﻿using FakeBand.Utils;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;

namespace FakeBand.Fakes
{
    public class FakeHeartRateSensor : FakeBandSensor<IBandHeartRateReading>
    {
        internal FakeHeartRateSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(1.0),
                SubscriptionType.HeartRate
            }
        }, bandType)
        {
        }

        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandHeartRateReading(rand.Next(63, 130));
        }
    }
}