using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppShell.Controls.UI
{
    public class DockingManager : ContentControl
    {
        IDockingManagerMessageQueue _dockingManagerMessageQueue;
        BaseDockGrid _rootGrid;
        IDockPanel _previousActiveDockPanel;


        public DockingManager() 
        {
            _dockingManagerMessageQueue = new DockingManagerMessageQueue();
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelAttached, _panellAttachedCallback);
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelGotFocus, _dockPanelFocused);
            var baseContent = new DockPanel(_dockingManagerMessageQueue);
            _rootGrid = new BaseDockGrid(baseContent);
           Content = _rootGrid;
        }

        void _dockPanelFocused(object args)
        {
            if (_previousActiveDockPanel != null)
            {
                _previousActiveDockPanel.ChangeFocusState(false);
            }
            _previousActiveDockPanel = args as IDockPanel;
        }

        void _panellAttachedCallback(object args)
        {
            //DockPanelCellContent panel, SnapPanelType type
            var messageArgs = args as PanelAttachedArgs;
            var perncent = 30;
            UIElement dockGrid = null;
            var panel = messageArgs.DockPanel;
            IDockPanelGrid parent = panel.Parent as IDockPanelGrid;
            var parentColumnIndex = (int)panel.GetValue(Grid.ColumnProperty);
            var parentRowIndex = (int)panel.GetValue(Grid.RowProperty);
            parent.Children.Remove(panel);

            var added = new DockPanel(_dockingManagerMessageQueue);
            switch (messageArgs.AttachedType)
            {
                case DockPanelAttachedType.Right:
                case DockPanelAttachedType.Left:
                    dockGrid = new DockGridHorizontal(messageArgs.AttachedType, panel.ActualWidth.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                case DockPanelAttachedType.Top:
                case DockPanelAttachedType.Bottom:
                    dockGrid = new DockGridVertical(messageArgs.AttachedType, panel.ActualHeight.GetPercent(perncent), panel, added);
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
