using Microsoft.Band.Sensors;
using System;

namespace MSBandAzure.Services.Fakes
{
    public class FakeAmbientLightReading : IBandAmbientLightReading
    {
        public int Brightness
        {
            get
            {
                Random rnd = new Random();

                // 100,000 lux is direct sunlight. picked as an example upper limit.
                return rnd.Next(100000);
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }
    }
}
