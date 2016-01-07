using System;

namespace FakeBandClientTestApp.ViewModels
{
    public class HeartRateViewModel : ViewModelBase
    {
        private int _heartRate;

        public int HeartRate { get { return _heartRate; } set { Set(ref _heartRate, value); } }
        public string HeartrateLabel { get { return nameof(HeartRate) + MainPage.LabelPostfix; } }

        private string _quality;

        public string Quality
        {
            get { return _quality; }
            set { Set(ref _quality, value); }
        }

        private DateTimeOffset _timeStamp;

        public DateTimeOffset TimeStamp
        {
            get { return _timeStamp; }
            set { Set(ref _timeStamp, value); }
        }

        public string QualityLabel { get { return nameof(Quality) + MainPage.LabelPostfix; } }
        public string TimestampLabel { get { return nameof(TimeStamp) + MainPage.LabelPostfix; } }
    }
}
