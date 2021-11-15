using GeePasswordGenerator.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeePasswordGenerator.WPF.Stores
{
    internal interface INavigationStore
    {
        public BaseViewModel CurrentViewModel { get; set; }
        event Action CurrentViewModelChanged;
    }
}
