using Microsoft.Band;
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace FakeBandClientTestApp.Converters
{
    public class BandThemeBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var isColor = value is BandColor;
            if (isColor == false)
                return value;
            var color = (BandColor)value;
            return new SolidColorBrush(Color.FromArgb(255, color.R, color.G, color.B));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
