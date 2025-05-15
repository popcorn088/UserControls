using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControls.CoefsTableControl
{
    public sealed partial class CoefsTable : UserControl
    {
        public static readonly DependencyProperty CoefsProperty
            = DependencyProperty.Register(
                nameof(Coefs),
                typeof(ObservableCollection<Coef>),
                typeof(CoefsTable),
                new PropertyMetadata(new ObservableCollection<Coef>())); // èâä˙ílÇê›íË

        public ObservableCollection<Coef> Coefs
        {
            get => (ObservableCollection<Coef>)this.GetValue(CoefsProperty);
            set => this.SetValue(CoefsProperty, value);
        }
        public static readonly DependencyProperty IndexHeaderProperty
            = DependencyProperty.Register(
                "IndexHeader",
                typeof(string),
                typeof(CoefsTable),
                new PropertyMetadata("Index"));
        public string IndexHeader
        {
            get => (string)this.GetValue(IndexHeaderProperty);
            set => this.SetValue(IndexHeaderProperty, value);
        }
        public static readonly DependencyProperty ValueHeaderProperty
            = DependencyProperty.Register(
                "ValueHeader",
                typeof(string),
                typeof(CoefsTable),
                new PropertyMetadata("Value"));
        public string ValueHeader
        {
            get => (string)this.GetValue(ValueHeaderProperty);
            set => this.SetValue(ValueHeaderProperty, value);
        }
        public static readonly DependencyProperty IndexVisibilityProperty
            = DependencyProperty.Register(
                "IndexVisibility",
                typeof(Visibility),
                typeof(CoefsTable),
                new PropertyMetadata(Visibility.Visible));
        public Visibility IndexVisibility
        {
            get => (Visibility)this.GetValue(IndexVisibilityProperty);
            set => this.SetValue(IndexVisibilityProperty, value);
        }
        public static readonly DependencyProperty StringFormatProperty
            = DependencyProperty.Register(
                "StringFormat",
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

            var obj = this.FindName("dataGrid");

            /*
            Binding bind = new Binding()
            {
                Path = new PropertyPath(nameof(this.Coefs)),
                Source = this,
                Mode = BindingMode.OneWay,
            };
            this.dataGrid.SetBinding(DataGrid.ItemsSourceProperty, bind);
            */
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            var coef = new Coef
            {
                Index = Coefs.Count,
                Value = 0,
                StringFormat = this.StringFormat,
            };
            Coefs.Add(coef);
        }

        private void RemoveClicked(object sender, RoutedEventArgs e)
        {
            List<Coef> coefList = [];
            foreach (Coef coef in Coefs)
            {
                if (coef.IsSelected == true)
                {
                    coefList.Add(coef);
                }
            }

            foreach (Coef coef in coefList)
            {
                Coefs.Remove(coef);
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
