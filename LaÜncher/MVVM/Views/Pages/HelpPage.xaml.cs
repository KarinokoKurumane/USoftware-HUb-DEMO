using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using USoftware_HUb.MVVM.ViewModel.Pages;

namespace USoftware_HUb.MVVM.Views.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy HelpPage.xaml
    /// </summary>
    public partial class HelpPage : UserControl
    {
        public HelpPage()
        {
            InitializeComponent();
            DataContext = HelpPageViewModel.Instance;
        }
    }
}
