using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBand.Fakes
{
    public class FakeBandDistanceReading : IBandDistanceReading
    {
        public MotionType CurrentMotion
        {
            get
            {
                return Pace > 5.0 ? MotionType.Running : MotionType.Jogging; 
            }
        }

        public double Pace
        {
            get
            {
                return 10.0 * rnd.NextDouble();
            }
        }

        Random rnd = new Random();

        public double Speed
        {
            get
            {
                return 20.0 * rnd.NextDouble();
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTime.Now;
            }
        }

        long _distance = (long)0.0;

        public long TotalDistance
        {
            get
            {
                return _distance += (long)0.3;
            }
        }
    }
}
