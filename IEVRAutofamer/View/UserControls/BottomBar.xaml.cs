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
            ApplicationUtilities.OpenWebsite("https://www.youtube.com/watch?v=wpV-gGA4PSk&list=RDwpV-gGA4PSk&start_radio=1");
        }

        private void OnX_Click(object sender, RoutedEventArgs e)
        {
            ApplicationUtilities.OpenWebsite("https://www.youtube.com/watch?v=wpV-gGA4PSk&list=RDwpV-gGA4PSk&start_radio=1");
        }

        private void OnPatreon_Click(object sender, RoutedEventArgs e)
        {
            ApplicationUtilities.OpenWebsite("https://www.youtube.com/watch?v=wpV-gGA4PSk&list=RDwpV-gGA4PSk&start_radio=1");
        }
    }
}
