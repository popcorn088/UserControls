using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControls.CoefsTable
{
    public sealed partial class CoefsTable : UserControl
    {
        public static readonly DependencyProperty CoefsProperty
            = DependencyProperty.Register(
                nameof(Coefs),
                typeof(Coefs),
                typeof(CoefsTable),
                new PropertyMetadata(null));
        public Coefs Coefs
        {
            get => (Coefs)this.GetValue(CoefsProperty);
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
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            var coef = new Coef
            {
                Index = Coefs.Items.Count,
                Value = 0,
                StringFormat = this.StringFormat,
            };
            Coefs.Items.Add(coef);
        }

        private void RemoveClicked(object sender, RoutedEventArgs e)
        {
            List<Coef> coefList = [];
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
