namespace FakeBandClientTestApp.ViewModels
{
    public class BandDeviceContactViewModel : ViewModelBase
    {
        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }

        private Microsoft.Band.Sensors.BandContactState _state;
        public Microsoft.Band.Sensors.BandContactState State { get { return _state; } set { Set(ref _state, value); } }

        public string StateLabel { get { return nameof(State) + MainPage.LabelPostfix; } }
    }
}
