namespace FakeBandClientTestApp.ViewModels
{
    public class AmbientLightViewModel : ViewModelBase
    {
        private System.Int32 _brightness;
        public System.Int32 Brightness { get { return _brightness; } set { Set(ref _brightness, value); } }

        public string BrightnessLabel { get { return nameof(Brightness) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
