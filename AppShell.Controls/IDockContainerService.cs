namespace AppShell.Controls
{
    public interface IDockContainerService
    {
        void AttachPanel(DockPanelAttachedArgs args);
        void RemovePanel(UI.DockPanel panel);
    }
}

