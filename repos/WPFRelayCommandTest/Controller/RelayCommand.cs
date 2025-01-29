using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFRelayCommandTest.Controller
{
    internal class RelayCommand : ICommand
    {

        Action<object> _execute;
        Predicate<object> _canExecute;

        public RelayCommand(Action<object> _execute)
        {
            this._execute = _execute; 
            _canExecute = (object parameter) => true;
        }

        public RelayCommand(Action<object> _execute, Predicate<object> _canExecute)
        {
            this._execute = _execute;
            this._canExecute = _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);         
        }
    }
}
