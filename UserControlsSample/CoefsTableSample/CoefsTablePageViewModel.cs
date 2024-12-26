using CommunityToolkit.Mvvm.ComponentModel;
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
        public ObservableCollection<Coef> Coefs
        {
            get => _coefs.Items;
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
                foreach (Coef coef in Coefs)
                {
                    coef.StringFormat = _stringFormat;
                }
            }
        }

        public CoefsTablePageViewModel()
        {
            _coefs.CoefValueChanged += CoefsChanged;
            _coefs.Items.Add(new Coef() { Index = 1, Value = 10, StringFormat = this.StringFormat});
        }

        private void CoefsChanged(Coef coef)
        {

        }
    }
}
