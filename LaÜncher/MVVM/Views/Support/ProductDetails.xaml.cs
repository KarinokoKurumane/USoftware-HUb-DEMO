using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using USoftware_HUb.MVVM.ViewModel.Pages;
using USoftware_HUb.MVVM.Views.Pages;

namespace USoftware_HUb.MVVM.Views.Support
{
    /// <summary>
    /// Logika interakcji dla klasy ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : UserControl
    {
        // Ikona produktu
        public static readonly DependencyProperty IconImageSourceProperty =
            DependencyProperty.Register(nameof(IconImageSource), typeof(ImageSource), typeof(ProductSheet));

        public static readonly DependencyProperty ProductNameTextProperty =
            DependencyProperty.Register(nameof(ProductName), typeof(string), typeof(ProductSheet));

        public static readonly DependencyProperty ProductDescriptionProperty =
            DependencyProperty.Register(nameof(ProductDescription), typeof(string), typeof(ProductSheet));

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
