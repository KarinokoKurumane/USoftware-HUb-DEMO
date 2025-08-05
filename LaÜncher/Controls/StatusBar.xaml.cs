using System.Windows.Controls;
using USoftware_HUb.MVVM.ViewModel;

namespace USoftware_HUb.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }
    }
}
