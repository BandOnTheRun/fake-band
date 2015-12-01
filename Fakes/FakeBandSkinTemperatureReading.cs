using Microsoft.Band.Sensors;
using System;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandSkinTemperatureReading : IBandSkinTemperatureReading
    {
        public FakeBandSkinTemperatureReading(int skinTemperature)
        {
            _skinTemperature = skinTemperature;
        }

        private double _skinTemperature;
        public double Temperature
        {
            get
            {
                return _skinTemperature;
            }
        }


        public HeartRateQuality Quality
        {
            get
            {
                return HeartRateQuality.Locked;
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
