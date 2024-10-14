using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppShell.Controls.UI
{
    public class ManagerDockGrid : ContentControl
    {
        BaseDockGrid _rootGrid;

        public ManagerDockGrid() 
        { 
            var baseContent = new ContentDockPanel(_splitDockPanel);
            _rootGrid = new BaseDockGrid(baseContent);
           Content = _rootGrid;
        }

        void _splitDockPanel(ContentDockPanel panel, SnapPanelType type)
        {
            var perncent = 30;
            UIElement dockGrid = null;
            IDockPanelGrid parent = panel.Parent as IDockPanelGrid;
            var parentColumnIndex = (int)panel.GetValue(Grid.ColumnProperty);
            var parentRowIndex = (int)panel.GetValue(Grid.RowProperty);
            parent.Children.Remove(panel);

            var added = new ContentDockPanel(_splitDockPanel);
            switch (type)
            {
                case SnapPanelType.Right:
                case SnapPanelType.Left:
                    dockGrid = new HorisontalDockGrid(type, panel.ActualWidth.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                case SnapPanelType.Top:
                case SnapPanelType.Bottom:
                    dockGrid = new VerticalDockGrid(type, panel.ActualHeight.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                default:
                    throw new Exception("ee");
            }


        }
    }
}
