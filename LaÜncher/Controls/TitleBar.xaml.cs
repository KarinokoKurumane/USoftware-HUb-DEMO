using System.Windows.Controls;
using System.Windows.Input;
using USoftware_HUb.MVVM.ViewModel;
using USoftwareHUB.Utility;

namespace USoftware_HUb.Controls
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
            DataContext = MainViewModel.Instance;
        }

        /// <summary>
        /// Pozwala przeciągać okno, gdy kliknięto na pasek tytułowy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                WindowBehaviour.GetCurrentWindow()?.DragMove();
        }

    }
}
