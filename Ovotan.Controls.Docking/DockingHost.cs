using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Services;
using Ovotan.Controls.Docking.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Controls.Docking
{
    public class DockingHost : ContentControl
    {
        DockPlacementWindow _dockPlacementWindow;
        /// <summary>
        /// Экземпляр сервиса для создания контейнеров для DockPanel.
        /// </summary>
        IDockConstractureService _dockConstractureService;
        /// <summary>
        /// Экземпляр сервиса очереди сообщений для DockingManager.
        /// </summary>
        public IDockingMessageQueue _dockingMessageQueue;
        PanelContainer _rootGrid;
        IDockPanel _previousActiveDockPanel;

        public DockingHost()
        {
            _dockingMessageQueue = new DockingMessageQueue();
            _dockPlacementWindow = new DockPlacementWindow(_dockingMessageQueue);
            _dockingMessageQueue.Register(DockingMessageType.PanelClosed, (x) => _dockConstractureService.RemovePanel(x as DockPanel));
            _dockingMessageQueue.Register(DockingMessageType.PanelSplitted, (x) => _dockConstractureService.SplitPanel(x as PanelSplittedMessage));
            _dockingMessageQueue.Register(DockingMessageType.PanelAttached, (x) => _panelAttached((PanelAttachedType)x));
            _dockingMessageQueue.Register(DockingMessageType.PanelGotFocus, _dockPanelFocused);
            _dockingMessageQueue.Register(DockingMessageType.StartDraggingDockWindow, _showDockPlacementWindow);
            _dockConstractureService = new DockConstractureService(_dockingMessageQueue);

            var baseContent = new DockPanel(_dockingMessageQueue);
            // _rootGrid = new DockPanelSingleContainer(baseContent);
            Content = new PanelContainer(baseContent);
        }



        #region DockingManagerMessageQueue handlers
        void _panelAttached(PanelAttachedType type)
        {
            _dockPlacementWindow.Hide();
            _dockConstractureService.AttachPanel(type, this, _rootGrid);
        }

        void _showDockPlacementWindow(object args)
        {
            var startPoints = this.PointToScreen(new Point());
            _dockPlacementWindow.Top = startPoints.Y;
            _dockPlacementWindow.Left = startPoints.X;
            _dockPlacementWindow.Height = ActualHeight;
            _dockPlacementWindow.Width = ActualWidth;
            _dockPlacementWindow.Show();
        }


        void _dockPanelFocused(object args)
        {
            if (_previousActiveDockPanel != null)
            {
                _previousActiveDockPanel.ChangeFocusState(false);
            }
            _previousActiveDockPanel = args as IDockPanel;
        }
        #endregion
    }
}
