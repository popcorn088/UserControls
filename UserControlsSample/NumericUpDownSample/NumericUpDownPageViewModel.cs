using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.Enums;

namespace UserControlsSample.NumericUpDownSample
{
    public class NumericUpDownPageViewModel : ObservableObject
    {
        private decimal _value;
        public decimal Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
        private decimal _min = 0m;
        public decimal Min
        {
            get => _min;
            set => SetProperty(ref _min, value);
        }
        private decimal _max = 100m;
        public decimal Max
        {
            get => _max;
            set => SetProperty(ref _max, value);
        }
        private decimal _nick = 2m;
        public decimal Nick
        {
            get => _nick;
            set => SetProperty(ref _nick, value);
        }
        private string _stringFormat = "F2";
        public string StringFormat
        {
            get => _stringFormat;
            set => SetProperty(ref _stringFormat, value);
        }
        private TextBoxAlignment _textBoxAlignment = TextBoxAlignment.Left;
        public TextBoxAlignment TextBoxAlignment
        {
            get => _textBoxAlignment;
            set => SetProperty(ref _textBoxAlignment, value);
        }
    }
}
