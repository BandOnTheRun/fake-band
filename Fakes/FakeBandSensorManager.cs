using FakeBand.Fakes;
using Microsoft.Band.Sensors;
using System;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandSensorManager : IBandSensorManager
    {
        public IBandSensor<IBandAccelerometerReading> Accelerometer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBandSensor<IBandCaloriesReading> Calories
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBandContactSensor Contact
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        
        IBandSensor<IBandDistanceReading> _distance = new FakeDistanceSensor();

        public IBandSensor<IBandDistanceReading> Distance
        {
            get
            {
                return _distance;
            }
        }

        public IBandSensor<IBandGyroscopeReading> Gyroscope
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IBandSensor<IBandHeartRateReading> _heartRate = new FakeHeartRateSensor();
        public IBandSensor<IBandHeartRateReading> HeartRate
        {
            get
            {
                return _heartRate;
            }
        }

        public IBandSensor<IBandPedometerReading> Pedometer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBandSensor<IBandSkinTemperatureReading> _skinTemperature = new FakeSkinTemperatureSensor();
        public IBandSensor<IBandSkinTemperatureReading> SkinTemperature
        {
            get
            {
                return _skinTemperature;
            }
        }

        public IBandSensor<IBandUVReading> _uv = new FakeUVSensor();
        public IBandSensor<IBandUVReading> UV
        {
            get
            {
                return _uv;
            }
        }

        public IBandSensor<IBandGsrReading> Gsr
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBandSensor<IBandRRIntervalReading> RRInterval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBandSensor<IBandAmbientLightReading> AmbientLight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBandSensor<IBandBarometerReading> Barometer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBandSensor<IBandAltimeterReading> Altimeter
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
