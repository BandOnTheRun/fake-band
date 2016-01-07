using System;
using Windows.UI.Xaml.Data;

namespace FakeBandClientTestApp.Converters
{
    public class TimeStampFormattingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var isdto = value is DateTimeOffset;
            if (!isdto)
                return value;
            var dto = (DateTimeOffset)value;
            return dto.ToString("HH:mm:ss:fff");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
