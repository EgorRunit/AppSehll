using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Services;
using Ovotan.Controls.Docking.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        SiteHost _siteHost;

        public DockingHost(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
            _dockPlacementWindow = new DockPlacementWindow(this, _dockingMessageQueue);
            _dockingMessageQueue.Register(DockingMessageType.PanelClosed, (x) => _dockConstractureService.RemovePanel(x as DockPanel));
            _dockingMessageQueue.Register(DockingMessageType.PanelSplitted, (x) => _dockConstractureService.SplitPanel(x as PanelSplittedMessage));
            _dockingMessageQueue.Register(DockingMessageType.PanelAttached, (x) => _panelAttached((PanelAttachedMessage)x));
            _dockingMessageQueue.Register(DockingMessageType.ShowDockPanelWindow, (x) => ShowDockPanelWindow(x as FrameworkElement));
            _dockConstractureService = new DockConstractureService(_dockingMessageQueue);

            _siteHost = new SiteHost(_dockingMessageQueue);
            var baseContent = new DockPanel(_dockingMessageQueue, _siteHost);
            Content = new PanelContainer(baseContent);
            Padding = new Thickness(5);
            Background = new SolidColorBrush(Colors.Red);
        }


        #region DockingManagerMessageQueue handlers
        void _panelAttached(PanelAttachedMessage message)
        {
            _dockConstractureService.AttachPanel(message.Type, this, message.DockPanelContent);
        }

        public void AttachPanelDock(PanelAttachedType panelAttachedType, FrameworkElement dockPanelContent)
        {
            _dockConstractureService.AttachPanel(panelAttachedType, this, dockPanelContent);
        }

        public void ShowDockPanelWindow(FrameworkElement DockPanelContent)
        { 
            var window = new DockPanelWindow(_dockPlacementWindow, DockPanelContent);
            window.Initialize(_dockingMessageQueue);
            window.Show();
        }
        #endregion
    }
}
