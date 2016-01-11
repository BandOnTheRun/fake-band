namespace FakeBandClientTestApp.ViewModels
{
    public class AccelerometerViewModel : ViewModelBase
    {
        private System.Double _accelerationX;
        public System.Double AccelerationX { get { return _accelerationX; } set { Set(ref _accelerationX, value); } }

        public string AccelerationXLabel { get { return nameof(AccelerationX) + MainPage.LabelPostfix; } }

        private System.Double _accelerationY;
        public System.Double AccelerationY { get { return _accelerationY; } set { Set(ref _accelerationY, value); } }

        public string AccelerationYLabel { get { return nameof(AccelerationY) + MainPage.LabelPostfix; } }

        private System.Double _accelerationZ;
        public System.Double AccelerationZ { get { return _accelerationZ; } set { Set(ref _accelerationZ, value); } }

        public string AccelerationZLabel { get { return nameof(AccelerationZ) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
