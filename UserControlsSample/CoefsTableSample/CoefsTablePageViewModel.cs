using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.CoefsTableControl;
using UserControls.Enums;
using WinRT;

namespace UserControlsSample.CoefsTableSample
{
    public class CoefsTablePageViewModel : ObservableObject
    {
        private readonly Coefs _coefs = new();
        public Coefs Coefs
        {
            get => _coefs;
        }
        private string _indexHeader = "Index";
        public string IndexHeader
        {
            get => _indexHeader;
            set => SetProperty(ref _indexHeader, value);
        }
        private string _valueHeader = "Value";
        public string ValueHeader
        {
            get => _valueHeader;
            set => SetProperty(ref _valueHeader, value);
        }
        private string _stringFormat = "F3";
        public string StringFormat
        {
            get => _stringFormat;
            set => SetProperty(ref _stringFormat, value);
        }
        private ColumnVisibility _indexVisibility = ColumnVisibility.Visible;
        public ColumnVisibility IndexVisibility
        {
            get => _indexVisibility;
            set => SetProperty(ref _indexVisibility, value);
        }
        public CoefsTablePageViewModel()
        {
            _coefs.CoefValueChanged += CoefsChanged;
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                Coef item = new()
                {
                    Index = i,
                    Value = (decimal)random.NextDouble(),
                };
                _coefs.Items.Add(item);
            }
        }

        private void CoefsChanged(Coef coef)
        {

        }
    }
}
