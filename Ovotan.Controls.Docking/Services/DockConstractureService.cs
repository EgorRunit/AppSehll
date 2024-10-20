using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using System.Windows.Controls;
using System.Windows;

namespace Ovotan.Controls.Docking.Services
{
    public class DockConstractureService : IDockConstractureService
    {
        /// <summary>
        /// Экземпляр очереди сообщений docking.
        /// </summary>
        IDockingMessageQueue _messageQueue;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="messageQueue">Экземпляр очереди сообщений DockingManager.</param>
        public DockConstractureService(IDockingMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public void AttachPanel(PanelAttachedType type, DockingHost dockingHost, FrameworkElement dockPanelContent)
        {

            var parent = dockingHost.Content as Grid;
            var percent = 20;
            var added = new DockPanel(_messageQueue, dockPanelContent);
            var panel = parent.Children[0] as FrameworkElement;
            FrameworkElement newPanelContainer = null;
            parent.Children.Clear();
            switch (type)
            {
                case PanelAttachedType.Left:
                    newPanelContainer = new PanelHorizontalContainer(PanelSplittedType.Left,dockingHost.ActualWidth.GetPercent(percent), panel, added);
                    break;
                case PanelAttachedType.Right:
                    newPanelContainer = new PanelHorizontalContainer(PanelSplittedType.Right, dockingHost.ActualWidth.GetPercent(percent), panel, added);
                    break;
                case PanelAttachedType.Top:
                    newPanelContainer = new PanelVerticalContainer(PanelSplittedType.Top, dockingHost.ActualHeight.GetPercent(percent), panel, added);
                    break;
                case PanelAttachedType.Bottom:
                    newPanelContainer = new PanelVerticalContainer(PanelSplittedType.Bottom, dockingHost.ActualHeight.GetPercent(percent), panel, added);
                    break;
            }
            parent.Children.Add(newPanelContainer);
            

        }

        #region SplitPanel(DockPanelAttachedArgs args)
        /// <summary>
        /// Разбеение указанной панели на две панели.
        /// </summary>
        /// <param name="args">Аргументы присоеденения.</param>
        public void SplitPanel(PanelSplittedMessage args)
        {
            var percent = 30;
            UIElement dockGrid = null;
            var panel = args.PanelSplitted;
            IDockPanelContainer parent = panel.Parent as IDockPanelContainer;
            var parentColumnIndex = (int)panel.GetValue(Grid.ColumnProperty);
            var parentRowIndex = (int)panel.GetValue(Grid.RowProperty);
            parent.Children.Remove(panel);

            var added = new DockPanel(_messageQueue, args.DockPanelContent);
            switch (args.SplitType)
            {
                case PanelSplittedType.Right:
                case PanelSplittedType.Left:
                    dockGrid = new PanelHorizontalContainer(args.SplitType, panel.ActualWidth.GetPercent(percent), panel, added);
                    dockGrid.SetValue(Grid.ColumnProperty, parentColumnIndex);
                    dockGrid.SetValue(Grid.RowProperty, parentRowIndex);
                    parent.Children.Add(dockGrid);
                    break;
                case PanelSplittedType.Top:
                case PanelSplittedType.Bottom:
                    dockGrid = new PanelVerticalContainer(args.SplitType, panel.ActualHeight.GetPercent(percent), panel, added);
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
        public void RemovePanel(DockPanel panel)
        {
            var parent = panel.Parent as Grid;
            if (parent.Parent is DockingHost)
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
