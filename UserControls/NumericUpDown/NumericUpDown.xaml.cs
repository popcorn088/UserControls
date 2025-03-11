using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Globalization;

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
            set => SetValue(ValueProperty, value);
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
        public static readonly DependencyProperty TextAlignmentProperty
            = DependencyProperty.Register(
                "TextAlignment",
                typeof(TextAlignment),
                typeof(NumericUpDown),
                new PropertyMetadata(TextAlignment.Left));
        public TextAlignment TextAlignment
        {
            get => (TextAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }
        RelayCommand<string> UpCommand { get; }
        RelayCommand<string> DownCommand { get; }
        public NumericUpDown()
        {
            this.InitializeComponent();
            this.UpCommand = new RelayCommand<string>(UpCommandExecute);
            this.DownCommand = new RelayCommand<string>(DownCommandExecute);

        }
        private void UpCommandExecute(string parameter)
        {
            ConvertBack(parameter);
            decimal tmp = Value + Nick;
            if (Maximum < tmp) return;
            Value += Nick;
        }

        private void DownCommandExecute(string parameter)
        {
            ConvertBack(parameter);
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
            if (decimal.TryParse(value, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                Value = result;
            }
            else
            {
                Value = Value;
            }
        }

        private void UpButtonLoaded(object sender, RoutedEventArgs e)
        {
            UpButton.Height = NumericUpDownTextBox.ActualSize.Y / 2.0;
        }

        private void DownButtonLoaded(object sender, RoutedEventArgs e)
        {
            DownButton.Height = NumericUpDownTextBox.ActualSize.Y / 2.0;
        }
    }
}
