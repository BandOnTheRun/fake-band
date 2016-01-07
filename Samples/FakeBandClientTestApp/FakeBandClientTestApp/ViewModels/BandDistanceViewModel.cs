namespace FakeBandClientTestApp.ViewModels
{
    public class BandDistanceViewModel : ViewModelBase
    {
        private Microsoft.Band.Sensors.MotionType _currentMotion;
        public Microsoft.Band.Sensors.MotionType CurrentMotion { get { return _currentMotion; } set { Set(ref _currentMotion, value); } }

        public string CurrentMotionLabel { get { return nameof(CurrentMotion) + MainPage.LabelPostfix; } }

        private System.Double _pace;
        public System.Double Pace { get { return _pace; } set { Set(ref _pace, value); } }

        public string PaceLabel { get { return nameof(Pace) + MainPage.LabelPostfix; } }

        private System.Double _speed;
        public System.Double Speed { get { return _speed; } set { Set(ref _speed, value); } }

        public string SpeedLabel { get { return nameof(Speed) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }

        private System.Int64 _totalDistance;
        public System.Int64 TotalDistance { get { return _totalDistance; } set { Set(ref _totalDistance, value); } }

        public string TotalDistanceLabel { get { return nameof(TotalDistance) + MainPage.LabelPostfix; } }
    }
}
