using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;
using Windows.ApplicationModel.Activation;

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
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string str)
            {
                if (decimal.TryParse(str, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture, out decimal dec))
                {
                    return dec;
                }
            }

            return 0m;
        }
    }
}
