using IEVRAutofamer.MVVM;
using System.Windows;
using System.Windows.Input;

namespace IEVRAutofamer.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        public readonly RelayCommand NavigateChronicleModeCommand;

        public readonly RelayCommand NavigateCompetitionModeCommand;

        public readonly RelayCommand NavigateOnlineModeCommand;

        public ICommand OnChronicleModeClicked => new RelayCommand((o) => OnChronicleMode_Clicked());
        public ICommand OnCompetitionModeClicked => new RelayCommand((o) => OnCompetitionMode_Clicked());
        public ICommand OnOnlineModeClicked => new RelayCommand((o) => OnOnlineMode_Clicked());
        public ICommand OnInProgressClicked => new RelayCommand((o) => OnInProgress_Clicked());
        public ICommand DevelopedByXeneClicked => new RelayCommand((o) => DevelopedByXene_Clicked());

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateChronicleModeCommand = 
                new NavigateCommand<ChronicleModeViewModel>(navigationStore,() => new ChronicleModeViewModel(navigationStore));
            NavigateCompetitionModeCommand = 
                new NavigateCommand<CompetitionModeViewModel>(navigationStore,() => new CompetitionModeViewModel(navigationStore));
            NavigateOnlineModeCommand = 
                new NavigateCommand<OnlineModeViewModel>(navigationStore,() => new OnlineModeViewModel(navigationStore));
        }

        private void OnChronicleMode_Clicked()
        {
            NavigateChronicleModeCommand.Execute(null);
        }
        private void OnCompetitionMode_Clicked()
        {
            NavigateCompetitionModeCommand.Execute(null);
        }

        private void OnOnlineMode_Clicked()
        {
            NavigateOnlineModeCommand.Execute(null);
        }

        private void OnInProgress_Clicked()
        {
            MessageBoxResult result = new MessageBoxResult();
            MessageBox.Show("This mode is under development. \r\nBeing more complex than the others, I will only develop it if I see interest and support for the project. Remember that you can help me by donating via the following link: https://ko-fi.com/agxene\r\n\r\nGo to the website?",
                "Beans Mode",MessageBoxButton.YesNo, MessageBoxImage.Information, result);
            if (result == MessageBoxResult.Yes)
            {
                ApplicationUtilities.OpenWebsite("https://github.com/AGXene");
            }
        }

        private void DevelopedByXene_Clicked()
        {
            ApplicationUtilities.OpenWebsite("https://ko-fi.com/agxene");
        }
    }
}
