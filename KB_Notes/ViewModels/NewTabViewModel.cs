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
        private bool _createTab = false;

        public NewTabViewModel(IDialogService dialogService)
        {
            _text = "";
            _dialogService = dialogService;
            Finish = new Commands.BoolCommand(finish);
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

        public bool? DialogResult { get { return _createTab && _text.Length > 0 ; } }

        private void finish(bool createTab)
        {
            _createTab = createTab;
            _dialogService.Close(this);
        }
    }
}
