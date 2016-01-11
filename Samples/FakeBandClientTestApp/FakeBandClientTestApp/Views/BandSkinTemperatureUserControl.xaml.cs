using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class BandSkinTemperatureUserControl : UserControl
    {
        public BandSkinTemperatureViewModel BandSkinTemperatureViewModel { get; set; } = new BandSkinTemperatureViewModel();

        public BandSkinTemperatureUserControl()
        {
            Mapper.CreateMap<FakeBandSkinTemperatureReading, BandSkinTemperatureViewModel>();
            this.InitializeComponent();
        }
    }
}
