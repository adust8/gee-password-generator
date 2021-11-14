using GeePasswordGenerator.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeePasswordGenerator.WPF.Factories
{
    internal interface IViewModelsFactory
    {
        BaseViewModel CreateViewModel(ViewModelType viewModelType);
    }
}
