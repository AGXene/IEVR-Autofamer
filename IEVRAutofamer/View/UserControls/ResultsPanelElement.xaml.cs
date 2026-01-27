using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for ResultsPanelElement.xaml
    /// </summary>
    public partial class ResultsPanelElement : UserControl
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(ImageSource), typeof(ResultsPanelElement), new UIPropertyMetadata(null));

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(ResultsPanelElement), new UIPropertyMetadata(null));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register(
            "Result", typeof(string), typeof(ResultsPanelElement), new UIPropertyMetadata(null));

        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public ResultsPanelElement()
        {
            InitializeComponent();
            //textBox.Loaded += (s, e) =>
            //{
            //    _titleLabel = (Label)textBox.Template.FindName("TitleLabel", textBox);
            //    _resultLabel = (Label)textBox.Template.FindName("ResultsLabel", textBox);
            //    _iconImage = (Image)textBox.Template.FindName("ImageIcon", textBox);
            //};
        }
    }
}
