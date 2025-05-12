using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
            {
                switch (visibility)
                {
                    case Visibility.Collapsed:
                        return "Collapsed";
                    case Visibility.Visible:
                        return "Visible";
                    default:
                        break;
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string str)
            {
                switch (str)
                {
                    case "Collapsed":
                        return Visibility.Collapsed;
                    case "Visible":
                        return Visibility.Visible;
                    default:
                        break;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
