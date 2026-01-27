using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for DropdownMenuOption.xaml
    /// </summary>
    public partial class DropdownMenuOption : UserControl
    {
        private TextBox _templateTextBox;

        //private string _dropdownText;
        //public string DropdownText
        //{
        //    get { return _dropdownText; }
        //    set
        //    {
        //        _dropdownText = value;
        //        dropdown.Loaded += (s, e) => _templateTextBox.Text = value;
        //    }
        //}

        public static readonly DependencyProperty DropdownTextProperty = DependencyProperty.Register(
            "DropdownText", typeof(string), typeof(DropdownMenuOption), new UIPropertyMetadata(null));
        public object DropdownText
        {
            get { return GetValue(DropdownTextProperty); }
            set { SetValue(DropdownTextProperty, value); }
        }


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

        private Brush _textColor;
        public Brush TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                toggleText.Foreground = _textColor;
            }
        }

        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
            "IsOpen", typeof(bool), typeof(DropdownMenuOption), new UIPropertyMetadata(null));

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set 
            { 
                SetValue(IsOpenProperty, value);
            }
        }

        public static readonly DependencyProperty MenuContentProperty = DependencyProperty.Register(
            "MenuContent", typeof(object), typeof(DropdownMenuOption), new UIPropertyMetadata(null));
        public object MenuContent
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public DropdownMenuOption()
        {
            InitializeComponent();
            dropdown.Loaded += (s, e) =>
            {
                _templateTextBox = (TextBox)dropdown.Template.FindName("TextObject", dropdown);
            };
        }
    }
}
