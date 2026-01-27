using IEVRAutofamer.MVVM;
using System.Windows;
using System.Windows.Input;

namespace IEVRAutofamer.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        public readonly RelayCommand NavigateChronicleModeCommand;

        public ICommand OnChronicleModeClicked => new RelayCommand((o) => OnChronicleMode_Clicked());
        public ICommand OnVSModeClicked => new RelayCommand((o) => OnVSMode_Clicked());
        public ICommand OnInProgressClicked => new RelayCommand((o) => OnInProgress_Clicked());
        public ICommand DevelopedByXeneClicked => new RelayCommand((o) => DevelopedByXene_Clicked());

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateChronicleModeCommand = 
                new NavigateCommand<ChronicleModeViewModel>(navigationStore,() => new ChronicleModeViewModel(navigationStore));
        }

        private void OnChronicleMode_Clicked()
        {
            NavigateChronicleModeCommand.Execute(null);
        }
        private void OnVSMode_Clicked()
        {
            MessageBox.Show("This tool is currently under development");
        }

        private void OnInProgress_Clicked()
        {
            MessageBox.Show("This tool is currently under development");
        }

        private void DevelopedByXene_Clicked()
        {
            ApplicationUtilities.OpenWebsite("https://www.youtube.com/watch?v=wpV-gGA4PSk&list=RDwpV-gGA4PSk&start_radio=1");
        }
    }
}
