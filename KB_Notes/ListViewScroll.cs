using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace KB_Notes
{
    public static class ListViewScroll
    {
        public static bool GetScrollToSelection(ListViewItem listViewItem)
        {
            return (bool)listViewItem.GetValue(ScrollToSelectionProperty);
        }

        public static void SetScrollToSelection(ListViewItem listViewItem, bool value)
        {
            listViewItem.SetValue(ScrollToSelectionProperty, value);
        }

        public static readonly DependencyProperty ScrollToSelectionProperty =
            DependencyProperty.RegisterAttached("ScrollToSelection",
                typeof(bool),
                typeof(ListViewScroll),
                new UIPropertyMetadata(false, OnScrollToSelectionChanged));

        static void OnScrollToSelectionChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ListViewItem item = obj as ListViewItem;
            if (item == null)
                return;
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
                item.Selected += OnScrollToSelectionSelected;
            else
                item.Selected -= OnScrollToSelectionSelected;
        }

        static void OnScrollToSelectionSelected(object sender, RoutedEventArgs e)
        {
            if (!Object.ReferenceEquals(sender, e.OriginalSource))
                return;
            ListViewItem item = e.OriginalSource as ListViewItem;
            if (item != null)
                item.BringIntoView();
        }
    }
}
