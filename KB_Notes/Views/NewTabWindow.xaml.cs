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
    public partial class NewTabWindow : Window
    {
        public NewTabWindow()
        {
            InitializeComponent();
            newTabTextBox.Focus();
        }

    }
}
