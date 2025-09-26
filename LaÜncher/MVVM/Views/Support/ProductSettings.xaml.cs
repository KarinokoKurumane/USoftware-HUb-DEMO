using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using USoftware_HUb.MVVM.ViewModel.Pages;

namespace USoftware_HUb.MVVM.Views.Support
{
    /// <summary>
    /// Logika interakcji dla klasy ProductSettings.xaml
    /// </summary>
    public partial class ProductSettings : UserControl
    {
        // Ragowanie na "Uruchom jako grupę"
        public static readonly DependencyProperty RunAsGroupProperty =
            DependencyProperty.Register(nameof(RunAsGroupCommand), typeof(ICommand), typeof(ProductSheet));

        // Reagowanie na "Dodaj do grupy"
        public static readonly DependencyProperty AddToGroupProperty =
            DependencyProperty.Register(nameof(AddToGroupCommand), typeof(ICommand), typeof(ProductSheet));

        // Reagowanie na "Usuń z grupy"
        public static readonly DependencyProperty RemoveFromGroupProperty =
            DependencyProperty.Register(nameof(RemoveFromGroupCommand), typeof(ICommand), typeof(ProductSheet));

        public ICommand RunAsGroupCommand
        {
            get => (ICommand)GetValue(RunAsGroupProperty);
            set => SetValue(RunAsGroupProperty, value);
        }

        public ICommand AddToGroupCommand
        {
            get => (ICommand)GetValue(AddToGroupProperty);
            set => SetValue(AddToGroupProperty, value);
        }

        public ICommand RemoveFromGroupCommand
        {
            get => (ICommand)GetValue(RemoveFromGroupProperty);
            set => SetValue(RemoveFromGroupProperty, value);
        }

        public ProductSettings()
        {
            InitializeComponent();
        }


    }
}
