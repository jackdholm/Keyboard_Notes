using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.Commands
{
    class GenericCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void GenericDelegate();
        private GenericDelegate _delegate;

        public GenericCommand(GenericDelegate d)
        {
            _delegate = d;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _delegate();
        }
    }
}
