using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.Commands
{
    class CloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void CloseDelegate(Utilities.IClosable window);
        private CloseDelegate _delegate;

        public CloseCommand(CloseDelegate del)
        {
            _delegate = del;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _delegate((Utilities.IClosable)parameter);
        }
    }
}
