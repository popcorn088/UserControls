using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.ComplexCoefsTable;
using System.Numerics;
using Microsoft.UI.Xaml;

namespace UserControlsSample.ComplexCoefsTableSample
{
    public class ComplexCoefsTableViewModel : ObservableObject
    {
        private readonly ComplexCoefs _complexCoefs = new();
        public ComplexCoefs ComplexCoefs
        {
            get => _complexCoefs;
        }
        private string _indexHeader = string.Empty;
        public string IndexHeader
        {
            get => _indexHeader;
            set => SetProperty(ref _indexHeader, value);
        }
        private string _realColumnHeader = string.Empty;
        public string RealColumnHeader
        {
            get => _realColumnHeader;
            set => SetProperty(ref _realColumnHeader, value);
        }
        private string _imaginaryColumnHeader = string.Empty;
        public string ImaginaryColumnHeader
        {
            get => _imaginaryColumnHeader;
            set => SetProperty(ref _imaginaryColumnHeader, value);
        }
        private Visibility _indexVisibility = Visibility.Collapsed;
        public Visibility IndexVisibility
        {
            get => _indexVisibility;
            set => SetProperty(ref _indexVisibility, value);
        }
        private Visibility _checkBoxVisibility = Visibility.Collapsed;
        public Visibility CheckBoxVisibility
        {
            get => _checkBoxVisibility;
            set => SetProperty(ref _checkBoxVisibility, value);
        }
        public ComplexCoefsTableViewModel()
        {
            _complexCoefs.ComplexCoefValueChanged += ComplexCoefsChanged;
            for (int i = 0; i < 20; i++)
            {
                _complexCoefs.Items.Add(new ComplexCoef()
                {
                    Index = i,
                    Real = 1,
                    Imaginary = 2,
                });
            }
        }

        private void ComplexCoefsChanged(ComplexCoef coef)
        {

        }
    }
}
