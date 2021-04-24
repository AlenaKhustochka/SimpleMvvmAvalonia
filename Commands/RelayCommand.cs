using System;
using System.Windows.Input;

namespace SimpleMvvmAvalonia.Commands
{
    public class RelayCommand : ICommand
    {
        private Action Command;
        private Func<bool> CanExecute;

        public RelayCommand(Action command)
        {
            Command = command;
        }

        public RelayCommand(Action command, Func<bool> canExecute)
        {
            Command = command;
            CanExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (CanExecute != null) return CanExecute();
            if (Command != null) return true;
            return false;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void Execute(object parametr)
        {
            if (Command != null) Command();
        }
    }
}