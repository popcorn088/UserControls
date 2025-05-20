using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlsSample.DecimalConverter
{
    public class DecimalConverterPageViewModel : ObservableObject
    {
        private decimal _value = 0m;
        public decimal Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }
}
