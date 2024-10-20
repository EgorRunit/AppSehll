using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Services;
using Ovotan.Controls.Docking.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.Controls.Docking
{
    public class DockingHost : ContentControl
    {
        public DockPlacementWindow _dockPlacementWindow;
        /// <summary>
        /// Экземпляр сервиса для создания контейнеров для DockPanel.
        /// </summary>
        IDockConstractureService _dockConstractureService;
        /// <summary>
        /// Экземпляр сервиса очереди сообщений для DockingManager.
        /// </summary>
        public IDockingMessageQueue _dockingMessageQueue;
        IDockPanel _previousActiveDockPanel;
        SiteHost _siteHost;

        public DockingHost()
        {
            _dockingMessageQueue = new DockingMessageQueue();
            _dockPlacementWindow = new DockPlacementWindow(this, _dockingMessageQueue);
            _dockingMessageQueue.Register(DockingMessageType.PanelClosed, (x) => _dockConstractureService.RemovePanel(x as DockPanel));
            _dockingMessageQueue.Register(DockingMessageType.PanelSplitted, (x) => _dockConstractureService.SplitPanel(x as PanelSplittedMessage));
            _dockingMessageQueue.Register(DockingMessageType.PanelAttached, (x) => _panelAttached((PanelAttachedMessage)x));
            _dockingMessageQueue.Register(DockingMessageType.ShowDockPanelWindow, (x) => _showDockPanelWindow(x as DockPanelWindow));
            _dockingMessageQueue.Register(DockingMessageType.PanelGotFocus, _dockPanelFocused);
            _dockConstractureService = new DockConstractureService(_dockingMessageQueue);

            _siteHost = new SiteHost(_dockingMessageQueue);
            var baseContent = new DockPanel(_dockingMessageQueue, _siteHost);
            Content = new PanelContainer(baseContent);
        }


        #region DockingManagerMessageQueue handlers
        void _panelAttached(PanelAttachedMessage message)
        {
            _dockConstractureService.AttachPanel(message.Type, this, message.DockPanelContent);
        }

        public void _showDockPanelWindow(DockPanelWindow window)
        {
            window.Initialize(_dockPlacementWindow, _dockingMessageQueue);
            window.Topmost = true;
            window.Show();
        }

        //void _showDockPlacementWindow(object args)
        //{
        //    var startPoints = this.PointToScreen(new Point());
        //    _dockPlacementWindow.Top = startPoints.Y;
        //    _dockPlacementWindow.Left = startPoints.X;
        //    _dockPlacementWindow.Height = ActualHeight;
        //    _dockPlacementWindow.Width = ActualWidth;
        //    _dockPlacementWindow.Show();

        //}


        void _dockPanelFocused(object args)
        {
            _previousActiveDockPanel?.ChangeFocusState(false);
            _previousActiveDockPanel = args as IDockPanel;
        }
        #endregion
    }
}
