using Microsoft.Band.Sensors;
using System;

namespace MSBandAzure.Services.Fakes
{
    public class FakeAltimeterReading : IBandAltimeterReading
    {
        Random rnd = new Random();

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
                return 10 * rnd.Next();
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
    }
}
