using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.CoefsTable;
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
        private string _stringFormat = "F3";
        public string StringFormat
        {
            get
            {
                return _stringFormat;
            }
            set
            {
                SetProperty(ref _stringFormat, value);
                foreach (Coef coef in Coefs.Items)
                {
                    coef.StringFormat = _stringFormat;
                }
            }
        }
        public TextAlignment TextAlignment { get; set; }

        public CoefsTablePageViewModel()
        {
            _coefs.CoefValueChanged += CoefsChanged;
            for (int i = 0; i < 30; i++)
            {
                _coefs.Items.Add(new Coef
                {
                    Index = i,
                    Value = i,
                    StringFormat = this.StringFormat,
                    TextAlignment = this.TextAlignment,
                });
            }
        }

        private void CoefsChanged(Coef coef)
        {

        }
    }
}
