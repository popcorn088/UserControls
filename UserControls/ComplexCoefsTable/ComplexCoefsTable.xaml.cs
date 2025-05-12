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
                new PropertyMetadata(null));
        public ComplexCoefs ComplexCoefs
        {
            get => (ComplexCoefs)this.GetValue(ComplexCoefsProperty);
            set => this.SetValue(ComplexCoefsProperty, value);
        }
        public static readonly DependencyProperty IndexHeaderProperty
            = DependencyProperty.Register(
                "IndexHeader",
                typeof(string),
                typeof(ComplexCoefsTable),
                new PropertyMetadata("Index", IndexHeaderPropertyChangedCallback));

        private static void IndexHeaderPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.indexColumn.Header = e.NewValue;
            }
        }

        public string IndexHeader
        {
            get => (string)this.GetValue(IndexHeaderProperty);
            set => this.SetValue(IndexHeaderProperty, value);
        }
        public static readonly DependencyProperty RealColumnHeaderProperty
            = DependencyProperty.Register(
                "RealColumnHeader",
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
                "ImaginaryColumnHeader",
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
        public static readonly DependencyProperty IndexVisibilityProperty
            = DependencyProperty.Register(
                "IndexVisibility",
                typeof(Visibility),
                typeof(ComplexCoefsTable),
                new PropertyMetadata(Visibility.Visible, IndexVisibilityPropertyChangedCallback));

        private static void IndexVisibilityPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.indexColumn.Visibility = (Visibility)e.NewValue;
            }
        }

        public Visibility IndexVisibility
        {
            get => (Visibility)this.GetValue(IndexVisibilityProperty);
            set => this.SetValue(IndexVisibilityProperty, value);
        }
        public static readonly DependencyProperty IsReadOnlyComplexColumnsProperty
            = DependencyProperty.Register(
                "IsReadOnlyComplexColumns",
                typeof(bool),
                typeof(ComplexCoefsTable),
                new PropertyMetadata(false));
        public bool IsReadOnlyComplexColumns
        {
            get => (bool)this.GetValue(IsReadOnlyComplexColumnsProperty);
            set => this.SetValue(IsReadOnlyComplexColumnsProperty, value);
        }

        public static readonly DependencyProperty CheckBoxVisibilityProperty
            = DependencyProperty.Register(
                "CheckBoxVisibility",
                typeof(Visibility),
                typeof(ComplexCoefsTable),
                new PropertyMetadata(Visibility.Visible, CheckBoxVisibilityPropertyChangedCallback));

        private static void CheckBoxVisibilityPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComplexCoefsTable complexCoefsTable)
            {
                complexCoefsTable.checkBoxColumn.Visibility = (Visibility)e.NewValue;
            }
        }

        public Visibility CheckBoxVisibility
        {
            get => (Visibility)this.GetValue(CheckBoxVisibilityProperty);
            set => this.SetValue(CheckBoxVisibilityProperty, value);
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
            List<ComplexCoef> complexCoefList = [];
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
