using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KB_Notes
{
    class App : Application
    {
        [System.STAThreadAttribute()]
        public static void Main()
        {
            App app = new App();
            app.Run();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Views.MainWindow window = new Views.MainWindow();
            window.DataContext = new ViewModels.NoteListViewModel();
            window.InitializeComponent();
            window.Show();
        }

    }
}
