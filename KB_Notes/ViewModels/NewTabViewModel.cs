using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmDialogs;

namespace KB_Notes.ViewModels
{
    class NewTabViewModel : ViewModelBase, MvvmDialogs.IModalDialogViewModel
    {
        private string _text;
        private IDialogService _dialogService;

        public NewTabViewModel(IDialogService dialogService)
        {
            _text = "";
            _dialogService = dialogService;
            Finish = new Commands.GenericCommand(finish);
        }

        public string CurrentText
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public ICommand Finish { get; set; }

        public bool? DialogResult { get { return _text.Length > 0 ; } }

        private void finish()
        {
            _dialogService.Close(this);
        }
    }
}
