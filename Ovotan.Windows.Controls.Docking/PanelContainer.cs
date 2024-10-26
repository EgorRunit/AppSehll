using System.Windows.Controls;
using System.Windows;
using Ovotan.Windows.Controls.Docking.Interfaces;

namespace Ovotan.Windows.Controls.Docking
{
    public class PanelContainer : Grid, IDockPanelContainer
    {
        public PanelContainer(FrameworkElement baseContent)
        {
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            Children.Add(baseContent);
        }
    }
}
