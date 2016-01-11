using FakeBand.Fakes;
using AutoMapper;
using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class GsrUserControl : UserControl
    {
        public GsrViewModel GsrViewModel { get; set; } = new GsrViewModel();


        public GsrUserControl()
        {
            Mapper.CreateMap<FakeGsrReading, GsrViewModel>();
            this.InitializeComponent();
        }
    }
}
