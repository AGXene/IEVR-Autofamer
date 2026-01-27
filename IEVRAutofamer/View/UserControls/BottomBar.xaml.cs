using System.Windows;
using System.Windows.Controls;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for BottomBar.xaml
    /// </summary>
    public partial class BottomBar : UserControl
    {
        public BottomBar()
        {
            InitializeComponent();
        }

        private void OnGitHub_Click(object sender, RoutedEventArgs e)
        {
            ApplicationUtilities.OpenWebsite("https://github.com/AGXene");
        }

        private void OnX_Click(object sender, RoutedEventArgs e)
        {
            ApplicationUtilities.OpenWebsite("https://x.com/AG_Xene");
        }

        private void OnPatreon_Click(object sender, RoutedEventArgs e)
        {
            ApplicationUtilities.OpenWebsite("https://ko-fi.com/agxene");
        }
    }
}
