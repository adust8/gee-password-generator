using GeePasswordGenerator.WPF.Commands;
using Generators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeePasswordGenerator.WPF.ViewModel
{

    internal class DefaultGeneratorViewModel : BaseViewModel
    {
        #region Ctor
        public DefaultGeneratorViewModel(Generator generator)
        {
            _generator = generator;
            GeneratePasswordCommand = new GeneratePasswordCommand(_generator, this);
            //Set default password listing length
            PasswordsListLength = 20;
            GeneratePasswordCommand.PasswordListChanged += OnPasswordListChanged;
        }
        #endregion

        #region Fields
        private readonly Generator _generator;
        #endregion

        #region Properties
        #region Password generator options
        private bool _useUpperCase;
        public bool UseUpperCase
        {
            get => _useUpperCase;
            set => Set(ref _useUpperCase, value);
        }
        private bool _useNumbers;
        public bool UseNumbers
        {
            get => _useNumbers;
            set => Set(ref _useNumbers, value);
        }
        private bool _useSymbols;
        public bool UseSymbols
        {
            get => _useSymbols;
            set => Set(ref _useSymbols, value);
        }
        private int _passwordsListLength;

        public int PasswordsListLength
        {
            get => _passwordsListLength;
            set => Set(ref _passwordsListLength, value);
        }
        private int _passwordLength;
        public int PasswordLength
        {
            get => _passwordLength;
            set => Set(ref _passwordLength, value);
        }
        private ObservableCollection<string> _passwordList;

        public ObservableCollection<string> PasswordList
        {
            get => _passwordList;
            set => Set(ref _passwordList, value);
        }


        #endregion

        #endregion

        #region Commands
        public GeneratePasswordCommand GeneratePasswordCommand { get; set; }
        #endregion

        #region Methods
        private void OnPasswordListChanged()
        {
            OnPropertyChanged(nameof(PasswordList));
        }
        #endregion
    }
}
