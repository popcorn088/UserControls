using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.ComplexCoefsTable;
using System.Numerics;
using Microsoft.UI.Xaml;
using UserControls.Enums;

namespace UserControlsSample.ComplexCoefsTableSample
{
    public class ComplexCoefsTableViewModel : ObservableObject
    {
        public ComplexCoefs ComplexCoefs { get; } = new();
        private string _indexColumnHeader = "Index";
        public string IndexColumnHeader
        {
            get => _indexColumnHeader;
            set => SetProperty(ref _indexColumnHeader, value);
        }
        private string _realColumnHeader = "Real";
        public string RealColumnHeader
        {
            get => _realColumnHeader;
            set => SetProperty(ref _realColumnHeader, value);
        }
        private string _imaginaryColumnHeader = "Imaginary";
        public string ImaginaryColumnHeader
        {
            get => _imaginaryColumnHeader;
            set => SetProperty(ref _imaginaryColumnHeader, value);
        }
        private ColumnVisibility _indexColumnVisibility = ColumnVisibility.Visible;
        public ColumnVisibility IndexColumnVisibility
        {
            get => _indexColumnVisibility;
            set => SetProperty(ref _indexColumnVisibility, value);
        }
        private ColumnVisibility _checkBoxColumnVisibility = ColumnVisibility.Visible;
        public ColumnVisibility CheckBoxColumnVisibility
        {
            get => _checkBoxColumnVisibility;
            set => SetProperty(ref _checkBoxColumnVisibility, value);
        }
        public ComplexCoefsTableViewModel()
        {
            ComplexCoefs.ComplexCoefValueChanged += ComplexCoefsChanged;
            var random = new Random();
            for (int i = 0; i < 20; i++)
            {
                ComplexCoefs.Items.Add(new ComplexCoef()
                {
                    Index = i,
                    Real = (decimal)random.NextDouble(),
                    Imaginary = (decimal)random.NextDouble(),
                });
            }
        }

        private void ComplexCoefsChanged(ComplexCoef coef)
        {

        }
    }
}
