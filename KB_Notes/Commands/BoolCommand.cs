using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.Commands
{
    class BoolCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void BoolDelegate(bool value);
        private BoolDelegate _delegate;

        public BoolCommand(BoolDelegate del)
        {
            _delegate = del;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            _delegate((bool)parameter);
        }
    }
}
