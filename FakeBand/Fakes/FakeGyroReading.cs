using System;
using Microsoft.Band.Sensors;

namespace FakeBand.Fakes
{
    public class FakeGyroReading : IBandGyroscopeReading
    {
        private double accx;
        private double accy;
        private double accz;
        private double angx;
        private double angy;
        private double angz;

        public FakeGyroReading(double accx, double accy, double accz, double angx, double angy, double angz)
        {
            this.accx = accx;
            this.accy = accy;
            this.accz = accz;
            this.angx = angx;
            this.angy = angy;
            this.angz = angz;
        }

        public double AccelerationX
        {
            get
            {
                return accx;
            }
        }

        public double AccelerationY
        {
            get
            {
                return accy;
            }
        }

        public double AccelerationZ
        {
            get
            {
                return accz;
            }
        }

        public double AngularVelocityX
        {
            get
            {
                return angx;
            }
        }

        public double AngularVelocityY
        {
            get
            {
                return angy;
            }
        }

        public double AngularVelocityZ
        {
            get
            {
                return angz;
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