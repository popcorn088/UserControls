using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.Enums;

namespace UserControls.Converters
{
    public class ColumnVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ColumnVisibility visibility)
            {
                switch (visibility)
                {
                    case ColumnVisibility.Collapsed:
                        return Visibility.Collapsed;
                    case ColumnVisibility.Visible:
                        return Visibility.Visible;
                    default:
                        throw new NotImplementedException();
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
            {
                switch (visibility)
                {
                    case Visibility.Collapsed:
                        return ColumnVisibility.Collapsed;
                    case Visibility.Visible:
                        return ColumnVisibility.Visible;
                    default:
                        throw new NotImplementedException();
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
