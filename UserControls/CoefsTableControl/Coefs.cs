using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.Foundation.Collections;

namespace UserControls.CoefsTableControl
{
    public class Coefs
    {
        private readonly ObservableCollection<Coef> _items = new ObservableCollection<Coef>();
        public ObservableCollection<Coef> Items => _items;
        public delegate void CoefValueChangedDelegate(Coef coef);
        public CoefValueChangedDelegate CoefValueChanged;
        public delegate void NumOfCoefsChangedDelegate();
        public NumOfCoefsChangedDelegate NumOfCoefsChanged;
        public Coefs()
        {
            Items.CollectionChanged += ValueCollectionChanged;
        }

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
