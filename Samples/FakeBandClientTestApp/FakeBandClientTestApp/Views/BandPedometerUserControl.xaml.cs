using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class BandPedometerUserControl : UserControl
    {
        public BandPedometerViewModel BandPedometerViewModel { get; set; } = new BandPedometerViewModel();

        public BandPedometerUserControl()
        {
            Mapper.CreateMap<FakeBandPedometerReading, BandPedometerViewModel>();
            this.InitializeComponent();
        }
    }
}
