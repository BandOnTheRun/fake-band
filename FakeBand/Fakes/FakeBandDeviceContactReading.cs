using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeBandDeviceContactReading : IBandContactReading
    {
        public FakeBandDeviceContactReading(BandContactState bandContactState)
        {
            State = bandContactState;
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }

        public BandContactState State { get; }
    }
}