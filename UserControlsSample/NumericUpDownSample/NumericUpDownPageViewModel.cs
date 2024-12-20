using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static decimal Min => 0m;
        public static decimal Max => 100m;
        public static decimal Nick => 2m;
    }
}
