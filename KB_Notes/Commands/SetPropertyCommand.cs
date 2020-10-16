using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.Commands
{
    class SetPropertyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void SetDelegate(bool f);
        private SetDelegate _del;
        private bool _value;
        
        public SetPropertyCommand(SetDelegate del, bool value)
        {
            _del = del;
            _value = value;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _del(_value);
        }
    }
}
