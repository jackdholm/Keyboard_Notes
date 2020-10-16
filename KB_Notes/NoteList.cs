using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace KB_Notes
{
    class NoteList
    {
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
            Notes.Add(n);
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
    }
}
    