using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KB_Notes.Views
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ICommand MoveLeft { get; set; }
        public ICommand MoveRight { get; set; }
        public ICommand MoveDown { get; set; }
        public ICommand MoveUp { get; set; }

        public EditWindow()
        {
            InitializeComponent();
            textBox.Focus();
            MoveLeft = new Commands.ScrollCommand(horizontalScroll, -1);
            MoveRight = new Commands.ScrollCommand(horizontalScroll, 1);
            MoveUp = new Commands.ScrollCommand(verticalScroll, 1);
            MoveDown = new Commands.ScrollCommand(verticalScroll, -1);
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
