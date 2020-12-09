using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace KB_Notes
{
    class NoteList : ViewModelBase
    {
        private bool _append;
        private string _name;
        private ObservableCollection<Note> _notes;
        private int _currentIndex;

        public NoteList(String name)
        {
            _name = name;
            _notes = new ObservableCollection<Note>();
            _currentIndex = -1;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;  
            }
        }
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
            }
        }
        public void Add(string s)
        {
            Note n = new Note(s);
            if (_append)
                _notes.Add(n);
            else
                _notes.Insert(0, n);
        }
        public void Remove(int i)
        {
            _notes.RemoveAt(i);
        }
        public int Size
        {
            get { return _notes.Count; }
        }
        public ObservableCollection<Note> Notes
        {
            get { return _notes; }
        }
        public bool Append 
        { 
            get { return _append; }
            set
            {
                _append = value;
            }
        }
        public void Reverse()
        {
            _append = !_append;
            ObservableCollection<Note> newList = new ObservableCollection<Note>();
            foreach (Note n in _notes)
                newList.Insert(0, n);
            _notes = newList;
            OnPropertyChanged("Notes");
        }
        public void ChangeNote(int i, string text)
        {
            ObservableCollection<Note> newList = new ObservableCollection<Note>(_notes);
            Note n = new Note(text);
            n.Date = _notes[i].Date;
            newList[i] = n;
            _notes = newList;
            OnPropertyChanged("Notes");
            OnPropertyChanged("Text");
        }
        public void UpdateNotes()
        {
            if (_notes.Count > 0)
            {
                ChangeNote(0, _notes[0].Text);
            }
        }
    }
}
    