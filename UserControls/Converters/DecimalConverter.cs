using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace UserControls.Converters
{
    public partial class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal dec)
            {
                return dec.ToString();
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string str)
            {
                if (decimal.TryParse(str, out decimal dec))
                {
                    return dec;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
