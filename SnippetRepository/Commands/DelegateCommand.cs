using System;
using System.Windows.Input;

namespace WebForms2011.Commands
{
    public class DelegateCommand : ICommand
    {
        public Action ExecuteCommand { get; set; }
        public Func<object, bool> CanExecuteCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
                return CanExecuteCommand(parameter);
            return true;
        }

        public void Execute(object p)
        {
            if (ExecuteCommand != null)
                ExecuteCommand();
        }

        public event EventHandler CanExecuteChanged;
    }

    public class DelegateCommand<T> : ICommand
    {
        public Action<T> ExecuteCommand { get; set; }
        public Func<T, bool> CanExecuteCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
                return CanExecuteCommand((T)parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            if (ExecuteCommand != null)
                ExecuteCommand((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
