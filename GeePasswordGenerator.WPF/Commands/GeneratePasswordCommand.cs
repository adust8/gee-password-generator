using GeePasswordGenerator.WPF.ViewModel;
using Generators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeePasswordGenerator.WPF.Commands
{
    internal class GeneratePasswordCommand : BaseCommand
    {
        private readonly Generator _generator;
        private readonly DefaultGeneratorViewModel _viewModel;
        public event Action PasswordListChanged;

        public GeneratePasswordCommand(Generator generator, DefaultGeneratorViewModel viewModel)
        {
            _generator = generator;
            _viewModel = viewModel;
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _viewModel.PasswordList = new ObservableCollection<string>(_generator.Generate(_viewModel.UseUpperCase, _viewModel.UseNumbers, _viewModel.UseSymbols, _viewModel.PasswordLength, _viewModel.PasswordsListLength));
            OnPasswordListChanged();
        }
        public void OnPasswordListChanged()
        {
            PasswordListChanged?.Invoke();
        }
    }
}
