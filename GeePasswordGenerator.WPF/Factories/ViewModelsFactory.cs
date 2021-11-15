using GeePasswordGenerator.WPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeePasswordGenerator.WPF.Factories
{
    public enum ViewModelType
    {
        Main,
        Default,
        KeyPhrase
    }
    internal class ViewModelsFactory : IViewModelsFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelsFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseViewModel CreateViewModel(ViewModelType viewModelType)
        {
            return viewModelType switch
            {
                ViewModelType.Main => _serviceProvider.GetRequiredService<MainWindowViewModel>(),
                ViewModelType.Default => _serviceProvider.GetRequiredService<DefaultGeneratorViewModel>(),
                _ => throw new ArgumentNullException($"Can't create a new instance of {viewModelType}")
            };
        }
    }
}
