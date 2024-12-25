﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string _stringFormat = string.Empty;
        public string StringFormat
        {
            get => _stringFormat;
            set => SetProperty(ref _stringFormat, value);
        }
        public delegate void CoefValueChangedDelegate(Coef coef);
        public CoefValueChangedDelegate CoefValueChanged;
        public Coefs()
        {
            _items.CollectionChanged += ValueCollectionChanged;
        }

        private void ValueCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Coef item in e.NewItems)
                {
                    item.PropertyChanged += ItemPropertyChanged;
                }
            }
        }

        private void ItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CoefValueChanged?.Invoke((Coef)sender);
        }
    }
}