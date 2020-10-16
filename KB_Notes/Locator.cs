using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KB_Notes
{
    class Locator : MvvmDialogs.DialogTypeLocators.IDialogTypeLocator
    {
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            if (viewModel.GetType() == typeof(ViewModels.NewTabViewModel))
                return typeof(Views.NewTabWindow);
            else if (viewModel.GetType() == typeof(NoteListViewModel))
                return typeof(MainWindow);
            else if (viewModel.GetType() == typeof(ViewModels.ConfirmViewModel))
                return typeof(Views.ConfirmWindow);
            else
                return null;
        }
    }
}
