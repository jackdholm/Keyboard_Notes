using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KB_Notes.Views
{
    // Code behind file used for setting focus due to issues with attached properties not updating the textbox
    public partial class MainWindow : Window
    {
        public ICommand FocusTabs { get; set; }
        public ICommand FocusText { get; set; }
        public ICommand MoveLeft { get; set; }
        public ICommand MoveRight { get; set; }
        public ICommand MoveDown { get; set; }
        public ICommand MoveUp { get; set; }
        public MainWindow()
        {
            DataContext = new ViewModels.NoteListViewModel();
            InitializeComponent();
            FocusTabs = new Commands.FocusCommand(focusTabs);
            FocusText = new Commands.FocusCommand(focusText);
            MoveLeft = new Commands.ScrollCommand(horizontalScroll, -1);
            MoveRight = new Commands.ScrollCommand(horizontalScroll, 1);
            MoveUp = new Commands.ScrollCommand(verticalScroll, 1);
            MoveDown = new Commands.ScrollCommand(verticalScroll, -1);
        }

        private void focusTabs()
        {
            Tabs.Focus();
        }
        private void focusText()
        {
            textBox.Focus();
        }
        private void horizontalScroll(int direction)
        {
            if (direction < 0)
                EditingCommands.MoveLeftByWord.Execute(null, textBox);
            else
                EditingCommands.MoveRightByWord.Execute(null, textBox);
        }
        private void verticalScroll(int direction)
        {
            if (direction < 0)
                EditingCommands.MoveDownByLine.Execute(null, textBox);
            else
                EditingCommands.MoveUpByLine.Execute(null, textBox);
        }
    }
}
