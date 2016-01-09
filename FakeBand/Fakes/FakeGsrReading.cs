using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeGsrReading : IBandGsrReading
    {
        private int v;

        public FakeGsrReading(int v)
        {
            this.v = v;
        }

        public int Resistance
        {
            get
            {
                return v;
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}