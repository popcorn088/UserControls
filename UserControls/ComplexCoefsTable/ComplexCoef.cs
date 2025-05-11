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
        private int _index;
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }
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
        public Complex Value => new Complex((double)Real, (double)Imaginary);
        public bool IsChecked { get; set; }
        public bool IsSelected { get; set; }
    }
}
