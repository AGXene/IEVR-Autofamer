using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for RunAutofarmButton.xaml
    /// </summary>
    public partial class RunAutofarmButton : UserControl
    {
        private ImageSource _onDeactivated;
        public ImageSource OnDeactivated
        {
            get { return _onDeactivated; }
            set
            {
                _onDeactivated = value; 
            }
        }

        private ImageSource _onActivated;
        public ImageSource OnActivated
        {
            get { return _onActivated; }
            set
            {
                _onActivated = value;
            }
        }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                runImage.Source = value;
            }
        }

        private ImageSource _onCanceled;
        public ImageSource OnCanceled
        {
            get { return _onCanceled; }
            set
            {
                _onCanceled = value;
            }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(RunAutofarmButton), new UIPropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public RunAutofarmButton()
        {
            InitializeComponent();
            Unloaded += (s, e) =>
            {
                AppConfig.OnAutofarmStateChangedEvent -= ChangeButtonVisuals;
                AppConfig.OnReactivateAutofarmEvent -= ChangeButtonVisualsOnActivated;
            };
            AppConfig.OnAutofarmStateChangedEvent += ChangeButtonVisuals;
            AppConfig.OnReactivateAutofarmEvent += ChangeButtonVisualsOnActivated;
   
        }

        private void ChangeButtonVisuals(bool state)
        {
            if (AppConfig.IsAutofarmAllowed)
            {
                ImageSource = state ? OnActivated : OnDeactivated;
            }
        }

        private void ChangeButtonVisualsOnActivated(bool state)
        {
            ImageSource = state ? OnDeactivated : OnCanceled;
        }
    }
}
