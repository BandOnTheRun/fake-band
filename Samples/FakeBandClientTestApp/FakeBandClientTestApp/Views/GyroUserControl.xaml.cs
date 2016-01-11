using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class GyroUserControl : UserControl
    {
        public GyroViewModel GyroViewModel { get; set; } = new GyroViewModel();

        public GyroUserControl()
        {
            Mapper.CreateMap<FakeGyroReading, GyroViewModel>();
            InitializeComponent();
        }
    }
}
