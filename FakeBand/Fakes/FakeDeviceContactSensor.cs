using System.Threading.Tasks;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using FakeBand.Utils;

namespace FakeBand.Fakes
{
    internal class FakeDeviceContactSensor : FakeBandSensor<IBandContactReading>, IBandContactSensor
    {
        public FakeDeviceContactSensor(BandTypeConstants bandType) : 
            base(new List<BandType>
        {
            BandType.Cargo,
            BandType.Envoy
        }, new Dictionary<TimeSpan, SubscriptionType>
        {
            {
                TimeSpan.Zero,
                SubscriptionType.DeviceContact
            }
        }, bandType)
        {
            State = new FakeBandDeviceContactReading(BandContactState.Worn);
        }

        private TimeSpan _reportingInterval = TimeSpan.FromSeconds(30);

        public override TimeSpan ReportingInterval
        {
            get
            {
                return _reportingInterval;
            }

            set
            {
                if (_reportingInterval == value)
                    return;
                _reportingInterval = value;
            }
        }

        private FakeBandDeviceContactReading State { get; set; }

        public async Task<IBandContactReading> GetCurrentStateAsync()
        {
            await Task.Delay(300);
            return State;
        }

        long _readingCount;

        public override IBandSensorReading CreateReading()
        {
            // Change the reading every now and again.
            if (_readingCount++ % 20 == 0)
            {
                State = new FakeBandDeviceContactReading((BandContactState)((int)(State.State + 1) % 2));
            }

            _readingCount++;
            return State;
        }

        public override bool HasReadingChanged(IBandSensorReading newReading)
        {
            var nr = newReading as FakeBandDeviceContactReading;
            if (nr == null)
                return false;
            return nr.State != State.State;
        }
    }
}