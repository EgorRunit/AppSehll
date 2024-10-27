using Ovotan.Windows.Controls.Docking.Enums;
using Ovotan.Windows.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.Docking.Messages;
using Ovotan.Windows.Controls.Docking.Services;
using Ovotan.Windows.Controls.Docking.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ovotan.Windows.Controls.Docking
{
    public class DockingHost : ContentControl
    {
        public DockPlacementWindow _dockPlacementWindow;
        /// <summary>
        /// Ссылка на последнию активную панель.
        /// </summary>
        DockPanel _oldPanelFocused;
        /// <summary>
        /// Экземпляр сервиса для создания контейнеров для DockPanel.
        /// </summary>
        IDockConstractureService _dockConstractureService;
        /// <summary>
        /// Экземпляр сервиса очереди сообщений для DockingManager.
        /// </summary>
        public IDockingMessageQueue _dockingMessageQueue;
        public ISiteHost SiteHost { get; set; }

        public DockingHost(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
            _dockPlacementWindow = new DockPlacementWindow(this, _dockingMessageQueue);
            _dockingMessageQueue.Register(DockingMessageType.PanelClosed, (x) => _dockConstractureService.RemovePanel(x as DockPanel));
            _dockingMessageQueue.Register(DockingMessageType.PanelSplitted, (x) => _dockConstractureService.SplitPanel(x as PanelSplittedMessage));
            _dockingMessageQueue.Register(DockingMessageType.PanelAttached, (x) => _panelAttached((PanelAttachedMessage)x));
            _dockingMessageQueue.Register(DockingMessageType.ShowDockPanelWindow, (x) => ShowDockPanelWindow(x as FrameworkElement));
            _dockConstractureService = new DockConstractureService(_dockingMessageQueue);

            SiteHost = new SiteHost(_dockingMessageQueue);

            var baseContent = new DockPanel(_dockingMessageQueue, SiteHost as FrameworkElement);
            Content = new PanelContainer(baseContent);
            Padding = new Thickness(5);
            Background = new SolidColorBrush(Colors.Red);
            Mouse.AddPreviewMouseDownHandler(this, (x, y) =>
            {
                if(_oldPanelFocused != null)
                {
                    _oldPanelFocused.IsPanelFocused = false;
                }
                _oldPanelFocused = y.Source as DockPanel;
                if (_oldPanelFocused != null)
                {
                    _oldPanelFocused.IsPanelFocused = true;
                }

            });

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
