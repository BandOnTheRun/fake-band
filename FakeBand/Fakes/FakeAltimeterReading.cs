using Microsoft.Band.Sensors;
using System;

namespace FakeBand.Fakes
{
    public class FakeAltimeterReading : IBandAltimeterReading
    {
        public FakeAltimeterReading(float rate)
        {
            _rate = rate;
        }

        Random rnd = new Random();
        private float _rate;

        public long FlightsAscended
        {
            get
            {
                return 20 * rnd.Next();
            }
        }

        public long FlightsDescended
        {
            get
            {
                return 20 * rnd.Next();
            }
        }

        public float Rate
        {
            get
            {
                return _rate;
            }
        }

        public long SteppingGain
        {
            get
            {
                return 100 * rnd.Next();
            }
        }

        public long SteppingLoss
        {
            get
            {
                return 100 * rnd.Next();
            }
        }

        public long StepsAscended
        {
            get
            {
                return 200 * rnd.Next();
            }
        }

        public long StepsDescended
        {
            get
            {
                return 100 * rnd.Next();
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }

        public long TotalGain
        {
            get
            {
                return 500 * rnd.Next();
            }
        }

        public long TotalLoss
        {
            get
            {
                return 500 * rnd.Next();
            }
        }

        public long FlightsAscendedToday
        {
            get
            {
                return 2;
            }
        }

        public long TotalGainToday
        {
            get
            {
                return 3;
            }
        }
    }
}
