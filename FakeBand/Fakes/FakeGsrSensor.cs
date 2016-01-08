﻿using System;
using Microsoft.Band.Sensors;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    public class FakeGsrSensor : FakeBandSensor<IBandGsrReading>
    {
        internal FakeGsrSensor(BandTypeConstants bandType) :
            base(new List<BandType>
        {
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.FromSeconds(5.0),
                SubscriptionType.Gsr
            }
        }, bandType)
        {
        }

        public override IBandSensorReading CreateReading()
        {
            throw new NotImplementedException();
        }
    }
}