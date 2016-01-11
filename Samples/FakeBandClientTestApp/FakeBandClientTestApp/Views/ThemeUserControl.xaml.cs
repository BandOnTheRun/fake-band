using AutoMapper;
using FakeBandClientTestApp.ViewModels;
using Microsoft.Band;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class ThemeUserControl : UserControl
    {
        public BandThemeViewModel BandThemeViewModel { get; set; } = new BandThemeViewModel();

        public ThemeUserControl()
        {
            Mapper.CreateMap<BandTheme, BandThemeViewModel>();
            this.InitializeComponent();
        }
    }
}
