using System.Windows.Controls;
using System.Windows;

namespace AppShell.Controls.UI
{
    public class DockPanelSingleContainer : Grid, IDockPanelGrid
    {
        public DockPanelSingleContainer(FrameworkElement baseContent)
        {
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            Children.Add(baseContent);
        }
    }
}
