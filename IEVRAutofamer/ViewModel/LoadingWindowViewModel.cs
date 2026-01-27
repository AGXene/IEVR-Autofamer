using IEVRAutofamer.MVVM;
using System.Windows;
using System.Windows.Media.Animation;

namespace IEVRAutofamer.ViewModel
{
    class LoadingWindowViewModel : ViewModelBase
    {
        private Window _window;

        public LoadingWindowViewModel(Window window)
        {
            _window = window;
            ExecuteAnimations();
        }

        private void ExecuteAnimations()
        {
            try
            {
                BeginStoryboard sbR = _window.FindResource("RotateAnimation") as BeginStoryboard;
                BeginStoryboard sbS = _window.FindResource("ScaleAnimation") as BeginStoryboard;
                sbR.Storyboard.Begin();
                sbS.Storyboard.Begin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
