using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KB_Notes.ViewModels
{
    class EditViewModel : ViewModelBase, IModalDialogViewModel
    {
        private Note _note;
        private string _text;
        private IDialogService _dialogService;
        private bool _changed = false;
        public ICommand Finish { get; set; }

        public EditViewModel(IDialogService dialogService, Note note)
        {
            _dialogService = dialogService;
            _note = note;
            _text = note.Text;
            Finish = new Commands.BoolCommand(finish);
        }
        public bool? DialogResult { get { return _changed; } }
        public string CurrentText
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
        private void finish(bool changeNote)
        {
            if (changeNote)
            {
                _changed = true;
                _note.Text = _text;
            }
            _dialogService.Close(this);
        }
    }
}
