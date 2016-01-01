using System;
using FakeBand.Fakes;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandSensorManager : IBandSensorManager
    {
        IBandSensor<IBandAccelerometerReading> _accelerometer = new FakeAccelerometerSensor();
        public IBandSensor<IBandAccelerometerReading> Accelerometer
        {
            get
            {
                return _accelerometer;
            }
        }

        IBandSensor<IBandCaloriesReading> _calories = new FakeCaloriesSensor();
        public IBandSensor<IBandCaloriesReading> Calories
        {
            get
            {
                return _calories;
            }
        }

        private IBandContactSensor _contact = new FakeDeviceContactSensor();
        public IBandContactSensor Contact
        {
            get
            {
                return _contact;
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

        IBandSensor<IBandGyroscopeReading> _gyroscope = new FakeGyroSensor();
        public IBandSensor<IBandGyroscopeReading> Gyroscope
        {
            get
            {
                return _gyroscope;
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

        IBandSensor<IBandPedometerReading> _pedometer = new FakePedometerSensor();
        public IBandSensor<IBandPedometerReading> Pedometer
        {
            get
            {
                return _pedometer;
            }
        }

        IBandSensor<IBandSkinTemperatureReading> _skinTemperature = new FakeSkinTemperatureSensor();
        public IBandSensor<IBandSkinTemperatureReading> SkinTemperature
        {
            get
            {
                return _skinTemperature;
            }
        }

        IBandSensor<IBandUVReading> _uv = new FakeUVSensor();
        public IBandSensor<IBandUVReading> UV
        {
            get
            {
                return _uv;
            }
        }

        IBandSensor<IBandGsrReading> _gsr = new FakeGsrSensor();
        public IBandSensor<IBandGsrReading> Gsr
        {
            get
            {
                return _gsr;
            }
        }

        IBandSensor<IBandRRIntervalReading> _rRInterval = new FakeRrSensor();
        public IBandSensor<IBandRRIntervalReading> RRInterval
        {
            get
            {
                return _rRInterval;
            }
        }

        IBandSensor<IBandAmbientLightReading> _ambientLight = new FakeAmbientLightSensor();
        public IBandSensor<IBandAmbientLightReading> AmbientLight
        {
            get
            {
                return _ambientLight;
            }
        }

        IBandSensor<IBandBarometerReading> _barometer = new FakeBarometerSensor();
        public IBandSensor<IBandBarometerReading> Barometer
        {
            get
            {
                return _barometer;
            }
        }

        IBandSensor<IBandAltimeterReading> _altimeter = new FakeAltimeterSensor();
        public IBandSensor<IBandAltimeterReading> Altimeter
        {
            get
            {
                return _altimeter;
            }
        }
    }
}
