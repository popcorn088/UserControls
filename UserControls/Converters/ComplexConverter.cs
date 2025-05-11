using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.Converters
{
    public partial class ComplexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Complex complex)
            {
                if ((string)parameter == "Re")
                {
                    return complex.Real.ToString();
                }
                else if ((string)parameter == "Im")
                {
                    return complex.Imaginary.ToString();
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string str)
            {
                /*
                if (Complex.TryParse(str, System.Globalization.NumberStyles.Float, null, out Complex complex))
                {
                    return complex;
                }
                */
                if (double.TryParse(str, System.Globalization.NumberStyles.Float, null, out double number))
                {
                    return new Complex(number, 0);
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
