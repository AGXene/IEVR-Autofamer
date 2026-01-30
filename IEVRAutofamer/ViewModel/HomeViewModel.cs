using IEVRAutofamer.MVVM;
using System.Windows;
using System.Windows.Input;

namespace IEVRAutofamer.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        public readonly RelayCommand NavigateChronicleModeCommand;

        public readonly RelayCommand NavigateCompetitionModeCommand;

        public ICommand OnChronicleModeClicked => new RelayCommand((o) => OnChronicleMode_Clicked());
        public ICommand OnCompetitionModeClicked => new RelayCommand((o) => OnCompetitionMode_Clicked());
        public ICommand OnInProgressClicked => new RelayCommand((o) => OnInProgress_Clicked());
        public ICommand DevelopedByXeneClicked => new RelayCommand((o) => DevelopedByXene_Clicked());

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateChronicleModeCommand = 
                new NavigateCommand<ChronicleModeViewModel>(navigationStore,() => new ChronicleModeViewModel(navigationStore));
            NavigateCompetitionModeCommand = 
                new NavigateCommand<CompetitionModeViewModel>(navigationStore,() => new CompetitionModeViewModel(navigationStore));
        }

        private void OnChronicleMode_Clicked()
        {
            NavigateChronicleModeCommand.Execute(null);
        }
        private void OnCompetitionMode_Clicked()
        {
            NavigateCompetitionModeCommand.Execute(null);
        }

        private void OnInProgress_Clicked()
        {
            MessageBox.Show("This tool is currently under development");
        }

        private void DevelopedByXene_Clicked()
        {
            ApplicationUtilities.OpenWebsite("https://github.com/AGXene");
        }
    }
}
