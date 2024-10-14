namespace AppShell.Controls
{
    public class SnapPanelManager
    {
        ISnapManagerMessageQueue _messageQueue;
        ISnapPanelService _snapPanelService;

        public ISnapPanel SnapPanel { get; private set; }

        public SnapPanelManager(ISnapPanelService snapPanelService, ISnapManagerMessageQueue messageQueue) 
        {
            _messageQueue = messageQueue;
            _snapPanelService = snapPanelService;
            SnapPanel = _snapPanelService.Create(SnapPanelType.Default, _messageQueue, null);
        }
    }
}
