using Ovotan.Controls.Docking.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovotan.Controls.Docking.Interfaces
{
    public interface IDockPanelWindow
    {
        void Initialize(DockPlacementWindow dockPlacementWindow, IDockingMessageQueue dockingMessageQueue);
    }
}
