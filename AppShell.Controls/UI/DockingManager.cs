using AppShell.Controls.Windows;
using System.Windows;
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
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelSplitted, (x) => _dockAttachPanel(x as PanelSPlittedMessgage));
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelGotFocus, _dockPanelFocused);
            _dockContainerService = new DockContainerService(_dockingManagerMessageQueue);

            var baseContent = new DockPanel(_dockingManagerMessageQueue);
           // _rootGrid = new DockPanelSingleContainer(baseContent);
           Content = new DockPanelSingleContainer(baseContent);
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

        void _dockAttachPanel(PanelSPlittedMessgage args)
        {
            _dockContainerService.SplitPanel(args);
            var window = new DockPlacementWindow();

            var dd = this.PointToScreen(new Point());
            window.Top = dd.Y;
            window.Left = dd.X;
            window.Height = this.ActualHeight;
            window.Width = this.ActualWidth;
            window.Show();

        }
        #endregion


        public void AttachedPanel(DockPanelAttachedType type)
        {
            var ss = (_rootGrid.Children[0] as FrameworkElement).Parent;
            
            //var args = new DockPanelAttachedArgs() { AttachedType = type, DockPanel = _rootGrid };
            //var ss = _dockContainerService.AttachPanel()
        }

    }
}
