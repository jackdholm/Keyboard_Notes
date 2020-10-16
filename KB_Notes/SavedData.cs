using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace KB_Notes
{
    static class SavedData
    {
        private static FileStream _fStream;
        private const string filename = "Notes.dat";

        public static ObservableCollection<NoteList> Open()
        {
            ObservableCollection<NoteList> noteLists;
            try
            {
                _fStream = File.Open(filename, FileMode.Open);
                using (StreamReader reader = new StreamReader(_fStream))
                {
                    string json = reader.ReadToEnd();
                    noteLists = JsonConvert.DeserializeObject<ObservableCollection<NoteList>>(json);
                }
            }
            catch (FileNotFoundException ex)
            {
                _fStream = File.Open(filename, FileMode.Create);
                NoteList nl = new NoteList("List1");
                noteLists = new ObservableCollection<NoteList>();
                noteLists.Add(nl);
            }
            finally
            {
                _fStream.Close();
            }
            return noteLists;
        }

        public static void Save(ObservableCollection<NoteList> lists)
        {
            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                writer.Write(JsonConvert.SerializeObject(lists));
            }
        }
    }
}
