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
    public class TextBoxAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TextBoxAlignment textboxAlignment)
            {
                return textboxAlignment switch
                {
                    TextBoxAlignment.Center => TextAlignment.Center,
                    TextBoxAlignment.Left => TextAlignment.Left,
                    TextBoxAlignment.Right => TextAlignment.Right,
                    TextBoxAlignment.Justify => TextAlignment.Justify,
                    TextBoxAlignment.DetectFromContent => (object)TextAlignment.DetectFromContent,
                    _ => throw new NotImplementedException(),
                };
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is TextAlignment textAlignment)
            {
                return textAlignment switch
                {
                    TextAlignment.Center => TextBoxAlignment.Center,
                    TextAlignment.Left => TextBoxAlignment.Left,
                    TextAlignment.Right => TextBoxAlignment.Right,
                    TextAlignment.Justify => TextBoxAlignment.Justify,
                    TextAlignment.DetectFromContent => (object)TextBoxAlignment.DetectFromContent,
                    _ => throw new NotImplementedException(),
                };
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
