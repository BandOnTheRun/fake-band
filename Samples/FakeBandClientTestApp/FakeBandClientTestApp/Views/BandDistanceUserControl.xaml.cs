using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class BandDistanceUserControl : UserControl
    {
        public BandDistanceViewModel BandDistanceViewModel { get; set; } = new BandDistanceViewModel();

        public BandDistanceUserControl()
        {
            Mapper.CreateMap<FakeBandDistanceReading, BandDistanceViewModel>();
            this.InitializeComponent();
        }
    }
}
