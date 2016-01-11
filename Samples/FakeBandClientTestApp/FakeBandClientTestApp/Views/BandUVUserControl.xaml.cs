using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class BandUVUserControl : UserControl
    {
        public BandUVViewModel BandUVViewModel { get; set; } = new BandUVViewModel();

        public BandUVUserControl()
        {
            Mapper.CreateMap<FakeBandUVReading, BandUVViewModel>();
            this.InitializeComponent();
        }
    }
}
