using System;
using System.Windows.Controls;
using System.Windows;
using AppShell.Controls.UI;

namespace AppShell.Controls
{
    /// <summary>
    /// Сервис для работы со структурой DockingManager.
    /// </summary>
    public class DockContainerService : IDockContainerService
    {
        /// <summary>
        /// Экземпляр очереди сообщений DockingManager.
        /// </summary>
        IDockingManagerMessageQueue _messageQueue;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="messageQueue">Экземпляр очереди сообщений DockingManager.</param>
        public DockContainerService(IDockingManagerMessageQueue messageQueue) 
        { 
            _messageQueue = messageQueue;
        }

        #region SplitPanel(DockPanelAttachedArgs args)
        /// <summary>
        /// Разбеение указанной панели на две панели.
        /// </summary>
        /// <param name="args">Аргументы присоеденения.</param>
        public void SplitPanel(PanelSPlittedMessgage args)
        {
            var perncent = 30;
            UIElement dockGrid = null;
            var panel = args.PanelSplitted;
            IDockPanelGrid parent = panel.Parent as IDockPanelGrid;
            var parentColumnIndex = (int)panel.GetValue(Grid.ColumnProperty);
            var parentRowIndex = (int)panel.GetValue(Grid.RowProperty);
            parent.Children.Remove(panel);

            var added = new UI.DockPanel(_messageQueue);
            switch (args.SplitType)
            {
                case DockPanelAttachedType.Right:
                case DockPanelAttachedType.Left:
                    dockGrid = new DockPanelHorizontalContainer(args.SplitType, panel.ActualWidth.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                case DockPanelAttachedType.Top:
                case DockPanelAttachedType.Bottom:
                    dockGrid = new DockPanelVerticalContainer(args.SplitType, panel.ActualHeight.GetPercent(perncent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                default:
                    throw new Exception("ee");
            }
        }
        #endregion

        #region RemovePanel(UI.DockPanel panel)
        /// <summary>
        /// Удаление паели из структуры докинга.
        /// </summary>
        /// <param name="panel">Экземпляр удаляемой панелию</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void RemovePanel(UI.DockPanel panel)
        {
            var parent = panel.Parent as Grid;
            if (parent.Parent is DockingManager)
            {
                throw new Exception("Нельзя удалять корневой контейнер.");
            }

            var parentRowIndex = (int)parent.GetValue(Grid.RowProperty);
            var parentColumnIndex = (int)parent.GetValue(Grid.ColumnProperty);

            parent.Children.Remove(panel);
            var remainingChild = parent.Children[0];
            parent.Children.Clear();
            var ownerParent = parent.Parent as Grid;

            remainingChild.SetValue(Grid.RowProperty, parentRowIndex);
            remainingChild.SetValue(Grid.ColumnProperty, parentColumnIndex);
            ownerParent.Children.Remove(parent);
            ownerParent.Children.Add(remainingChild);
        }
        #endregion
    }
}
