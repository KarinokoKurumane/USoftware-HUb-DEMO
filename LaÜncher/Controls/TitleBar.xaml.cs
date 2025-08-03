using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using USofware_HUb.MVVM.Utility;
using USofware_HUb.MVVM.ViewModel;

namespace USofware_HUb.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy TitleBar.xaml
    /// Co w kontrolce pozostaje w kontrolce.
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public TitleBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pozwala przeciągać okno, gdy kliknięto na pasek tytułowy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                WindowBehaviour.GetParentWindow()?.DragMove();
        }

    }
}
