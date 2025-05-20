using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.ComplexCoefsTable
{
    public class ComplexCoef : ObservableObject
    {
        public int Index { get; set; }
        private decimal _real;
        public decimal Real
        {
            get => _real;
            set => SetProperty(ref _real, value);
        }
        private decimal _imaginary;
        public decimal Imaginary
        {
            get => _imaginary;
            set => SetProperty(ref _imaginary, value);
        }
        public Complex Value => new((double)Real, (double)Imaginary);
        private bool _isChecked = false;
        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }
        public bool IsSelected { get; set; }
    }
}
