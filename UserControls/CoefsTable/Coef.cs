﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization;

namespace UserControls.CoefsTable
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

        private string _stringFormat = string.Empty;
        public string StringFormat
        {
            get => _stringFormat;
            set
            {
                SetProperty(ref _stringFormat, value);
                OnPropertyChanged(nameof(Value));
            }
        }
        public string Convert(decimal value)
            => value.ToString(StringFormat);
        public void ConvertBack(string value)
        {
            if (decimal.TryParse(value, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                Value = result;
            }
        }
        public bool IsSelected { get; set; }
    }
}
