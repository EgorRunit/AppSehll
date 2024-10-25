using Ovotan.ApplicationShell.Controls.Configurations;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.ApplicationShell.Controls
{
        public class EndPointObjectBrowserTreeItem : TreeViewItem
    {
        public EndPointObjectBrowserTreeItemType Type { get; set; }

        public object Data { get; set; }

        static EndPointObjectBrowserTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EndPointObjectBrowserTreeItem), new FrameworkPropertyMetadata(typeof(TreeViewItem)));
        }
    }
}
