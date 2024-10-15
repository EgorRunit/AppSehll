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
            var baseContent = new DockPanelCellContent(_splitDockPanel);
            _rootGrid = new BaseDockGrid(baseContent);
           Content = _rootGrid;
        }

        void _splitDockPanel(DockPanelCellContent panel, SnapPanelType type)
        {
            var perncent = 30;
            UIElement dockGrid = null;
            IDockPanelGrid parent = panel.Parent as IDockPanelGrid;
            var parentColumnIndex = (int)panel.GetValue(Grid.ColumnProperty);
            var parentRowIndex = (int)panel.GetValue(Grid.RowProperty);
            parent.Children.Remove(panel);

            var added = new DockPanelCellContent(_splitDockPanel);
            switch (type)
            {
                case SnapPanelType.Right:
                case SnapPanelType.Left:
                    dockGrid = new DockGridHorizontal(type, panel.ActualWidth.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                case SnapPanelType.Top:
                case SnapPanelType.Bottom:
                    dockGrid = new DockGridVertical(type, panel.ActualHeight.GetPercent(perncent), panel, added);
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
