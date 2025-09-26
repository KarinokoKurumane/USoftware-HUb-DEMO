using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using USoftware_HUb.MVVM.ViewModel.Pages;

namespace USoftware_HUb.MVVM.Views.Support
{
    /// <summary>
    /// Logika interakcji dla klasy ProductSheet.xaml
    /// </summary>
    public partial class ProductSheet : UserControl
    {
        // Reagowanie na "Ustawienia aplikacji"
        public static readonly DependencyProperty OpenSettingsCommandProperty =
            DependencyProperty.Register(nameof(OpenSettingsCommand), typeof(ICommand), typeof(ProductSheet));

        // Reagowanie na "Uruchom"
        public static readonly DependencyProperty RunAppProperty =
            DependencyProperty.Register(nameof(RunAppCommand), typeof(ICommand), typeof(ProductSheet));

        // Obrazek bannera
        public static readonly DependencyProperty BannerImageSourceProperty = 
            DependencyProperty.Register(nameof(BannerImageSource), typeof (ImageSource), typeof(ProductSheet));

        public ICommand OpenSettingsCommand
        {
            get => (ICommand)GetValue(OpenSettingsCommandProperty);
            set => SetValue(OpenSettingsCommandProperty, value);
        }

        public ICommand RunAppCommand
        {
            get => (ICommand)GetValue(RunAppProperty);
            set => SetValue(RunAppProperty, value);
        }

        public ImageSource BannerImageSource
        {
            get => (ImageSource)GetValue(BannerImageSourceProperty);
            set => SetValue(BannerImageSourceProperty, value);
        }

        public ProductSheet()
        {
            InitializeComponent();

            DataContext = ProductPageViewModel.Instance;
        }
    }
}
