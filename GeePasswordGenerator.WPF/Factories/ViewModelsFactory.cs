using GeePasswordGenerator.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeePasswordGenerator.WPF.Factories
{
    public enum ViewModelType
    {
        Main
    }
    internal class ViewModelsFactory : IViewModelsFactory
    {
        public BaseViewModel CreateViewModel(ViewModelType viewModelType)
        {
            return viewModelType switch
            {
                ViewModelType.Main => new MainWindowViewModel(),
                _ => throw new ArgumentNullException($"Can't create a new instance of {viewModelType}")
            };
        }
    }
}
