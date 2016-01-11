namespace FakeBandClientTestApp.ViewModels
{
    public class GsrViewModel : ViewModelBase
    {
        private System.Int32 _resistance;
        public System.Int32 Resistance { get { return _resistance; } set { Set(ref _resistance, value); } }

        public string ResistanceLabel { get { return nameof(Resistance) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
