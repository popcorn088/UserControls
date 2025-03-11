using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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
            // Auto Index Numbering
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].PropertyChanged -= ItemPropertyChanged;
                Items[i].Index = i;
                Items[i].PropertyChanged += ItemPropertyChanged;
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
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
