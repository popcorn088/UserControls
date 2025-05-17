using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization;

namespace UserControls.CoefsTableControl
{
    public class Coef : ObservableObject
    {
        private int _index;
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }
        private decimal _value;
        public decimal Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public bool IsSelected { get; set; }
    }
}
