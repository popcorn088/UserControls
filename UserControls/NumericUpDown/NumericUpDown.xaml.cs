using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CommunityToolkit.Mvvm.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControls.NumericUpDown
{
    public sealed partial class NumericUpDown : UserControl
    {
        public static readonly DependencyProperty ValueProperty
            = DependencyProperty.Register(
                "Value",
                typeof(decimal),
                typeof(NumericUpDown),
                new PropertyMetadata(0.0m, new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var nud = d as NumericUpDown;
            if (nud != null)
            {
                if (nud.Minimum > (decimal)e.NewValue)
                {
                    nud.Value = nud.Minimum;
                    return;
                }
                if (nud.Maximum < (decimal)e.NewValue)
                {
                    nud.Value = nud.Maximum;
                    return;
                }
            }
        }
        public decimal Value
        {
            get => (decimal)GetValue(ValueProperty);
            set
            {
                SetValue(ValueProperty, value);
            }
        }
        public static readonly DependencyProperty NickProperty
            = DependencyProperty.Register(
                "Nick",
                typeof(decimal),
                typeof(NumericUpDown),
                new PropertyMetadata(1.0m));
        public decimal Nick
        {
            get => (decimal)GetValue(NickProperty);
            set => SetValue(NickProperty, value);
        }
        public static readonly DependencyProperty MinimumProperty
            = DependencyProperty.Register(
                "Minimum",
                typeof(decimal),
                typeof(NumericUpDown),
                new PropertyMetadata(decimal.MinValue));
        public decimal Minimum
        {
            get => (decimal)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }
        public static readonly DependencyProperty MaximumProperty
            = DependencyProperty.Register(
                "Maximum",
                typeof(decimal),
                typeof(NumericUpDown),
                new PropertyMetadata(decimal.MaxValue));
        public decimal Maximum
        {
            get => (decimal)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        public static readonly DependencyProperty StringFormatProperty
            = DependencyProperty.Register(
                "StringFormat",
                typeof(string),
                typeof(NumericUpDown),
                new PropertyMetadata(string.Empty));
        public string StringFormat
        {
            get => (string)GetValue(StringFormatProperty);
            set => SetValue(StringFormatProperty, value);
        }
        RelayCommand UpCommand { get; }
        RelayCommand DownCommand { get; }
        public NumericUpDown()
        {
            this.InitializeComponent();
            this.UpCommand = new RelayCommand(UpCommandExecute);
            this.DownCommand = new RelayCommand(DownCommandExecute);
        }
        private void UpCommandExecute()
        {
            decimal tmp = Value + Nick;
            if (Maximum < tmp) return;
            Value += Nick;
        }

        private void DownCommandExecute()
        {
            decimal tmp = Value - Nick;
            if (Minimum > tmp) return;
            Value -= Nick;
        }

        public string Convert(decimal value)
        {
            return value.ToString(StringFormat);
        }
        public void ConvertBack(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                Value = result;
            }
        }
    }
}
