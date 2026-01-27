using IEVRAutofamer.ViewModel;

namespace IEVRAutofamer.MVVM
{
    class NavigateCommand<T> : RelayCommand where T : ViewModelBase
    {
        public readonly NavigationStore navigationStore;

        public NavigateCommand(NavigationStore navigationStore, Func<T> createViewModel) 
            : base ((o) => navigationStore.CurrentViewModel = createViewModel())
        {
            this.navigationStore = navigationStore;
        }
    }
}
