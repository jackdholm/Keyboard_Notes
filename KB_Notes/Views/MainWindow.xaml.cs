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

namespace KB_Notes
{
    // Code behind file used for setting focus due to issues with attached properties not updating the textbox
    public partial class MainWindow : Window
    {
        public ICommand FocusTabs { get; set; }
        public ICommand FocusText { get; set; }

        public MainWindow()
        {
            DataContext = new NoteListViewModel();
            InitializeComponent();
            FocusTabs = new Commands.FocusCommand(focusTabs);
            FocusText = new Commands.FocusCommand(focusText);
        }

        private void focusTabs()
        {
            Tabs.Focus();
        }
        private void focusText()
        {
            textBox.Focus();
        }
    }
}
