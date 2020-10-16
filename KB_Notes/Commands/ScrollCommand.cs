using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.Commands
{
    class ScrollCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public delegate void ScrollDelegate(int direction);
        private ScrollDelegate _del;
        private int _direction;

        public ScrollCommand(ScrollDelegate del, int direction)
        {
            _del = del;
            _direction = direction;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _del(_direction);
        }
    }
}
