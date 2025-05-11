using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.ComplexCoefsTable
{
    public class ComplexCoefs : ObservableObject
    {
        private ObservableCollection<ComplexCoef> _items = [];
        public ObservableCollection<ComplexCoef> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        public delegate void ComplexCoefValueChangedDelegate(ComplexCoef coef);
        public ComplexCoefValueChangedDelegate ComplexCoefValueChanged;
        public delegate void NumOfComplexCoefsChangedDelegate();
        public NumOfComplexCoefsChangedDelegate NumOfComplexCoefsChanged;
        public ComplexCoefs() => _items.CollectionChanged += ValueCollectioinChanged;

        private void ValueCollectioinChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].PropertyChanged -= ItemPropertyChanged;
                Items[i].Index = i;
                Items[i].PropertyChanged += ItemPropertyChanged;
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (ComplexCoef item in e.OldItems)
                {
                    item.PropertyChanged -= ItemPropertyChanged;
                }
            }

            NumOfComplexCoefsChanged?.Invoke();
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
            => ComplexCoefValueChanged?.Invoke((ComplexCoef)sender);
    }
}
