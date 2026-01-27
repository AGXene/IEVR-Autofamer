using System.Windows;
using System.Windows.Controls;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public TitleBar()
        {
            InitializeComponent();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            AppConfig.Minimize();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            ApplicationUtilities.OpenWebsite("https://github.com/AGXene/IEVR-Autofamer/tree/master?tab=readme-ov-file");
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (AppConfig.windowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.DragMove();
            }
        }
    }
}
