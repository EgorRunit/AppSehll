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
        IDockContainerService _dockContainerService;
        IDockingManagerMessageQueue _dockingManagerMessageQueue;
        DockPanelSingleContainer _rootGrid;
        IDockPanel _previousActiveDockPanel;


        public DockingManager() 
        {
            _dockingManagerMessageQueue = new DockingManagerMessageQueue();
            _dockingManagerMessageQueue.Register(DockingManagerMessageType.PanelAttached, _panellAttachedCallback);
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

        void _panellAttachedCallback(object args)
        {
            _dockContainerService.AttachPanel(args as DockPanelAttachedArgs);
        }
        #endregion
    }
}
