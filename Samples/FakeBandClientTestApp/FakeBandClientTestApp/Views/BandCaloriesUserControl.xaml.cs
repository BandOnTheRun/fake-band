using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class BandCaloriesUserControl : UserControl
    {
        public BandCaloriesViewModel BandCaloriesViewModel { get; set; } = new BandCaloriesViewModel();

        public BandCaloriesUserControl()
        {
            Mapper.CreateMap<FakeBandCaloriesReading, BandCaloriesViewModel>();
            this.InitializeComponent();
        }
    }
}
