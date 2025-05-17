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
                switch (textboxAlignment)
                {
                    case TextBoxAlignment.Center:
                        return TextAlignment.Center;
                    case TextBoxAlignment.Left:
                        return TextAlignment.Left;
                    case TextBoxAlignment.Right:
                        return TextAlignment.Right;
                    case TextBoxAlignment.Justify:
                        return TextAlignment.Justify;
                    case TextBoxAlignment.DetectFromContent:
                        return TextAlignment.DetectFromContent;
                    default:
                        throw new NotImplementedException();
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is TextAlignment textAlignment)
            {
                switch (textAlignment)
                {
                    case TextAlignment.Center:
                        return TextBoxAlignment.Center;
                    case TextAlignment.Left:
                        return TextBoxAlignment.Left;
                    case TextAlignment.Right:
                        return TextBoxAlignment.Right;
                    case TextAlignment.Justify:
                        return TextBoxAlignment.Justify;
                    case TextAlignment.DetectFromContent:
                        return TextBoxAlignment.DetectFromContent;
                    default:
                        throw new NotImplementedException();
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
