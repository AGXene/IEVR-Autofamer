using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IEVRAutofamer.View.UserControls
{
    /// <summary>
    /// Interaction logic for ReturnButton.xaml
    /// </summary>
    public partial class ReturnButton : UserControl
    {
        private ImageSource _source;
        public ImageSource Source
        {
            get { return _source; }
            set
            {
                _source = value;
                returnImage.Source = value;
            }
        }

        public static readonly DependencyProperty OnClickedProperty = DependencyProperty.Register(
            "OnClicked", typeof(ICommand), typeof(ReturnButton), new UIPropertyMetadata(null));

        public ICommand OnClicked
        {
            get { return (ICommand)GetValue(OnClickedProperty); }
            set { SetValue(OnClickedProperty, value); }
        }

        public ReturnButton()
        {
            InitializeComponent();
        }
    }
}
