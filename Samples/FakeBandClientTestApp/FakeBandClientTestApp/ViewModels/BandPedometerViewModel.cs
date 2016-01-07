namespace FakeBandClientTestApp.ViewModels
{
    public class BandPedometerViewModel : ViewModelBase
    {
        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }

        private System.Int64 _totalSteps;
        public System.Int64 TotalSteps { get { return _totalSteps; } set { Set(ref _totalSteps, value); } }

        public string TotalStepsLabel { get { return nameof(TotalSteps) + MainPage.LabelPostfix; } }
    }
}
