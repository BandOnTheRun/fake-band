using System;

namespace FakeBandClientTestApp.ViewModels
{
    public class AltimeterViewModel : ViewModelBase
    {
        private long _flightsAscended;
        private float _rate;
        private long _steppingGain;
        private long _steppingLoss;
        private long _stepsAscended;
        private long _stepsDescended;
        private DateTimeOffset _timestamp;
        private long _totalGain;
        private long _totalLoss;

        public string FlightsAscendedLabel { get { return nameof(FlightsAscended) + MainPage.LabelPostfix; } }
        public string FlightsDescendedLabel { get { return nameof(FlightsDescended) + MainPage.LabelPostfix; } }
        public string RateLabel { get { return nameof(Rate) + MainPage.LabelPostfix; } }
        public string SteppingGainLabel { get { return nameof(SteppingGain) + MainPage.LabelPostfix; } }
        public string SteppingLossLabel { get { return nameof(SteppingLoss) + MainPage.LabelPostfix; } }
        public string StepsAscendedLabel { get { return nameof(StepsAscended) + MainPage.LabelPostfix; } }
        public string StepsDescendedLabel { get { return nameof(StepsDescended) + MainPage.LabelPostfix; } }
        public string TimestampLabel { get { return nameof(Timestamp) + MainPage.LabelPostfix; } }
        public string TotalGainLabel { get { return nameof(TotalGain) + MainPage.LabelPostfix; } }
        public string TotalLossLabel { get { return nameof(TotalLoss) + MainPage.LabelPostfix; } }

        public long FlightsAscended
        {
            get { return _flightsAscended; }
            set { Set(ref _flightsAscended, value); }
        }

        private long _flightsDescended;

        public long FlightsDescended
        {
            get { return _flightsDescended; }
            set { Set(ref _flightsDescended, value); }
        }

        public float Rate
        {
            get { return _rate; }
            set { Set(ref _rate, value); }
        }
        public long SteppingGain
        {
            get { return _steppingGain; }
            set { Set(ref _steppingGain, value); }
        }
        public long SteppingLoss
        {
            get { return _steppingLoss; }
            set { Set(ref _steppingLoss, value); }
        }
        public long StepsAscended
        {
            get { return _stepsAscended; }
            set { Set(ref _stepsAscended, value); }
        }
        public long StepsDescended
        {
            get { return _stepsDescended; }
            set { Set(ref _stepsDescended, value); }
        }
        public DateTimeOffset Timestamp
        {
            get { return _timestamp; }
            set { Set(ref _timestamp, value); }
        }
        public long TotalGain
        {
            get { return _totalGain; }
            set { Set(ref _totalGain, value); }
        }
        public long TotalLoss
        {
            get { return _totalLoss; }
            set { Set(ref _totalLoss, value); }
        }
    }
}
