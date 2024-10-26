using System.Windows;

namespace Ovotan.Windows.Controls.Docking.Interfaces
{
    public interface IDockPanelWindow
    {
        FrameworkElement DockPanelContent { get; }
        void Initialize(IDockingMessageQueue dockingMessageQueue);
    }
}
