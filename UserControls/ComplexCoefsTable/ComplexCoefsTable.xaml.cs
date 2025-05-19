using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using CommunityToolkit.WinUI.UI.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControls.ComplexCoefsTable
{
    public sealed partial class ComplexCoefsTable : UserControl
    {
        public static readonly DependencyProperty ComplexCoefsProperty
            = DependencyProperty.Register(
                nameof(ComplexCoefs),
                typeof(ComplexCoefs),
                typeof(ComplexCoefsTable),
                new PropertyMetadata(new ComplexCoefs()));
        public ComplexCoefs ComplexCoefs
        {
            get => (ComplexCoefs)this.GetValue(ComplexCoefsProperty);
            set => this.SetValue(ComplexCoefsProperty, value);
        }
        public static readonly DependencyProperty IndexColumnHeaderProperty
            = DependencyProperty.Register(
                nameof(IndexColumnHeader),
                typeof(string),
                typeof(ComplexCoefsTable),
                new PropertyMetadata("Index", IndexColumnHeaderPropertyChangedCallback));

        private static void IndexColumnHeaderPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.indexColumn.Header = e.NewValue;
            }
        }

        public string IndexColumnHeader
        {
            get => (string)this.GetValue(IndexColumnHeaderProperty);
            set => this.SetValue(IndexColumnHeaderProperty, value);
        }
        public static readonly DependencyProperty RealColumnHeaderProperty
            = DependencyProperty.Register(
                nameof(RealColumnHeader),
                typeof(string),
                typeof(ComplexCoefsTable),
                new PropertyMetadata("Real", RealColumnHeaderPropertyChangedCallback));

        private static void RealColumnHeaderPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.realColumn.Header = e.NewValue;
            }
        }
        public string RealColumnHeader
        {
            get => (string)this.GetValue(RealColumnHeaderProperty);
            set => this.SetValue(RealColumnHeaderProperty, value);
        }
        public static readonly DependencyProperty ImaginaryColumnHeaderProperty
            = DependencyProperty.Register(
                nameof(ImaginaryColumnHeader),
                typeof(string),
                typeof(ComplexCoefsTable),
                new PropertyMetadata("Imaginary", ImaginaryColumnHeaderProrpertyChangedCallback));

        private static void ImaginaryColumnHeaderProrpertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.imaginaryColumn.Header = e.NewValue;
            }
        }
        public string ImaginaryColumnHeader
        {
            get => (string)this.GetValue(ImaginaryColumnHeaderProperty);
            set => this.SetValue(ImaginaryColumnHeaderProperty, value);
        }
        public static readonly DependencyProperty IndexColumnVisibilityProperty
            = DependencyProperty.Register(
                nameof(IndexColumnVisibility),
                typeof(Visibility),
                typeof(ComplexCoefsTable),
                new PropertyMetadata(Visibility.Visible, IndexColumnVisibilityPropertyChangedCallback));

        private static void IndexColumnVisibilityPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.indexColumn.Visibility = (Visibility)e.NewValue;
            }
        }

        public Visibility IndexColumnVisibility
        {
            get => (Visibility)this.GetValue(IndexColumnVisibilityProperty);
            set => this.SetValue(IndexColumnVisibilityProperty, value);
        }
        public static readonly DependencyProperty IsReadOnlyComplexColumnsProperty
            = DependencyProperty.Register(
                nameof(IsReadOnlyComplexColumns),
                typeof(bool),
                typeof(ComplexCoefsTable),
                new PropertyMetadata(false));
        public bool IsReadOnlyComplexColumns
        {
            get => (bool)this.GetValue(IsReadOnlyComplexColumnsProperty);
            set => this.SetValue(IsReadOnlyComplexColumnsProperty, value);
        }

        public static readonly DependencyProperty CheckBoxColumnVisibilityProperty
            = DependencyProperty.Register(
                nameof(CheckBoxColumnVisibility),
                typeof(Visibility),
                typeof(ComplexCoefsTable),
                new PropertyMetadata(Visibility.Visible, CheckBoxColumnVisibilityPropertyChangedCallback));

        private static void CheckBoxColumnVisibilityPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.checkBoxColumn.Visibility = (Visibility)e.NewValue;
            }
        }

        public Visibility CheckBoxColumnVisibility
        {
            get => (Visibility)this.GetValue(CheckBoxColumnVisibilityProperty);
            set => this.SetValue(CheckBoxColumnVisibilityProperty, value);
        }
        public ComplexCoefsTable()
        {
            this.InitializeComponent();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ComplexCoef item in e.AddedItems.Cast<ComplexCoef>())
            {
                item.IsSelected = true;
            }
            foreach (ComplexCoef item in e.RemovedItems.Cast<ComplexCoef>())
            {
                item.IsSelected = false;
            }
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            var complexCoef = new ComplexCoef
            {
                Index = ComplexCoefs.Items.Count,
                Real = 0,
                Imaginary = 0,
            };
            ComplexCoefs.Items.Add(complexCoef);
        }

        private void RemoveClicked(object sender, RoutedEventArgs e)
        {
            List<ComplexCoef> complexCoefList = new();
            foreach (ComplexCoef complexCoef in ComplexCoefs.Items)
            {
                if (complexCoef.IsSelected == true)
                {
                    complexCoefList.Add(complexCoef);
                }
            }

            foreach (ComplexCoef complexCoef in complexCoefList)
            {
                ComplexCoefs.Items.Remove(complexCoef);
            }
        }
    }
}
