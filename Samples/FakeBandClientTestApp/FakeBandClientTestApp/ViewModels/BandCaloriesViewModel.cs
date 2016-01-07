namespace FakeBandClientTestApp.ViewModels
{
    public class BandCaloriesViewModel : ViewModelBase
    {
        private System.Int64 _calories;
        public System.Int64 Calories { get { return _calories; } set { Set(ref _calories, value); } }

        public string CaloriesLabel { get { return nameof(Calories) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
