using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class AltimeterUserControl : UserControl
    {
        public AltimeterViewModel AltimeterViewModel { get; set; } = new AltimeterViewModel();

        public AltimeterUserControl()
        {
            Mapper.CreateMap<FakeAltimeterReading, AltimeterViewModel>();
            this.InitializeComponent();
        }
    }
}
