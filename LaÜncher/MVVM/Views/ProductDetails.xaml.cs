using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace USoftware_HUb.MVVM.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : UserControl
    {
        // Reagowanie na "Uruchom"
        public static readonly DependencyProperty RunAppProperty =
            DependencyProperty.Register(nameof(RunAppCommand), typeof(ICommand), typeof(ProductDetails));

        // Ragowanie na "Uruchom jako grupę"
        public static readonly DependencyProperty RunAsGroupProperty =
            DependencyProperty.Register(nameof(RunAsGroupCommand), typeof(ICommand), typeof(ProductDetails));

        // Reagowanie na "Dodaj do grupy"
        public static readonly DependencyProperty AddToGroupProperty =
            DependencyProperty.Register(nameof(AddToGroupCommand), typeof(ICommand), typeof(ProductDetails));

        // Reagowanie na "Usuń z grupy"
        public static readonly DependencyProperty RemoveFromGroupProperty =
            DependencyProperty.Register(nameof(RemoveFromGroupCommand), typeof(ICommand), typeof(ProductDetails));

        // Obrazek bannera
        public static readonly DependencyProperty BannerImageSourceProperty = 
            DependencyProperty.Register(nameof(BannerImageSource), typeof (ImageSource), typeof(ProductDetails));

        // Ikona produktu
        public static readonly DependencyProperty IconImageSourceProperty =
            DependencyProperty.Register(nameof(IconImageSource), typeof(ImageSource), typeof(ProductDetails));

        public static readonly DependencyProperty ProductNameTextProperty =
            DependencyProperty.Register(nameof(ProductName), typeof(string), typeof(ProductDetails));

        public static readonly DependencyProperty ProductDescriptionProperty =
            DependencyProperty.Register(nameof(ProductDescription), typeof(string), typeof(ProductDetails));


        public ICommand RunAppCommand
        {
            get => (ICommand)GetValue(RunAppProperty);
            set => SetValue(RunAppProperty, value);
        }

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

        public ImageSource BannerImageSource
        {
            get => (ImageSource)GetValue(BannerImageSourceProperty);
            set => SetValue(BannerImageSourceProperty, value);
        }

        public ImageSource IconImageSource
        {
            get => (ImageSource)GetValue(IconImageSourceProperty);
            set => SetValue(IconImageSourceProperty, value);
        }

        public string ProductName
        {
            get => (string)GetValue(ProductNameTextProperty);
            set => SetValue(ProductNameTextProperty, value);
        }

        public string ProductDescription
        {
            get => (string)GetValue(ProductDescriptionProperty);
            set => SetValue(ProductDescriptionProperty, value);
        }


        public ProductDetails()
        {
            InitializeComponent();
        }
    }
}
