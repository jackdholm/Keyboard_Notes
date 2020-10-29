using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmDialogs;

namespace KB_Notes.ViewModels
{
    class HelpViewModel : ViewModelBase, IModalDialogViewModel
    {
        private IDialogService _dialogService;
        private static string _text = "New Tab: Ctrl-N\nCreate Note Mode: Enter\nNavigation Mode: Escape\nTab Navigation: H/L\nNote Navigation: J/K\nDelete Note: Delete\nDelete Tab: Shift+Delete\nChange Order: Ctrl-O\n#TWhen Creating notes:\nTitle Text: #T\nAdd Note: Shift+Enter\nShift+H/J/K/L: Navigation";

        public HelpViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            Finish = new Commands.GenericCommand(finish);
        }

        public string HelpText { get { return _text; } }
        public bool? DialogResult { get { return true; } }

        public ICommand Finish { get; set; }
        private void finish()
        {
            _dialogService.Close(this);
        }
      
    }
}
