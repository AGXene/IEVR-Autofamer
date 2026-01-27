using IEVRAutofamer.Systems;
using IEVRAutofamer.View.Windows;
using IEVRAutofamer.ViewModel;
using System.Windows;

namespace IEVRAutofamer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public NavigationStore NavigationStore { get; private set; }

        public LoadingWindow LoadingWindow;

        private const int k_msBeforeLoading = 2500;

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore = new NavigationStore();
            NavigationStore.CurrentViewModel = new HomeViewModel(NavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(NavigationStore)
            };
            Current.MainWindow = MainWindow;
            AppConfig.ResolveDependencies(MainWindow);
#if DEBUG
            OpenMainWindowAfterLoading();
#else
            LoadingWindow = new LoadingWindow();
            LoadingWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoadingWindow.Show();
            ApplicationUtilities.WaitBeforeExecute(k_msBeforeLoading, OpenMainWindowAfterLoading);
#endif
            base.OnStartup(e);
        }

        private void OpenMainWindowAfterLoading()
        {
            MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MainWindow.Show();
            LoadingWindow?.Close();
        }
    }

}
