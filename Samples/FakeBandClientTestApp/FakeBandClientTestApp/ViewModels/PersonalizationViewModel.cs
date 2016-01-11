using Windows.UI.Xaml.Media.Imaging;

namespace FakeBandClientTestApp.ViewModels
{
    public class PersonalizationViewModel : ViewModelBase
    {
        private WriteableBitmap _meTile;

        public WriteableBitmap MeTile
        {
            get { return _meTile; }
            set { Set(ref _meTile, value); }
        }

        public string MeTileLabel { get { return "MeTile" + MainPage.LabelPostfix; } }
    }
}
