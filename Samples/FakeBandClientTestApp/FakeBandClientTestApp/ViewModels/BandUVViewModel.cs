namespace FakeBandClientTestApp.ViewModels
{
    public class BandUVViewModel : ViewModelBase
    {
        private Microsoft.Band.Sensors.UVIndexLevel _indexLevel;
        public Microsoft.Band.Sensors.UVIndexLevel IndexLevel { get { return _indexLevel; } set { Set(ref _indexLevel, value); } }

        public string IndexLevelLabel { get { return nameof(IndexLevel) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
