using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for ToggleOption.xaml
    /// </summary>
    public partial class ToggleOption : UserControl
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                toggleText.Text = _text;
            }
        }

        private Brush _color;
        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                toggleText.Foreground = _color;
            }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
            "IsChecked", typeof(bool), typeof(ToggleOption), new UIPropertyMetadata(null));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty OnCommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(ToggleOption), new UIPropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(OnCommandProperty); }
            set { SetValue(OnCommandProperty, value); }
        }

        public ToggleOption()
        {
            InitializeComponent();
        }
    }
}
