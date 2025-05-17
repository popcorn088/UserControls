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
using UserControls.CoefsTableControl;
using UserControls.Enums;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UserControlsSample.CoefsTableSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CoefsTablePage : Page
    {
        private readonly CoefsTablePageViewModel viewModel;
        public IEnumerable<ColumnVisibility> columnVisibilities { get; private set; } = Enum.GetValues<ColumnVisibility>().Cast<ColumnVisibility>();
        public CoefsTablePage()
        {
            this.InitializeComponent();
            viewModel = new CoefsTablePageViewModel();
            DataContext = viewModel;
        }
    }
}
