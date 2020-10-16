using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.Commands
{
    class NewNoteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private NoteListViewModel _vm;

        public NewNoteCommand(NoteListViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.CreateNote();
        }

    }
}
