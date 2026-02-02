using System.Windows.Controls;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for MenuTitleContainer.xaml
    /// </summary>
    public partial class MenuTitleContainer : UserControl
    {
        private string _titleText;
        public string TitleText
        {
            get { return _titleText; }
            set
            {
                _titleText = value;
                textBlock.Text = value;
            }
        }

        private ImageSource _titleImage;
        public ImageSource TitleImage
        {
            get { return _titleImage; }
            set
            {
                _titleImage = value;
                image.Source = value;
            }
        }
        private ImageSource _iconImage;
        public ImageSource IconImage
        {
            get { return _iconImage; }
            set
            {
                _iconImage = value;
                iconSource.Source= value;
            }
        }

        public MenuTitleContainer()
        {
            InitializeComponent();
        }
    }
}
