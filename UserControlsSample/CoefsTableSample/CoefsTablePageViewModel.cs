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
        private string _indexColumnHeader = "Index";
        public string IndexColumnHeader
        {
            get => _indexColumnHeader;
            set => SetProperty(ref _indexColumnHeader, value);
        }
        private string _valueColumnHeader = "Value";
        public string ValueColumnHeader
        {
            get => _valueColumnHeader;
            set => SetProperty(ref _valueColumnHeader, value);
        }
        private string _stringFormat = "F3";
        public string StringFormat
        {
            get => _stringFormat;
            set => SetProperty(ref _stringFormat, value);
        }
        private ColumnVisibility _indexColumnVisibility = ColumnVisibility.Visible;
        public ColumnVisibility IndexColumnVisibility
        {
            get => _indexColumnVisibility;
            set => SetProperty(ref _indexColumnVisibility, value);
        }
        public CoefsTablePageViewModel()
        {
            _coefs.CoefValueChanged += CoefsChanged;
            var random = new Random();
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
