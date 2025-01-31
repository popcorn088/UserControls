using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace UserControls.CoefsTable
{
    public class Coefs : ObservableObject
    {
        private ObservableCollection<Coef> _items = [];
        public ObservableCollection<Coef> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        public delegate void CoefValueChangedDelegate(Coef coef);
        public CoefValueChangedDelegate CoefValueChanged;
        public delegate void NumOfCoefsChangedDelegate();
        public NumOfCoefsChangedDelegate NumOfCoefsChanged;
        public Coefs() => _items.CollectionChanged += ValueCollectionChanged;

        private void ValueCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Coef item in e.NewItems)
                {
                    item.PropertyChanged += ItemPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Coef item in e.OldItems)
                {
                    item.PropertyChanged -= ItemPropertyChanged;
                }
            }

            NumOfCoefsChanged?.Invoke();
        }

        private void ItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            => CoefValueChanged?.Invoke((Coef)sender);
    }
}
