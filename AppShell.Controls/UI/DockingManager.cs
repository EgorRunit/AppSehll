using System.Windows.Controls;

namespace AppShell.Controls.UI
{
    public class DockingManager : ContentControl
    {
        /// <summary>
        /// Экземпляр сервиса для создания контейнеров для DockPanel.
        /// </summary>
        IDockContainerService _dockContainerService;
        /// <summary>
        /// Экземпляр сервиса очереди сообщений для DockingManager.
        /// </summary>
        IDockingManagerMessageQueue _dockingManagerMessageQueue;
        DockPanelSingleContainer _rootGrid;
        IDockPanel _previousActiveDockPanel;


        public DockingManager() 
        {
            _dockingManagerMessageQueue = new DockingManagerMessageQueue();
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelClosed, (x) => _dockContainerService.RemovePanel(x as DockPanel));
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelAttached, (x) => _dockContainerService.AttachPanel(x as DockPanelAttachedArgs));
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelGotFocus, _dockPanelFocused);
            _dockContainerService = new DockContainerService(_dockingManagerMessageQueue);

            var baseContent = new DockPanel(_dockingManagerMessageQueue);
            _rootGrid = new DockPanelSingleContainer(baseContent);
           Content = _rootGrid;
        }

        #region DockingManagerMessageQueue handlers
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
