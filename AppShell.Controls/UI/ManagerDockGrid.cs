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
        IDockingManagerMessageQueue _dockingManagerMessageQueue;
        BaseDockGrid _rootGrid;

        public ManagerDockGrid() 
        {
            _dockingManagerMessageQueue = new DockingManagerMessageQueue();
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelAttached, _panellAttachedCallback);
            var baseContent = new DockPanelCellContent(_dockingManagerMessageQueue);
            _rootGrid = new BaseDockGrid(baseContent);
           Content = _rootGrid;
        }

        void _panellAttachedCallback(object args)
        {
            //DockPanelCellContent panel, SnapPanelType type
            var messageArgs = args as DockingManagerPanelAttachedArgs;
            var perncent = 30;
            UIElement dockGrid = null;
            var panel = messageArgs.DockPanelCellContent;
            IDockPanelGrid parent = panel.Parent as IDockPanelGrid;
            var parentColumnIndex = (int)panel.GetValue(Grid.ColumnProperty);
            var parentRowIndex = (int)panel.GetValue(Grid.RowProperty);
            parent.Children.Remove(panel);

            var added = new DockPanelCellContent(_dockingManagerMessageQueue);
            switch (messageArgs.DockPanelAttachedType)
            {
                case DockPanelAttachedType.Right:
                case DockPanelAttachedType.Left:
                    dockGrid = new DockGridHorizontal(messageArgs.DockPanelAttachedType, panel.ActualWidth.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                case DockPanelAttachedType.Top:
                case DockPanelAttachedType.Bottom:
                    dockGrid = new DockGridVertical(messageArgs.DockPanelAttachedType, panel.ActualHeight.GetPercent(perncent), panel, added);
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
