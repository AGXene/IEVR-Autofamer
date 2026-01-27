using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        private ImageSource _buttonImage;
        public ImageSource ButtonImage
        {
            get { return _buttonImage; }
            set
            {
                _buttonImage = value;
                ImageSource.Source = value;
            }
        }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                TextImage.Text = value;
            }
        }

        public static readonly DependencyProperty OnClickedProperty = DependencyProperty.Register(
            "OnClicked", typeof(ICommand),typeof(MenuButton),new UIPropertyMetadata(null));

        public ICommand OnClicked
        {
            get { return (ICommand)GetValue(OnClickedProperty); }
            set { SetValue(OnClickedProperty, value); }
        }

        public MenuButton()
        {
            InitializeComponent();
        }
    }
}
