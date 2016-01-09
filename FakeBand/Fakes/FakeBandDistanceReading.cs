using Microsoft.Band.Sensors;
using System;

namespace FakeBand.Fakes
{
    public class FakeBandDistanceReading : IBandDistanceReading
    {
        public FakeBandDistanceReading(double Speeed, long TotalDistance)
        {
            _speed = Speed;
            _pace = CalcPace(_speed);
            _distance = TotalDistance;
        }

        // speed is measured in cm/s, Pace measured in ms/m
        // Running Speed is measured in cm/s
        // - 3 - 15 miles per hour roughly walking - running
        // Running Pace is measured in ms/m
        //  3 miles per hour -> 4.8km/h -> 4800 m/h -> 480000 cm/h -> 133 cm/s
        // (convert to pace) 133 cm / s : 0.00752 s / cm-> 0.752 s / m-> 752 ms / m
        // 15 miles per hour-> 24.138km / h-> 24138 m / h-> 2413800 cm / h-> 670 cm / s
        // (convert to pace) 670 cm / s :  0.00149 s / cm-> 1.49 s / m-> 1490 ms / m
        private double CalcPace(double speed)
        {
            return 100000.0 / speed; 
        }

        public MotionType CurrentMotion
        {
            get
            {
                return Pace > 200 ? MotionType.Running : MotionType.Jogging; 
            }
        }

        public double Pace
        {
            get
            {
                return _pace;
            }
        }

        Random rnd = new Random();

        public double Speed
        {
            get
            {
                return _speed;
            }
        }

        public DateTimeOffset Timestamp
        {
            get
            {
                return DateTime.Now;
            }
        }

        long _distance;
        private double _speed;
        private double _pace;

        // Mesured in cm
        public long TotalDistance
        {
            get
            {
                return _distance;
            }
        }
    }
}
