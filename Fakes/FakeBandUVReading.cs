using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBand.Fakes
{
    public class FakeBandUVReading : IBandUVReading
    {
        public UVIndexLevel IndexLevel
        {
            get
            {
                return UVIndexLevel.Medium;
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
