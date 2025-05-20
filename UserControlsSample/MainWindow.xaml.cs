using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UserControlsSample.CoefsTableSample;
using UserControlsSample.NumericUpDownSample;
using UserControlsSample.ComplexCoefsTableSample;
using Windows.Foundation;
using Windows.Foundation.Collections;
using UserControlsSample.DecimalConverter;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControlsSample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavigationViewSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if ((string)args.SelectedItemContainer.Content == "DecimalConverter")
            {
                ContentFrame.Navigate(typeof(DecimalConverterPage), null, new SlideNavigationTransitionInfo()
                {
                    Effect = SlideNavigationTransitionEffect.FromLeft,
                });
            }
            else if ((string)args.SelectedItemContainer.Content == "NumericUpDown")
            {
                ContentFrame.Navigate(typeof(NumericUpDownPage), null, new SlideNavigationTransitionInfo()
                {
                    Effect = SlideNavigationTransitionEffect.FromLeft,
                });
            }
            else if ((string)args.SelectedItemContainer.Content == "CoefsTable")
            {
                ContentFrame.Navigate(typeof(CoefsTablePage), null, new SlideNavigationTransitionInfo()
                {
                    Effect = SlideNavigationTransitionEffect.FromLeft,
                });
            }
            else if ((string)args.SelectedItemContainer.Content == "ComplexCoefsTable")
            {
                ContentFrame.Navigate(typeof(ComplexCoefsTablePage), null, new SlideNavigationTransitionInfo()
                {
                    Effect = SlideNavigationTransitionEffect.FromLeft,
                });
            }
        }
    }
}
