using FakeBandClientTestApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FakeBandClientTestApp.Views
{
    public sealed partial class PersonalizationUserControl : UserControl
    {
        public PersonalizationViewModel PersonalizationViewModel { get; set; } = new PersonalizationViewModel();

        public PersonalizationUserControl()
        {
            this.InitializeComponent();
        }
    }
}
