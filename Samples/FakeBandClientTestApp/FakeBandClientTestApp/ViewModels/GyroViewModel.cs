namespace FakeBandClientTestApp.ViewModels
{
    public class GyroViewModel : ViewModelBase
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

        private System.Double _angularVelocityX;
        public System.Double AngularVelocityX { get { return _angularVelocityX; } set { Set(ref _angularVelocityX, value); } }

        public string AngularVelocityXLabel { get { return nameof(AngularVelocityX) + MainPage.LabelPostfix; } }

        private System.Double _angularVelocityY;
        public System.Double AngularVelocityY { get { return _angularVelocityY; } set { Set(ref _angularVelocityY, value); } }

        public string AngularVelocityYLabel { get { return nameof(AngularVelocityY) + MainPage.LabelPostfix; } }

        private System.Double _angularVelocityZ;
        public System.Double AngularVelocityZ { get { return _angularVelocityZ; } set { Set(ref _angularVelocityZ, value); } }

        public string AngularVelocityZLabel { get { return nameof(AngularVelocityZ) + MainPage.LabelPostfix; } }

        private System.DateTimeOffset _timestamp;
        public System.DateTimeOffset Timestamp { get { return _timestamp; } set { Set(ref _timestamp, value); } }

        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
    }
}
