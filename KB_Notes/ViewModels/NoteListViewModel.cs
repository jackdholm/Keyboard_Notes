﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace KB_Notes.ViewModels
{
    class NoteListViewModel : ViewModelBase
    {
        private int _currentTab;
        private string _currentNoteText;
        private Note _selected;
        private bool _tabsFocused;
        private bool _textFocused;
        private double _textSize;
        private readonly MvvmDialogs.DialogService _dialogService;
        private const int TEXT_SIZE_DEFAULT = 12;
        private const int TEXT_SIZE_MAX = 36;
        private const int TEXT_SIZE_MIN = 8;

        public ObservableCollection<NoteList> Tabs { get; set; }
        #region Commands
        public ICommand NewNote { get; set; }
        public ICommand ResetFocus { get; set; }
        public ICommand RemoveFocus { get; set; }
        public ICommand ScrollUp { get; set; }
        public ICommand ScrollDown { get; set; }
        public ICommand ScrollLeft { get; set; }
        public ICommand ScrollRight { get; set; }
        public ICommand DeleteNote { get; set; }
        public ICommand NewTab { get; set; }
        public ICommand DeleteTab { get; set; }
        public ICommand OpenHelp { get; set; }
        public ICommand Reverse { get; set; }
        public ICommand Exit { get; set; }
        public ICommand EditNote { get; set; }
        public ICommand ChangeTextSize { get; set; }
        #endregion

        public NoteListViewModel()
        {
            Tabs = Utilities.SavedData.Open();
            Utilities.SavedData.Save(Tabs);
            NewNote = new Commands.NewNoteCommand(this);
            TextSize = TEXT_SIZE_DEFAULT;
            CurrentTab = 0;
            SelectedIndex = -1;
            TabsFocused = true; // Unused
            _dialogService = new MvvmDialogs.DialogService(null, new Utilities.Locator(), null);
            ScrollUp = new Commands.ScrollCommand(verticalScroll, -1);
            ScrollDown = new Commands.ScrollCommand(verticalScroll, 1);
            ScrollLeft = new Commands.ScrollCommand(horizontalScroll, -1);
            ScrollRight = new Commands.ScrollCommand(horizontalScroll, 1);
            ResetFocus = new Commands.SetPropertyCommand(setFocus, true);
            RemoveFocus = new Commands.SetPropertyCommand(setFocus, false);
            DeleteNote = new Commands.GenericCommand(deleteNote);
            NewTab = new Commands.GenericCommand(createTab);
            DeleteTab = new Commands.GenericCommand(deleteTab);
            OpenHelp = new Commands.GenericCommand(openHelp);
            Reverse = new Commands.GenericCommand(reverseNotes);
            Exit = new Commands.CloseCommand(exitApplication);
            EditNote = new Commands.GenericCommand(openEdit);
            ChangeTextSize = new Commands.BoolCommand(textSize);
        }
        public int CurrentTab
        {
            get { return _currentTab; }
            set
            {
                _currentTab = value;
                OnPropertyChanged("CurrentTab");
                OnPropertyChanged("TabTest");
            }
        }
        public string TabTest
        {
            get { return _currentTab.ToString(); }
        }
        public NoteList CurrentList
        {
            get { return Tabs[_currentTab]; }
        }
        public string CurrentNoteText
        {
            get { return _currentNoteText; }
            set
            {
                _currentNoteText = value;
                OnPropertyChanged("CurrentNoteText");
            }
        }
        public double TextSize
        {
            get { return _textSize; }
            set
            {
                _textSize = value;
                OnPropertyChanged("TextSize");
            }
        }
        public string IndexString
        {
            get { return SelectedIndex.ToString(); }
        }
        public Note Selected
        {
            get { return CurrentList.Notes[SelectedIndex]; }
        }
        public int SelectedIndex
        {
            get { return CurrentList.CurrentIndex; }
            set
            {
                CurrentList.CurrentIndex = value;
                OnPropertyChanged("SelectedIndex");
                OnPropertyChanged("IndexString");
            }
        }
        public bool TabsFocused
        {
            get { return _tabsFocused; }
            set
            {
                _tabsFocused = value;
                OnPropertyChanged("TabsFocused");
            }
        }
        public bool TextFocused
        {
            get { return _textFocused; }
            set
            {
                _textFocused = value;
                OnPropertyChanged("TextFocused");
            }
        }
        public void CreateNote()
        {
            if (_currentNoteText == null)
                _currentNoteText = "";  
            CurrentList.Add(_currentNoteText);
            CurrentNoteText = "";
            Utilities.SavedData.Save(Tabs);
        }
        private void verticalScroll(int direction)
        {
            int newIndex = SelectedIndex + direction;
            if (newIndex < 0)
                newIndex = 0;
            if (newIndex >= CurrentList.Notes.Count)
                newIndex--;
            SelectedIndex = newIndex;
        }
        private void horizontalScroll(int direction)
        {
            int newIndex = _currentTab + direction;
            if (newIndex < 0)
                newIndex = 0;
            if (newIndex >= Tabs.Count)
                newIndex--;
            CurrentTab = newIndex;
        }
        private void setFocus(bool focused)
        {
            TextFocused = !focused;
            TabsFocused = focused;
        }
        private void deleteNote()
        {
            int temp = SelectedIndex;
            if (temp >= 0 && temp < CurrentList.Size)
            {
                CurrentList.Remove(temp);
                SelectedIndex = temp > 0 ? temp - 1 : 0;
                Utilities.SavedData.Save(Tabs);
            }
        }
        private void createTab()
        {
            ViewModels.NewTabViewModel vm = new ViewModels.NewTabViewModel(_dialogService);
            if (_dialogService.ShowDialog(this, vm) == true)
            {
                Tabs.Add(new NoteList(vm.CurrentText));
                Utilities.SavedData.Save(Tabs);
            }
        }
        private void deleteTab()
        {
            int temp = CurrentTab;
            if (temp >= 0 && temp < Tabs.Count)
            {
                ViewModels.ConfirmViewModel vm = new ViewModels.ConfirmViewModel(_dialogService, CurrentList.Name);
                if (_dialogService.ShowDialog(this, vm) == true)
                {
                    SelectedIndex = -1;
                    Tabs.RemoveAt(temp);
                    CurrentTab = temp > 0 ? temp - 1 : 0;
                    if (Tabs.Count == 0)
                        Tabs.Add(new NoteList("List1"));
                    Utilities.SavedData.Save(Tabs);
                }
            }
                
        }
        private void openHelp()
        {
            _dialogService.ShowDialog(this, new ViewModels.HelpViewModel(_dialogService));
        }
        private void reverseNotes()
        {
            CurrentList.Reverse();
            Utilities.SavedData.Save(Tabs);
        }
        private void openEdit()
        {
            if (SelectedIndex >= 0)
            {
                _dialogService.ShowDialog(this, new ViewModels.EditViewModel(_dialogService, Selected));
                CurrentList.ChangeNote(SelectedIndex, Selected.Text);
                Utilities.SavedData.Save(Tabs);
            }
        }
        private void exitApplication(Utilities.IClosable window)
        {
            window.Close();
        }
        private void textSize(bool increase)
        {
            double temp = increase ? _textSize + 2 : _textSize - 2;
            if (temp > TEXT_SIZE_MAX)
                temp = TEXT_SIZE_MAX;
            else if (temp < TEXT_SIZE_MIN)
                temp = TEXT_SIZE_MIN;

            TextSize = temp;
            foreach (NoteList n in Tabs)
                n.UpdateNotes();
        }
    }
}
