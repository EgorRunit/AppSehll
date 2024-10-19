using Ovotan.Controls.Docking.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ovotan.Controls.Docking.Interfaces
{
    public interface IDockPanelWindow
    {
        FrameworkElement DockPanelContent { get; }
        void Initialize(DockPlacementWindow dockPlacementWindow, IDockingMessageQueue dockingMessageQueue);
    }
}
