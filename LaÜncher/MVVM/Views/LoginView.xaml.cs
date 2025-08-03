using USofware_HUb.MVVM.ViewModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace USofware_HUb.MVVM.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Animacja skalowania i wygaszenia okna po jego załadowaniu.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            var scaleAnim = new DoubleAnimation(0.8, 1.0, TimeSpan.FromMilliseconds(300)) { EasingFunction = new QuadraticEase() };
            fadeScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            fadeScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }
    }
}
