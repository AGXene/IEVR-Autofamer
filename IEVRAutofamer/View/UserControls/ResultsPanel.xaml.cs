using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for ResultsPanel.xaml
    /// </summary>
    public partial class ResultsPanel : UserControl
    {
        private ImageSource _source;
        public ImageSource Source
        {
            get { return _source; }
            set
            {
                _source = value;
                panelImage.Source = value;
            }
        }

        public static readonly DependencyProperty TotalMatchesProperty = DependencyProperty.Register(
            "TotalMatches", typeof(string), typeof(ResultsPanel), new UIPropertyMetadata(null));

        public string TotalMatches
        {
            get { return (string)GetValue(TotalMatchesProperty); }
            set { SetValue(TotalMatchesProperty, value); }
        }

        public static readonly DependencyProperty TutorialDurationProperty = DependencyProperty.Register(
            "TutorialDuration", typeof(string), typeof(ResultsPanel), new UIPropertyMetadata(null));

        public string TutorialDuration
        {
            get { return (string)GetValue(TutorialDurationProperty); }
            set { SetValue(TutorialDurationProperty, value); }
        }

        public static readonly DependencyProperty AverageDurationProperty = DependencyProperty.Register(
            "AverageDuration", typeof(string), typeof(ResultsPanel), new UIPropertyMetadata(null));

        public string AverageDuration
        {
            get { return (string)GetValue(AverageDurationProperty); }
            set { SetValue(AverageDurationProperty, value); }
        }

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(
            "Date", typeof(string), typeof(ResultsPanel), new UIPropertyMetadata(null));

        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        private ImageSource _durationSource;
        public ImageSource DurationSource
        {
            get { return  _durationSource; }
            set
            {
                _durationSource = value;
                durationElement.Icon = value;
            }
        }

        private ImageSource _matchSource;
        public ImageSource MatchSource
        {
            get { return _matchSource; }
            set
            {
                _matchSource = value;
                matchesElement.Icon = value;
            }
        }

        private ImageSource _averageSource;
        public ImageSource AverageSource
        {
            get { return _averageSource; }
            set
            {
                _averageSource = value;
                averageElement.Icon = value;
            }
        }

        public ResultsPanel()
        {
            InitializeComponent();
        }
    }
}
