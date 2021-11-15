using GeePasswordGenerator.WPF.Commands;
using GeePasswordGenerator.WPF.Factories;
using GeePasswordGenerator.WPF.Stores;
using System.Windows.Input;

namespace GeePasswordGenerator.WPF.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Ctor
        public MainWindowViewModel(INavigationStore navigationStore, IViewModelsFactory viewModelsFactory)
        {
            //Initialize field values
            _navigationStore = navigationStore;
            _viewModelsFactory = viewModelsFactory;
            NavigateCommand = new NavigationCommand(_navigationStore, _viewModelsFactory);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationStore.CurrentViewModel = _viewModelsFactory.CreateViewModel(ViewModelType.Default);
        }
        #endregion
        #region Fields
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelsFactory _viewModelsFactory;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        #endregion
        #region Commands
        public ICommand NavigateCommand { get; set; }
        #endregion
        #region Methods
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        #endregion
    }
}
