namespace AppShell.Controls
{
    public interface ISnapPanelService
    {
        ISnapPanel Create(SnapPanelType type, ISnapManagerMessageQueue messageQueue, SnapPanelChild parent);
    }
}
