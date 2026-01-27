using IEVRAutofamer.ViewModel;
using System.Windows;

namespace IEVRAutofamer.View.Windows
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            DataContext = new LoadingWindowViewModel(this);
        }
    }
}
