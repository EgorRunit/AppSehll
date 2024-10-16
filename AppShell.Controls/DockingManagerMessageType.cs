using AppShell.Controls.UI;

namespace AppShell.Controls
{
    public enum DockingManagerMessageType
    {
        //Была приклеплена новая панель.
        PanelAttached,

    }

    public class DockingManagerPanelAttachedArgs
    {
        public DockPanelCellContent DockPanelCellContent { get; set; }
        public DockPanelAttachedType DockPanelAttachedType { get; set; }
    }
}
