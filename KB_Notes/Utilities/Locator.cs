using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KB_Notes.Utilities
{
    class Locator : MvvmDialogs.DialogTypeLocators.IDialogTypeLocator
    {
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            Type t = viewModel.GetType();
            if (t == typeof(ViewModels.NewTabViewModel))
                return typeof(Views.NewTabWindow);
            else if (t == typeof(ViewModels.NoteListViewModel))
                return typeof(Views.MainWindow);
            else if (t == typeof(ViewModels.ConfirmViewModel))
                return typeof(Views.ConfirmWindow);
            else if (t == typeof(ViewModels.HelpViewModel))
                return typeof(Views.HelpWindow);
            else
                return null;
        }
    }
}
