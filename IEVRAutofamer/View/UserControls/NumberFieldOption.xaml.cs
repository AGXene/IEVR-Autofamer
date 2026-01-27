using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for NumberFieldOption.xaml
    /// </summary>
    public partial class NumberFieldOption : UserControl
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


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(string), typeof(NumberFieldOption), new UIPropertyMetadata(null));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set 
            {
                SetValue(ValueProperty, value);
            }
        }


        public NumberFieldOption()
        {
            InitializeComponent();
        }
    }
}
