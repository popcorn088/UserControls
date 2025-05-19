using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControls.CoefsTableControl
{
    public sealed partial class CoefsTable : UserControl
    {
        public static readonly DependencyProperty CoefsProperty
            = DependencyProperty.Register(
                nameof(Coefs),
                typeof(Coefs),
                typeof(CoefsTable),
                new PropertyMetadata(new Coefs()));
        public Coefs Coefs
        {
            get => (Coefs)this.GetValue(CoefsProperty);
            set => this.SetValue(CoefsProperty, value);
        }
        public static readonly DependencyProperty IndexColumnHeaderProperty
            = DependencyProperty.Register(
                nameof(IndexColumnHeader),
                typeof(string),
                typeof(CoefsTable),
                new PropertyMetadata("Index", new PropertyChangedCallback(OnIndexColumnHeaderPropertyChanged)));

        private static void OnIndexColumnHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CoefsTable coefsTable)
            {
                coefsTable.indexColumn.Header = e.NewValue;
            }
        }

        public string IndexColumnHeader
        {
            get => (string)this.GetValue(IndexColumnHeaderProperty);
            set => this.SetValue(IndexColumnHeaderProperty, value);
        }
        public static readonly DependencyProperty ValueColumnHeaderProperty
            = DependencyProperty.Register(
                nameof(ValueColumnHeader),
                typeof(string),
                typeof(CoefsTable),
                new PropertyMetadata("Value", new PropertyChangedCallback(OnValueColumnHeaderPropertyChanged)));
        private static void OnValueColumnHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CoefsTable coefsTable)
            {
                coefsTable.valueColumn.Header = e.NewValue;
            }
        }
        public string ValueColumnHeader
        {
            get => (string)this.GetValue(ValueColumnHeaderProperty);
            set => this.SetValue(ValueColumnHeaderProperty, value);
        }
        public static readonly DependencyProperty IndexColumnVisibilityProperty
            = DependencyProperty.Register(
                nameof(IndexColumnVisibility),
                typeof(Visibility),
                typeof(CoefsTable),
                new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(IndexColumnVisibilityPropertyChanged)));

        private static void IndexColumnVisibilityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CoefsTable coefsTable)
            {
                coefsTable.indexColumn.Visibility = (Visibility)e.NewValue;
            }
        }

        public Visibility IndexColumnVisibility
        {
            get => (Visibility)this.GetValue(IndexColumnVisibilityProperty);
            set => this.SetValue(IndexColumnVisibilityProperty, value);
        }
        public static readonly DependencyProperty StringFormatProperty
            = DependencyProperty.Register(
                nameof(StringFormat),
                typeof(string),
                typeof(CoefsTable),
                new PropertyMetadata(string.Empty));
        public string StringFormat
        {
            get => (string)this.GetValue(StringFormatProperty);
            set => this.SetValue(StringFormatProperty, value);
        }
        public static readonly DependencyProperty ValueAlignmentProperty
            = DependencyProperty.Register(
                nameof(ValueAlignment),
                typeof(TextAlignment),
                typeof(CoefsTable),
                new PropertyMetadata(TextAlignment.Left));
        public TextAlignment ValueAlignment
        {
            get => (TextAlignment)GetValue(ValueAlignmentProperty);
            set => SetValue(ValueAlignmentProperty, value);
        }

        public CoefsTable()
        {
            this.InitializeComponent();
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            var coef = new Coef
            {
                Index = Coefs.Items.Count,
                Value = 0,
            };
            Coefs.Items.Add(coef);
        }

        private void RemoveClicked(object sender, RoutedEventArgs e)
        {
            List<Coef> coefList = new();
            foreach (Coef coef in Coefs.Items)
            {
                if (coef.IsSelected == true)
                {
                    coefList.Add(coef);
                }
            }

            foreach (Coef coef in coefList)
            {
                Coefs.Items.Remove(coef);
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Coef item in e.AddedItems.Cast<Coef>())
            {
                item.IsSelected = true;
            }
            foreach (Coef item in e.RemovedItems.Cast<Coef>())
            {
                item.IsSelected = false;
            }
        }
    }
}
