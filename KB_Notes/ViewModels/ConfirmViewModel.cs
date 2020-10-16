using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmDialogs;

namespace KB_Notes.ViewModels
{
    class ConfirmViewModel : ViewModelBase, IModalDialogViewModel
    {
        private IDialogService _dialogService;
        private bool _accepted;
        private string _confirmText;

        public ConfirmViewModel(IDialogService dialogService, string tabName)
        {
            ConfirmText = "Delete tab: \"" + tabName + "\"? (Y/N)";
            _dialogService = dialogService;
            Finish = new Commands.BoolCommand(finish);
        }
        public bool? DialogResult { get { return _accepted; } }

        public ICommand Finish { get; set; }
        public string ConfirmText
        {
            get { return _confirmText; }
            set
            {
                _confirmText = value;
                OnPropertyChanged("ConfirmText");
            }
        }
        private void finish(bool confirm)
        {
            _accepted = confirm;
            _dialogService.Close(this);
        }
    }
}
