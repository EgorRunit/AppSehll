using System;
using System.Windows.Controls;
using System.Windows;
using AppShell.Controls.UI;

namespace AppShell.Controls
{
    public class DockContainerService : IDockContainerService
    {
        IDockingManagerMessageQueue _messageQueue;

        public DockContainerService(IDockingManagerMessageQueue messageQueue) 
        { 
            _messageQueue = messageQueue;
        } 

        public void AttachPanel(DockPanelAttachedArgs args)
        {
            var perncent = 30;
            UIElement dockGrid = null;
            var panel = args.DockPanel;
            IDockPanelGrid parent = panel.Parent as IDockPanelGrid;
            var parentColumnIndex = (int)panel.GetValue(Grid.ColumnProperty);
            var parentRowIndex = (int)panel.GetValue(Grid.RowProperty);
            parent.Children.Remove(panel);

            var added = new UI.DockPanel(_messageQueue);
            switch (args.AttachedType)
            {
                case DockPanelAttachedType.Right:
                case DockPanelAttachedType.Left:
                    dockGrid = new DockPanelHorizontalContainer(args.AttachedType, panel.ActualWidth.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                case DockPanelAttachedType.Top:
                case DockPanelAttachedType.Bottom:
                    dockGrid = new DockPanelVerticalContainer(args.AttachedType, panel.ActualHeight.GetPercent(perncent), panel, added);
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
