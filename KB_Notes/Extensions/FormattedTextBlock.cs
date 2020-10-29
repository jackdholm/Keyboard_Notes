using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KB_Notes.Extensions
{
    class FormattedTextBlock : TextBlock
    {
        private string _plainText;
        public void Format()
        {
            Inlines.Clear();
            string[] lines = _plainText.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string s = lines[i];
                if (i < lines.Length - 1)
                    s += "\n";
                FontWeight weight;
                double size = Application.Current.MainWindow.FontSize;
                if (s.Length >= 2 && s[0] == '#' && Char.ToUpper(s[1]) == 'T')
                {
                    weight = FontWeights.Bold;
                    size *= 2;
                    s = s.Substring(2);
                }
                else
                    weight = FontWeights.Normal;

                Run inline = new Run();
                inline.FontWeight = weight;
                inline.FontSize = size;
                inline.Text = s.TrimStart();
                Inlines.Add(inline);
            }
        }
        public static readonly DependencyProperty PlainTextProperty = DependencyProperty.Register("PlainText", typeof(string), typeof(FormattedTextBlock),
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, OnPropertyChanged));
        public string PlainText
        {
            get { return (string)GetValue(PlainTextProperty); }
            set
            {
                _plainText = value;
                SetValue(PlainTextProperty, value);
                Format();
            }
        }

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FormattedTextBlock block = (FormattedTextBlock)sender;
            block.PlainText = (string)e.NewValue;
        }
    }
}
