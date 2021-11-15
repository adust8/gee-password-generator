using GeePasswordGenerator.WPF.Factories;
using GeePasswordGenerator.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeePasswordGenerator.WPF.Commands
{
    internal class NavigationCommand : BaseCommand
    {
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelsFactory _viewModelsFactory;

        public NavigationCommand(INavigationStore navigationStore, IViewModelsFactory viewModelsFactory)
        {
            _navigationStore = navigationStore;
            _viewModelsFactory = viewModelsFactory;
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            ViewModelType viewModelType = (ViewModelType)parameter;
            _navigationStore.CurrentViewModel = _viewModelsFactory.CreateViewModel(viewModelType);
        }
    }
}
