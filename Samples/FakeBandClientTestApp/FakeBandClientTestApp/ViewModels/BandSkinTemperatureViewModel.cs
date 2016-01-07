namespace FakeBandClientTestApp.ViewModels
{
    public class BandSkinTemperatureViewModel : ViewModelBase
    {
        private System.Double _temperature;
        public System.Double Temperature { get { return _temperature; } set { Set(ref _temperature, value); } }

        public string TemperatureLabel { get { return nameof(Temperature) + MainPage.LabelPostfix; } }

        private Microsoft.Band.Sensors.HeartRateQuality _quality;
        public Microsoft.Band.Sensors.HeartRateQuality Quality { get { return _quality; } set { Set(ref _quality, value); } }

        public string QualityLabel { get { return nameof(Quality) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
