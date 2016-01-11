namespace FakeBandClientTestApp.ViewModels
{
    public class BandThemeViewModel : ViewModelBase
    { 
        public string ThemeLabel { get { return "Theme" + MainPage.LabelPostfix; } }

        private Microsoft.Band.BandColor _base;
        public Microsoft.Band.BandColor Base { get { return _base; } set { Set(ref _base, value); } }

        public string BaseLabel { get { return nameof(Base) + MainPage.LabelPostfix; } }

        private Microsoft.Band.BandColor _highlight;
        public Microsoft.Band.BandColor Highlight { get { return _highlight; } set { Set(ref _highlight, value); } }

        public string HighlightLabel { get { return nameof(Highlight) + MainPage.LabelPostfix; } }

        private Microsoft.Band.BandColor _lowlight;
        public Microsoft.Band.BandColor Lowlight { get { return _lowlight; } set { Set(ref _lowlight, value); } }

        public string LowlightLabel { get { return nameof(Lowlight) + MainPage.LabelPostfix; } }

        private Microsoft.Band.BandColor _secondaryText;
        public Microsoft.Band.BandColor SecondaryText { get { return _secondaryText; } set { Set(ref _secondaryText, value); } }

        public string SecondaryTextLabel { get { return nameof(SecondaryText) + MainPage.LabelPostfix; } }

        private Microsoft.Band.BandColor _highContrast;
        public Microsoft.Band.BandColor HighContrast { get { return _highContrast; } set { Set(ref _highContrast, value); } }

        public string HighContrastLabel { get { return nameof(HighContrast) + MainPage.LabelPostfix; } }

        private Microsoft.Band.BandColor _muted;
        public Microsoft.Band.BandColor Muted { get { return _muted; } set { Set(ref _muted, value); } }

        public string MutedLabel { get { return nameof(Muted) + MainPage.LabelPostfix; } }
    }
}
