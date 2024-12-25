using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.CoefsTable
{
    public class CoefsTableViewModel : ObservableObject
    {
        private Coefs _coefs = new();
        public Coefs Coefs
        {
            get => _coefs;
            set => SetProperty(ref _coefs, value);
        }
    }
}
