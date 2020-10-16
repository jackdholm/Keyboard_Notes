using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.Commands
{
    class FocusCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void FocusDelegate();
        private FocusDelegate _del;

        public FocusCommand(FocusDelegate del)
        {
            _del = del;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _del();
        }
    }
}
