using FakeBand.Utils;
using Microsoft.Band.Sensors;
using System;

namespace FakeBand.Fakes
{
    public class FakeBandSensorManager : IBandSensorManager
    {
        Lazy<IBandSensor<IBandAccelerometerReading>> _accelerometer;
        public IBandSensor<IBandAccelerometerReading> Accelerometer
        {
            get
            {
                return _accelerometer.Value;
            }
        }

        Lazy<IBandSensor<IBandCaloriesReading>> _calories;
        public IBandSensor<IBandCaloriesReading> Calories
        {
            get
            {
                return _calories.Value;
            }
        }

        private Lazy<IBandContactSensor> _contact;
        public IBandContactSensor Contact
        {
            get
            {
                return _contact.Value;
            }
        }

        
        Lazy<IBandSensor<IBandDistanceReading>> _distance;

        public IBandSensor<IBandDistanceReading> Distance
        {
            get
            {
                return _distance.Value;
            }
        }

        Lazy<IBandSensor<IBandGyroscopeReading>> _gyroscope;
        public IBandSensor<IBandGyroscopeReading> Gyroscope
        {
            get
            {
                return _gyroscope.Value;
            }
        }

        Lazy<IBandSensor<IBandHeartRateReading>> _heartRate;
        public IBandSensor<IBandHeartRateReading> HeartRate
        {
            get
            {
                return _heartRate.Value;
            }
        }

        Lazy<IBandSensor<IBandPedometerReading>> _pedometer;
        public IBandSensor<IBandPedometerReading> Pedometer
        {
            get
            {
                return _pedometer.Value;
            }
        }

        Lazy<IBandSensor<IBandSkinTemperatureReading>> _skinTemperature;
        public IBandSensor<IBandSkinTemperatureReading> SkinTemperature
        {
            get
            {
                return _skinTemperature.Value;
            }
        }

        Lazy<IBandSensor<IBandUVReading>> _uv;
        public IBandSensor<IBandUVReading> UV
        {
            get
            {
                return _uv.Value;
            }
        }

        Lazy<IBandSensor<IBandGsrReading>> _gsr;
        public IBandSensor<IBandGsrReading> Gsr
        {
            get
            {
                return _gsr.Value;
            }
        }

        Lazy<IBandSensor<IBandRRIntervalReading>> _rRInterval;
        public IBandSensor<IBandRRIntervalReading> RRInterval
        {
            get
            {
                return _rRInterval.Value;
            }
        }

        Lazy<IBandSensor<IBandAmbientLightReading>> _ambientLight;
        public IBandSensor<IBandAmbientLightReading> AmbientLight
        {
            get
            {
                return _ambientLight.Value;
            }
        }

        Lazy<IBandSensor<IBandBarometerReading>> _barometer;
        public IBandSensor<IBandBarometerReading> Barometer
        {
            get
            {
                return _barometer.Value;
            }
        }

        private BandTypeConstants _bandType;

        internal FakeBandSensorManager(BandTypeConstants bandType)
        {
            _bandType = bandType;
            _accelerometer = new Lazy<IBandSensor<IBandAccelerometerReading>>(() => new FakeAccelerometerSensor(bandType));
            _calories = new Lazy<IBandSensor<IBandCaloriesReading>>(() => new FakeCaloriesSensor(bandType));
            _contact = new Lazy<IBandContactSensor>(() => new FakeDeviceContactSensor(bandType));
            _distance = new Lazy<IBandSensor<IBandDistanceReading>>(() => new FakeDistanceSensor(bandType));
            _gyroscope = new Lazy<IBandSensor<IBandGyroscopeReading>>(() => new FakeGyroSensor(bandType));
            _heartRate = new Lazy<IBandSensor<IBandHeartRateReading>>(() => new FakeHeartRateSensor(bandType));
            _pedometer = new Lazy<IBandSensor<IBandPedometerReading>>(() => new FakePedometerSensor(bandType));
            _skinTemperature = new Lazy<IBandSensor<IBandSkinTemperatureReading>>(() => new FakeSkinTemperatureSensor(bandType));
            _uv = new Lazy<IBandSensor<IBandUVReading>>(() => new FakeUVSensor(bandType));
            _gsr = new Lazy<IBandSensor<IBandGsrReading>>(() => new FakeGsrSensor(bandType));
            _rRInterval = new Lazy<IBandSensor<IBandRRIntervalReading>>(() => new FakeRrSensor(bandType));
            _ambientLight = new Lazy<IBandSensor<IBandAmbientLightReading>>(() => new FakeAmbientLightSensor(bandType));
            _barometer = new Lazy<IBandSensor<IBandBarometerReading>>(() => new FakeBarometerSensor(bandType));
            _altimeter = new Lazy<IBandSensor<IBandAltimeterReading>>(() => new FakeAltimeterSensor(bandType));
        }

        Lazy<IBandSensor<IBandAltimeterReading>> _altimeter;

        public IBandSensor<IBandAltimeterReading> Altimeter
        {
            get
            {
                return _altimeter.Value;
            }
        }
    }
}
