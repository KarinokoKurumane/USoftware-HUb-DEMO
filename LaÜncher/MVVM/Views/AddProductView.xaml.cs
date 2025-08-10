using System.Windows;
using USoftware_HUb.MVVM.ViewModel;

namespace USoftware_HUb.MVVM.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddProductView.xaml
    /// </summary>
    public partial class AddProductView : Window
    {
        public AddProductView(string productType)
        {
            InitializeComponent();

            var vm = new AddProductViewModel(productType);
            vm.RequestClose += () => this.Close();
            DataContext = vm;
        }

    }
}
