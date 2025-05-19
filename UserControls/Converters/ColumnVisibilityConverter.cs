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
                return visibility switch
                {
                    ColumnVisibility.Collapsed => Visibility.Collapsed,
                    ColumnVisibility.Visible => (object)Visibility.Visible,
                    _ => throw new NotImplementedException(),
                };
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility visibility)
            {
                return visibility switch
                {
                    Visibility.Collapsed => ColumnVisibility.Collapsed,
                    Visibility.Visible => (object)ColumnVisibility.Visible,
                    _ => throw new NotImplementedException(),
                };
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
