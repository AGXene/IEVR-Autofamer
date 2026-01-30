using IEVRAutofamer.Model;
using IEVRAutofamer.MVVM;
using IEVRAutofamer.Systems;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfScreenHelper;

namespace IEVRAutofamer.ViewModel
{
    internal class CompetitionModeViewModel : ViewModelBase
    {
        public readonly RelayCommand NavigateChronicleModeCommand;

        public ICommand OnReturnClicked => new RelayCommand((o) => ReturnToHomeView_Clicked());
        public ICommand OnAutofarmCommand => new RelayCommand((o) => OnAutofarmCommand_Executed());
        public ICommand OnAudioExecutionType => new RelayCommand(OnAudioExecutionType_Executed);
        public ICommand OnMonitorTargetSelected => new RelayCommand(OnMonitorTargetSelected_Executed);
        public ICommand OnLearnMoreAboutTool => new RelayCommand((o) => OnLearnMoreAboutTool_Executed());
        public ICommand OnAudioActivated => new RelayCommand((o) => OnAudioActivated_Executed());

        public bool AudioActivation { get; set; }
        public string TotalMatches { get; set; }
        public AudioExecutionType AudioExecutionType { get; set; }

        public string AudioExecutionTypeDropdownText { get; set; }
        public bool AudioExecutionTypeDropdownOpen { get; set; }
        public string MonitorTargetDropdownText { get; set; }
        public bool MonitorTargetDropdownOpen { get; set; }
        public bool AutofarmButtonIsEnabled { get; set; }

        public string TotalMatchesResults { get; set; }
        public string TotalDurationResults { get; set; }
        public string TotalAverageResults { get; set; }

        private Screen _currentScreen;


        private CompetitionModeProcessor _processor;

        public object MonitorTargetDropdownContent
        {
            set;
            get { return CreateMonitorTargetDropdownButtons(); }
        }

        //========================= INITIALIZATION =========================

        public CompetitionModeViewModel(NavigationStore navigationStore)
        {
            NavigateChronicleModeCommand =
                new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));

            InitValues();
        }

        private void InitValues()
        {
            TotalMatches = "100";
            AudioActivation = true;
            OnAudioExecutionType_Executed("EveryMatch");
            OnMonitorTargetSelected_Executed(Screen.PrimaryScreen);
            TotalAverageResults = "0:0";
            TotalDurationResults = "0:0";
            TotalMatchesResults = "0";
        }

        //========================= COMMANDS =========================

        private void ReturnToHomeView_Clicked()
        {
            if (!AppConfig.IsAutofarmRunning && AppConfig.IsAutofarmAllowed)
            {
                NavigateChronicleModeCommand.Execute(null);
            }
            else
            {
                MessageBox.Show("Competition mode auto-farming is currently running. Close it before going to the home menu.");
            }
        }

        private void OnAutofarmCommand_Executed()
        {
            _processor = _processor ?? new CompetitionModeProcessor();

            _processor.OnStarted -= OnStarted;
            _processor.OnStarted += OnStarted;

            _processor.OnMatchFinished -= UpdateResultsPanel;
            _processor.OnMatchFinished += UpdateResultsPanel;

            if (_processor.OnExecution)
            {
                _processor.EndProcess();
            }
            else
            {
                _processor.StartProcess();
            }

            void OnStarted()
            {
                _processor.ProcessData.IsAudioActivated = AudioActivation;
                _processor.ProcessData.AudioExecutionType = AudioExecutionType;
                _processor.ProcessData.MaximuTotalMatches = int.Parse(TotalMatches);
                _processor.ProcessData.CurrentScreen = _currentScreen;
            }
        }

        private void UpdateResultsPanel()
        {
            TotalAverageResults = _processor.ProcessData.AverageDuration.ToString(@"hh\:mm\:ss");
            TotalDurationResults = _processor.ProcessData.TotalDuration.ToString(@"hh\:mm\:ss");
            TotalMatchesResults = _processor.ProcessData.TotalMatches.ToString();

            OnPropertyChanged("TotalAverageResults");
            OnPropertyChanged("TotalDurationResults");
            OnPropertyChanged("TotalMatchesResults");
        }

        private void OnLearnMoreAboutTool_Executed()
        {
            try
            {

                ApplicationUtilities.OpenWebsite("https://github.com/AGXene/IEVR-Autofamer/blob/master/Docs/CompetitionMode_Help.md");
            }
            catch
            {
                MessageBox.Show("Couldn't find the website.");
            }
        }

        private void OnAudioActivated_Executed()
        {
            if (AudioActivation)
            {
                AudioSystem.PlayFinishedSound();
            }
        }

        //========================= DROPDOWN COMMANDS =========================

        private void OnAudioExecutionType_Executed(object parameter)
        {
            try
            {
                var type = (AudioExecutionType)Enum.Parse(typeof(AudioExecutionType), parameter.ToString(), true);
                AudioExecutionType = type;
                Debug.WriteLine(type);

                if (type == AudioExecutionType.EveryMatch)
                {
                    AudioExecutionTypeDropdownText = "Every Match";
                }
                else
                {
                    AudioExecutionTypeDropdownText = "On Autofarm Finishes";
                }
                AudioExecutionTypeDropdownOpen = false;
                OnPropertyChanged("AudioExecutionTypeDropdownText");
                OnPropertyChanged("AudioExecutionTypeDropdownOpen");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private object CreateMonitorTargetDropdownButtons()
        {
            ResourceDictionary dictionary = (ResourceDictionary)Application.LoadComponent(new Uri(
                "/IEVRAutofamer;component/ResourcesDictonaries/DropdownMenuDictionary.xaml", UriKind.Relative));

            Border border = new Border();
            border.Style = (Style)dictionary["DropdownMenuBorder"];
            StackPanel stackPanel = new StackPanel();
            border.Child = stackPanel;

            var screens = ScreenObserver.GetAllScreens();

            foreach (var item in screens)
            {
                Button button = new Button();

                button.Command = OnMonitorTargetSelected;
                button.Style = (Style)dictionary["DropdownMenuButton"];
                button.CommandParameter = item;
                stackPanel.Children.Add(button);
                button.Content = item.DeviceName.ToString().Substring(4);

                if (Screen.PrimaryScreen.DeviceName == item.DeviceName)
                {
                    button.Content += " (Main)";
                }
            }
            return border;
        }

        private void OnMonitorTargetSelected_Executed(object parameter)
        {
            try
            {
                Screen screen = (Screen)parameter;
                _currentScreen = screen;

                MonitorTargetDropdownText = screen.DeviceName;

                if (MonitorTargetDropdownText == Screen.PrimaryScreen.DeviceName)
                {
                    MonitorTargetDropdownText += " (Main)";
                }

                MonitorTargetDropdownText = MonitorTargetDropdownText.ToString().Substring(4);

                MonitorTargetDropdownOpen = false;
                OnPropertyChanged("MonitorTargetDropdownOpen");
                OnPropertyChanged("MonitorTargetDropdownText");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
