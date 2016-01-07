namespace FakeBandClientTestApp.ViewModels
{
    public class BandRRIntervalViewModel : ViewModelBase
    {
        private System.Double _interval;
        public System.Double Interval { get { return _interval; } set { Set(ref _interval, value); } }

        public string IntervalLabel { get { return nameof(Interval) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
