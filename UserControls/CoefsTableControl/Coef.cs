using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization;

namespace UserControls.CoefsTableControl
{
    public class Coef : ObservableObject
    {
        public int Index { get; set; }
        private decimal _value;
        public decimal Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public bool IsSelected { get; set; }
    }
}
